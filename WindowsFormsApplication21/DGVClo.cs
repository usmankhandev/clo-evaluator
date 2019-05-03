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
    public partial class DGVClo : Form
    {
        public DGVClo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.SelectedRows[0].Index;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            string Id = Convert.ToString(selectedRow.Cells["Id"].Value);

            string Name = Convert.ToString(selectedRow.Cells["Name"].Value);
            Form3Clo h = new Form3Clo(Name,Id);
            this.Hide();
            h.Show();
        }
        public void loadgrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Clo]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void DGVClo_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            string a = Convert.ToString(selectedRow.Cells["Id"].Value);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True;";
            con.Open();
            string qr = "Delete from Rubric where CloId = '" + a + "'";
            SqlCommand cmd = new SqlCommand(qr, con);
            cmd.ExecuteNonQuery();
            loadgrid();

            string q = "Delete from Clo where Id = '" + a + "'";
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            loadgrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 h = new Form2();
            this.Hide();
            h.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RubricsGV h = new RubricsGV();
            this.Hide();
            h.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3Clo h = new Form3Clo();
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
    }
}
