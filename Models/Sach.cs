using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LuongXuanHoang_241224477.Models;

public partial class Sach
{
    public int MaSach { get; set; }
    public int MaTl { get; set; }
    [Required(ErrorMessage = "Ten Sach ko duoc de trong")]
    [StringLength(100, ErrorMessage = "Ten sach toi da 100 ki tu")]
    public string TenSach { get; set; } = null!;

    [Range(typeof(decimal), "50", "1000", ErrorMessage = "Gia phai tu 50 den 1000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^.*\.(jpg|png)$", ErrorMessage = "Ten file anh co duoi jpg or png")]
    public string? Anh { get; set; }

    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
