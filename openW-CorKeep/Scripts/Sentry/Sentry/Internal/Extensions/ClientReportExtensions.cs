using Sentry.Protocol.Envelopes;

namespace Sentry.Internal.Extensions
{
	internal static class ClientReportExtensions
	{
		public static void RecordDiscardedEvents(this IClientReportRecorder recorder, DiscardReason reason, Envelope envelope)
		{
			foreach (EnvelopeItem item in envelope.Items)
			{
				recorder.RecordDiscardedEvent(reason, item.DataCategory);
				if (item.DataCategory.Equals(DataCategory.Transaction) && item.Payload is JsonSerializable { Source: SentryTransaction source })
				{
					recorder.RecordDiscardedEvent(reason, DataCategory.Span, source.Spans.Count + 1);
				}
			}
		}
	}
}
