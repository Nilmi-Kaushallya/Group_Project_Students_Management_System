using System.ComponentModel.DataAnnotations;

namespace REG_SYSTEM
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }
        


    }
}