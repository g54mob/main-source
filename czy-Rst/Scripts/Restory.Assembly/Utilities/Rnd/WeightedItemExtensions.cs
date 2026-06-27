using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.Rnd
{
	public static class WeightedItemExtensions
	{
		public static IWeightedItem GetRandom(this IReadOnlyCollection<IWeightedItem> collection)
		{
			float maxInclusive = collection.Sum((IWeightedItem x) => x.Weight);
			float num = Random.Range(0f, maxInclusive);
			float num2 = 0f;
			foreach (IWeightedItem item in collection)
			{
				num2 += item.Weight;
				if (num2 >= num)
				{
					return item;
				}
			}
			return null;
		}
	}
}
