using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopScoreManager : ScoreManager
	{
		public void GainReward(ETabletopXPRewardEvent tabletopXpRewardEvent, int quantity = 1)
		{
			int num = base.CurrentScore;
			Calculation scoreRewardCalculation = TabletopScoreSettings.GetScoreRewardCalculation(tabletopXpRewardEvent);
			for (int i = 0; i < quantity; i++)
			{
				num = Mathf.RoundToInt(scoreRewardCalculation.ComputeValue(num));
			}
			ChangeScore(num, $"Gain reward due to event {tabletopXpRewardEvent}");
		}
	}
}
