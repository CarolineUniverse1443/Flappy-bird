using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_bird_game
{
    public partial class Form1 : Form
    {

        public int k = 0;
        public int score = 0;
        public int gravity = 5;
        public int jump = 30;
        public int speed = 10;
        public Form1()
        {
            InitializeComponent();
            Init();
            p1.Location = new Point(328, 0);
            p2.Location = new Point(328, ClientSize.Height - 180);
            label4.Text = "Speed: 10";
            label1.Location = new Point(ClientSize.Width / 2 - label1.Width/2, ClientSize.Height / 2 - label1.Height / 2);
            button1.Location = new Point(ClientSize.Width / 2 - button1.Width, ClientSize.Height / 2 + button1.Height);
            button2.Location = new Point(ClientSize.Width / 2 + button2.Width / 2, ClientSize.Height / 2 + button1.Height);
            this.DoubleBuffered = true;
        }

        //

        public void Init()
        {
            timer1.Interval = 40;
            timer1.Start();
            timer2.Interval = 40;
            timer2.Start();
            timer3.Interval = 6000;
            timer3.Start();
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            movePipes();
            gameOver();
        }

        void gameOver()
        {
             if((flappy.Bounds.IntersectsWith(p1.Bounds)) || (flappy.Bounds.IntersectsWith(p2.Bounds)))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                label1.Visible = true;
                button1.Visible = true;
                button1.Enabled = true;
                button2.Visible = true;
                button2.Enabled = true;
            }

        }

        Random rand = new Random();

        void movePipes()
        {
            if ((p1.Left >= 0) && (p2.Left >= 0))
            {
                p1.Left += -speed;
                p2.Left += -speed;
            }
            else
            {
                p1.Left = 640;
                p2.Left = 640;
                int way = rand.Next(0, 4);
                int x = p2.Location.X;
                int y = p1.Location.Y;
                switch (way)
                {
                    case 0:
                        p1.Height = -1;
                        p2.Height = 250;
                        p2.Location = new Point(x, -50);
                        p2.Location = new Point(x, ClientSize.Height - 312);
                        p2.Visible = true;
                        break;
                    case 1:
                        p1.Height = 250;
                        p2.Height = -1;
                        p2.Visible = false;
                        break;
                    case 2:
                        p1.Height = 120;
                        p2.Height = 150;
                        p1.Location = new Point(x, -40);
                        p2.Location = new Point(x, ClientSize.Height - 215);
                        p2.Visible = true;
                        break;
                    case 3:
                        p1.Height = 150;
                        p2.Height = 110;
                        p1.Location = new Point(x, 0);
                        p2.Location = new Point(x, ClientSize.Height - 160);
                        p2.Visible = true;
                        break;

                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(flappy.Top <= ClientSize.Height-120)
            {
                flappy.Top += gravity;
            }

            if ((score==0)&&(flappy.Left > p1.Left + 50))
            {
                score++;
            }

            if (flappy.Left > p1.Left+55)
            {
                score++;
            }
            
            label3.Text = score.ToString();
            gameOver();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode == Keys.Space) && (flappy.Top >= flappy.Height/2) )
            {
                if (!(flappy.Bounds.IntersectsWith(p1.Bounds)) && !(flappy.Bounds.IntersectsWith(p2.Bounds)))
                {
                    flappy.Top += -jump;
                }
                    
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            speed++;
            gravity++;
            label4.Text = "Speed: ";
            label4.Text += speed.ToString();
            if (timer3.Interval >= 999)
            {
                timer3.Interval -= 50;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.ControlLight;
            button1.ForeColor = Color.Black;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            /*score = 0;
            gravity = 5;
            speed = 10;
            label4.Text = "Speed: 10";
            label3.Text = "0";
            label1.Visible = false;
            button1.Visible = false;
            button1.Enabled = false;
            flappy.Location = new Point(51, 145);
            p1.Location = new Point(328, -2);
            p2.Location = new Point(328, 237);
            p1.Height = 116;
            p2.Height = 116;
            timer1.Start();
            timer2.Start();
            timer3.Start();*/
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            button2.BackColor = SystemColors.ControlLight;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseMove_1(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Red;
            button2.ForeColor = Color.White;
        }
    }
}
