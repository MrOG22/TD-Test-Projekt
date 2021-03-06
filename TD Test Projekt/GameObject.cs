﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Test_Projekt
{
    abstract class GameObject
    {
        protected Texture2D texture;

        protected Vector2 position;
        protected Vector2 velocity;

        protected Vector2 center;
        protected Vector2 origin;

        protected float rotation;

        public Vector2 Center
        {
            get { return center; }
        }

        public GameObject(Texture2D tex, Vector2 pos)
        {
            texture = tex;
            position = pos;
            velocity = Vector2.Zero;

            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Update(GameTime gameTime)
        {
            this.center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, center, null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0);
        }

    }
}
