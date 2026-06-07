using System.Collections.Generic;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "StatisticsCollection", menuName = "BBT/Statistics/Statistics Collection")]
	public class StatisticsCollection : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<EAgentStatistics, NumericStatistic> _statisticsToAdd;

		[SerializeField]
		private SerializableDictionary<EAgentStatistics, StatisticBehaviourFactory<EAgentStatistics>> _behavioursToAdd;

		[SerializeField]
		private DailyRefresh[] _dailyRefreshes;

		public void AddStatisticsAndBehaviours(AgentStatistics agentStatistics)
		{
			if (!agentStatistics)
			{
				return;
			}
			foreach (KeyValuePair<EAgentStatistics, NumericStatistic> item in _statisticsToAdd)
			{
				if (!agentStatistics.HasStatistic(item.Key))
				{
					agentStatistics.AddNumericStatistic(item.Key, new NumericStatistic(item.Value));
				}
			}
			foreach (KeyValuePair<EAgentStatistics, StatisticBehaviourFactory<EAgentStatistics>> item2 in _behavioursToAdd)
			{
				agentStatistics.AddBehaviourToStatistic(item2.Key, item2.Value);
			}
			DailyRefresh[] dailyRefreshes = _dailyRefreshes;
			foreach (DailyRefresh dailyRefreshToAdd in dailyRefreshes)
			{
				agentStatistics.AddDailyRefresh(dailyRefreshToAdd);
			}
		}
	}
}
