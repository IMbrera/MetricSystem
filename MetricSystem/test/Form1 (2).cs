using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace changeddelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000;
           
            progressBar1.Update();
            string[] inppb = { "0", "1", "2" };
            Random rnd = new Random();
            int inputIndex = rnd.Next(0, inppb.Length);

            for (int x = 1; x <=progressBar1.Maximum ; x++)
            {
                progressBar1.Value = x;
            }
        
           if (inputIndex == 0)

               pictureBox1.Visible = true;

           else
               if (inputIndex == 1)
                   pictureBox2.Visible = true;
               else
                   if (inputIndex == 2)
                       pictureBox3.Visible = true;
            //   rnd = pictureBox1.Visible = true;
            //pictureBox1.Visible=true =
         
           label1.Text = inputIndex.ToString();
         
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("changeddelegate.exe");
        }
    }
}
