using System.Collections;
using System.Collections.Generic;
using LightJson.Serialization;

namespace LightJson
{
	public sealed class JsonObject : IEnumerable<KeyValuePair<string, JsonValue>>, IEnumerable, IEnumerable<JsonValue>
	{
		private IDictionary<string, JsonValue> properties;

		public int Count => properties.Count;

		public JsonValue this[string key]
		{
			get
			{
				if (properties.TryGetValue(key, out var value))
				{
					return value;
				}
				return JsonValue.Null;
			}
			set
			{
				properties[key] = value;
			}
		}

		public JsonObject()
		{
			properties = new Dictionary<string, JsonValue>();
		}

		public JsonObject Add(string key)
		{
			return Add(key, JsonValue.Null);
		}

		public JsonObject Add(string key, JsonValue value)
		{
			properties.Add(key, value);
			return this;
		}

		public JsonObject AddIfNotNull(string key, JsonValue value)
		{
			if (!value.IsNull)
			{
				Add(key, value);
			}
			return this;
		}

		public bool Remove(string key)
		{
			return properties.Remove(key);
		}

		public JsonObject Clear()
		{
			properties.Clear();
			return this;
		}

		public JsonObject Rename(string oldKey, string newKey)
		{
			if (properties.TryGetValue(oldKey, out var value))
			{
				Remove(oldKey);
				this[newKey] = value;
			}
			return this;
		}

		public bool ContainsKey(string key)
		{
			return properties.ContainsKey(key);
		}

		public bool Contains(JsonValue value)
		{
			return properties.Values.Contains(value);
		}

		public IEnumerator<KeyValuePair<string, JsonValue>> GetEnumerator()
		{
			return properties.GetEnumerator();
		}

		IEnumerator<JsonValue> IEnumerable<JsonValue>.GetEnumerator()
		{
			return properties.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			return ToString(pretty: false);
		}

		public string ToString(bool pretty)
		{
			using JsonWriter jsonWriter = new JsonWriter(pretty);
			return jsonWriter.Serialize(this);
		}
	}
}
