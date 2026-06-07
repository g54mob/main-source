using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace MoreMountains.Tools
{
	[Serializable]
	public class MMSerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField]
		protected List<TKey> _keys = new List<TKey>();

		[SerializeField]
		protected List<TValue> _values = new List<TValue>();

		public MMSerializableDictionary()
		{
		}

		public MMSerializableDictionary(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public void OnBeforeSerialize()
		{
			_keys.Clear();
			_values.Clear();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<TKey, TValue> current = enumerator.Current;
				_keys.Add(current.Key);
				_values.Add(current.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			Clear();
			if (_keys.Count != _values.Count)
			{
				Debug.LogError("MMSerializableDictionary : there are " + _keys.Count + " keys and " + _values.Count + " values after deserialization. Counts need to match, make sure both key and value types are serializable.");
			}
			for (int i = 0; i < _keys.Count; i++)
			{
				Add(_keys[i], _values[i]);
			}
		}
	}
}
