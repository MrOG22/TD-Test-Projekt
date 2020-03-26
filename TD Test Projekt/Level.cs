using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Test_Projekt
{
    class Level
    {
        private Queue<Vector2> waypoints = new Queue<Vector2>();

        public Level()
        {
            waypoints.Enqueue(new Vector2(0, 0) * 32);
            waypoints.Enqueue(new Vector2(1, 0) * 32);
            waypoints.Enqueue(new Vector2(2, 0) * 32);
            waypoints.Enqueue(new Vector2(3, 0) * 32);
            waypoints.Enqueue(new Vector2(4, 0) * 32);
            waypoints.Enqueue(new Vector2(4, 1) * 32);
            waypoints.Enqueue(new Vector2(4, 3) * 32);
            waypoints.Enqueue(new Vector2(5, 3) * 32);
            waypoints.Enqueue(new Vector2(6, 3) * 32);
            waypoints.Enqueue(new Vector2(7, 3) * 32);
            waypoints.Enqueue(new Vector2(7, 2) * 32);
            waypoints.Enqueue(new Vector2(8, 2) * 32);
            waypoints.Enqueue(new Vector2(9, 2) * 32);
            waypoints.Enqueue(new Vector2(10, 2) * 32);
            waypoints.Enqueue(new Vector2(10, 3) * 32);
            waypoints.Enqueue(new Vector2(10, 4) * 32);
            waypoints.Enqueue(new Vector2(10, 5) * 32);
            waypoints.Enqueue(new Vector2(9, 5) * 32);
            waypoints.Enqueue(new Vector2(8, 5) * 32);
            waypoints.Enqueue(new Vector2(7, 5) * 32);
            waypoints.Enqueue(new Vector2(6, 5) * 32);
            waypoints.Enqueue(new Vector2(5, 5) * 32);
            waypoints.Enqueue(new Vector2(5, 6) * 32);
            waypoints.Enqueue(new Vector2(4, 6) * 32);
            waypoints.Enqueue(new Vector2(3, 6) * 32);
            waypoints.Enqueue(new Vector2(3, 7) * 32);
            waypoints.Enqueue(new Vector2(3, 8) * 32);
            waypoints.Enqueue(new Vector2(3, 9) * 32);
            waypoints.Enqueue(new Vector2(3, 10) * 32);
            waypoints.Enqueue(new Vector2(4, 10) * 32);
            waypoints.Enqueue(new Vector2(5, 10) * 32);
            waypoints.Enqueue(new Vector2(6, 10) * 32);
            waypoints.Enqueue(new Vector2(6, 9) * 32);
            waypoints.Enqueue(new Vector2(6, 8) * 32);
            waypoints.Enqueue(new Vector2(6, 7) * 32);
            waypoints.Enqueue(new Vector2(7, 7) * 32);
            waypoints.Enqueue(new Vector2(8, 7) * 32);
            waypoints.Enqueue(new Vector2(9, 7) * 32);
            waypoints.Enqueue(new Vector2(9, 8) * 32);
            waypoints.Enqueue(new Vector2(9, 9) * 32);
            waypoints.Enqueue(new Vector2(9, 10) * 32);
        }


        int[,] map = new int[,] //Level layout.
        {
            {1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,1,0,0,1,1,1,1},
            {0,0,0,0,1,1,1,1,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,1,1,1,1,1,1},
            {0,0,0,1,1,1,0,0,0,0,0},
            {0,0,0,1,0,0,1,1,1,1,0},
            {0,0,0,1,0,0,1,0,0,1,0},
            {0,0,0,1,0,0,1,0,0,1,0},
            {0,0,0,1,1,1,1,0,0,1,0}
        };

        public int Width //Banens bredde.
        { get { return map.GetLength(1); } }

        public int Height //Banens Højde
        {
            get { return map.GetLength(0); }
        }

        private List<Texture2D> tileTextures = new List<Texture2D>(); // dette er en liste over de textures vi skal bruge til banen.

        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }


        public void AddTexture(Texture2D texture) // med denne metode kan vi adde textures til vores liste.
        {
            tileTextures.Add(texture);
        }

        public void Draw(SpriteBatch spriteBatch) // denne funktion placere vores tiles udfra det layout der blev lavet tidligere. Den kører et for loop inde i et for loop.
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;
                    Texture2D texture = tileTextures[textureIndex];
                    spriteBatch.Draw(texture, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                }
            }
        }
    }
}
