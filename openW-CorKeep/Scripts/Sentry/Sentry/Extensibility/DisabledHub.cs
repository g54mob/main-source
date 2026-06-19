using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sentry.Internal;
using Sentry.Protocol.Envelopes;

namespace Sentry.Extensibility
{
	public class DisabledHub : IHub, ISentryClient, ISentryScopeManager, IDisposable
	{
		public static readonly DisabledHub Instance = new DisabledHub();

		public bool IsEnabled => false;

		public IMetricAggregator Metrics { get; } = new DisabledMetricAggregator();

		public SentryId LastEventId => SentryId.Empty;

		private DisabledHub()
		{
		}

		public void ConfigureScope(Action<Scope> configureScope)
		{
		}

		public Task ConfigureScopeAsync(Func<Scope, Task> configureScope)
		{
			return Task.CompletedTask;
		}

		public IDisposable PushScope()
		{
			return this;
		}

		public IDisposable PushScope<TState>(TState state)
		{
			return this;
		}

		public ITransactionTracer StartTransaction(ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext)
		{
			return NoOpTransaction.Instance;
		}

		public void BindException(Exception exception, ISpan span)
		{
		}

		public ISpan? GetSpan()
		{
			return null;
		}

		public SentryTraceHeader? GetTraceHeader()
		{
			return null;
		}

		public BaggageHeader? GetBaggage()
		{
			return null;
		}

		public TransactionContext ContinueTrace(string? traceHeader, string? baggageHeader, string? name = null, string? operation = null)
		{
			string? name2 = name ?? string.Empty;
			string? operation2 = operation ?? string.Empty;
			bool? isSampled = false;
			return new TransactionContext(name2, operation2, null, null, null, "", null, isSampled);
		}

		public TransactionContext ContinueTrace(SentryTraceHeader? traceHeader, BaggageHeader? baggageHeader, string? name = null, string? operation = null)
		{
			string? name2 = name ?? string.Empty;
			string? operation2 = operation ?? string.Empty;
			bool? isSampled = false;
			return new TransactionContext(name2, operation2, null, null, null, "", null, isSampled);
		}

		public void StartSession()
		{
		}

		public void PauseSession()
		{
		}

		public void ResumeSession()
		{
		}

		public void EndSession(SessionEndStatus status = SessionEndStatus.Exited)
		{
		}

		public void BindClient(ISentryClient client)
		{
		}

		public bool CaptureEnvelope(Envelope envelope)
		{
			return false;
		}

		public SentryId CaptureEvent(SentryEvent evt, Scope? scope = null, SentryHint? hint = null)
		{
			return SentryId.Empty;
		}

		public SentryId CaptureEvent(SentryEvent evt, Action<Scope> configureScope)
		{
			return SentryId.Empty;
		}

		public SentryId CaptureEvent(SentryEvent evt, SentryHint? hint, Action<Scope> configureScope)
		{
			return SentryId.Empty;
		}

		public void CaptureTransaction(SentryTransaction transaction)
		{
		}

		public void CaptureTransaction(SentryTransaction transaction, Scope? scope, SentryHint? hint)
		{
		}

		public void CaptureSession(SessionUpdate sessionUpdate)
		{
		}

		public SentryId CaptureCheckIn(string monitorSlug, CheckInStatus status, SentryId? sentryId = null, TimeSpan? duration = null, Scope? scope = null, Action<SentryMonitorOptions>? configureMonitorOptions = null)
		{
			return SentryId.Empty;
		}

		public Task FlushAsync(TimeSpan timeout)
		{
			return Task.CompletedTask;
		}

		public void Dispose()
		{
		}

		public void CaptureUserFeedback(UserFeedback userFeedback)
		{
		}
	}
}
