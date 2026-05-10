using System;

namespace CTS.Core.StatisticsSystem
{
	public abstract class StatisticBehaviour<T> where T : Enum
	{
		public bool IsActive { get; set; }

		public NumericStatistic AssignedStatistic { get; private set; }

		public StatisticsContainer<T> StatisticsContainer { get; private set; }

		public StatisticBehaviour(NumericStatistic statisticToAssign, StatisticsContainer<T> statisticsContainer)
		{
			AssignedStatistic = statisticToAssign;
			StatisticsContainer = statisticsContainer;
		}

		public void AddToStatistic(float toAdd)
		{
			if (!IsActive)
			{
				AssignedStatistic.AddToValue(toAdd);
			}
			else
			{
				AdditionLogic(toAdd);
			}
		}

		protected abstract void AdditionLogic(float toAdd);
	}
}
