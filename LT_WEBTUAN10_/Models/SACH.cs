namespace LT_WEBTUAN10_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            THAMGIAs = new HashSet<THAMGIA>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        [Required]
        [StringLength(50)]
        public string TENSACH { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABAN { get; set; }

        [StringLength(50)]
        public string MOTA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYCAPNHAT { get; set; }

        [StringLength(50)]
        public string ANHBIA { get; set; }

        public int? SOLUONGTON { get; set; }

        public bool? MOI { get; set; }

        public int? MACHUDE { get; set; }

        public int? MANXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual CHUDE CHUDE { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THAMGIA> THAMGIAs { get; set; }
    }
}
