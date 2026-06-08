using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.CredentialManagement;

namespace Amazon.Runtime.Credentials.Internal
{
	public interface ISSOTokenFileCache
	{
		bool Exists(CredentialProfileOptions options);

		bool TryGetSsoToken(SSOTokenManagerGetTokenOptions getSsoTokenOptions, string ssoCacheDirectory, out SsoToken ssoToken);

		void SaveSsoToken(SsoToken token, string ssoCacheDirectory);

		void DeleteSsoToken(SSOTokenManagerGetTokenOptions getSsoTokenOptions, string ssoCacheDirectory);

		void DeleteSsoToken(string filePath);

		List<SSOTokenFile> ScanSsoTokens(string ssoCacheDirectory);

		Task<TryResponse<SsoToken>> TryGetSsoTokenAsync(SSOTokenManagerGetTokenOptions getSsoTokenOptions, string ssoCacheDirectory, CancellationToken cancellationToken = default(CancellationToken));

		Task SaveSsoTokenAsync(SsoToken token, string ssoCacheDirectory, CancellationToken cancellationToken = default(CancellationToken));

		Task<List<SSOTokenFile>> ScanSsoTokensAsync(string ssoCacheDirectory, CancellationToken cancellationToken = default(CancellationToken));
	}
}
