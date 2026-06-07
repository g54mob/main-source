using System;
using System.Collections;
using System.IO;
using Borodar.FarlandSkies.Core.Json.Serialization;

namespace Borodar.FarlandSkies.Core.Json
{
	public abstract class JsonNode : ICloneable
	{
		public static JsonNode ReadFrom(string json)
		{
			return null;
		}

		public static JsonNode ReadFrom(Stream stream)
		{
			return null;
		}

		public static JsonNode ReadFrom(TextReader reader)
		{
			return null;
		}

		public static JsonNode ConvertFrom(object value)
		{
			return null;
		}

		private static JsonObjectNode FromDictionaryStyleCollection(ICollection collection, MetaType metaType)
		{
			return null;
		}

		object ICloneable.Clone()
		{
			return null;
		}

		public abstract JsonNode Clone();

		public abstract object ConvertTo(Type type);

		public T ConvertTo<T>()
		{
			return default(T);
		}

		public override string ToString()
		{
			return null;
		}

		public abstract void Write(IJsonWriter writer);
	}
}
