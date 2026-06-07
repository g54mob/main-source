using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaintsField
{
	[Serializable]
	public class SaintsDictionary<TKey, TValue> : SaintsDictionaryBase<TKey, TValue>
	{
		[SerializeField]
		private List<TKey> _keys = new List<TKey>();

		[SerializeField]
		private List<TValue> _values = new List<TValue>();

		protected override List<TKey> SerializedKeys => _keys;

		protected override List<TValue> SerializedValues => _values;

		public SaintsDictionary()
		{
		}

		public SaintsDictionary(IDictionary<TKey, TValue> dictionary)
		{
			Dictionary = new Dictionary<TKey, TValue>(dictionary);
			foreach (KeyValuePair<TKey, TValue> item in Dictionary)
			{
				_keys.Add(item.Key);
				_values.Add(item.Value);
			}
		}

		public SaintsDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
			foreach (KeyValuePair<TKey, TValue> item in Dictionary)
			{
				_keys.Add(item.Key);
				_values.Add(item.Value);
			}
		}

		public SaintsDictionary(IEqualityComparer<TKey> comparer)
		{
			Dictionary = new Dictionary<TKey, TValue>(comparer);
			foreach (KeyValuePair<TKey, TValue> item in Dictionary)
			{
				_keys.Add(item.Key);
				_values.Add(item.Value);
			}
		}
	}
}
