using System;
using UnityEngine;

namespace PajamaLlama
{
	[Serializable]
	public class WeightedList<T>
	{
		[Serializable]
		public class Entry
		{
			public T Object;

			public float Weight;

			public float WeightThreshold { get; private set; }

			public bool TryEvaluateThreshold(float totalWeight)
			{
				if (Weight == 0f)
				{
					return false;
				}
				totalWeight += Weight;
				WeightThreshold = totalWeight;
				return true;
			}

			public bool TryGetObject(float value, out T obj)
			{
				if (value < WeightThreshold)
				{
					obj = Object;
					return true;
				}
				obj = default(T);
				return false;
			}
		}

		[SerializeField]
		private Entry[] _entries;

		public T ReturnRandom(float progress = 0f)
		{
			using PooledList<Entry> pooledList = PooledList<Entry>.Get(_entries.Length);
			float num = 0f;
			Entry[] entries = _entries;
			foreach (Entry entry in entries)
			{
				if (entry.TryEvaluateThreshold(num))
				{
					num = entry.WeightThreshold;
					pooledList.Add(entry);
				}
			}
			float value = UnityEngine.Random.Range(0f, num);
			foreach (Entry item in pooledList)
			{
				if (item.TryGetObject(value, out var obj))
				{
					return obj;
				}
			}
			throw new NotSupportedException("[WeightedList.ReturnRandom] No Object was returned!");
		}
	}
}
