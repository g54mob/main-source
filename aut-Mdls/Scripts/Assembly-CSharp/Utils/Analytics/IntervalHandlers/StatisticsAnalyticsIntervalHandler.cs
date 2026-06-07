#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Statistics;
using Events.Analytics;
using UnityEngine;

namespace Utils.Analytics.IntervalHandlers
{
	public class StatisticsAnalyticsIntervalHandler : AbstractAnalyticsIntervalHandler
	{
		private const string STATISTICS = "Statistics";

		[SerializeField]
		private StatisticsSO _statistics;

		[SerializeField]
		private StatisticsAnalyticsSO _statisticsAnalyticsSO;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabaseSO;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private AnalyticsDesignEvent _analyticsDesignEvent;

		private readonly Dictionary<ResourceDataSO, ulong> _producedStats = new Dictionary<ResourceDataSO, ulong>();

		private readonly Dictionary<ResourceDataSO, uint> _deliveredStats = new Dictionary<ResourceDataSO, uint>();

		private readonly Dictionary<FactoryObjectData, uint> _placedStats = new Dictionary<FactoryObjectData, uint>();

		private readonly Dictionary<BehaviourStatisticType, uint> _behaviourStats = new Dictionary<BehaviourStatisticType, uint>();

		protected override void Initialize()
		{
			this.Log("GA Cache statistics", "Initialize", 29);
			_producedStats.Clear();
			_deliveredStats.Clear();
			_placedStats.Clear();
			foreach (ResourceDataSO resourceDatum in _resourceDatabaseSO.ResourceData)
			{
				if (_statisticsAnalyticsSO.ShouldTrackResourceProduced(resourceDatum))
				{
					_producedStats.Add(resourceDatum, _statistics.ProducedStats.GetValueOrDefault(resourceDatum.ID));
				}
				if (_statisticsAnalyticsSO.ShouldTrackResourcesDelivered(resourceDatum))
				{
					_deliveredStats.Add(resourceDatum, _statistics.DeliveredStats.GetValueOrDefault(resourceDatum.ID));
				}
			}
			foreach (FactoryObjectData allFactoryObjectsDatum in _factoryObjectDatabase.AllFactoryObjectsData)
			{
				if (_statisticsAnalyticsSO.ShouldTrackFactoryObjectPlaced(allFactoryObjectsDatum))
				{
					_placedStats.Add(allFactoryObjectsDatum, _statistics.PlacedStats.GetValueOrDefault(allFactoryObjectsDatum.ID));
				}
			}
			base.Initialize();
		}

		public override void TrySendAnalytics()
		{
			this.Log("GA Sending Statistics events interval!", "TrySendAnalytics", 61);
			TrackBehaviourStatistic(BehaviourStatisticType.CubesProduced);
			TrackDeliveredStatistics();
			TrackPlacedStatistics();
		}

		private void TrackBehaviourStatistic(BehaviourStatisticType type)
		{
			uint behaviourStatistic = _statistics.GetBehaviourStatistic(type);
			uint num = (_behaviourStats.ContainsKey(type) ? _behaviourStats[type] : 0u);
			if (behaviourStatistic - num != 0)
			{
				_analyticsDesignEvent.Fire((string.Format("{0}:Behaviour:{1}", "Statistics", type), behaviourStatistic - num));
				_behaviourStats[type] = behaviourStatistic;
			}
		}

		private void TrackProducedStatistics()
		{
			List<(ResourceDataSO, ulong)> list = new List<(ResourceDataSO, ulong)>();
			foreach (KeyValuePair<ResourceDataSO, ulong> producedStat in _producedStats)
			{
				ulong producedStatistic = _statistics.GetProducedStatistic(producedStat.Key.ID);
				if (producedStatistic > producedStat.Value)
				{
					_analyticsDesignEvent.Fire(("Statistics:Resource:Produced:" + producedStat.Key.AnalyticsName, producedStatistic - producedStat.Value));
					list.Add((producedStat.Key, producedStatistic));
				}
			}
			foreach (var (key, value) in list)
			{
				_producedStats[key] = value;
			}
		}

		private void TrackDeliveredStatistics()
		{
			List<(ResourceDataSO, uint)> list = new List<(ResourceDataSO, uint)>();
			foreach (KeyValuePair<ResourceDataSO, uint> deliveredStat in _deliveredStats)
			{
				uint deliveredStatistic = _statistics.GetDeliveredStatistic(deliveredStat.Key.ID);
				if (deliveredStatistic > deliveredStat.Value)
				{
					_analyticsDesignEvent.Fire(("Statistics:Resource:Delivered:" + deliveredStat.Key.AnalyticsName, deliveredStatistic - deliveredStat.Value));
					list.Add((deliveredStat.Key, deliveredStatistic));
				}
			}
			foreach (var (key, value) in list)
			{
				_deliveredStats[key] = value;
			}
		}

		private void TrackPlacedStatistics()
		{
			List<(FactoryObjectData, uint)> list = new List<(FactoryObjectData, uint)>();
			foreach (KeyValuePair<FactoryObjectData, uint> placedStat in _placedStats)
			{
				uint placedStatistic = _statistics.GetPlacedStatistic(placedStat.Key.ID);
				if (placedStatistic > placedStat.Value)
				{
					if (placedStat.Key is BuildingObjectData)
					{
						_analyticsDesignEvent.Fire(("Statistics:FactoryObject:PlacedBuilding:" + placedStat.Key.AnalyticsName, placedStatistic - placedStat.Value));
					}
					else
					{
						_analyticsDesignEvent.Fire(("Statistics:FactoryObject:PlacedOperator:" + placedStat.Key.AnalyticsName, placedStatistic - placedStat.Value));
					}
					list.Add((placedStat.Key, placedStatistic));
				}
			}
			foreach (var (key, value) in list)
			{
				_placedStats[key] = value;
			}
		}
	}
}
