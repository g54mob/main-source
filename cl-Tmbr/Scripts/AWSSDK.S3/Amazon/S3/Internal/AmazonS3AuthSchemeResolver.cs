using System.Collections.Generic;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.S3.Internal
{
	public class AmazonS3AuthSchemeResolver : IAuthSchemeResolver<AmazonS3AuthSchemeParameters>
	{
		public List<IAuthSchemeOption> ResolveAuthScheme(AmazonS3AuthSchemeParameters authParameters)
		{
			_ = authParameters.Operation;
			return AuthSchemeOption.DEFAULT_SIGV4;
		}
	}
}
