using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace AGLTest
{
	class MainClass
	{
		public static List<Pet> catsWithMaleOwner=new List<Pet>();
		public static List<Pet> catsWithFemaleOwner = new List<Pet>();

		public static void Main(string[] args)
		{
			var owners = GetOwners().Result;

			GetCatsByOwnerGender(owners);

			Console.WriteLine("Male");
			Console.WriteLine("\n");
			foreach (var cat in catsWithMaleOwner)
			{
				Console.WriteLine(cat.Name);
			}

			Console.WriteLine("-----------------");
			Console.WriteLine("Female");
			Console.WriteLine("\n");
			foreach (var cat in catsWithFemaleOwner)
			{
				Console.WriteLine(cat.Name);
			}
				
		}

		/// <summary>
		/// Get cats by owner's gender and order by name.
		/// </summary>
		/// <param name="owners">Owners.</param>
		public static void GetCatsByOwnerGender(List<Owner> owners)
		{
			List<Pet> petsWithMaleOwner = new List<Pet>();
			List<Pet> petsWithFemaleOwner = new List<Pet>();

			//Group pets by owner gender
			foreach (var owner in owners)
			{
				if (owner.Pets != null)
				{
					if (owner.Gender == "Male")
						petsWithMaleOwner = petsWithMaleOwner.Concat(owner.Pets).ToList();
					else
						petsWithFemaleOwner = petsWithFemaleOwner.Concat(owner.Pets).ToList();
				}
			}

			//Sort cats out and order by its name
			catsWithMaleOwner = petsWithMaleOwner.Where(x => x.Type == "Cat").OrderBy(x => x.Name).ToList();
			catsWithFemaleOwner = petsWithFemaleOwner.Where(x => x.Type == "Cat").OrderBy(x => x.Name).ToList();
		}

		/// <summary>
		/// Gets owners from Json Webservice.
		/// </summary>
		/// <returns>The owners.</returns>
		public static async Task<List<Owner>> GetOwners()
		{
			string url = @"http://agl-developer-test.azurewebsites.net/people.json";

			using (var client = new HttpClient())
			{
				var result = await client.GetStringAsync(url);

				return JsonConvert.DeserializeObject<List<Owner>>(result);
			}
		}
	}
}
