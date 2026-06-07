using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerMgr_SortingAnchorStatistic : UI_WorkerMgr_SortingAnchorBase
	{
		[SerializeField]
		private WorkerComparerStatistic _comparer;

		[SerializeField]
		[Inject(false)]
		private UI_AgentStatistic _statisticUI;

		public EAgentStatistics Statistic => _statisticUI.StatType;

		protected override IComparer<Worker> CreateComparer()
		{
			return _comparer.GetComparer(_statisticUI.StatType);
		}
	}
}
