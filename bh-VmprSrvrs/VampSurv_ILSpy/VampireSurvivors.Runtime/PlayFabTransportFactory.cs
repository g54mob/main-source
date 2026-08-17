using Coherence.Log;
using Coherence.Stats;
using Coherence.Transport;
using PlayFab.Party;

public class PlayFabTransportFactory : ITransportFactory
{
	private PlayFabMultiplayerManager manager;

	private string host;

	public ITransport Create(ushort mtu, IStats stats, Logger logger)
	{
		PlayFabMultiplayerManager playFabMultiplayerManager = default(PlayFabMultiplayerManager);
		return new PlayFabTransport(logger, stats, host, playFabMultiplayerManager);
	}

	public PlayFabTransportFactory(string host, PlayFabMultiplayerManager manager)
	{
		this.manager = manager;
		this.host = host;
	}
}
