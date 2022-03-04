using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EronCoreProject.Models
{
    public class AuthenticationModel:IEronModel
    {
        public string e_kullanici_adi { get; set; }
        public string e_sifre { get; set; }
    }
}
