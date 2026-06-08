using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public class AWS4PreSignedUrlSigner : AWS4Signer
	{
		public const long MaxAWS4PreSignedUrlExpiry = 604800L;

		public static readonly IEnumerable<string> ServicesUsingUnsignedPayload = new HashSet<string> { "s3", "s3-object-lambda", "s3-outposts", "s3express" };

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			throw new InvalidOperationException("PreSignedUrl signature computation is not supported by this method; use SignRequest instead.");
		}

		public new AWS4SigningResult SignRequest(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			string service = "s3";
			if (!string.IsNullOrEmpty(request.OverrideSigningServiceName))
			{
				service = request.OverrideSigningServiceName;
			}
			return SignRequest(request, clientConfig, metrics, awsAccessKeyId, awsSecretAccessKey, service, null);
		}

		public static AWS4SigningResult SignRequest(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey, string service, string overrideSigningRegion)
		{
			if (service == "s3" || service == "s3express")
			{
				request.UseDoubleEncoding = false;
			}
			request.Headers.Remove("Authorization");
			if (!request.Headers.ContainsKey("host"))
			{
				string text = request.Endpoint.Host;
				if (!request.Endpoint.IsDefaultPort)
				{
					text = text + ":" + request.Endpoint.Port;
				}
				request.Headers.Add("host", text);
			}
			DateTime correctedUtcNowForEndpoint = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(request.Endpoint.ToString());
			request.SignedAt = correctedUtcNowForEndpoint;
			string text2 = overrideSigningRegion ?? AWS4Signer.DetermineSigningRegion(clientConfig, clientConfig.RegionEndpointServiceName, request.AlternateEndpoint, request);
			if (request.Headers.ContainsKey("X-Amz-Content-SHA256"))
			{
				request.Headers.Remove("X-Amz-Content-SHA256");
			}
			IDictionary<string, string> sortedHeaders = AWS4Signer.SortAndPruneHeaders(request.Headers);
			string text3 = AWS4Signer.CanonicalizeHeaderNames(sortedHeaders);
			List<KeyValuePair<string, string>> parametersToCanonicalize = AWS4Signer.GetParametersToCanonicalize(request);
			parametersToCanonicalize.Add(new KeyValuePair<string, string>("X-Amz-Algorithm", "AWS4-HMAC-SHA256"));
			string value = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/{3}/{4}", awsAccessKeyId, AWS4Signer.FormatDateTime(correctedUtcNowForEndpoint, "yyyyMMdd"), text2, service, "aws4_request");
			parametersToCanonicalize.Add(new KeyValuePair<string, string>("X-Amz-Credential", value));
			parametersToCanonicalize.Add(new KeyValuePair<string, string>("X-Amz-Date", AWS4Signer.FormatDateTime(correctedUtcNowForEndpoint, "yyyyMMddTHHmmssZ")));
			parametersToCanonicalize.Add(new KeyValuePair<string, string>("X-Amz-SignedHeaders", text3));
			string canonicalQueryString = AWS4Signer.CanonicalizeQueryParameters(parametersToCanonicalize);
			string text4 = AWS4Signer.CanonicalizeRequest(request.Endpoint, request.ResourcePath, request.HttpMethod, sortedHeaders, canonicalQueryString, ServicesUsingUnsignedPayload.Contains(service) ? "UNSIGNED-PAYLOAD" : "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", request.PathResources, request.UseDoubleEncoding);
			metrics?.AddProperty(Metric.CanonicalRequest, text4);
			return AWS4Signer.ComputeSignature(awsAccessKeyId, awsSecretAccessKey, text2, correctedUtcNowForEndpoint, service, text3, text4, metrics);
		}
	}
}
