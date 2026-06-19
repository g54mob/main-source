using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Internal;
using Sentry.Protocol.Envelopes;

namespace Sentry
{
	public static class SentrySdk
	{
		private class DisposeHandle : IDisposable
		{
			private IHub _localHub;

			public DisposeHandle(IHub hub)
			{
				_localHub = hub;
			}

			public void Dispose()
			{
				Interlocked.CompareExchange(ref CurrentHub, DisabledHub.Instance, _localHub);
				(_localHub as IDisposable)?.Dispose();
				_localHub = null;
			}
		}

		internal static IHub CurrentHub = DisabledHub.Instance;

		internal static SentryOptions? CurrentOptions => CurrentHub.GetSentryOptions();

		public static SentryId LastEventId
		{
			[DebuggerStepThrough]
			get
			{
				return CurrentHub.LastEventId;
			}
		}

		public static bool IsEnabled
		{
			[DebuggerStepThrough]
			get
			{
				return CurrentHub.IsEnabled;
			}
		}

		[Obsolete("The SentrySdk.Metrics module is deprecated and will be removed in the next major release. Sentry will reject all metrics sent after October 7, 2024.Learn more: https://sentry.zendesk.com/hc/en-us/articles/26369339769883-Upcoming-API-Changes-to-Metrics")]
		public static IMetricAggregator Metrics => CurrentHub.Metrics;

		internal static IHub InitHub(SentryOptions options)
		{
			options.SetupLogging();
			if (ProcessInfo.Instance == null)
			{
				ProcessInfo.Instance = new ProcessInfo(options);
			}
			string dsn = options.SettingLocator.GetDsn();
			if (Dsn.IsDisabled(dsn))
			{
				options.LogWarning("Init called with an empty string as the DSN. Sentry SDK will be disabled.");
				return DisabledHub.Instance;
			}
			if (Dsn.Parse(dsn).SecretKey != null)
			{
				options.LogWarning("The provided DSN that contains a secret key. This is not required and will be ignored.");
			}
			options.LogDebug("This doesn't look like a Native AOT application build.");
			_ = options.InitNativeSdks;
			Hub hub = new Hub(options);
			foreach (Action<IHub> postInitCallback in options.PostInitCallbacks)
			{
				postInitCallback(hub);
			}
			options.PostInitCallbacks.Clear();
			LogWarningIfProfilingMisconfigured(options, ", because ProfilingIntegration from package Sentry.Profiling hasn't been registered. You can do that by calling 'options.AddIntegration(new ProfilingIntegration())'");
			return hub;
		}

		private static void LogWarningIfProfilingMisconfigured(SentryOptions options, string info)
		{
			if (options.IsProfilingEnabled && options.TransactionProfilerFactory == null)
			{
				options.LogWarning("You've tried to enable profiling in options, but it is not available{0}.", info);
			}
		}

		public static IDisposable Init()
		{
			return Init((string?)null);
		}

		public static IDisposable Init(string? dsn)
		{
			if (Dsn.IsDisabled(dsn))
			{
				return DisabledHub.Instance;
			}
			return Init(delegate(SentryOptions c)
			{
				c.Dsn = dsn;
			});
		}

		public static IDisposable Init(Action<SentryOptions>? configureOptions)
		{
			SentryOptions sentryOptions = new SentryOptions();
			configureOptions?.Invoke(sentryOptions);
			return Init(sentryOptions);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IDisposable Init(SentryOptions options)
		{
			return UseHub(InitHub(options));
		}

		internal static IDisposable UseHub(IHub hub)
		{
			(Interlocked.Exchange(ref CurrentHub, hub) as IDisposable)?.Dispose();
			return new DisposeHandle(hub);
		}

		[DebuggerStepThrough]
		public static void Flush()
		{
			CurrentHub.Flush();
		}

		[DebuggerStepThrough]
		public static void Flush(TimeSpan timeout)
		{
			CurrentHub.Flush(timeout);
		}

		[DebuggerStepThrough]
		public static Task FlushAsync()
		{
			return CurrentHub.FlushAsync();
		}

		[DebuggerStepThrough]
		public static Task FlushAsync(TimeSpan timeout)
		{
			return CurrentHub.FlushAsync(timeout);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Close()
		{
			(Interlocked.Exchange(ref CurrentHub, DisabledHub.Instance) as IDisposable)?.Dispose();
			ProcessInfo.Instance = null;
		}

		[DebuggerStepThrough]
		public static IDisposable PushScope<TState>(TState state)
		{
			return CurrentHub.PushScope(state);
		}

		[DebuggerStepThrough]
		public static IDisposable PushScope()
		{
			return CurrentHub.PushScope();
		}

		[DebuggerStepThrough]
		public static void BindClient(ISentryClient client)
		{
			CurrentHub.BindClient(client);
		}

		[DebuggerStepThrough]
		public static void AddBreadcrumb(string message, string? category = null, string? type = null, IDictionary<string, string>? data = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			CurrentHub.AddBreadcrumb(message, category, type, data, level);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void AddBreadcrumb(ISystemClock? clock, string message, string? category = null, string? type = null, IDictionary<string, string>? data = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			CurrentHub.AddBreadcrumb(clock, message, category, type, data, level);
		}

		[DebuggerStepThrough]
		public static void AddBreadcrumb(Breadcrumb breadcrumb, SentryHint? hint = null)
		{
			CurrentHub.AddBreadcrumb(breadcrumb, hint);
		}

		[DebuggerStepThrough]
		public static void ConfigureScope(Action<Scope> configureScope)
		{
			CurrentHub.ConfigureScope(configureScope);
		}

		[DebuggerStepThrough]
		public static Task ConfigureScopeAsync(Func<Scope, Task> configureScope)
		{
			return CurrentHub.ConfigureScopeAsync(configureScope);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool CaptureEnvelope(Envelope envelope)
		{
			return CurrentHub.CaptureEnvelope(envelope);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static SentryId CaptureEvent(SentryEvent evt, Scope? scope = null, SentryHint? hint = null)
		{
			return CurrentHub.CaptureEvent(evt, scope, hint);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static SentryId CaptureEvent(SentryEvent evt, Action<Scope> configureScope)
		{
			return CurrentHub.CaptureEvent(evt, null, configureScope);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static SentryId CaptureEvent(SentryEvent evt, SentryHint? hint, Action<Scope> configureScope)
		{
			return CurrentHub.CaptureEvent(evt, hint, configureScope);
		}

		[DebuggerStepThrough]
		public static SentryId CaptureException(Exception exception)
		{
			return CurrentHub.CaptureException(exception);
		}

		[DebuggerStepThrough]
		public static SentryId CaptureException(Exception exception, Action<Scope> configureScope)
		{
			return CurrentHub.CaptureException(exception, configureScope);
		}

		[DebuggerStepThrough]
		public static SentryId CaptureMessage(string message, SentryLevel level = SentryLevel.Info)
		{
			return CurrentHub.CaptureMessage(message, level);
		}

		[DebuggerStepThrough]
		public static SentryId CaptureMessage(string message, Action<Scope> configureScope, SentryLevel level = SentryLevel.Info)
		{
			return CurrentHub.CaptureMessage(message, configureScope, level);
		}

		[DebuggerStepThrough]
		public static void CaptureUserFeedback(UserFeedback userFeedback)
		{
			CurrentHub.CaptureUserFeedback(userFeedback);
		}

		[DebuggerStepThrough]
		public static void CaptureUserFeedback(SentryId eventId, string email, string comments, string? name = null)
		{
			CurrentHub.CaptureUserFeedback(new UserFeedback(eventId, name, email, comments));
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void CaptureTransaction(SentryTransaction transaction)
		{
			CurrentHub.CaptureTransaction(transaction);
		}

		[DebuggerStepThrough]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void CaptureTransaction(SentryTransaction transaction, Scope? scope, SentryHint? hint)
		{
			CurrentHub.CaptureTransaction(transaction, scope, hint);
		}

		[DebuggerStepThrough]
		public static void CaptureSession(SessionUpdate sessionUpdate)
		{
			CurrentHub.CaptureSession(sessionUpdate);
		}

		[DebuggerStepThrough]
		public static SentryId CaptureCheckIn(string monitorSlug, CheckInStatus status, SentryId? sentryId = null, TimeSpan? duration = null, Scope? scope = null, Action<SentryMonitorOptions>? configureMonitorOptions = null)
		{
			return CurrentHub.CaptureCheckIn(monitorSlug, status, sentryId, duration, scope, configureMonitorOptions);
		}

		[DebuggerStepThrough]
		public static ITransactionTracer StartTransaction(ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext)
		{
			return CurrentHub.StartTransaction(context, customSamplingContext);
		}

		[DebuggerStepThrough]
		internal static ITransactionTracer StartTransaction(ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext, DynamicSamplingContext? dynamicSamplingContext)
		{
			return CurrentHub.StartTransaction(context, customSamplingContext, dynamicSamplingContext);
		}

		[DebuggerStepThrough]
		public static ITransactionTracer StartTransaction(ITransactionContext context)
		{
			return CurrentHub.StartTransaction(context);
		}

		[DebuggerStepThrough]
		public static ITransactionTracer StartTransaction(string name, string operation)
		{
			return CurrentHub.StartTransaction(name, operation);
		}

		[DebuggerStepThrough]
		public static ITransactionTracer StartTransaction(string name, string operation, string? description)
		{
			return CurrentHub.StartTransaction(name, operation, description);
		}

		[DebuggerStepThrough]
		public static ITransactionTracer StartTransaction(string name, string operation, SentryTraceHeader traceHeader)
		{
			return CurrentHub.StartTransaction(name, operation, traceHeader);
		}

		[DebuggerStepThrough]
		public static void BindException(Exception exception, ISpan span)
		{
			CurrentHub.BindException(exception, span);
		}

		[DebuggerStepThrough]
		public static ISpan? GetSpan()
		{
			return CurrentHub.GetSpan();
		}

		[DebuggerStepThrough]
		public static SentryTraceHeader? GetTraceHeader()
		{
			return CurrentHub.GetTraceHeader();
		}

		[DebuggerStepThrough]
		public static BaggageHeader? GetBaggage()
		{
			return CurrentHub.GetBaggage();
		}

		[DebuggerStepThrough]
		public static TransactionContext ContinueTrace(string? traceHeader, string? baggageHeader, string? name = null, string? operation = null)
		{
			return CurrentHub.ContinueTrace(traceHeader, baggageHeader, name, operation);
		}

		[DebuggerStepThrough]
		public static TransactionContext ContinueTrace(SentryTraceHeader? traceHeader, BaggageHeader? baggageHeader, string? name = null, string? operation = null)
		{
			return CurrentHub.ContinueTrace(traceHeader, baggageHeader, name, operation);
		}

		[DebuggerStepThrough]
		public static void StartSession()
		{
			CurrentHub.StartSession();
		}

		[DebuggerStepThrough]
		public static void EndSession(SessionEndStatus status = SessionEndStatus.Exited)
		{
			CurrentHub.EndSession(status);
		}

		[DebuggerStepThrough]
		public static void PauseSession()
		{
			CurrentHub.PauseSession();
		}

		[DebuggerStepThrough]
		public static void ResumeSession()
		{
			CurrentHub.ResumeSession();
		}

		[Obsolete("WARNING: This method deliberately causes a crash, and should not be used in a real application.")]
		public static void CauseCrash(CrashType crashType)
		{
			string text = string.Format("{0}.{1}({2}.{3})", "SentrySdk", "CauseCrash", "CrashType", crashType);
			string msg = "This exception was caused deliberately by " + text + ".";
			CurrentOptions?.LogDebug("Triggering a deliberate exception because {0} was called", text);
			switch (crashType)
			{
			case CrashType.Managed:
				throw new ApplicationException(msg);
			case CrashType.ManagedBackgroundThread:
				new Thread((ThreadStart)delegate
				{
					throw new ApplicationException(msg);
				}).Start();
				CurrentOptions?.LogWarning("Something went wrong in {0}, execution should never reach this.", text);
				break;
			default:
				throw new ArgumentOutOfRangeException("crashType", crashType, null);
			}
		}
	}
}
