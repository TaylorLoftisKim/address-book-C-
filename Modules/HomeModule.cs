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
        return View["view-all-contact.cshtml", allContacts]
      };
      Post["/view-all-address"] = _ =>
      {
        Address newAddress = new Address(Request.Form["name"]);
        var allAddressMulti = Address.GetAllAddress();
        return View["view-all-address", allAddressMulti];
      };
      Post["/view-all-contact"] = _ =>
      {
        Contact newContact = new Contact(Request.Form["contact"]);
        var allContacts = Contacts.GetAll();
        return View["view-all-contact.cshtml", allContacts]
      };
      Post["/addressMulti"] = _ =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(Request.Form["artist-id"]);
        List<Address> contactAddressMulti = selectedContact.GetAddressMulti();
        Address newAddress = new Address(Request.Form["address-name"]);
        contactAddressMulti.Add(newAddress);
        model.Add("AddressMulti", contactAddressMulti);
        model.Add("contact", selectedContact);
        return View["view"]
      }
    }
  }
}
