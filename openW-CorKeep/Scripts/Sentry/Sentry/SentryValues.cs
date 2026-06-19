using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	internal sealed class SentryValues<T> : ISentryJsonSerializable
	{
		public IEnumerable<T> Values { get; }

		public SentryValues(IEnumerable<T>? values)
		{
			Values = values ?? Enumerable.Empty<T>();
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStartArray("values");
			foreach (T value in Values)
			{
				writer.WriteDynamicValue(value, logger);
			}
			writer.WriteEndArray();
			writer.WriteEndObject();
		}
	}
}
