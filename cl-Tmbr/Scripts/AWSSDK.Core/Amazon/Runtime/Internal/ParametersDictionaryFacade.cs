using System;
using System.Collections;
using System.Collections.Generic;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal
{
	public class ParametersDictionaryFacade : IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable
	{
		private readonly ParameterCollection _parameterCollection;

		public int Count => _parameterCollection.Count;

		public string this[string key]
		{
			get
			{
				return ParameterValueToString(_parameterCollection[key]);
			}
			set
			{
				if (_parameterCollection.TryGetValue(key, out var value2))
				{
					UpdateParameterValue(value2, value);
				}
				else
				{
					value2 = new StringParameterValue(value);
				}
				_parameterCollection[key] = value2;
			}
		}

		public ICollection<string> Keys => _parameterCollection.Keys;

		public ICollection<string> Values
		{
			get
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, ParameterValue> item2 in _parameterCollection)
				{
					string item = ParameterValueToString(item2.Value);
					list.Add(item);
				}
				return list;
			}
		}

		public bool IsReadOnly => ((IDictionary)_parameterCollection).IsReadOnly;

		public ParametersDictionaryFacade(ParameterCollection collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			_parameterCollection = collection;
		}

		private static string ParameterValueToString(ParameterValue pv)
		{
			if (pv == null)
			{
				throw new ArgumentNullException("pv");
			}
			StringParameterValue stringParameterValue = pv as StringParameterValue;
			StringListParameterValue stringListParameterValue = pv as StringListParameterValue;
			if (stringParameterValue != null)
			{
				return stringParameterValue.Value;
			}
			if (stringListParameterValue != null)
			{
				return JsonSerializerHelper.Serialize<List<string>>(stringListParameterValue.Value, JsonSerializerContext.Default);
			}
			throw new AmazonClientException("Unexpected parameter value type " + pv.GetType().FullName);
		}

		private static void UpdateParameterValue(ParameterValue pv, string newValue)
		{
			if (pv == null)
			{
				throw new ArgumentNullException("pv");
			}
			StringParameterValue stringParameterValue = pv as StringParameterValue;
			StringListParameterValue stringListParameterValue = pv as StringListParameterValue;
			if (stringParameterValue != null)
			{
				stringParameterValue.Value = newValue;
				return;
			}
			if (stringListParameterValue != null)
			{
				List<string> value = JsonSerializerHelper.Deserialize<List<string>>(newValue, JsonSerializerContext.Default);
				stringListParameterValue.Value = value;
				return;
			}
			throw new AmazonClientException("Unexpected parameter value type " + pv.GetType().FullName);
		}

		public void Add(string key, string value)
		{
			_parameterCollection.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return _parameterCollection.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return _parameterCollection.Remove(key);
		}

		public bool TryGetValue(string key, out string value)
		{
			if (_parameterCollection.TryGetValue(key, out var value2))
			{
				value = ParameterValueToString(value2);
				return true;
			}
			value = null;
			return false;
		}

		public bool Remove(KeyValuePair<string, string> item)
		{
			if (Contains(item))
			{
				return _parameterCollection.Remove(item.Key);
			}
			return false;
		}

		public void Add(KeyValuePair<string, string> item)
		{
			StringParameterValue value = new StringParameterValue(item.Value);
			_parameterCollection.Add(item.Key, value);
		}

		public bool Contains(KeyValuePair<string, string> item)
		{
			string key = item.Key;
			string value = item.Value;
			if (_parameterCollection.TryGetValue(key, out var value2))
			{
				return string.Equals(ParameterValueToString(value2), value, StringComparison.Ordinal);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0 || arrayIndex > array.Length)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (array.Length - arrayIndex < _parameterCollection.Count)
			{
				throw new ArgumentOutOfRangeException("arrayIndex", "Not enough space in target array");
			}
			using IEnumerator<KeyValuePair<string, string>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, string> current = enumerator.Current;
				array[arrayIndex++] = current;
			}
		}

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			foreach (KeyValuePair<string, ParameterValue> item in _parameterCollection)
			{
				string key = item.Key;
				string value = ParameterValueToString(item.Value);
				yield return new KeyValuePair<string, string>(key, value);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Clear()
		{
			_parameterCollection.Clear();
		}
	}
}
