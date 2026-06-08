using System;

namespace Amazon.Runtime.Internal.Auth
{
	public abstract class AWSSigningResultBase
	{
		private readonly string _awsAccessKeyId;

		private readonly DateTime _originalDateTime;

		private readonly string _signedHeaders;

		private readonly string _scope;

		public string AccessKeyId => _awsAccessKeyId;

		public string ISO8601DateTime => AWS4Signer.FormatDateTime(_originalDateTime, "yyyyMMddTHHmmssZ");

		public string ISO8601Date => AWS4Signer.FormatDateTime(_originalDateTime, "yyyyMMdd");

		public DateTime DateTime => _originalDateTime;

		public string SignedHeaders => _signedHeaders;

		public string Scope => _scope;

		public abstract string Signature { get; }

		public abstract string ForAuthorizationHeader { get; }

		public AWSSigningResultBase(string awsAccessKeyId, DateTime signedAt, string signedHeaders, string scope)
		{
			_awsAccessKeyId = awsAccessKeyId;
			_originalDateTime = signedAt;
			_signedHeaders = signedHeaders;
			_scope = scope;
		}
	}
}
