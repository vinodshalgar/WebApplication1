using System.Collections;
using System.Collections.Generic;

namespace AAG.Model
{
    public class WatchList
    {
        public WatchList()
        {
            Securities = new HashSet<Security>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Security> Securities { get; set; }
    }
}