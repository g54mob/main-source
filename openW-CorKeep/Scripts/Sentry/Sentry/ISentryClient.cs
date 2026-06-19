using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Sentry.Protocol.Envelopes;

namespace Sentry
{
	public interface ISentryClient
	{
		bool IsEnabled { get; }

		bool CaptureEnvelope(Envelope envelope);

		SentryId CaptureEvent(SentryEvent evt, Scope? scope = null, SentryHint? hint = null);

		void CaptureUserFeedback(UserFeedback userFeedback);

		[EditorBrowsable(EditorBrowsableState.Never)]
		void CaptureTransaction(SentryTransaction transaction);

		[EditorBrowsable(EditorBrowsableState.Never)]
		void CaptureTransaction(SentryTransaction transaction, Scope? scope, SentryHint? hint);

		void CaptureSession(SessionUpdate sessionUpdate);

		SentryId CaptureCheckIn(string monitorSlug, CheckInStatus status, SentryId? sentryId = null, TimeSpan? duration = null, Scope? scope = null, Action<SentryMonitorOptions>? configureMonitorOptions = null);

		Task FlushAsync(TimeSpan timeout);
	}
}
