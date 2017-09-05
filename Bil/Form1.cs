using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bil
{
    public partial class Form1 : Form
    {
        public static Image newimage;
        static OpenFileDialog dialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }
        string editstring(string s)
        {
            int i;
            string temp=s;
            if(s.Length>=50&&s.Length<100)
            {
                temp = s.Insert(50, "-\n");
            }
            else if (s.Length >=100)
            {
                temp = s.Insert(50, "-\n");
                s = temp;
                temp= s.Insert(101, "-\n");
            }
            return temp;
        }
        private void GenerateImage_Click(object sender, EventArgs e)
        {
            Font font = new Font(FontFamily.GenericSansSerif,
            12.0F, FontStyle.Bold);
          
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            string s3 = textBox3.Text;
            string s4 = textBox4.Text;
            string s5 = textBox5.Text;
            string s6 = textBox6.Text;
            int i;
            s1 = editstring(s1);
            s2 = editstring(s2);
            s3 = editstring(s3);
            s4 = editstring(s4);
            s5 = editstring(s5);
            s6 = editstring(s6);
            string ss = s1 + "\n\n" + s2 + "\n\n" + s3 + "\n\n" + s4 + "\n\n" + s5 + "\n\n" + s6 + "\n\n\n\n";
            Image img = DrawText(ss, font, Color.Black, Color.White);
           
            DateTime time = DateTime.Now;             // Use current time.
            string format = "dHHmmssyyyy";   // Use this format.
            string s = time.ToString(format); // Write to console.
                                              //   string ss = toolStripTextBox1.Text.ToString();
            img.Save(Application.StartupPath + "\\" + s + ".jpg");
            newimage = img;
            Form2 ob = new Form2();
            ob.Show();
        }
            
        private Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1,1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)700, (int)700);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 30, 80);
            Image i = pictureBox1.Image;// This is 300x300
        /*    Bitmap b = new Bitmap(400, 400);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawImage(i, 0, 0, 400, 400);
            }  */
            drawing.DrawImage(i, 510, 50, 150, 350);
            drawing.Save();
            
            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(maxWidth, maxHeight);//new

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, maxWidth, maxHeight);//new

            return newImage;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            dialog.Filter = "All files (*.*)|*.*|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dialog.InitialDirectory = @"C:\Pictures\";
            dialog.Title = "Please select an image file to encrypt.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //    Test();
                Image img= Image.FromFile(dialog.FileName);
                img = ScaleImage(img, 168, 289);
                pictureBox1.Image=img;
                //Encrypt the selected file. I'll do this later. :)
            }
        }
    }
}
