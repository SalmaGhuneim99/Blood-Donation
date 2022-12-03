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
    public partial class UpdatePatient : Form
    {
        public UpdatePatient()
        {
            InitializeComponent();
        }

        Applicationlayer obj = new Applicationlayer();
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string newPhone = textBox2.Text;
            obj.UpdatePhonePatient(email, newPhone); 
            MessageBox.Show("Your phone is updated");
        }
    }
}
