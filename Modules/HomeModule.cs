using Nancy;
using System.Collections.Generic;
using ContactList.Objects;

namespace ContactList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/address/new"] = _ => View["address-new-form.cshtml"];
      Get["/contact/new"] = _ => Voew["contact-new-form.cshtml"];
      Get["/contacts/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactAddress = selectedContact,GetAddressMulti();
        model.Add("artist", selectedContact);
        model.Add("address", contactAddressMulti);
        return View["view-all-cd.cshtml", model];
      };
      Get["/view-all-contacts"] = _ =>
      {
        var allContacts = Contacts.GetAll();
        return View["view-all-contact.cshtml"]
      }
    }
  }
}
