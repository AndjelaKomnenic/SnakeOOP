using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZmijAv1
{
    public partial class Form1 : Form
    {
        private string smer = "desno";
        private int rezultat = 0;
        private Random rand = new Random();
        private Zmija zmijica;
        private Hrana hranica;

        public Form1()
        {
            InitializeComponent();
            zmijica = new Zmija();
            hranica = new Hrana();
            timer2.Tick += Update;
            label1.Visible = false;
            pictureBox1.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData) 
            {
                case Keys.Enter:
                    timer2.Start();
                    label1.Visible = false;
                    pictureBox1.Visible = false;
                    break;
                case Keys.Right:
                    if (smer != "levo")
                        smer = "desno";
                    else
                        Restart();
                    break;
                case Keys.Down:
                    if (smer != "gore")
                        smer = "dole";
                    else
                        Restart();
                    break;
                case Keys.Left:
                    if (smer != "desno")
                        smer = "levo";
                    else
                        Restart();
                    break;
                case Keys.Up:
                    if (smer != "dole")
                        smer = "gore";
                    else
                        Restart();
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            zmijica.nacrtajSe(e.Graphics);
            hranica.nacrtajSe(e.Graphics);
        }

        private void Update(object sender, EventArgs e) 
        {
            zmijica.pomeriSe(smer);
            this.Text = string.Format("Rezultat: {0}", rezultat);
            for (int i = 1; i < zmijica.Telo.Length; i++)
            {
                if (zmijica.Telo[0].IntersectsWith(zmijica.Telo[i]))
                    Restart();
            }
            if (zmijica.Telo[0].X < 0 || zmijica.Telo[0].X > ClientRectangle.Width - zmijica.A)
            {
                Restart();
            }
            if (zmijica.Telo[0].Y < 0 || zmijica.Telo[0].Y > ClientRectangle.Height - zmijica.A)
            {
                Restart();
            }
            if (zmijica.Telo[0].IntersectsWith(hranica.Delic))
            {
                rezultat++;
                zmijica.porast();
                hranica.Generisi(rand);
            }
            Refresh();
        }

        private void Restart() 
        {
            timer2.Stop();
            Refresh();
            pictureBox1.Visible = true;
            label1.Visible = true;
            label1.BringToFront();
            zmijica = new Zmija();
            hranica = new Hrana();
            smer = "desno";
            rezultat = 0;

        }
    }
}
