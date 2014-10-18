using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityThreeLayerPracticeApp.BLL;
using UniversityThreeLayerPracticeApp.DLL.DAO;

namespace UniversityThreeLayerPracticeApp
{
    public partial class UniversityUI : Form
    {
        public UniversityUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            aStudent.Name = nameTextBox.Text;
            aStudent.Email = emailTextBox.Text;
            aStudent.Address = addressTextBox.Text;

            StudentBLL aStudentBll = new StudentBLL();
            string msg = aStudentBll.Save(aStudent);// here , to send aStudent object, because all logic apply base on this object 
            MessageBox.Show(msg);
        }
    }
}
