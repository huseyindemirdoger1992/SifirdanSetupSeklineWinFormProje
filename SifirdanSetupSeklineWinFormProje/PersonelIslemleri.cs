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
    public partial class PersonelIslemleri : Form
    {
        SifirdanSetupSeklineWinFormProjeEntitiesConnectionDb db = new SifirdanSetupSeklineWinFormProjeEntitiesConnectionDb();
        public PersonelIslemleri()
        {
            InitializeComponent();
        }
        public void Temizle()
        {
            dataGridView1.DataSource = db.Personel.ToList();
            txtAd.Text = txtSoyad.Text = txtMail.Text = txtPass.Text = txtTel.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personel p = new Personel();
            p.Ad = txtAd.Text;
            p.Soyad = txtSoyad.Text;
            p.Mail = txtMail.Text;
            p.Pass = txtPass.Text;
            p.Telefon = txtTel.Text;
            p.KayitTarihi = DateTime.Now;
            db.Personel.Add(p);
            db.SaveChanges();
            Temizle();
        }

        private void PersonelIslemleri_Load(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Silinecek = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Personel SilinecekPersonel = db.Personel.FirstOrDefault(x => x.Id == Silinecek);
            DialogResult Onay = MessageBox.Show("Seçili olan personel kalıcı olarak silinecek. Bu işlemi yapmak istediğinizden emin misiniz?","Kalıcı Olarak Silinecek",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (Onay == DialogResult.Yes)
            {
                db.Personel.Remove(SilinecekPersonel);
                db.SaveChanges();
                Temizle();
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPass.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Personel p = db.Personel.FirstOrDefault(x => x.Id == id);
            p.Ad = txtAd.Text;
            p.Soyad = txtSoyad.Text;
            p.Mail = txtMail.Text;
            p.Pass = txtPass.Text;
            p.Telefon = txtTel.Text;
            db.SaveChanges();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
