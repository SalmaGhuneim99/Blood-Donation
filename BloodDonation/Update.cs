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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        Applicationlayer obj = new Applicationlayer();

        private void button1_Click(object sender, EventArgs e)
        {

            string email = textBox1.Text;
            string newPhone = textBox2.Text;
            obj.UpdatePhone(email,newPhone);
            MessageBox.Show("Your phone is update");
           
        }
    }
}
