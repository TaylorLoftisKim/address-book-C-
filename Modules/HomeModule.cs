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
        var contactAddresses = selectedContact.GetAddresses();
        model.Add("contact", selectedContact);
        model.Add("Addresses", contactAddresses);
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
      Get["/contact/{id}/addresses/new"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactAddresses = selectedContact.GetAddresses();
        model.Add("contact", selectedContact);
        model.Add("Addresses", contactAddresses);
        return View["address-new-form.cshtml", model];
      };
      Post["/addresses"] = _ =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(Request.Form["artist-id"]);
        List<Address> contactAddresses = selectedContact.GetAddresses();
        Address newAddress = new Address(Request.Form["address-name"]);
        contactAddresses.Add(newAddress);
        model.Add("Addresses", contactAddresses);
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
