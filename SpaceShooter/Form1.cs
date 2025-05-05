using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                playerPictureBox.Left -= speed;
            }

            if (e.KeyCode == Keys.D)
            {
                playerPictureBox.Left += speed;
            }
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("Выстрел");
                PictureBox blaster = new PictureBox();
                blaster.Top = 50;
                blaster.Left = 150;
                blaster.Width = 50;
                blaster.Height = 50;
                blaster.SizeMode = PictureBoxSizeMode.StretchImage;
                blaster.Image = Properties.Resources.blaster;
                blaster.Name = "Blaster";

                this.Controls.Add(blaster); // появление на форме!!!
            }

            // вверх вниз сделать самостоятельно!
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
