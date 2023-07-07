using CodeFirst.TelefonRehberi.Core.Context;
using CodeFirst.TelefonRehberi.Core.Entities;
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
    public partial class FrmKisiDetay : Form
    {
        public FrmKisiDetay(Kisi secilenKisi)
        {
            InitializeComponent();
            secilenk = secilenKisi;

        }
        Kisi secilenk = new Kisi();
        private void FrmKisiDetay_Load(object sender, EventArgs e)
        {
            BilgiGetirIletisim();
            KisiBilgileriniGetir();

        }

        public List<IletisimDetay> KisiIDileIletisimBilgiGetir(int KisiID)
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                var kisininIletisimleri = db.IletisimDetay
                    .Where(ile => ile.KisiID == KisiID)
                    .Select(ile => new
                    {
                        ile.IletisimBilgi,
                        ile.IletisimID,
                        ile.KisiID,
                        ile.IletisimTuruID
                    })
                    .ToList();

                // IletisimDetay listesine dönüştürme
                List<IletisimDetay> result = kisininIletisimleri.Select(ile => new IletisimDetay
                {
                    IletisimBilgi = ile.IletisimBilgi,
                    IletisimID = ile.IletisimID,
                    KisiID = ile.KisiID,
                    IletisimTuruID = ile.IletisimTuruID
                }).ToList();

                return result;
            }
        }


        private void KisiBilgileriniGetir()
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                txtAd.Text = secilenk.Ad;
                txtSoyad.Text = secilenk.Soyad;
                txtCinsiyet.Text = secilenk.Cinsiyet == true ? "Erkek" : "Kadın";
                txtTc.Text = secilenk.TCNo;
                btnAdresDüzenle.Tag = btnEpostaDuzenle.Tag = btnTelefonDuzenle.Tag = secilenk.KisiID;
                List<IletisimDetay> telnolar = new List<IletisimDetay>();
                telnolar = KisiIDileIletisimBilgiGetir(secilenk.KisiID);
                foreach (var item in telnolar)
                {
                    if (item.IletisimTuruID == 1)
                    {
                        cmbTelefonList.Items.Add(item);
                    }
                    else
                    {
                        if (item.IletisimTuruID == 2)
                        {
                            cmbEpostaList.Items.Add(item);
                        }
                        else
                        {
                            if (item.IletisimTuruID == 3)
                            {
                                cmbAdresList.Items.Add(item);
                            }
                            else
                            {

                            }
                        }
                    }

                }
            }

        }

        //Cinsiyet seçimi için buton
        private void btnCinsiyetGuncelle_Click(object sender, EventArgs e)
        {
            if (txtCinsiyet.Text == "Kadın")
            {
                txtCinsiyet.Text = "Erkek";
            }
            else
            {
                txtCinsiyet.Text = "Kadın";
            }
        }
        //FrmDetayDuzenle formundaki verileri tutacak liste.
        List<IletisimDetay> eklenecekKisiBilgileri = new List<IletisimDetay>();

        #region ... butonları
        private void btnTelefonDuzenle_Click(object sender, EventArgs e)
        {
            FrmDetayDuzenle frm = new FrmDetayDuzenle(eklenecekKisiBilgileri);
            //FrmDetayDuzenle formundaki metod.
            frm.NerdenGeldi("Telefon");
            frm.ShowDialog();
            eklenecekKisiBilgileri = frm.teladresmailBilgi;
            BilgiGetirIletisim();
        }

        private void btnEpostaDuzenle_Click(object sender, EventArgs e)
        {
            FrmDetayDuzenle frm = new FrmDetayDuzenle(eklenecekKisiBilgileri);
            //FrmDetayDuzenle formundaki metod.
            frm.NerdenGeldi("Eposta");
            frm.ShowDialog();
            eklenecekKisiBilgileri = frm.teladresmailBilgi;
            BilgiGetirIletisim();
        }

        private void btnAdresDüzenle_Click(object sender, EventArgs e)
        {
            FrmDetayDuzenle frm = new FrmDetayDuzenle(eklenecekKisiBilgileri);
            //FrmDetayDuzenle formundaki metod.
            frm.NerdenGeldi("Adres");
            frm.ShowDialog();
            eklenecekKisiBilgileri = frm.teladresmailBilgi;
            BilgiGetirIletisim();
        }
        #endregion



        private void BilgiGetirIletisim()
        {
            //FrmDetayDuzenle formunda girilen verileri comboxlara ekliyor.
            foreach (IletisimDetay item in eklenecekKisiBilgileri)
            {
                if (item.IletisimTuruID == 1)
                {
                    cmbTelefonList.Items.Add(item);
                }
                else if (item.IletisimTuruID == 2)
                {
                    cmbEpostaList.Items.Add(item);
                }
                else if (item.IletisimTuruID == 3)
                {
                    cmbAdresList.Items.Add(item);
                }
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            //Ad, Soyad textboxları ve eklenecekKisiBilgileri listesi kontrol edilir. İçlerinden biri boş ise kayıt yapılmaz.
            //eklenecekKisiBilgileri listesinde kişiye ait telefon, eposta, adres bilgileri tutulur.
            if (!string.IsNullOrWhiteSpace(txtAd.Text) && !string.IsNullOrWhiteSpace(txtSoyad.Text) && eklenecekKisiBilgileri.Count > 0)
            {
                //Kişi özlük bilgileri
                Kisi kisiBilgi = new Kisi
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    TCNo = txtTc.Text,
                    //Cinsiyet Erkek ise db de TRUE , Kadın ise FALSE görüntülenecek.
                    Cinsiyet = (txtCinsiyet.Text == "Erkek" ? true : false)
                };
                using (TransactionScope tran = new TransactionScope())
                {
                    try
                    {
                        using (MyDBEntities db = new MyDBEntities())
                        {
                            Kisi yeniKisi = db.Kisi.Add(kisiBilgi);
                            db.SaveChanges();
                            //kişinini iletişim bilgileri (telefon, eposta, adres)
                            foreach (IletisimDetay item in eklenecekKisiBilgileri)
                            {
                                item.KisiID = kisiBilgi.KisiID;
                                db.IletisimDetay.Add(item);
                                db.SaveChanges();
                            }
                        }
                        tran.Complete();
                        MessageBox.Show("Kişi rehbere başarıyla eklendi.");
                    }
                    catch (Exception ex)
                    {
                        tran.Dispose();
                        MessageBox.Show("Hata : " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ad Soyad ve iletişim bilgisi alanları boş olamaz.");
            }
        }
    }
}
