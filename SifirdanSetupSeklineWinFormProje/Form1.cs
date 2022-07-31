using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SifirdanSetupSeklineWinFormProje.Models;

namespace SifirdanSetupSeklineWinFormProje
{
    public partial class Form1 : Form
    {
        SifirdanSetupSeklineWinFormProjeEntitiesConnectionDb db = new SifirdanSetupSeklineWinFormProjeEntitiesConnectionDb();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personel durum = db.Personel.FirstOrDefault(x => x.Mail == textBox1.Text && x.Pass == textBox2.Text);
            if (durum != null)
            {
                PersonelIslemleri pi = new PersonelIslemleri();
                this.Hide();
                pi.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Girilen Bilgiler Yanlıştır.","Durum",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Text = textBox2.Text = null;
            }
        }
    }
}
