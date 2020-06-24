using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName); // открываем изображение
            }
        }

       private void изменитьФотоToolStripMenuItem_Click(object sender, EventArgs e)
       {
            if (pictureBox1.Image != null)
            {
                Bitmap input = new Bitmap(pictureBox1.Image); //вставим изображение в bitmap

                Bitmap output = new Bitmap(input.Width, input.Height);

                //перебираем пиксели
                for (int j = 0; j< input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(input.GetPixel(i,j).ToArgb()); //получаем пиксел
                        float R = (float)((pixel & 0x00ff0000) >> 16); //значение компонента R
                        float G = (float)((pixel & 0x0000ff00) >> 8); //значение компонента G
                        float B = (float)((pixel & 0x000000ff)); //значение компонента B

                        R = G = B = (R + G + B) / 3.0f;

                        UInt32 newpixel = 0xff000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);

                        output.SetPixel(i, j, Color.FromArgb((int)newpixel));
                    }
                pictureBox1.Image = output;

            }   

       }
    }
}
