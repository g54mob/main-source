using System.Threading;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime.Credentials.Internal
{
	public class AwsV4aAuthScheme : IAuthScheme<AWSCredentials>
	{
		private static ISigner _signer;

		public string SchemeId => "aws.auth#sigv4a";

		public IIdentityResolver GetIdentityResolver(IIdentityResolverConfiguration configuration)
		{
			return configuration.GetIdentityResolver<AWSCredentials>();
		}

		public ISigner Signer()
		{
			if (_signer == null)
			{
				Interlocked.Exchange(ref _signer, new AWS4aSignerCRTWrapper());
			}
			return _signer;
		}
	}
}
