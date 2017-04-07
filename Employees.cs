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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            employeeDataSet1.Clear();
            sqlDataAdapter1.Fill(employeeDataSet1.EMPLOYEES);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.eMPLOYEESBindingSource.EndEdit();
            this.sqlDataAdapter1.Update(this.employeeDataSet1);
            MessageBox.Show("Съществуващ запис е добавен!");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text)
                || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox7.Text)
                || string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Оставили сте непопълнено поле!");
            }

            else
            {
                SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
                {
                    SqlCommand employeeQuerry = new SqlCommand("INSERT into EMPLOYEES(EMPLOYEE_ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, SALARY, JOB_ID) Values(@EMPLOYEE_ID, @FIRST_NAME, @LAST_NAME, @EMAIL, @PHONE_NUMBER, @SALARY, @JOB_ID)", con);

                    employeeQuerry.Parameters.AddWithValue("@EMPLOYEE_ID", textBox1.Text);
                    employeeQuerry.Parameters.AddWithValue("@FIRST_NAME", textBox2.Text);
                    employeeQuerry.Parameters.AddWithValue("@LAST_NAME", textBox3.Text);
                    employeeQuerry.Parameters.AddWithValue("@EMAIL", textBox4.Text);
                    employeeQuerry.Parameters.AddWithValue("@PHONE_NUMBER", textBox6.Text);
                    employeeQuerry.Parameters.AddWithValue("@SALARY", textBox7.Text);
                    employeeQuerry.Parameters.AddWithValue("@JOB_ID", textBox8.Text);

                    con.Open();
                    employeeQuerry.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Нов запис е доабвен!");
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
            {
                SqlCommand jobsQuerry = new SqlCommand("DELETE from EMPLOYEES WHERE EMPLOYEE_ID = @EMPLOYEE_ID", con);

                jobsQuerry.Parameters.AddWithValue("@EMPLOYEE_ID", textBox1.Text);

                con.Open();
                jobsQuerry.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Съществуващ запис е изтрит!");
            this.eMPLOYEESBindingSource.RemoveCurrent();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            eMPLOYEESBindingSource.MovePrevious();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            eMPLOYEESBindingSource.MoveNext();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за ID!");
                e.KeyChar = (char)0;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете букви!");
                e.KeyChar = (char)0;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете букви!");
                e.KeyChar = (char)0;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете телефонен номер!");
                e.KeyChar = (char)0;
            }

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете заплата!");
                e.KeyChar = (char)0;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за ID!");
                e.KeyChar = (char)0;
            }

        }
    }
}
