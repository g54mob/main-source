using System.Collections.Generic;
using Helpers.Ranges;
using UnityEngine;

namespace Restory.Data.ObjectPool
{
	public class ObjectPoolSettings : ScriptableObject
	{
		[SerializeField]
		private int defaultMaxOffset = 5;

		[SerializeField]
		private bool autoExpand;

		[SerializeField]
		private int maxInstantiateObjectsPerFrame = 100;

		[SerializeField]
		private List<ObjectPoolItem> prewarmItems;

		public int MaxInstantiateCountPerFrame => maxInstantiateObjectsPerFrame;

		public bool AutoExpand => autoExpand;

		public IReadOnlyCollection<ObjectPoolItem> PrewarmItems => prewarmItems;

		public void ExpandPrewarmItem(GameObject prefab)
		{
			if (!TryGetItemData(prefab, out var result))
			{
				result = new ObjectPoolItem
				{
					Prefab = prefab,
					Size = new IntRange(0, defaultMaxOffset)
				};
				prewarmItems.Add(result);
			}
			result.Size.Max++;
			result.Size.Min++;
		}

		public int GetMaxPoolSize(GameObject prefab)
		{
			if (TryGetItemData(prefab, out var result))
			{
				return result.Size.Max;
			}
			return -1;
		}

		private bool TryGetItemData(GameObject prefab, out ObjectPoolItem result)
		{
			for (int i = 0; i < prewarmItems.Count; i++)
			{
				ObjectPoolItem objectPoolItem = prewarmItems[i];
				if (objectPoolItem.Prefab == prefab)
				{
					result = objectPoolItem;
					return true;
				}
			}
			result = null;
			return false;
		}
	}
}
