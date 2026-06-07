using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class SerializableDictionary<SerializedKeyType, SerializedValueType> : ISerializationCallbackReceiver
	{
		private Dictionary<SerializedKeyType, SerializedValueType> _dictionary = new Dictionary<SerializedKeyType, SerializedValueType>();

		[SerializeField]
		private List<SerializedKeyType> _serializedKeys = new List<SerializedKeyType>();

		[SerializeField]
		private List<SerializedValueType> _serializedValues = new List<SerializedValueType>();

		public Dictionary<SerializedKeyType, SerializedValueType> Dictionary => _dictionary;

		public SerializedValueType this[SerializedKeyType index]
		{
			get
			{
				return _dictionary[index];
			}
			set
			{
				_dictionary[index] = value;
			}
		}

		public void OnBeforeSerialize()
		{
			RemoveNullKeys();
			_serializedKeys.Clear();
			_serializedValues.Clear();
			foreach (KeyValuePair<SerializedKeyType, SerializedValueType> item in _dictionary)
			{
				_serializedKeys.Add(item.Key);
				_serializedValues.Add(item.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			_dictionary = new Dictionary<SerializedKeyType, SerializedValueType>();
			int num = Math.Min(_serializedKeys.Count, _serializedValues.Count);
			for (int i = 0; i < num; i++)
			{
				_dictionary.Add(_serializedKeys[i], _serializedValues[i]);
			}
			_serializedKeys.Clear();
			_serializedValues.Clear();
		}

		public void Clear()
		{
			_dictionary.Clear();
		}

		public void Add(SerializedKeyType key, SerializedValueType value)
		{
			_dictionary.Add(key, value);
		}

		public bool ContainsKey(SerializedKeyType key)
		{
			return _dictionary.ContainsKey(key);
		}

		public void Copy(SerializableDictionary<SerializedKeyType, SerializedValueType> other)
		{
			Clear();
			foreach (KeyValuePair<SerializedKeyType, SerializedValueType> item in other.Dictionary)
			{
				_dictionary.Add(item.Key, item.Value);
			}
		}

		public void RemoveNullKeys()
		{
			_dictionary = _dictionary.Where(delegate(KeyValuePair<SerializedKeyType, SerializedValueType> keyValuePair)
			{
				EqualityComparer<SerializedKeyType> equalityComparer = EqualityComparer<SerializedKeyType>.Default;
				KeyValuePair<SerializedKeyType, SerializedValueType> keyValuePair2 = keyValuePair;
				return !equalityComparer.Equals(keyValuePair2.Key, default(SerializedKeyType));
			}).ToDictionary((KeyValuePair<SerializedKeyType, SerializedValueType> keyValuePair) => keyValuePair.Key, (KeyValuePair<SerializedKeyType, SerializedValueType> keyValuePair) => keyValuePair.Value);
		}
	}
}
