using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AutoPiWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class AutoPiService : IAutoPiService
    {
        List<Person> personList = new List<Person>();

        public AutoPiService()
        {
            for (int i = 0; i < 15; i++)
            {
                var person = new Person(i);
                personList.Add(person);
            }
        }

        public Dictionary<int, bool> GetLights()
        {
             Dictionary<int,bool> dict = new Dictionary<int, bool>();

            dict.Add(1, true);
            dict.Add(15, false);

            return dict;
        }

        public KeyValuePair<int, bool> GetLightById(string id)
        {
            throw new NotImplementedException();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "data/{id}")]
        public Person GetData(string id)
        {
            int ID;

            try
            {
                ID = Convert.ToInt32(id);

                return personList.FirstOrDefault(a => a.Id == ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public Address address { get; set; }

        public Person()
        {
            
        }

        public Person(int id)
            :this(id, "First"+id, "Last"+id)
        {
            
        }

        public Person(int id, string first, string last)
        {
            Id = id;
            fName = first;
            lName = last;
            this.address = new Address(id.ToString());
;
        }
    }

    public class Address
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Address()
        {
            
        }

        public Address(string id)
            : this("Street1"+id, "Street2"+id, "City"+id, "State"+id, "Zip"+id)
        {

        }

        public Address(string s1, string s2, string c, string s, string z)
        {
            Street1 = s1;
            Street2 = s2;
            City = c;
            State = s;
            ZipCode = z;
        }
    }
}
