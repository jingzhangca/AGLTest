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
			var owners = service.GetOwners().Result;

			// Assert
			// Assert owners are not null
			Assert.AreNotEqual(owners, null);
			// Assert the number of owners is correct
			Assert.AreEqual(owners.Count,6);
		}

		[Test]
		public void GetPetsByOwnerGenderTest()
		{ 
			//Act
			var owners = service.GetOwners().Result;
			var petsWithMaleOwner = service.GetPetsByOwnerGender(owners, "Male");
			var petsWithFemaleOwner = service.GetPetsByOwnerGender(owners, "Female");

			//Assert

			//Assert pets are not null
			Assert.AreNotEqual(petsWithMaleOwner, null);
			Assert.AreNotEqual(petsWithFemaleOwner, null);

			//Assert pets' count is correct
			Assert.AreEqual(petsWithMaleOwner.Count, 6);
			Assert.AreEqual(petsWithFemaleOwner.Count, 4);
		}
	}
}

