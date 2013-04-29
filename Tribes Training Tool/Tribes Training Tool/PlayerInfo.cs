using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tribes_Training_Tool
{
    //Stores pointers to our player, NO actual information is stored here e.g. Health:100 instead we get 
    //We then use "PlayerDataVec" to store all the information such as remaining health ETC
    public class PlayerData
    {
        public PlayerData(int baseAddress, int[] multiLevel)
        {
            this.baseAddress = baseAddress;
            this.multiLevel = multiLevel;
        }

        public int baseAddress;
        public int[] multiLevel;

        public int health = 0;
        public bool isDead = false;
        public bool respawned = false;

        public Vector3 position = new Vector3(0, 0, 0);
        public Vector3 velocity = new Vector3(0, 0, 0);


        public void Update(int health, Vector3 position, Vector3 velocity)
        {
            this.health = health;
            this.position = position;
            this.velocity = velocity;

            respawned = false;
            if (isDead == true && health > 0)
            {
                respawned = true;
                isDead = false;
            }
            else if (health <= 0)
            {
                isDead = true;
            }
        }
    }
}
