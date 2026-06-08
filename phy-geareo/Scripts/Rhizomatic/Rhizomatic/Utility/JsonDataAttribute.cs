using System;
using Newtonsoft.Json.Linq;

namespace Rhizomatic.Utility
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class JsonDataAttribute : Attribute
	{
		public readonly string key;

		public readonly object defaultValue;

		public readonly bool hasDefaultValue;

		public readonly Func<object, object> serializer;

		public readonly Action<object, JsonData.Member, JToken> deserializer;

		public JsonDataAttribute(string key, object defaultValue, bool hasDefaultValue, Func<object, object> serializer, Action<object, JsonData.Member, JToken> deserializer)
		{
		}

		public JsonDataAttribute()
		{
		}

		public JsonDataAttribute(string key)
		{
		}

		public JsonDataAttribute(object defaultValue, string key = "")
		{
		}
	}
}
