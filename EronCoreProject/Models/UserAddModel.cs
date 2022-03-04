namespace EronCoreProject.Models
{
        public class UserAddModel : IEronModel
        {
            public int e_kategori_id { get; set; }
            public string e_adi_soyadi { get; set; }
            public string e_telefon { get; set; }
        }
    public class UserDeleteModel : IEronModel
    {
        public int ESKI_ID { get; set; }

        public UserDeleteModel(int id)
        {
            ESKI_ID = id;
        }
    }
    public class UserUpdateModel : IEronModel
    {
        public int ESKI_ID { get; set; }
        public int e_kategori_id { get; set; }
        public string e_adi_soyadi { get; set; }
        public string e_telefon { get; set; }
    }
}
