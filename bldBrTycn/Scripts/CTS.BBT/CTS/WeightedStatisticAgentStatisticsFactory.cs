using CTS.Core;
using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Weighted Statistic Behaviour", menuName = "BBT/Statistics/Behaviours/Weighted Statistic Behaviour")]
	public class WeightedStatisticAgentStatisticsFactory : StatisticBehaviourFactory<EAgentStatistics>
	{
		[SerializeField]
		private SerializableDictionary<EAgentStatistics, float> _statisticWeightedIn;

		public override StatisticBehaviour<EAgentStatistics> GetNewBehaviour(NumericStatistic statistic, StatisticsContainer<EAgentStatistics> statisticsContainer)
		{
			return new WeightedStatistic<EAgentStatistics>(statistic, statisticsContainer, _statisticWeightedIn);
		}
	}
}
