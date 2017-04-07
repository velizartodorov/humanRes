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
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sqlDataAdapter1_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            departmentsDataSet11.Clear();
            sqlDataAdapter1.Fill(departmentsDataSet11.DEPARTMENTS);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dEPARTMENTSBindingSource.EndEdit();
            this.sqlDataAdapter1.Update(this.departmentsDataSet11);

          
            MessageBox.Show("Записът е променен!");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDepartmentID.Text) || string.IsNullOrWhiteSpace(textBoxLocationID.Text)
                || string.IsNullOrWhiteSpace(textBoxEmployeeID.Text) || string.IsNullOrWhiteSpace(textBoxManagerID.Text))
            {
                MessageBox.Show("Оставили сте непопълнено поле!");
            }

            else
            {
                SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");

                {
                    SqlCommand departmentQuerry = new SqlCommand("INSERT into DEPARTMENTS(DEPARTMENT_ID, EMPLOYEE_ID, MANAGER_ID, LOCATION_ID) Values(@DEPARTMENT_ID, @EMPLOYEE_ID, @MANAGER_ID, @LOCATION_ID)", con);

                    departmentQuerry.Parameters.AddWithValue("@DEPARTMENT_ID", textBoxDepartmentID.Text);
                    departmentQuerry.Parameters.AddWithValue("@EMPLOYEE_ID", textBoxLocationID.Text);
                    departmentQuerry.Parameters.AddWithValue("@MANAGER_ID", textBoxEmployeeID.Text);
                    departmentQuerry.Parameters.AddWithValue("@LOCATION_ID", textBoxManagerID.Text);

                    con.Open();
                    departmentQuerry.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Добавен е нов запис!");
            }
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
            {
                SqlCommand departmentQuerry = new SqlCommand("DELETE from DEPARTMENTS WHERE DEPARTMENT_ID = @DEPARTMENT_ID", con);

                departmentQuerry.Parameters.AddWithValue("@DEPARTMENT_ID", textBoxDepartmentID.Text);

                con.Open();
                departmentQuerry.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Съществуващ запис е изтрит!");
            this.dEPARTMENTSBindingSource.RemoveCurrent();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            dEPARTMENTSBindingSource.MovePrevious();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            dEPARTMENTSBindingSource.MoveNext();
        }

        private void textBoxDepartmentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за ID!");
                e.KeyChar = (char)0;
            }
        }

        private void textBoxEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за ID!");
                e.KeyChar = (char)0;
            }
        }

        private void textBoxLocationID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за ID!");
                e.KeyChar = (char)0;
            }

        }

        private void textBoxManagerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за ID!");
                e.KeyChar = (char)0;
            }
        }
    }
}
