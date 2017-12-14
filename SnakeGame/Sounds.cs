using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SnakeGame
{
    public static class Sounds
    {
        public static void playEat() //jedzenie
        {
            SoundPlayer eat = new SoundPlayer(@"Dzwiek\1.wav");
            eat.Play();
        }

        public static void playLose() //przegrana
        {
            SoundPlayer lose = new SoundPlayer(@"Dzwiek\2.wav");
            lose.Play();
        }
    }
}
