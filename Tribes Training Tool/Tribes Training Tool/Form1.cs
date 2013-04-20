using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProcessMemoryReaderLib;
using System.Globalization;
using System.Diagnostics;
using System.IO;

namespace Tribes_Training_Tool
{
    public partial class Form1 : Form
    {
        Process[] myProcess;
        ProcessModule mainModule;
        ProcessMemoryReader Mem = new ProcessMemoryReader();

        #region ------Addresses-------
        int[] PlayerOffsets = new int[]{0x238,  //Health
                                        0x4,    //X Pos
                                        0x8,    //Y Pos
                                        0x0,    //Z Pos
                                        0x90,   //X Speed
                                        0x94,   //Y Speed
                                        0x8C    //Z Speed                                       
                                        };
        int MainOffset = 0x238;


        PlayerData m_mainPlayerData = new PlayerData(0x00F67E90, new int[] { 0xF0, 0xEC, 0x1C, 0x14, 0x2F4 });
        PlayerData m_AIData = new PlayerData(0x00FB021C, new int[] { 0x19C, 0x10, 0x94, 0xF0, 0x2F4 });
        #endregion

        #region ------Map Spawns-------
        Vector3[,] DryDockSpawns = new Vector3[,] {{new Vector3(-22315,7345,13115),
                                                   new Vector3(-22273,6833,13649),
                                                   new Vector3(-15200,8625,-16672),
                                                   new Vector3(20000,12000,10000)},
                                                   
                                                   {new Vector3(15745,8625,-16816),
                                                   new Vector3(22240,6833,13776),
                                                   new Vector3(22992,7601,13088),
                                                   new Vector3(22326,7346,12967)}};


        Vector3[,] CrossfireSpawns = new Vector3[,] {{new Vector3(-1967,7437,18017),
                                                   new Vector3(-6703,8251,19215),
                                                   new Vector3(7036,8853,20401),
                                                   new Vector3(-560,7425,17408)},
                                                   
                                                   {new Vector3(880, 7436, -18000),
                                                   new Vector3(-7632, 8853, -20978),
                                                   new Vector3(6111, 8252, -19791),
                                                   new Vector3(-560,7425,-17408)}};
        #endregion

        PlayerDataVec m_mainPlayer = new PlayerDataVec();

        bool GameFound      = false;
        bool m_isRecording  = false;
        bool m_isPlayback = false;
        List<Vector3> m_replayPosition = new List<Vector3>();
        List<Vector3> m_replayVelocity = new List<Vector3>();
        int m_playbackState;
        int PLAYBACKMAXDISTANCE = 50;
        PlayerData m_playBackPlayer;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBoxGameChosie_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < myProcess.Length; i++)
                {
                    Debug.Print(comboBoxGameChosie.Text.Replace(myProcess[i].ProcessName + "-", ""));
                    if (comboBoxGameChosie.SelectedItem.ToString().Contains(myProcess[i].ProcessName))
                    {
                        myProcess[0] = Process.GetProcessById(int.Parse(comboBoxGameChosie.Text.Replace(myProcess[i].ProcessName + "-", "")));
                        mainModule = myProcess[0].MainModule;
                        Mem.ReadProcess = myProcess[0];
                        Mem.OpenProcess();
                        GameFound = true;
                        labelGameStatus.Text = "Ready";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to process " + ex.Message);
            }
        }

        private void comboBoxGameChosie_Click(object sender, EventArgs e)
        {
            comboBoxGameChosie.Items.Clear();
            myProcess = Process.GetProcesses();
            for (int i = 0; i < myProcess.Length; i++)
            {
                comboBoxGameChosie.Items.Add(myProcess[i].ProcessName + "-" + myProcess[i].Id);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (GameFound)
            {
                UpdatePlayerInfo();

                labelHealth.Text =  m_mainPlayer.health.ToString();
                labelXPos.Text =    m_mainPlayer.position.x.ToString();
                labelYPos.Text =    m_mainPlayer.position.y.ToString();
                labelZPos.Text =    m_mainPlayer.position.z.ToString();
                labelXSpeed.Text =  m_mainPlayer.velocity.x.ToString();
                labelYSpeed.Text =  m_mainPlayer.velocity.y.ToString();
                labelZSpeed.Text =  m_mainPlayer.velocity.z.ToString();

                int aiBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + m_AIData.baseAddress, 4, m_AIData.multiLevel);

                labelAIHealth.Text = "" + Mem.ReadInt(aiBase - MainOffset + PlayerOffsets[0]);
                labelAIXPos.Text = "" + Mem.ReadFloat(aiBase - MainOffset + PlayerOffsets[1]);
                labelAIYPos.Text = "" + Mem.ReadFloat(aiBase - MainOffset + PlayerOffsets[2]);
                labelAIZPos.Text = "" + Mem.ReadFloat(aiBase - MainOffset + PlayerOffsets[3]);
                
                CheckRecording();
            }


            try
            {
                if (myProcess != null)
                {
                    if (myProcess[0].HasExited)
                        GameFound = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error " + ex.Message);
            }
        }

        void UpdatePlayerInfo()
        {
            int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + m_mainPlayerData.baseAddress, 4, m_mainPlayerData.multiLevel);

            Vector3 pos = new Vector3(Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[1]),
                                      Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[2]),
                                      Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[3]));

            Vector3 velo = new Vector3(Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[4]),
                                       Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[5]),
                                       Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[6]));

            m_mainPlayer.Update( Mem.ReadInt(playerBase - MainOffset + PlayerOffsets[0]), pos, velo);
        }

        void CheckRecording()
        {
            if (m_isRecording)
            {
                int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + m_mainPlayerData.baseAddress, 4, m_mainPlayerData.multiLevel);
                Vector3 vec = new Vector3();
                vec.x = m_mainPlayer.position.x;
                vec.y = m_mainPlayer.position.y;
                vec.z = m_mainPlayer.position.z;
                m_replayPosition.Add(vec);

                vec = new Vector3();
                vec.x = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[4]);
                vec.y = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[5]);
                vec.z = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[6]);
                m_replayVelocity.Add(vec);

                labelRecordPlayback.Text = "Recording";

            }
            else if (m_isPlayback)
            {
                if (m_playbackState >= m_replayPosition.Count)
                {
                    m_isPlayback = false;
                    return;
                }

                int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + m_playBackPlayer.baseAddress, 4, m_playBackPlayer.multiLevel);
                Vector3 vec = new Vector3();
                vec.x = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[1]);
                vec.y = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[2]);
                vec.z = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[3]);

                float distance = Vector3.Distance(vec, m_replayPosition[m_playbackState]); 
                if (distance > PLAYBACKMAXDISTANCE)                                 //Make sure the player doesen't get to desynced
                {
                    SetPlayerPosition(m_playBackPlayer, m_replayPosition[m_playbackState]);
                }

                SetPlayerVelocity(m_playBackPlayer, m_replayVelocity[m_playbackState]);
                m_playbackState++;

                labelRecordPlayback.Text = "Playback";
            }
            else
            {
                labelRecordPlayback.Text = "Idle";
            }
        }

        void SetPlayerPosition(PlayerData player, Vector3 pos)
        {
            int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + player.baseAddress, 4, player.multiLevel);

            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[1], pos.x);
            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[2], pos.y);
            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[3], pos.z);
        }

        void SetPlayerVelocity(PlayerData player, Vector3 velocity)
        {
            int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + player.baseAddress, 4, player.multiLevel);

            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[4], velocity.x);
            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[5], velocity.y);
            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[6], velocity.z);
        }

        void SetHealth(PlayerData player, int health)
        {
            int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + player.baseAddress, 4, player.multiLevel);

            Mem.WriteInt(playerBase - MainOffset + PlayerOffsets[0], health);
        }



        private void buttonRecord_Click(object sender, EventArgs e)
        {
            m_isRecording = !m_isRecording;

            if (m_isRecording)
            {
                m_isPlayback = false;
                m_replayPosition.Clear();
                m_replayVelocity.Clear();
            }
        }

        private void buttonPlayback_Click(object sender, EventArgs e)
        {
            m_isPlayback = !m_isPlayback;

            if (m_isPlayback)
            {
                m_playBackPlayer = m_mainPlayerData;
                m_isRecording = false;
                m_playbackState = 0;
                SetPlayerPosition(m_playBackPlayer, m_replayPosition[0]);
            }
        }

        private void buttonPlaybackAI_Click(object sender, EventArgs e)
        {
            m_isPlayback = !m_isPlayback;

            if (m_isPlayback)
            {
                m_playBackPlayer = m_AIData;
                m_isRecording = false;
                m_playbackState = 0;
                SetPlayerPosition(m_playBackPlayer, m_replayPosition[0]);
                SetHealth(m_playBackPlayer, 100000);                         //Give the bot lots of hp so he doesen't die while going on the path
            }
        }



        void SpawnButton(int team, int id)
        {
            if (comboBoxMap.SelectedIndex == 0)
            {
                SetPlayerPosition(m_mainPlayerData, DryDockSpawns[team, id]);
            }
            else if (comboBoxMap.SelectedIndex == 1)
            {
                SetPlayerPosition(m_mainPlayerData, CrossfireSpawns[team, id]);
            }
        }

        #region HEALTH BUTTONS
        private void buttonSetHealth900_Click(object sender, EventArgs e)
        {
            SetHealth(m_mainPlayerData, 900);
        }

        private void button2SetHealth1000000_Click(object sender, EventArgs e)
        {
            SetHealth(m_mainPlayerData, 1000000);
        }
        #endregion

        #region SPAWN BUTTONS
        private void buttonBESpawn1_Click(object sender, EventArgs e)
        {
            SpawnButton(0, 0);
        }

        private void buttonBESpawn2_Click(object sender, EventArgs e)
        {
            SpawnButton(0, 1);
        }

        private void buttonBESpawn3_Click(object sender, EventArgs e)
        {
            SpawnButton(0, 2);
        }

        private void buttonBESpawn4_Click(object sender, EventArgs e)
        {
            SpawnButton(0, 3);
        }

        private void buttonDSSpawn1_Click(object sender, EventArgs e)
        {
            SpawnButton(1, 0);
        }

        private void buttonDSSpawn2_Click(object sender, EventArgs e)
        {
            SpawnButton(1, 1);
        }

        private void buttonDSSpawn3_Click(object sender, EventArgs e)
        {
            SpawnButton(1, 2);
        }

        private void buttonDSSpawn4_Click(object sender, EventArgs e)
        {
            SpawnButton(1, 3);
        }

        #endregion

        private void buttonImportReplay_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "replay files (*.replay)|*.replay|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            m_replayPosition.Clear();
                            m_replayVelocity.Clear();

                            StreamReader sr = new StreamReader(myStream);

                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] posSplit = line.Split('.');
                                Vector3 vec = new Vector3(float.Parse(posSplit[0]), float.Parse(posSplit[1]), float.Parse(posSplit[2]));
                                Vector3 vel = new Vector3(float.Parse(posSplit[3]), float.Parse(posSplit[4]), float.Parse(posSplit[5]));
                                m_replayPosition.Add(vec);
                                m_replayVelocity.Add(vel);
                            }

                           /* string wholeString = sr.ReadToEnd();

                            string[] posList = wholeString.Split('+');
                            foreach (string str in posList)
                            {
                                string[] posSplit = str.Split('.');
                                Vector3 vec = new Vector3(float.Parse(posSplit[0]), float.Parse(posSplit[1]), float.Parse(posSplit[2]));
                                Vector3 vel = new Vector3(float.Parse(posSplit[3]), float.Parse(posSplit[4]), float.Parse(posSplit[5]));
                                m_replayPosition.Add(vec);
                                m_replayVelocity.Add(vel);
                            }*/
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void buttonExportReplay_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "replay files (*.replay)|*.replay|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter sw = new StreamWriter(myStream);
                    sw.Flush();
                    int i = 0;
                    foreach (Vector3 vec in m_replayPosition)
                    {
                        Vector3 vel = m_replayVelocity[i];                       

                        string str = vec.x + "." + vec.y + "." + vec.z + "." + vel.x  + "." + vel.y  + "." + vel.z;
                        sw.WriteLine(str);
                        
                        i++;
                    }

                    sw.Close();
                    myStream.Close();
                }
            }
        }
    }
}
