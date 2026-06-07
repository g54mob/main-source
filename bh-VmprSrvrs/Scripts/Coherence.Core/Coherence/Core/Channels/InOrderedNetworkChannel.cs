using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;
using Coherence.Stats;

namespace Coherence.Core.Channels
{
	internal class InOrderedNetworkChannel : IInNetworkChannel
	{
		internal static readonly int SequenceBufferSize;

		internal const int MillisecondsMessageTTL = 5000;

		private static readonly TimeSpan MessageTTL;

		private readonly ISchemaSpecificComponentDeserialize deserializer;

		private readonly IComponentInfo definition;

		private readonly IEntityRegistry entityRegistry;

		private readonly Coherence.Stats.Stats stats;

		private readonly Logger logger;

		private readonly ReceiveSequenceBuffer sequenceBuffer;

		private readonly Queue<ExpirableMessage> receivedCommands;

		private readonly IDateTimeProvider dateTimeProvider;

		private readonly List<IEntityMessage> receivedMessages;

		public event Action<List<IncomingEntityUpdate>> OnEntityUpdate
		{
			add
			{
			}
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
			add
			{
			}
			remove
			{
			}
		}

		public InOrderedNetworkChannel(ISchemaSpecificComponentDeserialize deserializer, IComponentInfo definition, IEntityRegistry entityRegistry, Coherence.Stats.Stats stats, Logger logger)
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
	}
}
