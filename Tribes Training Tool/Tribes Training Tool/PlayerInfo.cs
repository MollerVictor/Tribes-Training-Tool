using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tribes_Training_Tool
{
    //Stores pointers to our player, NO actual information is stored here e.g. Health:100 instead we get 
    //We then use "PlayerDataVec" to store all the information such as remaining health ETC
    public struct PlayerData
    {
        public PlayerData(int baseAddress, int[] multiLevel)
        {
            this.baseAddress = baseAddress;
            this.multiLevel = multiLevel;
        }

        public int baseAddress;
        public int[] multiLevel;
        //ALL THESE BELOW ARE pointers to our player's information
        //public PlayerDataAddr offsets;
    }

    //Here we store the actual contents of the memory addresses usually within "PlayerData" we
    public struct PlayerDataVec
    {
        //public float xMouse;
        //public float yMouse;
        public int     health;
        public Vector3 position;
        public Vector3 velocity;

        public void Update(int health,Vector3 position, Vector3 velocity)
        {
            this.health = health;
            this.position = position;
            this.velocity = velocity;
        }
    }
}
