using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Telemetry.Metrics;
using Amazon.Util;

namespace Amazon.Runtime
{
	public abstract class AmazonServiceClient : IDisposable
	{
		private static volatile bool _isProtocolUpdated;

		private readonly object _lock = new object();

		private IDisposable _uptimeMetricMeasurer;

		private bool _disposed;

		private Logger _logger;

		private readonly ClientConfig _config;

		private PreRequestEventHandler mBeforeMarshallingEvent;

		private RequestEventHandler mBeforeRequestEvent;

		private ResponseEventHandler mAfterResponseEvent;

		private ExceptionEventHandler mExceptionEvent;

		protected EndpointDiscoveryResolverBase EndpointDiscoveryResolver { get; private set; }

		protected RuntimePipeline RuntimePipeline { get; set; }

		public IClientConfig Config => _config;

		protected virtual IServiceMetadata ServiceMetadata { get; } = new ServiceMetadata();

		protected virtual bool SupportResponseLogging => true;

		internal event PreRequestEventHandler BeforeMarshallingEvent
		{
			add
			{
				lock (_lock)
				{
					mBeforeMarshallingEvent = (PreRequestEventHandler)Delegate.Combine(mBeforeMarshallingEvent, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					mBeforeMarshallingEvent = (PreRequestEventHandler)Delegate.Remove(mBeforeMarshallingEvent, value);
				}
			}
		}

		public event RequestEventHandler BeforeRequestEvent
		{
			add
			{
				lock (_lock)
				{
					mBeforeRequestEvent = (RequestEventHandler)Delegate.Combine(mBeforeRequestEvent, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					mBeforeRequestEvent = (RequestEventHandler)Delegate.Remove(mBeforeRequestEvent, value);
				}
			}
		}

		public event ResponseEventHandler AfterResponseEvent
		{
			add
			{
				lock (_lock)
				{
					mAfterResponseEvent = (ResponseEventHandler)Delegate.Combine(mAfterResponseEvent, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					mAfterResponseEvent = (ResponseEventHandler)Delegate.Remove(mAfterResponseEvent, value);
				}
			}
		}

		public event ExceptionEventHandler ExceptionEvent
		{
			add
			{
				lock (_lock)
				{
					mExceptionEvent = (ExceptionEventHandler)Delegate.Combine(mExceptionEvent, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					mExceptionEvent = (ExceptionEventHandler)Delegate.Remove(mExceptionEvent, value);
				}
			}
		}

		protected AmazonServiceClient(AWSCredentials credentials, ClientConfig config)
		{
			if (config.DisableLogging)
			{
				_logger = Logger.EmptyLogger;
			}
			else
			{
				_logger = Logger.GetLogger(GetType());
			}
			config.Validate();
			if (credentials != null)
			{
				config.DefaultAWSCredentials = credentials;
			}
			_config = config;
			EndpointDiscoveryResolver = new EndpointDiscoveryResolver(config, _logger);
			Initialize();
			UpdateSecurityProtocol();
			BuildRuntimePipeline();
			_uptimeMetricMeasurer = MetricsUtilities.MeasureDuration(config, "client.uptime");
		}

		protected AmazonServiceClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, ClientConfig config)
			: this(new SessionAWSCredentials(awsAccessKeyId, awsSecretAccessKey, awsSessionToken), config)
		{
		}

		protected AmazonServiceClient(string awsAccessKeyId, string awsSecretAccessKey, ClientConfig config)
			: this(new BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey), config)
		{
		}

		protected AmazonServiceClient(ClientConfig config)
			: this(null, config)
		{
		}

		protected virtual void Initialize()
		{
		}

		protected TResponse Invoke<TResponse>(AmazonWebServiceRequest request, InvokeOptionsBase options) where TResponse : AmazonWebServiceResponse
		{
			ThrowIfDisposed();
			Amazon.Runtime.Internal.ExecutionContext executionContext = new Amazon.Runtime.Internal.ExecutionContext(new RequestContext(Config.LogMetrics)
			{
				ClientConfig = Config,
				Marshaller = options.RequestMarshaller,
				OriginalRequest = request,
				Unmarshaller = options.ResponseUnmarshaller,
				IsAsync = false,
				ServiceMetaData = ServiceMetadata,
				Options = options
			}, new ResponseContext());
			SetupCSMHandler(executionContext.RequestContext);
			return (TResponse)RuntimePipeline.InvokeSync(executionContext).Response;
		}

		protected Task<TResponse> InvokeAsync<TResponse>(AmazonWebServiceRequest request, InvokeOptionsBase options, CancellationToken cancellationToken) where TResponse : AmazonWebServiceResponse, new()
		{
			ThrowIfDisposed();
			if (cancellationToken == default(CancellationToken))
			{
				cancellationToken = _config.BuildDefaultCancellationToken();
			}
			Amazon.Runtime.Internal.ExecutionContext executionContext = new Amazon.Runtime.Internal.ExecutionContext(new RequestContext(Config.LogMetrics)
			{
				ClientConfig = Config,
				Marshaller = options.RequestMarshaller,
				OriginalRequest = request,
				Unmarshaller = options.ResponseUnmarshaller,
				IsAsync = true,
				CancellationToken = cancellationToken,
				ServiceMetaData = ServiceMetadata,
				Options = options
			}, new ResponseContext());
			SetupCSMHandler(executionContext.RequestContext);
			return RuntimePipeline.InvokeAsync<TResponse>(executionContext);
		}

		protected virtual IEnumerable<DiscoveryEndpointBase> EndpointOperation(EndpointOperationContextBase context)
		{
			return null;
		}

		protected void ProcessPreRequestHandlers(IExecutionContext executionContext)
		{
			if (mBeforeMarshallingEvent != null)
			{
				PreRequestEventArgs e = PreRequestEventArgs.Create(executionContext.RequestContext.OriginalRequest);
				mBeforeMarshallingEvent(this, e);
			}
		}

		protected void ProcessRequestHandlers(IExecutionContext executionContext)
		{
			IRequest request = executionContext.RequestContext.Request;
			WebServiceRequestEventArgs e = WebServiceRequestEventArgs.Create(request);
			if (request.OriginalRequest != null)
			{
				request.OriginalRequest.FireBeforeRequestEvent(this, e);
			}
			if (mBeforeRequestEvent != null)
			{
				mBeforeRequestEvent(this, e);
			}
		}

		protected void ProcessResponseHandlers(IExecutionContext executionContext)
		{
			if (mAfterResponseEvent != null)
			{
				WebServiceResponseEventArgs e = WebServiceResponseEventArgs.Create(executionContext.ResponseContext.Response, executionContext.RequestContext.Request, executionContext.ResponseContext.HttpResponse);
				mAfterResponseEvent(this, e);
			}
		}

		protected virtual void ProcessExceptionHandlers(IExecutionContext executionContext, Exception exception)
		{
			if (mExceptionEvent != null)
			{
				WebServiceExceptionEventArgs e = WebServiceExceptionEventArgs.Create(exception, executionContext.RequestContext.Request);
				mExceptionEvent(this, e);
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				RuntimePipeline?.Dispose();
				RuntimePipeline = null;
				_uptimeMetricMeasurer?.Dispose();
				_uptimeMetricMeasurer = null;
				_disposed = true;
			}
		}

		private void ThrowIfDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
		}

		protected virtual void CustomizeRuntimePipeline(RuntimePipeline pipeline)
		{
		}

		private void BuildRuntimePipeline()
		{
			HttpHandler<HttpContent> item = new HttpHandler<HttpContent>(new HttpRequestMessageFactory(Config), this);
			CallbackHandler callbackHandler = new CallbackHandler();
			callbackHandler.OnPreInvoke = ProcessPreRequestHandlers;
			CallbackHandler callbackHandler2 = new CallbackHandler();
			callbackHandler2.OnPreInvoke = ProcessRequestHandlers;
			CallbackHandler callbackHandler3 = new CallbackHandler();
			callbackHandler3.OnPostInvoke = ProcessResponseHandlers;
			ErrorCallbackHandler errorCallbackHandler = new ErrorCallbackHandler();
			errorCallbackHandler.OnError = ProcessExceptionHandlers;
			RetryPolicy retryPolicy = Config.RetryMode switch
			{
				RequestRetryMode.Adaptive => new AdaptiveRetryPolicy(Config), 
				RequestRetryMode.Standard => new StandardRetryPolicy(Config), 
				_ => throw new InvalidOperationException("Unknown retry mode"), 
			};
			RuntimePipeline = new RuntimePipeline(new List<IPipelineHandler>
			{
				item,
				new Unmarshaller(SupportResponseLogging),
				new ErrorHandler(_logger),
				callbackHandler3,
				new Signer(),
				new EndpointDiscoveryHandler(),
				new ChecksumHandler(),
				new RetryHandler(retryPolicy),
				new CompressionHandler(),
				callbackHandler2,
				new EndpointResolver(),
				new Marshaller(),
				callbackHandler,
				errorCallbackHandler,
				new MetricsHandler()
			}, _logger);
			if (DeterminedCSMConfiguration.Instance.CSMConfiguration.Enabled && !string.IsNullOrEmpty(ServiceMetadata.ServiceId))
			{
				RuntimePipeline.AddHandlerBefore<ErrorHandler>(new CSMCallAttemptHandler());
				RuntimePipeline.AddHandlerBefore<MetricsHandler>(new CSMCallEventHandler());
			}
			CustomizeRuntimePipeline(RuntimePipeline);
			RuntimePipelineCustomizerRegistry.Instance.ApplyCustomizations(GetType(), RuntimePipeline);
		}

		private void UpdateSecurityProtocol()
		{
			if (_isProtocolUpdated)
			{
				return;
			}
			AmazonSecurityProtocolManager amazonSecurityProtocolManager = new AmazonSecurityProtocolManager();
			try
			{
				if (!amazonSecurityProtocolManager.IsSecurityProtocolSystemDefault())
				{
					amazonSecurityProtocolManager.UpdateProtocolsToSupported();
				}
			}
			catch (Exception ex)
			{
				if (ex is NotSupportedException)
				{
					_logger.InfoFormat(ex.Message);
				}
				else
				{
					_logger.InfoFormat("Unexpected error " + ex.GetType().Name + " encountered when trying to set Security Protocol.\n" + ex);
				}
			}
			_isProtocolUpdated = true;
		}

		public static Uri ComposeUrl(IRequest iRequest)
		{
			return ComposeUrl(iRequest, skipEncodingValidPathChars: true);
		}

		public static Uri ComposeUrl(IRequest internalRequest, bool skipEncodingValidPathChars)
		{
			Uri endpoint = internalRequest.Endpoint;
			string text = internalRequest.ResourcePath;
			if (text == null)
			{
				text = string.Empty;
			}
			else
			{
				if (text.StartsWith("/", StringComparison.Ordinal))
				{
					text = text.Substring(1);
				}
				text = AWSSDKUtils.ResolveResourcePathV2(text, internalRequest.PathResources);
			}
			string arg = "?";
			StringBuilder stringBuilder = new StringBuilder();
			IDictionary<string, string> subResources = internalRequest.SubResources;
			if (subResources != null && subResources.Count > 0)
			{
				foreach (KeyValuePair<string, string> subResource in internalRequest.SubResources)
				{
					stringBuilder.AppendFormat("{0}{1}", arg, subResource.Key);
					if (subResource.Value != null)
					{
						stringBuilder.AppendFormat("={0}", subResource.Value);
					}
					arg = "&";
				}
			}
			if (internalRequest.UseQueryString)
			{
				IDictionary<string, string> parameters = internalRequest.Parameters;
				if (parameters != null && parameters.Count > 0)
				{
					string parametersAsString = AWSSDKUtils.GetParametersAsString(internalRequest);
					stringBuilder.AppendFormat("{0}{1}", arg, parametersAsString);
				}
			}
			string text2 = text + stringBuilder;
			Uri uri = new Uri((endpoint.AbsoluteUri.EndsWith("/", StringComparison.Ordinal) || text2.StartsWith("/", StringComparison.Ordinal)) ? (endpoint.AbsoluteUri + text2) : (endpoint.AbsoluteUri + "/" + text2));
			DontUnescapePathDotsAndSlashes(uri);
			return uri;
		}

		private static void DontUnescapePathDotsAndSlashes(Uri uri)
		{
		}

		internal C CloneConfig<C>() where C : ClientConfig, new()
		{
			C val = new C();
			CloneConfig(val);
			return val;
		}

		internal void CloneConfig(ClientConfig newConfig)
		{
			if (!string.IsNullOrEmpty(Config.ServiceURL))
			{
				RegionEndpoint bySystemName = RegionEndpoint.GetBySystemName(AWSSDKUtils.DetermineRegion(Config.ServiceURL));
				newConfig.RegionEndpoint = bySystemName;
			}
			else
			{
				newConfig.RegionEndpoint = Config.RegionEndpoint;
			}
			newConfig.UseHttp = Config.UseHttp;
			newConfig.ProxyCredentials = Config.ProxyCredentials;
			newConfig.ProxyHost = Config.ProxyHost;
			newConfig.ProxyPort = Config.ProxyPort;
		}

		private static void SetupCSMHandler(IRequestContext requestContext)
		{
			if (requestContext.CSMEnabled)
			{
				requestContext.CSMCallEvent = new MonitoringAPICallEvent(requestContext);
			}
		}
	}
}
