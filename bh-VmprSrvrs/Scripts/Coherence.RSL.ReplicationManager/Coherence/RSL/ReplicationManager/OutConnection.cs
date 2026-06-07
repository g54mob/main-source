using System;
using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.Brisk.Connection;
using Coherence.RSL.EntityManager.Commands;
using Coherence.RSL.EntityManager.Query;
using Coherence.RSL.EntityManager.Requests;
using Coherence.RSL.ReplicationManager.Channels;
using Coherence.RSL.ReplicationManager.ClientWorld;
using Coherence.RSL.ReplicationManager.OutBuffer;
using Coherence.RSL.Tickers;
using Coherence.Serializer;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager
{
	public class OutConnection : IOutgoingEntityChangeBuffer, IDisposable
	{
		private static readonly int inputSendingFrequency;

		private uint participant;

		private Entity relativeConnectionEntity;

		private IExtendedDefinition root;

		private IEntityMapper mapper;

		private FloatingOrigin floatingOrigin;

		private WorldProcessResult worldResult;

		private QuerySync querySync;

		private IUserConnection connection;

		private uint protocolVersion;

		private readonly SortedList<ChannelID, IOutChannel> channels;

		private readonly CacheList<Entity> acked;

		private ITickProvider mainSendTicker;

		private ITickProvider inputSendTicker;

		private Coherence.RSL.ReplicationManager.ClientWorld.ClientWorld clientWorld;

		private Logger logger;

		private IOutChannel DefaultChannel => null;

		public OutConnection(uint participant, Entity connectionEntity, ITickProviderFactory tickProviderFactory, int sendFrequency, double minQueryDistance, IUserConnection connection, IEntityMapper mapper, IClientQueryHandler queryHandler, IExtendedDefinition root, Dictionary<ChannelID, IOutChannel> channels, Logger logger)
		{
		}

		private void AddChannel(ChannelID channelID, IOutChannel channel)
		{
		}

		public void Dispose()
		{
		}

		public void ProcessInternalDestroys(IReadOnlyList<InternalDestroy> destroys)
		{
		}

		public IReadOnlyList<IBaseRequest> ProcessChanges(IReadOnlyList<ResponseInfo> changes)
		{
			return null;
		}

		public void HandleClientMessage(IClientMessage clientMessage)
		{
		}

		public void HandleCommand(IEntityMessage command)
		{
		}

		public void HandleInput(IEntityMessage input)
		{
		}

		public void Tick()
		{
		}

		private void OnDeliveryInfo(DeliveryInfo info)
		{
		}

		private SerializedEntityMessage MapEntityMessage(IEntityMessage originalMessage, MessageType messageType)
		{
			return null;
		}

		private void HandleAuthorityChanged(AuthorityChangedMessage message)
		{
		}

		private void HandleAuthorityRequestRejection(AuthorityRequestRejectionMessage message)
		{
		}

		private void HandleSceneIndexChangedMessage(SceneIndexChangedMessage message)
		{
		}

		private void RemoveSceneComponentChanges()
		{
		}

		private bool TryMapWorldResult()
		{
			return false;
		}

		private bool HandleTick()
		{
			return false;
		}

		private bool TickInputs()
		{
			return false;
		}

		private void CheckQuerySync(List<Entity> acked)
		{
		}

		private void HandleQuerySyncResult(QuerySync.Result result)
		{
		}

		private void SendQuerySyncedCommand(bool liveQuerySynced, bool globalQuerySynced)
		{
		}

		private void HandleReceived()
		{
		}

		private void HandleLost(SequenceId _)
		{
		}

		private void SendInputsOnly()
		{
		}

		private void SendChanges()
		{
		}

		private void SendChannels(SerializerContext<IOutBitStream> serializerCtx, AbsoluteSimulationFrame simulationFrameNow)
		{
		}

		public void ShiftOutgoingPositionComponents(Vector3d floatingOriginShift)
		{
		}
	}
}
