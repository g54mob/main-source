using Brewery.Core;
using Brewery.Employee.AI;

namespace Brewery.Employee
{
	public static class BreweryEmployeeUpgradeConfig
	{
		public const int MaxLevel = 10;

		public const float SpeedReductionPerLevel = 0.075f;

		public const int BonusBottlesPerLevel = 1;

		public const float SalaryIncreasePerUpgrade = 10f;

		public const float BaseUpgradeCost = 100f;

		public const float UpgradeCostMultiplier = 1.5f;

		public const int BonusBottlesPerOptionalInput = 2;

		public static float GetUpgradeCost(int currentLevel)
		{
			return 0f;
		}

		public static float GetSpeedMultiplier(int level)
		{
			return 0f;
		}

		public static int GetBonusBottles(int level)
		{
			return 0;
		}

		public static bool CanWorkStation(BreweryEmployeeSlot slot, StationRole role)
		{
			return false;
		}

		public static bool CanBottleBeverage(BreweryEmployeeSlot slot, BeverageType beverageType)
		{
			return false;
		}

		public static int GetRelevantLevel(BreweryEmployeeSlot slot, StationRole role)
		{
			return 0;
		}
	}
}
