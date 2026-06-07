using Coherence.Log;
using Coherence.Stats;

namespace Coherence.Transport
{
	public interface ITransportFactory
	{
		ITransport Create(ushort mtu, IStats stats, Logger logger);
	}
}
