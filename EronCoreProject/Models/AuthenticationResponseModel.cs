using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EronCoreProject.Models
{
    public abstract class ResponseModel
    {
        public string S { get; set; }
        public string HATA_KODU { get; set; }
        public string HATA_ACIKLAMASI { get; set; }
        public string MESAJ { get; set; }
    }
    public class AuthenticationResponseModel:ResponseModel
    {
        public string UTOKEN { get; set; }
        public string e_personel_adi_soyadi { get; set; }
        public string e_personel_id { get; set; }
    }
    public class LogoutResponseModel : ResponseModel
    {
    }
    public class CategoryResponseModel : ResponseModel
    {
    }
}
