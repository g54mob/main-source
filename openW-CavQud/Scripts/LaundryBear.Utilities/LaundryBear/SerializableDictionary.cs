using System;
using System.Collections.Generic;
using UnityEngine;

namespace LaundryBear
{
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[Serializable]
		public class Entry
		{
			[SerializeField]
			internal TKey m_key;

			[SerializeField]
			internal TValue m_value;

			public TKey Key => m_key;

			public TValue Value => m_value;
		}

		public delegate bool Predicate(TValue value);

		[SerializeField]
		private List<Entry> m_entries = new List<Entry>();

		public SerializableDictionary(IEqualityComparer<TKey> keyComparer)
			: base(keyComparer)
		{
		}

		public void OnAfterDeserialize()
		{
			for (int i = 0; i < m_entries.Count; i++)
			{
				Entry entry = m_entries[i];
				base[entry.Key] = entry.Value;
			}
		}

		public void OnBeforeSerialize()
		{
			m_entries.Clear();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<TKey, TValue> current = enumerator.Current;
				m_entries.Add(new Entry
				{
					m_key = current.Key,
					m_value = current.Value
				});
			}
		}

		public bool TryFindValue(Predicate predicate, out TValue result)
		{
			foreach (TValue value in base.Values)
			{
				if (predicate(value))
				{
					result = value;
					return true;
				}
			}
			result = default(TValue);
			return false;
		}
	}
}
