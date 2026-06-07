using System.Collections.Generic;

namespace Gh.Tk
{
	public static class FeedbackCategory
	{
		public const string Atmosphere = "atmosphere";

		public const string Decor = "decor";

		public const string Accommodation = "accommodation";

		public const string Drink = "drink";

		public const string Facilities = "facilities";

		public const string Food = "food";

		public const string Satisfaction = "satisfaction";

		public const string Service = "service";

		public const string Shop = "shop";

		public static IEnumerable<string> GetOrderedFeedbackCategories()
		{
			return null;
		}

		public static string GetDisplayName(string category)
		{
			return null;
		}

		public static string GetDisplayNameKey(string category)
		{
			return null;
		}
	}
}
