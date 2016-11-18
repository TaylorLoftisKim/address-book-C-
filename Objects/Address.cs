using System.Collections.Generic;

namespace ContactList.Objects
{
  public class Address
  {
    private string _name;
    private int _id;
    private static List<Address> _instances = new List<Address> {};

    public Address (string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }
    public static List<Address> GetAllAddress()
    {
      return _instances;
    }
    public static AddressMulti Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
