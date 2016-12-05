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
      Get["/add-contact"] = _ =>{
        return View["add_contact.cshtml"];
      };
      Get["/{id}"] = parameters =>{
        Contact contact = Contact.Find(parameters.id);
        return View["/contact.cshtml", contact];
      };
      Post["/contact/contact-new-form"] = _ =>{
        Contact newContact = new Contact(Request.Form["new-name"], Request.Form["new-number"], Request.Form["new-address"]);
        return View["new_contact.cshtml", newContact];
      };
      Post["/contacts/contact-cleared"] = _ =>{
        Contact.ClearAll();
        return View["contact-cleared.cshtml"];
      };
    }
  }
