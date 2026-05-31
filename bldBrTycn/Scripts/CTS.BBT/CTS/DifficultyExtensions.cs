using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public static class DifficultyExtensions
	{
		public static StringKey StartingMoneyKey { get; } = "Diff_StartingMoney";

		public static StringKey RaidKey { get; } = "Diff_Raid";

		public static StringKey DrinkKey { get; } = "Diff_Drink";

		public static StringKey MaeveBaseKey { get; } = "Diff_MaeveBase";

		public static StringKey MaeveMultiplierKey { get; } = "Diff_MaeveMultiplier";

		public static StringKey ReviewImpact { get; } = "Diff_ReviewImpact";

		public static void SetStartingMoneyWithDifficulty(this MoneyHandler handler, int defaultAmount)
		{
			handler.SetCurrentMoney(defaultAmount + Mathf.RoundToInt(Difficulty.GetAdditiveDifficulty(StartingMoneyKey)));
		}

		public static int GetMaxVigilanceWithDifficulty(this VigilanceHandlers handler)
		{
			return handler.VigilanceData.VigilanceForRaid + Mathf.RoundToInt(Difficulty.GetAdditiveDifficulty(RaidKey));
		}

		public static float GetCurrentVigilancePercentageWithDifficulty(this VigilanceHandlers handler)
		{
			return FloatExtensions.Remap(handler.CurrentVigilance, 0f, handler.VigilanceData.VigilanceForRaid, 0f, handler.GetMaxVigilanceWithDifficulty());
		}

		public static void SetVigilanceFromUnitIntervalWithDifficulty(this VigilanceHandlers handler, float unitInterval)
		{
			handler.SetVigilanceTo(Mathf.RoundToInt(unitInterval * (float)handler.GetMaxVigilanceWithDifficulty()));
		}

		public static int GetCurrentPriceWithDifficulty(this DrinkSO drink)
		{
			return Mathf.RoundToInt((float)drink.GetCurrentPrice() * Difficulty.GetMultiplicativeDifficulty(DrinkKey));
		}

		public static int GetStartingMoneyWithDifficulty(this CustomerParameters data)
		{
			return Mathf.CeilToInt((float)data.StartMoney.RandomInRangeInclusive() * Difficulty.GetMultiplicativeDifficulty(DrinkKey));
		}

		public static int GetPriceWithDifficulty(this ExterminationDataSO extermination, int current)
		{
			float num = (float)extermination.GetBasePrice() + Difficulty.GetAdditiveDifficulty(MaeveBaseKey);
			float num2 = extermination.GetPriceMultiplier() * Difficulty.GetMultiplicativeDifficulty(MaeveMultiplierKey);
			if (extermination.IsModifierAdditive())
			{
				num += num * num2 * (float)current;
			}
			else
			{
				for (int i = 0; i < current; i++)
				{
					num *= num2;
				}
			}
			return Mathf.FloorToInt(num * MonoSingleton<MaeveExtermination>.Instance.DiscountMultiplier);
		}

		public static int GetScoreFromSatisfactionWithDifficulty(this CustomerReviewData customerReview, float unitIntervalSatisfaction, bool Vampire = false)
		{
			return Mathf.RoundToInt((float)customerReview.GetScoreFromSatisfaction(unitIntervalSatisfaction, Vampire) * Difficulty.GetMultiplicativeDifficulty(ReviewImpact));
		}
	}
}
