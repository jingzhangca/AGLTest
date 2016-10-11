using System;
using NUnit.Framework;
using AGLTest;

namespace AGLTest.Tests
{
	[TestFixture]
	public class JsonServiceTest
	{
		 //Arrange
		IService<Owner,Pet> service = new JsonService();

		[Test]
		public void GetOwnersTest()
		{
			// Act
			var result = service.GetOwners().Result;

			// Assert
			Assert.AreNotEqual(result, null);
		}

		[Test]
		public void GetPetsByOwnerGenderTest()
		{ 
			//Act
			var owners = service.GetOwners().Result;
			var petsWithMaleOwner = service.GetPetsByOwnerGender(owners, "Male");
			var petsWithFemaleOwner = service.GetPetsByOwnerGender(owners, "Female");

			//Assert
			Assert.AreNotEqual(petsWithMaleOwner, null);
			Assert.AreNotEqual(petsWithFemaleOwner, null);
		}
	}
}

