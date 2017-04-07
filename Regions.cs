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
    public partial class Regions : Form
    {
        public Regions()
        {
            InitializeComponent();
        }

        private void Regions_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            regionsDataSet1.Clear();
            sqlDataAdapter1.Fill(regionsDataSet1.REGIONS);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rEGIONSBindingSource.EndEdit();
            this.sqlDataAdapter1.Update(this.regionsDataSet1);
            MessageBox.Show("Записът е променен!");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxRegionID.Text) || string.IsNullOrWhiteSpace(textBoxRegionName.Text))
            {
                MessageBox.Show("Оставили сте непопълнено поле!");
            }

            else
            {
                SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");

                {
                    SqlCommand regionsQuerry = new SqlCommand("INSERT into REGIONS(REGION_ID, REGION_NAME) Values(@REGION_ID, @REGION_NAME)", con);

                    regionsQuerry.Parameters.AddWithValue("@REGION_ID", textBoxRegionID.Text);
                    regionsQuerry.Parameters.AddWithValue("@REGION_NAME", textBoxRegionName.Text);

                    con.Open();
                    regionsQuerry.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Нов запис добавен!");
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
            {
                SqlCommand jobsQuerry = new SqlCommand("DELETE from REGIONS WHERE REGION_ID = @REGION_ID", con);

                jobsQuerry.Parameters.AddWithValue("@REGION_ID", textBoxRegionID.Text);

                con.Open();
                jobsQuerry.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Съществуващия запис е изтрит!");
            this.rEGIONSBindingSource.RemoveCurrent();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            rEGIONSBindingSource.MovePrevious();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            rEGIONSBindingSource.MoveNext();
        }

        private void textBoxRegionID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(e.KeyChar == (char)8))
            {
                MessageBox.Show("Моля, въведете числа за ID!");
                e.KeyChar = (char)0;
            }
        }
    }
}
