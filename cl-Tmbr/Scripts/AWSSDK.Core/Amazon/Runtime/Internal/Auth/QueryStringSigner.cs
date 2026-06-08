using System;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public class QueryStringSigner : AbstractAWSSigner
	{
		private const string SignatureVersion2 = "2";

		public override ClientProtocol Protocol => ClientProtocol.QueryStringProtocol;

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			ImmutableCredentials credentials = (identity as AWSCredentials).GetCredentials();
			if (string.IsNullOrEmpty(credentials?.AccessKey))
			{
				throw new ArgumentOutOfRangeException("awsAccessKeyId", "The AWS Access Key ID cannot be NULL or a Zero length string");
			}
			request.Parameters["AWSAccessKeyId"] = credentials.AccessKey;
			request.Parameters["SignatureVersion"] = "2";
			request.Parameters["SignatureMethod"] = clientConfig.SignatureMethod.ToString();
			request.Parameters["Timestamp"] = AWSSDKUtils.GetFormattedTimestampISO8601(clientConfig, request.OriginalRequest);
			request.SignedAt = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(request.Endpoint.ToString());
			request.Parameters.Remove("Signature");
			string text = AWSSDKUtils.CalculateStringToSignV2(request.ParameterCollection, request.Endpoint.AbsoluteUri);
			metrics.AddProperty(Metric.StringToSign, text);
			string value = AbstractAWSSigner.ComputeHash(text, credentials.SecretKey, clientConfig.SignatureMethod);
			request.Parameters["Signature"] = value;
		}
	}
}
