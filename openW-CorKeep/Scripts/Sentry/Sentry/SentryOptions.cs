using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Sentry.Extensibility;
using Sentry.Http;
using Sentry.Infrastructure;
using Sentry.Integrations;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Internal.Http;
using Sentry.Internal.ScopeStack;
using Sentry.PlatformAbstractions;

namespace Sentry
{
	public class SentryOptions
	{
		[Flags]
		internal enum DefaultIntegrations
		{
			AutoSessionTrackingIntegration = 1,
			AppDomainUnhandledExceptionIntegration = 2,
			AppDomainProcessExitIntegration = 4,
			UnobservedTaskExceptionIntegration = 8
		}

		private Dictionary<string, string>? _defaultTags;

		private const RegexOptions DefaultRegexOptions = RegexOptions.Compiled | RegexOptions.CultureInvariant;

		private readonly Lazy<string?> _lazyInstallationId;

		private bool? _isGlobalModeEnabled;

		private Lazy<IClientReportRecorder> _clientReportRecorder;

		private Lazy<ISentryStackTraceFactory> _sentryStackTraceFactory;

		private DefaultIntegrations _defaultIntegrations;

		private float? _sampleRate;

		private string? _dsn;

		internal Dsn? _parsedDsn;

		private readonly Lazy<string> _sentryBaseUrl;

		private Func<SentryEvent, SentryHint, SentryEvent?>? _beforeSend;

		private Func<SentryTransaction, SentryHint, SentryTransaction?>? _beforeSendTransaction;

		private Func<Breadcrumb, SentryHint, Breadcrumb?>? _beforeBreadcrumb;

		private int _maxQueueItems = 30;

		private int _maxCacheItems = 30;

		private volatile bool _debug;

		private volatile IDiagnosticLogger? _diagnosticLogger;

		private Lazy<IList<SubstringOrRegexPattern>> _failedRequestTargets = new Lazy<IList<SubstringOrRegexPattern>>(() => new AutoClearingList<SubstringOrRegexPattern>(new SubstringOrRegexPattern[1]
		{
			new SubstringOrRegexPattern(".*")
		}, clearOnNextAdd: true));

		private IFileSystem? _fileSystem;

		private double? _tracesSampleRate;

		private double? _profilesSampleRate;

		private IList<SubstringOrRegexPattern> _tracePropagationTargets = new AutoClearingList<SubstringOrRegexPattern>(new SubstringOrRegexPattern[1]
		{
			new SubstringOrRegexPattern(".*")
		}, clearOnNextAdd: true);

		private StackTraceMode? _stackTraceMode;

		private readonly List<ISdkIntegration> _integrations = new List<ISdkIntegration>();

		internal IScopeStackContainer? ScopeStackContainer { get; set; }

		internal string? InstallationId => _lazyInstallationId.Value;

		public bool IsGlobalModeEnabled
		{
			get
			{
				bool valueOrDefault = _isGlobalModeEnabled == true;
				if (!_isGlobalModeEnabled.HasValue)
				{
					valueOrDefault = SentryRuntime.Current.IsBrowserWasm();
					_isGlobalModeEnabled = valueOrDefault;
					return valueOrDefault;
				}
				return valueOrDefault;
			}
			set
			{
				_isGlobalModeEnabled = value;
			}
		}

		public IScopeObserver? ScopeObserver { get; set; }

		public bool EnableScopeSync { get; set; }

		public ITransport? Transport { get; set; }

		internal IClientReportRecorder ClientReportRecorder
		{
			get
			{
				return _clientReportRecorder.Value;
			}
			set
			{
				_clientReportRecorder = new Lazy<IClientReportRecorder>(() => value);
			}
		}

		internal ISentryStackTraceFactory SentryStackTraceFactory
		{
			get
			{
				return _sentryStackTraceFactory.Value;
			}
			set
			{
				_sentryStackTraceFactory = new Lazy<ISentryStackTraceFactory>(() => value);
			}
		}

		internal int SentryVersion { get; } = 7;

		internal List<(Type Type, Lazy<ISentryEventExceptionProcessor> Lazy)> ExceptionProcessors { get; set; }

		internal List<ISentryTransactionProcessor>? TransactionProcessors { get; set; }

		internal List<(Type Type, Lazy<ISentryEventProcessor> Lazy)> EventProcessors { get; set; }

		internal List<Func<IEnumerable<ISentryEventProcessor>>> EventProcessorsProviders { get; set; }

		internal List<Func<IEnumerable<ISentryTransactionProcessor>>> TransactionProcessorsProviders { get; set; }

		internal List<Func<IEnumerable<ISentryEventExceptionProcessor>>> ExceptionProcessorsProviders { get; set; }

		internal IEnumerable<ISdkIntegration> Integrations
		{
			get
			{
				if ((_defaultIntegrations & DefaultIntegrations.AutoSessionTrackingIntegration) != 0)
				{
					yield return new AutoSessionTrackingIntegration();
				}
				if ((_defaultIntegrations & DefaultIntegrations.AppDomainUnhandledExceptionIntegration) != 0)
				{
					yield return new AppDomainUnhandledExceptionIntegration();
				}
				if ((_defaultIntegrations & DefaultIntegrations.AppDomainProcessExitIntegration) != 0)
				{
					yield return new AppDomainProcessExitIntegration();
				}
				if ((_defaultIntegrations & DefaultIntegrations.UnobservedTaskExceptionIntegration) != 0)
				{
					yield return new UnobservedTaskExceptionIntegration();
				}
				foreach (ISdkIntegration integration in _integrations)
				{
					yield return integration;
				}
			}
		}

		internal List<IExceptionFilter>? ExceptionFilters { get; set; } = new List<IExceptionFilter>();

		public ICollection<SubstringOrRegexPattern> TagFilters { get; set; } = new List<SubstringOrRegexPattern>();

		public IBackgroundWorker? BackgroundWorker { get; set; }

		internal ISentryHttpClientFactory? SentryHttpClientFactory { get; set; }

		public ISentryScopeStateProcessor SentryScopeStateProcessor { get; set; } = new DefaultSentryScopeStateProcessor();

		internal List<StringOrRegex>? InAppExclude { get; set; }

		internal List<StringOrRegex>? InAppInclude { get; set; }

		public bool SendDefaultPii { get; set; }

		public bool IsEnvironmentUser { get; set; } = true;

		public string? ServerName { get; set; }

		public bool AttachStacktrace { get; set; } = true;

		public int MaxBreadcrumbs { get; set; } = 100;

		public float? SampleRate
		{
			get
			{
				return _sampleRate;
			}
			set
			{
				bool flag;
				if (value.HasValue)
				{
					float valueOrDefault = value.GetValueOrDefault();
					if (valueOrDefault > 1f || valueOrDefault <= 0f)
					{
						flag = true;
						goto IL_0027;
					}
				}
				flag = false;
				goto IL_0027;
				IL_0027:
				if (flag)
				{
					throw new InvalidOperationException($"The value {value} is not valid. Use null to disable or values between 0.01 (inclusive) and 1.0 (exclusive) ");
				}
				_sampleRate = value;
			}
		}

		public string? Release { get; set; }

		public string? Distribution { get; set; }

		public string? Environment { get; set; }

		public string? Dsn
		{
			get
			{
				return _dsn;
			}
			set
			{
				_dsn = value;
				_parsedDsn = null;
			}
		}

		internal Dsn ParsedDsn => _parsedDsn ?? (_parsedDsn = Sentry.Dsn.Parse(Dsn));

		internal Func<SentryEvent, SentryHint, SentryEvent?>? BeforeSendInternal => _beforeSend;

		internal Func<SentryTransaction, SentryHint, SentryTransaction?>? BeforeSendTransactionInternal => _beforeSendTransaction;

		internal Func<Breadcrumb, SentryHint, Breadcrumb?>? BeforeBreadcrumbInternal => _beforeBreadcrumb;

		public int MaxQueueItems
		{
			get
			{
				return _maxQueueItems;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("value", value, "At least 1 item must be allowed in the queue.");
				}
				_maxQueueItems = value;
			}
		}

		public int MaxCacheItems
		{
			get
			{
				return _maxCacheItems;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("value", value, "At least 1 item must be allowed in the cache.");
				}
				_maxCacheItems = value;
			}
		}

		public TimeSpan ShutdownTimeout { get; set; } = TimeSpan.FromSeconds(2.0);

		public TimeSpan FlushTimeout { get; set; } = TimeSpan.FromSeconds(2.0);

		public DecompressionMethods DecompressionMethods { get; set; } = (DecompressionMethods)(-1);

		public CompressionLevel RequestBodyCompressionLevel { get; set; }

		public bool RequestBodyCompressionBuffered { get; set; } = true;

		public bool SendClientReports { get; set; } = true;

		public IWebProxy? HttpProxy { get; set; }

		public Func<HttpMessageHandler>? CreateHttpMessageHandler { get; set; }

		public Action<HttpClient>? ConfigureClient { get; set; }

		public bool Debug
		{
			get
			{
				return _debug;
			}
			set
			{
				_debug = value;
			}
		}

		public SentryLevel DiagnosticLevel { get; set; }

		public IDiagnosticLogger? DiagnosticLogger
		{
			get
			{
				if (!Debug)
				{
					return null;
				}
				return _diagnosticLogger;
			}
			set
			{
				if (value == null)
				{
					_diagnosticLogger?.LogDebug("Sentry will not emit SDK debug messages because debug mode has been turned off.");
				}
				else
				{
					_diagnosticLogger?.LogInfo("Replacing current logger with: '{0}'.", value.GetType().Name);
				}
				_diagnosticLogger = value;
			}
		}

		public ReportAssembliesMode ReportAssembliesMode { get; set; } = ReportAssembliesMode.Version;

		public DeduplicateMode DeduplicateMode { get; set; } = (DeduplicateMode)2147483643;

		public string? CacheDirectoryPath { get; set; }

		public bool CaptureFailedRequests { get; set; } = true;

		public IList<HttpStatusCodeRange> FailedRequestStatusCodes { get; set; } = new List<HttpStatusCodeRange> { (Start: 500, End: 599) };

		public IList<SubstringOrRegexPattern> FailedRequestTargets
		{
			get
			{
				return _failedRequestTargets.Value;
			}
			set
			{
				_failedRequestTargets = new Lazy<IList<SubstringOrRegexPattern>>(value.WithConfigBinding);
			}
		}

		internal IFileSystem FileSystem
		{
			get
			{
				IFileSystem fileSystem = _fileSystem;
				if (fileSystem == null)
				{
					IFileSystem fileSystem3;
					IFileSystem fileSystem2;
					if (!DisableFileWrite)
					{
						fileSystem2 = new ReadWriteFileSystem();
						fileSystem3 = fileSystem2;
					}
					else
					{
						fileSystem2 = new ReadOnlyFileSystem();
						fileSystem3 = fileSystem2;
					}
					fileSystem2 = fileSystem3;
					_fileSystem = fileSystem3;
					fileSystem = fileSystem2;
				}
				return fileSystem;
			}
			set
			{
				_fileSystem = value;
			}
		}

		public bool DisableFileWrite { get; set; }

		public TimeSpan InitCacheFlushTimeout { get; set; } = TimeSpan.FromSeconds(1.0);

		public Dictionary<string, string> DefaultTags
		{
			get
			{
				return _defaultTags ?? (_defaultTags = new Dictionary<string, string>());
			}
			internal set
			{
				_defaultTags = value;
			}
		}

		internal bool IsPerformanceMonitoringEnabled
		{
			get
			{
				bool? enableTracing = EnableTracing;
				if (enableTracing.HasValue)
				{
					if (enableTracing != true)
					{
						return false;
					}
					bool flag = TracesSampler != null;
					if (!flag)
					{
						double? tracesSampleRate = TracesSampleRate;
						bool flag2 = ((!tracesSampleRate.HasValue || tracesSampleRate.GetValueOrDefault() > 0.0) ? true : false);
						flag = flag2;
					}
					return flag;
				}
				int result;
				if (TracesSampler == null)
				{
					double? tracesSampleRate = TracesSampleRate;
					result = ((tracesSampleRate.HasValue && tracesSampleRate.GetValueOrDefault() > 0.0) ? 1 : 0);
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool IsProfilingEnabled
		{
			get
			{
				if (IsPerformanceMonitoringEnabled)
				{
					return ProfilesSampleRate > 0.0;
				}
				return false;
			}
		}

		[Obsolete("Use TracesSampleRate or TracesSampler instead")]
		public bool? EnableTracing { get; set; }

		public double? TracesSampleRate
		{
			get
			{
				return _tracesSampleRate;
			}
			set
			{
				bool flag;
				if (value.HasValue)
				{
					double valueOrDefault = value.GetValueOrDefault();
					if (valueOrDefault < 0.0 || valueOrDefault > 1.0)
					{
						flag = true;
						goto IL_002f;
					}
				}
				flag = false;
				goto IL_002f;
				IL_002f:
				if (flag)
				{
					throw new ArgumentOutOfRangeException("value", value, "The traces sample rate must be between 0.0 and 1.0, inclusive.");
				}
				_tracesSampleRate = value;
			}
		}

		public double? ProfilesSampleRate
		{
			get
			{
				return _profilesSampleRate;
			}
			set
			{
				bool flag;
				if (value.HasValue)
				{
					double valueOrDefault = value.GetValueOrDefault();
					if (valueOrDefault < 0.0 || valueOrDefault > 1.0)
					{
						flag = true;
						goto IL_002f;
					}
				}
				flag = false;
				goto IL_002f;
				IL_002f:
				if (flag)
				{
					throw new ArgumentOutOfRangeException("value", value, "The profiles sample rate must be between 0.0 and 1.0, inclusive.");
				}
				_profilesSampleRate = value;
			}
		}

		public Func<TransactionSamplingContext, double?>? TracesSampler { get; set; }

		public IList<SubstringOrRegexPattern> TracePropagationTargets
		{
			get
			{
				return _tracePropagationTargets;
			}
			set
			{
				_tracePropagationTargets = value.WithConfigBinding();
			}
		}

		internal ITransactionProfilerFactory? TransactionProfilerFactory { get; set; }

		public StackTraceMode StackTraceMode
		{
			get
			{
				StackTraceMode? stackTraceMode = _stackTraceMode;
				if (stackTraceMode.HasValue)
				{
					return _stackTraceMode.Value;
				}
				try
				{
					_stackTraceMode = ((!(SentryRuntime.Current.Name == ".NET Native")) ? StackTraceMode.Enhanced : StackTraceMode.Original);
				}
				catch (Exception exception)
				{
					_stackTraceMode = StackTraceMode.Enhanced;
					DiagnosticLogger?.LogError(exception, "Failed to get runtime, setting {0} to {1} ", "StackTraceMode", _stackTraceMode);
				}
				return _stackTraceMode.Value;
			}
			set
			{
				_stackTraceMode = value;
			}
		}

		public long MaxAttachmentSize { get; set; } = 20971520L;

		public StartupTimeDetectionMode DetectStartupTime { get; set; } = SentryRuntime.Current.IsBrowserWasm() ? StartupTimeDetectionMode.Fast : StartupTimeDetectionMode.Best;

		public TimeSpan AutoSessionTrackingInterval { get; set; } = TimeSpan.FromSeconds(30.0);

		public bool AutoSessionTracking { get; set; }

		public bool UseAsyncFileIO { get; set; } = true;

		public Func<bool>? CrashedLastRun { get; set; }

		internal Instrumenter Instrumenter { get; set; }

		public bool JsonPreserveReferences
		{
			get
			{
				return JsonExtensions.JsonPreserveReferences;
			}
			set
			{
				JsonExtensions.JsonPreserveReferences = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public INetworkStatusListener? NetworkStatusListener { get; set; }

		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, PEReader?>? AssemblyReader { get; set; }

		public ExperimentalMetricsOptions? ExperimentalMetrics { get; set; }

		public string SpotlightUrl { get; set; } = "http://localhost:8969/stream";

		public bool EnableSpotlight { get; set; }

		internal SettingLocator SettingLocator { get; set; }

		internal bool InitNativeSdks { get; set; } = true;

		internal List<Action<IHub>> PostInitCallbacks { get; set; } = new List<Action<IHub>>();

		internal HttpClient GetHttpClient()
		{
			return (SentryHttpClientFactory ?? new DefaultSentryHttpClientFactory()).Create(this);
		}

		internal bool IsSentryRequest(string? requestUri)
		{
			if (!string.IsNullOrEmpty(requestUri))
			{
				return IsSentryRequest(new Uri(requestUri));
			}
			return false;
		}

		internal bool IsSentryRequest(Uri? requestUri)
		{
			if (string.IsNullOrEmpty(Dsn) || (object)requestUri == null)
			{
				return false;
			}
			return string.Equals(requestUri.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped), _sentryBaseUrl.Value, StringComparison.OrdinalIgnoreCase);
		}

		public void SetBeforeSend(Func<SentryEvent, SentryHint, SentryEvent?> beforeSend)
		{
			_beforeSend = beforeSend;
		}

		public void SetBeforeSend(Func<SentryEvent, SentryEvent?> beforeSend)
		{
			_beforeSend = (SentryEvent @event, SentryHint _) => beforeSend(@event);
		}

		public void SetBeforeSendTransaction(Func<SentryTransaction, SentryHint, SentryTransaction?> beforeSendTransaction)
		{
			_beforeSendTransaction = beforeSendTransaction;
		}

		public void SetBeforeSendTransaction(Func<SentryTransaction, SentryTransaction?> beforeSendTransaction)
		{
			_beforeSendTransaction = (SentryTransaction transaction, SentryHint _) => beforeSendTransaction(transaction);
		}

		public void SetBeforeBreadcrumb(Func<Breadcrumb, SentryHint, Breadcrumb?> beforeBreadcrumb)
		{
			_beforeBreadcrumb = beforeBreadcrumb;
		}

		public void SetBeforeBreadcrumb(Func<Breadcrumb, Breadcrumb?> beforeBreadcrumb)
		{
			_beforeBreadcrumb = (Breadcrumb breadcrumb, SentryHint _) => beforeBreadcrumb(breadcrumb);
		}

		public void AddJsonConverter(JsonConverter converter)
		{
			if (converter == null)
			{
				throw new ArgumentNullException("converter");
			}
			JsonExtensions.AddJsonConverter(converter);
		}

		public void AddJsonSerializerContext<T>(Func<JsonSerializerOptions, T> contextBuilder) where T : JsonSerializerContext
		{
			if (contextBuilder == null)
			{
				throw new ArgumentNullException("contextBuilder");
			}
			JsonExtensions.AddJsonSerializerContext(contextBuilder);
		}

		public SentryOptions()
		{
			SettingLocator = new SettingLocator(this);
			_lazyInstallationId = new Lazy<string>(() => new InstallationIdHelper(this).TryGetInstallationId());
			TransactionProcessorsProviders = new List<Func<IEnumerable<ISentryTransactionProcessor>>>
			{
				delegate
				{
					IEnumerable<ISentryTransactionProcessor> transactionProcessors = TransactionProcessors;
					return transactionProcessors ?? Enumerable.Empty<ISentryTransactionProcessor>();
				}
			};
			_clientReportRecorder = new Lazy<IClientReportRecorder>(() => new ClientReportRecorder(this));
			_sentryStackTraceFactory = new Lazy<ISentryStackTraceFactory>(() => new SentryStackTraceFactory(this));
			EventProcessors = new List<(Type, Lazy<ISentryEventProcessor>)>
			{
				(typeof(DuplicateEventDetectionEventProcessor), new Lazy<ISentryEventProcessor>(() => new DuplicateEventDetectionEventProcessor(this))),
				(typeof(MainSentryEventProcessor), new Lazy<ISentryEventProcessor>(() => new MainSentryEventProcessor(this, SentryStackTraceFactoryAccessor)))
			};
			EventProcessorsProviders = new List<Func<IEnumerable<ISentryEventProcessor>>>
			{
				() => EventProcessors.Select<(Type, Lazy<ISentryEventProcessor>), ISentryEventProcessor>(((Type Type, Lazy<ISentryEventProcessor> Lazy) x) => x.Lazy.Value)
			};
			ExceptionProcessors = new List<(Type, Lazy<ISentryEventExceptionProcessor>)> { (typeof(MainExceptionProcessor), new Lazy<ISentryEventExceptionProcessor>(() => new MainExceptionProcessor(this, SentryStackTraceFactoryAccessor))) };
			ExceptionProcessorsProviders = new List<Func<IEnumerable<ISentryEventExceptionProcessor>>>
			{
				() => ExceptionProcessors.Select<(Type, Lazy<ISentryEventExceptionProcessor>), ISentryEventExceptionProcessor>(((Type Type, Lazy<ISentryEventExceptionProcessor> Lazy) x) => x.Lazy.Value)
			};
			_integrations = new List<ISdkIntegration>();
			_defaultIntegrations = DefaultIntegrations.AutoSessionTrackingIntegration | DefaultIntegrations.AppDomainUnhandledExceptionIntegration | DefaultIntegrations.AppDomainProcessExitIntegration | DefaultIntegrations.UnobservedTaskExceptionIntegration;
			InAppExclude = new List<StringOrRegex>
			{
				"System", "Mono", "Sentry", "Microsoft", "MS", "ABI.Microsoft", "WinRT", "UIKit", "Newtonsoft.Json", "FSharp",
				"Serilog", "Giraffe", "NLog", "Npgsql", "RabbitMQ", "Hangfire", "IdentityServer4", "AWSSDK", "Polly", "Swashbuckle",
				"FluentValidation", "Autofac", "Stackexchange.Redis", "Dapper", "RestSharp", "SkiaSharp", "IdentityModel", "SqlitePclRaw", "Xamarin", "Android",
				"Google", "MongoDB", "Remotion.Linq", "AutoMapper", "Nest", "Owin", "MediatR", "ICSharpCode", "Grpc", "ServiceStack"
			};
			_sentryBaseUrl = new Lazy<string>(() => new Uri(Dsn ?? string.Empty).GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped));
			NetworkStatusListener = new PollingNetworkStatusListener(this);
			ISentryStackTraceFactory SentryStackTraceFactoryAccessor()
			{
				return SentryStackTraceFactory;
			}
		}

		public void AddIntegration(ISdkIntegration integration)
		{
			_integrations.Add(integration);
		}

		public void RemoveIntegration<TIntegration>() where TIntegration : ISdkIntegration
		{
			_integrations.RemoveAll((ISdkIntegration integration) => integration is TIntegration);
		}

		public void AddExceptionFilter(IExceptionFilter exceptionFilter)
		{
			if (ExceptionFilters == null)
			{
				ExceptionFilters = new List<IExceptionFilter> { exceptionFilter };
			}
			else
			{
				ExceptionFilters.Add(exceptionFilter);
			}
		}

		public void RemoveExceptionFilter<TFilter>() where TFilter : IExceptionFilter
		{
			ExceptionFilters?.RemoveAll((IExceptionFilter filter) => filter is TFilter);
		}

		public void AddExceptionFilterForType<TException>() where TException : Exception
		{
			AddExceptionFilter(new ExceptionTypeFilter<TException>());
		}

		public void AddInAppExclude(string prefix)
		{
			if (InAppExclude == null)
			{
				InAppExclude = new List<StringOrRegex>(1) { prefix };
			}
			else
			{
				InAppExclude.Add(prefix);
			}
		}

		public void AddInAppExclude(Regex regex)
		{
			if (InAppExclude == null)
			{
				InAppExclude = new List<StringOrRegex>(1) { regex };
			}
			else
			{
				InAppExclude.Add(regex);
			}
		}

		public void AddInAppExcludeRegex(string pattern)
		{
			AddInAppExclude(new Regex(pattern, RegexOptions.Compiled | RegexOptions.CultureInvariant));
		}

		public void AddInAppInclude(string prefix)
		{
			if (InAppInclude == null)
			{
				InAppInclude = new List<StringOrRegex>(1) { prefix };
			}
			else
			{
				InAppInclude.Add(prefix);
			}
		}

		public void AddInAppInclude(Regex regex)
		{
			if (InAppInclude == null)
			{
				InAppInclude = new List<StringOrRegex>(1) { regex };
			}
			else
			{
				InAppInclude.Add(regex);
			}
		}

		public void AddInAppIncludeRegex(string pattern)
		{
			AddInAppInclude(new Regex(pattern, RegexOptions.Compiled | RegexOptions.CultureInvariant));
		}

		public void AddExceptionProcessor(ISentryEventExceptionProcessor processor)
		{
			ExceptionProcessors.Add((processor.GetType(), new Lazy<ISentryEventExceptionProcessor>(() => processor)));
		}

		public void AddExceptionProcessors(IEnumerable<ISentryEventExceptionProcessor> processors)
		{
			foreach (ISentryEventExceptionProcessor processor in processors)
			{
				AddExceptionProcessor(processor);
			}
		}

		public void AddEventProcessor(ISentryEventProcessor processor)
		{
			EventProcessors.Add((processor.GetType(), new Lazy<ISentryEventProcessor>(() => processor)));
		}

		public void AddEventProcessors(IEnumerable<ISentryEventProcessor> processors)
		{
			foreach (ISentryEventProcessor processor in processors)
			{
				AddEventProcessor(processor);
			}
		}

		public void RemoveEventProcessor<TProcessor>() where TProcessor : ISentryEventProcessor
		{
			EventProcessors.RemoveAll(((Type Type, Lazy<ISentryEventProcessor> Lazy) processor) => processor.Type == typeof(TProcessor));
		}

		public void AddEventProcessorProvider(Func<IEnumerable<ISentryEventProcessor>> processorProvider)
		{
			EventProcessorsProviders.Add(processorProvider);
		}

		public void AddTransactionProcessor(ISentryTransactionProcessor processor)
		{
			if (TransactionProcessors == null)
			{
				TransactionProcessors = new List<ISentryTransactionProcessor> { processor };
			}
			else
			{
				TransactionProcessors.Add(processor);
			}
		}

		public void AddTransactionProcessors(IEnumerable<ISentryTransactionProcessor> processors)
		{
			if (TransactionProcessors == null)
			{
				TransactionProcessors = processors.ToList();
			}
			else
			{
				TransactionProcessors.AddRange(processors);
			}
		}

		public void RemoveTransactionProcessor<TProcessor>() where TProcessor : ISentryTransactionProcessor
		{
			TransactionProcessors?.RemoveAll((ISentryTransactionProcessor processor) => processor is TProcessor);
		}

		public void AddTransactionProcessorProvider(Func<IEnumerable<ISentryTransactionProcessor>> processorProvider)
		{
			TransactionProcessorsProviders = TransactionProcessorsProviders.Concat<Func<IEnumerable<ISentryTransactionProcessor>>>(new Func<IEnumerable<ISentryTransactionProcessor>>[1] { processorProvider }).ToList();
		}

		public void AddExceptionProcessorProvider(Func<IEnumerable<ISentryEventExceptionProcessor>> processorProvider)
		{
			ExceptionProcessorsProviders.Add(processorProvider);
		}

		public IEnumerable<ISentryEventProcessor> GetAllEventProcessors()
		{
			return EventProcessorsProviders.SelectMany((Func<IEnumerable<ISentryEventProcessor>> p) => p());
		}

		public IEnumerable<ISentryTransactionProcessor> GetAllTransactionProcessors()
		{
			return TransactionProcessorsProviders.SelectMany((Func<IEnumerable<ISentryTransactionProcessor>> p) => p());
		}

		public IEnumerable<ISentryEventExceptionProcessor> GetAllExceptionProcessors()
		{
			return ExceptionProcessorsProviders.SelectMany((Func<IEnumerable<ISentryEventExceptionProcessor>> p) => p());
		}

		public SentryOptions UseStackTraceFactory(ISentryStackTraceFactory sentryStackTraceFactory)
		{
			SentryStackTraceFactory = sentryStackTraceFactory ?? throw new ArgumentNullException("sentryStackTraceFactory");
			return this;
		}

		public void ApplyDefaultTags(IHasTags hasTags)
		{
			foreach (KeyValuePair<string, string> item in DefaultTags.Where<KeyValuePair<string, string>>((KeyValuePair<string, string> t) => !hasTags.Tags.TryGetValue(t.Key, out string _)))
			{
				hasTags.SetTag(item.Key, item.Value);
			}
		}

		public void DisableDuplicateEventDetection()
		{
			RemoveEventProcessor<DuplicateEventDetectionEventProcessor>();
		}

		public void DisableAppDomainUnhandledExceptionCapture()
		{
			RemoveDefaultIntegration(DefaultIntegrations.AppDomainUnhandledExceptionIntegration);
		}

		public void DisableUnobservedTaskExceptionCapture()
		{
			RemoveDefaultIntegration(DefaultIntegrations.UnobservedTaskExceptionIntegration);
		}

		public void DisableAppDomainProcessExitFlush()
		{
			RemoveDefaultIntegration(DefaultIntegrations.AppDomainProcessExitIntegration);
		}

		internal bool HasIntegration<TIntegration>()
		{
			return _integrations.Any((ISdkIntegration integration) => integration is TIntegration);
		}

		internal void RemoveDefaultIntegration(DefaultIntegrations defaultIntegrations)
		{
			_defaultIntegrations &= ~defaultIntegrations;
		}

		internal void SetupLogging()
		{
			if (Debug)
			{
				if (DiagnosticLogger == null)
				{
					DiagnosticLogger = new ConsoleDiagnosticLogger(DiagnosticLevel);
					DiagnosticLogger.LogDebug("Logging enabled with ConsoleDiagnosticLogger and min level: {0}", DiagnosticLevel);
				}
				if (SettingLocator.GetEnvironment().Equals("production", StringComparison.OrdinalIgnoreCase))
				{
					DiagnosticLogger.LogWarning("Sentry option 'Debug' is set to true while Environment is production. Be aware this can cause performance degradation and is not advised. See https://docs.sentry.io/platforms/dotnet/configuration/diagnostic-logger for more information");
				}
			}
			else
			{
				DiagnosticLogger = null;
			}
		}

		internal string? TryGetDsnSpecificCacheDirectoryPath()
		{
			if (string.IsNullOrWhiteSpace(CacheDirectoryPath))
			{
				return null;
			}
			if (string.IsNullOrWhiteSpace(Dsn))
			{
				return null;
			}
			return Path.Combine(CacheDirectoryPath, "Sentry", Dsn.GetHashString());
		}

		internal string? TryGetProcessSpecificCacheDirectoryPath()
		{
			return TryGetDsnSpecificCacheDirectoryPath();
		}
	}
}
