using System;
using System.Collections.Concurrent;
using System.Reflection;
using Newtonsoft.Json;

namespace FractureField
{
	public class RefConverter : JsonConverter
	{
		private static readonly ConcurrentDictionary<Type, bool> _canConvertCache;

		private static readonly ConcurrentDictionary<Type, PropertyInfo> _valuePropertyCache;

		private static readonly ConcurrentDictionary<Type, ConstructorInfo> _constructorCache;

		public override bool CanConvert(Type objectType)
		{
			return false;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		}
	}
}
