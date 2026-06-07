using System.Collections;
using System.Collections.Generic;
using Epic.OnlineServices;
using Epic.OnlineServices.P2P;

namespace EpicTransport
{
	public abstract class Common
	{
		protected enum InternalMessages : byte
		{
			CONNECT = 0,
			ACCEPT_CONNECT = 1,
			DISCONNECT = 2
		}

		protected struct PacketKey
		{
			public ProductUserId productUserId;

			public byte channel;
		}

		private PacketReliability[] channels;

		private OnIncomingConnectionRequestCallback OnIncomingConnectionRequest;

		private ulong incomingNotificationId;

		private OnRemoteConnectionClosedCallback OnRemoteConnectionClosed;

		private ulong outgoingNotificationId;

		protected readonly EosTransport transport;

		protected List<string> deadSockets;

		public bool ignoreAllMessages;

		protected Dictionary<PacketKey, List<List<Packet>>> incomingPackets;

		private int internal_ch => 0;

		protected Common(EosTransport transport)
		{
		}

		protected void Dispose()
		{
		}

		protected abstract void OnNewConnection(OnIncomingConnectionRequestInfo result);

		private void OnConnectFail(OnRemoteConnectionClosedInfo result)
		{
		}

		protected void SendInternal(ProductUserId target, SocketId socketId, InternalMessages type)
		{
		}

		protected void Send(ProductUserId host, SocketId socketId, byte[] msgBuffer, byte channel)
		{
		}

		private bool Receive(out ProductUserId clientProductUserId, out SocketId socketId, out byte[] receiveBuffer, byte channel)
		{
			clientProductUserId = null;
			socketId = null;
			receiveBuffer = null;
			return false;
		}

		protected virtual void CloseP2PSessionWithUser(ProductUserId clientUserID, SocketId socketId)
		{
		}

		protected void WaitForClose(ProductUserId clientUserID, SocketId socketId)
		{
		}

		private IEnumerator DelayedClose(ProductUserId clientUserID, SocketId socketId)
		{
			return null;
		}

		public void ReceiveData()
		{
		}

		protected abstract void OnReceiveInternalData(InternalMessages type, ProductUserId clientUserID, SocketId socketId);

		protected abstract void OnReceiveData(byte[] data, ProductUserId clientUserID, int channel);

		protected abstract void OnConnectionFailed(ProductUserId remoteId);
	}
}
