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
    public partial class DeletePatient : Form
    {
        public DeletePatient()
        {
            InitializeComponent();
        }
        Applicationlayer obj = new Applicationlayer();
        private void button1_Click(object sender, EventArgs e)
        {
            String id = textBox1.Text;
            obj.deletePatient(id);
            MessageBox.Show("Deleted");
        }
    }
}
