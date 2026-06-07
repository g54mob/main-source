using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS.Core.StatisticSystemExample
{
	[CreateAssetMenu]
	public class StatisticBehaviourFactoryExample : StatisticBehaviourFactory<EStatistics>
	{
		public override StatisticBehaviour<EStatistics> GetNewBehaviour(NumericStatistic statistic, StatisticsContainer<EStatistics> statisticsContainer)
		{
			return new StatisticBehaviourExample(statistic, statisticsContainer, this);
		}
	}
}
