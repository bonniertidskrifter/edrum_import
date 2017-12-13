using System;
using System.Collections.Generic;
using System.Text;

namespace Import_Edrum.Model
{
    public class CategoryRelationship
    {
        public ulong ObjectId { get; set; } 
        public ulong TaxonomyId { get; set; }  
        public int TermOrder { get; set; }
    }
}
