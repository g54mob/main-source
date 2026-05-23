using System.Collections.Generic;
using Data.Shapes;
using UnityEngine;

namespace Data.Statistics
{
	[CreateAssetMenu(menuName = "General/Statistics", fileName = "StatisticsSO", order = 0)]
	public class StatisticsSO : ScriptableObject
	{
		private readonly Dictionary<int, ulong> _producedStats = new Dictionary<int, ulong>();

		private readonly Dictionary<RotationIndependentHash, uint> _producedShapesStats = new Dictionary<RotationIndependentHash, uint>();

		private readonly Dictionary<int, uint> _deliveredStats = new Dictionary<int, uint>();

		private readonly Dictionary<RotationIndependentHash, uint> _deliveredShapesStats = new Dictionary<RotationIndependentHash, uint>();

		private readonly Dictionary<int, uint> _withdrawnStats = new Dictionary<int, uint>();

		private readonly Dictionary<int, uint> _placedStats = new Dictionary<int, uint>();

		private readonly Dictionary<BehaviourStatisticType, uint> _behaviourStats = new Dictionary<BehaviourStatisticType, uint>();

		private readonly Dictionary<XPEarnedSource, int> _xpEarned = new Dictionary<XPEarnedSource, int>();

		public Dictionary<int, ulong> ProducedStats => _producedStats;

		public Dictionary<RotationIndependentHash, uint> ProducedShapesStats => _producedShapesStats;

		public Dictionary<int, uint> DeliveredStats => _deliveredStats;

		public Dictionary<RotationIndependentHash, uint> DeliveredShapesStats => _deliveredShapesStats;

		public Dictionary<int, uint> WithdrawnStats => _withdrawnStats;

		public Dictionary<int, uint> PlacedStats => _placedStats;

		public Dictionary<BehaviourStatisticType, uint> BehaviourStats => _behaviourStats;

		public Dictionary<XPEarnedSource, int> XPEarned => _xpEarned;

		public void ApplySaveData(StatisticsSaveData saveData)
		{
			Reset();
			if (saveData.ProducedStats != null)
			{
				foreach (KeyValuePair<int, ulong> producedStat in saveData.ProducedStats)
				{
					_producedStats.Add(producedStat.Key, producedStat.Value);
				}
			}
			if (saveData.ProducedShapesStats != null)
			{
				foreach (KeyValuePair<string, uint> producedShapesStat in saveData.ProducedShapesStats)
				{
					_producedShapesStats.Add(RotationIndependentHash.Parse(producedShapesStat.Key), producedShapesStat.Value);
				}
			}
			if (saveData.DeliveredStats != null)
			{
				foreach (KeyValuePair<int, uint> deliveredStat in saveData.DeliveredStats)
				{
					_deliveredStats.Add(deliveredStat.Key, deliveredStat.Value);
				}
			}
			if (saveData.DeliveredShapesStats != null)
			{
				foreach (KeyValuePair<string, uint> deliveredShapesStat in saveData.DeliveredShapesStats)
				{
					_deliveredShapesStats.Add(RotationIndependentHash.Parse(deliveredShapesStat.Key), deliveredShapesStat.Value);
				}
			}
			if (saveData.WithdrawnStats != null)
			{
				foreach (KeyValuePair<int, uint> withdrawnStat in saveData.WithdrawnStats)
				{
					_withdrawnStats.Add(withdrawnStat.Key, withdrawnStat.Value);
				}
			}
			if (saveData.PlacedStats != null)
			{
				foreach (KeyValuePair<int, uint> placedStat in saveData.PlacedStats)
				{
					_placedStats.Add(placedStat.Key, placedStat.Value);
				}
			}
			if (saveData.BehaviourStats != null)
			{
				foreach (KeyValuePair<BehaviourStatisticType, uint> behaviourStat in saveData.BehaviourStats)
				{
					_behaviourStats.Add(behaviourStat.Key, behaviourStat.Value);
				}
			}
			if (saveData.XPEarned == null)
			{
				return;
			}
			foreach (KeyValuePair<XPEarnedSource, int> item in saveData.XPEarned)
			{
				_xpEarned.Add(item.Key, item.Value);
			}
		}

		public void Reset()
		{
			_producedStats.Clear();
			_producedShapesStats.Clear();
			_deliveredStats.Clear();
			_deliveredShapesStats.Clear();
			_withdrawnStats.Clear();
			_placedStats.Clear();
			_behaviourStats.Clear();
			_xpEarned.Clear();
		}

		public void AddProducedStatistic(int resourceId, ulong addAmount = 1uL)
		{
			if (!_producedStats.TryAdd(resourceId, addAmount))
			{
				_producedStats[resourceId] += addAmount;
			}
		}

		public void AddProducedShapeStatistic(RotationIndependentHash shapeHash, uint addAmount = 1u)
		{
			if (!_producedShapesStats.TryAdd(shapeHash, addAmount))
			{
				_producedShapesStats[shapeHash] += addAmount;
			}
		}

		public void AddDeliveredStatistic(int resourceId, uint addAmount = 1u)
		{
			if (!_deliveredStats.TryAdd(resourceId, addAmount))
			{
				_deliveredStats[resourceId] += addAmount;
			}
		}

		public void AddDeliveredShapeStatistic(RotationIndependentHash shapeHash, uint addAmount = 1u)
		{
			if (!_deliveredShapesStats.TryAdd(shapeHash, addAmount))
			{
				_deliveredShapesStats[shapeHash] += addAmount;
			}
		}

		public void AddWithdrawnStatistic(int resourceId, uint addAmount = 1u)
		{
			if (!_withdrawnStats.TryAdd(resourceId, addAmount))
			{
				_withdrawnStats[resourceId] += addAmount;
			}
		}

		public void AddPlacedStatistic(int factoryObjectId, uint addAmount = 1u)
		{
			if (!_placedStats.TryAdd(factoryObjectId, addAmount))
			{
				_placedStats[factoryObjectId] += addAmount;
			}
		}

		public void AddBehaviourStatistic(BehaviourStatisticType type, uint addAmount = 1u)
		{
			if (!_behaviourStats.TryAdd(type, addAmount))
			{
				_behaviourStats[type] += addAmount;
			}
		}

		public void AddXPEarnedStatistic(XPEarnedSource type, int addAmount = 1)
		{
			if (!_xpEarned.TryAdd(type, addAmount))
			{
				_xpEarned[type] += addAmount;
			}
		}

		public ulong GetProducedStatistic(int resourceId)
		{
			if (!_producedStats.ContainsKey(resourceId))
			{
				return 0uL;
			}
			return _producedStats[resourceId];
		}

		public uint GetProducedShapesStatistic(RotationIndependentHash shapeHash)
		{
			if (!_producedShapesStats.ContainsKey(shapeHash))
			{
				return 0u;
			}
			return _producedShapesStats[shapeHash];
		}

		public uint GetDeliveredStatistic(int resourceId)
		{
			if (!_deliveredStats.ContainsKey(resourceId))
			{
				return 0u;
			}
			return _deliveredStats[resourceId];
		}

		public uint GetDeliveredShapesStatistic(RotationIndependentHash shapeHash)
		{
			if (!_deliveredShapesStats.ContainsKey(shapeHash))
			{
				return 0u;
			}
			return _deliveredShapesStats[shapeHash];
		}

		public uint GetWithdrawnStatistic(int resourceId)
		{
			if (!_withdrawnStats.ContainsKey(resourceId))
			{
				return 0u;
			}
			return _withdrawnStats[resourceId];
		}

		public uint GetPlacedStatistic(int factoryObjectId)
		{
			if (!_placedStats.ContainsKey(factoryObjectId))
			{
				return 0u;
			}
			return _placedStats[factoryObjectId];
		}

		public uint GetBehaviourStatistic(BehaviourStatisticType type)
		{
			if (!_behaviourStats.ContainsKey(type))
			{
				return 0u;
			}
			return _behaviourStats[type];
		}

		public int GetXPEarnedStatistic(XPEarnedSource type)
		{
			if (!_xpEarned.ContainsKey(type))
			{
				return 0;
			}
			return _xpEarned[type];
		}
	}
}
