// add
using System;
using System.Collections.Generic;
using System.Text;

namespace GptDeepResearch
{
	/// <summary>
	/// Represents a dictionary value in the Python interpreter.
	/// Supports basic dictionary operations with string and numeric keys.
	/// </summary>
	public class DictValue
	{
		private Dictionary<string, object> _data = new Dictionary<string, object>();

		/// <summary>
		/// Get item by key
		/// </summary>
		public object GetItem(object key)
		{
			string keyStr = NormalizeKey(key);
			if (_data.ContainsKey(keyStr))
			{
				return _data[keyStr];
			}
			throw new Exception($"Key '{key}' not found in dictionary");
		}

		/// <summary>
		/// Set item by key
		/// </summary>
		public void SetItem(object key, object value)
		{
			string keyStr = NormalizeKey(key);
			_data[keyStr] = value;
		}

		/// <summary>
		/// Check if key exists
		/// </summary>
		public bool ContainsKey(object key)
		{
			string keyStr = NormalizeKey(key);
			return _data.ContainsKey(keyStr);
		}

		/// <summary>
		/// Get all keys
		/// </summary>
		public List<object> GetKeys()
		{
			List<object> keys = new List<object>();
			foreach (string key in _data.Keys)
			{
				// Try to convert back to original type
				if (double.TryParse(key, out double numKey))
				{
					keys.Add(numKey);
				}
				else
				{
					keys.Add(key);
				}
			}
			return keys;
		}

		/// <summary>
		/// Get all values
		/// </summary>
		public List<object> GetValues()
		{
			return new List<object>(_data.Values);
		}

		/// <summary>
		/// Get count of items
		/// </summary>
		public int Count => _data.Count;

		/// <summary>
		/// Normalize key to string for internal storage
		/// </summary>
		private string NormalizeKey(object key)
		{
			if (key == null)
				throw new Exception("Dictionary key cannot be null");

			if (key is string str)
				return str;

			if (NumericHelpers.IsNumeric(key))
				return NumericHelpers.ToDouble(key).ToString();

			// For other types, use ToString() but warn about limitations
			return key.ToString();
		}

		/// <summary>
		/// String representation
		/// </summary>
		public override string ToString()
		{
			if (_data.Count == 0)
				return "{}";

			StringBuilder sb = new StringBuilder();
			sb.Append("{");
			bool first = true;
			foreach (var kvp in _data)
			{
				if (!first) sb.Append(", ");
				first = false;

				// Format key
				if (double.TryParse(kvp.Key, out double numKey))
				{
					sb.Append(numKey);
				}
				else
				{
					sb.Append($"'{kvp.Key}'");
				}

				sb.Append(": ");

				// Format value
				if (kvp.Value is string valStr)
				{
					sb.Append($"'{valStr}'");
				}
				else if (kvp.Value == null)
				{
					sb.Append("None");
				}
				else
				{
					sb.Append(kvp.Value.ToString());
				}
			}
			sb.Append("}");
			return sb.ToString();
		}
	}
}