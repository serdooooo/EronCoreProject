namespace EronCoreProject.Models
{
    public class CategoryAddModel : IEronModel
    {
        public string e_kategori_adi { get; set; }
    }
    public class CategoryUpdateModel : IEronModel
    {
        public int ESKI_ID { get; set; }
        public string e_kategori_adi { get; set; }
    }
    public class CategoryDeleteModel : IEronModel
    {
        public int ESKI_ID { get; set; }

        public CategoryDeleteModel(int id)
        {
            ESKI_ID = id;
        }
    }
}
