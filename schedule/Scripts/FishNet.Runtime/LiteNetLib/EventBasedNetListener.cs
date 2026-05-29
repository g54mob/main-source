using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using LiteNetLib.Utils;

namespace LiteNetLib
{
	public class EventBasedNetListener : INetEventListener, IDeliveryEventListener, INtpEventListener, IPeerAddressChangedListener
	{
		public delegate void OnPeerConnected(NetPeer peer);

		public delegate void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo);

		public delegate void OnNetworkError(IPEndPoint endPoint, SocketError socketError);

		public delegate void OnNetworkReceive(NetPeer peer, NetPacketReader reader, byte channel, DeliveryMethod deliveryMethod);

		public delegate void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType);

		public delegate void OnNetworkLatencyUpdate(NetPeer peer, int latency);

		public delegate void OnConnectionRequest(ConnectionRequest request);

		public delegate void OnDeliveryEvent(NetPeer peer, object userData);

		public delegate void OnNtpResponseEvent(NtpPacket packet);

		public delegate void OnPeerAddressChangedEvent(NetPeer peer, IPEndPoint previousAddress);

		public event OnPeerConnected PeerConnectedEvent
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

		public event OnPeerDisconnected PeerDisconnectedEvent
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

		public event OnNetworkError NetworkErrorEvent
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

		public event OnNetworkReceive NetworkReceiveEvent
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

		public event OnNetworkReceiveUnconnected NetworkReceiveUnconnectedEvent
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

		public event OnNetworkLatencyUpdate NetworkLatencyUpdateEvent
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

		public event OnConnectionRequest ConnectionRequestEvent
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

		public event OnDeliveryEvent DeliveryEvent
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

		public event OnNtpResponseEvent NtpResponseEvent
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

		public event OnPeerAddressChangedEvent PeerAddressChangedEvent
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

		public void ClearPeerConnectedEvent()
		{
		}

		public void ClearPeerDisconnectedEvent()
		{
		}

		public void ClearNetworkErrorEvent()
		{
		}

		public void ClearNetworkReceiveEvent()
		{
		}

		public void ClearNetworkReceiveUnconnectedEvent()
		{
		}

		public void ClearNetworkLatencyUpdateEvent()
		{
		}

		public void ClearConnectionRequestEvent()
		{
		}

		public void ClearDeliveryEvent()
		{
		}

		public void ClearNtpResponseEvent()
		{
		}

		public void ClearPeerAddressChangedEvent()
		{
		}

		void INetEventListener.OnPeerConnected(NetPeer peer)
		{
		}

		void INetEventListener.OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
		{
		}

		void INetEventListener.OnNetworkError(IPEndPoint endPoint, SocketError socketErrorCode)
		{
		}

		void INetEventListener.OnNetworkReceive(NetPeer peer, NetPacketReader reader, byte channelNumber, DeliveryMethod deliveryMethod)
		{
		}

		void INetEventListener.OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
		{
		}

		void INetEventListener.OnNetworkLatencyUpdate(NetPeer peer, int latency)
		{
		}

		void INetEventListener.OnConnectionRequest(ConnectionRequest request)
		{
		}

		void IDeliveryEventListener.OnMessageDelivered(NetPeer peer, object userData)
		{
		}

		void INtpEventListener.OnNtpResponse(NtpPacket packet)
		{
		}

		void IPeerAddressChangedListener.OnPeerAddressChanged(NetPeer peer, IPEndPoint previousAddress)
		{
		}
	}
}
