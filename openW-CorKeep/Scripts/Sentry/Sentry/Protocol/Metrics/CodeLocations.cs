using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol.Metrics
{
	internal class CodeLocations : ISentryJsonSerializable
	{
		public long Timestamp => _003Ctimestamp_003EP;

		public CodeLocations(long timestamp, IReadOnlyDictionary<MetricResourceIdentifier, SentryStackFrame> locations)
		{
			_003Ctimestamp_003EP = timestamp;
			_003Clocations_003EP = locations;
			base._002Ector();
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteNumber("timestamp", Timestamp);
			Dictionary<string, SentryStackFrame> dictionary = _003Clocations_003EP.ToDictionary<KeyValuePair<MetricResourceIdentifier, SentryStackFrame>, string, SentryStackFrame>((KeyValuePair<MetricResourceIdentifier, SentryStackFrame> kvp) => kvp.Key.ToString(), delegate(KeyValuePair<MetricResourceIdentifier, SentryStackFrame> kvp)
			{
				SentryStackFrame value = kvp.Value;
				value.IsCodeLocation = true;
				return value;
			});
			writer.WritePropertyName("mapping");
			writer.WriteStartObject();
			foreach (var (propertyName, sentryStackFrame2) in dictionary)
			{
				writer.WriteArray(propertyName, new SentryStackFrame[1] { sentryStackFrame2 }, logger);
			}
			writer.WriteEndObject();
			writer.WriteEndObject();
		}
	}
}
