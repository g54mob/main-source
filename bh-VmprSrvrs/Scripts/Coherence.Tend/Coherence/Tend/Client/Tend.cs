using System;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Log;
using Coherence.Tend.Models;

namespace Coherence.Tend.Client
{
	public class Tend
	{
		public bool Connected;

		private readonly IOutgoingLogic tendOut;

		private readonly IIncomingLogic tendIn;

		private readonly Logger logger;

		public bool CanSend => false;

		public SequenceId OutgoingSequenceId => default(SequenceId);

		public SequenceId LastReceivedByRemote => default(SequenceId);

		private int NumberOfPacketsPending => 0;

		public event Action<DeliveryInfo> OnDeliveryInfo
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

		public Tend(Logger logger)
		{
		}

		public Tend(Logger logger, IOutgoingLogic tendOut, IIncomingLogic tendIn)
		{
		}

		public bool ReadHeader(IInOctetStream stream, out TendHeader tendHeader, out bool didAck)
		{
			tendHeader = default(TendHeader);
			didAck = default(bool);
			return false;
		}

		public TendHeader WriteHeader(IOutOctetStream stream, bool isReliable)
		{
			return default(TendHeader);
		}

		public void OnPacketSent(SequenceId sequenceId, bool isReliable)
		{
		}

		public bool IsValidSeqToSend(in SequenceId sentSequenceId)
		{
			return false;
		}

		public static void SerializeHeader(IOutOctetStream stream, TendHeader tendHeader)
		{
		}

		public static TendHeader DeserializeHeader(IInOctetStream stream)
		{
			return default(TendHeader);
		}
	}
}
