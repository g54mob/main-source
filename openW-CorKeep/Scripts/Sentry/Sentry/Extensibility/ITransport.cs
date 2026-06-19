using System.Threading;
using System.Threading.Tasks;
using Sentry.Protocol.Envelopes;

namespace Sentry.Extensibility
{
	public interface ITransport
	{
		Task SendEnvelopeAsync(Envelope envelope, CancellationToken cancellationToken = default(CancellationToken));
	}
}
