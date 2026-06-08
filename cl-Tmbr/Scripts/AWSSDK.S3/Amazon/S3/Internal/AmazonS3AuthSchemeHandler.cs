using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.S3.Internal
{
	public class AmazonS3AuthSchemeHandler : BaseAuthResolverHandler
	{
		private readonly AmazonS3EndpointResolver _endpointResolver = new AmazonS3EndpointResolver();

		public AmazonS3AuthSchemeResolver AuthSchemeResolver { get; } = new AmazonS3AuthSchemeResolver();

		protected override List<IAuthSchemeOption> ResolveAuthOptions(IExecutionContext executionContext)
		{
			List<IAuthSchemeOption> list = BaseAuthResolverHandler.RetrieveSchemesFromEndpoint(_endpointResolver.GetEndpoint(executionContext));
			if (list != null)
			{
				return list;
			}
			IRequestContext requestContext = executionContext.RequestContext;
			AmazonS3AuthSchemeParameters authParameters = new AmazonS3AuthSchemeParameters
			{
				Operation = requestContext.Request.RequestName,
				Region = requestContext.ClientConfig.RegionEndpoint?.SystemName
			};
			return AuthSchemeResolver.ResolveAuthScheme(authParameters);
		}

		protected override ISigner GetSigner(IAuthScheme<BaseIdentity> scheme)
		{
			return new S3Signer();
		}
	}
}
