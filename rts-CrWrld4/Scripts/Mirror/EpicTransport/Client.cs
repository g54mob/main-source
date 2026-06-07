using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Epic.OnlineServices;
using Epic.OnlineServices.P2P;

namespace EpicTransport
{
	public class Client : Common
	{
		public SocketId socketId;

		public ProductUserId serverId;

		private TimeSpan ConnectionTimeout;

		public bool isConnecting;

		public string hostAddress;

		private ProductUserId hostProductId;

		private TaskCompletionSource<Task> connectedComplete;

		private CancellationTokenSource cancelToken;

		public bool Connected { get; private set; }

		public bool Error { get; private set; }

		private event Action<byte[], int> OnReceivedData
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

		private event Action OnConnected
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

		public event Action OnDisconnected
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

		private Client(EosTransport transport)
			: base(null)
		{
		}

		public static Client CreateClient(EosTransport transport, string host)
		{
			return null;
		}

		public void Connect(string host)
		{
		}

		public void Disconnect()
		{
		}

		private void SetConnectedComplete()
		{
		}

		protected override void OnReceiveData(byte[] data, ProductUserId clientUserId, int channel)
		{
		}

		protected override void OnNewConnection(OnIncomingConnectionRequestInfo result)
		{
		}

		protected override void OnReceiveInternalData(InternalMessages type, ProductUserId clientUserId, SocketId socketId)
		{
		}

		public void Send(byte[] data, int channelId)
		{
		}

		protected override void OnConnectionFailed(ProductUserId remoteId)
		{
		}

		public void EosNotInitialized()
		{
		}
	}
}
