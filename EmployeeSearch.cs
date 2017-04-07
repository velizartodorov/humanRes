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
using System.Text.RegularExpressions;
using System.IO;

namespace humanres
{
    public partial class EmployeeSearch : Form
    {
        public EmployeeSearch()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void EmployeeSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'humanResDataSet.EMPLOYEES' table. You can move, or remove it, as needed.
            this.eMPLOYEESTableAdapter.Fill(this.humanResDataSet.EMPLOYEES);
            SqlConnection con = new SqlConnection("Data Source=desktop-p98i75t;Initial Catalog=HumanRes;Integrated Security=True");
            SqlDataAdapter employeePrintQuerry = new SqlDataAdapter(@"SELECT EMPLOYEES.FIRST_NAME as [Собствено име], EMPLOYEES.LAST_NAME as [Фамилно име], EMPLOYEES.EMAIL as [Електронна поща], EMPLOYEES.PHONE_NUMBER as [Тел. номер],  EMPLOYEES.SALARY as [Заплата], EMPLOYEES.JOB_ID as [Идентификатор на професия], JOBS.JOB_TITLE as [Професия], JOBS.REGION_ID as [Идентификатор на региона] from EMPLOYEES, JOBS WHERE EMPLOYEES.JOB_ID = JOBS.JOB_ID", con);

            employeePrintQuerry.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("[Собствено име] like '%{0}%' OR [Фамилно име] like '%{0}%'  OR [Електронна поща] like '%{0}%' OR [Тел. номер] like '%{0}%' OR [Заплата] like '%{0}%' OR [Идентификатор на професия] like '%{0}%' OR [Професия] like '%{0}%' OR [Идентификатор на региона] like '%{0}%'", textBoxCriteria.Text);
            dataGridView1.DataSource = dv.ToTable();
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1251);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void buttonWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.doc)|*.doc";
            sfd.FileName = "export.doc";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dataGridView1, sfd.FileName); // Here dataGridview1 is your grid view name 
            }

        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Title = "Запазете като Excell файл";
            saveFileDialog1.FileName = "excel1";
            saveFileDialog1.Filter = "Excel Files (2003)|*.xls|Excel Files (2007)|*.xlsx";
            if(saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                ExcelApp.Columns.ColumnWidth = 20;

                for(int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

                }
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }
                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
            }
        }
    }
}
