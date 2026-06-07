using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LightJson.Serialization;

namespace LightJson
{
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(JsonArrayDebugView))]
	public sealed class JsonArray : IEnumerable<JsonValue>, IEnumerable
	{
		private class JsonArrayDebugView
		{
			private JsonArray jsonArray;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public JsonValue[] Items
			{
				get
				{
					JsonValue[] array = new JsonValue[jsonArray.Count];
					for (int i = 0; i < jsonArray.Count; i++)
					{
						array[i] = jsonArray[i];
					}
					return array;
				}
			}

			public JsonArrayDebugView(JsonArray jsonArray)
			{
				this.jsonArray = jsonArray;
			}
		}

		private IList<JsonValue> items;

		public int Count => items.Count;

		public JsonValue this[int index]
		{
			get
			{
				if (index >= 0 && index < items.Count)
				{
					return items[index];
				}
				return JsonValue.Null;
			}
			set
			{
				items[index] = value;
			}
		}

		public JsonArray()
		{
			items = new List<JsonValue>();
		}

		public JsonArray(params JsonValue[] values)
			: this()
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			foreach (JsonValue item in values)
			{
				items.Add(item);
			}
		}

		public JsonArray Add(JsonValue value)
		{
			items.Add(value);
			return this;
		}

		public JsonArray AddIfNotNull(JsonValue value)
		{
			if (!value.IsNull)
			{
				Add(value);
			}
			return this;
		}

		public JsonArray Insert(int index, JsonValue value)
		{
			items.Insert(index, value);
			return this;
		}

		public JsonArray InsertIfNotNull(int index, JsonValue value)
		{
			if (!value.IsNull)
			{
				Insert(index, value);
			}
			return this;
		}

		public JsonArray Remove(int index)
		{
			items.RemoveAt(index);
			return this;
		}

		public JsonArray Clear()
		{
			items.Clear();
			return this;
		}

		public bool Contains(JsonValue item)
		{
			return items.Contains(item);
		}

		public int IndexOf(JsonValue item)
		{
			return items.IndexOf(item);
		}

		public IEnumerator<JsonValue> GetEnumerator()
		{
			return items.GetEnumerator();
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
