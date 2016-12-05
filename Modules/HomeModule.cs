using Nancy;
using System.Collections.Generic;
using Contacts.Objects;

namespace Contacts
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>{
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contact-add"] = _ =>{
        return View["contact-add.cshtml"];
      };
      Get["/{id}"] = parameters =>{
        Contact contact = Contact.Find(parameters.id);
        return View["/view-all-contact.cshtml", contact];
      };
      Post["/contact/contact-new"] = _ =>{
        Contact newContact = new Contact(Request.Form["new-name"], Request.Form["new-number"], Request.Form["new-address"]);
        return View["contact-new.cshtml", newContact];
      };
      Post["/contacts/contact-cleared"] = _ =>{
        Contact.ClearAll();
        return View["contact-cleared.cshtml"];
      };
    }
  }
