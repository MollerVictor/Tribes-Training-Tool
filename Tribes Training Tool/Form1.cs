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

namespace Tribes_Training_Tool
{
    public class Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3()
        {
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            float distance = 0;
            distance += Math.Abs(a.X - b.X);
            distance += Math.Abs(a.Y - b.Y);
            distance += Math.Abs(a.Z - b.Z);
            return distance;
        }

    }

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
        PlayerData m_AIData = new PlayerData(0x00FB40F4, new int[] { 0x10, 0x50, 0x250,  0x2B0, 0x2F4 });
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

        bool GameFound      = false;
        bool m_isRecording  = false;
        bool m_isPlayback = false;
        List<Vector3> m_record = new List<Vector3>();
        List<Vector3> m_recordVelocity = new List<Vector3>();
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
                int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + m_mainPlayerData.baseAddress, 4, m_mainPlayerData.multiLevel);
                
                labelBaseGameAdress.Text = "" + myProcess[0].MainModule.BaseAddress;
                label3.Text = m_mainPlayerData.baseAddress.ToString("x");
                label2.Text = playerBase.ToString("x");                
               
                labelHealth.Text = "" + Mem.ReadInt(playerBase - MainOffset + PlayerOffsets[0]);
                labelXPos.Text = "" + Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[1]);
                labelYPos.Text = "" + Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[2]);
                labelZPos.Text = "" + Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[3]);
                labelXSpeed.Text = "" + Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[4]);
                labelYSpeed.Text = "" + Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[5]);
                labelZSpeed.Text = "" + Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[6]);

                int aiBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + m_AIData.baseAddress, 4, m_AIData.multiLevel);

                labelAIHealth.Text = "" + Mem.ReadInt(aiBase - MainOffset + PlayerOffsets[0]);
                labelAIXPos.Text = "" + Mem.ReadFloat(aiBase - MainOffset + PlayerOffsets[1]);
                labelAIYPos.Text = "" + Mem.ReadFloat(aiBase - MainOffset + PlayerOffsets[2]);
                labelAIZPos.Text = "" + Mem.ReadFloat(aiBase - MainOffset + PlayerOffsets[3]);
                
                CheckRecording();

            }
            else
                label2.Text = "False";


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

        void CheckRecording()
        {
            if (m_isRecording)
            {
                int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + m_mainPlayerData.baseAddress, 4, m_mainPlayerData.multiLevel);
                Vector3 vec = new Vector3();
                vec.X = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[1]);
                vec.Y =Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[2]);
                vec.Z =Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[3]);
                m_record.Add(vec);

                vec = new Vector3();
                vec.X = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[4]);
                vec.Y = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[5]);
                vec.Z = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[6]);
                m_recordVelocity.Add(vec);

                labelRecordPlayback.Text = "Recording";

            }
            else if (m_isPlayback)
            {
                if (m_playbackState >= m_record.Count)
                {
                    m_isPlayback = false;
                    return;
                }

                int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + m_playBackPlayer.baseAddress, 4, m_playBackPlayer.multiLevel);
                Vector3 vec = new Vector3();
                vec.X = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[1]);
                vec.Y = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[2]);
                vec.Z = Mem.ReadFloat(playerBase - MainOffset + PlayerOffsets[3]);

                float distance = Vector3.Distance(vec, m_record[m_playbackState]);
                Debug.Print(distance.ToString());
                if (distance > PLAYBACKMAXDISTANCE)
                {
                    SetPlayerPosition(m_playBackPlayer, m_record[m_playbackState]);
                }

                SetPlayerVelocity(m_playBackPlayer, m_recordVelocity[m_playbackState]);
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

            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[1], pos.X);
            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[2], pos.Y);
            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[3], pos.Z);
        }

        void SetPlayerVelocity(PlayerData player, Vector3 velocity)
        {
            int playerBase = Mem.ReadMultiLevelPointer(myProcess[0].MainModule.BaseAddress.ToInt32() + player.baseAddress, 4, player.multiLevel);

            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[4], velocity.X);
            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[5], velocity.Y);
            Mem.WriteFloat(playerBase - MainOffset + PlayerOffsets[6], velocity.Z);
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
                m_record.Clear();
                m_recordVelocity.Clear();
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
                SetPlayerPosition(m_playBackPlayer, m_record[0]);
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
                SetPlayerPosition(m_playBackPlayer, m_record[0]);
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
    }
}
