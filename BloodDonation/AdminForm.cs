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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        Applicationlayer obj = new Applicationlayer();
        private void AdminForm_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = obj.GetDonorBloodType();
            listBox2.DataSource = obj.GetDonorEmail();
            listBox3.DataSource = obj.GetDonorRegion();
            listBox4.DataSource = obj.GetPatientBloodType();
            listBox5.DataSource = obj.GetPatientEmail();
            listBox6.DataSource = obj.GetPatientRegion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          List<string> D_bloodType = obj.GetDonorBloodType();
          List<string> p_bloodType = obj.GetPatientBloodType();

            // obj.Match(D_bloodType,p_bloodType);


            //testing
            MessageBox.Show("Matching");
           
        }
    }
}
