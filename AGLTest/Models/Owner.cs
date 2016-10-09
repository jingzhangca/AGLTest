using System;
using System.Collections.Generic;

namespace AGLTest
{
	public class Owner
	{
		public Owner()
		{
		}

		public string Name { get; set; }

		public string Gender { get; set; }

		public int Age { get; set; }

		public List<Pet> Pets { get; set; }
	}
}
