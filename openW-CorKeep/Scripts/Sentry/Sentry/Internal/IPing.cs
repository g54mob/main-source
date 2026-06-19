using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal
{
	internal interface IPing
	{
		Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
	}
}
