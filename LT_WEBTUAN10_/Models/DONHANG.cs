namespace LT_WEBTUAN10_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MADONHANG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYGIAO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYDAT { get; set; }

        public bool? DATHANHTOAN { get; set; }

        [StringLength(50)]
        public string TINHTRANGGIAOHANG { get; set; }

        public int? MAKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
