using System.Collections.Generic;

namespace ContactList.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _contactName;
    private int _id;
    private List<Address> _addressMulti>
    private static List<Contact> _matches = new List<Contact> {};

    public Artist(string contactName)
    {
      _contactName = contactName;
      _instances.Add(this);
      _id = _instances.Count;
      _address = new List<Address>{};
    }
    public string GetContactName()
    {
      return _contactName;
    }
    public int GetId()
    {
      return _id;
    }
    public List<Address> GetAddressMulti()
    {
      return _addressMulti;
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public static List<Contact> FilteredArtist(string searchName)
    {
      foreach(Artist i in _instances)
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
