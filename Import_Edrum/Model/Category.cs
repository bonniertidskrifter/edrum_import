using System;
using System.Collections.Generic;
using System.Text;

namespace Import_Edrum.Model
{
    public class Category
    {
        public ulong Id { get; set; } //wp_terms, wp_taxanomy
        public string Name { get; set; } //wp_terms
        public string Slug { get; set; } //wp_terms
        public int Group { get; set; } //wp_terms
        public ulong TaxonomyId { get; set; }  //wp_taxanomy
        public string Taxonomy { get; set; } //wp_taxanomy
        public string Description { get; set; } //wp_taxanomy
        public ulong ParentId { get; set; } //wp_taxanomy
        public long Count { get; set; } //wp_taxanomy
    }
}
