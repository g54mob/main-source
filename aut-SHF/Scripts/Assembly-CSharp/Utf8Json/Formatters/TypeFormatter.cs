using System;
using System.Text.RegularExpressions;

namespace Utf8Json.Formatters
{
	public sealed class TypeFormatter : IJsonFormatter<Type>, IJsonFormatter
	{
		public static readonly TypeFormatter Default;

		private static readonly Regex SubtractFullNameRegex;

		private bool serializeAssemblyQualifiedName;

		private bool deserializeSubtractAssemblyQualifiedName;

		private bool throwOnError;

		public TypeFormatter()
		{
		}

		public TypeFormatter(bool serializeAssemblyQualifiedName, bool deserializeSubtractAssemblyQualifiedName, bool throwOnError)
		{
		}

		public void Serialize(ref JsonWriter writer, Type value, IJsonFormatterResolver formatterResolver)
		{
		}

		public Type Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
