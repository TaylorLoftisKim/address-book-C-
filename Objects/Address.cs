using System;
using System.Collections.Generic;

namespace Contacts.Objects
{
  public class Contact
  {
    private string _name;
    private string _phoneNumber;
    private string _userAddress;
    private int _id;
    private static List<Contact> _instances = new List<Contact>{};

    public Contact(string name, string phoneNumber, string userAddress)
    {
      _name = name;
      _phoneNumber = phoneNumber;
      _userAddress = userAddress;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }

    public string GetUserAddress()
    {
      return _userAddress;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Contact> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Contact Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}
