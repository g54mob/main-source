using System.Collections.Generic;
using Coherence.Brisk;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.Transport;

namespace Coherence.Core
{
	public static class Core
	{
		public static IClient GetNewClient(IDefinition root, Logger logger, HashSet<Entity> activeEntities = null, TransportType transportType = TransportType.UDPWithTCPFallback, TransportConfiguration transportConfiguration = TransportConfiguration.Default, BriskServices briskServices = null)
		{
			return null;
		}

		public static IClient GetNewClient(IDefinition root, Logger logger, HashSet<Entity> activeEntities = null, ITransportFactory transportFactory = null, BriskServices briskServices = null)
		{
			return null;
		}
	}
}
