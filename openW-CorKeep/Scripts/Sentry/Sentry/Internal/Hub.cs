using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Integrations;
using Sentry.Protocol.Envelopes;
using Sentry.Protocol.Metrics;

namespace Sentry.Internal
{
	internal class Hub : IHub, ISentryClient, ISentryScopeManager, IMetricHub, IDisposable
	{
		private readonly object _sessionPauseLock = new object();

		private readonly ISystemClock _clock;

		private readonly ISessionManager _sessionManager;

		private readonly SentryOptions _options;

		private readonly RandomValuesFactory _randomValuesFactory;

		private int _isPersistedSessionRecovered;

		private int _isEnabled = 1;

		internal ConditionalWeakTable<Exception, ISpan> ExceptionToSpanMap { get; } = new ConditionalWeakTable<Exception, ISpan>();

		internal IInternalScopeManager ScopeManager { get; }

		public IMetricAggregator Metrics { get; }

		public bool IsEnabled => _isEnabled == 1;

		internal SentryOptions Options => _options;

		private Scope CurrentScope => ScopeManager.GetCurrent().Key;

		private ISentryClient CurrentClient => ScopeManager.GetCurrent().Value;

		public SentryId LastEventId => CurrentScope.LastEventId;

		internal Hub(SentryOptions options, ISentryClient? client = null, ISessionManager? sessionManager = null, ISystemClock? clock = null, IInternalScopeManager? scopeManager = null, RandomValuesFactory? randomValuesFactory = null)
		{
			if (string.IsNullOrWhiteSpace(options.Dsn))
			{
				options.LogFatal("Attempt to instantiate a Hub without a DSN.");
				throw new InvalidOperationException("Attempt to instantiate a Hub without a DSN.");
			}
			options.LogDebug("Initializing Hub for Dsn: '{0}'.", options.Dsn);
			_options = options;
			_randomValuesFactory = randomValuesFactory ?? new SynchronizedRandomValuesFactory();
			_sessionManager = sessionManager ?? new GlobalSessionManager(options);
			_clock = clock ?? SystemClock.Clock;
			if (client == null)
			{
				client = new SentryClient(options, null, _randomValuesFactory, _sessionManager);
			}
			ScopeManager = scopeManager ?? new SentryScopeManager(options, client);
			if (!options.IsGlobalModeEnabled)
			{
				PushScope();
			}
			if (options.ExperimentalMetrics != null)
			{
				options.LogDebug("Registering integration: Metrics");
				Metrics = new MetricAggregator(options, this);
			}
			else
			{
				Metrics = new DisabledMetricAggregator();
			}
			foreach (ISdkIntegration integration in options.Integrations)
			{
				options.LogDebug("Registering integration: '{0}'.", integration.GetType().Name);
				integration.Register(this, options);
			}
		}

		public void ConfigureScope(Action<Scope> configureScope)
		{
			try
			{
				ScopeManager.ConfigureScope(configureScope);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to ConfigureScope");
			}
		}

		public async Task ConfigureScopeAsync(Func<Scope, Task> configureScope)
		{
			try
			{
				await ScopeManager.ConfigureScopeAsync(configureScope).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to ConfigureScopeAsync");
			}
		}

		public IDisposable PushScope()
		{
			return ScopeManager.PushScope();
		}

		public IDisposable PushScope<TState>(TState state)
		{
			return ScopeManager.PushScope(state);
		}

		public void RestoreScope(Scope savedScope)
		{
			ScopeManager.RestoreScope(savedScope);
		}

		public void BindClient(ISentryClient client)
		{
			ScopeManager.BindClient(client);
		}

		public ITransactionTracer StartTransaction(ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext)
		{
			return StartTransaction(context, customSamplingContext, null);
		}

		internal ITransactionTracer StartTransaction(ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext, DynamicSamplingContext? dynamicSamplingContext)
		{
			TransactionTracer transactionTracer = new TransactionTracer(this, context);
			if (!IsEnabled || ((!_options.EnableTracing) ?? false))
			{
				transactionTracer.IsSampled = false;
				transactionTracer.SampleRate = 0.0;
			}
			else
			{
				Func<TransactionSamplingContext, double?> tracesSampler = _options.TracesSampler;
				if (tracesSampler != null)
				{
					TransactionSamplingContext arg = new TransactionSamplingContext(context, customSamplingContext);
					double? num = tracesSampler(arg);
					if (num.HasValue)
					{
						double valueOrDefault = num.GetValueOrDefault();
						transactionTracer.IsSampled = _randomValuesFactory.NextBool(valueOrDefault);
						transactionTracer.SampleRate = valueOrDefault;
					}
				}
				if (!transactionTracer.IsSampled.HasValue)
				{
					double num2 = _options.TracesSampleRate ?? ((_options.EnableTracing ?? false) ? 1.0 : 0.0);
					transactionTracer.IsSampled = _randomValuesFactory.NextBool(num2);
					transactionTracer.SampleRate = num2;
				}
				if (transactionTracer.IsSampled ?? false)
				{
					ITransactionProfilerFactory transactionProfilerFactory = _options.TransactionProfilerFactory;
					if (transactionProfilerFactory != null && _randomValuesFactory.NextBool(_options.ProfilesSampleRate.GetValueOrDefault()))
					{
						transactionTracer.TransactionProfiler = transactionProfilerFactory.Start(transactionTracer, CancellationToken.None);
					}
				}
			}
			transactionTracer.DynamicSamplingContext = dynamicSamplingContext ?? transactionTracer.CreateDynamicSamplingContext(_options);
			return transactionTracer;
		}

		public void BindException(Exception exception, ISpan span)
		{
			if (span.IsSampled != false)
			{
				ExceptionToSpanMap.GetValue(exception, (Exception _) => span);
			}
		}

		public ISpan? GetSpan()
		{
			return CurrentScope.Span;
		}

		public SentryTraceHeader GetTraceHeader()
		{
			SentryTraceHeader sentryTraceHeader = GetSpan()?.GetTraceHeader();
			if (sentryTraceHeader != null)
			{
				return sentryTraceHeader;
			}
			SentryPropagationContext propagationContext = CurrentScope.PropagationContext;
			return new SentryTraceHeader(propagationContext.TraceId, propagationContext.SpanId, null);
		}

		public BaggageHeader GetBaggage()
		{
			if (GetSpan()?.GetTransaction() is TransactionTracer transactionTracer)
			{
				DynamicSamplingContext dynamicSamplingContext = transactionTracer.DynamicSamplingContext;
				if (dynamicSamplingContext != null && !dynamicSamplingContext.IsEmpty)
				{
					return dynamicSamplingContext.ToBaggageHeader();
				}
			}
			return CurrentScope.PropagationContext.GetOrCreateDynamicSamplingContext(_options).ToBaggageHeader();
		}

		public TransactionContext ContinueTrace(string? traceHeader, string? baggageHeader, string? name = null, string? operation = null)
		{
			SentryTraceHeader traceHeader2 = null;
			if (traceHeader != null)
			{
				traceHeader2 = SentryTraceHeader.Parse(traceHeader);
			}
			BaggageHeader baggageHeader2 = null;
			if (baggageHeader != null)
			{
				baggageHeader2 = BaggageHeader.TryParse(baggageHeader, onlySentry: true);
			}
			return ContinueTrace(traceHeader2, baggageHeader2, name, operation);
		}

		public TransactionContext ContinueTrace(SentryTraceHeader? traceHeader, BaggageHeader? baggageHeader, string? name = null, string? operation = null)
		{
			SentryPropagationContext propagationContext = SentryPropagationContext.CreateFromHeaders(_options.DiagnosticLogger, traceHeader, baggageHeader);
			ConfigureScope(delegate(Scope scope)
			{
				scope.PropagationContext = propagationContext;
			});
			string? name2 = name ?? string.Empty;
			string? operation2 = operation ?? string.Empty;
			SpanId? spanId = propagationContext.SpanId;
			SpanId? parentSpanId = propagationContext.ParentSpanId;
			SentryId? traceId = propagationContext.TraceId;
			bool? isSampled = traceHeader?.IsSampled;
			bool? isParentSampled = traceHeader?.IsSampled;
			return new TransactionContext(name2, operation2, spanId, parentSpanId, traceId, "", null, isSampled, isParentSampled);
		}

		public void StartSession()
		{
			if (Interlocked.Exchange(ref _isPersistedSessionRecovered, 1) != 1)
			{
				try
				{
					SessionUpdate sessionUpdate = _sessionManager.TryRecoverPersistedSession();
					if (sessionUpdate != null)
					{
						CaptureSession(sessionUpdate);
					}
				}
				catch (Exception exception)
				{
					_options.LogError(exception, "Failed to recover persisted session.");
				}
			}
			try
			{
				SessionUpdate sessionUpdate2 = _sessionManager.StartSession();
				if (sessionUpdate2 != null)
				{
					CaptureSession(sessionUpdate2);
				}
			}
			catch (Exception exception2)
			{
				_options.LogError(exception2, "Failed to start a session.");
			}
		}

		public void PauseSession()
		{
			lock (_sessionPauseLock)
			{
				try
				{
					_sessionManager.PauseSession();
				}
				catch (Exception exception)
				{
					_options.LogError(exception, "Failed to pause a session.");
				}
			}
		}

		public void ResumeSession()
		{
			lock (_sessionPauseLock)
			{
				try
				{
					foreach (SessionUpdate item in _sessionManager.ResumeSession())
					{
						CaptureSession(item);
					}
				}
				catch (Exception exception)
				{
					_options.LogError(exception, "Failed to resume a session.");
				}
			}
		}

		private void EndSession(DateTimeOffset timestamp, SessionEndStatus status)
		{
			try
			{
				SessionUpdate sessionUpdate = _sessionManager.EndSession(timestamp, status);
				if (sessionUpdate != null)
				{
					CaptureSession(sessionUpdate);
				}
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failed to end a session.");
			}
		}

		public void EndSession(SessionEndStatus status = SessionEndStatus.Exited)
		{
			EndSession(_clock.GetUtcNow(), status);
		}

		private ISpan? GetLinkedSpan(SentryEvent evt)
		{
			Exception exception = evt.Exception;
			if (exception != null && ExceptionToSpanMap.TryGetValue(exception, out ISpan value))
			{
				return value;
			}
			return null;
		}

		private void ApplyTraceContextToEvent(SentryEvent evt, ISpan span)
		{
			evt.Contexts.Trace.SpanId = span.SpanId;
			evt.Contexts.Trace.TraceId = span.TraceId;
			evt.Contexts.Trace.ParentSpanId = span.ParentSpanId;
			if (span.GetTransaction() is TransactionTracer transactionTracer)
			{
				evt.DynamicSamplingContext = transactionTracer.DynamicSamplingContext;
			}
		}

		private void ApplyTraceContextToEvent(SentryEvent evt, SentryPropagationContext propagationContext)
		{
			evt.Contexts.Trace.TraceId = propagationContext.TraceId;
			evt.Contexts.Trace.SpanId = propagationContext.SpanId;
			evt.Contexts.Trace.ParentSpanId = propagationContext.ParentSpanId;
			evt.DynamicSamplingContext = propagationContext.GetOrCreateDynamicSamplingContext(_options);
		}

		public bool CaptureEnvelope(Envelope envelope)
		{
			return CurrentClient.CaptureEnvelope(envelope);
		}

		private void AddBreadcrumbForException(SentryEvent evt, Scope scope)
		{
			try
			{
				if (!IsEnabled)
				{
					return;
				}
				Exception exception = evt.Exception;
				if (exception != null)
				{
					string text = exception.Message ?? "";
					string text2 = evt.Message?.Formatted;
					Dictionary<string, string> data = null;
					string message;
					if (string.IsNullOrWhiteSpace(text2))
					{
						message = text;
					}
					else
					{
						message = text2;
						data = new Dictionary<string, string> { { "exception_message", text } };
					}
					scope.AddBreadcrumb(message, "Exception", null, data, BreadcrumbLevel.Critical);
				}
			}
			catch (Exception exception2)
			{
				_options.LogError(exception2, "Failure to store breadcrumb for exception event: {0}", evt.EventId);
			}
		}

		public SentryId CaptureEvent(SentryEvent evt, Action<Scope> configureScope)
		{
			return CaptureEvent(evt, null, configureScope);
		}

		public SentryId CaptureEvent(SentryEvent evt, SentryHint? hint, Action<Scope> configureScope)
		{
			if (!IsEnabled)
			{
				return SentryId.Empty;
			}
			try
			{
				Scope scope = CurrentScope.Clone();
				configureScope(scope);
				SentryId result = CaptureEvent(evt, hint, scope);
				AddBreadcrumbForException(evt, CurrentScope);
				return result;
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to capture event: {0}", evt.EventId);
				return SentryId.Empty;
			}
		}

		public SentryId CaptureEvent(SentryEvent evt, Scope? scope = null, SentryHint? hint = null)
		{
			if (scope == null)
			{
				scope = CurrentScope;
			}
			SentryId result = CaptureEvent(evt, hint, scope);
			AddBreadcrumbForException(evt, scope);
			return result;
		}

		private SentryId CaptureEvent(SentryEvent evt, SentryHint? hint, Scope scope)
		{
			if (!IsEnabled)
			{
				return SentryId.Empty;
			}
			try
			{
				ISpan span = GetLinkedSpan(evt) ?? scope.Span;
				if (span != null)
				{
					if (span.IsSampled ?? true)
					{
						ApplyTraceContextToEvent(evt, span);
					}
				}
				else
				{
					ApplyTraceContextToEvent(evt, scope.PropagationContext);
				}
				SentryId result = (scope.LastEventId = CurrentClient.CaptureEvent(evt, scope, hint));
				scope.SessionUpdate = null;
				if (evt.HasTerminalException())
				{
					ITransactionTracer transaction = scope.Transaction;
					if (transaction != null)
					{
						_options.LogDebug("Ending transaction as Aborted, due to unhandled exception.");
						transaction.Finish(SpanStatus.Aborted);
					}
				}
				return result;
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to capture event: {0}", evt.EventId);
				return SentryId.Empty;
			}
		}

		public void CaptureUserFeedback(UserFeedback userFeedback)
		{
			if (!IsEnabled)
			{
				return;
			}
			try
			{
				CurrentClient.CaptureUserFeedback(userFeedback);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to capture user feedback: {0}", userFeedback.EventId);
			}
		}

		public void CaptureTransaction(SentryTransaction transaction)
		{
			CaptureTransaction(transaction, null, null);
		}

		public void CaptureTransaction(SentryTransaction transaction, Scope? scope, SentryHint? hint)
		{
			try
			{
				CurrentClient.CaptureTransaction(transaction, scope ?? CurrentScope, hint);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to capture transaction: {0}", transaction.SpanId);
			}
		}

		public void CaptureMetrics(IEnumerable<Metric> metrics)
		{
			if (!IsEnabled)
			{
				return;
			}
			Metric[] array = null;
			try
			{
				array = (metrics as Metric[]) ?? metrics.ToArray();
				_options.LogDebug("Capturing metrics.");
				CurrentClient.CaptureEnvelope(Envelope.FromMetrics(metrics));
			}
			catch (Exception exception)
			{
				SentryId[] values = array?.Select((Metric m) => m.EventId).ToArray() ?? Array.Empty<SentryId>();
				_options.LogError(exception, "Failure to capture metrics: {0}", string.Join(",", values));
			}
		}

		public void CaptureCodeLocations(CodeLocations codeLocations)
		{
			if (!IsEnabled)
			{
				return;
			}
			try
			{
				_options.LogDebug("Capturing code locations for period: {0}", codeLocations.Timestamp);
				CurrentClient.CaptureEnvelope(Envelope.FromCodeLocations(codeLocations));
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to capture code locations");
			}
		}

		public ISpan StartSpan(string operation, string description)
		{
			ITransactionTracer currentTransaction = null;
			ConfigureScope(delegate(Scope s)
			{
				currentTransaction = s.Transaction;
			});
			if (currentTransaction != null)
			{
				ITransactionTracer span = currentTransaction;
				return span.StartChild(operation, description);
			}
			return this.StartTransaction(operation, description);
		}

		public void CaptureSession(SessionUpdate sessionUpdate)
		{
			if (!IsEnabled)
			{
				return;
			}
			try
			{
				CurrentClient.CaptureSession(sessionUpdate);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to capture session update: {0}", sessionUpdate.Id);
			}
		}

		public SentryId CaptureCheckIn(string monitorSlug, CheckInStatus status, SentryId? sentryId = null, TimeSpan? duration = null, Scope? scope = null, Action<SentryMonitorOptions>? configureMonitorOptions = null)
		{
			if (!IsEnabled)
			{
				return SentryId.Empty;
			}
			try
			{
				_options.LogDebug("Capturing '{0}' check-in for '{1}'", status, monitorSlug);
				if (scope == null)
				{
					scope = CurrentScope;
				}
				return CurrentClient.CaptureCheckIn(monitorSlug, status, sentryId, duration, scope, configureMonitorOptions);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failed to capture check in for: {0}", monitorSlug);
			}
			return SentryId.Empty;
		}

		public async Task FlushAsync(TimeSpan timeout)
		{
			try
			{
				await CurrentClient.FlushAsync(timeout).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failure to Flush events");
			}
		}

		public void Dispose()
		{
			_options.LogInfo("Disposing the Hub.");
			if (Interlocked.Exchange(ref _isEnabled, 0) != 1)
			{
				return;
			}
			try
			{
				CurrentClient.FlushAsync(_options.ShutdownTimeout).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter()
					.GetResult();
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failed to wait on disposing tasks to flush.");
			}
		}
	}
}
