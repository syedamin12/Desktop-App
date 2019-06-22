using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace whatapp_msg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from = "923059108705";
            string To = txtTo.Text;
            string msg = txtmsg.Text;


            WhatsApp wa = new WhatsApp(from, "604c6a32ffe14e04e999d064342551061a01c778", "Amin", false, false);
            wa.OnConnectSuccess += () =>
            {
                MessageBox.Show("Connected to Whatsapp");
                wa.OnLoginSuccess += (phoneNumber, data) =>
                {
                    wa.SendMessage(To, msg);
                    MessageBox.Show("Message send.....");
                };
                wa.OnLoginFailed += (data) =>
                {
                    MessageBox.Show("Login Failed :(0)", data);
                };
                wa.Login();
            };
            wa.OnConnectFailed += (ex) =>
            {
                MessageBox.Show("Connection Failed......");
            };
            wa.Connect();
        }
    }
}
