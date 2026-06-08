using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Credentials.Internal
{
	public interface ISSOTokenManager
	{
		Task<SsoToken> GetTokenAsync(SSOTokenManagerGetTokenOptions options, CancellationToken cancellationToken = default(CancellationToken));

		Task LogoutAsync(string ssoCacheDirectory = null, CancellationToken cancellationToken = default(CancellationToken));

		Task LogoutAsync(SSOTokenManagerGetTokenOptions options, CancellationToken cancellationToken = default(CancellationToken));
	}
}
