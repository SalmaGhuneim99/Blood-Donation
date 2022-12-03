using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BloodDonation
{
    public partial class LoginPatient : Form
    {
        public static int id;
        public LoginPatient()
        {
            InitializeComponent();
        }

        Applicationlayer obj = new Applicationlayer();
        private void button1_Click(object sender, EventArgs e)
        {
           
               id = obj.LogInPatient(textBox1.Text, textBox2.Text);
            if (id != 0)
            {
                ReservationPatient reg = new ReservationPatient();
                reg.Show();

            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }
    }
}
