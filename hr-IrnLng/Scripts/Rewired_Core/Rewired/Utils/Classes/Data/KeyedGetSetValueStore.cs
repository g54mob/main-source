using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal sealed class KeyedGetSetValueStore<TKey> : IEnumerable, IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>
	{
		private readonly Dictionary<TKey, object> ekhDAugGrLfJMBjXfsQQeGdcIkDE;

		private readonly bool RoygjUAjdNbffAghfhjWHzoARUtA;

		public int Count => ekhDAugGrLfJMBjXfsQQeGdcIkDE.Count;

		public bool isReadOnlyCollection => RoygjUAjdNbffAghfhjWHzoARUtA;

		ICollection<TKey> IDictionary<TKey, object>.Keys => ekhDAugGrLfJMBjXfsQQeGdcIkDE.Keys;

		ICollection<object> IDictionary<TKey, object>.Values => ekhDAugGrLfJMBjXfsQQeGdcIkDE.Values;

		object IDictionary<TKey, object>.this[TKey key]
		{
			get
			{
				return ekhDAugGrLfJMBjXfsQQeGdcIkDE[key];
			}
			set
			{
				KlYkmqGtnfiHkXFiBnZqEISfKLp();
				ekhDAugGrLfJMBjXfsQQeGdcIkDE[key] = value;
			}
		}

		int ICollection<KeyValuePair<TKey, object>>.Count => ekhDAugGrLfJMBjXfsQQeGdcIkDE.Count;

		bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => RoygjUAjdNbffAghfhjWHzoARUtA;

		public KeyedGetSetValueStore(Dictionary<TKey, object> valueDelegates, bool isReadOnlyCollection)
		{
			ekhDAugGrLfJMBjXfsQQeGdcIkDE = valueDelegates;
			RoygjUAjdNbffAghfhjWHzoARUtA = isReadOnlyCollection;
		}

		public KeyedGetSetValueStore(bool isReadOnlyCollection)
		{
			RoygjUAjdNbffAghfhjWHzoARUtA = isReadOnlyCollection;
			ekhDAugGrLfJMBjXfsQQeGdcIkDE = new Dictionary<TKey, object>();
		}

		public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			KlYkmqGtnfiHkXFiBnZqEISfKLp();
			ekhDAugGrLfJMBjXfsQQeGdcIkDE.Add(key, item);
		}

		public IGetSetValue<TValue> GetItem<TValue>(TKey key)
		{
			if (!ekhDAugGrLfJMBjXfsQQeGdcIkDE.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
			{
				QswQmUBOyEvvDiGMFAgXmaIzCUm(key, typeof(TValue));
				return null;
			}
			return result;
		}

		public bool RemoveItem<TValue>(TKey key)
		{
			KlYkmqGtnfiHkXFiBnZqEISfKLp();
			return ekhDAugGrLfJMBjXfsQQeGdcIkDE.Remove(key);
		}

		public bool ContainsKey(TKey key)
		{
			return ekhDAugGrLfJMBjXfsQQeGdcIkDE.ContainsKey(key);
		}

		public void Clear()
		{
			KlYkmqGtnfiHkXFiBnZqEISfKLp();
			ekhDAugGrLfJMBjXfsQQeGdcIkDE.Clear();
		}

		public bool ContainsValue<TValue>(TKey key)
		{
			if (ekhDAugGrLfJMBjXfsQQeGdcIkDE.TryGetValue(key, out var value))
			{
				return value is IGetSetValue<TValue>;
			}
			return false;
		}

		public TValue GetValue<TValue>(TKey key)
		{
			if (!TryGetValue<TValue>(key, out var value))
			{
				QswQmUBOyEvvDiGMFAgXmaIzCUm(key, typeof(TValue));
			}
			return value;
		}

		public void SetValue<TValue>(TKey key, TValue value)
		{
			if (!TrySetValue(key, value))
			{
				QswQmUBOyEvvDiGMFAgXmaIzCUm(key, typeof(TValue));
			}
		}

		public bool TryGetValue<TValue>(TKey key, out TValue value)
		{
			if (!ekhDAugGrLfJMBjXfsQQeGdcIkDE.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
			{
				value = default(TValue);
				Logger.LogError(fkVyHulsOEPLOjSYzJejjRpaeTg(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			value = getValue.GetValue();
			return true;
		}

		public bool TrySetValue<TValue>(TKey key, TValue value)
		{
			ISetValue<TValue> setValue;
			if (!ekhDAugGrLfJMBjXfsQQeGdcIkDE.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
			{
				Logger.LogError(fkVyHulsOEPLOjSYzJejjRpaeTg(key, typeof(TValue)), requiredThreadSafety: true);
				return false;
			}
			setValue.SetValue(value);
			return true;
		}

		private void KlYkmqGtnfiHkXFiBnZqEISfKLp()
		{
			if (RoygjUAjdNbffAghfhjWHzoARUtA)
			{
				throw new Exception("The collection is read-only.");
			}
		}

		private static void QswQmUBOyEvvDiGMFAgXmaIzCUm(TKey P_0, Type P_1)
		{
			throw new Exception(fkVyHulsOEPLOjSYzJejjRpaeTg(P_0, P_1));
		}

		private static string fkVyHulsOEPLOjSYzJejjRpaeTg(TKey P_0, Type P_1)
		{
			return string.Concat("Value with key ", P_0, " of type ", P_1, " not found.");
		}

		void IDictionary<TKey, object>.Add(TKey key, object value)
		{
			KlYkmqGtnfiHkXFiBnZqEISfKLp();
			ekhDAugGrLfJMBjXfsQQeGdcIkDE.Add(key, value);
		}

		bool IDictionary<TKey, object>.ContainsKey(TKey key)
		{
			return ContainsKey(key);
		}

		bool IDictionary<TKey, object>.Remove(TKey key)
		{
			KlYkmqGtnfiHkXFiBnZqEISfKLp();
			return ekhDAugGrLfJMBjXfsQQeGdcIkDE.Remove(key);
		}

		bool IDictionary<TKey, object>.TryGetValue(TKey key, out object value)
		{
			return ekhDAugGrLfJMBjXfsQQeGdcIkDE.TryGetValue(key, out value);
		}

		void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> item)
		{
			KlYkmqGtnfiHkXFiBnZqEISfKLp();
			((ICollection<KeyValuePair<TKey, object>>)ekhDAugGrLfJMBjXfsQQeGdcIkDE).Add(item);
		}

		void ICollection<KeyValuePair<TKey, object>>.Clear()
		{
			KlYkmqGtnfiHkXFiBnZqEISfKLp();
			((ICollection<KeyValuePair<TKey, object>>)ekhDAugGrLfJMBjXfsQQeGdcIkDE).Clear();
		}

		bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> item)
		{
			return ((ICollection<KeyValuePair<TKey, object>>)ekhDAugGrLfJMBjXfsQQeGdcIkDE).Contains(item);
		}

		void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, object>>)ekhDAugGrLfJMBjXfsQQeGdcIkDE).CopyTo(array, arrayIndex);
		}

		bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> item)
		{
			KlYkmqGtnfiHkXFiBnZqEISfKLp();
			return ((ICollection<KeyValuePair<TKey, object>>)ekhDAugGrLfJMBjXfsQQeGdcIkDE).Remove(item);
		}

		IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
		{
			return ekhDAugGrLfJMBjXfsQQeGdcIkDE.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ekhDAugGrLfJMBjXfsQQeGdcIkDE.GetEnumerator();
		}
	}
}
