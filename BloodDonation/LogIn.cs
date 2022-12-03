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
    public partial class LogIn : Form
    {
        public static int id;
        public LogIn()
        {
            InitializeComponent();
        }
        Applicationlayer obj = new Applicationlayer();
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String email = textBox1.Text;
            String new_phone = textBox2.Text;
            obj.UpdatePhone(email, new_phone);
            Update up = new Update();
            up.Show();

        }
        //login donor
        private void button3_Click(object sender, EventArgs e)
        {
            id = obj.LogInDonor(textBox1.Text, textBox2.Text);
         
            if (id != 0)
            {
                Registeration reg = new Registeration();
                reg.Show();

            }
            else
            {
                MessageBox.Show("Invalid Login");
            }


        }
      



        private void button2_Click(object sender, EventArgs e)
        {

             Delete_Record_ID del = new Delete_Record_ID();
             del.Show();
          

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginPatient pat = new LoginPatient();
            pat.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
          
            DeletePatient del = new DeletePatient();
            del.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String email = textBox1.Text;
            String new_phone = textBox2.Text;
            obj.UpdatePhonePatient(email, new_phone);
            UpdatePatient up = new UpdatePatient();
            up.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
        }
    }
}
