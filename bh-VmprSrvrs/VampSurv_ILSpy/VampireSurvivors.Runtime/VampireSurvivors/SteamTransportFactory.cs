using Coherence.Log;
using Coherence.Stats;
using Coherence.Transport;

namespace VampireSurvivors;

public class SteamTransportFactory(SteamConnectionManager steamConnectionManager) : ITransportFactory
{
	private readonly SteamConnectionManager _steamConnectionManager = steamConnectionManager;

	public ITransport Create(ushort mtu, IStats stats, Logger logger)
	{
		return new SteamTransport(stats, logger, _steamConnectionManager);
	}
}
