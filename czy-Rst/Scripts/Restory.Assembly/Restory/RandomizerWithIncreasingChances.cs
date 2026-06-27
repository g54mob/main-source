using UnityEngine;

namespace Restory
{
	public class RandomizerWithIncreasingChances
	{
		private float currentChance;

		private float startingChance;

		private float chanceIncrementAfterFail;

		public RandomizerWithIncreasingChances(float startingChancePercent, float chanceIncrementAfterFail)
		{
			startingChance = startingChancePercent;
			this.chanceIncrementAfterFail = chanceIncrementAfterFail;
			currentChance = startingChance;
		}

		public void ResetChance()
		{
			currentChance = startingChance;
		}

		public void SetStartingChance(float newStartingChance, bool resetChances = false)
		{
			startingChance = newStartingChance;
			if (resetChances)
			{
				ResetChance();
			}
		}

		public void SetChanceIncrementAfterFail(float newIncrement, bool resetChances = false)
		{
			chanceIncrementAfterFail = newIncrement;
			if (resetChances)
			{
				ResetChance();
			}
		}

		public bool RollResult()
		{
			bool flag = (float)Random.Range(0, 100) < currentChance;
			currentChance = (flag ? startingChance : (currentChance + chanceIncrementAfterFail));
			return flag;
		}
	}
}
