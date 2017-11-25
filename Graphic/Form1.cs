using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            double scalaX;
            double scalaY;
            double offsetY;

            scalaY = pictureBox1.Height / 2.5;
            scalaX = pictureBox1.Width / Math.PI / 2;
            offsetY = pictureBox1.Height / 2;

            for (double x = 0; x < Math.PI * 2; x += 0.001)
            {
                double y = F(x);
                int puntoX = Convert.ToInt32(x * scalaX);
                int puntoY = Convert.ToInt32(y * scalaY + offsetY);
                g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(puntoX, puntoY, 1, 1));
            }
        }

        private double F(double x)
        {
            return Math.Sin(x) + Math.Sin(x * 30)/5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            double scalaX;
            double scalaY;

            scalaY = pictureBox1.Height / 2.5;
            scalaX = pictureBox1.Width / Math.PI / 2;
            double scalaZ = 127;
            int offsetZ = 128;

            for (double x = 0; x < Math.PI * 2; x += 0.01)
            {
                for (double y = 0; y < Math.PI * 2; y += 0.01)
                {
                    double z = F(x,y);
                    int puntoX = Convert.ToInt32(x * scalaX);
                    int puntoY = Convert.ToInt32(y * scalaY);
                    int coloreZ = Convert.ToInt32(z * scalaZ + offsetZ);

                    Brush brush = new SolidBrush(Color.FromArgb(coloreZ, coloreZ, coloreZ));
                    g.FillRectangle(brush, new Rectangle(puntoX, puntoY, 1, 1));
                }
            }
        }

        private double F(double x, double y)
        {
            return Math.Sin(x) * Math.Sin(y * 5);
        }

    }
}
