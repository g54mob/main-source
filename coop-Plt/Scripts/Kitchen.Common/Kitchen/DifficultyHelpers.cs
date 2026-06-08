using UnityEngine;

namespace Kitchen
{
	public static class DifficultyHelpers
	{
		public static float CustomerChangePerPoint => 15f;

		public static int TotalShopCount(int day)
		{
			return 5;
		}

		public static int StapleCount(int day)
		{
			return Mathf.Clamp(4 - Mathf.FloorToInt((float)day / 5f), 2, 4);
		}

		public static float BaseUpgradedShopChance(int day)
		{
			return (float)Mathf.FloorToInt((float)day / 5f) * 0.1f;
		}

		public static int IncreasedRerollCost(int cost)
		{
			return cost + 10;
		}

		public static float CustomerModifierRateModifier(float modifier)
		{
			return Mathf.Pow(1f - CustomerChangePerPoint / 100f, modifier);
		}

		public static float MoneyRewardPlayerModifier(int player_count)
		{
			return player_count switch
			{
				0 => 1f, 
				1 => 1f / CustomerPlayersRateModifier(1), 
				2 => 1.1f, 
				3 => 1f, 
				_ => 1f, 
			};
		}

		public static float PatiencePlayerCountModifier(int player_count)
		{
			return player_count switch
			{
				0 => 0.5f, 
				1 => 0.65f, 
				2 => 1f, 
				3 => 1.1f, 
				_ => 1.15f, 
			};
		}

		public static float FireSpreadModifier(int player_count)
		{
			return player_count switch
			{
				0 => 0.5f, 
				1 => 0.75f, 
				2 => 1f, 
				3 => 1.2f, 
				_ => 1.5f, 
			};
		}

		public static float CustomerPlayersRateModifier(int player_count)
		{
			return player_count switch
			{
				0 => 1f, 
				1 => 0.8f, 
				2 => 1f, 
				3 => 1.25f, 
				_ => 1.5f, 
			};
		}
	}
}
