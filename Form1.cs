using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
namespace Image_Segmentation
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> imageInuput;
        Image<Gray, byte> imageoutput;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                imageInuput = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = imageInuput.Bitmap;
                 

            }
        }

        public void ApplyGay(int min , int max )
        {
            try
            {
                imageoutput = imageInuput.Convert<Gray, byte>().InRange(new Gray(min), new Gray(max));
                pictureBox2.Image = imageoutput.Bitmap;
                pictureBox2.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyGay(trackBar1.Value, trackBar2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(imageInuput == null )
                {
                    return;
                }

                Image<Bgr, byte> temp = imageInuput.Clone();
                temp.SetValue(new Bgr(0, 0, 255), imageoutput);
                pictureBox2.Image = temp.Bitmap;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
