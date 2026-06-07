using System;
using System.Collections;
using System.Collections.Generic;

namespace Borodar.FarlandSkies.Core.Json
{
	public sealed class JsonArrayNode : JsonNode, IList<JsonNode>, ICollection<JsonNode>, IEnumerable<JsonNode>, IEnumerable
	{
		private readonly List<JsonNode> nodes;

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

		bool ICollection<JsonNode>.IsReadOnly => false;

		public static JsonArrayNode FromArray<T>(T[] array)
		{
			return null;
		}

		public static JsonArrayNode FromCollection(IEnumerable collection)
		{
			return null;
		}

		public JsonArrayNode()
		{
		}

		public JsonArrayNode(int length)
		{
		}

		public JsonArrayNode(JsonNode[] nodes)
		{
		}

		public JsonArrayNode(IEnumerable<JsonNode> collection)
		{
		}

		public int IndexOf(JsonNode item)
		{
			return 0;
		}

		public void Insert(int index, JsonNode item)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public void Add(JsonNode item)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(JsonNode item)
		{
			return false;
		}

		public void CopyTo(JsonNode[] array, int arrayIndex)
		{
		}

		public bool Remove(JsonNode item)
		{
			return false;
		}

		public IEnumerator<JsonNode> GetEnumerator()
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
