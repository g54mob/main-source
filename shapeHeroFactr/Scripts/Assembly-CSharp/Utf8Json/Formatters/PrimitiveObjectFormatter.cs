using System;
using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public sealed class PrimitiveObjectFormatter : IJsonFormatter<object>, IJsonFormatter
	{
		public static readonly IJsonFormatter<object> Default;

		private static readonly Dictionary<Type, int> typeToJumpCode;

		public void Serialize(ref JsonWriter writer, object value, IJsonFormatterResolver formatterResolver)
		{
		}

		public object Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
