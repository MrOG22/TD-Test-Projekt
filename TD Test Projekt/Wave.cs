using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Test_Projekt
{
    class Wave
    {
        private int numberOfStudents;
        //antallet af studerendende der skal være i en Wave.
        private int waveNumber;
        //hvilken wave har vi gang i.
        private float spawnTimer = 0;
        //hvornår skal der spawnes en studerende.
        private int studentsSpawned = 0;
        //hvor mange studerende skal der spawnes.

        private bool studentAtGoal;
        //er en studerende nået i mål.
        private bool spawningStudents;
        //spawner vi stadig studerende.
        private Level level;
        // her refererer  vi til vores level.
        private Texture2D studentTexture;
        // dette er til at give texture til students.
        public List<Student> students = new List<Student>();
        //dette er en liste med vores students.

        public bool RoundDone
        {
            get { return students.Count == 0 && studentsSpawned == numberOfStudents; }
        }


        public int RoundNumber
        {
            get { return waveNumber; }
        }

        public bool StudentAtGoal
        {
            get { return studentAtGoal; }
            set { studentAtGoal = value; }
        }

        public List<Student> Students
        {
            get { return students; }

        }

        public Wave(int waveNumber, int NumberOfStudents, Level level, Texture2D studentTexture)
        {
            this.waveNumber = waveNumber;
            this.numberOfStudents = NumberOfStudents;
            this.level = level;
            this.studentTexture = studentTexture;
        }

        private void AddStudent()
        {
            Student student = new Student(studentTexture, level.Waypoints.Peek(), 100, false, 0.5f);
            student.SetWaypoints(level.Waypoints);
            students.Add(student);
            spawnTimer = 0;

            studentsSpawned++;

            if (waveNumber == 5)
            {
                float speed = 2.0f;

                student = new Student(studentTexture, level.Waypoints.Peek(), 100, false, speed);
                student.SetWaypoints(level.Waypoints);
            }
        }
        
        public void Start()
        {
            spawningStudents = true;
        }

        public void Update(GameTime gameTime)
        {
            if (studentsSpawned == numberOfStudents)
            {
                spawningStudents = false;

            }
            if (spawningStudents)
            {
                spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnTimer < 2)
                    AddStudent();
            }

            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];
                student.Update(gameTime);
                if (student.IsDead)
                {
                    if (student.CurrentHealth > 0)
                    {
                        studentAtGoal = true;
                    }

                    students.Remove(student);
                    i--;
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Student student in students)
                student.Draw(spriteBatch);
        }




    }
}
