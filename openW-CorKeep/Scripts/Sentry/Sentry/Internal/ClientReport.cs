using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Internal
{
	internal class ClientReport : ISentryJsonSerializable
	{
		public DateTimeOffset Timestamp { get; }

		public IReadOnlyDictionary<DiscardReasonWithCategory, int> DiscardedEvents { get; }

		public ClientReport(DateTimeOffset timestamp, IReadOnlyDictionary<DiscardReasonWithCategory, int> discardedEvents)
		{
			Timestamp = timestamp;
			DiscardedEvents = discardedEvents;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("timestamp", Timestamp);
			writer.WriteStartArray("discarded_events");
			foreach (KeyValuePair<DiscardReasonWithCategory, int> item in from x in DiscardedEvents
				where x.Value > 0
				orderby x.Key.Reason, x.Key.Category
				select x)
			{
				writer.WriteStartObject();
				writer.WriteString("reason", item.Key.Reason);
				writer.WriteString("category", item.Key.Category);
				writer.WriteNumber("quantity", item.Value);
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
			writer.WriteEndObject();
		}

		public static ClientReport FromJson(JsonElement json)
		{
			DateTimeOffset dateTimeOffset = json.GetProperty("timestamp").GetDateTimeOffset();
			Dictionary<DiscardReasonWithCategory, int> discardedEvents = (from x in json.GetProperty("discarded_events").EnumerateArray()
				select new
				{
					Reason = x.GetProperty("reason").GetString(),
					Category = x.GetProperty("category").GetString(),
					Quantity = x.GetProperty("quantity").GetInt32()
				}).ToDictionary(x => new DiscardReasonWithCategory(x.Reason, x.Category), x => x.Quantity);
			return new ClientReport(dateTimeOffset, discardedEvents);
		}
	}
}
