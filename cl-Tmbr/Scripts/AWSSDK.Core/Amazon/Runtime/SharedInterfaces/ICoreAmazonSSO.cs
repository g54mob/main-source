using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Runtime.SharedInterfaces
{
	public interface ICoreAmazonSSO
	{
		Task<ImmutableCredentials> CredentialsFromSsoAccessTokenAsync(string accountId, string roleName, string accessToken, IDictionary<string, object> additionalProperties);
	}
}
