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
        var selectedContact
      }
    }
  }
}
