using System;
using System.Text;

namespace Amazon.Runtime.Internal.Auth
{
	public class AWS4aSigningResult : AWSSigningResultBase
	{
		private readonly string _regionSet;

		private readonly string _signature;

		private readonly string _service;

		private readonly string _presignedUri;

		private readonly ImmutableCredentials _credentials;

		public override string Signature => _signature;

		public override string ForAuthorizationHeader => new StringBuilder().Append("AWS4-ECDSA-P256-SHA256").AppendFormat(" {0}={1}/{2},", "Credential", base.AccessKeyId, base.Scope).AppendFormat(" {0}={1},", "SignedHeaders", base.SignedHeaders)
			.AppendFormat(" {0}={1}", "Signature", Signature)
			.ToString();

		public string RegionSet => _regionSet;

		public string PresignedUri => _presignedUri;

		public string Service => _service;

		public ImmutableCredentials Credentials => _credentials;

		public AWS4aSigningResult(string awsAccessKeyId, DateTime signedAt, string signedHeaders, string scope, string regionSet, string signature, string service, string presignedUri, ImmutableCredentials credentials)
			: base(awsAccessKeyId, signedAt, signedHeaders, scope)
		{
			_regionSet = regionSet;
			_signature = signature;
			_service = service;
			_presignedUri = presignedUri;
			_credentials = credentials;
		}
	}
}
