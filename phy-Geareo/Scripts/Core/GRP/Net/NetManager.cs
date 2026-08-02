using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;

namespace GRP.Net
{
	public class NetManager
	{
		public NetTransport transport;

		public NetServer server;

		public NetClient client;

		public State<bool> connecting;

		public State<bool> serverActive;

		public State<bool> clientActive;

		public State<bool> connected;

		public StateSelector<bool> isHost;

		public StateSelector<bool> isClient;

		public Action<NetServer> OnServer;

		public Action<NetClient> OnClient;

		public Action<string> OnError;

		private ushort messageId;

		private Dictionary<ushort, Type> messageTypeById;

		private Dictionary<Type, ushort> messageIdByType;

		private bool disconnectingClient;

		public NetManager(NetManagerOptions options)
		{
		}

		public void RegisterMessage<T>() where T : struct, NetMessage
		{
		}

		public void RegisterMessage(Type messageType)
		{
		}

		public void RegisterMessageEmpty()
		{
		}

		public void EarlyUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public NetServer StartServer(ushort port)
		{
			return null;
		}

		public void StopServer()
		{
		}

		public NetClient StartClient(string address, ushort port)
		{
			return null;
		}

		public void StopClient()
		{
		}

		public void StartHost(ushort port)
		{
		}

		public void StopHost()
		{
		}

		public void BuildServer(Action<NetServer> action)
		{
		}

		public void UnbuildServer(Action<NetServer> action)
		{
		}

		public void BuildClient(Action<NetClient> action)
		{
		}

		public void UnbuildClient(Action<NetClient> action)
		{
		}

		public ArraySegment<byte> SerializeMessage<T>(T message) where T : NetMessage
		{
			return default(ArraySegment<byte>);
		}

		public NetMessage DeserializeMessage(ArraySegment<byte> bytes)
		{
			return null;
		}
	}
}
