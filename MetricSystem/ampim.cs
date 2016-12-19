using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetricSystem
{
    public partial class ampim : MetroForm
    {
        public ampim()
        {
            InitializeComponent();
        }

        private void ampim_Load(object sender, EventArgs e)
        {
            brows();
        }
        private void brows()
        {
            TabPage tab = new TabPage();
            tab.Text = "new Tab";
            metroTabControl1.Controls.Add(tab);
            metroTabControl1.SelectTab(metroTabControl1.TabCount - 1);
            WebBrowser bowser = new WebBrowser() { ScriptErrorsSuppressed = true };
            bowser.Parent = tab;
            bowser.Dock = DockStyle.Fill;
            bowser.Navigate("http://www.ilinpage.me");
            bowser.DocumentCompleted += Browser_DocumentCompleted;
        }
        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = metroTabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
                metroTabControl1.SelectedTab.Text = browser.DocumentTitle;

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            mail mru = new mail();
            mru.Show();
        }
    }
}
