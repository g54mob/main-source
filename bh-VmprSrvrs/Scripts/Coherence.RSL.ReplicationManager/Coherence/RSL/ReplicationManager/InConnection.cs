using System.Collections.Generic;
using System.Numerics;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.Brisk.Connection;
using Coherence.RSL.EntityManager.Requests;
using Coherence.RSL.ReplicationManager.Channels;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager
{
	public class InConnection
	{
		private readonly uint participant;

		private FloatingOrigin currentFloatingOrigin;

		private List<IInOctetStream> receivedStreams;

		private IConnectionReceiver receiver;

		private uint protocolVersion;

		private IEntityMapper mapper;

		private Logger logger;

		private readonly SortedList<ChannelID, IInChannel> channels;

		private readonly CacheList<ChannelID> channelsWithChanges;

		private readonly CacheList<IBaseRequest> requestCache;

		private IInChannel DefaultChannel => null;

		public InConnection(uint participant, IConnectionReceiver receiver, IEntityMapper mapper, IExtendedDefinition root, uint protocolVersion, Dictionary<ChannelID, IInChannel> channels, Logger logger)
		{
		}

		internal void AddChannel(ChannelID channelID, IInChannel channel)
		{
		}

		private void OnReceive(IInOctetStream stream)
		{
		}

		public void Tick(List<IBaseRequest> requestBuffer, List<InternalDestroy> internalDestroyBuffer)
		{
		}

		private bool HandleStream(IInOctetStream stream)
		{
			return false;
		}

		private void ProcessIncomingPacket(IInOctetStream octetStream)
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

		private void FlushChangeBuffers(List<IBaseRequest> requestBuffer, List<InternalDestroy> internalDestroyBuffer)
		{
		}
	}
}
