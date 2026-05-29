using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	public class PercentageList<T> : IEnumerable<PercentageList<T>.ChancePair>, IEnumerable, ISerializationCallbackReceiver
	{
		[Serializable]
		public struct ChancePair : IEquatable<ChancePair>, IEquatable<T>
		{
			public float Chance;

			public T Value;

			public bool Equals(ChancePair other)
			{
				return EqualityComparer<T>.Default.Equals(Value, other.Value);
			}

			public bool Equals(T other)
			{
				return EqualityComparer<T>.Default.Equals(Value, other);
			}
		}

		[SerializeField]
		private float _max = 100f;

		[SerializeField]
		private List<ChancePair> _list = new List<ChancePair>();

		public int Count => _list.Count;

		public bool RemoveAndWeight(T obj)
		{
			int count = _list.Count;
			float num = 0f;
			for (int i = 0; i < _list.Count; i++)
			{
				ChancePair chancePair = _list[i];
				if (chancePair.Equals(obj))
				{
					num = chancePair.Chance;
					_list.RemoveAt(i);
					break;
				}
			}
			if (count == _list.Count)
			{
				return false;
			}
			if (_list.Count == 0)
			{
				return true;
			}
			num /= (float)_list.Count;
			for (int j = 0; j < _list.Count; j++)
			{
				ChancePair value = _list[j];
				value.Chance += num;
				_list[j] = value;
			}
			return true;
		}

		public T GetWeightedRandom()
		{
			return Get(UnityEngine.Random.value);
		}

		public T Get(float unitIntervalChance)
		{
			if (Count <= 0)
			{
				return default(T);
			}
			float num = unitIntervalChance * _max;
			float num2 = 0f;
			foreach (ChancePair item in _list)
			{
				num2 += item.Chance;
				if (num <= num2)
				{
					return item.Value;
				}
			}
			List<ChancePair> list = _list;
			return list[list.Count - 1].Value;
		}

		public bool TryGetWeightedRandom(out T outData)
		{
			if (Count <= 0)
			{
				outData = default(T);
				return false;
			}
			outData = GetWeightedRandom();
			return true;
		}

		public bool TryGet(float unitIntervalChance, out T outData)
		{
			if (Count <= 0)
			{
				outData = default(T);
				return false;
			}
			outData = Get(unitIntervalChance);
			return true;
		}

		public List<ChancePair>.Enumerator GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		IEnumerator<ChancePair> IEnumerable<ChancePair>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
