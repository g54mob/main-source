using System;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.SocketServer.Security;

namespace ExitGames.Client.Photon
{
	public abstract class PeerBase
	{
		internal delegate void MyAction();

		private static class GpBinaryV3Parameters
		{
			public const byte CustomObject = 0;

			public const byte ExtraPlatformParams = 1;
		}

		internal PhotonPeer photonPeer;

		public IProtocol SerializationProtocol;

		internal ConnectionProtocol usedTransportProtocol;

		internal IPhotonSocket PhotonSocket;

		internal ConnectionStateValue peerConnectionState;

		internal int ByteCountLastOperation;

		internal int ByteCountCurrentDispatch;

		internal NCommand CommandInCurrentDispatch;

		internal int packetLossByCrc;

		internal int packetLossByChallenge;

		internal readonly Queue<MyAction> ActionQueue;

		internal short peerID;

		internal int serverTimeOffset;

		internal bool serverTimeOffsetIsAvailable;

		internal int roundTripTime;

		internal int roundTripTimeVariance;

		internal int lastRoundTripTime;

		internal int lowestRoundTripTime;

		internal int highestRoundTripTimeVariance;

		internal int timestampOfLastReceive;

		internal static short peerCount;

		internal long bytesOut;

		internal long bytesIn;

		internal object PhotonToken;

		internal object CustomInitData;

		public string AppId;

		internal EventData reusableEventData;

		private Stopwatch watch;

		internal int timeoutInt;

		internal int timeLastAckReceive;

		internal int longestSentCall;

		internal int timeLastSendAck;

		internal int timeLastSendOutgoing;

		internal bool ApplicationIsInitialized;

		internal bool isEncryptionAvailable;

		internal int outgoingCommandsInStream;

		protected internal static Queue<StreamBuffer> MessageBufferPool;

		internal byte[] messageHeader;

		internal ICryptoProvider CryptoProvider;

		private readonly Random lagRandomizer;

		internal readonly LinkedList<SimulationItem> NetSimListOutgoing;

		internal readonly LinkedList<SimulationItem> NetSimListIncoming;

		private readonly NetworkSimulationSet networkSimulationSettings;

		internal int TrafficPackageHeaderSize;

		public string ServerAddress { get; internal set; }

		public string ProxyServerAddress { get; internal set; }

		internal IPhotonPeerListener Listener => null;

		public DebugLevel debugOut => default(DebugLevel);

		internal int DisconnectTimeout => 0;

		internal int timePingInterval => 0;

		internal byte ChannelCount => 0;

		internal long BytesOut => 0L;

		internal long BytesIn => 0L;

		internal abstract int QueuedIncomingCommandsCount { get; }

		internal abstract int QueuedOutgoingCommandsCount { get; }

		internal virtual int SentReliableCommandsCount => 0;

		public virtual string PeerID => null;

		internal int timeInt => 0;

		internal static int outgoingStreamBufferSize => 0;

		internal int mtu => 0;

		protected internal bool IsIpv6 => false;

		public NetworkSimulationSet NetworkSimulationSettings => null;

		internal bool TrafficStatsEnabled => false;

		internal TrafficStats TrafficStatsIncoming => null;

		internal TrafficStats TrafficStatsOutgoing => null;

		internal TrafficStatsGameLevel TrafficStatsGameLevel => null;

		public static StreamBuffer MessageBufferPoolGet()
		{
			return null;
		}

		public static void MessageBufferPoolPut(StreamBuffer buff)
		{
		}

		internal virtual void Reset()
		{
		}

		internal abstract bool Connect(string serverAddress, string proxyServerAddress, string appID, object photonToken);

		private string GetHttpKeyValueString(Dictionary<string, string> dic)
		{
			return null;
		}

		internal byte[] WriteInitRequest()
		{
			return null;
		}

		private byte[] WriteInitV3()
		{
			return null;
		}

		internal string PrepareWebSocketUrl(string serverAddress, string appId, object photonToken)
		{
			return null;
		}

		public abstract void OnConnect();

		internal void InitCallback()
		{
		}

		internal abstract void Disconnect();

		internal abstract void StopConnection();

		internal abstract void FetchServerTimestamp();

		internal abstract bool IsTransportEncrypted();

		internal abstract bool EnqueuePhotonMessage(StreamBuffer opBytes, SendOptions sendParams);

		internal StreamBuffer SerializeOperationToMessage(byte opCode, Dictionary<byte, object> parameters, EgMessageType messageType, bool encrypt)
		{
			return null;
		}

		internal StreamBuffer SerializeOperationToMessage(byte opCode, ParameterDictionary parameters, EgMessageType messageType, bool encrypt)
		{
			return null;
		}

		internal StreamBuffer SerializeMessageToMessage(object message, bool encrypt)
		{
			return null;
		}

		internal abstract bool SendOutgoingCommands();

		internal virtual bool SendAcksOnly()
		{
			return false;
		}

		internal abstract void ReceiveIncomingCommands(byte[] inBuff, int dataLength);

		internal abstract bool DispatchIncomingCommands();

		internal virtual bool DeserializeMessageAndCallback(StreamBuffer stream)
		{
			return false;
		}

		internal void UpdateRoundTripTimeAndVariance(int lastRoundtripTime)
		{
		}

		internal bool ExchangeKeysForEncryption(object lockObject)
		{
			return false;
		}

		internal void DeriveSharedKey(OperationResponse operationResponse)
		{
		}

		internal virtual void InitEncryption(byte[] secret)
		{
		}

		internal void EnqueueActionForDispatch(MyAction action)
		{
		}

		internal void EnqueueDebugReturn(DebugLevel level, string debugReturn)
		{
		}

		internal void EnqueueStatusCallback(StatusCode statusValue)
		{
		}

		internal void SendNetworkSimulated(byte[] dataToSend)
		{
		}

		internal void ReceiveNetworkSimulated(byte[] dataReceived)
		{
		}

		protected internal void NetworkSimRun()
		{
		}
	}
}
