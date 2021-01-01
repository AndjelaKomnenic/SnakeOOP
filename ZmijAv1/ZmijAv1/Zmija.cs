using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ZmijAv1
{
    class Zmija
    {
        private Rectangle[] telo;
        private int x, y;
        private SolidBrush sb;

        public Rectangle[] Telo
        {
            get { return telo; }
        }
        public int A { get; set; }
        public Zmija() 
        {
            x = 0;
            y = 0;
            A = 20;
            telo = new Rectangle[1];
            telo[0] = new Rectangle(x, y, A, A);
            sb = new SolidBrush(Color.GreenYellow);
        }

        public void nacrtajSe() 
        {
            for (int i = telo.Length - 1; i > 0; i--)
            {
                telo[i] = telo[i - 1];
            }
        }

        public void nacrtajSe(Graphics g) 
        {
            g.FillRectangles(sb, telo);
        }

        public void pomeriSe(string smer) 
        {
            nacrtajSe();
            switch (smer)
            {
                case "desno":
                    telo[0].X += 20;
                    break;
                case "dole":
                    telo[0].Y += 20;
                    break;
                case "levo":
                    telo[0].X -= 20;
                    break;
                case "gore":
                    telo[0].Y -= 20;
                    break;
            }
        }

        public void porast() 
        {
            List<Rectangle> temp = telo.ToList();
            temp.Add(new Rectangle(telo[telo.Length - 1].X, telo[telo.Length - 1].Y, A, A));
            telo = temp.ToArray();
        }
    }
}
