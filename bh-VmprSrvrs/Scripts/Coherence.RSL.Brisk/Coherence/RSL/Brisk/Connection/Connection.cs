using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Coherence.Brisk.Models;
using Coherence.Brook;
using Coherence.Brook.Octet;
using Coherence.Common.Pooling;
using Coherence.Connection;
using Coherence.Log;
using Coherence.RSL.Tickers;
using Coherence.RSL.Transport;
using Coherence.SimulationFrame;
using Coherence.Tend.Client;

namespace Coherence.RSL.Brisk.Connection
{
	public class Connection : IUserConnection, IConnectionAckHandler, IConnectionReceiver, IDisposable
	{
		public enum Error
		{
			None = 0,
			DisconnectRequest = 1,
			OutOfSequence = 2,
			MissingSequence = 3
		}

		public enum State
		{
			Unknown = 0,
			Disconnected = 1,
			Connecting = 2,
			Connected = 3
		}

		public enum ShutdownMode
		{
			Unknown = 0,
			LeaveTransport = 1,
			CloseTransport = 2,
			CloseTransportWithMessage = 3
		}

		public enum TickResult
		{
			Normal = 0,
			Upgraded = 1,
			Closed = 2
		}

		private const int defaultClientSendFrequency = 60;

		private State state;

		private ConnectInfo? connectionInfo;

		private ClientID connectionClientID;

		private ConnectionType connectionType;

		private bool wasShutdown;

		private ITransportConnection transport;

		private OOBAckQueue oobAckQueue;

		private Queue<SequenceId> clientAckQueue;

		private Coherence.Tend.Client.Tend tend;

		private IOobMessage connectionMessage;

		private TimeSpan disconnectTimeout;

		private OutStreamPool streamPool;

		private DateTime lastPacketReceivedTime;

		private ConcurrentQueue<IInOctetStream> receivedPackets;

		private ITickProvider ticker;

		private Buffer<byte> lastSentReliablePacket;

		private SequenceId lastSentReliableSequenceID;

		private Logger logger;

		public Action<IInOctetStream> RecvChannel { get; set; }

		public Action<DeliveryInfo> AckChannel { get; set; }

		public uint Participant => 0u;

		public bool UseDebugStream => false;

		public ConnectionID ID => default(ConnectionID);

		public ClientID ClientID => default(ClientID);

		public ConnectionType ConnectionType => default(ConnectionType);

		public ConnectInfo? ConnectionInfo => null;

		public bool IsReliable => false;

		public ITransportConnection TransportConnection => null;

		public ConnectionCloseReason CloseReason { get; private set; }

		public State ConnectionState => default(State);

		internal Connection(ITransportConnection connection, string connectionName, ConnectionType connectionType, TimeSpan disconnectTimeout, int sendFrequency, ITickProviderFactory tickProviderFactory, OutStreamPool streamPool, Logger logger)
		{
		}

		public void Dispose()
		{
		}

		public ConnectionType Type()
		{
			return default(ConnectionType);
		}

		public OutPacket CreatePacket(bool reliable)
		{
			return default(OutPacket);
		}

		private OutPacket CreatePacket(bool reliable, bool isOob)
		{
			return default(OutPacket);
		}

		private OutOctetStream CreatePacketFromData(ReadOnlySpan<byte> data)
		{
			return null;
		}

		private void ResendOOBPacket(IOutOctetStream stream)
		{
		}

		public bool CanSend()
		{
			return false;
		}

		public bool IsConnected()
		{
			return false;
		}

		public bool IsDisconnected()
		{
			return false;
		}

		public void Accept(ClientID clientID, AbsoluteSimulationFrame simFrame)
		{
		}

		public void ProcessConnectingStates()
		{
		}

		public void Close(ConnectionCloseReason reason)
		{
		}

		public TickResult Tick()
		{
			return default(TickResult);
		}

		public void UpgradeType(ConnectionType newType)
		{
		}

		public void UpgradeInfo(ConnectInfo newInfo)
		{
		}

		public void SetDisconnectTimeout(TimeSpan disconnectTimeout)
		{
		}

		private void SendOOBMessage(IOobMessage message)
		{
		}

		private OutPacket CreateOOBMessage(IOobMessage message)
		{
			return default(OutPacket);
		}

		public void Send(OutPacket outPacket)
		{
		}

		private void SetLastSentReliablePacket(ReadOnlySpan<byte> packetData, SequenceId sequenceID)
		{
		}

		private void TransportSend(IOutOctetStream outStream, SequenceId sequenceId, bool isReliable)
		{
		}

		private void WriteHeader(IOutOctetStream stream, bool isOob)
		{
		}

		private void Shutdown(ConnectionCloseReason reason, ShutdownMode mode, bool clientInitiated)
		{
		}

		private void ShutdownWithMessage(ConnectionCloseReason reason)
		{
		}

		public void HandleReceivedData(IInOctetStream data)
		{
		}

		private ConnectionCloseReason ProcessPacket(IInOctetStream inData)
		{
			return default(ConnectionCloseReason);
		}

		private void UpdateStateForConnectResponseAck()
		{
		}

		private Error ProcessOOBPacket(IInOctetStream stream)
		{
			return default(Error);
		}

		private void HandleAck(DeliveryInfo ack)
		{
		}

		private Error VerifySequenceID(DeliveryInfo ack)
		{
			return default(Error);
		}

		private ConnectInfo ValidateConnectInfo(ConnectInfo connectionInfo)
		{
			return default(ConnectInfo);
		}

		private void OnOOBConnectRequest(ConnectRequest message)
		{
		}

		private void ConnectionSuccess()
		{
		}

		private void OnOOBDisconnectRequest(DisconnectRequest request)
		{
		}

		private void HandleError(ConnectionException ex)
		{
		}
	}
}
