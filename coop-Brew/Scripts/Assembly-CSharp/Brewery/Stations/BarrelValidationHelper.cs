using Brewery.Items;

namespace Brewery.Stations
{
	public static class BarrelValidationHelper
	{
		public static bool IsEmptyBarrel(BarrelMetadata metadata)
		{
			return false;
		}

		public static bool IsUnfermentedWine(BarrelMetadata metadata)
		{
			return false;
		}

		public static bool IsFermentingBeer(BarrelMetadata metadata)
		{
			return false;
		}

		public static bool IsAgingWine(BarrelMetadata metadata)
		{
			return false;
		}

		public static bool IsReadySpirits(BarrelMetadata metadata)
		{
			return false;
		}

		public static string GetBarrelDescription(BarrelMetadata metadata)
		{
			return null;
		}
	}
}
