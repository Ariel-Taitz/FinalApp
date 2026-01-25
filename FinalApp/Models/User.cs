using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UEmail { get; set; }
        public string? UPassword { get; set; }
        public string? UMobile { get; set; }
        public DateTime UBDate { get; set; }
        public DateTime RegDate { get; set; }
    }
}
