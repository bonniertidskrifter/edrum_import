using System;
using System.Collections.Generic;
using System.Text;

namespace Import_Edrum.Model
{
    public class Postmeta
    {
        public ulong? MetaId { get; set; }
        public ulong PostId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
