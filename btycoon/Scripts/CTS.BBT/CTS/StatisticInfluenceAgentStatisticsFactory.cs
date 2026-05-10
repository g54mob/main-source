using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Statistic Influence Behaviour", menuName = "BBT/Statistics/Behaviours/Statistic Influence Behaviour")]
	public class StatisticInfluenceAgentStatisticsFactory : StatisticBehaviourFactory<EAgentStatistics>
	{
		[SerializeField]
		private EAgentStatistics _influencedStatistic;

		[SerializeField]
		[Range(0f, 10f)]
		private float _influenceRatio = 1f;

		[SerializeField]
		private float _additionalInfluence;

		public override StatisticBehaviour<EAgentStatistics> GetNewBehaviour(NumericStatistic statistic, StatisticsContainer<EAgentStatistics> statisticsContainer)
		{
			return new StatisticInfluence<EAgentStatistics>(statistic, statisticsContainer, _influencedStatistic, _influenceRatio, _additionalInfluence);
		}
	}
}
