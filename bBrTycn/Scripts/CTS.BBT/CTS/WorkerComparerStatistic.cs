using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Workers/Worker Comparer (Statistic)")]
	public class WorkerComparerStatistic : WorkerComparer
	{
		public class Comparer : IComparer<Worker>
		{
			private EAgentStatistics _statistic;

			public Comparer(EAgentStatistics stat)
			{
				_statistic = stat;
			}

			public int Compare(Worker x, Worker y)
			{
				float statisticValue;
				bool flag = x.Statistics.TryGetStatisticUnitInterval(_statistic, out statisticValue);
				float statisticValue2;
				bool flag2 = y.Statistics.TryGetStatisticUnitInterval(_statistic, out statisticValue2);
				if (!flag2 && !flag)
				{
					return 0;
				}
				if (!flag2)
				{
					return -1;
				}
				if (!flag)
				{
					return 1;
				}
				return statisticValue.CompareTo(statisticValue2);
			}
		}

		[SerializeField]
		private EAgentStatistics _statistics;

		public IComparer<Worker> GetComparer(EAgentStatistics stat)
		{
			return new Comparer(stat);
		}

		public override IComparer<Worker> GetComparer()
		{
			return new Comparer(_statistics);
		}
	}
}
