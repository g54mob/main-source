using Coherence.Log;
using Coherence.Stats;

namespace Coherence.Transport
{
	public class DefaultTransportFactory : ITransportFactory
	{
		private readonly TransportType type;

		private readonly TransportConfiguration configuration;

		public DefaultTransportFactory(TransportType type = TransportType.UDPWithTCPFallback, TransportConfiguration configuration = TransportConfiguration.Default)
		{
		}

		public ITransport Create(ushort mtu, IStats stats, Logger logger)
		{
			return null;
		}
	}
}
