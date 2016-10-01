namespace RPG_Text_Game
{
    class Item
    {
        public string name { get; private set; }
        public string description { get; private set; }

        public Item(string Title, string Look)
        {
            this.name = Title;
            this.description = Look;
        }
    }
}
