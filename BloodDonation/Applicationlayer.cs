using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BloodDonation
{
    class Applicationlayer
    {
        //Donorlogin

        public int LogInDonor(string Email, string Phone)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Donor ", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string email = (string)rdr["D_email"];
                string phone = (string)rdr["D_phone"];
                int id = rdr.GetInt32(rdr.GetOrdinal("D_ID"));
                if (Email == email && Phone == phone)
                    return id;
            }
            return 0;
                }

        //patient login
        public int LogInPatient(string Email, string Phone)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Patient ", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string email = (string)rdr["p_email"];
                string phone = (string)rdr["p_phone"];
                int id = rdr.GetInt32(rdr.GetOrdinal("p_id"));
                if (Email == email && Phone == phone)
                    return id;
            }
            return 0;
        }

        //insert in donor

        public void Regist(int D_id ,string D_name, string D_gender, string D_age, string D_email, string D_phone, string D_bloodtype, string D_region)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"insert into Donor (D_name,D_gender,D_age,D_email,D_phone,D_bloodtype,D_region) values(@name,@gender,@age,@email,@phone,@bloodtype,@region)" , con);
        

           SqlParameter parameter = new SqlParameter("@name", D_name);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@gender", D_gender);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@age", D_age);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@email", D_email);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@phone", D_phone);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@bloodtype", D_bloodtype);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@region", D_region);
            cmd.Parameters.Add(parameter);
          
            cmd.ExecuteNonQuery();

        }
        //insert in patient
        public void RegistPatient(int p_id, string p_name, string p_gender, string p_age, string p_email, string p_phone, string p_bloodtype, string p_region ,string H_name)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"insert into Patient (p_name,p_gender,p_age,p_email,p_phone,p_bloodtype,p_region,H_name) values(@name,@gender,@age,@email,@phone,@bloodtype,@region,@hospital)", con);
            

             SqlParameter parameter = new SqlParameter("@name", p_name);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@gender", p_gender);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@age", p_age);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@email", p_email);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@phone", p_phone);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@bloodtype", p_bloodtype);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@region", p_region);
            cmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@hospital", H_name);
            cmd.Parameters.Add(parameter);
            //error------------------------------------------------------------------------------
            cmd.ExecuteNonQuery();

        }















        //update phone in donor


        public void UpdatePhone( string D_email, string D_phone)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update Donor set D_phone=@phone where D_email=@email ", con);

            SqlParameter parameter = new SqlParameter("@phone", D_phone);
            cmd.Parameters.Add(parameter);

           

            parameter = new SqlParameter("@email", D_email);
            cmd.Parameters.Add(parameter);

           
            cmd.ExecuteNonQuery();

        }

        //update phone in patient
        public void UpdatePhonePatient(string p_email, string p_phone)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update Patient set p_phone=@phone where p_email=@email ", con);

            SqlParameter parameter = new SqlParameter("@phone", p_phone);
            cmd.Parameters.Add(parameter);



            parameter = new SqlParameter("@email", p_email);
            cmd.Parameters.Add(parameter);

           
            cmd.ExecuteNonQuery();

        }

        //donor delete
        public void delete(String D_ID)
        {

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Delete from Donor where D_ID=@id ", con);

            SqlParameter parameter = new SqlParameter("@id", D_ID);
            cmd.Parameters.Add(parameter);

        
            
            cmd.ExecuteNonQuery();

        }
        //patient delete
        public void deletePatient(String p_ID)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Delete from Patient where p_id=@id  ", con);

            SqlParameter parameter = new SqlParameter("@id", p_ID);
            cmd.Parameters.Add(parameter);




            cmd.ExecuteNonQuery();

        }











        public List<string> GetBloodBanksNames() {
            try {
                List<string> BloodBankNames = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from bloodbank ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BloodBankNames.Add((string)(rdr["B_name"]));
                   
                }
               


                return BloodBankNames;
            }
            catch
            {
                return null;
            }

        }

        public List<string> GetDonorBloodType()
        {
            try
            {
                List<string> DonorBloodType = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Donor ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DonorBloodType.Add((string)(rdr["D_bloodtype"]));

                }



                return DonorBloodType;
            }
            catch
            {
                return null;
            }
        }

        public List<string> GetDonorEmail()
        {
            try
            {
                List<string> DonorEmail = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Donor ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DonorEmail.Add((string)(rdr["D_email"]));

                }



                return DonorEmail;
            }
            catch
            {
                return null;
            }
        }

        public List<string> GetDonorRegion()
        {
            try
            {
                List<string> DonorRegion = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Donor ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DonorRegion.Add((string)(rdr["D_region"]));

                }



                return DonorRegion;
            }
            catch
            {
                return null;
            }
        }

        //patient
        public List<string> GetPatientBloodType()
        {
            try
            {
                List<string> PatientBloodType = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Patient ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PatientBloodType.Add((string)(rdr["p_bloodtype"]));

                }



                return PatientBloodType;
            }
            catch
            {
                return null;
            }
        }

        public List<string> GetPatientEmail()
        {
            try
            {
                List<string> PatientEmail = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Patient ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PatientEmail.Add((string)(rdr["p_email"]));

                }



                return PatientEmail;
            }
            catch
            {
                return null;
            }
        }

        public List<string> GetPatientRegion()
        {
            try
            {
                List<string> PatientRegion = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Patient ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PatientRegion.Add((string)(rdr["p_region"]));

                }



                return PatientRegion;
            }
            catch
            {
                return null;
            }
        }




        public List<string> GetHospitalNames()
        {
            try
            {
                List<string> HospitalNames = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Hospital ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    HospitalNames.Add((string)(rdr["H_name"]));

                }



                return HospitalNames;
            }
            catch
            {
                return null;
            }
        }

        public List<string> GePatientNames()
        {
            try
            {
                List<string> PatientNames = new List<string>();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Patient ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PatientNames.Add((string)(rdr["p_name"]));

                }



                return PatientNames;
            }
            catch
            {
                return null;
            }
        }
        public void Store(String D_email , string B_name)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select B_id from bloodbank where B_name = @Blood_name  ", con);
            SqlParameter parameter = new SqlParameter("@Blood_name", B_name);
            cmd.Parameters.Add(parameter);
            SqlDataReader rdr = cmd.ExecuteReader();
            int Bb_id = 0;
            while (rdr.Read())
            {
                
                 Bb_id = rdr.GetInt32(rdr.GetOrdinal("B_id"));
                
                  
            }


            rdr.Close();


            // SqlParameter parameter = new SqlParameter("@B_name", Blood_name);
            // cmd.Parameters.Add(parameter);

            SqlCommand cmdSelect = new SqlCommand("select D_ID from Donor where D_email=@email ", con);
           // cmd = new SqlCommand("select D_ID from Donor where D_email=@email ", con);
            parameter = new SqlParameter("@email", D_email);
            cmdSelect.Parameters.Add(parameter);
            SqlDataReader rdrSelect = cmdSelect.ExecuteReader();
          //  rdr = cmdSelect.ExecuteReader();
            int Do_id=0;
            while (rdrSelect.Read())
            {

                 Do_id= rdrSelect.GetInt32(rdrSelect.GetOrdinal("D_ID"));


            }
            rdrSelect.Close();


            //  parameter = new SqlParameter("@D_email", email);
            //  cmd.Parameters.Add(parameter);
            SqlCommand cmdInsert   = new SqlCommand(@"insert into store (D_id,B_id,medicalreport,quantity)values(@Do_id,@Bb_id,NULL,NULL)", con);
             parameter = new SqlParameter("@Do_id", Do_id);
            cmdInsert.Parameters.Add(parameter);
            parameter = new SqlParameter("@Bb_id", Bb_id);
            cmdInsert.Parameters.Add(parameter);

            cmdInsert.ExecuteNonQuery();


        }








        public void Match ( String D_bloodType, String p_bloodType)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Blood_Donation;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Patient " , con);
            cmd = new SqlCommand(@"select * from Donor ", con);
            SqlParameter parameter = new SqlParameter("@D_blood", D_bloodType);
            parameter = new SqlParameter("@P_blood", p_bloodType);
            cmd.Parameters.Add(parameter);

            if(D_bloodType == "A" && p_bloodType =="A")
             
            {
                List<string> PatientNames = GePatientNames();
            }

            



            cmd.ExecuteNonQuery();

        }
    }
}
