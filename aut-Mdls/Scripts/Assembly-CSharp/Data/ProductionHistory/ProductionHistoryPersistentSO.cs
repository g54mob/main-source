#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using Data.SaveData;
using Logic.Threading.Events;
using UnityEngine;
using Utils;

namespace Data.ProductionHistory
{
	[CreateAssetMenu(menuName = "PersistentSOs/Production History", fileName = "ProductionHistoryPersistentSO", order = 0)]
	public class ProductionHistoryPersistentSO : AbstractPersistentSO
	{
		private const int HourRange = 30;

		private const int HourCapacity = 30;

		private const int TenHourToHour = 10;

		private const int TenHourRange = 30;

		private const int TenHourCapacity = 30;

		private const int TenHourStepInterval = 10;

		private const int HundredHourToTenHour = 6;

		private const int HundredHourRange = 50;

		private const int HundredHourCapacity = 50;

		private const int HundredHourStepInterval = 60;

		private const int LifeTimeToHundredHour = 5;

		private const int LifeTimeStepInterval = 300;

		private ProductionHistoryNode _currentHistory = new ProductionHistoryNode();

		private readonly List<ProductionHistoryNode> _hourHistory = new List<ProductionHistoryNode>(30);

		private readonly List<ProductionHistoryNode> _tenHoursHistory = new List<ProductionHistoryNode>(30);

		private readonly List<ProductionHistoryNode> _hundredHourHistory = new List<ProductionHistoryNode>(50);

		private readonly List<ProductionHistoryNode> _lifeTimeHistory = new List<ProductionHistoryNode>();

		private int _managerStep;

		private uint _minuteStep;

		private readonly Dictionary<int, int> _factoryObjectIds = new Dictionary<int, int>();

		private readonly Dictionary<int, int> _resourceProducedIds = new Dictionary<int, int>();

		private readonly Dictionary<int, int> _resourceDeliveredIds = new Dictionary<int, int>();

		public MainThreadEvent OnNewNode = new MainThreadEvent();

		internal int ManagerStep
		{
			get
			{
				return _managerStep;
			}
			set
			{
				_managerStep = value;
			}
		}

		public ProductionHistoryNode CurrentHistory => _currentHistory;

		public Dictionary<int, int> FactoryObjectIds => _factoryObjectIds;

		public Dictionary<int, int> ProducedResourceIds => _resourceProducedIds;

		public Dictionary<int, int> ResourceDeliveredIds => _resourceDeliveredIds;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			if (!(saveData as ProductionHistorySaveData).TryApply(this, ref _currentHistory, _hourHistory, _tenHoursHistory, _hundredHourHistory, _lifeTimeHistory, ref _minuteStep))
			{
				ResetToDefaults();
			}
			this.Log("Applied Savegame!", "ApplyLoadedSaveData", 62);
		}

		public override AbstractSaveData GetSaveData()
		{
			return new ProductionHistorySaveData(this, _hourHistory, _tenHoursHistory, _hundredHourHistory, _lifeTimeHistory, _minuteStep);
		}

		public override void ResetToDefaults()
		{
			_managerStep = 0;
			_minuteStep = 0u;
			_currentHistory = new ProductionHistoryNode();
			_hourHistory.Clear();
			_tenHoursHistory.Clear();
			_hundredHourHistory.Clear();
			_lifeTimeHistory.Clear();
			_factoryObjectIds.Clear();
			_resourceProducedIds.Clear();
			_resourceDeliveredIds.Clear();
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<ProductionHistorySaveData>(fullPath);
		}

		internal void OnMinuteReached()
		{
			if (_hourHistory.Count >= 30)
			{
				_hourHistory.RemoveAt(0);
			}
			_hourHistory.Add(_currentHistory);
			TryMoveNodesForward(++_minuteStep);
			_currentHistory = new ProductionHistoryNode(_currentHistory);
			OnNewNode.Fire();
		}

		private void TryMoveNodesForward(uint step)
		{
			if (step == 0 || step % 10 != 0)
			{
				return;
			}
			AddNodeAverage(_hourHistory, _tenHoursHistory, 30, 10);
			if (step % 60 == 0)
			{
				AddNodeAverage(_tenHoursHistory, _hundredHourHistory, 50, 6);
				if (step % 300 == 0)
				{
					AddNodeAverage(_hundredHourHistory, _lifeTimeHistory, int.MaxValue, 5);
				}
			}
		}

		private void AddNodeAverage(List<ProductionHistoryNode> fromQueue, List<ProductionHistoryNode> toQueue, int toQueueCapcity, int fromToQueueRange)
		{
			ProductionHistoryNode productionHistoryNode = new ProductionHistoryNode();
			for (int i = fromQueue.Count - fromToQueueRange; i < fromQueue.Count; i++)
			{
				productionHistoryNode.Add(fromQueue[i]);
			}
			productionHistoryNode.Divide(fromToQueueRange);
			if (toQueue.Count >= toQueueCapcity)
			{
				toQueue.RemoveAt(0);
			}
			toQueue.Add(productionHistoryNode);
		}

		public IEnumerable<ProductionHistoryNode> GetHourNodes()
		{
			foreach (ProductionHistoryNode item in _hourHistory)
			{
				yield return item;
			}
			yield return _currentHistory;
		}

		public IEnumerable<ProductionHistoryNode> GetTenHourNodes()
		{
			return _tenHoursHistory;
		}

		public IEnumerable<ProductionHistoryNode> GetHundredHourNodes()
		{
			return _hundredHourHistory;
		}

		public IEnumerable<ProductionHistoryNode> GetLifeTimeNodes()
		{
			return _lifeTimeHistory;
		}

		public void ModifyFactoryObjectAmount(int factoryObjectId, int delta = 1)
		{
			ModifyValue(factoryObjectId, delta, _currentHistory.FactoryObjectAmounts, _factoryObjectIds);
		}

		public void ModifyResourceProducedDelta(int resourceId, int delta = 1)
		{
			ModifyValue(resourceId, delta, _currentHistory.ResourceProducedDeltas, _resourceProducedIds);
		}

		public void ModifyResourceDeliveredDelta(int resourceId, int delta = 1)
		{
			ModifyValue(resourceId, delta, _currentHistory.ResourceDeliveredDeltas, _resourceDeliveredIds);
		}

		private void ModifyValue<T>(T id, int delta, List<int> values, Dictionary<T, int> idToIndex)
		{
			if (!idToIndex.TryGetValue(id, out var value))
			{
				value = idToIndex.Count;
				idToIndex.Add(id, value);
			}
			while (value >= values.Count)
			{
				values.Add(0);
			}
			values[value] += delta;
		}
	}
}
