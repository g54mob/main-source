using System.Collections.Generic;
using System.Text;

namespace Gh.Tk
{
	public interface IPatronRatable
	{
		static int RatingPercentageThreshold;

		string FullNameKey { get; }

		int Stars { get; }

		string Category { get; }

		int GetPrice();

		(int, string) GetOkPrice(string race, int tier, bool generateReason);

		float GetEffectiveQuality(string race, int tier, StringBuilder details = null);

		float GetExpectedQuality(string race, int tier);

		int GetTier();

		static IEnumerable<IPatronRatable> GetPatronRatablesForCategory(string category)
		{
			return null;
		}

		static bool WouldPatronChoose(string race, int tier, IPatronRatable template, List<IPatronRatable> otherItems)
		{
			return false;
		}

		static IPatronRatable()
		{
		}
	}
}
