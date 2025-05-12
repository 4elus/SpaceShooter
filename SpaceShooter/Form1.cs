using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        int speed = 10;
        Random random = new Random();
        
       // List<PictureBox> blasters = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.A)
            //{
            //    playerPictureBox.Left -= speed;
            //}

            //if (e.KeyCode == Keys.D)
            //{
            //    playerPictureBox.Left += speed;
            //}
            if (e.KeyCode == Keys.Space)
            {

              
                Shoot();
            }

            // вверх вниз сделать самостоятельно!
        }

        public void Shoot()
        {
            PictureBox blaster = new PictureBox();
            blaster.Top = playerPictureBox.Top - 45;
            blaster.Left = playerPictureBox.Left + 15;

            blaster.Width = 50;
            blaster.Height = 50;
            blaster.SizeMode = PictureBoxSizeMode.StretchImage;
            blaster.Image = Properties.Resources.laser_cartoon;
            blaster.Name = "Blaster";
            this.Controls.Add(blaster);

            Timer timer = new Timer();
            timer.Interval = 10;

            timer.Tick += (s, e) =>
            {
                blaster.Top -= 5;

                if (blaster.Top + blaster.Height < 0)
                {
                    timer.Stop();
                    this.Controls.Remove(blaster);
                    
                }
            };
            timer.Start();
        }

        public void Asteroid()
        {
           
            PictureBox asteroid = new PictureBox();
           
            asteroid.Top = 0;
            asteroid.Left = random.Next(0, 1130);

            asteroid.Width = 64;
            asteroid.Height = 64;
            asteroid.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroid.Image = Properties.Resources.asteroid;
            asteroid.Name = "asteroid";
            this.Controls.Add(asteroid);

            Timer timer = new Timer();
            timer.Interval = 25;

            timer.Tick += (s, e) =>
            {
                asteroid.Top += 5;

                if (asteroid.Top + asteroid.Height > 644)
                {
                    timer.Stop();
                    this.Controls.Remove(asteroid);

                }
            };
            timer.Start();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')
            {
                playerPictureBox.Left -= speed;
            }

            if (e.KeyChar == 'd')
            {
                playerPictureBox.Left += speed;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;

            timer.Tick += (s, a) =>
            {
                Asteroid();

               
            };
            timer.Start();

            
        }
    }
}
