using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class HashList<TKey, TValue> : DictionaryBase<TKey, IList<TValue>>
	{
		public int ValueCount
		{
			get
			{
				int num = 0;
				using (Dictionary<TKey, IList<TValue>>.Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<TKey, IList<TValue>> current = enumerator.Current;
						if (current.Value != null)
						{
							num += current.Value.Count;
						}
					}
					return num;
				}
			}
		}

		public int KeyCount
		{
			get
			{
				return base.Count;
			}
		}

		public HashList()
		{
		}

		public HashList(IDictionary<TKey, IList<TValue>> dictionary)
			: base(dictionary)
		{
		}

		public HashList(IEqualityComparer<TKey> comparer)
			: base(comparer)
		{
		}

		public HashList(int capacity)
			: base(capacity)
		{
		}

		public HashList(int capacity, IEqualityComparer<TKey> comparer)
			: base(capacity, comparer)
		{
		}

		protected HashList(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public IEnumerator<TValue> GetValueEnumerator()
		{
			using (Dictionary<TKey, IList<TValue>>.Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IList<TValue> value = enumerator.Current.Value;
					if (value != null)
					{
						for (int i = 0; i < value.Count; i++)
						{
							yield return value[i];
						}
					}
				}
			}
		}

		public void Add(TKey key, TValue value)
		{
			AddItem(new KeyValuePair<TKey, TValue>(key, value));
		}

		public virtual void AddItem(KeyValuePair<TKey, TValue> item)
		{
			IList<TValue> value;
			if (!TryGetValue(item.Key, out value))
			{
				value = new List<TValue>();
				base[item.Key] = value;
			}
			value.Add(item.Value);
		}

		public void Add(TKey key, params TValue[] values)
		{
			Add(key, new List<TValue>(values));
		}

		protected override void AddItem(TKey key, IList<TValue> value)
		{
			Guard.ArgumentNotNull(value, "value");
			IList<TValue> value2;
			if (!TryGetValue(key, out value2))
			{
				value2 = (base[key] = new List<TValue>());
			}
			((List<TValue>)value2).AddRange(value);
		}

		public bool RemoveValue(TValue item)
		{
			return RemoveValueItem(item);
		}

		protected virtual bool RemoveValueItem(TValue item)
		{
			IList<TKey> list = new List<TKey>(base.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				if (base[list[i]].Remove(item))
				{
					return true;
				}
			}
			return false;
		}

		public void RemoveAll(TValue item)
		{
			RemoveAllItems(item);
		}

		protected virtual void RemoveAllItems(TValue item)
		{
			IList<TKey> list = new List<TKey>(base.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				IList<TValue> list2 = base[list[i]];
				if (list2 == null)
				{
					continue;
				}
				for (int j = 0; j < list2.Count; j++)
				{
					if (list2[j].Equals(item))
					{
						list2.RemoveAt(j);
						j--;
					}
				}
			}
		}

		public bool Remove(TKey key, TValue item)
		{
			return RemoveItem(key, item);
		}

		protected virtual bool RemoveItem(TKey key, TValue item)
		{
			IList<TValue> value;
			if (TryGetValue(key, out value))
			{
				return value.Remove(item);
			}
			return false;
		}
	}
}
