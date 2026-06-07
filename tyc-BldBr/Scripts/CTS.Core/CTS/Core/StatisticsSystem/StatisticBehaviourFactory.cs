using System;
using UnityEngine;

namespace CTS.Core.StatisticsSystem
{
	public abstract class StatisticBehaviourFactory<T> : ScriptableObject where T : Enum
	{
		public abstract StatisticBehaviour<T> GetNewBehaviour(NumericStatistic statistic, StatisticsContainer<T> statisticsContainer);
	}
}
