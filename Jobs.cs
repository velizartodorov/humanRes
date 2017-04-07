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
    public partial class Jobs : Form
    {
        SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
        public Jobs()
        {
            InitializeComponent();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxJobsID.Text) || string.IsNullOrWhiteSpace(textBoxJobTitle.Text)
                || string.IsNullOrWhiteSpace(textBoxMin_salary.Text) || string.IsNullOrWhiteSpace(textBoxMax_salary.Text)
                || string.IsNullOrWhiteSpace(textBoxStart_vacation.Text) || string.IsNullOrWhiteSpace(textBoxEnd_vacation.Text)) 
            {
                MessageBox.Show("Оставили сте непопълнено поле!");
            }

            else
            { 
            SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
            
            {
                SqlCommand jobsQuerry = new SqlCommand("INSERT into JOBS(JOB_ID, JOB_TITLE, MIN_SALARY, MAX_SALARY, REGION_ID, START_VACATION, END_VACATION) Values(@JOB_ID, @JOB_TITLE, @MIN_SALARY, @MAX_SALARY, @REGION_ID, @START_VACATION, @END_VACATION)", con);
                jobsQuerry.Parameters.AddWithValue("@JOB_ID", textBoxJobsID.Text);
                jobsQuerry.Parameters.AddWithValue("@JOB_TITLE", textBoxJobTitle.Text);
                jobsQuerry.Parameters.AddWithValue("@MIN_SALARY", textBoxMin_salary.Text);
                jobsQuerry.Parameters.AddWithValue("@MAX_SALARY", textBoxMax_salary.Text);
                jobsQuerry.Parameters.AddWithValue("@REGION_ID", comboBox1.Text);
                jobsQuerry.Parameters.AddWithValue("@START_VACATION", textBoxStart_vacation.Text);
                jobsQuerry.Parameters.AddWithValue("@END_VACATION", textBoxEnd_vacation.Text);

                con.Open();
                jobsQuerry.ExecuteNonQuery();
                con.Close();
            }
            

            MessageBox.Show("Нов запис добавен!");
            } //else
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            this.Validate();
            this.jOBSBindingSource.EndEdit();
            this.sqlDataAdapter1.Update(this.jobsDataSet1);

            MessageBox.Show("Съществуващ запис е променен!");
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void sqlConnection1_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void sqlDataAdapter1_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            jobsDataSet1.Clear();
            sqlDataAdapter1.Fill(jobsDataSet1.JOBS);
            regionsDataSet.Clear();
            sqlDataAdapter2.Fill(regionsDataSet.REGIONS);
        }

        private void textBoxJobsID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8)) 
       
            {
                MessageBox.Show("Моля, въведете числа за ID!");
                e.KeyChar = (char)0;
            }
        }

        private void textBoxMin_salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за минимална заплата!");
                e.KeyChar = (char)0;
            }
        }

        private void textBoxMax_salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за максимална заплата!");
                e.KeyChar = (char)0;
            }
        }

        



        private void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
            {
                SqlCommand jobsQuerry = new SqlCommand("DELETE from JOBS WHERE JOB_ID = @JOB_ID", con);

                jobsQuerry.Parameters.AddWithValue("@JOB_ID", textBoxJobsID.Text);

                con.Open();
                jobsQuerry.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Записът е изтрит!");
            this.jOBSBindingSource.RemoveCurrent();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            jOBSBindingSource.MoveNext();
            jOBSBindingSource1.MoveNext();
            jOBSBindingSource2.MoveNext();
            jOBSBindingSource3.MoveNext();
            jOBSBindingSource4.MoveNext();
            jOBSBindingSource5.MoveNext();
            jOBSBindingSource6.MoveNext();
            rEGIONSBindingSource.MoveNext();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            jOBSBindingSource.MovePrevious();
            jOBSBindingSource1.MovePrevious();
            jOBSBindingSource2.MovePrevious();
            jOBSBindingSource3.MovePrevious();
            jOBSBindingSource4.MovePrevious();
            jOBSBindingSource5.MovePrevious();
            jOBSBindingSource6.MovePrevious();
            rEGIONSBindingSource.MovePrevious();
        }

        private void textBoxStart_vacation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)45))
            {
                MessageBox.Show("Позволени са числа и точка (.) за начало на отпуската!");
                e.KeyChar = (char)0;
            }

        }

        private void textBoxEnd_vacation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)45))
            {
                MessageBox.Show("Позволени са числа и точка (.) за края на отпуската!");
                e.KeyChar = (char)0;
            }

        }

        private void Jobs_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this.eMPLOYEESTableAdapter.Fill(this.humanResDataSet.EMPLOYEES);
        }

        private void comboBox1_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, MouseEventArgs e)
        {
        
            
            SqlCommand jobsQuerry = new SqlCommand("SELECT REGION_ID FROM REGIONS", con);
            con.Open();
            
           
            SqlDataReader sqlReader = jobsQuerry.ExecuteReader();
  
            while(sqlReader.Read())
            {
              
                if (!comboBox1.Items.Contains(sqlReader["REGION_ID"].ToString()))
                    { 
                    comboBox1.Items.Add(sqlReader["REGION_ID"].ToString());
                    } 
            }
           
           
            con.Close();
            sqlReader.Close();
            comboBox1.ResetText();
           
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
  
                e.KeyChar = (char)0;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
     }
}
