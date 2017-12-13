using System;
using System.Collections.Generic;
using System.Text;

namespace Import_Edrum.Model
{
    public class Posts
    {
        public long Id { get; set; }
        public long Author { get; set; }
        public DateTime Date { get; set; }
        public DateTime Date_gmt { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Status { get; set; }
        public string CommentStatus { get; set; }
        public string PingStatus { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ToPing { get; set; }
        public string Pinged { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Modified_gmt { get; set; }
        public string ContentFiltered { get; set; }
        public ulong Parent { get; set; }
        public string Guid { get; set; }
        public int MenuOrder { get; set; }
        public string Type { get; set; }
        public string MimeType { get; set; }
        public long CommentCount { get; set; }
    }
}
