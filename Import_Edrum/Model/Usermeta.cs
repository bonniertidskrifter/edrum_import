using System;
using System.Collections.Generic;
using System.Text;

namespace Import_Edrum.Model
{
    public class Usermeta
    {
        public ulong? MetaId { get; set; }
        public ulong UserId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
