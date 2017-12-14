using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    class Piece
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Piece()
        {
            X = 192;
            Y = 256;
        }

        public void Move(int direction)
        {
            switch (direction) // 0 - UP, 1 - DOWN, 2 - LEF, 3 - RIGHT
            {
                case 0:
                    Y += 32;
                    break;
                case 1:
                    Y -= 32;
                    break;
                case 2:
                    X -= 32;
                    break;
                case 3:
                    X += 32;
                    break;
            }
        }

        public void Generate_Food()
        {
            Random rand = new Random();
            X = rand.Next(4, 26)*32;
            Y = rand.Next(4, 16)*32;
        }
    }
}
