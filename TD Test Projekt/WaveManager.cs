using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Test_Projekt
{
    class WaveManager
    {
        private int numberOfWaves;
        //hvor mange waves spillet skal have.
        private float timeSinceLastWave;
        //hvor langt der går efter den sidste wave sluttede.
        private Queue<Wave> waves = new Queue<Wave>();
        //skaber en kø med alle vores waves i.
        private Texture2D studentTexture;
        //Texture til vores studerende.
        private bool finishedWave = false;
        //er den nuværende bølge ovre.
        private Level level;
        
        public Wave CurrentWave
        {
            get { return waves.Peek(); }
        }

        public List<Student> Students
        {
            get { return CurrentWave.Students; }
        }

        public int Round
        {
            get { return CurrentWave.RoundNumber + 1; }
        }

        public WaveManager(Level level, int numberOfWaves, Texture2D studentTexture)
        {
            this.numberOfWaves = numberOfWaves;
            this.studentTexture = studentTexture;

            this.level = level;

            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumbOfStudents = 6;
                int numberModifier = (i / 6) + 1;
                Wave wave = new Wave(i, initialNumbOfStudents * numberModifier, level, studentTexture);

                waves.Enqueue(wave);
            }
        }
    }
}
