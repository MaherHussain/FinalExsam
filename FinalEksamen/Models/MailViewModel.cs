using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalEksamen.Models
{
    public class MailViewModel
    {

        [Required(ErrorMessage = "Du skal taste noget")]
        [EmailAddress(ErrorMessage = "Invalid emailadresse - husk et @")]
        public string MailAdressFrom { get; set; }
        public string MailAdressTo { get; set; }
        public string MailName { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public Boolean CheckNewsletter { get; set; }
        public string Message { get; set; }
        public List<Bestyrelse_Tb> BestrelseListe { get; set; }
        public int optionId { get; set; }
        public Bestyrelse_Tb BestrelseMedlem { get; set; }
    }
}