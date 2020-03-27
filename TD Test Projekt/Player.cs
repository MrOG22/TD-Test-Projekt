using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Test_Projekt
{
    class Player
    {
        private int money = 50;

        private List<Towers> towers = new List<Towers>();

        private MouseState mouseState;
        private MouseState prevMouseState;

        public int Money
        {
            get { return money; }
        }

        private Level level;

        public Player(Level level)
        {
            this.level = level;
        }

        private int cellX;
        private int cellY;
        private int tileX;
        private int tileY;

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            cellX = (int)(mouseState.X / 32);
            cellY = (int)(mouseState.Y / 32);

            tileX = cellX * 32;
            tileY = cellY * 32;

            prevMouseState = mouseState;
        }
    }
}
