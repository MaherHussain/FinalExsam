using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FinalEksamen.Controllers
{
    public class HomeController : Controller
    {
        private FinalEksamenDbEntities db = new FinalEksamenDbEntities();
        // GET: Home
        public ActionResult Index()
        {

            EventsTb eventdate = new EventsTb();
            eventdate = db.EventsTbs.FirstOrDefault();

            return View(eventdate);



        }

        public ActionResult Sponsore()
        {
            List<SponsorerTb> sponsoreliste = new List<SponsorerTb>();
            sponsoreliste = db.SponsorerTbs.ToList();

            return View(sponsoreliste);
        }
        public ActionResult Events()
        {
            List<EventsTb> EventListe = new List<EventsTb>();
            EventListe = db.EventsTbs.ToList();

            return View(EventListe);

        }
        public ActionResult VisEvent(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Events");

            }
            Models.TilmeldingViewModel vm = new Models.TilmeldingViewModel();
            vm.MyEvent = db.EventsTbs.Where(i => i.Id == Id).FirstOrDefault();


            //EventsTb MyEvent = new EventsTb();
            //MyEvent = db.EventsTbs.Where(i=> i.Id == Id).FirstOrDefault();
            if (vm.MyEvent == null)
            {
                return RedirectToAction("Events");
            }

            return View(vm);

        }
        [HttpPost]
        public ActionResult VisEvent(TilmedlingTb tilmedling)
        {


            if (ModelState.IsValid)
            {

                //tilmedling.MailName = db.TilmedlingTbs.FirstOrDefault();
                db.TilmedlingTbs.Add(tilmedling);

                db.SaveChanges();

                //tilmedling.MyEvent.PladserAntal = tilmedling.MyEvent.PladserAntal - 1;
            }
            //EventsTb paldsantal = db.EventsTbs.Where(i => i.Id == tilmedling.Fk_EventId).FirstOrDefault();
            //paldsantal.PladserAntal = paldsantal.PladserAntal - 1;
            //db.EventsTbs.AddOrUpdate(paldsantal);
            //db.SaveChanges();


            return RedirectToAction("Events", "Home");

        }
        public ActionResult Tilmeldinger()
        {
            List<TilmedlingTb> Tilmeldinge = new List<TilmedlingTb>();
            Tilmeldinge = db.TilmedlingTbs.ToList();
            return View(Tilmeldinge);
        }
        public ActionResult sletTilmelding(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TilmedlingTb SletTilmeldinge = db.TilmedlingTbs.Find(Id);
            if (SletTilmeldinge == null)
            {
                return HttpNotFound();
            }

            return View(SletTilmeldinge);
        }
        [HttpPost]
        public ActionResult sletTilmelding(TilmedlingTb SletTilmelding)
        {
            SletTilmelding = db.TilmedlingTbs.Find(SletTilmelding.Id);
            if (SletTilmelding == null)
            {
                return RedirectToAction("Tilmeldinger");
            }
            db.TilmedlingTbs.Remove(SletTilmelding);
            db.SaveChanges();
            return RedirectToAction("Tilmeldinger");
        }
        [ChildActionOnly]
        public ActionResult HomeEvent()
        {
            //Models.HomeViewModel MyHomeEvent = new Models.HomeViewModel();
            EventsTb MyHomeEvent = new EventsTb();
            MyHomeEvent = db.EventsTbs.FirstOrDefault();
            return PartialView("_HomeEventPartial", MyHomeEvent);

        }
        [ChildActionOnly]
        public ActionResult HomeSponsor()
        {
            SponsorerTb MyHomeSponsor = new SponsorerTb();
            MyHomeSponsor = db.SponsorerTbs.FirstOrDefault();
            //MyHomeSponsor = db.SponsorerTbs.Where(i => i.Fk_Level.Equals(2)).Take(1).FirstOrDefault();
            //MyHomeSponsor = db.SponsorerTbs.Where(i => i.Fk_Level.Equals(3)).Take(1).FirstOrDefault(); 

            return PartialView("_HomeSponsorPartial", MyHomeSponsor);

        }



        public ActionResult _NewsLetter()
        {
            NewsLetterTb news = new NewsLetterTb();

            return PartialView("_NewsLetterPartial", news);
        }

        [HttpPost]
        public ActionResult NewsLetter(NewsLetterTb news)
        {
            if (ModelState.IsValid)
            {

                db.NewsLetterTbs.Add(news);
                db.SaveChanges();

            }
            return View("Home", "Index");
        }
        public ActionResult Kontakt()
        {

            Models.MailViewModel sendbesked = new Models.MailViewModel();

            sendbesked.BestrelseListe = db.Bestyrelse_Tbs.ToList();


            //sendbesked.BestrelseMedlem = db.Bestyrelse_Tbs.FirstOrDefault();



            return View(sendbesked);
        }

        [HttpPost]
        public ActionResult Kontakt(FinalEksamen.Models.MailViewModel SendBesked)
        {
            if (ModelState.IsValid)
            {

                SendBesked.MailAdressFrom = SendBesked.MailAdressFrom;
                SendBesked.MailAdressTo = "maherhussain6@gmail.com";
                //SendBesked.MailSubject = "Fra mailformular: " + SendBesked.MailSubject;
                SendBesked.MailBody = @"Navn: " +
                                          "<b>" + SendBesked.MailName + "</b> </br>" +
                                          "</b>Emne: <b>" +
                                          SendBesked.MailSubject +
                                          "<br /></b>Besked: "
                                          + SendBesked.MailBody.Replace(Environment.NewLine, "<br />");

                SendMail(SendBesked);
                return RedirectToAction("ThankYou", "Home");
            }



            return View();
        }
        public ActionResult MedlemDe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestyrelse_Tb MedlemDe = db.Bestyrelse_Tbs.Find(id);
            if (MedlemDe == null)
            {
                return HttpNotFound();
            }

            return View(MedlemDe);
        }


        public ActionResult ThankYou()
        {
            return View();
        }
        public ActionResult NextRunPlaces()
        {
            EventsTb nextevent = db.EventsTbs.FirstOrDefault();
            return PartialView("_NextRunPlaces", nextevent);
        }
        public ActionResult SearchResult()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SearchResult(string Soegetxt)
        {
            Models.SearchViewModel Soegresultat = new Models.SearchViewModel();


            if (Soegetxt != "")
            {
                Soegresultat.Events = db.EventsTbs.Where(j => j.EventTitle.Contains(Soegetxt) || j.Region.Contains(Soegetxt) || j.Rubrik.Contains(Soegetxt) || j.UnderBrik.Contains(Soegetxt)).ToList();
                Soegresultat.Medlems = db.Bestyrelse_Tbs.Where(f => f.MedlemName.Contains(Soegetxt) || f.MedlemBeskrivelse.Contains(Soegetxt) || f.BestyrelseRole.MedlemRole.Contains(Soegetxt)).ToList();


            }
            return View(Soegresultat);

        }
        public ActionResult AdvanceretSoeg()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdvanceretSoeg(Models.SearchViewModel SoegResulta, string soegetxt, int? PrisFra, int? PrisTil, string region,string radiobtn1,string radiobtn2)
        {
            if (soegetxt != "")
            {


                SoegResulta.Events = db.EventsTbs.Where(i => i.EventTitle.Contains(soegetxt) && i.Pris >= PrisFra && i.Pris <= PrisTil && i.Region == region).ToList();




            }
            else if (PrisFra >= 0 && PrisTil < 100000000)
            {
                SoegResulta.Events = db.EventsTbs.Where(p => p.Pris >= PrisFra && p.Pris <= PrisTil && p.Region == region).ToList();

            }

            else if (region != "")
            {
                SoegResulta.Events = db.EventsTbs.Where(p => p.Region == region).ToList();

            }
           







            return View(SoegResulta);
        }
        public void SendMail(FinalEksamen.Models.MailViewModel myMail)
        {
            // En istans af .NET klassen mailmessage
            // starter  på en ny mail. Husk using i toppen af controllen (.net.mail)
            //using er et  namespace eller bibliotek som kan tikoblis
            MailMessage mail = new MailMessage();

            // from er = mailens afsender 
            // det er ikke mailens afsender, når vi bruger gmail som smtp, relevant information fra webhost
            mail.From = new MailAddress(myMail.MailAdressFrom);

            // dette er den mail som man besvarer til (det er inputfelttet"MailForm")
            mail.ReplyToList.Add(myMail.MailAdressFrom);

            // subject er emnefelttet på en mail_ dette er et vigtigt felt, men ikke et krav
            //mail.Subject = myMail.MailSubject;

            // body er selve beskeden- kommer fra brugeren selv via textarea-felttet
            // da vi har valgt at sende HTML, kan vi erstatte NewLine(enviroment) med <br/>-tag
            mail.Body = myMail.MailBody;
            mail.IsBodyHtml = true;

            //mail .to er den emailadresse som modtager mail fra formularen
            // statisk i formularen (os selv)
            // dynamisk i newsletter (MailForm)

            mail.To.Add(myMail.MailAdressTo);



            // "smtp" er en instans af  SmtpClient
            SmtpClient smtp = new SmtpClient();


            // Host er web´host udgående mail server
            // i dette tilfælde bruger vi gmails-stmp
            //tjek med udbyder (eks.smtp .unoeuro.com)
            smtp.Host = "smtp.gmail.com";

            // tjek med webhost hvilken port du må/skal bruge
            smtp.Port = 587;

            // Ssl er nødvendigt når vi bruger gmail
            //tjek evt.med webhost
            smtp.EnableSsl = true;


            //Her slå vi standard logino-plysningerne fra 
            smtp.UseDefaultCredentials = false;

            // Her taster vi vores login-oplyninger til gmailen.
            smtp.Credentials = new System.Net.NetworkCredential("maher.h.webud@gmail.com", "maher1988");


            // Her pakke vi hele instansen "mail" ned som parameter til metod "send"
            //inkl. alle værdier og data vi har tastet ovenover
            smtp.Send(mail);

        }

    }
}