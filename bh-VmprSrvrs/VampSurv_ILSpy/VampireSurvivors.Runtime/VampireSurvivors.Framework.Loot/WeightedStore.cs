using System.Collections.Generic;

namespace VampireSurvivors.Framework.Loot;

public class WeightedStore
{
	private List<WeightedItem> _weightedItems;

	private float _accumulatedWeight;

	public List<WeightedItem> WeightedItems => _weightedItems;

	public float AccumulatedWeight => _accumulatedWeight;

	public WeightedStore(List<WeightedItem> items, float accumulatedWeight)
	{
		_weightedItems = items;
		_accumulatedWeight = accumulatedWeight;
	}
}
