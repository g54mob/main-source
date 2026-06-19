using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Extensibility
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface INetworkStatusListener
	{
		bool Online { get; }

		Task WaitForNetworkOnlineAsync(CancellationToken cancellationToken);
	}
}
