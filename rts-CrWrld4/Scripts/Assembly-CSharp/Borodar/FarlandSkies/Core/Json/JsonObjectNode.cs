using System;
using System.Collections;
using System.Collections.Generic;

namespace Borodar.FarlandSkies.Core.Json
{
	public sealed class JsonObjectNode : JsonNode, IDictionary<string, JsonNode>, ICollection<KeyValuePair<string, JsonNode>>, IEnumerable<KeyValuePair<string, JsonNode>>, IEnumerable
	{
		private readonly Dictionary<string, JsonNode> properties;

		public ICollection<string> Keys => null;

		public ICollection<JsonNode> Values => null;

		public JsonNode Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Count => 0;

		bool ICollection<KeyValuePair<string, JsonNode>>.IsReadOnly => false;

		internal static JsonObjectNode FromInstance(object instance)
		{
			return null;
		}

		public static JsonObjectNode FromDictionary<TValue>(IDictionary<string, TValue> dictionary)
		{
			return null;
		}

		public void Add(string key, JsonNode value)
		{
		}

		public bool ContainsKey(string key)
		{
			return false;
		}

		public bool Remove(string key)
		{
			return false;
		}

		public bool TryGetValue(string key, out JsonNode value)
		{
			value = null;
			return false;
		}

		void ICollection<KeyValuePair<string, JsonNode>>.Add(KeyValuePair<string, JsonNode> item)
		{
		}

		public void Clear()
		{
		}

		bool ICollection<KeyValuePair<string, JsonNode>>.Contains(KeyValuePair<string, JsonNode> item)
		{
			return false;
		}

		void ICollection<KeyValuePair<string, JsonNode>>.CopyTo(KeyValuePair<string, JsonNode>[] array, int arrayIndex)
		{
		}

		bool ICollection<KeyValuePair<string, JsonNode>>.Remove(KeyValuePair<string, JsonNode> item)
		{
			return false;
		}

		public IEnumerator<KeyValuePair<string, JsonNode>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public override JsonNode Clone()
		{
			return null;
		}

		public override object ConvertTo(Type type)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override void Write(IJsonWriter writer)
		{
		}
	}
}
