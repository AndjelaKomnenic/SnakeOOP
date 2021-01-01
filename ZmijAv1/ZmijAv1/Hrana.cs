using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ZmijAv1
{
    class Hrana
    {
        private Rectangle delic;
        private SolidBrush sb;
        private int x, y, a;
        private Random rand;

        public Rectangle Delic 
        {
            get { return delic; } 
        }

        public Hrana() 
        {
            rand = new Random();
            Generisi(rand);
            a = 20;
            delic = new Rectangle(x, y, a, a);
            sb = new SolidBrush(Color.OrangeRed);
        }

        public void nacrtajSe(Graphics g) 
        {
            delic.X = x;
            delic.Y = y;
            g.FillRectangle(sb, delic);
        }

        public void Generisi(Random rand) 
        {
            x = rand.Next(0, 25) * 20;
            y = rand.Next(0, 25) * 20;
        }
    }
}
