using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_Rewriting
{
    public class Control : IPublisher
    {
		private List<ISubscriber> subscriber = new List<ISubscriber>();

        DBControl DBC = new DBControl();
        public void InsertPet(string name, string type, string breed, string dob, string weight, string ownerId)
        {
            Pet pet = new Pet { Name = name, Type = type, Breed = breed, DOB = dob, Weight = weight, OwnerId = ownerId };
            DBC.InsertPet(pet);
			NotifySubscribers(name);
        }

        public void InsertOwner(string firstName, string lastName, string phone, string email)
        {
           Owner own = new Owner { FirstName = firstName, LastName = lastName, Phone = phone, Email = email };
           DBC.InsertOwner(own);
        }

        public List<Pet> ShowPets()
        {
            return DBC.ShowPets();
        }

        public Owner FindOwnerByLastName(string lastName)
        {
            return DBC.FindOwnerByLastName(lastName);
        }

        public Owner FindOwnerByEmail(string email, string name)
        {
            return DBC.FindOwnerByEmail(email, name);
        }

		public void DeletePet(string name, int ownerid)
		{
			DBC.DeletePet(name, ownerid);
			NotifySubscribers(name);
		}

		public void RegisterSubscriber(ISubscriber observer)
		{
			subscriber.Add(observer);
		}

		public void RemoveSubscriber(ISubscriber observer)
		{
			subscriber.Remove(observer);
		}

		public void NotifySubscribers(string message)
		{
			foreach(ISubscriber sub in subscriber)
			{
				sub.Update(this, message);
			}
		}
	}
}
