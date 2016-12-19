using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace MetricSystem
{
    public partial class mail :MetroFramework.Forms.MetroForm
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        public mail()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           
           
          
        }
       
       

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            login = new NetworkCredential(mailBox.Text, Passbox.Text);

            client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
          //  client.Timeout = 10000;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress(mailBox.Text + Passbox.Text.Replace("smtp.", "@"), "Lucy", Encoding.UTF8) };
            //      client.Credentials = new NetworkCredential(Convert.ToString(mailBox.Text),Convert.ToString(Passbox.Text));
            msg.To.Add(metroTextBox1.Text);
            msg.From = new MailAddress(mailBox.Text);
            msg.Subject = metroTextBox2.Text;
            msg.Body = metroTextBox3.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(sendcom);
            string userstate = "Sending...";
            client.SendAsync(msg, userstate);
        }
             private static void sendcom(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canseled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ваше сообщение было успешно отправлено", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
    }

