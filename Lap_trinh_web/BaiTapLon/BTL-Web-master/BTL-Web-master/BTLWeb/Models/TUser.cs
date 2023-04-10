using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTLWeb.Models;

public partial class TUser
{
    
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    /*[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]*/
    public byte? LoaiUser { get; set; }

    public virtual ICollection<TKhachHang> TKhachHangs { get; } = new List<TKhachHang>();
}
