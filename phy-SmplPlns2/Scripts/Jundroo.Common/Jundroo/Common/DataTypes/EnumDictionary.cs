using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Jundroo.Common.DataTypes
{
	[Serializable]
	public class EnumDictionary<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TKey : Enum
	{
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			private EnumDictionary<TKey, TValue> _dictionary;

			private int _index;

			public KeyValuePair<TKey, TValue> Current
			{
				get
				{
					TKey key = EnumDictionary<TKey, TValue>._keyList[_index];
					return new KeyValuePair<TKey, TValue>(key, _dictionary[key]);
				}
			}

			object IEnumerator.Current
			{
				get
				{
					TKey key = EnumDictionary<TKey, TValue>._keyList[_index];
					return new KeyValuePair<TKey, TValue>(key, _dictionary[key]);
				}
			}

			public Enumerator(EnumDictionary<TKey, TValue> dictionary)
			{
				_dictionary = dictionary;
				_index = -1;
			}

			public void Dispose()
			{
				_dictionary = null;
			}

			public bool MoveNext()
			{
				return ++_index < EnumDictionary<TKey, TValue>._keyList.Length;
			}

			public void Reset()
			{
				_index = -1;
			}
		}

		private static TKey[] _keyList = (from TKey x in Enum.GetValues(typeof(TKey))
			orderby x
			select x).ToArray();

		[SerializeField]
		private readonly TValue[] _array;

		public int Count => _keyList.Length;

		public ICollection<TKey> Keys => _keyList;

		public ICollection<TValue> Values => _array;

		public TValue this[TKey key]
		{
			get
			{
				return _array[Convert.ToInt32(key)];
			}
			set
			{
				_array[Convert.ToInt32(key)] = value;
			}
		}

		public EnumDictionary()
		{
			_array = new TValue[Convert.ToInt32(_keyList[_keyList.Length - 1]) + 1];
		}

		public EnumDictionary(Func<TKey, TValue> initialValueFunction)
			: this()
		{
			TKey[] keyList = _keyList;
			foreach (TKey val in keyList)
			{
				_array[Convert.ToInt32(val)] = initialValueFunction(val);
			}
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}
	}
}
