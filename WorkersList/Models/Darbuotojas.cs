namespace WorkersList.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Darbuotojas
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Vardas")]
        public string Vardas { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Pavardė")]

        public string Pavarde { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Asmens kodas")]

        public string Asmens_kodas { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Gimimo data")]

        public DateTime Gimimo_data { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Adresas")]

        public string Adresas { get; set; }

        [Required]
        [Display(Name = "Aktyvumo požymis")]

        public bool Aktyvumo_pozymis { get; set; }
    }
}
