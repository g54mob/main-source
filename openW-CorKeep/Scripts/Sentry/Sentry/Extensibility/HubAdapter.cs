using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Sentry.Infrastructure;
using Sentry.Protocol.Envelopes;

namespace Sentry.Extensibility
{
	[DebuggerStepThrough]
	public sealed class HubAdapter : IHub, ISentryClient, ISentryScopeManager
	{
		public static readonly HubAdapter Instance = new HubAdapter();

		public bool IsEnabled
		{
			[DebuggerStepThrough]
			get
			{
				return SentrySdk.IsEnabled;
			}
		}

		public SentryId LastEventId
		{
			[DebuggerStepThrough]
			get
			{
				return SentrySdk.LastEventId;
			}
		}

		[Obsolete("The SentrySdk.Metrics module is deprecated and will be removed in the next major release. Sentry will reject all metrics sent after October 7, 2024.Learn more: https://sentry.zendesk.com/hc/en-us/articles/26369339769883-Upcoming-API-Changes-to-Metrics")]
		public IMetricAggregator Metrics => SentrySdk.Metrics;

		private HubAdapter()
		{
		}

		[DebuggerStepThrough]
		public void ConfigureScope(Action<Scope> configureScope)
		{
			SentrySdk.ConfigureScope(configureScope);
		}

		[DebuggerStepThrough]
		public Task ConfigureScopeAsync(Func<Scope, Task> configureScope)
		{
			return SentrySdk.ConfigureScopeAsync(configureScope);
		}

		[DebuggerStepThrough]
		public IDisposable PushScope()
		{
			return SentrySdk.PushScope();
		}

		[DebuggerStepThrough]
		public IDisposable PushScope<TState>(TState state)
		{
			return SentrySdk.PushScope(state);
		}

		[DebuggerStepThrough]
		public ITransactionTracer StartTransaction(ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext)
		{
			return SentrySdk.StartTransaction(context, customSamplingContext);
		}

		[DebuggerStepThrough]
		internal ITransactionTracer StartTransaction(ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext, DynamicSamplingContext? dynamicSamplingContext)
		{
			return SentrySdk.StartTransaction(context, customSamplingContext, dynamicSamplingContext);
		}

		[DebuggerStepThrough]
		public void BindException(Exception exception, ISpan span)
		{
			SentrySdk.BindException(exception, span);
		}

		[DebuggerStepThrough]
		public ISpan? GetSpan()
		{
			return SentrySdk.GetSpan();
		}

		[DebuggerStepThrough]
		public SentryTraceHeader? GetTraceHeader()
		{
			return SentrySdk.GetTraceHeader();
		}

		[DebuggerStepThrough]
		public BaggageHeader? GetBaggage()
		{
			return SentrySdk.GetBaggage();
		}

		[DebuggerStepThrough]
		public TransactionContext ContinueTrace(string? traceHeader, string? baggageHeader, string? name = null, string? operation = null)
		{
			return SentrySdk.ContinueTrace(traceHeader, baggageHeader, name, operation);
		}

		[DebuggerStepThrough]
		public TransactionContext ContinueTrace(SentryTraceHeader? traceHeader, BaggageHeader? baggageHeader, string? name = null, string? operation = null)
		{
			return SentrySdk.ContinueTrace(traceHeader, baggageHeader, name, operation);
		}

		[DebuggerStepThrough]
		public void StartSession()
		{
			SentrySdk.StartSession();
		}

		[DebuggerStepThrough]
		public void PauseSession()
		{
			SentrySdk.PauseSession();
		}

		[DebuggerStepThrough]
		public void ResumeSession()
		{
			SentrySdk.ResumeSession();
		}

		[DebuggerStepThrough]
		public void EndSession(SessionEndStatus status = SessionEndStatus.Exited)
		{
			SentrySdk.EndSession(status);
		}

		[DebuggerStepThrough]
		public void BindClient(ISentryClient client)
		{
			SentrySdk.BindClient(client);
		}

		[DebuggerStepThrough]
		public void AddBreadcrumb(string message, string? category = null, string? type = null, IDictionary<string, string>? data = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			SentrySdk.AddBreadcrumb(message, category, type, data, level);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddBreadcrumb(ISystemClock clock, string message, string? category = null, string? type = null, IDictionary<string, string>? data = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			SentrySdk.AddBreadcrumb(clock, message, category, type, data, level);
		}

		[DebuggerStepThrough]
		public SentryId CaptureEvent(SentryEvent evt)
		{
			return SentrySdk.CaptureEvent(evt);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SentryId CaptureEvent(SentryEvent evt, Scope? scope)
		{
			return SentrySdk.CaptureEvent(evt, scope);
		}

		public bool CaptureEnvelope(Envelope envelope)
		{
			return SentrySdk.CurrentHub.CaptureEnvelope(envelope);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SentryId CaptureEvent(SentryEvent evt, Scope? scope, SentryHint? hint = null)
		{
			return SentrySdk.CaptureEvent(evt, scope, hint);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SentryId CaptureEvent(SentryEvent evt, Action<Scope> configureScope)
		{
			return SentrySdk.CaptureEvent(evt, configureScope);
		}

		public SentryId CaptureEvent(SentryEvent evt, SentryHint? hint, Action<Scope> configureScope)
		{
			return SentrySdk.CaptureEvent(evt, hint, configureScope);
		}

		[DebuggerStepThrough]
		public SentryId CaptureException(Exception exception)
		{
			return SentrySdk.CaptureException(exception);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CaptureTransaction(SentryTransaction transaction)
		{
			SentrySdk.CaptureTransaction(transaction);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CaptureTransaction(SentryTransaction transaction, Scope? scope, SentryHint? hint)
		{
			SentrySdk.CaptureTransaction(transaction, scope, hint);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CaptureSession(SessionUpdate sessionUpdate)
		{
			SentrySdk.CaptureSession(sessionUpdate);
		}

		public SentryId CaptureCheckIn(string monitorSlug, CheckInStatus status, SentryId? sentryId = null, TimeSpan? duration = null, Scope? scope = null, Action<SentryMonitorOptions>? monitorOptions = null)
		{
			return SentrySdk.CaptureCheckIn(monitorSlug, status, sentryId, duration, scope, monitorOptions);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Task FlushAsync(TimeSpan timeout)
		{
			return SentrySdk.FlushAsync(timeout);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CaptureUserFeedback(UserFeedback sentryUserFeedback)
		{
			SentrySdk.CaptureUserFeedback(sentryUserFeedback);
		}
	}
}
