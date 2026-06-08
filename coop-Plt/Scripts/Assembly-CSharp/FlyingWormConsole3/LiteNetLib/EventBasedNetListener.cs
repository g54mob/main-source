using System.Net;
using System.Net.Sockets;
using FlyingWormConsole3.LiteNetLib.Utils;

namespace FlyingWormConsole3.LiteNetLib
{
	public class EventBasedNetListener : INetEventListener, IDeliveryEventListener, INtpEventListener
	{
		public delegate void OnPeerConnected(NetPeer peer);

		public delegate void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo);

		public delegate void OnNetworkError(IPEndPoint endPoint, SocketError socketError);

		public delegate void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod);

		public delegate void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType);

		public delegate void OnNetworkLatencyUpdate(NetPeer peer, int latency);

		public delegate void OnConnectionRequest(ConnectionRequest request);

		public delegate void OnDeliveryEvent(NetPeer peer, object userData);

		public delegate void OnNtpResponseEvent(NtpPacket packet);

		public event OnPeerConnected PeerConnectedEvent;

		public event OnPeerDisconnected PeerDisconnectedEvent;

		public event OnNetworkError NetworkErrorEvent;

		public event OnNetworkReceive NetworkReceiveEvent;

		public event OnNetworkReceiveUnconnected NetworkReceiveUnconnectedEvent;

		public event OnNetworkLatencyUpdate NetworkLatencyUpdateEvent;

		public event OnConnectionRequest ConnectionRequestEvent;

		public event OnDeliveryEvent DeliveryEvent;

		public event OnNtpResponseEvent NtpResponseEvent;

		public void ClearPeerConnectedEvent()
		{
			this.PeerConnectedEvent = null;
		}

		public void ClearPeerDisconnectedEvent()
		{
			this.PeerDisconnectedEvent = null;
		}

		public void ClearNetworkErrorEvent()
		{
			this.NetworkErrorEvent = null;
		}

		public void ClearNetworkReceiveEvent()
		{
			this.NetworkReceiveEvent = null;
		}

		public void ClearNetworkReceiveUnconnectedEvent()
		{
			this.NetworkReceiveUnconnectedEvent = null;
		}

		public void ClearNetworkLatencyUpdateEvent()
		{
			this.NetworkLatencyUpdateEvent = null;
		}

		public void ClearConnectionRequestEvent()
		{
			this.ConnectionRequestEvent = null;
		}

		public void ClearDeliveryEvent()
		{
			this.DeliveryEvent = null;
		}

		public void ClearNtpResponseEvent()
		{
			this.NtpResponseEvent = null;
		}

		void INetEventListener.OnPeerConnected(NetPeer peer)
		{
			if (this.PeerConnectedEvent != null)
			{
				this.PeerConnectedEvent(peer);
			}
		}

		void INetEventListener.OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
		{
			if (this.PeerDisconnectedEvent != null)
			{
				this.PeerDisconnectedEvent(peer, disconnectInfo);
			}
		}

		void INetEventListener.OnNetworkError(IPEndPoint endPoint, SocketError socketErrorCode)
		{
			if (this.NetworkErrorEvent != null)
			{
				this.NetworkErrorEvent(endPoint, socketErrorCode);
			}
		}

		void INetEventListener.OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
		{
			if (this.NetworkReceiveEvent != null)
			{
				this.NetworkReceiveEvent(peer, reader, deliveryMethod);
			}
		}

		void INetEventListener.OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
		{
			if (this.NetworkReceiveUnconnectedEvent != null)
			{
				this.NetworkReceiveUnconnectedEvent(remoteEndPoint, reader, messageType);
			}
		}

		void INetEventListener.OnNetworkLatencyUpdate(NetPeer peer, int latency)
		{
			if (this.NetworkLatencyUpdateEvent != null)
			{
				this.NetworkLatencyUpdateEvent(peer, latency);
			}
		}

		void INetEventListener.OnConnectionRequest(ConnectionRequest request)
		{
			if (this.ConnectionRequestEvent != null)
			{
				this.ConnectionRequestEvent(request);
			}
		}

		void IDeliveryEventListener.OnMessageDelivered(NetPeer peer, object userData)
		{
			if (this.DeliveryEvent != null)
			{
				this.DeliveryEvent(peer, userData);
			}
		}

		void INtpEventListener.OnNtpResponse(NtpPacket packet)
		{
			if (this.NtpResponseEvent != null)
			{
				this.NtpResponseEvent(packet);
			}
		}
	}
}
