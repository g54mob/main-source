using System;
using System.Collections.Generic;
using System.Threading;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class RequestContext : IRequestContext
	{
		private IServiceMetadata _serviceMetadata;

		private IDictionary<string, object> _contextAttributes;

		private UserAgentDetails _userAgentDetails;

		public IRequest Request { get; set; }

		public RequestMetrics Metrics { get; private set; }

		public IClientConfig ClientConfig { get; set; }

		public int Retries { get; set; }

		public CapacityManager.CapacityType LastCapacityType { get; set; }

		public int EndpointDiscoveryRetries { get; set; }

		public bool IsSigned { get; set; }

		public bool IsAsync { get; set; }

		public AmazonWebServiceRequest OriginalRequest { get; set; }

		public IMarshaller<IRequest, AmazonWebServiceRequest> Marshaller { get; set; }

		public ResponseUnmarshaller Unmarshaller { get; set; }

		public InvokeOptionsBase Options { get; set; }

		public ISigner Signer { get; set; }

		public BaseIdentity Identity { get; set; }

		public UserAgentDetails UserAgentDetails
		{
			get
			{
				if (_userAgentDetails != null)
				{
					return _userAgentDetails;
				}
				_userAgentDetails = new UserAgentDetails();
				_userAgentDetails.AddUserAgentComponent(((IAmazonWebServiceRequest)OriginalRequest).UserAgentDetails.GetCustomUserAgentComponents());
				foreach (string trackedFeatureId in ((IAmazonWebServiceRequest)OriginalRequest).UserAgentDetails.TrackedFeatureIds)
				{
					_userAgentDetails.AddFeature(trackedFeatureId);
				}
				return _userAgentDetails;
			}
		}

		public CancellationToken CancellationToken { get; set; }

		public string RequestName => OriginalRequest.GetType().Name;

		public MonitoringAPICallAttempt CSMCallAttempt { get; set; }

		public MonitoringAPICallEvent CSMCallEvent { get; set; }

		public IServiceMetadata ServiceMetaData
		{
			get
			{
				return _serviceMetadata;
			}
			internal set
			{
				_serviceMetadata = value;
				CSMEnabled = DeterminedCSMConfiguration.Instance.CSMConfiguration.Enabled && !string.IsNullOrEmpty(_serviceMetadata.ServiceId);
			}
		}

		public bool CSMEnabled { get; private set; }

		public bool IsLastExceptionRetryable { get; set; }

		public Guid InvocationId { get; private set; }

		public IDictionary<string, object> ContextAttributes
		{
			get
			{
				if (_contextAttributes == null)
				{
					_contextAttributes = new Dictionary<string, object>();
				}
				return _contextAttributes;
			}
		}

		public IHttpRequestStreamHandle RequestStreamHandle { get; set; }

		public RequestContext(bool enableMetric)
			: this(enableMetric, null)
		{
		}

		public RequestContext(bool enableMetrics, ISigner clientSigner)
		{
			Signer = clientSigner;
			Metrics = new RequestMetrics();
			Metrics.IsEnabled = enableMetrics;
			InvocationId = Guid.NewGuid();
		}
	}
}
