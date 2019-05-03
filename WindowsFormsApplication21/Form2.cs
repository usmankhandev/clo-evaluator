using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication21
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            string Id = Convert.ToString(selectedRow.Cells["Id"].Value);
            
            string FirstName = Convert.ToString(selectedRow.Cells["FirstName"].Value);
            string LastName = Convert.ToString(selectedRow.Cells["LastName"].Value);
            string Contact = Convert.ToString(selectedRow.Cells["Contact"].Value);
            string Email = Convert.ToString(selectedRow.Cells["Email"].Value);
            string RegistrationNumber = Convert.ToString(selectedRow.Cells["RegistrationNumber"].Value);
            Form1 h = new Form1(FirstName,LastName,Contact,Email, RegistrationNumber,Id);
            this.Hide();
            h.Show();
            
        }

        public void loadgrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Student]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            string a = Convert.ToString(selectedRow.Cells["Id"].Value);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True;";
            con.Open();
            string q = "Delete from Student where Id = '" + a + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            loadgrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 h = new Form1();
            this.Hide();
            h.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DGVClo h = new DGVClo();
            this.Hide();
            h.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RubricsGV h = new RubricsGV();
            this.Hide();
            h.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            RubricLevelGV h = new RubricLevelGV();
            this.Hide();
            h.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Assessment_GV h = new Assessment_GV();
            this.Hide();
            h.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            S_Attendance_GV h = new S_Attendance_GV();
            this.Hide();
            h.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
