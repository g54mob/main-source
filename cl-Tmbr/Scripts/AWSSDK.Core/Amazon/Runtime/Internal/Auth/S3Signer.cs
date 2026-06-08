using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public class S3Signer : AbstractAWSSigner
	{
		public delegate void RegionDetectionUpdater(IRequest request);

		private readonly RegionDetectionUpdater _regionDetector;

		private static readonly HashSet<string> SignableParameters = new HashSet<string>(new string[6] { "response-content-type", "response-content-language", "response-expires", "response-cache-control", "response-content-disposition", "response-content-encoding" }, StringComparer.OrdinalIgnoreCase);

		private static readonly HashSet<string> SubResourcesSigningExclusion = new HashSet<string>(new string[1] { "id" }, StringComparer.OrdinalIgnoreCase);

		public override ClientProtocol Protocol => ClientProtocol.RestProtocol;

		public S3Signer()
			: this(null)
		{
		}

		public S3Signer(RegionDetectionUpdater regionDetector)
		{
			_regionDetector = regionDetector;
		}

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			AbstractAWSSigner abstractAWSSigner = SelectSigner(this, useSigV4Setting: true, request, clientConfig);
			AWS4Signer aWS4Signer = abstractAWSSigner as AWS4Signer;
			AWS4aSignerCRTWrapper aWS4aSignerCRTWrapper = abstractAWSSigner as AWS4aSignerCRTWrapper;
			bool flag = aWS4Signer != null;
			bool flag2 = aWS4aSignerCRTWrapper != null;
			ImmutableCredentials credentials = ((identity as AWSCredentials) ?? throw new AmazonClientException("The identity parameter must be of type AWSCredentials for the signer S3Signer.")).GetCredentials();
			if (credentials == null)
			{
				return;
			}
			if (flag2)
			{
				AWS4aSigningResult aWS4aSignerResult = aWS4aSignerCRTWrapper.SignRequest(request, clientConfig, metrics, credentials);
				if (request.UseChunkEncoding)
				{
					request.AWS4aSignerResult = aWS4aSignerResult;
				}
			}
			else if (flag)
			{
				_regionDetector?.Invoke(request);
				AWS4SigningResult aWS4SigningResult = aWS4Signer.SignRequest(request, clientConfig, metrics, credentials.AccessKey, credentials.SecretKey);
				request.Headers["Authorization"] = aWS4SigningResult.ForAuthorizationHeader;
				if (request.UseChunkEncoding)
				{
					request.AWS4SignerResult = aWS4SigningResult;
				}
			}
			else
			{
				SignRequest(request, metrics, credentials.AccessKey, credentials.SecretKey);
			}
		}

		public static void SignRequest(IRequest request, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			request.Headers["X-Amz-Date"] = AWSSDKUtils.FormattedCurrentTimestampRFC822;
			request.SignedAt = AWSSDKUtils.CorrectedUtcNow;
			string text = BuildStringToSign(request);
			metrics.AddProperty(Metric.StringToSign, text);
			string text2 = CryptoUtilFactory.CryptoInstance.HMACSign(text, awsSecretAccessKey, SigningAlgorithm.HmacSHA1);
			string value = "AWS " + awsAccessKeyId + ":" + text2;
			request.Headers["Authorization"] = value;
			request.SignatureVersion = SignatureVersion.SigV2;
		}

		private static string BuildStringToSign(IRequest request)
		{
			StringBuilder stringBuilder = new StringBuilder("", 256);
			stringBuilder.Append(request.HttpMethod);
			stringBuilder.Append("\n");
			IDictionary<string, string> headers = request.Headers;
			IDictionary<string, string> parameters = request.Parameters;
			if (headers != null)
			{
				string text = null;
				if (headers.ContainsKey("Content-MD5") && !string.IsNullOrEmpty(text = headers["Content-MD5"]))
				{
					stringBuilder.Append(text);
				}
				stringBuilder.Append("\n");
				if (parameters.ContainsKey("ContentType"))
				{
					stringBuilder.Append(parameters["ContentType"]);
				}
				else if (headers.ContainsKey("Content-Type"))
				{
					stringBuilder.Append(headers["Content-Type"]);
				}
				stringBuilder.Append("\n");
			}
			else
			{
				stringBuilder.Append("\n\n");
			}
			if (parameters.ContainsKey("Expires"))
			{
				stringBuilder.Append(parameters["Expires"]);
				headers?.Remove("X-Amz-Date");
			}
			IDictionary<string, string> dictionary = new Dictionary<string, string>(headers);
			foreach (KeyValuePair<string, string> item in parameters)
			{
				if (!dictionary.ContainsKey(item.Key))
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
			stringBuilder.Append("\n");
			stringBuilder.Append(BuildCanonicalizedHeaders(dictionary));
			string value = BuildCanonicalizedResource(request);
			if (!string.IsNullOrEmpty(value))
			{
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		private static string BuildCanonicalizedHeaders(IDictionary<string, string> headers)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			foreach (string item in headers.Keys.OrderBy((string x) => x.ToLowerInvariant(), StringComparer.Ordinal))
			{
				string text = item.ToLowerInvariant();
				if (text.StartsWith("x-amz-", StringComparison.Ordinal))
				{
					stringBuilder.Append(text + ":" + headers[item]?.Trim() + "\n");
				}
			}
			return stringBuilder.ToString();
		}

		private static string BuildCanonicalizedResource(IRequest request)
		{
			StringBuilder stringBuilder = new StringBuilder(request.CanonicalResourcePrefix);
			stringBuilder.Append((!string.IsNullOrEmpty(request.ResourcePath)) ? AWSSDKUtils.ResolveResourcePathV2(request.ResourcePath, request.PathResources) : "/");
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			if (request.SubResources.Count > 0)
			{
				foreach (KeyValuePair<string, string> subResource in request.SubResources)
				{
					if (!SubResourcesSigningExclusion.Contains(subResource.Key))
					{
						dictionary.Add(subResource.Key, subResource.Value);
					}
				}
			}
			if (request.Parameters.Count > 0)
			{
				foreach (KeyValuePair<string, string> sortedParameters in request.ParameterCollection.GetSortedParametersList())
				{
					if (sortedParameters.Value != null && SignableParameters.Contains(sortedParameters.Key))
					{
						dictionary.Add(sortedParameters.Key, sortedParameters.Value);
					}
				}
			}
			string arg = "?";
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				list.Add(item);
			}
			list.Sort((KeyValuePair<string, string> firstPair, KeyValuePair<string, string> nextPair) => string.CompareOrdinal(firstPair.Key, nextPair.Key));
			foreach (KeyValuePair<string, string> item2 in list)
			{
				stringBuilder.AppendFormat("{0}{1}", arg, item2.Key);
				if (item2.Value != null)
				{
					stringBuilder.AppendFormat("={0}", item2.Value);
				}
				arg = "&";
			}
			return stringBuilder.ToString();
		}
	}
}
