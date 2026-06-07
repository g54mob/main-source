using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;
using Coherence.Stats;

namespace Coherence.Core.Channels
{
	internal class InNetworkChannel : IInNetworkChannel
	{
		private readonly ISchemaSpecificComponentDeserialize deserializer;

		private readonly IComponentInfo definition;

		private readonly ReceiveChangeBuffer changeBuffer;

		private readonly Coherence.Stats.Stats stats;

		private readonly Logger logger;

		private readonly List<IncomingEntityUpdate> updatesBuffer;

		private readonly List<IEntityMessage> messagesBuffer;

		public event Action<List<IncomingEntityUpdate>> OnEntityUpdate
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

		public event Action<IEntityCommand, MessageTarget, Entity> OnCommand
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

		public event Action<IEntityInput, long, Entity> OnInput
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

		public InNetworkChannel(ISchemaSpecificComponentDeserialize deserializer, IComponentInfo definition, IEntityRegistry entityRegistry, Coherence.Stats.Stats stats, Logger logger)
		{
		}

		public bool Deserialize(IInBitStream stream, AbsoluteSimulationFrame packetSimulationFrame, Vector3 floatingOriginDelta)
		{
			return false;
		}

		public List<RefsInfo> GetRefsInfos()
		{
			return null;
		}

		public void FlushBuffer(IReadOnlyCollection<Entity> resolvableEntities)
		{
		}

		public void Clear()
		{
		}

		private void PerformMessage(MessageType messageType, AbsoluteSimulationFrame packetSimulationFrame, IInBitStream bitStream, Vector3 floatingOriginDelta)
		{
		}

		private void HandleCommands(IInBitStream bitStream)
		{
		}

		private void HandleInputs(IInBitStream bitStream)
		{
		}

		private void HandleEntityUpdate(AbsoluteSimulationFrame packetSimulationFrame, IInBitStream bitStream, Vector3 floatingOriginDelta)
		{
		}
	}
}
