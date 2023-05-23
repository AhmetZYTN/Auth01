using Auth01.Models;

namespace Auth01.Models
{
    public class FAQModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }


        public int CategoryId { get; set; }
        public FAQCat Categorys { get; set; }
    }

public class FAQCat
    {
        public int Id { get; set; }
        public string CatName { get; set; }
        public List<FAQModel> FAQs { get; set; }
    }
}

