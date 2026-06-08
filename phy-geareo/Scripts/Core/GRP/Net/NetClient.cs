using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GRP.Net
{
	public class NetClient
	{
		public NetManager manager;

		public NetTransport transport;

		public Dictionary<Type, List<NetClientHandlerDelegate>> handlers;

		public event Action OnConnected
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

		public event Action<TransportError, string> OnError
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

		public event Action<Exception> OnTransportException
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

		public NetClient(NetManager manager)
		{
		}

		public void EarlyUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public void Destroy()
		{
		}

		public void Send<T>(T message, NetChannel channel = NetChannel.Reliable) where T : struct, NetMessage
		{
		}

		public void RegisterHandler<T>(Action<T> handler) where T : struct, NetMessage
		{
		}

		public void UnregisterHandler<T>() where T : struct, NetMessage
		{
		}

		private void HandleOnConnected()
		{
		}

		private void HandleOnDataReceived(ArraySegment<byte> segment, NetChannel channel)
		{
		}

		private void HandleOnError(TransportError error, string message)
		{
		}

		private void HandleOnTransportException(Exception exception)
		{
		}

		private void HandleOnDisconnected()
		{
		}
	}
}
