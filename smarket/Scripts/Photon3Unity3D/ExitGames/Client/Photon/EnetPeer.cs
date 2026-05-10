using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	internal class EnetPeer : PeerBase
	{
		private const int CRC_LENGTH = 4;

		private const int EncryptedDataGramHeaderSize = 7;

		private const int EncryptedHeaderSize = 5;

		private const int QUICK_RESEND_QUEUELIMIT = 25;

		internal NCommandPool nCommandPool;

		private List<NCommand> sentReliableCommands;

		private int sendWindowUpdateRequiredBackValue;

		private StreamBuffer outgoingAcknowledgementsPool;

		internal const int UnsequencedWindowSize = 128;

		internal readonly int[] unsequencedWindow;

		internal int outgoingUnsequencedGroupNumber;

		internal int incomingUnsequencedGroupNumber;

		private byte udpCommandCount;

		private byte[] udpBuffer;

		private int udpBufferIndex;

		private byte[] bufferForEncryption;

		private int commandBufferSize;

		internal int challenge;

		internal int reliableCommandsRepeated;

		internal int reliableCommandsSent;

		internal int serverSentTime;

		internal static readonly byte[] udpHeader0xF3;

		protected bool datagramEncryptedConnection;

		private EnetChannel[] channelArray;

		private const byte ControlChannelNumber = 255;

		protected internal const short PeerIdForConnect = -1;

		protected internal const short PeerIdForConnectTrace = -2;

		private Queue<int> commandsToRemove;

		private int fragmentLength;

		private int fragmentLengthDatagramEncrypt;

		private int fragmentLengthMtuValue;

		private Queue<NCommand> CommandQueue;

		private readonly HashSet<byte> channelsToUpdateLowestSent;

		private int[] lowestSentSequenceNumber;

		internal override int QueuedIncomingCommandsCount => 0;

		internal override int QueuedOutgoingCommandsCount => 0;

		internal override int SentReliableCommandsCount => 0;

		private bool sendWindowUpdateRequired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal EnetPeer()
		{
		}

		internal override bool IsTransportEncrypted()
		{
			return false;
		}

		internal override void Reset()
		{
		}

		internal void ApplyRandomizedSequenceNumbers()
		{
		}

		private EnetChannel GetChannel(byte channelNumber)
		{
			return null;
		}

		internal override bool Connect(string ipport, string proxyServerAddress, string appID, object photonToken)
		{
			return false;
		}

		public override void OnConnect()
		{
		}

		internal override void Disconnect()
		{
		}

		internal override void StopConnection()
		{
		}

		internal override void FetchServerTimestamp()
		{
		}

		internal override bool DispatchIncomingCommands()
		{
			return false;
		}

		private int GetFragmentLength()
		{
			return 0;
		}

		private int CalculatePacketSize(int inSize)
		{
			return 0;
		}

		private int CalculateInitialOffset()
		{
			return 0;
		}

		internal override bool SendAcksOnly()
		{
			return false;
		}

		internal override bool SendOutgoingCommands()
		{
			return false;
		}

		private void UpdateSendWindow()
		{
		}

		internal override bool EnqueuePhotonMessage(StreamBuffer opBytes, SendOptions sendParams)
		{
			return false;
		}

		internal bool CreateAndEnqueueCommand(byte commandType, StreamBuffer payload, byte channelNumber)
		{
			return false;
		}

		internal int SerializeAckToBuffer()
		{
			return 0;
		}

		internal int SerializeToBuffer(Queue<NCommand> commandList, int channelSequenceLimit)
		{
			return 0;
		}

		private bool SerializeCommandToBuffer(NCommand command, bool commandIsInSentQueue = false)
		{
			return false;
		}

		internal void SendData(byte[] data, int length)
		{
		}

		private void SendToSocket(byte[] data, int length)
		{
		}

		private void SendDataEncrypted(byte[] data, int length)
		{
		}

		internal void QueueSentCommand(NCommand command, bool commandIsAlreadyInSentQueue = false)
		{
		}

		internal void QueueOutgoingReliableCommand(NCommand command)
		{
		}

		internal void QueueOutgoingUnreliableCommand(NCommand command)
		{
		}

		internal void QueueOutgoingAcknowledgement(NCommand readCommand, int sendTime)
		{
		}

		internal override void ReceiveIncomingCommands(byte[] inBuff, int inDataLength)
		{
		}

		internal void ExecuteCommand(NCommand command)
		{
		}

		internal bool QueueIncomingCommand(NCommand command)
		{
			return false;
		}

		internal NCommand RemoveSentReliableCommand(int ackReceivedReliableSequenceNumber, int ackReceivedChannel, bool isUnsequenced)
		{
			return null;
		}

		internal string CommandListToString(NCommand[] list)
		{
			return null;
		}
	}
}
