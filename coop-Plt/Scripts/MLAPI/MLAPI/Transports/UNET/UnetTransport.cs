using System;
using System.Collections.Generic;
using System.Net.Sockets;
using MLAPI.Logging;
using MLAPI.Transports.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace MLAPI.Transports.UNET
{
	public class UnetTransport : Transport
	{
		public int MessageBufferSize = 5120;

		public int MaxConnections = 100;

		public string ConnectAddress = "127.0.0.1";

		public int ConnectPort = 7777;

		public int ServerListenPort = 7777;

		public int ServerWebsocketListenPort = 8887;

		public bool SupportWebsocket;

		public List<UnetChannel> Channels = new List<UnetChannel>();

		public bool UseMLAPIRelay;

		public string MLAPIRelayAddress = "184.72.104.138";

		public int MLAPIRelayPort = 8888;

		private byte[] messageBuffer;

		private WeakReference temporaryBufferReference;

		private readonly Dictionary<string, int> channelNameToId = new Dictionary<string, int>();

		private readonly Dictionary<int, string> channelIdToName = new Dictionary<int, string>();

		private int serverConnectionId;

		private int serverHostId;

		private SocketTask connectTask;

		public override ulong ServerClientId => GetMLAPIClientId(0, 0, isServer: true);

		public override void Send(ulong clientId, ArraySegment<byte> data, string channelName)
		{
			GetUnetConnectionDetails(clientId, out var hostId, out var connectionId);
			int num = 0;
			num = ((!channelNameToId.ContainsKey(channelName)) ? channelNameToId["MLAPI_INTERNAL"] : channelNameToId[channelName]);
			byte[] array;
			if (data.Offset > 0)
			{
				if (messageBuffer.Length >= data.Count)
				{
					array = messageBuffer;
				}
				else
				{
					object obj = null;
					if (temporaryBufferReference != null && (obj = temporaryBufferReference.Target) != null && ((byte[])obj).Length >= data.Count)
					{
						array = (byte[])obj;
					}
					else
					{
						array = new byte[data.Count];
						temporaryBufferReference = new WeakReference(array);
					}
				}
				Buffer.BlockCopy(data.Array, data.Offset, array, 0, data.Count);
			}
			else
			{
				array = data.Array;
			}
			RelayTransport.Send(hostId, connectionId, num, array, data.Count, out var _);
		}

		public override NetEventType PollEvent(out ulong clientId, out string channelName, out ArraySegment<byte> payload, out float receiveTime)
		{
			int hostId;
			int connectionId;
			int channelId;
			int receivedSize;
			byte error;
			NetworkEventType networkEventType = RelayTransport.Receive(out hostId, out connectionId, out channelId, messageBuffer, messageBuffer.Length, out receivedSize, out error);
			clientId = GetMLAPIClientId((byte)hostId, (ushort)connectionId, isServer: false);
			receiveTime = Time.realtimeSinceStartup;
			NetworkError networkError = (NetworkError)error;
			if (networkError == NetworkError.MessageToLong)
			{
				byte[] array;
				if (temporaryBufferReference != null && temporaryBufferReference.IsAlive && ((byte[])temporaryBufferReference.Target).Length >= receivedSize)
				{
					array = (byte[])temporaryBufferReference.Target;
				}
				else
				{
					array = new byte[receivedSize];
					temporaryBufferReference = new WeakReference(array);
				}
				networkEventType = RelayTransport.Receive(out hostId, out connectionId, out channelId, array, array.Length, out receivedSize, out error);
				payload = new ArraySegment<byte>(array, 0, receivedSize);
			}
			else
			{
				payload = new ArraySegment<byte>(messageBuffer, 0, receivedSize);
			}
			if (channelIdToName.ContainsKey(channelId))
			{
				channelName = channelIdToName[channelId];
			}
			else
			{
				channelName = "MLAPI_INTERNAL";
			}
			if (connectTask != null && hostId == serverHostId && connectionId == serverConnectionId)
			{
				switch (networkEventType)
				{
				case NetworkEventType.ConnectEvent:
					connectTask.Message = null;
					connectTask.SocketError = ((networkError != NetworkError.Ok) ? SocketError.SocketError : SocketError.Success);
					connectTask.State = null;
					connectTask.Success = networkError == NetworkError.Ok;
					connectTask.TransportCode = (byte)networkError;
					connectTask.TransportException = null;
					connectTask.IsDone = true;
					connectTask = null;
					break;
				case NetworkEventType.DisconnectEvent:
					connectTask.Message = null;
					connectTask.SocketError = SocketError.SocketError;
					connectTask.State = null;
					connectTask.Success = false;
					connectTask.TransportCode = (byte)networkError;
					connectTask.TransportException = null;
					connectTask.IsDone = true;
					connectTask = null;
					break;
				}
			}
			if (networkError == NetworkError.Timeout)
			{
				networkEventType = NetworkEventType.DisconnectEvent;
			}
			return networkEventType switch
			{
				NetworkEventType.DataEvent => NetEventType.Data, 
				NetworkEventType.ConnectEvent => NetEventType.Connect, 
				NetworkEventType.DisconnectEvent => NetEventType.Disconnect, 
				NetworkEventType.Nothing => NetEventType.Nothing, 
				NetworkEventType.BroadcastEvent => NetEventType.Nothing, 
				_ => NetEventType.Nothing, 
			};
		}

		public override SocketTasks StartClient()
		{
			SocketTask working = SocketTask.Working;
			serverHostId = RelayTransport.AddHost(new HostTopology(GetConfig(), 1), createServer: false);
			serverConnectionId = RelayTransport.Connect(serverHostId, ConnectAddress, ConnectPort, 0, out var error);
			if (error == 0)
			{
				working.Success = true;
				working.TransportCode = error;
				working.SocketError = SocketError.Success;
				working.IsDone = false;
				connectTask = working;
			}
			else
			{
				working.Success = false;
				working.TransportCode = error;
				working.SocketError = SocketError.SocketError;
				working.IsDone = true;
			}
			return working.AsTasks();
		}

		public override SocketTasks StartServer()
		{
			HostTopology topology = new HostTopology(GetConfig(), MaxConnections);
			if (SupportWebsocket)
			{
				if (!UseMLAPIRelay)
				{
					int num = NetworkTransport.AddWebsocketHost(topology, ServerWebsocketListenPort);
				}
				else if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("Cannot create websocket host when using MLAPI relay");
				}
			}
			int num2 = RelayTransport.AddHost(topology, ServerListenPort, createServer: true);
			return SocketTask.Done.AsTasks();
		}

		public override void DisconnectRemoteClient(ulong clientId)
		{
			GetUnetConnectionDetails(clientId, out var hostId, out var connectionId);
			RelayTransport.Disconnect(hostId, connectionId, out var _);
		}

		public override void DisconnectLocalClient()
		{
			RelayTransport.Disconnect(serverHostId, serverConnectionId, out var _);
		}

		public override ulong GetCurrentRtt(ulong clientId)
		{
			GetUnetConnectionDetails(clientId, out var hostId, out var connectionId);
			if (UseMLAPIRelay)
			{
				return 0uL;
			}
			byte error;
			return (ulong)NetworkTransport.GetCurrentRTT(hostId, connectionId, out error);
		}

		public override void Shutdown()
		{
			channelIdToName.Clear();
			channelNameToId.Clear();
			NetworkTransport.Shutdown();
		}

		public override void Init()
		{
			UpdateRelay();
			messageBuffer = new byte[MessageBufferSize];
			NetworkTransport.Init();
		}

		public ulong GetMLAPIClientId(byte hostId, ushort connectionId, bool isServer)
		{
			if (isServer)
			{
				return 0uL;
			}
			return (connectionId | ((ulong)hostId << 16)) + 1;
		}

		public void GetUnetConnectionDetails(ulong clientId, out byte hostId, out ushort connectionId)
		{
			if (clientId == 0L)
			{
				hostId = (byte)serverHostId;
				connectionId = (ushort)serverConnectionId;
			}
			else
			{
				hostId = (byte)(clientId - 1 >> 16);
				connectionId = (ushort)(clientId - 1);
			}
		}

		public ConnectionConfig GetConfig()
		{
			ConnectionConfig connectionConfig = new ConnectionConfig();
			for (int i = 0; i < base.MLAPI_CHANNELS.Length; i++)
			{
				int num = AddMLAPIChannel(base.MLAPI_CHANNELS[i].Type, connectionConfig);
				channelIdToName.Add(num, base.MLAPI_CHANNELS[i].Name);
				channelNameToId.Add(base.MLAPI_CHANNELS[i].Name, num);
			}
			for (int j = 0; j < Channels.Count; j++)
			{
				int num2 = AddUNETChannel(Channels[j].Type, connectionConfig);
				channelIdToName.Add(num2, Channels[j].Name);
				channelNameToId.Add(Channels[j].Name, num2);
			}
			return connectionConfig;
		}

		public int AddMLAPIChannel(ChannelType type, ConnectionConfig config)
		{
			return type switch
			{
				ChannelType.Unreliable => config.AddChannel(QosType.Unreliable), 
				ChannelType.Reliable => config.AddChannel(QosType.Reliable), 
				ChannelType.ReliableSequenced => config.AddChannel(QosType.ReliableSequenced), 
				ChannelType.ReliableFragmentedSequenced => config.AddChannel(QosType.ReliableFragmentedSequenced), 
				ChannelType.UnreliableSequenced => config.AddChannel(QosType.UnreliableSequenced), 
				_ => 0, 
			};
		}

		public int AddUNETChannel(QosType type, ConnectionConfig config)
		{
			return type switch
			{
				QosType.Unreliable => config.AddChannel(QosType.Unreliable), 
				QosType.UnreliableFragmented => config.AddChannel(QosType.UnreliableFragmented), 
				QosType.UnreliableSequenced => config.AddChannel(QosType.UnreliableSequenced), 
				QosType.Reliable => config.AddChannel(QosType.Reliable), 
				QosType.ReliableFragmented => config.AddChannel(QosType.ReliableFragmented), 
				QosType.ReliableSequenced => config.AddChannel(QosType.ReliableSequenced), 
				QosType.StateUpdate => config.AddChannel(QosType.StateUpdate), 
				QosType.ReliableStateUpdate => config.AddChannel(QosType.ReliableStateUpdate), 
				QosType.AllCostDelivery => config.AddChannel(QosType.AllCostDelivery), 
				QosType.UnreliableFragmentedSequenced => config.AddChannel(QosType.UnreliableFragmentedSequenced), 
				QosType.ReliableFragmentedSequenced => config.AddChannel(QosType.ReliableFragmentedSequenced), 
				_ => 0, 
			};
		}

		private void UpdateRelay()
		{
			RelayTransport.Enabled = UseMLAPIRelay;
			RelayTransport.RelayAddress = MLAPIRelayAddress;
			RelayTransport.RelayPort = (ushort)MLAPIRelayPort;
		}
	}
}
