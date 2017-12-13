using System;
using System.Collections.Generic;
using System.Text;

namespace Import_Edrum.Model
{
    public class User
    {
        public ulong Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Nicename { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public DateTime Registered { get; set; }
        public string ActivationKey { get; set; }
        public int Status { get; set; }
        public string DisplayName { get; set; }
    }
}
