using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	public class SerializeReferenceDictionary<TKey, TValue> : SerializableDictionaryBase<TKey, TValue>
	{
		[Serializable]
		public struct KeyValuePair
		{
			public TKey Key;

			[SerializeReference]
			public TValue Value;

			public KeyValuePair(TKey key, TValue value)
			{
				Key = key;
				Value = value;
			}
		}

		[SerializeField]
		private List<KeyValuePair> _list = new List<KeyValuePair>();

		protected override TKey GetKeyAtIndex(int index)
		{
			return _list[index].Key;
		}

		protected override TValue GetValueAtIndex(int index)
		{
			return _list[index].Value;
		}

		protected override int GetListCount()
		{
			return _list.Count;
		}

		protected override void SetKeyAndValueAtIndex(int index, TKey key, TValue value)
		{
			_list[index] = new KeyValuePair(key, value);
		}

		protected override void AddKeyAndValue(TKey key, TValue value)
		{
			_list.Add(new KeyValuePair(key, value));
		}

		protected override void RemoveAtIndex(int index)
		{
			_list.RemoveAt(index);
		}

		protected override void ClearList()
		{
			_list.Clear();
		}
	}
}
