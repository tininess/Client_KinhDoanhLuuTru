using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonViTTTV.Models;
using DonViTTTV.ServiceReference1;

namespace DonViTTTV.Classes
{
    public class TamTruAccessConsolidator
    {
        Level2ServiceClient proxy = new Level2ServiceClient();
        public IList<TamTruModel> getAllTTTV(string username)
        {

            IList<TamTruModel> list = new List<TamTruModel>();
            var data = proxy.getAllTamTru().Where(e=>e.TaiKhoanDangKi==username);
            foreach (var item in data)
            {
                TamTruModel model = new TamTruModel();
                model.MaTamTru = item.ID_TamTru;
                model.GiayTo = item.TTTV__GiayTo.GiayTo;
                model.QuocTich = item.TTTV__QuocTich.QuocTich;
                model.LiDo = item.TTTV__LiDo.LiDo;
                model.TT_FullName = item.TT_FullName;
                model.TT_NgayDen = item.TT_NgayDen;
                model.TT_NgayDi = item.TT_NgayDi;
                model.TT_DiaChiThuongTru = item.TT_DiaChiThuongTru;
                model.TT_Room = item.TT_Room;
                model.TT_GiayTo = item.TT_GiayTo;
                model.username = item.TaiKhoanDangKi;
                list.Add(model);
            }
            return list;
        }
        public TamTruModel getTTTVByID(int id)
        {
            TTTV__TamTru item = proxy.getTamTruById(id);
            TamTruModel model = new TamTruModel();

            model.MaTamTru = item.ID_TamTru;
            model.SelectedLiDoValue = item.ID_LiDo;
            model.SelectedQuocTichValue = item.ID_QuocTich;
            model.SelectedGiayToValue = item.ID_GiayTo;
            model.GiayTo = item.TTTV__GiayTo.GiayTo;
            model.QuocTich = item.TTTV__QuocTich.QuocTich;
            model.LiDo = item.TTTV__LiDo.LiDo;
            model.TT_FullName = item.TT_FullName;
            model.TT_NgayDen = item.TT_NgayDen;
            model.TT_NgayDi = item.TT_NgayDi;
            model.TT_DiaChiThuongTru = item.TT_DiaChiThuongTru;
            model.TT_Room = item.TT_Room;
            model.TT_GiayTo = item.TT_GiayTo;
            model.TT_LiDoKhac = item.TT_LiDoKhac;
            model.username = item.TaiKhoanDangKi;
            return model;

        }
    }
}