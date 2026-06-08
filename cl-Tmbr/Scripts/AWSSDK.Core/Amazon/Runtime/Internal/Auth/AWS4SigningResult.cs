using System;
using System.Globalization;
using System.Text;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public class AWS4SigningResult : AWSSigningResultBase
	{
		private readonly byte[] _signingKey;

		private readonly byte[] _signature;

		public override string Signature => AWSSDKUtils.ToHex(_signature, lowercase: true);

		public override string ForAuthorizationHeader => new StringBuilder().Append("AWS4-HMAC-SHA256").AppendFormat(" {0}={1}/{2},", "Credential", base.AccessKeyId, base.Scope).AppendFormat(" {0}={1},", "SignedHeaders", base.SignedHeaders)
			.AppendFormat(" {0}={1}", "Signature", Signature)
			.ToString();

		public string ForQueryParameters => new StringBuilder().AppendFormat("{0}={1}", AWSSDKUtils.UrlEncode("X-Amz-Algorithm", path: false), AWSSDKUtils.UrlEncode("AWS4-HMAC-SHA256", path: false)).AppendFormat("&{0}={1}", AWSSDKUtils.UrlEncode("X-Amz-Credential", path: false), AWSSDKUtils.UrlEncode(string.Format(CultureInfo.InvariantCulture, "{0}/{1}", base.AccessKeyId, base.Scope), path: false)).AppendFormat("&{0}={1}", AWSSDKUtils.UrlEncode("X-Amz-Date", path: false), AWSSDKUtils.UrlEncode(base.ISO8601DateTime, path: false))
			.AppendFormat("&{0}={1}", AWSSDKUtils.UrlEncode("X-Amz-SignedHeaders", path: false), AWSSDKUtils.UrlEncode(base.SignedHeaders, path: false))
			.AppendFormat("&{0}={1}", AWSSDKUtils.UrlEncode("X-Amz-Signature", path: false), AWSSDKUtils.UrlEncode(Signature, path: false))
			.ToString();

		public AWS4SigningResult(string awsAccessKeyId, DateTime signedAt, string signedHeaders, string scope, byte[] signingKey, byte[] signature)
			: base(awsAccessKeyId, signedAt, signedHeaders, scope)
		{
			_signingKey = signingKey;
			_signature = signature;
		}

		public byte[] GetSigningKey()
		{
			byte[] array = new byte[_signingKey.Length];
			_signingKey.CopyTo(array, 0);
			return array;
		}
	}
}
