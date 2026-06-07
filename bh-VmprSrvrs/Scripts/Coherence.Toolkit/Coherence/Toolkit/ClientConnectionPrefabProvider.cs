using Coherence.Connection;

namespace Coherence.Toolkit
{
	public delegate CoherenceSync ClientConnectionPrefabProvider(ClientID clientId, ConnectionType connectionType);
}
