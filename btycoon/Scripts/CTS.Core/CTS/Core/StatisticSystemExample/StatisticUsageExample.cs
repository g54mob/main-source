using CTS.Core.StatisticsSystem;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.Core.StatisticSystemExample
{
	public class StatisticUsageExample : MonoBehaviour
	{
		public StatisticsContainerExample statistics;

		[Button("Add 5 to all stats.", EButtonEnableMode.Always)]
		private void Add5()
		{
			StatisticsContainer<EStatistics>.StatisticChanged += StatisticsExample_StatisticChanged;
			statistics.AddToStatistic(EStatistics.Strenght, 5f);
			statistics.AddToStatistic(EStatistics.Intellect, 5f);
			StatisticsContainer<EStatistics>.StatisticChanged -= StatisticsExample_StatisticChanged;
		}

		private void StatisticsExample_StatisticChanged(EStatistics arg1, float arg2)
		{
			MonoBehaviour.print($"{arg1} changed to {arg2}.");
		}
	}
}
