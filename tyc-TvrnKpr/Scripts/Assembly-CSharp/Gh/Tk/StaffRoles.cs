using System.Collections.Generic;

namespace Gh.Tk
{
	public static class StaffRoles
	{
		public const string ROLE_PREFIX = "role:";

		public const string OffWork = "OffWork";

		public const string Generalist = "Generalist";

		public const string Server = "Server";

		public const string Chef = "Chef";

		public const string Janitor = "Janitor";

		public const string Dogsbody = "Dogsbody";

		public static string[] AllRoles;

		public static string GetDisplayNameKey(string role)
		{
			return null;
		}

		public static IEnumerable<string> GetAllUnlockedRoles()
		{
			return null;
		}

		public static IEnumerable<string> GetAssignableRoles()
		{
			return null;
		}
	}
}
