using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Resources;
using Data.GameState;
using Data.Progression;
using Data.SaveData.PersistentSOs;
using Data.Statistics;
using Data.Variables;
using Events;
using Events.Analytics;
using Events.UI.TechTree;
using NaughtyAttributes;
using UnityEngine;

namespace Utils.Analytics.IntervalHandlers
{
	public class BalancingAnalyticsIntervalHandler : AbstractAnalyticsIntervalHandler
	{
		[InfoBox("Balancing Interval Minutes with their corresponding cutoffs. For example: every 15 minutes for first 10 hours (600 min).", EInfoBoxType.Normal)]
		[SerializeField]
		private int[] _balancingIntervalMinutes;

		[SerializeField]
		private int[] _balancingIntervalCutoffMinutes;

		[SerializeField]
		private StatisticsSO _statistics;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSo;

		[SerializeField]
		private AnalyticsQueueEvent _analyticsQueueEvent;

		[SerializeField]
		private BaseEvent _analyticsClearQueueEvent;

		[SerializeField]
		private PauseStateData _pauseState;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsSO;

		[SerializeField]
		private NodeUnlockedEvent _nodeUnlockedEvent;

		[SerializeField]
		private IntVariableSO _GNNGateCurrentPhaseSO;

		[Header("Stats")]
		[SerializeField]
		private ResourceDataSO[] _bots;

		[SerializeField]
		private ResourceDataSO[] _datashards;

		[SerializeField]
		private BuildingObjectData[] _monuments;

		[SerializeField]
		private ProgressionMonumentsManager _monumentsManager;

		[SerializeField]
		private BoolVariableSO _gnnGateFinished;

		private readonly List<TechTreeNodeSO> _techtreeNodesUnlocked = new List<TechTreeNodeSO>();

		private int _nextInterval;

		private double _totalPlayTimeMins;

		private readonly List<(string, float)> _balancingData = new List<(string, float)>();

		private int _GNNGateStartPhase;

		protected override void Initialize()
		{
			_nodeUnlockedEvent.Register(OnTechTreeNodeUnlocked);
			_analyticsClearQueueEvent.Fire();
			_GNNGateStartPhase = _GNNGateCurrentPhaseSO.Value;
			_totalPlayTimeMins = _saveInfoPersistentSo.TotalPlayTimeMins;
			int interval = GetInterval(_totalPlayTimeMins);
			_nextInterval = interval * Mathf.CeilToInt((float)_totalPlayTimeMins / (float)interval);
			base.Initialize();
		}

		protected override void OnDestroy()
		{
			_nodeUnlockedEvent.UnRegister(OnTechTreeNodeUnlocked);
			base.OnDestroy();
		}

		private int GetInterval(double totalPlayTimeMins)
		{
			for (int i = 0; i < _balancingIntervalCutoffMinutes.Length; i++)
			{
				if (totalPlayTimeMins <= (double)_balancingIntervalCutoffMinutes[i])
				{
					return _balancingIntervalMinutes[i];
				}
			}
			return _balancingIntervalMinutes[^1];
		}

		public override void TrySendAnalytics()
		{
			if (!_pauseState.IsPaused)
			{
				_totalPlayTimeMins = _saveInfoPersistentSo.GetUpdatedTotalPlaytime();
				if (_totalPlayTimeMins >= (double)_nextInterval)
				{
					SendStatistics(_nextInterval);
					_nextInterval += GetInterval(_totalPlayTimeMins);
				}
			}
		}

		private void SendStatistics(int timeInterval)
		{
			_balancingData.Clear();
			for (int i = 0; i < _bots.Length; i++)
			{
				GatherStatistic($"Balance:{timeInterval}:Delivered:{_bots[i].AnalyticsName}", _statistics.GetDeliveredStatistic(_bots[i].ID));
			}
			for (int j = 0; j < _datashards.Length; j++)
			{
				GatherStatistic($"Balance:{timeInterval}:Delivered:{_datashards[j].AnalyticsName}", _statistics.GetDeliveredStatistic(_datashards[j].ID));
			}
			GatherStatistic($"Balance:{timeInterval}:EarnedXP:DeliveryTargets", (uint)_statistics.GetXPEarnedStatistic(XPEarnedSource.DeliveryTargets));
			GatherStatistic($"Balance:{timeInterval}:EarnedXP:ModuleChallenges", (uint)_statistics.GetXPEarnedStatistic(XPEarnedSource.ModuleChallenges));
			GatherStatistic($"Balance:{timeInterval}:Unlocked:Island", (uint)_unlockedIslandsSO.UnlockedIslandCount);
			for (int k = 0; k < _monuments.Length; k++)
			{
				if (_monumentsManager.GetMonumentState(_monuments[k]) == ProgressionMonumentsManager.MonumentState.Built)
				{
					GatherStatistic($"Balance:{timeInterval}:Completed:{_monuments[k].AnalyticsName}", 1u);
				}
			}
			if (_GNNGateCurrentPhaseSO.Value - 1 > _GNNGateStartPhase)
			{
				for (int l = _GNNGateStartPhase + 1; l <= _GNNGateCurrentPhaseSO.Value; l++)
				{
					if (l > 0)
					{
						GatherStatistic($"Balance:{timeInterval}:Completed:GNNGatePhase{l}", 1u);
					}
				}
				_GNNGateStartPhase = _GNNGateCurrentPhaseSO.Value;
			}
			if (_gnnGateFinished.Value)
			{
				GatherStatistic($"Balance:{timeInterval}:Completed:GNNGate", 1u);
			}
			for (int m = 0; m < _techtreeNodesUnlocked.Count; m++)
			{
				GatherStatistic($"Balance:{timeInterval}:Unlocked:{_techtreeNodesUnlocked[m].LocaKey}", 1u);
			}
			_techtreeNodesUnlocked.Clear();
			_analyticsQueueEvent.Fire(_balancingData);
		}

		private void GatherStatistic(string eventString, uint value)
		{
			if (value != 0)
			{
				_balancingData.Add((eventString, value));
			}
		}

		private void GatherStatistic(string eventString, ulong value)
		{
			if (value != 0L)
			{
				_balancingData.Add((eventString, value));
			}
		}

		private void OnTechTreeNodeUnlocked(TechTreeNodeSO techTreeNode)
		{
			if (techTreeNode.AddToBalancingGAData)
			{
				_techtreeNodesUnlocked.Add(techTreeNode);
			}
		}
	}
}
