using System.ComponentModel.DataAnnotations;

namespace REG_SYSTEM
{
    public class Students
    {
        [Key]
        public string Reg_No { get; set; }
        public string Name { get; set;}
        public string Address { get; set;}
        public int Marks_IS3301 { get; set;}
        public int Marks_EE3302 { get; set; }
        public int Marks_EE3251 { get; set; }
        public int GPA { get; set; }

    }
}