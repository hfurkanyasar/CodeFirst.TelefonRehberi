using CodeFirst.TelefonRehberi.Core.Entities;
using CodeFirst.TelefonRehberi.UI.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst.TelefonRehberi.UI
{
    public partial class FrmDetayDuzenle : Form
    {
        public FrmDetayDuzenle(List<IletisimDetay> eklenecekKisiBilgileri)
        {
            InitializeComponent();
            teladresmailBilgi = eklenecekKisiBilgileri;
        }
        public void NerdenGeldi(string gorunenliste)
        {
            lblBaslik.Text = gorunenliste + " Bilgileri";
        }

        public List<IletisimDetay> teladresmailBilgi = new List<IletisimDetay>();

        private void btnEkle_Click(object sender, EventArgs e)
        {
            IletisimDetay bilgi = new IletisimDetay();
            int numara;
            //FrmKisiDetay formunda hangi bilgi butonuna tıklandıysa ona göre işlem yapılacak. Textbox a boş bilgi girilemez.
            //Telefon eklenmek istendiğinde girilen değerin sayısal değer olması gerekir.
            if (lblBaslik.Text == "Telefon Bilgileri" && !string.IsNullOrWhiteSpace(txtEklenecekBilgi.Text))
            {
                //telefon bilgisi ekleniyor
                bilgi = new IletisimDetay
                {
                    IletisimTuruID = 1,
                    IletisimBilgi = txtEklenecekBilgi.Text
                };
                teladresmailBilgi.Add(bilgi);
                lstBilgiListesi.Items.Add(txtEklenecekBilgi.Text);
            }
            else if (lblBaslik.Text == "Eposta Bilgileri" && !string.IsNullOrWhiteSpace(txtEklenecekBilgi.Text))
            {
                //eposta bilgileri ekleniyor
                bilgi = new IletisimDetay
                {
                    IletisimTuruID = 2,
                    IletisimBilgi = txtEklenecekBilgi.Text
                };
                teladresmailBilgi.Add(bilgi);
                lstBilgiListesi.Items.Add(txtEklenecekBilgi.Text);
            }
            else if (lblBaslik.Text == "Adres Bilgileri" && !string.IsNullOrWhiteSpace(txtEklenecekBilgi.Text))
            {
                //adres bilgisi ekleniyor
                bilgi = new IletisimDetay
                {
                    IletisimTuruID = 3,
                    IletisimBilgi = txtEklenecekBilgi.Text
                };
                teladresmailBilgi.Add(bilgi);
                lstBilgiListesi.Items.Add(txtEklenecekBilgi.Text);
            }
            else
            {
                MessageBox.Show("Girilen değer hatalı.");
            }
        }

        private void FrmDetayDuzenle_Load(object sender, EventArgs e)
        {
            //listbox için tel,adres,eposta listelerini çek
        }
    }
}
