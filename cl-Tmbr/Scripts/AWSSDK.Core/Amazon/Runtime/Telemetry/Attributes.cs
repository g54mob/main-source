using System.Collections.Generic;

namespace Amazon.Runtime.Telemetry
{
	public class Attributes
	{
		private readonly Dictionary<string, object> _attributes;

		public IEnumerable<KeyValuePair<string, object>> AllAttributes => _attributes;

		public Attributes()
		{
			_attributes = new Dictionary<string, object>();
		}

		public Attributes(IEnumerable<KeyValuePair<string, object>> attributes)
		{
			_attributes = new Dictionary<string, object>();
			foreach (KeyValuePair<string, object> attribute in attributes)
			{
				_attributes[attribute.Key] = attribute.Value;
			}
		}

		public void Set(string key, object value)
		{
			_attributes[key] = value;
		}

		public object Get(string key)
		{
			_attributes.TryGetValue(key, out var value);
			return value;
		}

		public bool Remove(string key)
		{
			return _attributes.Remove(key);
		}
	}
}
