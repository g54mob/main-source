using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence.Brisk.Models;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Common.Pooling;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Tend.Client;
using Coherence.Transport;

namespace Coherence.Brisk
{
	public class Brisk : IConnection, IOutConnection
	{
		private class KeepAliveTimer
		{
			private static readonly TimeSpan keepAlivePeriod;

			private Timer timer;

			private readonly Brisk brisk;

			public KeepAliveTimer(Brisk brisk)
			{
			}

			public void StartKeepAlive()
			{
			}

			public void StopKeepAlive()
			{
			}
		}

		public const ushort DefaultMTU = 1280;

		public const ushort MinMTU = 256;

		public const ushort MaxMTU = 32767;

		private const byte defaultSendFrequency = 20;

		private static readonly TimeSpan roundTripTimeThreshold;

		private ConnectResponse connectResponse;

		private readonly IStopwatch connectionTimer;

		private readonly Logger logger;

		private KeepAliveTimer keepAliveTimer;

		private TimeSpan nextSend;

		private readonly IStopwatch sendTimer;

		private OutPacket lastSentReliablePacket;

		private Dictionary<SequenceId, DateTime> pingSequence;

		private SendRateCounter sendRateCounter;

		private LatencyCollection latencies;

		private Coherence.Tend.Client.Tend tend;

		private ITransport transport;

		private Func<Logger, ITransport> transportFactory;

		private EndpointData endpoint;

		private ConnectionType connectionType;

		private bool clientAsSimulator;

		private readonly List<(IInOctetStream, IPEndPoint)> incomingBuffer;

		private readonly OobAckQueue oobAckQueue;

		private readonly Pool<PooledOutOctetStream> oobStreamPool;

		private Pool<PooledOutOctetStream> streamPool;

		private BriskServices briskServices;

		public bool CanSend => false;

		public Ping Ping => default(Ping);

		public ClientID ClientID { get; private set; }

		public ushort ConnectionMTU => 0;

		public byte SendFrequency { get; private set; }

		public bool UseDebugStreams => false;

		public ConnectionState State { get; private set; }

		public ConnectionSettings Settings { get; private set; }

		public uint InitialScene { get; set; }

		public string TransportDescription => null;

		public event Action<ConnectResponse> OnConnect
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

		public event Action<ConnectionCloseReason> OnDisconnect
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

		public event Action<ConnectionException> OnError
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

		public Brisk(Logger logger, BriskServices services = null)
		{
		}

		public void Connect(EndpointData endpoint, ConnectionType connectionType, bool clientAsSimulator = false, ConnectionSettings connectionSettings = null)
		{
		}

		public void Disconnect(ConnectionCloseReason connectionCloseReason, bool serverInitiated)
		{
		}

		public void Update()
		{
		}

		public void Send(OutPacket packet)
		{
		}

		public void Receive(List<InPacket> buffer)
		{
		}

		public OutPacket CreatePacket(bool reliable)
		{
			return default(OutPacket);
		}

		private void InitializeAndBeginHandshake()
		{
		}

		private void CleanUp()
		{
		}

		private void UpdateNextSendTime(bool restartTimer = true)
		{
		}

		private bool IsReadyToSendNextPacket()
		{
			return false;
		}

		private void TransportSend(OutPacket packet, bool isReliable, bool isMainThread = true)
		{
		}

		private void SetLastSentReliablePacket(in OutPacket packet)
		{
		}

		private OutPacket CreatePacket(bool reliable, bool isOob)
		{
			return default(OutPacket);
		}

		private (InPacket, bool) ProcessReceivedPacket(IInOctetStream stream, IPEndPoint from)
		{
			return default((InPacket, bool));
		}

		private void ProcessOobMessage(IOobMessage oobMessage)
		{
		}

		private void SendConnectRequest(bool isInitialRequest = false)
		{
		}

		private void OnConnectResponse(ConnectResponse response)
		{
		}

		private void ConnectionSuccess()
		{
		}

		private void SendOOBMessage(IOobMessage oobMessage, bool isMainThread = true)
		{
		}

		private void WriteHeader(IOutOctetStream stream, bool isOob)
		{
		}

		private void SendAckPacket()
		{
		}

		private void HandleError(ConnectionException exception)
		{
		}

		private void HandleDeliveryInfo(DeliveryInfo info)
		{
		}

		private void UpdatePingForSequenceId(SequenceId sequenceId)
		{
		}

		private void StartKeepAlive()
		{
		}

		private void StopKeepAlive()
		{
		}

		[Conditional("DEBUG")]
		private void AssertTransportNotClosed(bool isMainThread = true, [CallerMemberName] string caller = null)
		{
		}

		private static bool IsTraceLog(OobMessageType messageType)
		{
			return false;
		}
	}
}
