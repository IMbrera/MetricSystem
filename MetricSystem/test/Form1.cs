using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace regexvir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
        }
        
      

        private void button2_Click(object sender, EventArgs e)
        {
			int v=0;
            string ChepinCode = ChepinAnalyze.DelComnt(richTextBox1.Text);
            ChepinCode = ChepinAnalyze.DelStr(ChepinCode);
            List<string> variables = ChepinAnalyze.GetVariables(ChepinCode);
            List<ChepinAnalyze.VariableInfo> variablesInfo = ChepinAnalyze.GetVariablesInfo(variables, ChepinCode);
            int dataCount = 0, StewartCount = 0, ModifiedCount = 0, ParasiticCount = 0;
            for (int i = 0; i < variablesInfo.Count; i++)
            {
                if (variablesInfo[i].Input)
                    dataCount++;
                if (variablesInfo[i].Steward)
                    StewartCount++;
                if (variablesInfo[i].Modern)
                    ModifiedCount++;
                if (variablesInfo[i].virus)
                    ParasiticCount++;
                ListViewItem Item = new ListViewItem(variablesInfo[i].Indentifier);
                Item.SubItems.Add(variablesInfo[i].Input.ToString());
                Item.SubItems.Add(variablesInfo[i].Steward.ToString());
                Item.SubItems.Add(variablesInfo[i].Modern.ToString());
                Item.SubItems.Add(variablesInfo[i].virus.ToString());
                listResult.Items.Add(Item);
            }
            const double InputCoefficient = 1;
            const double StewardCoefficient = 3;
            const double ModernCoefficient = 2;
            const double virusCoefficient = 0.5;
            txtResult.Text = "Значение метрики = P + 2M + 3C + 0.5T = " + dataCount * InputCoefficient + StewartCount * StewardCoefficient + ModifiedCount * ModernCoefficient + ParasiticCount * virusCoefficient; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            { richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText); }
        }
    }
    
    }

        