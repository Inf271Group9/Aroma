using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Employee_Login_code
{
    public partial class Form1 : Form
        
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = RAHUL\\SYSARCH; Initial Catalog = TestLogin; Integrated Security = True");
            con.Open();
            
            SqlCommand cmd = new SqlCommand("Select * FROM Employee where Role = 'Admin' and Username='" + txtUse.Text + "'and Password ='" + txtPass.Text   +  "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            if (count == 1)
            {
                this.Hide();
                MessageBox.Show("Yay");
                FormYay t = new FormYay();
                t.Show();
            }
           else if ( count < 1)
            {
                MessageBox.Show("User does not exist, please enter password again");
            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate user existence");
            }
             
            //SqlDataAdapter sda = new SqlDataAdapter();
           // DataTable dt = new System.Data.DataTable();
           // sda.Fill(dt);
            
            //if (dt.Rows.Count == 1)
            //{
            //    FormYay t = new FormYay();
             //  t.Show();
          //  }
        }
    }
}
