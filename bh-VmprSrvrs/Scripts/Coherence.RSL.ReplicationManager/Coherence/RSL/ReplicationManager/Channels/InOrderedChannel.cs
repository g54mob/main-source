using System;
using System.Collections.Generic;
using System.Numerics;
using Coherence.Brook;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager.Requests;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager.Channels
{
	public class InOrderedChannel : IInChannel
	{
		private readonly ReceiveSequenceBuffer sequenceBuffer;

		private readonly ISchemaSpecificComponentDeserialize deserializer;

		private readonly IEntityMapper mapper;

		private readonly Queue<ExpirableMessage> receivedCommands;

		private readonly Logger logger;

		private readonly uint participant;

		private static readonly TimeSpan OrderedChannelMessageExpireDelay;

		public InOrderedChannel(ISchemaSpecificComponentDeserialize deserializer, IEntityMapper mapper, uint participant, Logger logger)
		{
		}

		public bool Deserialize(IInBitStream stream, AbsoluteSimulationFrame packetSimulationFrame, Vector3 floatingOriginDelta)
		{
			return false;
		}

		public void FlushBuffer(List<IBaseRequest> requestBuffer, List<InternalDestroy> destroyBuffer, List<Entity> _)
		{
		}

		public bool HasNothingToProcess()
		{
			return false;
		}

		public List<Coherence.RSL.EntityManager.Requests.RefsInfo> GetRefsInfos()
		{
			return null;
		}

		public void MapResolvableEntities(List<Entity> resolvableEntities)
		{
		}
	}
}
