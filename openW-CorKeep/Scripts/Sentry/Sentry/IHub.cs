using System;
using System.Collections.Generic;

namespace Sentry
{
	public interface IHub : ISentryClient, ISentryScopeManager
	{
		SentryId LastEventId { get; }

		IMetricAggregator Metrics { get; }

		ITransactionTracer StartTransaction(ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext);

		void BindException(Exception exception, ISpan span);

		ISpan? GetSpan();

		SentryTraceHeader? GetTraceHeader();

		BaggageHeader? GetBaggage();

		TransactionContext ContinueTrace(string? traceHeader, string? baggageHeader, string? name = null, string? operation = null);

		TransactionContext ContinueTrace(SentryTraceHeader? traceHeader, BaggageHeader? baggageHeader, string? name = null, string? operation = null);

		void StartSession();

		void PauseSession();

		void ResumeSession();

		void EndSession(SessionEndStatus status = SessionEndStatus.Exited);

		SentryId CaptureEvent(SentryEvent evt, Action<Scope> configureScope);

		SentryId CaptureEvent(SentryEvent evt, SentryHint? hint, Action<Scope> configureScope);
	}
}
