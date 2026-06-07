using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Epic.OnlineServices;
using Epic.OnlineServices.P2P;

namespace EpicTransport
{
	public class Server : Common
	{
		private BidirectionalDictionary<ProductUserId, int> epicToMirrorIds;

		private Dictionary<ProductUserId, SocketId> epicToSocketIds;

		private int maxConnections;

		private int nextConnectionID;

		private event Action<int> OnConnected
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

		private event Action<int, byte[], int> OnReceivedData
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

		private event Action<int> OnDisconnected
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

		private event Action<int, Exception> OnReceivedError
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

		public static Server CreateServer(EosTransport transport, int maxConnections)
		{
			return null;
		}

		private Server(EosTransport transport, int maxConnections)
			: base(null)
		{
		}

		protected override void OnNewConnection(OnIncomingConnectionRequestInfo result)
		{
		}

		protected override void OnReceiveInternalData(InternalMessages type, ProductUserId clientUserId, SocketId socketId)
		{
		}

		protected override void OnReceiveData(byte[] data, ProductUserId clientUserId, int channel)
		{
		}

		public bool Disconnect(int connectionId)
		{
			return false;
		}

		public void Shutdown()
		{
		}

		public void SendAll(int connectionId, byte[] data, int channelId)
		{
		}

		public string ServerGetClientAddress(int connectionId)
		{
			return null;
		}

		protected override void OnConnectionFailed(ProductUserId remoteId)
		{
		}
	}
}
