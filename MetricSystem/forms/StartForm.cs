using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetricSystem
{
    public partial class StartForm : Form
    {
        public StartForm()
        {

            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            circular.Value = 0;
            circular.Minimum = 0;
            circular.Maximum = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
                circular.Increment(9);
                circular.Text = circular.Value.ToString();
           
                if (circular.Value >= 100)
                {
                    this.timer1.Stop();
                    this.Hide();
                    mForm main = new mForm();
                    main.Show();
                }
            }
        }
    }

