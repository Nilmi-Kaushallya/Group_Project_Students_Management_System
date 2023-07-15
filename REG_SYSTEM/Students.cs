using System.ComponentModel.DataAnnotations;

namespace REG_SYSTEM
{
    public class Students
    {
        [Key]
        public int Reg_No { get; set; }
        public string Name { get; set;}
        public string Address { get; set;}
        public string EE3301 { get; set;}
        public string EE3302 { get; set; }
        public string EE3303 { get; set; }
        public string GPA { get; set; }

    }
}