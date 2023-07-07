using CodeFirst.TelefonRehberi.Core.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.TelefonRehberi.Core.Entities
{
    public class Kisi
    {
        public int KisiID { get; set; }

        [Required(ErrorMessage = "bu alan boş geçilemez")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "bu alan boş geçilemez")]
        public string Soyad { get; set; }
        public bool Cinsiyet { get; set; } //Cinsiyet Erkek ise db de TRUE , Kadın ise FALSE görüntülenecek.

        public string TCNo { get; set; } //longda olur

        public List<IletisimDetay> IletisimDetay { get; set; }

        public override string ToString()
        {
            return Ad+ " " +Soyad;
        }


        public List<Kisi> AdIleKisiArama(string girilenAd)
        {
            List<Kisi> aranilanAdaGoreListe = null;
            using (MyDBEntities db = new MyDBEntities())
            {
                aranilanAdaGoreListe = db.Kisi.Where(a => a.Ad.ToUpper().Contains(girilenAd.ToUpper())).Select(a => new Kisi()
                {
                    Ad = a.Ad,
                    Soyad = a.Soyad,
                    Cinsiyet = a.Cinsiyet,
                    IletisimDetay = a.IletisimDetay,
                    KisiID = a.KisiID,
                    TCNo = a.TCNo
                }).ToList();
            }
            return aranilanAdaGoreListe;
        }

        public List<Kisi> SoyAdIleKisiArama(string girilenSoyad)
        {
            List<Kisi> aranilanSoyadaGoreListe = null;
            using (MyDBEntities db = new MyDBEntities())
            {
                aranilanSoyadaGoreListe = db.Kisi.Where(a => a.Soyad.ToUpper().Contains(girilenSoyad.ToUpper())).Select(a => new Kisi()
                {
                    Ad = a.Ad,
                    Soyad = a.Soyad,
                    Cinsiyet = a.Cinsiyet,
                    IletisimDetay = a.IletisimDetay,
                    KisiID = a.KisiID,
                    TCNo = a.TCNo
                }).ToList();
            }
            return aranilanSoyadaGoreListe;
        }

        public List<Kisi> BilgiIleKisiArama(string bilgi)
        {
            List<Kisi> aranilanBilgiyeGoreListe = null;
            using (MyDBEntities db = new MyDBEntities())
            {
                aranilanBilgiyeGoreListe = (from k in db.Kisi
                                           join ile in db.IletisimDetay on k.KisiID equals ile.KisiID
                                           where ile.IletisimBilgi == bilgi
                                           select new Kisi
                                           {
                                               Ad = k.Ad,
                                               Soyad = k.Soyad,
                                               KisiID = k.KisiID,
                                               Cinsiyet = k.Cinsiyet,
                                               TCNo = k.TCNo
                                           }).ToList();
            };
            return aranilanBilgiyeGoreListe;
        }


    }
}
