using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;

namespace MLAPI.Transports.UNET
{
	public static class RelayTransport
	{
		private enum MessageType
		{
			StartServer = 0,
			ConnectToServer = 1,
			Data = 2,
			ClientDisconnect = 3,
			AddressReport = 4
		}

		private static byte defaultChannelId;

		private static int relayConnectionId;

		private static bool isClient = false;

		private static string address;

		private static ushort port;

		private static List<ChannelQOS> channels = new List<ChannelQOS>();

		private static readonly byte[] disconnectBuffer = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 3 };

		public static bool Enabled { get; set; } = true;

		public static string RelayAddress { get; set; } = "127.0.0.1";

		public static ushort RelayPort { get; set; } = 8888;

		public static event Action<IPEndPoint> OnRemoteEndpointReported;

		public static int Connect(int hostId, string serverAddress, int serverPort, int exceptionConnectionId, out byte error)
		{
			if (!Enabled)
			{
				return NetworkTransport.Connect(hostId, serverAddress, serverPort, exceptionConnectionId, out error);
			}
			isClient = true;
			address = serverAddress;
			port = (ushort)serverPort;
			relayConnectionId = NetworkTransport.Connect(hostId, RelayAddress, RelayPort, exceptionConnectionId, out error);
			return relayConnectionId;
		}

		public static int ConnectWithSimulator(int hostId, string serverAddress, int serverPort, int exceptionConnectionId, out byte error, ConnectionSimulatorConfig conf)
		{
			if (!Enabled)
			{
				return NetworkTransport.ConnectWithSimulator(hostId, serverAddress, serverPort, exceptionConnectionId, out error, conf);
			}
			isClient = true;
			address = serverAddress;
			port = (ushort)serverPort;
			relayConnectionId = NetworkTransport.ConnectWithSimulator(hostId, RelayAddress, RelayPort, exceptionConnectionId, out error, conf);
			return relayConnectionId;
		}

		public static int ConnectEndPoint(int hostId, EndPoint endPoint, int exceptionConnectionId, out byte error)
		{
			if (!Enabled)
			{
				return NetworkTransport.ConnectEndPoint(hostId, endPoint, exceptionConnectionId, out error);
			}
			isClient = true;
			address = ((IPEndPoint)endPoint).Address.ToString();
			port = (ushort)((IPEndPoint)endPoint).Port;
			relayConnectionId = NetworkTransport.Connect(hostId, RelayAddress, RelayPort, exceptionConnectionId, out error);
			return relayConnectionId;
		}

		private static void SetChannelsFromTopology(HostTopology topology)
		{
			channels = topology.DefaultConfig.Channels;
		}

		public static int AddHost(HostTopology topology, bool createServer)
		{
			if (!Enabled)
			{
				return NetworkTransport.AddHost(topology, 0, null);
			}
			isClient = !createServer;
			defaultChannelId = topology.DefaultConfig.AddChannel(QosType.ReliableSequenced);
			SetChannelsFromTopology(topology);
			int num = NetworkTransport.AddHost(topology, 0, null);
			if (createServer)
			{
				relayConnectionId = NetworkTransport.Connect(num, RelayAddress, RelayPort, 0, out var _);
			}
			return num;
		}

		public static int AddHost(HostTopology topology, int port, bool createServer)
		{
			if (!Enabled)
			{
				return NetworkTransport.AddHost(topology, port);
			}
			isClient = !createServer;
			defaultChannelId = topology.DefaultConfig.AddChannel(QosType.ReliableSequenced);
			SetChannelsFromTopology(topology);
			int num = NetworkTransport.AddHost(topology, port);
			if (createServer)
			{
				relayConnectionId = NetworkTransport.Connect(num, RelayAddress, RelayPort, 0, out var _);
			}
			return num;
		}

		public static int AddHost(HostTopology topology, int port, string ip, bool createServer)
		{
			if (!Enabled)
			{
				return NetworkTransport.AddHost(topology, port, ip);
			}
			isClient = !createServer;
			defaultChannelId = topology.DefaultConfig.AddChannel(QosType.ReliableSequenced);
			SetChannelsFromTopology(topology);
			int num = NetworkTransport.AddHost(topology, port, ip);
			if (createServer)
			{
				relayConnectionId = NetworkTransport.Connect(num, RelayAddress, RelayPort, 0, out var _);
			}
			return num;
		}

		public static int AddHostWithSimulator(HostTopology topology, int minTimeout, int maxTimeout, int port, string ip, bool createServer)
		{
			if (!Enabled)
			{
				return NetworkTransport.AddHostWithSimulator(topology, minTimeout, maxTimeout);
			}
			isClient = !createServer;
			defaultChannelId = topology.DefaultConfig.AddChannel(QosType.ReliableSequenced);
			SetChannelsFromTopology(topology);
			int num = NetworkTransport.AddHostWithSimulator(topology, minTimeout, maxTimeout, port, ip);
			if (createServer)
			{
				relayConnectionId = NetworkTransport.Connect(num, RelayAddress, RelayPort, 0, out var _);
			}
			return num;
		}

		public static int AddHostWithSimulator(HostTopology topology, int minTimeout, int maxTimeout, bool createServer)
		{
			if (!Enabled)
			{
				return NetworkTransport.AddHostWithSimulator(topology, minTimeout, maxTimeout);
			}
			isClient = !createServer;
			defaultChannelId = topology.DefaultConfig.AddChannel(QosType.ReliableSequenced);
			SetChannelsFromTopology(topology);
			int num = NetworkTransport.AddHostWithSimulator(topology, minTimeout, maxTimeout);
			if (createServer)
			{
				relayConnectionId = NetworkTransport.Connect(num, RelayAddress, RelayPort, 0, out var _);
			}
			return num;
		}

		public static int AddHostWithSimulator(HostTopology topology, int minTimeout, int maxTimeout, int port, bool createServer)
		{
			if (!Enabled)
			{
				return NetworkTransport.AddHostWithSimulator(topology, minTimeout, maxTimeout, port);
			}
			isClient = !createServer;
			SetChannelsFromTopology(topology);
			int num = NetworkTransport.AddHostWithSimulator(topology, minTimeout, maxTimeout, port);
			if (createServer)
			{
				relayConnectionId = NetworkTransport.Connect(num, RelayAddress, RelayPort, 0, out var _);
			}
			return num;
		}

		public static int AddWebsocketHost(HostTopology topology, int port, bool createServer)
		{
			if (!Enabled)
			{
				return NetworkTransport.AddWebsocketHost(topology, port);
			}
			isClient = !createServer;
			defaultChannelId = topology.DefaultConfig.AddChannel(QosType.ReliableSequenced);
			SetChannelsFromTopology(topology);
			int num = NetworkTransport.AddWebsocketHost(topology, port);
			if (createServer)
			{
				relayConnectionId = NetworkTransport.Connect(num, RelayAddress, RelayPort, 0, out var _);
			}
			return num;
		}

		public static int AddWebsocketHost(HostTopology topology, int port, string ip, bool createServer)
		{
			if (!Enabled)
			{
				return NetworkTransport.AddWebsocketHost(topology, port, ip);
			}
			isClient = !createServer;
			defaultChannelId = topology.DefaultConfig.AddChannel(QosType.ReliableSequenced);
			SetChannelsFromTopology(topology);
			int num = NetworkTransport.AddWebsocketHost(topology, port, ip);
			if (createServer)
			{
				relayConnectionId = NetworkTransport.Connect(num, RelayAddress, RelayPort, 0, out var _);
			}
			return num;
		}

		public static bool Disconnect(int hostId, int connectionId, out byte error)
		{
			if (!Enabled)
			{
				return NetworkTransport.Disconnect(hostId, connectionId, out error);
			}
			if (!isClient)
			{
				for (byte b = 0; b < 8; b++)
				{
					disconnectBuffer[b] = (byte)((ulong)connectionId >> b * 8);
				}
				return NetworkTransport.Send(hostId, relayConnectionId, defaultChannelId, disconnectBuffer, 9, out error);
			}
			return NetworkTransport.Disconnect(hostId, connectionId, out error);
		}

		public static bool Send(int hostId, int connectionId, int channelId, byte[] buffer, int size, out byte error)
		{
			if (!Enabled)
			{
				return NetworkTransport.Send(hostId, connectionId, channelId, buffer, size, out error);
			}
			size++;
			if (!isClient)
			{
				size += 8;
				int num = size - 9;
				for (byte b = 0; b < 8; b++)
				{
					buffer[num + b] = (byte)((ulong)connectionId >> b * 8);
				}
			}
			buffer[size - 1] = 2;
			return NetworkTransport.Send(hostId, relayConnectionId, channelId, buffer, size, out error);
		}

		public static bool QueueMessageForSending(int hostId, int connectionId, int channelId, byte[] buffer, int size, out byte error)
		{
			if (!Enabled)
			{
				return NetworkTransport.QueueMessageForSending(hostId, connectionId, channelId, buffer, size, out error);
			}
			size++;
			if (!isClient)
			{
				size += 8;
				int num = size - 9;
				for (byte b = 0; b < 8; b++)
				{
					buffer[num + b] = (byte)((ulong)connectionId >> b * 8);
				}
			}
			buffer[size - 1] = 2;
			return NetworkTransport.QueueMessageForSending(hostId, relayConnectionId, channelId, buffer, size, out error);
		}

		public static bool SendQueuedMessages(int hostId, int connectionId, out byte error)
		{
			if (!Enabled)
			{
				return NetworkTransport.SendQueuedMessages(hostId, connectionId, out error);
			}
			return NetworkTransport.SendQueuedMessages(hostId, relayConnectionId, out error);
		}

		public static NetworkEventType ReceiveFromHost(int hostId, out int connectionId, out int channelId, byte[] buffer, int bufferSize, out int receivedSize, out byte error)
		{
			if (!Enabled)
			{
				return NetworkTransport.ReceiveFromHost(hostId, out connectionId, out channelId, buffer, bufferSize, out receivedSize, out error);
			}
			NetworkEventType networkEventType = NetworkTransport.ReceiveFromHost(hostId, out connectionId, out channelId, buffer, bufferSize, out receivedSize, out error);
			return BaseReceive(networkEventType, hostId, ref connectionId, ref channelId, buffer, bufferSize, ref receivedSize, ref error);
		}

		public static NetworkEventType Receive(out int hostId, out int connectionId, out int channelId, byte[] buffer, int bufferSize, out int receivedSize, out byte error)
		{
			if (!Enabled)
			{
				return NetworkTransport.Receive(out hostId, out connectionId, out channelId, buffer, bufferSize, out receivedSize, out error);
			}
			NetworkEventType networkEventType = NetworkTransport.Receive(out hostId, out connectionId, out channelId, buffer, bufferSize, out receivedSize, out error);
			return BaseReceive(networkEventType, hostId, ref connectionId, ref channelId, buffer, bufferSize, ref receivedSize, ref error);
		}

		private static NetworkEventType BaseReceive(NetworkEventType @event, int hostId, ref int connectionId, ref int channelId, byte[] buffer, int bufferSize, ref int receivedSize, ref byte error)
		{
			switch (@event)
			{
			case NetworkEventType.DataEvent:
				switch ((MessageType)buffer[receivedSize - 1])
				{
				case MessageType.AddressReport:
				{
					byte[] array = new byte[16];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = buffer[i];
					}
					ushort num4 = (ushort)(buffer[16] | (buffer[17] << 8));
					IPEndPoint obj = new IPEndPoint(new IPAddress(array), num4);
					if (RelayTransport.OnRemoteEndpointReported != null)
					{
						RelayTransport.OnRemoteEndpointReported(obj);
					}
					break;
				}
				case MessageType.ConnectToServer:
					if (!isClient)
					{
						ulong num3 = buffer[receivedSize - 9] | ((ulong)buffer[receivedSize - 8] << 8) | ((ulong)buffer[receivedSize - 7] << 16) | ((ulong)buffer[receivedSize - 6] << 24) | ((ulong)buffer[receivedSize - 5] << 32) | ((ulong)buffer[receivedSize - 4] << 40) | ((ulong)buffer[receivedSize - 3] << 48) | ((ulong)buffer[receivedSize - 2] << 56);
						connectionId = (int)num3;
					}
					return NetworkEventType.ConnectEvent;
				case MessageType.Data:
					if (isClient)
					{
						receivedSize--;
					}
					else
					{
						receivedSize -= 9;
						ulong num2 = buffer[receivedSize] | ((ulong)buffer[receivedSize + 1] << 8) | ((ulong)buffer[receivedSize + 2] << 16) | ((ulong)buffer[receivedSize + 3] << 24) | ((ulong)buffer[receivedSize + 4] << 32) | ((ulong)buffer[receivedSize + 5] << 40) | ((ulong)buffer[receivedSize + 6] << 48) | ((ulong)buffer[receivedSize + 7] << 56);
						connectionId = (int)num2;
					}
					return NetworkEventType.DataEvent;
				case MessageType.ClientDisconnect:
				{
					ulong num = buffer[0] | ((ulong)buffer[1] << 8) | ((ulong)buffer[2] << 16) | ((ulong)buffer[3] << 24) | ((ulong)buffer[4] << 32) | ((ulong)buffer[5] << 40) | ((ulong)buffer[6] << 48) | ((ulong)buffer[7] << 56);
					connectionId = (int)num;
					return NetworkEventType.DisconnectEvent;
				}
				}
				break;
			case NetworkEventType.ConnectEvent:
				if (isClient)
				{
					IPAddress iPAddress = IPAddress.Parse(address);
					byte[] array2;
					if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
					{
						array2 = iPAddress.GetAddressBytes();
					}
					else if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
					{
						byte[] addressBytes = iPAddress.GetAddressBytes();
						array2 = new byte[16]
						{
							0,
							0,
							0,
							0,
							0,
							0,
							0,
							0,
							0,
							0,
							255,
							255,
							addressBytes[0],
							addressBytes[1],
							addressBytes[2],
							addressBytes[3]
						};
					}
					else
					{
						array2 = null;
					}
					for (int j = 0; j < array2.Length; j++)
					{
						buffer[j] = array2[j];
					}
					for (byte b = 0; b < 2; b++)
					{
						buffer[16 + b] = (byte)(port >> b * 8);
					}
					buffer[18] = 1;
					NetworkTransport.Send(hostId, connectionId, defaultChannelId, buffer, 19, out error);
				}
				else
				{
					buffer[0] = 0;
					NetworkTransport.Send(hostId, connectionId, defaultChannelId, buffer, 1, out error);
				}
				return NetworkEventType.Nothing;
			case NetworkEventType.DisconnectEvent:
				if (error == 10)
				{
					Debug.LogError("[MLAPI.Relay] The MLAPI Relay detected a CRC mismatch. This could be due to the maxClients or other connectionConfig settings not being the same");
				}
				return NetworkEventType.DisconnectEvent;
			}
			return @event;
		}
	}
}
