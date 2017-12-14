using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
/*
 * Dodanie ustawień (Szerokość mapy, wysokość) - DO ZROBIENIA 
 * Dodanie BEST SCORE - DO ZROBIENIA
 * Nowy system wykrywania kolizji - DO ZRObIENIA 
 * ładne okono początkowe / win / lose - DO ZROBIENIA
 * 
*/

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private int direction = 0; //odpowiada za kierunek poruszania się Snake'a
        private int width = 32; // szerokosc 1 'czesci' snake'a
        private int tempDirection = 0;
        private int tempSpeed;
        private int height = 32; // wysokosc 1 'czesci' snake'a
        private int gameSpeed = 30; // zmienna odpowiadajaca za szybkosc gry gameTimer.Interval = 10 000 / gameSpeed
        private int score = 0; // wynik
        private bool gameover = false; // zmienna przechowująca wynik gry: false - gra w toku / true - przegrana, ekran przegranej
        private bool welcome = true; // ekran powitalny
        Piece food = new Piece(); // tworzy obiekt jedzenia
        List<Piece> SnakeBody = new List<Piece>(); // tworzy liste 'czesci' snake'a
        Bitmap owoc = new Bitmap(@"Grafika\owocCzerwony.png");
        private int up = 1;
        private int down = 0;
        private int left = 2;
        private int right = 3;
        private int kolor=0;





        public Form1()
        {
            InitializeComponent();
            buttonStart.Enabled = true; // true - przycisk start mozna wlaczyc / false - nie mozna
            gameTimer.Tick += new EventHandler(Update); // Update - główna pętla gry
        }

        private void StartGame() // funkcja odpowiedzialna za Rozpoczęcie Gry
        {
            gameover = false; //ukrywa ekran koncowy
            welcome = false; //ukrywa ekran powitalny
            buttonStart.Visible = false;
            buttonStart.Enabled = false;
            lblScore.Visible = true;
            up = 1;
            down = 0;
            left = 2;
            right = 3;
            gameSpeed = 20; // początkowa prędkość gry
            score = 0;
            tempDirection = 0;
            direction = 0;// na początku Snake idzie w dół
            food.Generate_Food(); // generuje pierwsze jedzenie na mapie
            SnakeBody.Clear(); // czyści liste czesci snake'a
            Piece head = new Piece(); // tworzy głowę snake'a
            SnakeBody.Add(head); // dodaje głowę do listy części
            gameTimer.Interval = 3000 / gameSpeed; ; // ustawia początkową prędkość gry
            snakeTimer.Interval = gameTimer.Interval;
            gameTimer.Start(); //startuje główną pętlę gry
            snakeTimer.Start();
        }

        private void GameOver() // odpowiada za koniec gry
        {
            buttonStart.Visible = true;
            lblScore.Visible = false;
            Sounds.playLose();
            gameover = true;
            gameTimer.Stop();
            snakeTimer.Stop();
            buttonStart.Enabled = true; //grę można znowu wystartować
            blueTimer.Stop();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // sprawdza jaki klawisz na klawiaturze był wcisniety, i zmienia kierunek snake'a
        {
            switch (e.KeyData) // 
            {
                case Keys.Down: //dół 
                    if (SnakeBody.Count >= 2 && tempDirection == up)  // Jeżeli Snake składa się z więcej niż 2 części i idzie w górę nie pozwól mu iść w dół (żeby sam się nie zjadł)
                        break;
                    else // jeżeli nie idź w dół
                        direction = down;
                    break;
                case Keys.S://dół
                    if (SnakeBody.Count >= 2 && tempDirection == up)// 0 - down, 1 - up, 2 - left, 3 - right,
                        break;
                    else
                        direction = down;
                    break;

                case Keys.Up:
                    if (SnakeBody.Count >= 2 && tempDirection ==down)
                        break;
                    else
                        direction = up;
                    break;
                case Keys.W:
                    if (SnakeBody.Count >= 2 && tempDirection == down)
                        break;
                    else
                        direction = up;
                    break;

                case Keys.Left:
                    if (SnakeBody.Count >= 2 && tempDirection == right)
                        break;
                    else
                        direction = left;
                    break;
                case Keys.A:
                    if (SnakeBody.Count >= 2 && tempDirection == right)
                        break;
                    else
                        direction = left;
                    break;

                case Keys.Right:
                    if (SnakeBody.Count >= 2 && tempDirection == left)
                        break;
                    else
                        direction = right;
                    break;
                case Keys.D:
                    if (SnakeBody.Count >= 2 && tempDirection == left)
                        break;
                    else
                        direction = right;
                    break;

            }
            e.SuppressKeyPress = true;
        }

        private void pbGameScr_Paint(object sender, PaintEventArgs e) //odpowiada za 'grafike'
        {
            Graphics graphics = e.Graphics;
            Graphics blackout = e.Graphics;
            if (welcome) // ekran powitalny
            {
                Font font = new System.Drawing.Font("Tw Cen MT", 100, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                string tittle_msg = "Snake";
                int center_width = pbGameScr.Width / 2;
                SizeF msg_size = graphics.MeasureString(tittle_msg, font);
                PointF msg_point = new PointF(center_width - msg_size.Width / 2, 100);
                graphics.DrawString(tittle_msg, font, Brushes.Purple, msg_point);

                Font font2 = new System.Drawing.Font("Tw Cen MT", 25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                string tittle_msg2 = "Sterowanie:";
                msg_size = graphics.MeasureString(tittle_msg2, font2);
                msg_point = new PointF(center_width - msg_size.Width / 2, 250);
                graphics.DrawString(tittle_msg2, font2, Brushes.Black, msg_point);

                string tittle_msg3 = "WASD lub STRZAŁKI";
                msg_size = graphics.MeasureString(tittle_msg3, font2);
                msg_point = new PointF(center_width - msg_size.Width / 2, 280);
                graphics.DrawString(tittle_msg3, font2, Brushes.Black, msg_point);



            }
            else
            {
                if (gameover) // ekran po przegranej
                {
                    Font font = new System.Drawing.Font("Tw Cen MT", 65, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    string tittle_msg = "PRZEGRAŁEŚ";
                    int center_width = pbGameScr.Width / 2;
                    SizeF msg_size = graphics.MeasureString(tittle_msg, font);
                    PointF msg_point = new PointF(center_width - msg_size.Width / 2, 140);
                    graphics.DrawString(tittle_msg, font, Brushes.Red, msg_point);

                    Font font2 = new System.Drawing.Font("Tw Cen MT", 25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    string tittle_msg2 = "Aby zagrać ponownie nacisnij GRAJ!";
                    msg_size = graphics.MeasureString(tittle_msg2, font2);
                    msg_point = new PointF(center_width - msg_size.Width / 2, 250);
                    graphics.DrawString(tittle_msg2, font2, Brushes.Black, msg_point);
                }
                else
                {
                    graphics.DrawImage(owoc, food.X, food.Y, width, height); // jedzenie
                    for (int i = 0; i < SnakeBody.Count; i++) // generuj snake'a
                    {
                        //Brush snake_color = i == 0 ? Brushes.Red : Brushes.Black; // jeżeli dany obiekt jest głową koloruj na czerwono jeżeli nie to na czarno
                        if (i == 0) // GŁOWA
                        {
                            switch (tempDirection)
                            {
                                case 0: // UP
                                    graphics.DrawImage(new Bitmap(@"Grafika\headDown.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                                    break;
                                case 1: //down
                                    graphics.DrawImage(new Bitmap(@"Grafika\headUp.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                                    break;
                                case 2: //left
                                    graphics.DrawImage(new Bitmap(@"Grafika\headLeft.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                                    break;
                                case 3: //right
                                    graphics.DrawImage(new Bitmap(@"Grafika\headRight.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                                    break;
                            }
                        }
                        else if (i == SnakeBody.Count-1)
                        {
                            if (SnakeBody[i].Y > SnakeBody[i-1].Y)
                            {
                                graphics.DrawImage(new Bitmap(@"Grafika\endUp.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                            }
                            else if (SnakeBody[i].Y < SnakeBody[i - 1].Y)
                            {
                                graphics.DrawImage(new Bitmap(@"Grafika\endDown.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                            }
                            else if(SnakeBody[i].X > SnakeBody[i - 1].X)
                            {
                                graphics.DrawImage(new Bitmap(@"Grafika\endLeft.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                            }
                            else if(SnakeBody[i].X < SnakeBody[i - 1].X)
                            {
                                graphics.DrawImage(new Bitmap(@"Grafika\endRight.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                            }
                        }//Kolano Góra-prawo,  prawo-dół
                        else if ((SnakeBody[i].X == SnakeBody[i + 1].X - width && SnakeBody[i].Y == SnakeBody[i + 1].Y && SnakeBody[i].X == SnakeBody[i - 1].X && SnakeBody[i].Y == SnakeBody[i - 1].Y - width) || (SnakeBody[i].X == SnakeBody[i - 1].X - width && SnakeBody[i].Y == SnakeBody[i - 1].Y && SnakeBody[i].X == SnakeBody[i + 1].X && SnakeBody[i].Y == SnakeBody[i + 1].Y - width))
                        {
                            graphics.DrawImage(new Bitmap(@"Grafika\kolanoGL.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                        }//kolanp Góra-lewo, lewo-doł
                        else if ((SnakeBody[i].X == SnakeBody[i - 1].X + width && SnakeBody[i].Y == SnakeBody[i - 1].Y && SnakeBody[i].X == SnakeBody[i + 1].X && SnakeBody[i].Y == SnakeBody[i + 1].Y - width) || (SnakeBody[i].X == SnakeBody[i + 1].X + width && SnakeBody[i].Y == SnakeBody[i + 1].Y && SnakeBody[i].X == SnakeBody[i - 1].X && SnakeBody[i].Y == SnakeBody[i - 1].Y - width))
                        {
                            graphics.DrawImage(new Bitmap(@"Grafika\kolanoGP.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                        }
                        else if ((SnakeBody[i].X == SnakeBody[i - 1].X - width && SnakeBody[i].Y == SnakeBody[i - 1].Y && SnakeBody[i].X == SnakeBody[i + 1].X && SnakeBody[i].Y == SnakeBody[i + 1].Y + width) || (SnakeBody[i].X == SnakeBody[i + 1].X - width && SnakeBody[i].Y == SnakeBody[i + 1].Y && SnakeBody[i].X == SnakeBody[i - 1].X && SnakeBody[i].Y == SnakeBody[i - 1].Y + width))
                        {
                            graphics.DrawImage(new Bitmap(@"Grafika\kolanoDP.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                        }
                        else if ((SnakeBody[i].X == SnakeBody[i + 1].X + width && SnakeBody[i].Y == SnakeBody[i + 1].Y && SnakeBody[i].X == SnakeBody[i - 1].X && SnakeBody[i].Y == SnakeBody[i - 1].Y + width) || (SnakeBody[i].X == SnakeBody[i - 1].X + width && SnakeBody[i].Y == SnakeBody[i - 1].Y && SnakeBody[i].X == SnakeBody[i + 1].X && SnakeBody[i].Y == SnakeBody[i + 1].Y + width))
                        {
                            graphics.DrawImage(new Bitmap(@"Grafika\kolanoDL.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                        }
                        else
                            graphics.DrawImage(new Bitmap(@"Grafika\body.png"), SnakeBody[i].X, SnakeBody[i].Y, width, height);
                        //graphics.FillEllipse(Brushes.Black, new Rectangle(SnakeBody[i].X, SnakeBody[i].Y, width, height));
                    }
                }


                lblScore.Text = score.ToString(); // rysuj wynik
                //lblSpeed.Text = (gameSpeed - 20).ToString(); // rysuj wynik
            }
        }

        private void Update(object sender, EventArgs e) //główna mechanika gry
        {
            for (int i = SnakeBody.Count - 1; i >= 0; i--) //przebieg przez wszystkie czesci snake'a
            {
                if (i == 0) // działa na głowie snake'a
                {

                    if (SnakeBody[0].X == food.X && SnakeBody[0].Y == food.Y) //zetknięcie się z jedzeniem
                    {
                        Sounds.playEat();
                        if (kolor == 1)
                            niebieski();
                        if (kolor == 2)
                            zielony();
                        if (score > 10 && gameSpeed < 30)
                            gameSpeed++;
                        gameTimer.Interval = 3000 / gameSpeed;
                        snakeTimer.Interval = gameTimer.Interval;
                        Piece body = new Piece();
                        body.X = SnakeBody[SnakeBody.Count - 1].X;
                        body.Y = SnakeBody[SnakeBody.Count - 1].Y;
                        SnakeBody.Add(body);
                        score++;

                        Random rand = new Random(); // !DODAAĆ ZIARNO
                        int zmienna; //!WYWALIC NA POCZATEK
                        int rodzaj;
                        zmienna = rand.Next(0,100);
                        rodzaj = rand.Next(0, 100);
                        if(zmienna > 85)
                        {
                            food.Generate_Food();
                            if (rodzaj > 50)
                            {
                                owoc = new Bitmap(@"Grafika\owocZielony.png");
                                kolor = 2;
                            }
                            else
                            {
                                owoc = new Bitmap(@"Grafika\owocNiebieski.png");
                                kolor = 1;
                            }
                        }
                        else
                        {
                            food.Generate_Food();
                            owoc = new Bitmap(@"Grafika\owocCzerwony.png");
                        }
                        for (int j = 0; j < SnakeBody.Count; j++)
                        {
                            if (food.X == SnakeBody[j].X && food.Y == SnakeBody[j].Y)
                            {
                                food.Generate_Food();
                                j = 0;
                            }

                        }
                    }
                    SnakeBody[i].Move(tempDirection);
                    for (int j = 1; j < SnakeBody.Count; j++) // zetknięcie się z samym sobą
                        if (SnakeBody[i].X == SnakeBody[j].X && SnakeBody[i].Y == SnakeBody[j].Y)
                            GameOver();

                    if (SnakeBody[i].X < 64) //zetknięcie się ze ścianą
                        GameOver();
                    if (SnakeBody[i].X >= 896)
                        GameOver();
                    if (SnakeBody[i].Y < 64)
                        GameOver();
                    if (SnakeBody[i].Y >= 576)
                        GameOver();
                }
                else // przemieszczenie się reszty częsci snake'a
                {
                    SnakeBody[i].X = SnakeBody[i - 1].X;
                    SnakeBody[i].Y = SnakeBody[i - 1].Y;
                }

            }
            pbGameScr.Invalidate(); // odświeżenie grafiki
        }

        private void buttonStart_Click(object sender, EventArgs e) //kliknięcie w przycisk start
        {
            StartGame();
        }

        private void snakeTimer_Tick(object sender, EventArgs e)
        {
            tempDirection = direction;
        }

        private void blueTimer_Tick(object sender, EventArgs e)
        {
            up = 1;
            down = 0;
            left = 2;
            right = 3;
            gameSpeed = tempSpeed;
            gameTimer.Interval = 3000 / gameSpeed;
            snakeTimer.Interval = gameTimer.Interval;
            blueTimer.Stop();
        }

        private void niebieski()
        {
            kolor = 0;
            tempSpeed = gameSpeed;
            gameSpeed = 8;
            blueTimer.Stop();
            blueTimer.Start();
            up = 0;
            down = 1;
            left = 3;
            right = 2;
        }

        private void zielony()
        {
            kolor = 0;
            tempSpeed = gameSpeed;
            gameSpeed = 50;
            greenTimer.Stop();
            greenTimer.Start();
        }

        private void greenTimer_Tick(object sender, EventArgs e)
        {
            gameSpeed = tempSpeed;
            gameTimer.Interval = 3000 / gameSpeed;
            snakeTimer.Interval = gameTimer.Interval;
            greenTimer.Stop();

        }
    }
}
