using System.Collections.Generic;

namespace TH20
{
	public class HUDSavedState
	{
		private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

		public void Set<T>(string key, T value)
		{
			if (_values.ContainsKey(key))
			{
				_values[key] = value;
			}
			else
			{
				_values.Add(key, value);
			}
		}

		public bool Get<T>(string key, out T value)
		{
			if (_values.ContainsKey(key))
			{
				value = (T)_values[key];
				return true;
			}
			value = default(T);
			return false;
		}
	}
}
