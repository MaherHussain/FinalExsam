using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalEksamen.Models
{
    public class SearchViewModel
    {
        public List<EventsTb> Events { get; set; }
        public EventsTb MyEvent { get; set; }

        public List<Bestyrelse_Tb> Medlems{ get; set; }
        
    }
}