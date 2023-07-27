using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SPModel
    {
        [Key]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
        public int JerseyNo { get; set; }
        public string Address { get; set; }

    }
    public class SP_PostModel
    {
        [Key]
        public string? PlayerName { get; set; }
        public int PlayerAge { get; set; }
        public int JerseyNo { get; set; }
        public string Address { get; set; }

    }
}
