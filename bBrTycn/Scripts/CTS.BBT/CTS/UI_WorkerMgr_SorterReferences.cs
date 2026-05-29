using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerMgr_SorterReferences : CTSBehaviour
	{
		[SerializeField]
		private SerializableDictionary<StringKey, UI_WorkerMgr_SortingAnchorBase> _baseSorters = new SerializableDictionary<StringKey, UI_WorkerMgr_SortingAnchorBase>();

		private readonly Dictionary<EAgentStatistics, UI_WorkerMgr_SortingAnchorStatistic> _statisticSorters = new Dictionary<EAgentStatistics, UI_WorkerMgr_SortingAnchorStatistic>();

		public ReadOnlyDictionary<StringKey, UI_WorkerMgr_SortingAnchorBase> BaseSorters => _baseSorters;

		public ReadOnlyDictionary<EAgentStatistics, UI_WorkerMgr_SortingAnchorStatistic> StatisticSorters => _statisticSorters;

		protected override void OnAwake()
		{
			base.OnAwake();
			UI_WorkerMgr_SortingAnchorStatistic[] componentsInChildren = GetComponentsInChildren<UI_WorkerMgr_SortingAnchorStatistic>(includeInactive: true);
			foreach (UI_WorkerMgr_SortingAnchorStatistic uI_WorkerMgr_SortingAnchorStatistic in componentsInChildren)
			{
				_statisticSorters[uI_WorkerMgr_SortingAnchorStatistic.Statistic] = uI_WorkerMgr_SortingAnchorStatistic;
			}
		}
	}
}
