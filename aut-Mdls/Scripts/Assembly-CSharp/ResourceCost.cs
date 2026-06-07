using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using UnityEngine;

[Serializable]
public class ResourceCost
{
	[SerializeField]
	private SerializedDictionary<ResourceDataSO, int> _cost = new SerializedDictionary<ResourceDataSO, int>();

	public ResourceCost()
	{
		_cost = new SerializedDictionary<ResourceDataSO, int>();
	}

	public ResourceCost(ResourceCost original)
	{
		_cost = new SerializedDictionary<ResourceDataSO, int>(original._cost);
	}

	public ResourceCost(SerializedDictionary<ResourceDataSO, int> costs)
	{
		_cost = costs;
	}

	public int GetCost(ResourceDataSO resource)
	{
		return _cost.GetValueOrDefault(resource, 0);
	}

	public Dictionary<ResourceDataSO, int> GetAllCosts()
	{
		return new Dictionary<ResourceDataSO, int>(_cost);
	}

	public bool IsFree()
	{
		return _cost.Values.All((int cost) => cost <= 0);
	}

	private string Pluralize(string noun, int count)
	{
		if (count != 1)
		{
			return noun + "s";
		}
		return noun;
	}

	public override string ToString()
	{
		if (IsFree())
		{
			return "Free";
		}
		List<string> values = _cost.Where((KeyValuePair<ResourceDataSO, int> kv) => kv.Value > 0).Select(delegate(KeyValuePair<ResourceDataSO, int> kv)
		{
			string arg = ExtractColorFromResourceName(kv.Key.name);
			return string.Format("{0} {1} {2}", kv.Value, arg, Pluralize("shard", kv.Value));
		}).ToList();
		return string.Join(", ", values);
	}

	private string ExtractColorFromResourceName(string resourceName)
	{
		if (string.IsNullOrEmpty(resourceName))
		{
			return "Unknown";
		}
		if (resourceName.EndsWith("DataShardResourceData"))
		{
			return resourceName.Replace("DataShardResourceData", "");
		}
		return resourceName;
	}
}
