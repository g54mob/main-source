using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Protocol.Metrics;

namespace Sentry.Protocol.Envelopes
{
	public sealed class Envelope : ISerializable, IDisposable
	{
		private SentryId? _eventId;

		private static readonly IReadOnlyDictionary<string, string?> SdkHeader = new Dictionary<string, string>(2, StringComparer.Ordinal)
		{
			["name"] = SdkVersion.Instance.Name,
			["version"] = SdkVersion.Instance.Version
		}.AsReadOnly();

		private static readonly IReadOnlyDictionary<string, object?> DefaultHeader = new Dictionary<string, object>(1, StringComparer.Ordinal) { ["sdk"] = SdkHeader }.AsReadOnly();

		public IReadOnlyDictionary<string, object?> Header { get; }

		public IReadOnlyList<EnvelopeItem> Items { get; }

		public Envelope(IReadOnlyDictionary<string, object?> header, IReadOnlyList<EnvelopeItem> items)
			: this(null, header, items)
		{
		}

		private Envelope(SentryId? eventId, IReadOnlyDictionary<string, object?> header, IReadOnlyList<EnvelopeItem> items)
		{
			_eventId = eventId;
			Header = header;
			Items = items;
		}

		public SentryId? TryGetEventId()
		{
			IDiagnosticLogger logger = SentrySdk.CurrentOptions?.DiagnosticLogger;
			return TryGetEventId(logger);
		}

		internal SentryId? TryGetEventId(IDiagnosticLogger? logger)
		{
			if (_eventId.HasValue)
			{
				return _eventId;
			}
			if (!Header.TryGetValue("event_id", out object value))
			{
				return null;
			}
			if (value == null)
			{
				logger?.LogError("Header event_id is null");
				return null;
			}
			if (!(value is string input))
			{
				logger?.LogError($"Header event_id has incorrect type: {value.GetType()}");
				return null;
			}
			if (!Guid.TryParse(input, out var result))
			{
				logger?.LogError($"Header event_id is not a GUID: {value}");
				return null;
			}
			if (result == Guid.Empty)
			{
				logger?.LogError("Envelope contains an empty event_id header");
				_eventId = SentryId.Empty;
				return _eventId;
			}
			_eventId = new SentryId(result);
			return _eventId;
		}

		private async Task SerializeHeaderAsync(Stream stream, IDiagnosticLogger? logger, ISystemClock clock, CancellationToken cancellationToken)
		{
			IEnumerable<KeyValuePair<string, object?>> enumerable;
			if (stream.IsFileStream())
			{
				IEnumerable<KeyValuePair<string, object>> header = Header;
				enumerable = header;
			}
			else
			{
				enumerable = Header.Append("sent_at", clock.GetUtcNow());
			}
			IEnumerable<KeyValuePair<string, object>> dic = enumerable;
			Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(stream);
			await using (utf8JsonWriter)
			{
				utf8JsonWriter.WriteDictionaryValue(dic, logger);
				await utf8JsonWriter.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private void SerializeHeader(Stream stream, IDiagnosticLogger? logger, ISystemClock clock)
		{
			IEnumerable<KeyValuePair<string, object?>> enumerable;
			if (stream.IsFileStream())
			{
				IEnumerable<KeyValuePair<string, object>> header = Header;
				enumerable = header;
			}
			else
			{
				enumerable = Header.Append("sent_at", clock.GetUtcNow());
			}
			IEnumerable<KeyValuePair<string, object>> dic = enumerable;
			using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(stream);
			utf8JsonWriter.WriteDictionaryValue(dic, logger);
			utf8JsonWriter.Flush();
		}

		public Task SerializeAsync(Stream stream, IDiagnosticLogger? logger, CancellationToken cancellationToken = default(CancellationToken))
		{
			return SerializeAsync(stream, logger, SystemClock.Clock, cancellationToken);
		}

		internal async Task SerializeAsync(Stream stream, IDiagnosticLogger? logger, ISystemClock clock, CancellationToken cancellationToken = default(CancellationToken))
		{
			await SerializeHeaderAsync(stream, logger, clock, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await stream.WriteNewlineAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			foreach (EnvelopeItem item in Items)
			{
				try
				{
					await item.SerializeAsync(stream, logger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					await stream.WriteNewlineAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception exception)
				{
					logger?.LogWarning(exception, "Failed to serialize envelope item");
				}
			}
		}

		public void Serialize(Stream stream, IDiagnosticLogger? logger)
		{
			Serialize(stream, logger, SystemClock.Clock);
		}

		internal void Serialize(Stream stream, IDiagnosticLogger? logger, ISystemClock clock)
		{
			SerializeHeader(stream, logger, clock);
			stream.WriteNewline();
			foreach (EnvelopeItem item in Items)
			{
				try
				{
					item.Serialize(stream, logger);
					stream.WriteNewline();
				}
				catch (Exception exception)
				{
					logger?.LogWarning(exception, "Failed to serialize envelope item");
				}
			}
		}

		public void Dispose()
		{
			Items.DisposeAll();
		}

		private static Dictionary<string, object?> CreateHeader(SentryId eventId, int extraCapacity = 0)
		{
			return new Dictionary<string, object>(2 + extraCapacity, StringComparer.Ordinal)
			{
				["sdk"] = SdkHeader,
				["event_id"] = eventId.ToString()
			};
		}

		private static Dictionary<string, object?> CreateHeader(SentryId eventId, DynamicSamplingContext? dsc)
		{
			if (dsc == null)
			{
				return CreateHeader(eventId);
			}
			Dictionary<string, object?> dictionary = CreateHeader(eventId, 1);
			dictionary["trace"] = dsc.Items;
			return dictionary;
		}

		public static Envelope FromEvent(SentryEvent @event, IDiagnosticLogger? logger = null, IReadOnlyCollection<SentryAttachment>? attachments = null, SessionUpdate? sessionUpdate = null)
		{
			SentryId eventId = @event.EventId;
			Dictionary<string, object> header = CreateHeader(eventId, @event.DynamicSamplingContext);
			List<EnvelopeItem> list = new List<EnvelopeItem> { EnvelopeItem.FromEvent(@event) };
			if (attachments != null)
			{
				foreach (SentryAttachment attachment in attachments)
				{
					if (attachment.IsNull())
					{
						logger?.LogWarning("Encountered a null attachment.  Skipping.");
						continue;
					}
					try
					{
						Stream stream = attachment.Content.GetStream();
						if (stream.TryGetLength() != 0)
						{
							list.Add(EnvelopeItem.FromAttachment(attachment, stream));
							continue;
						}
						stream.Dispose();
						logger?.LogWarning("Did not add '{0}' to envelope because the stream was empty.", attachment.FileName);
					}
					catch (Exception exception)
					{
						logger?.LogError(exception, "Failed to add attachment: {0}.", attachment.FileName);
					}
				}
			}
			if (sessionUpdate != null)
			{
				list.Add(EnvelopeItem.FromSession(sessionUpdate));
			}
			return new Envelope(eventId, header, list);
		}

		public static Envelope FromUserFeedback(UserFeedback sentryUserFeedback)
		{
			SentryId eventId = sentryUserFeedback.EventId;
			Dictionary<string, object> header = CreateHeader(eventId);
			EnvelopeItem[] items = new EnvelopeItem[1] { EnvelopeItem.FromUserFeedback(sentryUserFeedback) };
			return new Envelope(eventId, header, items);
		}

		public static Envelope FromTransaction(SentryTransaction transaction)
		{
			SentryId eventId = transaction.EventId;
			Dictionary<string, object> header = CreateHeader(eventId, transaction.DynamicSamplingContext);
			List<EnvelopeItem> list = new List<EnvelopeItem> { EnvelopeItem.FromTransaction(transaction) };
			ITransactionProfiler transactionProfiler = transaction.TransactionProfiler;
			if (transactionProfiler != null)
			{
				ISerializable serializable = transactionProfiler.Collect(transaction);
				if (serializable != null)
				{
					list.Add(EnvelopeItem.FromProfileInfo(serializable));
				}
			}
			return new Envelope(eventId, header, list);
		}

		internal static Envelope FromCodeLocations(CodeLocations codeLocations)
		{
			return new Envelope(DefaultHeader, new List<EnvelopeItem>(1) { EnvelopeItem.FromCodeLocations(codeLocations) });
		}

		internal static Envelope FromMetrics(IEnumerable<Metric> metrics)
		{
			IReadOnlyDictionary<string, object> defaultHeader = DefaultHeader;
			List<EnvelopeItem> list = new List<EnvelopeItem>();
			foreach (Metric metric in metrics)
			{
				list.Add(EnvelopeItem.FromMetric(metric));
			}
			return new Envelope(defaultHeader, list);
		}

		public static Envelope FromSession(SessionUpdate sessionUpdate)
		{
			IReadOnlyDictionary<string, object> defaultHeader = DefaultHeader;
			EnvelopeItem[] items = new EnvelopeItem[1] { EnvelopeItem.FromSession(sessionUpdate) };
			return new Envelope(defaultHeader, items);
		}

		public static Envelope FromCheckIn(SentryCheckIn checkIn)
		{
			IReadOnlyDictionary<string, object> defaultHeader = DefaultHeader;
			EnvelopeItem[] items = new EnvelopeItem[1] { EnvelopeItem.FromCheckIn(checkIn) };
			return new Envelope(defaultHeader, items);
		}

		internal static Envelope FromClientReport(ClientReport clientReport)
		{
			IReadOnlyDictionary<string, object> defaultHeader = DefaultHeader;
			EnvelopeItem[] items = new EnvelopeItem[1] { EnvelopeItem.FromClientReport(clientReport) };
			return new Envelope(defaultHeader, items);
		}

		private static async Task<IReadOnlyDictionary<string, object?>> DeserializeHeaderAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			Dictionary<string, object?>? obj = Json.Parse(await stream.ReadLineAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false), JsonExtensions.GetDictionaryOrNull) ?? throw new InvalidOperationException("Envelope header is malformed.");
			obj.Remove("sent_at");
			return obj;
		}

		public static async Task<Envelope> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			IReadOnlyDictionary<string, object?> header = await DeserializeHeaderAsync(stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			List<EnvelopeItem> items = new List<EnvelopeItem>();
			while (stream.Position < stream.Length)
			{
				items.Add(await EnvelopeItem.DeserializeAsync(stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			}
			return new Envelope(header, items);
		}

		internal Envelope WithItem(EnvelopeItem item)
		{
			List<EnvelopeItem> list = Items.ToList();
			list.Add(item);
			return new Envelope(_eventId, Header, list);
		}
	}
}
