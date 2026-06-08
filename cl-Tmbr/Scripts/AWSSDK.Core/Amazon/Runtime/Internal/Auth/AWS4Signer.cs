using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime.Internal.Auth
{
	public class AWS4Signer : AbstractAWSSigner
	{
		public const string Scheme = "AWS4";

		public const string Algorithm = "HMAC-SHA256";

		public const string Sigv4aAlgorithm = "ECDSA-P256-SHA256";

		public const string AWS4AlgorithmTag = "AWS4-HMAC-SHA256";

		public const string AWS4aAlgorithmTag = "AWS4-ECDSA-P256-SHA256";

		public const string Terminator = "aws4_request";

		public static readonly byte[] TerminatorBytes = Encoding.UTF8.GetBytes("aws4_request");

		public const string Credential = "Credential";

		public const string SignedHeaders = "SignedHeaders";

		public const string Signature = "Signature";

		public const string EmptyBodySha256 = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";

		public const string StreamingBodySha256 = "STREAMING-AWS4-HMAC-SHA256-PAYLOAD";

		public const string StreamingBodySha256WithTrailer = "STREAMING-AWS4-HMAC-SHA256-PAYLOAD-TRAILER";

		public const string V4aStreamingBodySha256 = "STREAMING-AWS4-ECDSA-P256-SHA256-PAYLOAD";

		public const string V4aStreamingBodySha256WithTrailer = "STREAMING-AWS4-ECDSA-P256-SHA256-PAYLOAD-TRAILER";

		public const string AWSChunkedEncoding = "aws-chunked";

		public const string UnsignedPayload = "UNSIGNED-PAYLOAD";

		public const string UnsignedPayloadWithTrailer = "STREAMING-UNSIGNED-PAYLOAD-TRAILER";

		internal const SigningAlgorithm SignerAlgorithm = SigningAlgorithm.HmacSHA256;

		private static IEnumerable<string> _headersToIgnoreWhenSigning = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "x-amzn-trace-id", "transfer-encoding", "amz-sdk-invocation-id", "amz-sdk-request" };

		public bool SignPayload { get; private set; }

		public override ClientProtocol Protocol => ClientProtocol.RestProtocol;

		public AWS4Signer()
			: this(signPayload: true)
		{
		}

		public AWS4Signer(bool signPayload)
		{
			SignPayload = signPayload;
		}

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			ImmutableCredentials credentials = ((identity as AWSCredentials) ?? throw new AmazonClientException("The identity parameter must be of type AWSCredentials for the signer AWS4Signer.")).GetCredentials();
			if (credentials != null)
			{
				AWS4SigningResult aWS4SigningResult = (request.AWS4SignerResult = SignRequest(request, clientConfig, metrics, credentials.AccessKey, credentials.SecretKey));
				request.Headers["Authorization"] = aWS4SigningResult.ForAuthorizationHeader;
			}
		}

		public override IEventSigner CreateEventSigner(BaseIdentity identity, string region, string service, string requestSignature)
		{
			return new AWS4EventSigner((identity as AWSCredentials) ?? throw new AmazonClientException("The identity parameter must be of type AWSCredentials for the signer AWS4Signer."), region, service, requestSignature);
		}

		public AWS4SigningResult SignRequest(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			ValidateRequest(request);
			DateTime signedAt = InitializeHeaders(request.Headers, request.Endpoint);
			string text = ((!string.IsNullOrEmpty(request.OverrideSigningServiceName)) ? request.OverrideSigningServiceName : DetermineService(clientConfig, request));
			if (text == "s3")
			{
				request.UseDoubleEncoding = false;
			}
			request.DeterminedSigningRegion = DetermineSigningRegion(clientConfig, clientConfig.RegionEndpointServiceName, request.AlternateEndpoint, request);
			SetXAmzTrailerHeader(request.Headers, request.TrailingHeaders);
			string canonicalQueryString = CanonicalizeQueryParameters(GetParametersToCanonicalize(request));
			IDictionary<string, string> trailingHeaders = request.TrailingHeaders;
			string chunkedBodyHash = ((trailingHeaders != null && trailingHeaders.Count > 0) ? "STREAMING-AWS4-HMAC-SHA256-PAYLOAD-TRAILER" : "STREAMING-AWS4-HMAC-SHA256-PAYLOAD");
			string precomputedBodyHash = SetRequestBodyHash(request, SignPayload, chunkedBodyHash, 64);
			IDictionary<string, string> sortedHeaders = SortAndPruneHeaders(request.Headers);
			string text2 = CanonicalizeRequest(request.Endpoint, request.ResourcePath, request.HttpMethod, sortedHeaders, canonicalQueryString, precomputedBodyHash, request.PathResources, request.UseDoubleEncoding);
			metrics?.AddProperty(Metric.CanonicalRequest, text2);
			request.SignatureVersion = SignatureVersion.SigV4;
			return ComputeSignature(awsAccessKeyId, awsSecretAccessKey, request.DeterminedSigningRegion, signedAt, text, CanonicalizeHeaderNames(sortedHeaders), text2, metrics);
		}

		public static DateTime InitializeHeaders(IDictionary<string, string> headers, Uri requestEndpoint)
		{
			return InitializeHeaders(headers, requestEndpoint, CorrectClockSkew.GetCorrectedUtcNowForEndpoint(requestEndpoint.ToString()));
		}

		public static DateTime InitializeHeaders(IDictionary<string, string> headers, Uri requestEndpoint, DateTime requestDateTime)
		{
			CleanHeaders(headers);
			if (!headers.ContainsKey("host"))
			{
				string text = requestEndpoint.Host;
				if (!requestEndpoint.IsDefaultPort)
				{
					text = text + ":" + requestEndpoint.Port;
				}
				headers.Add("host", text);
			}
			DateTime result = requestDateTime;
			headers["X-Amz-Date"] = result.ToUniversalTime().ToString("yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture);
			return result;
		}

		public static void SetXAmzTrailerHeader(IDictionary<string, string> headers, IDictionary<string, string> trailingHeaders)
		{
			if (trailingHeaders != null && trailingHeaders.Count != 0)
			{
				headers["X-Amz-Trailer"] = string.Join(",", trailingHeaders.Keys.OrderBy((string key) => key).ToArray());
			}
		}

		private static void CleanHeaders(IDictionary<string, string> headers)
		{
			headers.Remove("Authorization");
			headers.Remove("X-Amz-Content-SHA256");
			if (headers.TryGetValue("X-Amz-Decoded-Content-Length", out var value))
			{
				headers["Content-Length"] = value;
				headers.Remove("X-Amz-Decoded-Content-Length");
			}
		}

		private static void ValidateRequest(IRequest request)
		{
			Uri endpoint = request.Endpoint;
			if (request.DisablePayloadSigning == true && endpoint.Scheme != "https")
			{
				throw new AmazonClientException("When DisablePayloadSigning is true, the request must be sent over HTTPS.");
			}
		}

		public static AWS4SigningResult ComputeSignature(ImmutableCredentials credentials, string region, DateTime signedAt, string service, string signedHeaders, string canonicalRequest)
		{
			return ComputeSignature(credentials.AccessKey, credentials.SecretKey, region, signedAt, service, signedHeaders, canonicalRequest);
		}

		public static AWS4SigningResult ComputeSignature(string awsAccessKey, string awsSecretAccessKey, string region, DateTime signedAt, string service, string signedHeaders, string canonicalRequest)
		{
			return ComputeSignature(awsAccessKey, awsSecretAccessKey, region, signedAt, service, signedHeaders, canonicalRequest, null);
		}

		public static AWS4SigningResult ComputeSignature(string awsAccessKey, string awsSecretAccessKey, string region, DateTime signedAt, string service, string signedHeaders, string canonicalRequest, RequestMetrics metrics)
		{
			string text = FormatDateTime(signedAt, "yyyyMMdd");
			string text2 = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/{3}", text, region, service, "aws4_request");
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}-{1}\n{2}\n{3}\n", "AWS4", "HMAC-SHA256", FormatDateTime(signedAt, "yyyyMMddTHHmmssZ"), text2);
			byte[] data = ComputeHash(canonicalRequest);
			stringBuilder.Append(AWSSDKUtils.ToHex(data, lowercase: true));
			metrics?.AddProperty(Metric.StringToSign, stringBuilder);
			byte[] array = ComposeSigningKey(awsSecretAccessKey, region, text, service);
			string data2 = stringBuilder.ToString();
			byte[] signature = ComputeKeyedHash(SigningAlgorithm.HmacSHA256, array, data2);
			return new AWS4SigningResult(awsAccessKey, signedAt, signedHeaders, text2, array, signature);
		}

		public static string FormatDateTime(DateTime dt, string formatString)
		{
			return dt.ToUniversalTime().ToString(formatString, CultureInfo.InvariantCulture);
		}

		public static byte[] ComposeSigningKey(string awsSecretAccessKey, string region, string date, string service)
		{
			char[] array = null;
			try
			{
				array = ("AWS4" + awsSecretAccessKey).ToCharArray();
				byte[] key = ComputeKeyedHash(SigningAlgorithm.HmacSHA256, Encoding.UTF8.GetBytes(array), Encoding.UTF8.GetBytes(date));
				byte[] key2 = ComputeKeyedHash(SigningAlgorithm.HmacSHA256, key, Encoding.UTF8.GetBytes(region));
				byte[] key3 = ComputeKeyedHash(SigningAlgorithm.HmacSHA256, key2, Encoding.UTF8.GetBytes(service));
				return ComputeKeyedHash(SigningAlgorithm.HmacSHA256, key3, TerminatorBytes);
			}
			finally
			{
				if (array != null)
				{
					Array.Clear(array, 0, array.Length);
				}
			}
		}

		public static string SetRequestBodyHash(IRequest request, string chunkedBodyHash, int signatureLength)
		{
			return SetRequestBodyHash(request, signPayload: true, chunkedBodyHash, signatureLength);
		}

		public static string SetRequestBodyHash(IRequest request, bool signPayload, string chunkedBodyHash, int signatureLength)
		{
			if (request.DisablePayloadSigning.HasValue ? request.DisablePayloadSigning.Value : (!signPayload))
			{
				IDictionary<string, string> trailingHeaders = request.TrailingHeaders;
				if (trailingHeaders != null && trailingHeaders.Count > 0)
				{
					request.Headers["X-Amz-Decoded-Content-Length"] = request.Headers["Content-Length"];
					long baseStreamLength = long.Parse(request.Headers["Content-Length"], CultureInfo.InvariantCulture);
					request.Headers["Content-Length"] = TrailingHeadersWrapperStream.CalculateLength(request.TrailingHeaders, request.SelectedChecksum, baseStreamLength).ToString(CultureInfo.InvariantCulture);
					SetContentEncodingHeader(request);
					return SetPayloadSignatureHeader(request, "STREAMING-UNSIGNED-PAYLOAD-TRAILER");
				}
				return SetPayloadSignatureHeader(request, "UNSIGNED-PAYLOAD");
			}
			if (request.Headers.TryGetValue("X-Amz-Content-SHA256", out var value) && !request.UseChunkEncoding)
			{
				return value;
			}
			if (request.UseChunkEncoding)
			{
				value = chunkedBodyHash;
				if (request.Headers.TryGetValue("Content-Length", out var value2))
				{
					request.Headers["X-Amz-Decoded-Content-Length"] = value2;
					long originalLength = long.Parse(value2, CultureInfo.InvariantCulture);
					request.Headers["Content-Length"] = ChunkedUploadWrapperStream.ComputeChunkedContentLength(originalLength, signatureLength, request.TrailingHeaders, request.SelectedChecksum).ToString(CultureInfo.InvariantCulture);
				}
				SetContentEncodingHeader(request);
			}
			else if (request.ContentStream != null)
			{
				value = request.ComputeContentStreamHash();
			}
			else
			{
				byte[] requestPayloadBytes = AWSSDKUtils.GetRequestPayloadBytes(request, request.UseQueryString);
				value = AWSSDKUtils.ToHex(CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(requestPayloadBytes), lowercase: true);
			}
			return SetPayloadSignatureHeader(request, value ?? "UNSIGNED-PAYLOAD");
		}

		private static void SetContentEncodingHeader(IRequest request)
		{
			if (request.Headers.TryGetValue("Content-Encoding", out var value) && !value.Contains("aws-chunked"))
			{
				request.Headers["Content-Encoding"] = value + ", aws-chunked";
			}
		}

		public static byte[] SignBlob(byte[] key, string data)
		{
			return SignBlob(key, Encoding.UTF8.GetBytes(data));
		}

		public static byte[] SignBlob(byte[] key, byte[] data)
		{
			return CryptoUtilFactory.CryptoInstance.HMACSignBinary(data, key, SigningAlgorithm.HmacSHA256);
		}

		public static byte[] ComputeKeyedHash(SigningAlgorithm algorithm, byte[] key, string data)
		{
			return ComputeKeyedHash(algorithm, key, Encoding.UTF8.GetBytes(data));
		}

		public static byte[] ComputeKeyedHash(SigningAlgorithm algorithm, byte[] key, byte[] data)
		{
			return CryptoUtilFactory.CryptoInstance.HMACSignBinary(data, key, algorithm);
		}

		public static byte[] ComputeHash(string data)
		{
			return ComputeHash(Encoding.UTF8.GetBytes(data));
		}

		public static byte[] ComputeHash(byte[] data)
		{
			return CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(data);
		}

		private static string SetPayloadSignatureHeader(IRequest request, string payloadHash)
		{
			if (request.Headers.ContainsKey("X-Amz-Content-SHA256"))
			{
				request.Headers["X-Amz-Content-SHA256"] = payloadHash;
			}
			else
			{
				request.Headers.Add("X-Amz-Content-SHA256", payloadHash);
			}
			return payloadHash;
		}

		public static string DetermineSigningRegion(IClientConfig clientConfig, string serviceName, RegionEndpoint alternateEndpoint, IRequest request)
		{
			if (alternateEndpoint != null)
			{
				return alternateEndpoint.SystemName;
			}
			string authenticationRegion = clientConfig.AuthenticationRegion;
			if (request != null && request.AuthenticationRegion != null)
			{
				authenticationRegion = request.AuthenticationRegion;
			}
			if (!string.IsNullOrEmpty(authenticationRegion))
			{
				return authenticationRegion.ToLowerInvariant();
			}
			if (!string.IsNullOrEmpty(clientConfig.ServiceURL))
			{
				string text = AWSSDKUtils.DetermineRegion(clientConfig.ServiceURL);
				if (!string.IsNullOrEmpty(text))
				{
					return text.ToLowerInvariant();
				}
			}
			RegionEndpoint regionEndpoint = clientConfig.RegionEndpoint;
			if (regionEndpoint != null)
			{
				return regionEndpoint.SystemName;
			}
			return string.Empty;
		}

		public static string DetermineService(IClientConfig clientConfig, IRequest request)
		{
			if (!string.IsNullOrEmpty(clientConfig.AuthenticationServiceName))
			{
				return clientConfig.AuthenticationServiceName;
			}
			ServiceOperationEndpointParameters parameters = new ServiceOperationEndpointParameters(request.OriginalRequest);
			return AWSSDKUtils.DetermineService(clientConfig.DetermineServiceOperationEndpoint(parameters).URL);
		}

		protected static string CanonicalizeRequest(Uri endpoint, string resourcePath, string httpMethod, IDictionary<string, string> sortedHeaders, string canonicalQueryString, string precomputedBodyHash)
		{
			return CanonicalizeRequest(endpoint, resourcePath, httpMethod, sortedHeaders, canonicalQueryString, precomputedBodyHash, null);
		}

		protected static string CanonicalizeRequest(Uri endpoint, string resourcePath, string httpMethod, IDictionary<string, string> sortedHeaders, string canonicalQueryString, string precomputedBodyHash, IDictionary<string, string> pathResources)
		{
			return CanonicalizeRequestHelper(endpoint, resourcePath, httpMethod, sortedHeaders, canonicalQueryString, precomputedBodyHash, pathResources, doubleEncode: true);
		}

		protected static string CanonicalizeRequest(Uri endpoint, string resourcePath, string httpMethod, IDictionary<string, string> sortedHeaders, string canonicalQueryString, string precomputedBodyHash, IDictionary<string, string> pathResources, bool doubleEncode)
		{
			return CanonicalizeRequestHelper(endpoint, resourcePath, httpMethod, sortedHeaders, canonicalQueryString, precomputedBodyHash, pathResources, doubleEncode);
		}

		private static string CanonicalizeRequestHelper(Uri endpoint, string resourcePath, string httpMethod, IDictionary<string, string> sortedHeaders, string canonicalQueryString, string precomputedBodyHash, IDictionary<string, string> pathResources, bool doubleEncode)
		{
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(512);
			valueStringBuilder.Append(httpMethod);
			valueStringBuilder.Append('\n');
			valueStringBuilder.Append(AWSSDKUtils.CanonicalizeResourcePathV2(endpoint, resourcePath, doubleEncode, pathResources) + "\n");
			valueStringBuilder.Append(canonicalQueryString + "\n");
			valueStringBuilder.Append(CanonicalizeHeaders(sortedHeaders) + "\n");
			valueStringBuilder.Append(CanonicalizeHeaderNames(sortedHeaders) + "\n");
			string value;
			if (precomputedBodyHash != null)
			{
				valueStringBuilder.Append(precomputedBodyHash);
			}
			else if (sortedHeaders.TryGetValue("X-Amz-Content-SHA256", out value))
			{
				valueStringBuilder.Append(value);
			}
			return valueStringBuilder.ToString();
		}

		protected internal static IDictionary<string, string> SortAndPruneHeaders(IEnumerable<KeyValuePair<string, string>> requestHeaders)
		{
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(StringComparer.Ordinal);
			foreach (KeyValuePair<string, string> requestHeader in requestHeaders)
			{
				if (!_headersToIgnoreWhenSigning.Contains(requestHeader.Key))
				{
					sortedDictionary.Add(requestHeader.Key.ToLowerInvariant(), requestHeader.Value);
				}
			}
			return sortedDictionary;
		}

		protected internal static string CanonicalizeHeaders(IEnumerable<KeyValuePair<string, string>> sortedHeaders)
		{
			if (sortedHeaders == null)
			{
				return string.Empty;
			}
			ICollection<KeyValuePair<string, string>> collection = (sortedHeaders as ICollection<KeyValuePair<string, string>>) ?? sortedHeaders.ToList();
			if (collection.Count == 0)
			{
				return string.Empty;
			}
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(512);
			foreach (KeyValuePair<string, string> item in collection)
			{
				valueStringBuilder.Append(item.Key.ToLowerInvariant());
				valueStringBuilder.Append(':');
				valueStringBuilder.Append(AWSSDKUtils.CompressSpaces(item.Value)?.Trim());
				valueStringBuilder.Append("\n");
			}
			return valueStringBuilder.ToString();
		}

		protected static string CanonicalizeHeaderNames(IEnumerable<KeyValuePair<string, string>> sortedHeaders)
		{
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(512);
			foreach (KeyValuePair<string, string> sortedHeader in sortedHeaders)
			{
				if (valueStringBuilder.Length > 0)
				{
					valueStringBuilder.Append(';');
				}
				valueStringBuilder.Append(sortedHeader.Key.ToLowerInvariant());
			}
			return valueStringBuilder.ToString();
		}

		protected static List<KeyValuePair<string, string>> GetParametersToCanonicalize(IRequest request)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (request.SubResources != null && request.SubResources.Count > 0)
			{
				foreach (KeyValuePair<string, string> subResource in request.SubResources)
				{
					list.Add(new KeyValuePair<string, string>(subResource.Key, subResource.Value));
				}
			}
			if (request.UseQueryString && request.Parameters != null && request.Parameters.Count > 0)
			{
				foreach (KeyValuePair<string, string> item in from queryParameter in request.ParameterCollection.GetSortedParametersList()
					where queryParameter.Value != null
					select queryParameter)
				{
					list.Add(new KeyValuePair<string, string>(item.Key, item.Value));
				}
			}
			return list;
		}

		protected static string CanonicalizeQueryParameters(string queryString)
		{
			return CanonicalizeQueryParameters(queryString, uriEncodeParameters: true);
		}

		protected static string CanonicalizeQueryParameters(string queryString, bool uriEncodeParameters)
		{
			if (string.IsNullOrEmpty(queryString))
			{
				return string.Empty;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			int num = queryString.IndexOf('?');
			string text = queryString.Substring(++num);
			int num2 = 0;
			int num3 = text.IndexOfAny(new char[2] { '&', ';' }, 0);
			if (num3 == -1 && num2 < text.Length)
			{
				num3 = text.Length;
			}
			while (num3 != -1)
			{
				string text2 = text.Substring(num2, num3 - num2);
				if (num3 + 1 >= text.Length || text[num3 + 1] != ' ')
				{
					int num4 = text2.IndexOf('=');
					if (num4 == -1)
					{
						dictionary.Add(text2, null);
					}
					else
					{
						dictionary.Add(text2.Substring(0, num4), text2.Substring(num4 + 1));
					}
					num2 = num3 + 1;
				}
				if (text.Length <= num3 + 1)
				{
					break;
				}
				num3 = text.IndexOfAny(new char[2] { '&', ';' }, num3 + 1);
				if (num3 == -1 && num2 < text.Length)
				{
					num3 = text.Length;
				}
			}
			return CanonicalizeQueryParameters(dictionary, uriEncodeParameters);
		}

		protected static string CanonicalizeQueryParameters(IEnumerable<KeyValuePair<string, string>> parameters)
		{
			return CanonicalizeQueryParameters(parameters, uriEncodeParameters: true);
		}

		protected static string CanonicalizeQueryParameters(IEnumerable<KeyValuePair<string, string>> parameters, bool uriEncodeParameters)
		{
			if (parameters == null)
			{
				return string.Empty;
			}
			List<KeyValuePair<string, string>> list = parameters.OrderBy((KeyValuePair<string, string> kvp) => kvp.Key, StringComparer.Ordinal).ToList();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in list)
			{
				string key = item.Key;
				string value = item.Value;
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append("&");
				}
				if (uriEncodeParameters)
				{
					if (string.IsNullOrEmpty(value))
					{
						stringBuilder.AppendFormat("{0}=", AWSSDKUtils.UrlEncode(key, path: false));
					}
					else
					{
						stringBuilder.AppendFormat("{0}={1}", AWSSDKUtils.UrlEncode(key, path: false), AWSSDKUtils.UrlEncode(value, path: false));
					}
				}
				else if (string.IsNullOrEmpty(value))
				{
					stringBuilder.AppendFormat("{0}=", key);
				}
				else
				{
					stringBuilder.AppendFormat("{0}={1}", key, value);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
