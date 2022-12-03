using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BloodDonation
{
    public partial class Registeration : Form
    {
        public Registeration()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        Applicationlayer obj = new Applicationlayer();

        private void button1_Click(object sender, EventArgs e)
        {
            int D_ID = LogIn.id;
            String name = txtname.Text;
            String gender = txtgender.Text;
            String age = txtage.Text;
            String email = txtemail.Text;
            String phone = txtphone.Text;
            String Bloodtype = txtbloodtype.Text;
            String region = txtregion.Text;
            string bank_name = (comboBox1.SelectedItem).ToString();
            obj.Regist(D_ID , name,gender,age,email,phone,Bloodtype,region);
         obj.Store(email,bank_name);

           


        }

        private void Registeration_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = obj.GetBloodBanksNames();
            listBox2.DataSource = obj.GetHospitalNames();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from bloodbank", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
               
                string name = (string)rdr["B_name"];
                comboBox1.Items.Add(name);

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
