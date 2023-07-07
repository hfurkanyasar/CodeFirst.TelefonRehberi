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
    public class IletisimDetay
    {
        [Key]
        public int IletisimID { get; set; }
        public int KisiID { get; set; }
        public string IletisimBilgi { get; set; }
        public int IletisimTuruID { get; set; }

        [ForeignKey("IletisimTuruID")]
        public IletisimTuru IletisimTuru { get; set; }

        [ForeignKey("KisiID")]
        public Kisi Kisiler { get; set; }



      


        public override string ToString()
        {
            return IletisimBilgi;
        }




    }
}
