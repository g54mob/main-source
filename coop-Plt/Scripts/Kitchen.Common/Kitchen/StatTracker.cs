using System.Collections.Generic;
using Kitchen.Statistics;
using UnityEngine;

namespace Kitchen
{
	public class StatTracker
	{
		private readonly Dictionary<StatType, IStatistic> Statistics = new Dictionary<StatType, IStatistic>();

		public static StatTracker Main { get; } = new StatTracker();

		public StatTracker()
		{
			Statistics.Add(StatType.NetworkFilteredPacketCount, new MovingAverageStatistic());
			Statistics.Add(StatType.NetworkFilteredPacketRatio, new MovingAverageStatistic());
			Statistics.Add(StatType.NetworkSerialisationSize, new MovingAverageStatistic());
			Statistics.Add(StatType.IndicatorCreated, new CountStatistic(10f));
		}

		public T ResultValue<T>(StatType stat)
		{
			if (!Statistics.TryGetValue(stat, out var value))
			{
				Debug.LogWarning($"Attempted to read untracked {stat}");
				return default(T);
			}
			if (value is IStatistic<T> statistic)
			{
				return statistic.ResultValue();
			}
			Debug.LogWarning($"Attempted to mis-read type of {stat} (as {typeof(T)})");
			return default(T);
		}

		public void Report<TI, TV>(StatType stat, TI index, TV value)
		{
			if (!Statistics.TryGetValue(stat, out var value2))
			{
				Debug.LogWarning($"Attempted to report untracked {stat}");
			}
			else if (value2 is Statistic<TI, TV> statistic)
			{
				statistic.Report(index, value);
			}
			else
			{
				Debug.LogWarning($"Attempted to mis-report type of {stat} (as {typeof(TI)}/{typeof(TV)})");
			}
		}
	}
}
