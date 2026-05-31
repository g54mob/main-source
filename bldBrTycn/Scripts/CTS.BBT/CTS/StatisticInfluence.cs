using System;
using CTS.Core.StatisticsSystem;

namespace CTS
{
	public class StatisticInfluence<T> : StatisticBehaviour<T> where T : Enum
	{
		private T _influencedStatistic;

		private float _influenceRatio = 1f;

		private float _additionalInfluence;

		public StatisticInfluence(NumericStatistic statisticToAssign, StatisticsContainer<T> statisticsContainer, T influencedStatistic, float influenceRatio, float additionalInfluence)
			: base(statisticToAssign, statisticsContainer)
		{
			_influencedStatistic = influencedStatistic;
			_influenceRatio = influenceRatio;
			_additionalInfluence = additionalInfluence;
		}

		protected override void AdditionLogic(float toAdd)
		{
			base.AssignedStatistic.AddToValue(toAdd);
			base.StatisticsContainer.TryAddToStatistic(_influencedStatistic, toAdd * _influenceRatio + _additionalInfluence);
		}
	}
}
