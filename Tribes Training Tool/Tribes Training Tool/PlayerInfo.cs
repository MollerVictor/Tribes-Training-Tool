using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tribes_Training_Tool
{
    //Stores pointers to our player, NO actual information is stored here e.g. Health:100 instead we get 
    //Health:0x123E2A(The address in memory)
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
}
