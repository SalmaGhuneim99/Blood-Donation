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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        Applicationlayer obj = new Applicationlayer();
      

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.DataSource = obj.GetBloodBanksNames();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = obj.GetHospitalNames();
        }
    }
}
