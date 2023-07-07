using CodeFirst.TelefonRehberi.Core.Context;
using CodeFirst.TelefonRehberi.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst.TelefonRehberi.UI
{
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            KisileriGetir();
        }

        private void KisileriGetir()
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                //lstKisiler listboxını temizler.
                lstKisiler.Items.Clear();
                //Databasedeki kisi tablosundaki kişileri lstKisiler e ekler.
                foreach (Kisi item in db.Kisi)
                {
                    lstKisiler.Items.Add(item);
                }
            }
        }

        #region Admin paneli
        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKontrolPanel frm = new FrmKontrolPanel();
            frm.Show();
        }
        #endregion

        //Yeni kişi kaydı butonu
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kisi k = new Kisi();
            FrmKisiDetay frm = new FrmKisiDetay(k);
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string bilgi = textBox1.Text;
            if (string.IsNullOrWhiteSpace(bilgi))
            {
                //text boş
                //listeyi doldur.
            }
            else
            {
                //text dolu arama yap
                var kisiler = new Kisi().BilgiIleKisiArama(bilgi);
                if (kisiler.Count > 0)
                {
                    //arama sonucunda öge bulundu
                    lstKisiler.Items.Clear();
                    foreach (var item in kisiler)
                    {
                        lstKisiler.Items.Add(kisiler);
                    }
                }
                else
                {
                    //aramadan hiçbir şey bulunmadı
                }
            }
        }
        private void lstKisiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<IletisimDetay> bilgiListe = new List<IletisimDetay>();
            Kisi secilenKisi = new Kisi();
            secilenKisi = lstKisiler.SelectedItem as Kisi;

            if (secilenKisi != null)
            {
                FrmKisiDetay frm = new FrmKisiDetay(secilenKisi);
                frm.ShowDialog();
            }
        }
    }
}
