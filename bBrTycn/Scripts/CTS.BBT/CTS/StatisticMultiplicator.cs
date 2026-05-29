using System;
using CTS.Core.StatisticsSystem;

namespace CTS
{
	public class StatisticMultiplicator<T> : StatisticBehaviour<T> where T : Enum
	{
		private float _multiplicator = 1f;

		public StatisticMultiplicator(NumericStatistic statisticToAssign, StatisticsContainer<T> statisticsContainer, float multiplicator)
			: base(statisticToAssign, statisticsContainer)
		{
			_multiplicator = multiplicator;
		}

		protected override void AdditionLogic(float toAdd)
		{
			base.AssignedStatistic.AddToValue(toAdd * _multiplicator);
		}
	}
}
