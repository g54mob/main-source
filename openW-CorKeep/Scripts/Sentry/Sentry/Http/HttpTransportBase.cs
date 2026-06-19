using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Internal.Http;
using Sentry.Protocol.Envelopes;

namespace Sentry.Http
{
	public abstract class HttpTransportBase
	{
		internal const string DefaultErrorMessage = "No message";

		private readonly SentryOptions _options;

		private readonly ISystemClock _clock;

		private readonly Func<string, string?> _getEnvironmentVariable;

		private string? _lastDiscardedSessionInitId;

		private string _typeName;

		internal ConcurrentDictionary<RateLimitCategory, DateTimeOffset> CategoryLimitResets { get; } = new ConcurrentDictionary<RateLimitCategory, DateTimeOffset>();

		protected HttpTransportBase(SentryOptions options, Func<string, string?>? getEnvironmentVariable = null, ISystemClock? clock = null)
		{
			_options = options;
			_clock = clock ?? SystemClock.Clock;
			_getEnvironmentVariable = getEnvironmentVariable ?? new Func<string, string>(options.SettingLocator.GetEnvironmentVariable);
			_typeName = GetType().Name;
		}

		protected internal Envelope ProcessEnvelope(Envelope envelope)
		{
			DateTimeOffset utcNow = _clock.GetUtcNow();
			List<EnvelopeItem> list = new List<EnvelopeItem>();
			foreach (EnvelopeItem item in envelope.Items)
			{
				ProcessEnvelopeItem(utcNow, item, list);
			}
			SentryId? arg = envelope.TryGetEventId(_options.DiagnosticLogger);
			ClientReport clientReport = _options.ClientReportRecorder.GenerateClientReport();
			if (clientReport != null)
			{
				list.Add(EnvelopeItem.FromClientReport(clientReport));
				_options.LogDebug("{0}: Attached client report to envelope {1}.", _typeName, arg);
			}
			if (list.Count == 0)
			{
				if (_options.SendClientReports)
				{
					_options.LogInfo("{0}: Envelope '{1}' was discarded because all contained items are rate-limited and there are no client reports to send.", _typeName, arg);
				}
				else
				{
					_options.LogInfo("{0}: Envelope '{1}' was discarded because all contained items are rate-limited.", _typeName, arg);
				}
			}
			return new Envelope(envelope.Header, list);
		}

		private void ProcessEnvelopeItem(DateTimeOffset now, EnvelopeItem item, List<EnvelopeItem> items)
		{
			if (CategoryLimitResets.Any<KeyValuePair<RateLimitCategory, DateTimeOffset>>((KeyValuePair<RateLimitCategory, DateTimeOffset> kvp) => kvp.Value > now && kvp.Key.Matches(item)))
			{
				DiscardReason rateLimitBackoff = DiscardReason.RateLimitBackoff;
				_options.ClientReportRecorder.RecordDiscardedEvent(rateLimitBackoff, item.DataCategory);
				_options.LogDebug("{0}: Envelope item of type {1} was discarded because it's rate-limited.", _typeName, item.TryGetType());
				if (item.DataCategory.Equals(DataCategory.Transaction) && item.Payload is JsonSerializable { Source: SentryTransaction source })
				{
					_options.ClientReportRecorder.RecordDiscardedEvent(rateLimitBackoff, DataCategory.Span, source.Spans.Count + 1);
				}
				if (item.Payload is JsonSerializable { Source: SessionUpdate { IsInitial: not false } source2 })
				{
					_lastDiscardedSessionInitId = source2.Id.ToString();
					_options.LogDebug("{0}: Discarded envelope item containing initial session update (SID: {1}).", _typeName, source2.Id);
				}
			}
			else if (string.Equals(item.TryGetType(), "attachment", StringComparison.OrdinalIgnoreCase) && item.TryGetOrRecalculateLength() > _options.MaxAttachmentSize)
			{
				_options.LogWarning("{0}: Attachment '{1}' dropped because it's too large ({2} bytes).", _typeName, item.TryGetFileName(), item.TryGetLength());
			}
			else if (item.Payload is JsonSerializable { Source: SessionUpdate { IsInitial: false, Id: var id } source3 } && string.Equals(id.ToString(), Interlocked.Exchange(ref _lastDiscardedSessionInitId, null), StringComparison.Ordinal))
			{
				EnvelopeItem item2 = new EnvelopeItem(item.Header, new JsonSerializable(new SessionUpdate(source3, isInitial: true)));
				items.Add(item2);
				_options.LogDebug("{0}: Promoted envelope item with session update to initial following a discarded update (SID: {1}).", _typeName, source3.Id);
			}
			else
			{
				items.Add(item);
			}
		}

		protected internal virtual HttpRequestMessage CreateRequest(Envelope envelope)
		{
			if (string.IsNullOrWhiteSpace(_options.Dsn))
			{
				throw new InvalidOperationException("The DSN is expected to be set at this point.");
			}
			Dsn dsn = Dsn.Parse(_options.Dsn);
			string[] obj = new string[8]
			{
				$"Sentry sentry_version={_options.SentryVersion},",
				"sentry_client=",
				SdkVersion.Instance.Name,
				"/",
				SdkVersion.Instance.Version,
				",sentry_key=",
				dsn.PublicKey,
				null
			};
			string secretKey = dsn.SecretKey;
			obj[7] = ((secretKey != null) ? (",sentry_secret=" + secretKey) : null);
			string value = string.Concat(obj);
			return new HttpRequestMessage
			{
				RequestUri = dsn.GetEnvelopeEndpointUri(),
				Method = HttpMethod.Post,
				Headers = { { "X-Sentry-Auth", value } },
				Content = new EnvelopeHttpContent(envelope, _options.DiagnosticLogger, _clock)
			};
		}

		protected void HandleResponse(HttpResponseMessage response, Envelope envelope)
		{
			ExtractRateLimits(response.Headers);
			if (response.StatusCode == HttpStatusCode.OK)
			{
				HandleSuccess(envelope);
			}
			else
			{
				HandleFailure(response, envelope);
			}
		}

		protected Task HandleResponseAsync(HttpResponseMessage response, Envelope envelope, CancellationToken cancellationToken)
		{
			ExtractRateLimits(response.Headers);
			if (response.StatusCode == HttpStatusCode.OK)
			{
				return HandleSuccessAsync(envelope, cancellationToken);
			}
			return HandleFailureAsync(response, envelope, cancellationToken);
		}

		protected Stream ReadStreamFromHttpContent(HttpContent content)
		{
			return content.ReadAsStream();
		}

		private void ExtractRateLimits(HttpHeaders responseHeaders)
		{
			if (!responseHeaders.TryGetValues("X-Sentry-Rate-Limits", out var values))
			{
				return;
			}
			DateTimeOffset utcNow = _clock.GetUtcNow();
			foreach (RateLimit item in from rl in RateLimit.ParseMany(string.Join(",", values))
				orderby rl.RetryAfter
				select rl)
			{
				foreach (RateLimitCategory category in item.Categories)
				{
					if (!string.Equals(category.Name, "metric_bucket", StringComparison.OrdinalIgnoreCase) || item.IsDefaultNamespace)
					{
						CategoryLimitResets[category] = utcNow + item.RetryAfter;
					}
				}
			}
		}

		private void HandleSuccess(Envelope envelope)
		{
			if (_options.DiagnosticLogger?.IsEnabled(SentryLevel.Debug) ?? false)
			{
				string payload = envelope.SerializeToString(_options.DiagnosticLogger, _clock);
				LogEnvelopeSent(envelope, payload);
			}
			else
			{
				LogEnvelopeSent(envelope);
			}
		}

		private async Task HandleSuccessAsync(Envelope envelope, CancellationToken cancellationToken)
		{
			if (_options.DiagnosticLogger?.IsEnabled(SentryLevel.Debug) ?? false)
			{
				LogEnvelopeSent(envelope, await envelope.SerializeToStringAsync(_options.DiagnosticLogger, _clock, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			}
			else
			{
				LogEnvelopeSent(envelope);
			}
		}

		private void LogEnvelopeSent(Envelope envelope, string? payload = null)
		{
			SentryId? arg = envelope.TryGetEventId(_options.DiagnosticLogger);
			if (payload == null)
			{
				if (!arg.HasValue)
				{
					_options.LogInfo("{0}: Envelope successfully sent.", _typeName);
				}
				else
				{
					_options.LogInfo("{0}: Envelope '{1}' successfully sent.", _typeName, arg);
				}
			}
			else if (!arg.HasValue)
			{
				_options.LogDebug("{0}: Envelope successfully sent. Content: {1}", _typeName, payload);
			}
			else
			{
				_options.LogDebug("{0}: Envelope '{1}' successfully sent. Content: {2}", _typeName, arg, payload);
			}
		}

		private void HandleFailure(HttpResponseMessage response, Envelope envelope)
		{
			IncrementDiscardsForHttpFailure(response.StatusCode, envelope);
			SentryId? sentryId = envelope.TryGetEventId(_options.DiagnosticLogger);
			if (_options.DiagnosticLogger?.IsEnabled(SentryLevel.Error) ?? false)
			{
				HttpContent content = response.Content;
				if (content != null)
				{
					if (HasJsonContent(content))
					{
						JsonElement responseJson = content.ReadAsJson();
						LogFailure(responseJson, response.StatusCode, sentryId);
					}
					else
					{
						string responseString = content.ReadAsString();
						LogFailure(responseString, response.StatusCode, sentryId);
					}
				}
			}
			if (!(_options.DiagnosticLogger?.IsEnabled(SentryLevel.Debug) ?? false))
			{
				return;
			}
			string arg = envelope.SerializeToString(_options.DiagnosticLogger, _clock);
			_options.LogDebug("{0}: Failed envelope '{1}' has payload:\n{2}\n", _typeName, sentryId, arg);
			if (response.StatusCode != HttpStatusCode.RequestEntityTooLarge)
			{
				return;
			}
			string text = _getEnvironmentVariable("SENTRY_KEEP_LARGE_ENVELOPE_PATH");
			if (text == null)
			{
				return;
			}
			_options.LogDebug("{0}: Environment variable '{1}' set. Writing envelope to {2}", _typeName, "SENTRY_KEEP_LARGE_ENVELOPE_PATH", text);
			if (_options.DisableFileWrite)
			{
				_options.LogInfo("File write has been disabled via the options. Skipping persisting envelope.");
				return;
			}
			string text2 = Path.Combine(text, "envelope_too_large", (sentryId ?? SentryId.Create()).ToString());
			if (!_options.FileSystem.CreateDirectory(Path.GetDirectoryName(text2)))
			{
				_options.LogError("Failed to create directory to store the envelope.");
				return;
			}
			if (!_options.FileSystem.CreateFileForWriting(text2, out Stream fileStream))
			{
				_options.LogError("Failed to create envelope file.");
				return;
			}
			using (fileStream)
			{
				envelope.Serialize(fileStream, _options.DiagnosticLogger);
				fileStream.Flush();
				_options.LogInfo("{0}: Envelope's {1} bytes written to: {2}", _typeName, fileStream.Length, text2);
			}
		}

		private async Task HandleFailureAsync(HttpResponseMessage response, Envelope envelope, CancellationToken cancellationToken)
		{
			IncrementDiscardsForHttpFailure(response.StatusCode, envelope);
			SentryId? eventId = envelope.TryGetEventId(_options.DiagnosticLogger);
			if (_options.DiagnosticLogger?.IsEnabled(SentryLevel.Error) ?? false)
			{
				HttpContent content = response.Content;
				if (content != null)
				{
					if (HasJsonContent(content))
					{
						LogFailure(await content.ReadAsJsonAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false), response.StatusCode, eventId);
					}
					else
					{
						LogFailure(await content.ReadAsStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false), response.StatusCode, eventId);
					}
				}
			}
			if (!(_options.DiagnosticLogger?.IsEnabled(SentryLevel.Debug) ?? false))
			{
				return;
			}
			string arg = await envelope.SerializeToStringAsync(_options.DiagnosticLogger, _clock, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			_options.LogDebug("{0}: Failed envelope '{1}' has payload:\n{2}\n", _typeName, eventId, arg);
			if (response.StatusCode != HttpStatusCode.RequestEntityTooLarge)
			{
				return;
			}
			string text = _getEnvironmentVariable("SENTRY_KEEP_LARGE_ENVELOPE_PATH");
			if (text == null)
			{
				return;
			}
			_options.LogDebug("{0}: Environment variable '{1}' set. Writing envelope to {2}", _typeName, "SENTRY_KEEP_LARGE_ENVELOPE_PATH", text);
			if (_options.DisableFileWrite)
			{
				_options.LogInfo("File write has been disabled via the options. Skipping persisting envelope.");
				return;
			}
			string destination = Path.Combine(text, "envelope_too_large", (eventId ?? SentryId.Create()).ToString());
			if (!_options.FileSystem.CreateDirectory(Path.GetDirectoryName(destination)))
			{
				_options.LogError("Failed to create directory to store the envelope.");
				return;
			}
			if (!_options.FileSystem.CreateFileForWriting(destination, out Stream envelopeFile))
			{
				_options.LogError("Failed to create envelope file.");
				return;
			}
			using (envelopeFile)
			{
				await envelope.SerializeAsync(envelopeFile, _options.DiagnosticLogger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				await envelopeFile.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				_options.LogInfo("{0}: Envelope's {1} bytes written to: {2}", _typeName, envelopeFile.Length, destination);
			}
		}

		private void IncrementDiscardsForHttpFailure(HttpStatusCode responseStatusCode, Envelope envelope)
		{
			if ((responseStatusCode < HttpStatusCode.BadRequest || responseStatusCode == HttpStatusCode.TooManyRequests) ? true : false)
			{
				return;
			}
			_options.ClientReportRecorder.RecordDiscardedEvents(DiscardReason.NetworkError, envelope);
			foreach (EnvelopeItem item in envelope.Items.Where((EnvelopeItem x) => x.TryGetType() == "client_report"))
			{
				ClientReport report = (ClientReport)((JsonSerializable)item.Payload).Source;
				_options.ClientReportRecorder.Load(report);
			}
		}

		private void LogFailure(string responseString, HttpStatusCode responseStatusCode, SentryId? eventId)
		{
			_options.LogError("{0}: Sentry rejected the envelope '{1}'. Status code: {2}. Error detail: {3}.", _typeName, eventId, responseStatusCode, responseString);
		}

		private void LogFailure(JsonElement responseJson, HttpStatusCode responseStatusCode, SentryId? eventId)
		{
			string arg = responseJson.GetPropertyOrNull("detail")?.GetString() ?? "No message";
			JsonElement? propertyOrNull = responseJson.GetPropertyOrNull("causes");
			string[] value = (propertyOrNull.HasValue ? (from j in propertyOrNull.GetValueOrDefault().EnumerateArray()
				select j.GetString()).ToArray() : null) ?? Array.Empty<string>();
			_options.LogError("{0}: Sentry rejected the envelope '{1}'. Status code: {2}. Error detail: {3}. Error causes: {4}.", _typeName, eventId, responseStatusCode, arg, string.Join(", ", value));
		}

		private static bool HasJsonContent(HttpContent content)
		{
			return string.Equals(content.Headers.ContentType?.MediaType, "application/json", StringComparison.OrdinalIgnoreCase);
		}
	}
}
