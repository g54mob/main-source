using System;
using System.Collections.Generic;
using System.IO;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.EventStreams;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public interface IRequest
	{
		IEventStreamPublisher EventStreamPublisher { get; set; }

		IHttpRequestStreamPublisher HttpRequestStreamPublisher { get; set; }

		string RequestName { get; }

		IDictionary<string, string> Headers { get; }

		bool UseQueryString { get; set; }

		IDictionary<string, string> Parameters { get; }

		ParameterCollection ParameterCollection { get; }

		IDictionary<string, string> SubResources { get; }

		string HttpMethod { get; set; }

		Uri Endpoint { get; set; }

		string ResourcePath { get; set; }

		IDictionary<string, string> PathResources { get; }

		byte[] Content { get; set; }

		bool SetContentFromParameters { get; set; }

		Stream ContentStream { get; set; }

		long OriginalStreamPosition { get; set; }

		string OverrideSigningServiceName { get; set; }

		string ServiceName { get; }

		AmazonWebServiceRequest OriginalRequest { get; }

		RegionEndpoint AlternateEndpoint { get; set; }

		string HostPrefix { get; set; }

		bool Suppress404Exceptions { get; set; }

		AWS4SigningResult AWS4SignerResult { get; set; }

		bool? DisablePayloadSigning { get; set; }

		AWS4aSigningResult AWS4aSignerResult { get; set; }

		bool UseChunkEncoding { get; set; }

		string CanonicalResourcePrefix { get; set; }

		SignatureVersion SignatureVersion { get; set; }

		string AuthenticationRegion { get; set; }

		string DeterminedSigningRegion { get; set; }

		CoreChecksumAlgorithm SelectedChecksum { get; set; }

		IDictionary<string, string> TrailingHeaders { get; }

		bool UseDoubleEncoding { get; set; }

		IPropertyBag EndpointAttributes { get; set; }

		CompressionEncodingAlgorithm CompressionAlgorithm { get; set; }

		ChecksumData ChecksumData { get; set; }

		DateTime? SignedAt { get; set; }

		Version HttpProtocolVersion { get; set; }

		void AddSubResource(string subResource);

		void AddSubResource(string subResource, string value);

		void AddPathResource(string key, string value);

		string GetHeaderValue(string headerName);

		string ComputeContentStreamHash();

		bool IsRequestStreamRewindable();

		bool MayContainRequestBody();

		bool HasRequestBody();
	}
}
