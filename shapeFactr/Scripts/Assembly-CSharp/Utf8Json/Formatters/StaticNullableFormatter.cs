using System;

namespace Utf8Json.Formatters
{
	public sealed class StaticNullableFormatter<T> : IJsonFormatter<T?>, IJsonFormatter where T : struct
	{
		private readonly IJsonFormatter<T> underlyingFormatter;

		public StaticNullableFormatter(IJsonFormatter<T> underlyingFormatter)
		{
		}

		public StaticNullableFormatter(Type formatterType, object[] formatterArguments)
		{
		}

		public void Serialize(ref JsonWriter writer, T? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public T? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
