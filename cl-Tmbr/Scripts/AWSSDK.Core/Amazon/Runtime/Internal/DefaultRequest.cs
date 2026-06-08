using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.EventStreams;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.Internal
{
	public class DefaultRequest : IRequest
	{
		private readonly ParameterCollection parametersCollection;

		private readonly IDictionary<string, string> parametersFacade;

		private readonly IDictionary<string, string> headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		private readonly IDictionary<string, string> trailingHeaders = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		private readonly IDictionary<string, string> subResources = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		private readonly IDictionary<string, string> pathResources = new Dictionary<string, string>(StringComparer.Ordinal);

		private Uri endpoint;

		private string resourcePath;

		private string serviceName;

		private readonly AmazonWebServiceRequest originalRequest;

		private byte[] content;

		private Stream contentStream;

		private string contentStreamHash;

		private string httpMethod = "POST";

		private bool useQueryString;

		private string requestName;

		private string canonicalResource;

		private RegionEndpoint alternateRegion;

		private long originalStreamLength;

		private DateTime? signedAt;

		public IEventStreamPublisher EventStreamPublisher { get; set; }

		public IHttpRequestStreamPublisher HttpRequestStreamPublisher { get; set; }

		public DateTime? SignedAt
		{
			get
			{
				return signedAt;
			}
			set
			{
				signedAt = value;
			}
		}

		public string RequestName => requestName;

		public string HttpMethod
		{
			get
			{
				return httpMethod;
			}
			set
			{
				httpMethod = value;
			}
		}

		public bool UseQueryString
		{
			get
			{
				if (HttpMethod == "GET")
				{
					return true;
				}
				return useQueryString;
			}
			set
			{
				useQueryString = value;
			}
		}

		public AmazonWebServiceRequest OriginalRequest => originalRequest;

		public IDictionary<string, string> Headers => headers;

		public IDictionary<string, string> Parameters => parametersFacade;

		public ParameterCollection ParameterCollection => parametersCollection;

		public IDictionary<string, string> SubResources => subResources;

		public Uri Endpoint
		{
			get
			{
				return endpoint;
			}
			set
			{
				endpoint = value;
			}
		}

		public string ResourcePath
		{
			get
			{
				return resourcePath;
			}
			set
			{
				resourcePath = value;
			}
		}

		public IDictionary<string, string> PathResources => pathResources;

		public string CanonicalResource
		{
			get
			{
				return canonicalResource;
			}
			set
			{
				canonicalResource = value;
			}
		}

		public byte[] Content
		{
			get
			{
				return content;
			}
			set
			{
				content = value;
			}
		}

		public bool SetContentFromParameters { get; set; }

		public Stream ContentStream
		{
			get
			{
				return contentStream;
			}
			set
			{
				contentStream = value;
				OriginalStreamPosition = -1L;
				if (contentStream != null)
				{
					Stream nonWrapperBaseStream = WrapperStream.GetNonWrapperBaseStream(contentStream);
					if (nonWrapperBaseStream.CanSeek)
					{
						OriginalStreamPosition = nonWrapperBaseStream.Position;
					}
				}
			}
		}

		public long OriginalStreamPosition
		{
			get
			{
				return originalStreamLength;
			}
			set
			{
				originalStreamLength = value;
			}
		}

		public string ServiceName => serviceName;

		public RegionEndpoint AlternateEndpoint
		{
			get
			{
				return alternateRegion;
			}
			set
			{
				alternateRegion = value;
			}
		}

		public string HostPrefix { get; set; }

		public bool Suppress404Exceptions { get; set; }

		public AWS4SigningResult AWS4SignerResult { get; set; }

		public bool? DisablePayloadSigning { get; set; }

		public AWS4aSigningResult AWS4aSignerResult { get; set; }

		public bool UseChunkEncoding { get; set; }

		public bool UseDoubleEncoding { get; set; } = true;

		public string CanonicalResourcePrefix { get; set; }

		public SignatureVersion SignatureVersion { get; set; }

		public string AuthenticationRegion { get; set; }

		public string DeterminedSigningRegion { get; set; }

		public string OverrideSigningServiceName { get; set; }

		public CoreChecksumAlgorithm SelectedChecksum { get; set; }

		public IDictionary<string, string> TrailingHeaders => trailingHeaders;

		public CompressionEncodingAlgorithm CompressionAlgorithm { get; set; }

		public ChecksumData ChecksumData { get; set; }

		public IPropertyBag EndpointAttributes { get; set; }

		public Version HttpProtocolVersion { get; set; } = HttpVersion.Version11;

		public DefaultRequest(AmazonWebServiceRequest request, string serviceName)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			if (string.IsNullOrEmpty(serviceName))
			{
				throw new ArgumentNullException("serviceName");
			}
			this.serviceName = serviceName;
			originalRequest = request;
			requestName = originalRequest.GetType().Name;
			SignatureVersion = ((IAmazonWebServiceRequest)originalRequest).SignatureVersion;
			HostPrefix = string.Empty;
			parametersCollection = new ParameterCollection();
			parametersFacade = new ParametersDictionaryFacade(parametersCollection);
		}

		public void AddSubResource(string subResource)
		{
			AddSubResource(subResource, null);
		}

		public void AddSubResource(string subResource, string value)
		{
			SubResources.Add(subResource, value);
		}

		public void AddPathResource(string key, string value)
		{
			PathResources.Add(key, value);
		}

		public string ComputeContentStreamHash()
		{
			if (contentStream == null)
			{
				return null;
			}
			if (contentStreamHash == null)
			{
				Stream stream = WrapperStream.SearchWrappedStream(contentStream, (Stream s) => s.CanSeek);
				if (stream != null)
				{
					long position = stream.Position;
					byte[] data = CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(stream);
					contentStreamHash = AWSSDKUtils.ToHex(data, lowercase: true);
					stream.Seek(position, SeekOrigin.Begin);
				}
			}
			return contentStreamHash;
		}

		public bool IsRequestStreamRewindable()
		{
			Stream stream = ContentStream;
			if (stream != null)
			{
				stream = WrapperStream.GetNonWrapperBaseStream(stream);
				return stream.CanSeek;
			}
			return true;
		}

		public bool MayContainRequestBody()
		{
			if (!(HttpMethod == "POST") && !(HttpMethod == "PUT"))
			{
				return HttpMethod == "PATCH";
			}
			return true;
		}

		public bool HasRequestBody()
		{
			bool num = HttpMethod == "POST" || HttpMethod == "PUT" || HttpMethod == "PATCH";
			bool flag = this.HasRequestData();
			return num && flag;
		}

		public string GetHeaderValue(string headerName)
		{
			if (headers.TryGetValue(headerName, out var value))
			{
				return value;
			}
			return string.Empty;
		}
	}
}
