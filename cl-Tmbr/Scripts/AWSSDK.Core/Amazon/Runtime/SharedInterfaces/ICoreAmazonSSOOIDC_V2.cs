using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.SharedInterfaces
{
	public interface ICoreAmazonSSOOIDC_V2
	{
		Task<GetSsoTokenResponse> GetSsoTokenAsync(GetSsoTokenRequest getSsoTokenRequest, CancellationToken cancellationToken);
	}
}
