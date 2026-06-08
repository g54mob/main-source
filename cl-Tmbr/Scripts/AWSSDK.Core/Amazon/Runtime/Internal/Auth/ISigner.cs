using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public interface ISigner
	{
		ClientProtocol Protocol { get; }

		bool RequiresCredentials { get; }

		void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity);

		Task SignAsync(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity, CancellationToken token = default(CancellationToken));

		IEventSigner CreateEventSigner(BaseIdentity identity, string region, string service, string requestSignature);
	}
}
