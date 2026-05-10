using CTS.Core.StatisticsSystem;

namespace CTS.Core.StatisticSystemExample
{
	public class StatisticBehaviourExample : StatisticBehaviour<EStatistics>
	{
		public StatisticBehaviourFactoryExample BehaviourFactoryExample { get; private set; }

		public StatisticBehaviourExample(NumericStatistic statisticToAssign, StatisticsContainer<EStatistics> statisticsContainer, StatisticBehaviourFactoryExample factory)
			: base(statisticToAssign, statisticsContainer)
		{
			BehaviourFactoryExample = factory;
		}

		protected override void AdditionLogic(float toAdd)
		{
			base.AssignedStatistic.AddToValue(base.StatisticsContainer.HasStatistic(EStatistics.Strenght) ? (toAdd * base.StatisticsContainer.GetStatisticUnitInterval(EStatistics.Strenght)) : toAdd);
		}
	}
}
