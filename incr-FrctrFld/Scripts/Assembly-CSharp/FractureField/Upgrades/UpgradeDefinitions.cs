using System.Collections.Generic;

namespace FractureField.Upgrades
{
	public static class UpgradeDefinitions
	{
		public static class Categories
		{
			public const string Player = "Player";

			public const string Quarry = "Quarry";

			public const string RockLayers = "RockLayers";

			public const string Tools = "Tools";

			public const string Drones = "Drones";

			public const string Bombs = "Bombs";

			public const string WorldFracture = "WorldFracture";

			public const string QuarryForeman = "QuarryForeman";

			public const string RealityShatter = "RealityShatter";
		}

		private static Dictionary<string, UpgradeDefinition> _all;

		public static Dictionary<string, UpgradeDefinition> All => null;

		public static UpgradeDefinition Get(string id)
		{
			return null;
		}

		private static void InitializeDefinitions()
		{
		}

		private static float GetIncrementAtLevel(int level, float basePerLevel, float incrementValue, int incrementInterval)
		{
			return 0f;
		}

		private static float GetTotalIncrementValueAtLevel(int level, float basePerLevel, float incrementValue, int incrementInterval)
		{
			return 0f;
		}

		private static void InitializePlayerStatUpgrades()
		{
		}

		private static void InitializeRockLayerUpgrades()
		{
		}

		private static void InitializeDroneUpgrades()
		{
		}

		private static void InitializeBombUpgrades()
		{
		}

		private static void InitializeWorldFractureUpgrades()
		{
		}

		private static void InitializeQuarryForemanUpgrades()
		{
		}

		private static void InitializeRealityShatterUpgrades()
		{
		}

		private static void InitializeRealityShatterPlayerUpgrades()
		{
		}

		private static void InitializeRealityShatterQuarryUpgrades()
		{
		}

		private static void InitializeRealityShatterRockLayerUpgrades()
		{
		}

		private static void InitializeRealityShatterDroneUpgrades()
		{
		}

		private static void InitializeRealityShatterBombUpgrades()
		{
		}

		private static void InitializeRealityShatterMetaUpgrades()
		{
		}

		private static void AddDefinition(UpgradeDefinition definition)
		{
		}
	}
}
