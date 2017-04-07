using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace humanres
{
    public partial class HumanResources : Form
    {
        public HumanResources()
        {
            InitializeComponent();
        }

        private void HumanResources_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // затваря главния прозорец
        }

        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Regions newForm = new Regions();
            newForm.ShowDialog(this);
        }

        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jobs newForm = new Jobs();
            newForm.ShowDialog(this);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DepartmentsStripMenuItem_Click(object sender, EventArgs e)
        {
            Departments newForm = new Departments();
            newForm.ShowDialog(this);
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           Employees newForm = new Employees();
            newForm.ShowDialog(this);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeSearch newForm = new EmployeeSearch();
            newForm.ShowDialog(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeesPrint newForm = new EmployeesPrint();
            newForm.ShowDialog(this);
        }
    }
}
