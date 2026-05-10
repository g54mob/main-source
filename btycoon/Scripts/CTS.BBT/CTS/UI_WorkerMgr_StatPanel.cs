using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[Constructor("Construct")]
	public class UI_WorkerMgr_StatPanel : UI_WorkerMgr_WorkerInfoBase
	{
		[SerializeField]
		private AgentStatisticData[] _statisticsToMonitor = Array.Empty<AgentStatisticData>();

		[SerializeField]
		private Transform _container;

		[SerializeField]
		private UI_AgentStatistic _statisticPrefab;

		private Dictionary<EAgentStatistics, UI_AgentStatistic> _statistics = new Dictionary<EAgentStatistics, UI_AgentStatistic>();

		private void Construct()
		{
			AgentStatisticData[] statisticsToMonitor = _statisticsToMonitor;
			foreach (AgentStatisticData agentStatisticData in statisticsToMonitor)
			{
				if (!_statistics.ContainsKey(agentStatisticData.Statistic))
				{
					UI_AgentStatistic uI_AgentStatistic = CTSFactory.Instantiate(_statisticPrefab, _container, instantiateInWorldSpace: false, true);
					uI_AgentStatistic.SetStatisticData(agentStatisticData);
					uI_AgentStatistic.SetDisplay(isOn: false);
					_statistics[agentStatisticData.Statistic] = uI_AgentStatistic;
				}
			}
		}

		public override void Repaint()
		{
			if (base._worker == null)
			{
				return;
			}
			foreach (var (stat, _) in _statistics)
			{
				RepaintStat(stat);
			}
		}

		private void RepaintStat(EAgentStatistics stat)
		{
			if (_statistics.TryGetValue(stat, out var value))
			{
				if (base._worker.Statistics.TryGetNumericStatistic(stat, out var numericStatistic))
				{
					value.SetDisplay(isOn: true);
					value.SetStatistic(numericStatistic);
				}
				else
				{
					value.SetDisplay(isOn: false);
					value.SetStatistic(null);
				}
			}
		}
	}
}
