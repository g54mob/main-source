using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Core.Channels;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;

namespace Coherence.Core
{
	public class InConnection
	{
		private const int FULL_PACKET_MARGIN = 128;

		private readonly IEntityRegistry knownEntities;

		private readonly SortedList<ChannelID, IInNetworkChannel> channels;

		private readonly RefsResolver refsResolver;

		private Vector3d currentFloatingOrigin;

		private int octetStreamWarnThreshold;

		private readonly Logger logger;

		private readonly List<RefsInfo> allRefsInfos;

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

		public event Action<AbsoluteSimulationFrame> OnServerSimulationFrameReceived
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

		internal event Action<int> OnPacketReceived
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

		internal InConnection(IEntityRegistry knownEntities, Dictionary<ChannelID, IInNetworkChannel> channels, Logger logger)
		{
		}

		private void AddChannel(ChannelID channelID, IInNetworkChannel channel)
		{
		}

		public void ProcessIncomingPacket(IInOctetStream octetStream)
		{
		}

		private bool ReadSingleChannel(IInBitStream bitStream, AbsoluteSimulationFrame packetSimulationFrame, Vector3 floatingOriginDelta, ChannelID channelID)
		{
			return false;
		}

		private bool ReadMultipleChannels(IInBitStream bitStream, AbsoluteSimulationFrame packetSimulationFrame, Vector3 floatingOriginDelta)
		{
			return false;
		}

		internal void Clear()
		{
		}

		internal void SetFloatingOrigin(Vector3d newFloatingOrigin)
		{
		}

		internal void SetMaximumTransmissionUnit(int mtu)
		{
		}

		private void FlushChangeBuffer()
		{
		}
	}
}
