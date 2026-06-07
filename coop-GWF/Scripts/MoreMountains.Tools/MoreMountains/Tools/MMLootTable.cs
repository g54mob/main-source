using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMLootTable<T, V> where T : MMLoot<V>
	{
		[SerializeField]
		public List<T> ObjectsToLoot;

		[Header("Debug")]
		[MMReadOnly]
		public float WeightsTotal;

		protected float _maximumWeightSoFar;

		protected bool _weightsComputed;

		private float GetSeededRandomRange(float min, float max)
		{
			try
			{
				Type type = Type.GetType("SeededRandomManager");
				if (type != null)
				{
					PropertyInfo property = type.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public);
					if (property != null)
					{
						object value = property.GetValue(null);
						if (value != null)
						{
							MethodInfo method = type.GetMethod("Range", new Type[2]
							{
								typeof(float),
								typeof(float)
							});
							if (method != null)
							{
								return (float)method.Invoke(value, new object[2] { min, max });
							}
						}
					}
				}
			}
			catch
			{
			}
			return UnityEngine.Random.Range(min, max);
		}

		public virtual void ComputeWeights()
		{
			if (ObjectsToLoot == null || ObjectsToLoot.Count == 0)
			{
				return;
			}
			_maximumWeightSoFar = 0f;
			foreach (T item in ObjectsToLoot)
			{
				if (item.Weight >= 0f)
				{
					item.RangeFrom = _maximumWeightSoFar;
					_maximumWeightSoFar += item.Weight;
					item.RangeTo = _maximumWeightSoFar;
				}
				else
				{
					item.Weight = 0f;
				}
			}
			WeightsTotal = _maximumWeightSoFar;
			foreach (T item2 in ObjectsToLoot)
			{
				item2.ChancePercentage = item2.Weight / WeightsTotal * 100f;
			}
			_weightsComputed = true;
		}

		public virtual T GetLoot()
		{
			if (ObjectsToLoot == null)
			{
				return null;
			}
			if (ObjectsToLoot.Count == 0)
			{
				return null;
			}
			if (!_weightsComputed)
			{
				ComputeWeights();
			}
			float seededRandomRange = GetSeededRandomRange(0f, WeightsTotal);
			foreach (T item in ObjectsToLoot)
			{
				if (seededRandomRange > item.RangeFrom && seededRandomRange < item.RangeTo)
				{
					return item;
				}
			}
			return null;
		}
	}
}
