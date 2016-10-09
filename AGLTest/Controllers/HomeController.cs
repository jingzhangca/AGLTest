using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AGLTest.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			IService<Owner, Pet> service = new JsonService(); 
			var owners = service.GetOwners().Result;
			var petsWithMaleOwner =  service.GetPetsByOwnerGender(owners,"Male");
			var petsWithFemaleOwner = service.GetPetsByOwnerGender(owners, "Female");
			//Sort cats out and order by its name
			ViewData["CatsWithMaleOwner"] = petsWithMaleOwner.Where(x => x.Type == "Cat").OrderBy(x => x.Name).ToList();
			ViewData["CatsWithFemaleOwner"] = petsWithFemaleOwner.Where(x => x.Type == "Cat").OrderBy(x => x.Name).ToList();

			return View();

		}




	}
}
