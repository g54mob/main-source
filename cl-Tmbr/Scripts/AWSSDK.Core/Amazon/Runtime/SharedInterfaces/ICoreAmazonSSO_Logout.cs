using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.SharedInterfaces
{
	public interface ICoreAmazonSSO_Logout
	{
		Task LogoutAsync(string accessToken, CancellationToken cancellationToken = default(CancellationToken));
	}
}
