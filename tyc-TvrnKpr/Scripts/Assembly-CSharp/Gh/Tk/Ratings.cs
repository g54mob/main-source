using System.Text;

namespace Gh.Tk
{
	public static class Ratings
	{
		private static int RatePriceBasedOnRange(int price, int okPrice, int minPrice, int maxPrice, StringBuilder details = null, bool clampValues = true)
		{
			return 0;
		}

		public static int RatePrice(Patron patron, IPatronRatable ratable, StringBuilder details = null)
		{
			return 0;
		}

		public static int RatePrice(string race, int tier, IPatronRatable ratable, StringBuilder details = null, bool clampValues = true)
		{
			return 0;
		}

		public static int RateQuality(string race, int tier, IPatronRatable ratable, string rateDescription, string rateDescriptionCapitalized, StringBuilder details = null)
		{
			return 0;
		}
	}
}
