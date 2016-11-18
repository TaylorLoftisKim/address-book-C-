using System.Collections.Generic;

namespace ContactList.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _contactName;
    private int _id;
    private List<Address> _addresses;
    private static List<Contact> _matches = new List<Contact> {};

    public Contact(string contactName)
    {
      _contactName = contactName;
      _instances.Add(this);
      _id = _instances.Count;
      _addresses = new List<Address>{};
    }
    public string GetContactName()
    {
      return _contactName;
    }
    public int GetId()
    {
      return _id;
    }
    public List<Address> GetAddresses()
    {
      return _addresses;
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public static List<Contact> FilteredContacts(string searchName)
    {
      foreach(Contact i in _instances)
      {
        if(i._contactName == searchName)
        {
          _matches.Add(i);
        }
      }
      return _matches;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
  }
}
