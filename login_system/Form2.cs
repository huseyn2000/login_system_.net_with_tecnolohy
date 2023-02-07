using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(Class1.GetConnectionString());
            con.Open();


            SqlCommand cmd = new SqlCommand("INSERT INTO USERS " +
                "VALUES(@usarname,@password,@email)", con);


            cmd.Parameters.AddWithValue("@usarname", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);

          



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success");




            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

            finally
            {

                con.Close();
                con.Dispose(); //garbage collector

                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();



            }
            //update, insert, delete - ExecuteNonQuery()

            //ExecuteScalar() - select
            //ExecuteReader() - select




        }

        public DataTable GeTuser()
        {

            SqlConnection con = new SqlConnection();
            con = new SqlConnection(Class1.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from USERS", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            con.Close();
            return dt;


        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = GeTuser();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "DEPARTMENT_NAME";
            comboBox1.ValueMember = "ID";
        }
    }
}
