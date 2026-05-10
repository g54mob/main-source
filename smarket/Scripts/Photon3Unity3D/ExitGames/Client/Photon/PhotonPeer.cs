using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon.Encryption;

namespace ExitGames.Client.Photon
{
	public class PhotonPeer
	{
		[Obsolete("Check QueuedOutgoingCommands and QueuedIncomingCommands on demand instead.")]
		public int WarningSize;

		[Obsolete("Where dynamic linking is available, this library will attempt to load it and fallback to a managed implementation. This value is always true.")]
		public const bool NativeDatagramEncrypt = true;

		[Obsolete("Use the ITrafficRecorder to capture all traffic instead.")]
		public int CommandLogSize;

		public const bool NoSocket = false;

		public const bool DebugBuild = true;

		public const int NativeEncryptorApiVersion = 2;

		public TargetFrameworks TargetFramework;

		public static bool NoNativeCallbacks;

		public bool RemoveAppIdFromWebSocketPath;

		public byte ClientSdkId;

		private static string clientVersion;

		[Obsolete("A Native Socket implementation is no longer part of this DLL but delivered in a separate add-on. This value always returns false.")]
		public static readonly bool NativeSocketLibAvailable;

		[Obsolete("Native Payload Encryption is no longer part of this DLL but delivered in a separate add-on. This value always returns false.")]
		public static readonly bool NativePayloadEncryptionLibAvailable;

		[Obsolete("Native Datagram Encryption is no longer part of this DLL but delivered in a separate add-on. This value always returns false.")]
		public static readonly bool NativeDatagramEncryptionLibAvailable;

		internal bool UseInitV3;

		public Dictionary<ConnectionProtocol, Type> SocketImplementationConfig;

		public DebugLevel DebugOut;

		private bool reuseEventInstance;

		private bool useByteArraySlicePoolForEvents;

		private bool wrapIncomingStructs;

		public bool SendInCreationOrder;

		public int SendWindowSize;

		public ITrafficRecorder TrafficRecorder;

		private byte quickResendAttempts;

		public byte ChannelCount;

		public bool EnableEncryptedFlag;

		private bool crcEnabled;

		public int SentCountAllowance;

		public int InitialResendTimeMax;

		public int TimePingInterval;

		public bool PingUsedAsInit;

		private int disconnectTimeout;

		public static int OutgoingStreamBufferSize;

		private int mtu;

		public static bool AsyncKeyExchange;

		internal bool RandomizeSequenceNumbers;

		internal byte[] RandomizedSequenceNumbers;

		internal bool GcmDatagramEncryption;

		private Stopwatch trafficStatsStopwatch;

		private bool trafficStatsEnabled;

		internal PeerBase peerBase;

		private readonly object SendOutgoingLockObject;

		private readonly object DispatchLockObject;

		private readonly object EnqueueLock;

		private Type payloadEncryptorType;

		protected internal byte[] PayloadEncryptionSecret;

		private Type encryptorType;

		protected internal IPhotonEncryptor Encryptor;

		[Obsolete("See remarks.")]
		public int CommandBufferSize { get; set; }

		[Obsolete("See remarks.")]
		public int LimitOfUnreliableCommands { get; set; }

		[Obsolete("Returns SupportClass.GetTickCount(). Should be replaced by a StopWatch or the per peer PhotonPeer.ClientTime.")]
		public int LocalTimeInMilliSeconds => 0;

		protected internal byte ClientSdkIdShifted => 0;

		[Obsolete("The static string Version should be preferred.")]
		public string ClientVersion => null;

		public static string Version => null;

		public SerializationProtocol SerializationProtocolType { get; set; }

		public Type SocketImplementation { get; internal set; }

		public int SocketErrorCode => 0;

		public IPhotonPeerListener Listener { get; protected set; }

		public bool ReuseEventInstance
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseByteArraySlicePoolForEvents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool WrapIncomingStructs
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ByteArraySlicePool ByteArraySlicePool => null;

		[Obsolete("Use SendWindowSize instead.")]
		public int SequenceDeltaLimitSends
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public long BytesIn => 0L;

		public long BytesOut => 0L;

		public int ByteCountCurrentDispatch => 0;

		public string CommandInfoCurrentDispatch => null;

		public int ByteCountLastOperation => 0;

		public bool EnableServerTracing { get; set; }

		public byte QuickResendAttempts
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public PeerStateValue PeerState => default(PeerStateValue);

		public string PeerID => null;

		public int QueuedIncomingCommands => 0;

		public int QueuedOutgoingCommands => 0;

		public bool CrcEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int PacketLossByCrc => 0;

		public int PacketLossByChallenge => 0;

		public int SentReliableCommandsCount => 0;

		public int ResentReliableCommands => 0;

		public int DisconnectTimeout
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ServerTimeInMilliSeconds => 0;

		[Obsolete("The PhotonPeer will no longer use this delegate. It uses a Stopwatch in all cases. You can access PhotonPeer.ConnectionTime.")]
		public SupportClass.IntegerMillisecondsDelegate LocalMsTimestampDelegate
		{
			set
			{
			}
		}

		public int ConnectionTime => 0;

		public int LastSendAckTime => 0;

		public int LastSendOutgoingTime => 0;

		public int LongestSentCall
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int RoundTripTime => 0;

		public int RoundTripTimeVariance => 0;

		public int LastRoundTripTime => 0;

		public int TimestampOfLastSocketReceive => 0;

		public string ServerAddress => null;

		public string ServerIpAddress => null;

		public ConnectionProtocol UsedProtocol => default(ConnectionProtocol);

		public ConnectionProtocol TransportProtocol { get; set; }

		public virtual bool IsSimulationEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public NetworkSimulationSet NetworkSimulationSettings => null;

		public int MaximumTransferUnit
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsEncryptionAvailable => false;

		[Obsolete("Internally not used anymore. Call SendAcksOnly() instead.")]
		public bool IsSendingOnlyAcks { get; set; }

		public TrafficStats TrafficStatsIncoming { get; internal set; }

		public TrafficStats TrafficStatsOutgoing { get; internal set; }

		public TrafficStatsGameLevel TrafficStatsGameLevel { get; internal set; }

		public long TrafficStatsElapsedMs => 0L;

		public bool TrafficStatsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Type PayloadEncryptorType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Type EncryptorType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int CountDiscarded { get; set; }

		public int DeltaUnreliableNumber { get; set; }

		public event Action<DisconnectMessage> OnDisconnectMessage
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

		[Obsolete("Use the ITrafficRecorder to capture all traffic instead.")]
		public string CommandLogToString()
		{
			return null;
		}

		public static void MessageBufferPoolTrim(int countOfBuffers)
		{
		}

		public static int MessageBufferPoolSize()
		{
			return 0;
		}

		public void TrafficStatsReset()
		{
		}

		internal void InitializeTrafficStats()
		{
		}

		public string VitalStatsToString(bool all)
		{
			return null;
		}

		public PhotonPeer(ConnectionProtocol protocolType)
		{
		}

		public PhotonPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType)
		{
		}

		public virtual bool Connect(string serverAddress, string appId, object photonToken = null, object customInitData = null)
		{
			return false;
		}

		public virtual bool Connect(string serverAddress, string proxyServerAddress, string appId, object photonToken, object customInitData = null)
		{
			return false;
		}

		private void CreatePeerBase()
		{
		}

		public virtual void Disconnect()
		{
		}

		internal void OnDisconnectMessageCall(DisconnectMessage dm)
		{
		}

		public virtual void StopThread()
		{
		}

		public virtual void FetchServerTimestamp()
		{
		}

		public bool EstablishEncryption()
		{
			return false;
		}

		public bool InitDatagramEncryption(byte[] encryptionSecret, byte[] hmacSecret, bool randomizedSequenceNumbers = false, bool chainingModeGCM = false)
		{
			return false;
		}

		public void InitPayloadEncryption(byte[] secret)
		{
		}

		public virtual void Service()
		{
		}

		public virtual bool SendOutgoingCommands()
		{
			return false;
		}

		public virtual bool SendAcksOnly()
		{
			return false;
		}

		public virtual bool DispatchIncomingCommands()
		{
			return false;
		}

		public virtual bool SendOperation(byte operationCode, Dictionary<byte, object> operationParameters, SendOptions sendOptions)
		{
			return false;
		}

		public virtual bool SendOperation(byte operationCode, ParameterDictionary operationParameters, SendOptions sendOptions)
		{
			return false;
		}

		public static bool RegisterType(Type customType, byte code, SerializeMethod serializeMethod, DeserializeMethod constructor)
		{
			return false;
		}

		public static bool RegisterType(Type customType, byte code, SerializeStreamMethod serializeMethod, DeserializeStreamMethod constructor)
		{
			return false;
		}
	}
}
