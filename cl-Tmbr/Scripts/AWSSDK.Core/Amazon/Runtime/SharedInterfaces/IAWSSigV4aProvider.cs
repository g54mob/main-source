using System.Collections.Generic;
using System.IO;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.SharedInterfaces
{
	public interface IAWSSigV4aProvider
	{
		ClientProtocol Protocol { get; }

		void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, ImmutableCredentials credentials);

		AWS4aSigningResult SignRequest(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, ImmutableCredentials credentials);

		AWS4aSigningResult Presign4a(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, ImmutableCredentials credentials, string service, string overrideSigningRegion);

		string SignChunk(Stream chunkBody, string previousSignature, AWS4aSigningResult headerSigningResult);

		string SignTrailingHeaderChunk(IDictionary<string, string> trailingHeaders, string previousSignature, AWS4aSigningResult headerSigningResult);
	}
}
