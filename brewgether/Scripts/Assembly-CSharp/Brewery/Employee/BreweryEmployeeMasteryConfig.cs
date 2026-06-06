using Brewery.Core;
using Brewery.Employee.AI;

namespace Brewery.Employee
{
	public static class BreweryEmployeeMasteryConfig
	{
		public static BreweryMasterySettingsSO Settings { get; set; }

		public static int MaxMasteryLevel => 0;

		public static int MaxPerks => 0;

		public static float MasterySpeedBonusPerLevel => 0f;

		public static float MasteryEfficiencyBonusPerLevel => 0f;

		public static float SpecializationXpMultiplier => 0f;

		public static int GetXPForLevel(int level)
		{
			return 0;
		}

		public static int GetMasteryLevel(int totalXP)
		{
			return 0;
		}

		public static string GetMasteryTitle(int level)
		{
			return null;
		}

		public static int GetUnlockedPerkSlots(int masteryLevel)
		{
			return 0;
		}

		public static int CountPerks(byte perks)
		{
			return 0;
		}

		public static bool HasPerk(byte perks, EmployeePerk perk)
		{
			return false;
		}

		public static int GetTaskXP(BreweryTaskType taskType, BeverageType taskBeverage, BeverageType specialization)
		{
			return 0;
		}

		public static float GetMasterySpeedMultiplier(byte level, byte perks)
		{
			return 0f;
		}

		public static float GetMasteryEfficiencyMultiplier(byte level, byte perks)
		{
			return 0f;
		}

		public static int GetPerkBonusBottles(byte perks)
		{
			return 0;
		}

		public static int GetPerkUnlockLevel(int slotIndex)
		{
			return 0;
		}

		public static int GetNightOwlExtraHours()
		{
			return 0;
		}

		public static int GetLoyalWorkerExtraGraceDays()
		{
			return 0;
		}

		public static string GetPerkDisplayName(EmployeePerk perk)
		{
			return null;
		}

		public static string GetPerkDescription(EmployeePerk perk)
		{
			return null;
		}

		private static int GetPerkBitIndex(EmployeePerk perk)
		{
			return 0;
		}

		private static object GetPerkNumericValue(EmployeePerk perk)
		{
			return null;
		}

		private static string GetPerkDescriptionFallback(EmployeePerk perk)
		{
			return null;
		}
	}
}
