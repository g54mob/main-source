using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Core.Channels;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;

namespace Coherence.Core
{
	public class OutConnection
	{
		private readonly SortedList<ChannelID, IOutNetworkChannel> channels;

		private readonly IOutConnection connection;

		private HashSet<Entity> ackedEntities;

		private Dictionary<Entity, HashSet<uint>> ackedComponentsPerEntity;

		private HashSet<Entity> entitiesInAuthTransfer;

		private readonly Logger logger;

		private List<Entity> entitiesToRemove;

		private Vector3d floatingOrigin;

		private readonly Dictionary<ChannelID, Dictionary<Entity, OutgoingEntityUpdate>> allChannelUpdatesSent;

		private IOutNetworkChannel DefaultChannel => null;

		internal event Action<PacketSentDebugInfo> OnPacketSent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal event Action<Entity> OnEntityAcked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal event Action<Entity> OnAuthorityTransferred
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal OutConnection(IOutConnection connection, Dictionary<ChannelID, IOutNetworkChannel> channels, HashSet<Entity> ackedEntities, Logger logger)
		{
		}

		internal void AddChannel(ChannelID channelID, IOutNetworkChannel channel)
		{
		}

		public void Update(AbsoluteSimulationFrame clientSimulationFrame)
		{
		}

		public void OnDeliveryInfo(DeliveryInfo info)
		{
		}

		public bool IsEntityInAuthTransfer(Entity id)
		{
			return false;
		}

		public bool CanSendUpdates(Entity id)
		{
			return false;
		}

		public void CreateEntity(Entity id, ICoherenceComponentData[] data)
		{
		}

		public void UpdateEntity(Entity id, ICoherenceComponentData[] data)
		{
		}

		public void RemoveComponent(Entity id, uint[] componentTypes)
		{
		}

		public void DestroyEntity(Entity id)
		{
		}

		public void PushCommand(IEntityCommand message, MessageTarget target, Entity id, ChannelID channelID)
		{
		}

		public void PushInput(IEntityInput message)
		{
		}

		private void SerializeAndQueuePackets(AbsoluteSimulationFrame clientSimulationFrame)
		{
		}

		private void ReliableSendToConnection(OutPacket packet)
		{
		}

		public void ClearAllChangesForEntity(Entity id)
		{
		}

		public void HoldChangesForEntity(Entity id)
		{
		}

		public void Reset()
		{
		}

		private void UpdateHeldEntities()
		{
		}

		internal void SetFloatingOrigin(Vector3d floatingOrigin)
		{
		}
	}
}
