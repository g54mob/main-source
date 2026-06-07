using Dhs5.Utility.Settings;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Settings("Shop/Score", Scope.Project)]
	public class TabletopScoreSettings : ScoreSettings
	{
		[Header("Score Reward Chart")]
		[SerializeField]
		private TabletopScoreRewardChart m_tabletopScoreRewardChart;

		public static Calculation GetScoreRewardCalculation(ETabletopXPRewardEvent tabletopXpRewardEvent)
		{
			return ((TabletopScoreSettings)CustomSettings<ScoreSettings>.I).m_tabletopScoreRewardChart[tabletopXpRewardEvent];
		}
	}
}
