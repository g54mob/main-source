using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Protocol.Metrics;

namespace Sentry.Protocol.Envelopes
{
	public sealed class EnvelopeItem : ISerializable, IDisposable
	{
		private const string TypeKey = "type";

		internal const string TypeValueEvent = "event";

		internal const string TypeValueUserReport = "user_report";

		internal const string TypeValueTransaction = "transaction";

		internal const string TypeValueSpan = "span";

		internal const string TypeValueSession = "session";

		internal const string TypeValueCheckIn = "check_in";

		internal const string TypeValueAttachment = "attachment";

		internal const string TypeValueClientReport = "client_report";

		internal const string TypeValueProfile = "profile";

		internal const string TypeValueMetric = "statsd";

		internal const string TypeValueCodeLocations = "metric_meta";

		private const string LengthKey = "length";

		private const string FileNameKey = "filename";

		public IReadOnlyDictionary<string, object?> Header { get; }

		public ISerializable Payload { get; }

		internal DataCategory DataCategory => TryGetType() switch
		{
			"event" => DataCategory.Error, 
			"transaction" => DataCategory.Transaction, 
			"span" => DataCategory.Span, 
			"session" => DataCategory.Session, 
			"attachment" => DataCategory.Attachment, 
			"profile" => DataCategory.Profile, 
			_ => DataCategory.Default, 
		};

		public EnvelopeItem(IReadOnlyDictionary<string, object?> header, ISerializable payload)
		{
			Header = header;
			Payload = payload;
		}

		public string? TryGetType()
		{
			return Header.GetValueOrDefault("type") as string;
		}

		public long? TryGetLength()
		{
			object valueOrDefault = Header.GetValueOrDefault("length");
			if (valueOrDefault == null)
			{
				return null;
			}
			return Convert.ToInt64(valueOrDefault);
		}

		internal long? TryGetOrRecalculateLength()
		{
			long? num = TryGetLength();
			if (num.HasValue)
			{
				return num.GetValueOrDefault();
			}
			if (Payload is StreamSerializable streamSerializable)
			{
				return streamSerializable.Source.TryGetLength();
			}
			return null;
		}

		public string? TryGetFileName()
		{
			return Header.GetValueOrDefault("filename") as string;
		}

		private async Task<MemoryStream> BufferPayloadAsync(IDiagnosticLogger? logger, CancellationToken cancellationToken)
		{
			MemoryStream buffer = new MemoryStream();
			if (Payload is JsonSerializable jsonSerializable)
			{
				jsonSerializable.Serialize(buffer, logger);
			}
			else
			{
				await Payload.SerializeAsync(buffer, logger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			buffer.Seek(0L, SeekOrigin.Begin);
			return buffer;
		}

		private MemoryStream BufferPayload(IDiagnosticLogger? logger)
		{
			MemoryStream memoryStream = new MemoryStream();
			Payload.Serialize(memoryStream, logger);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return memoryStream;
		}

		private static async Task SerializeHeaderAsync(Stream stream, IReadOnlyDictionary<string, object?> header, IDiagnosticLogger? logger, CancellationToken cancellationToken)
		{
			Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(stream);
			ConfiguredAsyncDisposable I_0 = utf8JsonWriter.ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				utf8JsonWriter.WriteDictionaryValue(header, logger);
				await utf8JsonWriter.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				IAsyncDisposable asyncDisposable = I_0 as IAsyncDisposable;
				if (asyncDisposable != null)
				{
					await asyncDisposable.DisposeAsync();
				}
			}
		}

		private static void SerializeHeader(Stream stream, IReadOnlyDictionary<string, object?> header, IDiagnosticLogger? logger)
		{
			using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(stream);
			utf8JsonWriter.WriteDictionaryValue(header, logger);
			utf8JsonWriter.Flush();
		}

		public async Task SerializeAsync(Stream stream, IDiagnosticLogger? logger, CancellationToken cancellationToken = default(CancellationToken))
		{
			MemoryStream payloadBuffer = await BufferPayloadAsync(logger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			using (payloadBuffer)
			{
				Dictionary<string, object> dictionary = Header.ToDict();
				dictionary["length"] = payloadBuffer.Length;
				await SerializeHeaderAsync(stream, dictionary, logger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				await stream.WriteNewlineAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				await PolyfillExtensions.CopyToAsync(payloadBuffer, stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public void Serialize(Stream stream, IDiagnosticLogger? logger)
		{
			using MemoryStream memoryStream = BufferPayload(logger);
			Dictionary<string, object> dictionary = Header.ToDict();
			dictionary["length"] = memoryStream.Length;
			SerializeHeader(stream, dictionary, logger);
			stream.WriteNewline();
			memoryStream.CopyTo(stream);
		}

		public void Dispose()
		{
			(Payload as IDisposable)?.Dispose();
		}

		public static EnvelopeItem FromEvent(SentryEvent @event)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "event" }, new JsonSerializable(@event));
		}

		public static EnvelopeItem FromUserFeedback(UserFeedback sentryUserFeedback)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "user_report" }, new JsonSerializable(sentryUserFeedback));
		}

		public static EnvelopeItem FromTransaction(SentryTransaction transaction)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "transaction" }, new JsonSerializable(transaction));
		}

		internal static EnvelopeItem FromCodeLocations(CodeLocations codeLocations)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "metric_meta" }, new JsonSerializable(codeLocations));
		}

		internal static EnvelopeItem FromMetric(Metric metric)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "statsd" }, metric);
		}

		internal static EnvelopeItem FromProfileInfo(ISerializable source)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "profile" }, source);
		}

		public static EnvelopeItem FromSession(SessionUpdate sessionUpdate)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "session" }, new JsonSerializable(sessionUpdate));
		}

		public static EnvelopeItem FromCheckIn(SentryCheckIn checkIn)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "check_in" }, new JsonSerializable(checkIn));
		}

		public static EnvelopeItem FromAttachment(SentryAttachment attachment)
		{
			Stream stream = attachment.Content.GetStream();
			return FromAttachment(attachment, stream);
		}

		internal static EnvelopeItem FromAttachment(SentryAttachment attachment, Stream stream)
		{
			string value = attachment.Type switch
			{
				AttachmentType.Minidump => "event.minidump", 
				AttachmentType.AppleCrashReport => "event.applecrashreport", 
				AttachmentType.UnrealContext => "unreal.context", 
				AttachmentType.UnrealLogs => "unreal.logs", 
				AttachmentType.ViewHierarchy => "event.view_hierarchy", 
				_ => "event.attachment", 
			};
			return new EnvelopeItem(new Dictionary<string, object>(5, StringComparer.Ordinal)
			{
				["type"] = "attachment",
				["length"] = stream.TryGetLength(),
				["filename"] = attachment.FileName,
				["attachment_type"] = value,
				["content_type"] = attachment.ContentType
			}, new StreamSerializable(stream));
		}

		internal static EnvelopeItem FromClientReport(ClientReport report)
		{
			return new EnvelopeItem(new Dictionary<string, object>(1, StringComparer.Ordinal) { ["type"] = "client_report" }, new JsonSerializable(report));
		}

		private static async Task<Dictionary<string, object?>> DeserializeHeaderAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Json.Parse(await stream.ReadLineAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false), JsonExtensions.GetDictionaryOrNull) ?? throw new InvalidOperationException("Envelope item header is malformed.");
		}

		private static async Task<ISerializable> DeserializePayloadAsync(Stream stream, IReadOnlyDictionary<string, object?> header, CancellationToken cancellationToken = default(CancellationToken))
		{
			object valueOrDefault = header.GetValueOrDefault("length");
			long? num = ((valueOrDefault != null) ? new long?(Convert.ToInt64(valueOrDefault)) : ((long?)null));
			long? num2 = num;
			string a = header.GetValueOrDefault("type") as string;
			if (string.Equals(a, "event", StringComparison.OrdinalIgnoreCase))
			{
				int expectedLength = (int)(num2 ?? stream.Length);
				return new JsonSerializable(Json.Parse(await stream.ReadByteChunkAsync(expectedLength, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), SentryEvent.FromJson));
			}
			if (string.Equals(a, "user_report", StringComparison.OrdinalIgnoreCase))
			{
				int expectedLength2 = (int)(num2 ?? stream.Length);
				return new JsonSerializable(Json.Parse(await stream.ReadByteChunkAsync(expectedLength2, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), UserFeedback.FromJson));
			}
			if (string.Equals(a, "transaction", StringComparison.OrdinalIgnoreCase))
			{
				int expectedLength3 = (int)(num2 ?? stream.Length);
				return new JsonSerializable(Json.Parse(await stream.ReadByteChunkAsync(expectedLength3, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), SentryTransaction.FromJson));
			}
			if (string.Equals(a, "session", StringComparison.OrdinalIgnoreCase))
			{
				int expectedLength4 = (int)(num2 ?? stream.Length);
				return new JsonSerializable(Json.Parse(await stream.ReadByteChunkAsync(expectedLength4, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), SessionUpdate.FromJson));
			}
			if (string.Equals(a, "client_report", StringComparison.OrdinalIgnoreCase))
			{
				int expectedLength5 = (int)(num2 ?? stream.Length);
				return new JsonSerializable(Json.Parse(await stream.ReadByteChunkAsync(expectedLength5, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), ClientReport.FromJson));
			}
			PartialStream source = new PartialStream(stream, stream.Position, num2);
			if (num2.HasValue)
			{
				stream.Seek(num2.Value, SeekOrigin.Current);
			}
			else
			{
				stream.Seek(0L, SeekOrigin.End);
			}
			return new StreamSerializable(source);
		}

		public static async Task<EnvelopeItem> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			Dictionary<string, object?> header = await DeserializeHeaderAsync(stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			ISerializable payload = await DeserializePayloadAsync(stream, header, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await stream.SkipNewlinesAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			header.Remove("length");
			return new EnvelopeItem(header, payload);
		}
	}
}
