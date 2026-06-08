using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Identity
{
	public interface IIdentityResolver
	{
		BaseIdentity ResolveIdentity(IClientConfig clientConfig);

		Task<BaseIdentity> ResolveIdentityAsync(IClientConfig clientConfig, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IIdentityResolver<T> : IIdentityResolver where T : BaseIdentity
	{
		new T ResolveIdentity(IClientConfig clientConfig);

		new Task<T> ResolveIdentityAsync(IClientConfig clientConfig, CancellationToken cancellationToken = default(CancellationToken));
	}
}
