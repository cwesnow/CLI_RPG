﻿namespace RPG_Text_Game
{
    class NPC
    {
        public string name { get; private set; }
        public string description { get; private set; }

        public NPC(string Title, string Look) {
            this.name = Title;
            this.description = Look;
        }
    }
}