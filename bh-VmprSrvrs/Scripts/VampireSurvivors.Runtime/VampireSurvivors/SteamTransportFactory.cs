using Coherence.Log;
using Coherence.Stats;
using Coherence.Transport;

namespace VampireSurvivors
{
	public class SteamTransportFactory : ITransportFactory
	{
		private readonly SteamConnectionManager _steamConnectionManager;

		public SteamTransportFactory(SteamConnectionManager steamConnectionManager)
		{
		}

		public ITransport Create(ushort mtu, IStats stats, Logger logger)
		{
			return null;
		}
	}
}
