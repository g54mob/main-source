using System;
using Coherence.Connection;
using Coherence.Entities;

namespace Coherence.Toolkit
{
	public interface IClientConnectionManager
	{
		void GetPrefab(ClientID clientId, ConnectionType connectionType, Action<ICoherenceSync> onLoaded);

		void Add(CoherenceClientConnection connection);

		bool Remove(Entity entityID);
	}
}
