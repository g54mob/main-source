using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Amazon.Runtime.Endpoints
{
	public class PropertyBag : IPropertyBag
	{
		private Dictionary<string, object> properties = new Dictionary<string, object>();

		public object this[string propertyName]
		{
			get
			{
				if (properties.TryGetValue(propertyName, out var value))
				{
					return value;
				}
				return null;
			}
			set
			{
				properties[propertyName] = value;
			}
		}

		internal static PropertyBag FromJsonElement(JsonElement jsonData)
		{
			PropertyBag propertyBag = new PropertyBag();
			foreach (JsonProperty item in jsonData.EnumerateObject())
			{
				propertyBag[item.Name] = ElementToValue(item.Value);
			}
			return propertyBag;
		}

		private static object ElementToValue(JsonElement element)
		{
			int value;
			long value2;
			uint value3;
			ulong value4;
			return element.ValueKind switch
			{
				JsonValueKind.String => element.GetString(), 
				JsonValueKind.Number => element.TryGetInt32(out value) ? ((double)value) : (element.TryGetInt64(out value2) ? ((double)value2) : (element.TryGetUInt32(out value3) ? ((double)value3) : (element.TryGetUInt64(out value4) ? ((double)value4) : element.GetDouble()))), 
				JsonValueKind.True => true, 
				JsonValueKind.False => false, 
				JsonValueKind.Object => FromJsonElement(element), 
				JsonValueKind.Array => ParseJsonArray(element), 
				_ => throw new ArgumentException("Unsupported JSON value type."), 
			};
		}

		private static List<object> ParseJsonArray(JsonElement element)
		{
			List<object> list = new List<object>();
			foreach (JsonElement item in element.EnumerateArray())
			{
				list.Add(ElementToValue(item));
			}
			return list;
		}
	}
}
