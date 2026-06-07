using System;

namespace VoxelBusters.CoreLibrary
{
	public class User
	{
		public enum UserGender
		{
			Undefined = 0,
			Male = 1,
			Female = 2,
			Others = 3
		}

		public string UserId { get; private set; }

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public UserGender Gender { get; private set; }

		public DateTime? DateOfBirth { get; private set; }

		public int? Age => null;

		public bool IsGuest { get; private set; }

		public User(string userId, string email = null, string firstName = null, string lastName = null, UserGender gender = UserGender.Undefined, DateTime? dob = null, bool isGuest = false)
		{
		}
	}
}
