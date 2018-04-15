using SiparisTakip.Bll.KullanciBll;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;
using SiparisTakip.Entity.Models;
using SiparisTakip.Interfaces.Kullanici;
using System.Web.Mvc;

namespace SiparisTakip.AspNetMvcUI.Controllers
{
    public class KullaniciController : Controller
    {

        IKullaniciService _kullaniciService = new KullaniciManager(new EfKullaniciRepository());


        [HttpGet]
        public ActionResult KullaniciGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciGiris(Kullanici kullanici)
        {
            try
            {
                var _kullanici=_kullaniciService.KullaniciGiris(kullanici.KullaniciKodu, kullanici.Parola);
                if(_kullanici!=null)
                {
                    Session["KullaniciId"] = _kullanici.KullaniciID;
                    Session["KullaniciAdi"] = _kullanici.KullaniciAdi + " " + _kullanici.KullaniciSoyadi;

                    return RedirectToAction("Index", "Anasayfa");
                }
                else
                {

                }
            }
            catch (System.Exception error)
            {
                //return RedirectToAction();
            }

            return new JsonResult();
        }
    }
}