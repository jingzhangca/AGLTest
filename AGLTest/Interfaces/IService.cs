using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AGLTest
{
	public interface IService<T,P>
	{
		Task<List<T>> GetOwners();

		List<P> GetPetsByOwnerGender(List<T> owners, string ownerGender);
	}
}
