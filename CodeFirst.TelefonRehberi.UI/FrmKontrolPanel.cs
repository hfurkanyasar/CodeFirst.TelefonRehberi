using CodeFirst.TelefonRehberi.Core.Context;
using CodeFirst.TelefonRehberi.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace CodeFirst.TelefonRehberi.UI
{
    public partial class FrmKontrolPanel : Form
    {
        public FrmKontrolPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == "123")
            {
                txtEklenecekTur.Enabled = true;
                btnEkle.Enabled = true;
                txtSifre.Enabled = false;
                button1.Enabled = false;
                lbldurum.ForeColor = Color.LimeGreen;
                lbldurum.Text = "Server ile bağlantı kuruldu.";
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    using (MyDBEntities db = new MyDBEntities())
                    {
                        db.IletisimTuru.Add(new IletisimTuru()
                        {
                            TurAdi = txtEklenecekTur.Text
                        });
                        int kayit = db.SaveChanges();
                        tran.Complete();
                        if (kayit > 0)
                        {
                            MessageBox.Show("İletişim türü veritabanına eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt başarısız.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    MessageBox.Show("Kayıt başarısız." + ex.Message);
                }
            }
        }
    }
}
