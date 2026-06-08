using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Identity;

namespace Amazon.Runtime.Credentials
{
	public class DefaultAWSTokenIdentityResolver : IIdentityResolver<AWSToken>, IIdentityResolver
	{
		private readonly IAWSTokenProvider _tokenProvider;

		public DefaultAWSTokenIdentityResolver()
		{
			_tokenProvider = new AWSTokenProviderChain(new ProfileTokenProvider());
		}

		BaseIdentity IIdentityResolver.ResolveIdentity(IClientConfig clientConfig)
		{
			return ResolveIdentity(null);
		}

		public AWSToken ResolveIdentity(IClientConfig clientConfig)
		{
			TryResponse<AWSToken> result = _tokenProvider.TryResolveTokenAsync().GetAwaiter().GetResult();
			if (result.Success)
			{
				return result.Value;
			}
			throw new AmazonClientException("Failed to resolve bearer token in DefaultAWSTokenIdentityResolver");
		}

		async Task<BaseIdentity> IIdentityResolver.ResolveIdentityAsync(IClientConfig clientConfig, CancellationToken cancellationToken)
		{
			return await ResolveIdentityAsync(clientConfig, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<AWSToken> ResolveIdentityAsync(IClientConfig clientConfig, CancellationToken cancellationToken = default(CancellationToken))
		{
			TryResponse<AWSToken> tryResponse = await _tokenProvider.TryResolveTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (tryResponse.Success)
			{
				return tryResponse.Value;
			}
			throw new AmazonClientException("Failed to resolve bearer token in DefaultAWSTokenIdentityResolver");
		}
	}
}
