using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC317PassManagerP2Starter.Modules.Models
{
    public class PasswordModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string PlatformName { get; set; }
        public string PlatformUserName { get; set; }
        public byte[] PasswordText { get; set; }
    }

}
