using System;
using System.Collections.Generic;
using Data.SaveData;

namespace Data.ProductionHistory
{
	[Serializable]
	public class ProductionHistorySaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public int LastStep;

		public ProductionHistoryNode CurrentHistory;

		public uint MinuteStep;

		public int[] FactoryObjectIds;

		public int[] ResourceproducedIds;

		public int[] ResourceDeliveredIds;

		public List<ProductionHistoryNode> HourHistory;

		public List<ProductionHistoryNode> TenHoursHistory;

		public List<ProductionHistoryNode> HundredHourHistory;

		public List<ProductionHistoryNode> LifeTimeHistory;

		public ProductionHistorySaveData()
			: base(0)
		{
		}

		public ProductionHistorySaveData(ProductionHistoryPersistentSO persistentSO, List<ProductionHistoryNode> hourHistory, List<ProductionHistoryNode> tenHourHistory, List<ProductionHistoryNode> hundredHourHistory, List<ProductionHistoryNode> lifeTimeHistory, uint minuteStep)
			: base(0)
		{
			LastStep = persistentSO.ManagerStep;
			CurrentHistory = persistentSO.CurrentHistory;
			MinuteStep = minuteStep;
			HourHistory = hourHistory;
			TenHoursHistory = tenHourHistory;
			HundredHourHistory = hundredHourHistory;
			LifeTimeHistory = lifeTimeHistory;
			FactoryObjectIds = new int[persistentSO.FactoryObjectIds.Count];
			foreach (KeyValuePair<int, int> factoryObjectId in persistentSO.FactoryObjectIds)
			{
				FactoryObjectIds[factoryObjectId.Value] = factoryObjectId.Key;
			}
			ResourceproducedIds = new int[persistentSO.ProducedResourceIds.Count];
			foreach (KeyValuePair<int, int> producedResourceId in persistentSO.ProducedResourceIds)
			{
				ResourceproducedIds[producedResourceId.Value] = producedResourceId.Key;
			}
			ResourceDeliveredIds = new int[persistentSO.ResourceDeliveredIds.Count];
			foreach (KeyValuePair<int, int> resourceDeliveredId in persistentSO.ResourceDeliveredIds)
			{
				ResourceDeliveredIds[resourceDeliveredId.Value] = resourceDeliveredId.Key;
			}
		}

		public bool TryApply(ProductionHistoryPersistentSO persistentSO, ref ProductionHistoryNode currentHistory, List<ProductionHistoryNode> hourHistory, List<ProductionHistoryNode> tenHourHistory, List<ProductionHistoryNode> hundredHourHistory, List<ProductionHistoryNode> lifeTimeHistory, ref uint minuteStep)
		{
			if (CurrentHistory == null)
			{
				return false;
			}
			persistentSO.ManagerStep = LastStep;
			currentHistory = CurrentHistory;
			minuteStep = MinuteStep;
			hourHistory.Clear();
			hourHistory.AddRange(HourHistory);
			tenHourHistory.Clear();
			tenHourHistory.AddRange(TenHoursHistory);
			hundredHourHistory.Clear();
			hundredHourHistory.AddRange(HundredHourHistory);
			lifeTimeHistory.Clear();
			lifeTimeHistory.AddRange(LifeTimeHistory);
			persistentSO.FactoryObjectIds.Clear();
			persistentSO.ProducedResourceIds.Clear();
			persistentSO.ResourceDeliveredIds.Clear();
			for (int i = 0; i < FactoryObjectIds.Length; i++)
			{
				persistentSO.FactoryObjectIds.Add(FactoryObjectIds[i], i);
			}
			for (int j = 0; j < ResourceproducedIds.Length; j++)
			{
				persistentSO.ProducedResourceIds.Add(ResourceproducedIds[j], j);
			}
			for (int k = 0; k < ResourceDeliveredIds.Length; k++)
			{
				persistentSO.ResourceDeliveredIds.Add(ResourceDeliveredIds[k], k);
			}
			return true;
		}
	}
}
