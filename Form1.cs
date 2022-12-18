using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertRGBImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Browse Image";
            openFile.Filter = "JPEG Files|*.jpg|PNG Files|*.png";

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
                Image image = Image.FromFile(openFile.FileName);
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string img = textBox1.Text;
            Bitmap bmp = new Bitmap(img);

            Bitmap redbmp = new Bitmap(bmp);
            Bitmap greenbmp = new Bitmap(bmp);
            Bitmap bluebmp = new Bitmap(bmp);

            int width = bmp.Width;
            int height = bmp.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p = bmp.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    redbmp.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));
                    greenbmp.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));
                    bluebmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));
                }
            }

            pictureBox2.Image = redbmp;
            pictureBox3.Image = greenbmp;
            pictureBox4.Image = bluebmp;
        }
    }
}
