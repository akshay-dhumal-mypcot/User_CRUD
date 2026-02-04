using System.ComponentModel.DataAnnotations;

namespace User_CRUD.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string ContactNo { get; set; }
    }
}
