using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DonViTTTV.Models
{
    public class TamTruModel
    {
       
            [Display(Name = "Mã Tạm Trú")]
            public int MaTamTru { get; set; }

            [Required]
            [Display(Name = "_Loại Giấy Tờ")]
            public int? SelectedGiayToValue { get; set; }

            [Display(Name = "Loại Giấy Tờ")]
            public string GiayTo { get; set; }

            [Required]
            [Display(Name = "_Lí Do")]
            public int? SelectedLiDoValue { get; set; }

            [Display(Name = "Lí Do")]
            public string LiDo { get; set; }

            [Required]
            [Display(Name = "_Quốc Tịch")]
            public int? SelectedQuocTichValue { get; set; }

            [Display(Name = "Quốc Tịch")]
            public string QuocTich { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [Display(Name = "Họ Và Tên")]
            public string TT_FullName { get; set; }



            [Required]
            [Display(Name = "Ngày Đến")]
            [DataType(DataType.Time)]
            [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime? TT_NgayDen { get; set; }


            [Required]
            [Display(Name = "Ngày Đi")]
            [DataType(DataType.Time)]
            [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime? TT_NgayDi { get; set; }

            // Địa chỉ tạm trú cho cá nhân hoặc dk tại trụ sở công an.
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
            [Display(Name = "Địa chỉ thường trú")]
            public string TT_DiaChiThuongTru { get; set; }


            [Display(Name = "Phòng")]
            public string TT_Room { get; set; }


            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 7)]
            [Display(Name = "Giấy Tờ")]
            public string TT_GiayTo { get; set; }


            [Display(Name = "Người Đăng Kí")]
            public string username { get; set; }
            [Display(Name = "Lí Do Khác")]
            public string TT_LiDoKhac { get; set; }

        
    }
}