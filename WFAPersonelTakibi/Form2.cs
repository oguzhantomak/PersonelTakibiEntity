using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using WFAPersonelTakibi.Models;

namespace WFAPersonelTakibi
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        void Listele()
        {
            dgvEmployees.DataSource = db.Employees.ToList();
        }

        MyContext db = new MyContext();
        private void Form2_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void tsmSil_Click(object sender, EventArgs e)
        {
            int id = (int)dgvEmployees.CurrentRow.Cells[0].Value;
            var personeler = db.Employees.Where(x => x.EmployeeID == id);

            Employee personel = db.Employees.FirstOrDefault(x => x.EmployeeID == id);

            db.Employees.Remove(personel);
            db.SaveChanges();
            Listele();
        }

        Employee guncellenecek;

        private void tsmDuzenle_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();

            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncelleme işlemi için eleman seçin !");
                return;
            }

            int id = (int)dgvEmployees.CurrentRow.Cells[0].Value;
            guncellenecek = db.Employees.FirstOrDefault(x => x.EmployeeID == id);

            if (guncellenecek!=null)
            {
                frm4.EmployeeName = guncellenecek.EmployeeName;
                frm4.EmployeeLastName = guncellenecek.EmployeeLastName;
                frm4.EmployeeBirthDate = guncellenecek.EmployeeBirthDate;
                frm4.EmployeeMail = guncellenecek.EmployeeMail;
                frm4.EmployeeGender = guncellenecek.EmployeeGender;
                frm4.EmployeeAddress = guncellenecek.EmployeeAddress;
                frm4.EmployeePhone = guncellenecek.EmployeePhone;
                frm4.EmployeeDepartment = guncellenecek.EmployeeDepartment;



                

                //txtFirstName.Text = guncellenecek.EmployeeName;
                //txtLastName.Text = guncellenecek.EmployeeLastName;
                //dtBirthDate.Value = guncellenecek.EmployeeBirthDate;
                //txtMail.Text = guncellenecek.EmployeeMail;
                ////Gender eklenecek
                //txtAddress.Text = guncellenecek.EmployeeAddress;
                //txtPhone.Text = guncellenecek.EmployeePhone;
                //cmbDepartment.SelectedItem = guncellenecek.EmployeeDepartment;
            }




            
            
            this.Hide();
            frm4.ShowDialog();

            
        }
    }
}
