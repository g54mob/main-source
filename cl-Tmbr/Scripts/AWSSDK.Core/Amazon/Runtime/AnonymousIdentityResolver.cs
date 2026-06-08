using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Identity;

namespace Amazon.Runtime
{
	public class AnonymousIdentityResolver : IIdentityResolver<AnonymousAWSCredentials>, IIdentityResolver
	{
		private readonly AnonymousAWSCredentials _credentials = new AnonymousAWSCredentials();

		BaseIdentity IIdentityResolver.ResolveIdentity(IClientConfig clientConfig)
		{
			return _credentials;
		}

		public AnonymousAWSCredentials ResolveIdentity(IClientConfig clientConfig)
		{
			return _credentials;
		}

		Task<BaseIdentity> IIdentityResolver.ResolveIdentityAsync(IClientConfig clientConfig, CancellationToken cancellationToken)
		{
			return Task.FromResult((BaseIdentity)_credentials);
		}

		public Task<AnonymousAWSCredentials> ResolveIdentityAsync(IClientConfig clientConfig, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.FromResult(_credentials);
		}
	}
}
