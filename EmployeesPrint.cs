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

namespace humanres
{
    public partial class EmployeesPrint : Form
    {
        
        public EmployeesPrint()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        DataTable dt = new DataTable();
        private void EmployeesPrint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'humanResDataSet1.JOBS' table. You can move, or remove it, as needed.
           // this.jOBSTableAdapter.Fill(this.humanResDataSet1.JOBS);
            // TODO: This line of code loads data into the 'humanResDataSet.EMPLOYEES' table. You can move, or remove it, as needed.
            SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
            SqlDataAdapter employeePrintQuerry = new SqlDataAdapter(@"SELECT EMPLOYEES.FIRST_NAME as [Собствено име], EMPLOYEES.LAST_NAME as [Фамилно име], JOBS.START_VACATION as [Начало отпуска], JOBS.END_VACATION as [Край отпуска] from EMPLOYEES, JOBS WHERE EMPLOYEES.JOB_ID = JOBS.JOB_ID", con);
            
            employeePrintQuerry.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("convert([Начало отпуска], 'System.String') like '%{0}%' OR convert([Край отпуска], 'System.String') LIKE '%{0}%'", searchTextBox.Text);
            dataGridView1.DataSource = dv.ToTable();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
