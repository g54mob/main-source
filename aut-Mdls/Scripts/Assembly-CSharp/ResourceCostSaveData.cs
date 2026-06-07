#define ENABLE_DEBUG_WARNINGS
using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using UnityEngine;
using Utils;

[Serializable]
public class ResourceCostSaveData
{
	[Serializable]
	public struct CostPair
	{
		public int ResourceDataId;

		public int Amount;

		public CostPair(int resourceDataId, int amount)
		{
			ResourceDataId = resourceDataId;
			Amount = amount;
		}
	}

	[SerializeField]
	private CostPair[] _costs;

	public ResourceCostSaveData()
	{
		_costs = Array.Empty<CostPair>();
	}

	public ResourceCostSaveData(ResourceCost original)
	{
		Dictionary<ResourceDataSO, int> allCosts = original.GetAllCosts();
		_costs = new CostPair[allCosts.Count];
		int num = 0;
		foreach (KeyValuePair<ResourceDataSO, int> item in allCosts)
		{
			_costs[num++] = new CostPair(item.Key.ID, item.Value);
		}
	}

	public ResourceCost ToResourceCost(ResourceDatabaseSO resourceDatabase)
	{
		SerializedDictionary<ResourceDataSO, int> serializedDictionary = new SerializedDictionary<ResourceDataSO, int>();
		CostPair[] costs = _costs;
		for (int i = 0; i < costs.Length; i++)
		{
			CostPair costPair = costs[i];
			ResourceDataSO resourceDataFromID = resourceDatabase.GetResourceDataFromID(costPair.ResourceDataId);
			if (resourceDataFromID == null)
			{
				this.LogWarning($"Resource of Id '{costPair.ResourceDataId}' with amount '{costPair.Amount}' not found. Skipping", "ToResourceCost", 51);
			}
			else
			{
				serializedDictionary.Add(resourceDataFromID, costPair.Amount);
			}
		}
		return new ResourceCost(serializedDictionary);
	}
}
