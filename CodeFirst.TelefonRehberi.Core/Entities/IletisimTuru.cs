using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.TelefonRehberi.Core.Entities
{
    public class IletisimTuru
    {
        [Key]
        public int IletisimTuruID { get; set; }

        [Required(ErrorMessage = "bu alan boş geçilemez")]
        [StringLength(70,ErrorMessage = "3-70 karakter arasında veri giriniz.",MinimumLength =3)]
        public string TurAdi { get; set; }

        public List<IletisimDetay> IletisimDetays { get; set; }


    }
}
