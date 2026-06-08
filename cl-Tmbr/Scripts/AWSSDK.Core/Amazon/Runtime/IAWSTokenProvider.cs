using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime
{
	public interface IAWSTokenProvider
	{
		Task<TryResponse<AWSToken>> TryResolveTokenAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
