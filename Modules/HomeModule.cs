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
      Get["/contact/new"] = _ => View["contact-new-form.cshtml"];
      Get["/address/new"] = _ => View["address-new-form.cshtml"];
      Get["/contacts/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactAddressMulti = selectedContact.GetAddressMulti();
        model.Add("artist", selectedContact);
        model.Add("AddressMulti", contactAddressMulti);
        return View["view-contact.cshtml", model];
      };
      Get["/view-all-contact"] = _ =>
      {
        var allContacts = Contact.GetAll();
        return View["view-all-contact.cshtml", allContacts];
      };
      Post["/view-all-contact"] = _ =>
      {
        Contact newContact = new Contact(Request.Form["contact-name"]);
        var allContacts = Contact.GetAll();
        return View["view-all-contact.cshtml", allContacts];
      };
      Post["/view-all-address"] = _ =>
      {
        Address newAddress = new Address(Request.Form["name"]);
        var allAddressMulti = Address.GetAllAddress();
        return View["view-all-address", allAddressMulti];
      };
      Get["/contact/{id}/addressMulti/new"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactAddressMulti = selectedContact.GetAddressMulti();
        model.Add("contact", selectedContact);
        model.Add("AddressMulti", contactAddressMulti);
        return View["address-new-form.cshtml", model];
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
        return View["view"];
      };
      Post["/searchContact"] = _ =>
      {
        var searchInput = Request.Form["searchName"];
        List<Contact> matchedContacts = Contact.FilteredContacts(searchInput);
        return View["view-all-contact", matchedContacts];
      };
    }
  }
}
