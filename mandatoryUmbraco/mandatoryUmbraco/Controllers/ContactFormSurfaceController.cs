using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using mandatoryUmbraco.ViewModels;
using System.Net.Mail;

namespace mandatoryUmbraco.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface

        public ActionResult Index()
        {
            return PartialView("contactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {


            IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Message");

            comment.SetValue("cName", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);

            //Save
            Services.ContentService.Save(comment);

            return RedirectToCurrentUmbracoPage();
        }
    }
}