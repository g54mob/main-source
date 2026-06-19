using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Protocol.Envelopes;

namespace Sentry
{
	public class SentryClient : ISentryClient, IDisposable
	{
		private readonly SentryOptions _options;

		private readonly ISessionManager _sessionManager;

		private readonly RandomValuesFactory _randomValuesFactory;

		private readonly Enricher _enricher;

		internal IBackgroundWorker Worker { get; }

		internal SentryOptions Options => _options;

		public bool IsEnabled => true;

		public SentryClient(SentryOptions options)
			: this(options, null, null, null)
		{
		}

		internal SentryClient(SentryOptions options, IBackgroundWorker? worker = null, RandomValuesFactory? randomValuesFactory = null, ISessionManager? sessionManager = null)
		{
			_options = options ?? throw new ArgumentNullException("options");
			_randomValuesFactory = randomValuesFactory ?? new SynchronizedRandomValuesFactory();
			_sessionManager = sessionManager ?? new GlobalSessionManager(options);
			_enricher = new Enricher(options);
			options.SetupLogging();
			if (worker == null)
			{
				SdkComposer sdkComposer = new SdkComposer(options);
				Worker = sdkComposer.CreateBackgroundWorker();
			}
			else
			{
				options.LogDebug("Worker of type {0} was provided via Options.", worker.GetType().Name);
				Worker = worker;
			}
		}

		public SentryId CaptureEvent(SentryEvent? @event, Scope? scope = null, SentryHint? hint = null)
		{
			if (@event == null)
			{
				return SentryId.Empty;
			}
			try
			{
				return DoSendEvent(@event, hint, scope);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "An error occurred when capturing the event {0}.", @event.EventId);
				return SentryId.Empty;
			}
		}

		public void CaptureUserFeedback(UserFeedback userFeedback)
		{
			if (userFeedback.EventId.Equals(SentryId.Empty))
			{
				_options.LogWarning("User feedback dropped due to empty id.");
			}
			else
			{
				CaptureEnvelope(Envelope.FromUserFeedback(userFeedback));
			}
		}

		public void CaptureTransaction(SentryTransaction transaction)
		{
			CaptureTransaction(transaction, null, null);
		}

		public void CaptureTransaction(SentryTransaction transaction, Scope? scope, SentryHint? hint)
		{
			if (transaction.SpanId.Equals(SpanId.Empty))
			{
				_options.LogWarning("Transaction dropped due to empty id.");
				return;
			}
			if (string.IsNullOrWhiteSpace(transaction.Name) || string.IsNullOrWhiteSpace(transaction.Operation))
			{
				_options.LogWarning("Transaction discarded due to one or more required fields missing.");
				return;
			}
			if (!transaction.IsFinished)
			{
				_options.LogWarning("Capturing a transaction which has not been finished. Please call transaction.Finish() instead of hub.CaptureTransaction(transaction) to properly finalize the transaction and send it to Sentry.");
			}
			int quantity = transaction.Spans.Count + 1;
			if ((!transaction.IsSampled) ?? false)
			{
				_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.SampleRate, DataCategory.Transaction);
				_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.SampleRate, DataCategory.Span, quantity);
				_options.LogDebug("Transaction dropped by sampling.");
				return;
			}
			if (scope == null)
			{
				scope = new Scope(_options);
			}
			if (hint == null)
			{
				hint = new SentryHint();
			}
			hint.AddAttachmentsFromScope(scope);
			_options.LogInfo("Capturing transaction.");
			scope.Evaluate();
			scope.Apply(transaction);
			_enricher.Apply(transaction);
			SentryTransaction sentryTransaction = transaction;
			foreach (ISentryTransactionProcessor allTransactionProcessor in scope.GetAllTransactionProcessors())
			{
				sentryTransaction = allTransactionProcessor.DoProcessTransaction(transaction, hint);
				if (sentryTransaction == null)
				{
					_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.EventProcessor, DataCategory.Transaction);
					_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.EventProcessor, DataCategory.Span, quantity);
					_options.LogInfo("Event dropped by processor {0}", allTransactionProcessor.GetType().Name);
					return;
				}
			}
			sentryTransaction = BeforeSendTransaction(sentryTransaction, hint);
			if (sentryTransaction == null)
			{
				_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.BeforeSend, DataCategory.Transaction);
				_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.BeforeSend, DataCategory.Span, quantity);
				_options.LogInfo("Transaction dropped by BeforeSendTransaction callback.");
				return;
			}
			if (!_options.SendDefaultPii)
			{
				sentryTransaction.Redact();
			}
			CaptureEnvelope(Envelope.FromTransaction(sentryTransaction));
		}

		private SentryTransaction? BeforeSendTransaction(SentryTransaction transaction, SentryHint hint)
		{
			if (_options.BeforeSendTransactionInternal == null)
			{
				return transaction;
			}
			_options.LogDebug("Calling the BeforeSendTransaction callback");
			try
			{
				return _options.BeforeSendTransactionInternal?.Invoke(transaction, hint);
			}
			catch (Exception ex)
			{
				ex.Demystify();
				_options.LogError(ex, "The BeforeSendTransaction callback threw an exception. It will be added as breadcrumb and continue.");
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "message", ex.Message } };
				if (ex.StackTrace != null)
				{
					dictionary.Add("stackTrace", ex.StackTrace);
				}
				transaction.AddBreadcrumb("BeforeSendTransaction callback failed.", "SentryClient", null, dictionary, BreadcrumbLevel.Error);
				return transaction;
			}
		}

		public void CaptureSession(SessionUpdate sessionUpdate)
		{
			CaptureEnvelope(Envelope.FromSession(sessionUpdate));
		}

		public SentryId CaptureCheckIn(string monitorSlug, CheckInStatus status, SentryId? sentryId = null, TimeSpan? duration = null, Scope? scope = null, Action<SentryMonitorOptions>? configureMonitorOptions = null)
		{
			if (scope == null)
			{
				scope = new Scope(_options);
			}
			SentryId traceId = scope.PropagationContext.TraceId;
			if (scope.Span != null)
			{
				traceId = scope.Span.TraceId;
			}
			SentryCheckIn sentryCheckIn = new SentryCheckIn(monitorSlug, status, sentryId)
			{
				Duration = duration,
				TraceId = traceId
			};
			if (configureMonitorOptions != null)
			{
				SentryMonitorOptions sentryMonitorOptions = new SentryMonitorOptions();
				configureMonitorOptions(sentryMonitorOptions);
				sentryCheckIn.MonitorOptions = sentryMonitorOptions;
			}
			_enricher.Apply(sentryCheckIn);
			if (!CaptureEnvelope(Envelope.FromCheckIn(sentryCheckIn)))
			{
				return SentryId.Empty;
			}
			return sentryCheckIn.Id;
		}

		public Task FlushAsync(TimeSpan timeout)
		{
			return Worker.FlushAsync(timeout);
		}

		private SentryId DoSendEvent(SentryEvent @event, SentryHint? hint, Scope? scope)
		{
			IReadOnlyCollection<Exception> readOnlyCollection = ApplyExceptionFilters(@event.Exception);
			if (readOnlyCollection != null && readOnlyCollection.Count > 0)
			{
				_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.EventProcessor, DataCategory.Error);
				_options.LogInfo("Event was dropped by one or more exception filters for exception(s): {0}", string.Join(", ", readOnlyCollection.Select((Exception e) => e.GetType()).Distinct()));
				return SentryId.Empty;
			}
			if (scope == null)
			{
				scope = new Scope(_options);
			}
			if (hint == null)
			{
				hint = new SentryHint();
			}
			hint.AddAttachmentsFromScope(scope);
			_options.LogInfo("Capturing event.");
			scope.Evaluate();
			scope.Apply(@event);
			if (scope.Level.HasValue)
			{
				_options.LogInfo("Overriding level set on event '{0}' with level set on scope '{1}'.", @event.Level, scope.Level);
				@event.Level = scope.Level;
			}
			if (@event.Exception != null)
			{
				foreach (ISentryEventExceptionProcessor allExceptionProcessor in scope.GetAllExceptionProcessors())
				{
					allExceptionProcessor.Process(@event.Exception, @event);
				}
			}
			SentryEvent sentryEvent = @event;
			foreach (ISentryEventProcessor allEventProcessor in scope.GetAllEventProcessors())
			{
				sentryEvent = allEventProcessor.DoProcessEvent(sentryEvent, hint);
				if (sentryEvent == null)
				{
					_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.EventProcessor, DataCategory.Error);
					_options.LogInfo("Event dropped by processor {0}", allEventProcessor.GetType().Name);
					return SentryId.Empty;
				}
			}
			sentryEvent = BeforeSend(sentryEvent, hint);
			if (sentryEvent == null)
			{
				_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.BeforeSend, DataCategory.Error);
				_options.LogInfo("Event dropped by BeforeSend callback.");
				return SentryId.Empty;
			}
			if (sentryEvent.HasTerminalException())
			{
				_options.LogDebug("Ending session as Crashed, due to unhandled exception.");
				scope.SessionUpdate = _sessionManager.EndSession(SessionEndStatus.Crashed);
			}
			else if (sentryEvent.HasException())
			{
				scope.SessionUpdate = _sessionManager.ReportError();
			}
			if (_options.SampleRate.HasValue)
			{
				if (!_randomValuesFactory.NextBool(_options.SampleRate.Value))
				{
					_options.ClientReportRecorder.RecordDiscardedEvent(DiscardReason.SampleRate, DataCategory.Error);
					_options.LogDebug("Event sampled.");
					return SentryId.Empty;
				}
			}
			else
			{
				_options.LogDebug("Event not sampled.");
			}
			if (!_options.SendDefaultPii)
			{
				sentryEvent.Redact();
			}
			List<SentryAttachment> attachments = hint.Attachments.ToList();
			Envelope envelope = Envelope.FromEvent(sentryEvent, _options.DiagnosticLogger, attachments, scope.SessionUpdate);
			if (!CaptureEnvelope(envelope))
			{
				return SentryId.Empty;
			}
			return sentryEvent.EventId;
		}

		private IReadOnlyCollection<Exception>? ApplyExceptionFilters(Exception? exception)
		{
			List<IExceptionFilter> exceptionFilters = _options.ExceptionFilters;
			if (exception == null || exceptionFilters == null || exceptionFilters.Count == 0)
			{
				return null;
			}
			if (exceptionFilters.Any((IExceptionFilter f) => f.Filter(exception)))
			{
				return new Exception[1] { exception };
			}
			if (exception is AggregateException ex)
			{
				ReadOnlyCollection<Exception> innerExceptions = ex.Flatten().InnerExceptions;
				if (innerExceptions.All((Exception e) => ApplyExceptionFilters(e) != null))
				{
					return innerExceptions;
				}
			}
			return null;
		}

		public bool CaptureEnvelope(Envelope envelope)
		{
			if (Worker.EnqueueEnvelope(envelope))
			{
				_options.LogInfo("Envelope queued up: '{0}'", envelope.TryGetEventId(_options.DiagnosticLogger));
				return true;
			}
			_options.LogWarning("The attempt to queue the event failed. Items in queue: {0}", Worker.QueuedItems);
			return false;
		}

		private SentryEvent? BeforeSend(SentryEvent? @event, SentryHint hint)
		{
			if (_options.BeforeSendInternal == null)
			{
				return @event;
			}
			_options.LogDebug("Calling the BeforeSend callback");
			try
			{
				@event = _options.BeforeSendInternal?.Invoke(@event, hint);
			}
			catch (Exception ex)
			{
				ex.Demystify();
				_options.LogError(ex, "The BeforeSend callback threw an exception. It will be added as breadcrumb and continue.");
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "message", ex.Message } };
				if (ex.StackTrace != null)
				{
					dictionary.Add("stackTrace", ex.StackTrace);
				}
				@event?.AddBreadcrumb("BeforeSend callback failed.", "SentryClient", null, dictionary, BreadcrumbLevel.Error);
			}
			return @event;
		}

		public void Dispose()
		{
			_options.LogDebug("Flushing SentryClient.");
			try
			{
				Worker.FlushAsync(_options.ShutdownTimeout).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter()
					.GetResult();
			}
			catch
			{
				_options.LogDebug("Failed to wait on worker to flush");
			}
		}
	}
}
