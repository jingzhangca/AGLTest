using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.Configuration;

namespace AGLTest
{
	public class JsonService:IService<Owner,Pet>
	{
		public JsonService()
		{
		}

		/// <summary>
		/// Gets owners from Json Webservice.
		/// </summary>
		/// <returns>The owners.</returns>
		public async Task<List<Owner>> GetOwners()
		{
			//Get service url from configuration file.
			string url = ConfigurationManager.AppSettings["jsonServiceUrl"];

			using (var client = new HttpClient())
			{
				var result = await client.GetStringAsync(url);

				return JsonConvert.DeserializeObject<List<Owner>>(result);
			}
		}

		/// <summary>
		/// Get cats by owner's gender and order by name.
		/// </summary>
		/// <param name="owners">Owners.</param>
		public List<Pet> GetPetsByOwnerGender(List<Owner> owners, string ownerGender)
		{
			List <Pet> pets = new List<Pet>();
			//Group pets by owner gender
			foreach (var owner in owners)
			{
				if (owner.Pets != null)
				{
					if (owner.Gender == ownerGender)
					{
						pets= pets.Concat(owner.Pets).ToList();

					}
				}
			}
			return pets;
		}

	}
}
