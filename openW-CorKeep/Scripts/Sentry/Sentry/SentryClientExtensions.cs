using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Internal;

namespace Sentry
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class SentryClientExtensions
	{
		internal static SentryOptions? SentryOptionsForTestingOnly { get; set; }

		public static SentryId CaptureException(this ISentryClient client, Exception ex)
		{
			if (!client.IsEnabled)
			{
				return SentryId.Empty;
			}
			return client.CaptureEvent(new SentryEvent(ex));
		}

		public static SentryId CaptureMessage(this ISentryClient client, string message, SentryLevel level = SentryLevel.Info)
		{
			if (client.IsEnabled && !string.IsNullOrWhiteSpace(message))
			{
				return client.CaptureEvent(new SentryEvent
				{
					Message = message,
					Level = level
				});
			}
			return SentryId.Empty;
		}

		public static void CaptureUserFeedback(this ISentryClient client, SentryId eventId, string email, string comments, string? name = null)
		{
			if (client.IsEnabled)
			{
				client.CaptureUserFeedback(new UserFeedback(eventId, name, email, comments));
			}
		}

		public static void Flush(this ISentryClient client)
		{
			client.FlushAsync().GetAwaiter().GetResult();
		}

		public static void Flush(this ISentryClient client, TimeSpan timeout)
		{
			client.FlushAsync(timeout).GetAwaiter().GetResult();
		}

		public static Task FlushAsync(this ISentryClient client)
		{
			TimeSpan flushTimeout = (client.GetSentryOptions() ?? new SentryOptions()).FlushTimeout;
			return client.FlushAsync(flushTimeout);
		}

		internal static SentryOptions? GetSentryOptions(this ISentryClient clientOrHub)
		{
			if (!(clientOrHub is SentryClient sentryClient))
			{
				if (!(clientOrHub is Hub hub))
				{
					if (clientOrHub is HubAdapter)
					{
						return SentrySdk.CurrentOptions;
					}
					return SentryOptionsForTestingOnly;
				}
				return hub.Options;
			}
			return sentryClient.Options;
		}
	}
}
