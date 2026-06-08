using System.Threading.Tasks;

namespace Amazon.Runtime.SharedInterfaces
{
	public interface ICoreAmazonSSOOIDC
	{
		Task<GetSsoTokenResponse> GetSsoTokenAsync(GetSsoTokenRequest getSsoTokenRequest);

		Task<GetSsoTokenResponse> RefreshTokenAsync(GetSsoTokenResponse previousResponse);
	}
}
