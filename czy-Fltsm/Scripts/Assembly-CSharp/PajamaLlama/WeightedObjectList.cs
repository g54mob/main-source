using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama
{
	[Serializable]
	public class WeightedObjectList
	{
		public enum Mode
		{
			Value = 0,
			Range = 1,
			Curve = 2
		}

		[Serializable]
		public class Entry
		{
			public UnityEngine.Object Object;

			public float Weight;

			public float WeightTo;

			[Range(0f, 1f)]
			public float ActiveThreshold;

			public AnimationCurve WeightCurve;

			public float WeightThreshold { get; private set; }

			public bool TryEvaluateThreshold(Mode mode, float time, float totalWeight)
			{
				float num = Weight;
				switch (mode)
				{
				case Mode.Range:
					num = ((!(time < ActiveThreshold)) ? Mathf.Lerp(Weight, WeightTo, (time - ActiveThreshold) / (1f - ActiveThreshold)) : 0f);
					break;
				case Mode.Curve:
					num = WeightCurve.Evaluate(time);
					break;
				}
				if (num == 0f)
				{
					return false;
				}
				totalWeight += num;
				WeightThreshold = totalWeight;
				return true;
			}

			public bool TryGetObject(float value, out UnityEngine.Object obj)
			{
				if (value < WeightThreshold)
				{
					obj = Object;
					return true;
				}
				obj = null;
				return false;
			}
		}

		[SerializeField]
		private Mode _mode;

		[SerializeField]
		private bool _useCachedList;

		[SerializeField]
		private Entry[] _entries;

		public bool TryReturnRandom<T>(out T obj, float progress = 0f) where T : UnityEngine.Object
		{
			obj = ReturnRandom(progress) as T;
			return obj != null;
		}

		public UnityEngine.Object ReturnRandom(float progress = 0f)
		{
			using PooledList<Entry> pooledList = PooledList<Entry>.Get(_entries.Length);
			float num = 0f;
			Entry[] entries = _entries;
			foreach (Entry entry in entries)
			{
				if (entry.TryEvaluateThreshold(_mode, progress, num))
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

		public void ReturnObjectList<T>(List<T> objectList) where T : UnityEngine.Object
		{
			Entry[] entries = _entries;
			for (int i = 0; i < entries.Length; i++)
			{
				if (entries[i].Object is T itemToAdd)
				{
					objectList.AddUnique(itemToAdd);
				}
			}
		}
	}
}
