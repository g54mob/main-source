using System.Collections.Generic;

namespace Gh.Tk
{
	public static class RoomZones
	{
		public const string Blacksmith = "blacksmith";

		public const string Counselling = "counselling";

		public const string Dorm = "dorm";

		public const string Hallway = "hallway";

		public const string Kitchen = "kitchen";

		public const string Larder = "larder";

		public const string Laundry = "laundry";

		public const string Staffroom = "staffroom";

		public const string Taproom = "taproom";

		public const string FrontOffice = "frontoffice";

		public const string Toilet = "toilet";

		public const string Unzoned = "unzoned";

		public const string Shop = "shop";

		public const string PrivateRoom = "privateroom";

		public static readonly string[] PrivateZones;

		public static readonly string[] StaffZones;

		public static readonly string[] AllZones;

		public static readonly Dictionary<float, string[]> StarZones;

		public static string[] GetAllZoneIds()
		{
			return null;
		}

		public static string GetDisplayNameKey(string zone)
		{
			return null;
		}
	}
}
