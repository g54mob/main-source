using System.Collections.Generic;
using System.Numerics;
using Coherence.Brook;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager.Requests;
using Coherence.RSL.ReplicationManager.InBuffer;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager.Channels
{
	internal class InChannel : IInChannel
	{
		private readonly Coherence.RSL.ReplicationManager.InBuffer.InBuffer changeBuffer;

		private readonly uint participant;

		private readonly RequestManager requestManager;

		private readonly IExtendedDefinition root;

		private readonly Logger logger;

		private readonly List<IncomingEntityUpdate> updatesBuffer;

		internal InChannel(uint participant, IExtendedDefinition root, IEntityMapper mapper, Logger logger)
		{
		}

		public bool Deserialize(IInBitStream stream, AbsoluteSimulationFrame packetSimulationFrame, Vector3 floatingOriginDelta)
		{
			return false;
		}

		private void PerformMessage(MessageType messageType, AbsoluteSimulationFrame packetSimulationFrame, IInBitStream bitStream, Vector3 floatingOriginDelta)
		{
		}

		private void HandleEntityUpdate(AbsoluteSimulationFrame packetSimulationFrame, IInBitStream bitStream, Vector3 floatingOriginDelta)
		{
		}

		private void ProcessIncomingEntityUpdate(IncomingEntityUpdate update)
		{
		}

		private void HandleCommands(IInBitStream bitStream)
		{
		}

		private void HandleInputs(IInBitStream bitStream)
		{
		}

		private bool CanRouteCommand(IEntityCommand command)
		{
			return false;
		}

		public void FlushBuffer(List<IBaseRequest> requestBuffer, List<InternalDestroy> destroyBuffer, List<Entity> resolvableEntities)
		{
		}

		public bool HasNothingToProcess()
		{
			return false;
		}

		public List<RefsInfo> GetRefsInfos()
		{
			return null;
		}

		public void MapResolvableEntities(List<Entity> resolvableEntities)
		{
		}
	}
}
