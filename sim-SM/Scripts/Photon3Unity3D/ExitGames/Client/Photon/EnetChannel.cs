using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	internal class EnetChannel
	{
		internal byte ChannelNumber;

		internal NonAllocDictionary<int, NCommand> incomingReliableCommandsList;

		internal NonAllocDictionary<int, NCommand> incomingUnreliableCommandsList;

		internal Queue<NCommand> incomingUnsequencedCommandsList;

		internal NonAllocDictionary<int, NCommand> incomingUnsequencedFragments;

		internal Queue<NCommand> outgoingReliableCommandsList;

		internal Queue<NCommand> outgoingUnreliableCommandsList;

		internal int incomingReliableSequenceNumber;

		internal int incomingUnreliableSequenceNumber;

		internal int outgoingReliableSequenceNumber;

		internal int outgoingUnreliableSequenceNumber;

		internal int outgoingReliableUnsequencedNumber;

		private int reliableUnsequencedNumbersCompletelyReceived;

		private HashSet<int> reliableUnsequencedNumbersReceived;

		internal int highestReceivedAck;

		internal int reliableCommandsInFlight;

		internal int lowestUnacknowledgedSequenceNumber;

		public EnetChannel(byte channelNumber, int commandBufferSize)
		{
		}

		public bool ContainsUnreliableSequenceNumber(int unreliableSequenceNumber)
		{
			return false;
		}

		public NCommand FetchUnreliableSequenceNumber(int unreliableSequenceNumber)
		{
			return null;
		}

		public bool ContainsReliableSequenceNumber(int reliableSequenceNumber)
		{
			return false;
		}

		public NCommand FetchReliableSequenceNumber(int reliableSequenceNumber)
		{
			return null;
		}

		public bool TryGetFragment(int reliableSequenceNumber, bool isSequenced, out NCommand fragment)
		{
			fragment = null;
			return false;
		}

		public void RemoveFragment(int reliableSequenceNumber, bool isSequenced)
		{
		}

		public void clearAll()
		{
		}

		public bool QueueIncomingReliableUnsequenced(NCommand command)
		{
			return false;
		}
	}
}
