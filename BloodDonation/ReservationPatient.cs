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
    public partial class ReservationPatient : Form
    {
        public ReservationPatient()
        {
            InitializeComponent();
        }

        Applicationlayer obj = new Applicationlayer();
        private void button1_Click(object sender, EventArgs e)
        {
            // not sure about ID
            int p_id = LoginPatient.id;
            String name = txtname.Text;
            String gender = txtGender.Text;
            String age = txtAge.Text;
            String email = txtEmail.Text;
            String phone = txtPhone.Text;
            String Bloodtype = txtBloodType.Text;
            String region = txtRegion.Text;
            String Hospital = txtHospital.Text;
            obj.RegistPatient(p_id, name, gender, age, email, phone, Bloodtype, region,Hospital);
        }

        private void ReservationPatient_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = obj.GetBloodBanksNames();
            listBox2.DataSource = obj.GetHospitalNames();
        }
    }
}
