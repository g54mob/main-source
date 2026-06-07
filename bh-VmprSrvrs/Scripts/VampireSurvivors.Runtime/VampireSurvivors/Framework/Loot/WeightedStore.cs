using System.Collections.Generic;

namespace VampireSurvivors.Framework.Loot
{
	public class WeightedStore
	{
		private List<WeightedItem> _weightedItems;

		private float _accumulatedWeight;

		public List<WeightedItem> WeightedItems => null;

		public float AccumulatedWeight => 0f;

		public WeightedStore(List<WeightedItem> items, float accumulatedWeight)
		{
		}
	}
}
