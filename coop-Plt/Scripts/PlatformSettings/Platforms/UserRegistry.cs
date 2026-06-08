using System.Collections.Generic;

namespace Platforms
{
	public class UserRegistry<T> where T : IUserDetails
	{
		private static int LastAssignedID = 1;

		protected Dictionary<PlatformUser, T> Registry = new Dictionary<PlatformUser, T>();

		public PlatformUser Find(T details)
		{
			if (TryGetUser(details, out var user))
			{
				return user;
			}
			PlatformUser platformUser = new PlatformUser(LastAssignedID++);
			Registry.Add(platformUser, details);
			return platformUser;
		}

		public bool GetDetails(PlatformUser user, out T details)
		{
			return Registry.TryGetValue(user, out details);
		}

		public bool TryGetUser(T details, out PlatformUser user)
		{
			user = default(PlatformUser);
			foreach (KeyValuePair<PlatformUser, T> item in Registry)
			{
				if (item.Value.IsEquivalent(details))
				{
					user = item.Key;
					return true;
				}
			}
			return false;
		}

		public IEnumerable<T> Users()
		{
			return Registry.Values;
		}
	}
}
