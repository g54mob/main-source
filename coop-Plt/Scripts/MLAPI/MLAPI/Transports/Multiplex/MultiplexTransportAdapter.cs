using System;
using System.Collections.Generic;
using MLAPI.Transports.Tasks;
using UnityEngine;

namespace MLAPI.Transports.Multiplex
{
	public class MultiplexTransportAdapter : Transport
	{
		public enum ConnectionIdSpreadMethod
		{
			MakeRoomLastBits = 0,
			ReplaceFirstBits = 1,
			ReplaceLastBits = 2,
			MakeRoomFirstBits = 3,
			Spread = 4
		}

		public ConnectionIdSpreadMethod SpreadMethod;

		public Transport[] Transports = new Transport[0];

		private byte _lastProcessedTransportIndex;

		public override ulong ServerClientId => 0uL;

		public override bool IsSupported => true;

		public override void DisconnectLocalClient()
		{
			Transports[GetFirstSupportedTransportIndex()].DisconnectLocalClient();
		}

		public override void DisconnectRemoteClient(ulong clientId)
		{
			GetMultiplexTransportDetails(clientId, out var transportId, out var connectionId);
			Transports[transportId].DisconnectRemoteClient(connectionId);
		}

		public override ulong GetCurrentRtt(ulong clientId)
		{
			GetMultiplexTransportDetails(clientId, out var transportId, out var connectionId);
			return Transports[transportId].GetCurrentRtt(connectionId);
		}

		public override void Init()
		{
			for (int i = 0; i < Transports.Length; i++)
			{
				if (Transports[i].IsSupported)
				{
					Transports[i].Init();
				}
			}
		}

		public override NetEventType PollEvent(out ulong clientId, out string channelName, out ArraySegment<byte> payload, out float receiveTime)
		{
			if (_lastProcessedTransportIndex >= Transports.Length - 1)
			{
				_lastProcessedTransportIndex = 0;
			}
			for (byte b = _lastProcessedTransportIndex; b < Transports.Length; b++)
			{
				_lastProcessedTransportIndex = b;
				if (Transports[b].IsSupported)
				{
					ulong clientId2;
					NetEventType netEventType = Transports[b].PollEvent(out clientId2, out channelName, out payload, out receiveTime);
					if (netEventType != NetEventType.Nothing)
					{
						clientId = GetMLAPIClientId(b, clientId2, isServer: false);
						return netEventType;
					}
				}
			}
			clientId = 0uL;
			channelName = null;
			payload = default(ArraySegment<byte>);
			receiveTime = 0f;
			return NetEventType.Nothing;
		}

		public override void Send(ulong clientId, ArraySegment<byte> data, string channelName)
		{
			GetMultiplexTransportDetails(clientId, out var transportId, out var connectionId);
			Transports[transportId].Send(connectionId, data, channelName);
		}

		public override void Shutdown()
		{
			for (int i = 0; i < Transports.Length; i++)
			{
				if (Transports[i].IsSupported)
				{
					Transports[i].Shutdown();
				}
			}
		}

		public override SocketTasks StartClient()
		{
			List<SocketTask> list = new List<SocketTask>();
			for (int i = 0; i < Transports.Length; i++)
			{
				if (Transports[i].IsSupported)
				{
					list.AddRange(Transports[i].StartClient().Tasks);
				}
			}
			return new SocketTasks
			{
				Tasks = list.ToArray()
			};
		}

		public override SocketTasks StartServer()
		{
			List<SocketTask> list = new List<SocketTask>();
			for (int i = 0; i < Transports.Length; i++)
			{
				if (Transports[i].IsSupported)
				{
					list.AddRange(Transports[i].StartServer().Tasks);
				}
			}
			return new SocketTasks
			{
				Tasks = list.ToArray()
			};
		}

		public ulong GetMLAPIClientId(byte transportId, ulong connectionId, bool isServer)
		{
			if (isServer)
			{
				return ServerClientId;
			}
			switch (SpreadMethod)
			{
			case ConnectionIdSpreadMethod.ReplaceFirstBits:
			{
				byte b4 = (byte)Mathf.CeilToInt(Mathf.Log(Transports.Length, 2f));
				ulong num5 = connectionId << (int)b4 >> (int)b4;
				ulong num6 = (ulong)transportId << 64 - b4;
				return (num5 | num6) + 1;
			}
			case ConnectionIdSpreadMethod.MakeRoomFirstBits:
			{
				byte b3 = (byte)Mathf.CeilToInt(Mathf.Log(Transports.Length, 2f));
				ulong num3 = connectionId >> (int)b3;
				ulong num4 = (ulong)transportId << 64 - b3;
				return (num3 | num4) + 1;
			}
			case ConnectionIdSpreadMethod.ReplaceLastBits:
			{
				byte b2 = (byte)Mathf.CeilToInt(Mathf.Log(Transports.Length, 2f));
				ulong num2 = connectionId >> (int)b2 << (int)b2;
				return (num2 | transportId) + 1;
			}
			case ConnectionIdSpreadMethod.MakeRoomLastBits:
			{
				byte b = (byte)Mathf.CeilToInt(Mathf.Log(Transports.Length, 2f));
				ulong num = connectionId << (int)b;
				return (num | transportId) + 1;
			}
			case ConnectionIdSpreadMethod.Spread:
				return (ulong)((long)connectionId * (long)Transports.Length + transportId + 1);
			default:
				return ServerClientId;
			}
		}

		public void GetMultiplexTransportDetails(ulong clientId, out byte transportId, out ulong connectionId)
		{
			if (clientId == ServerClientId)
			{
				transportId = GetFirstSupportedTransportIndex();
				connectionId = Transports[transportId].ServerClientId;
				return;
			}
			switch (SpreadMethod)
			{
			case ConnectionIdSpreadMethod.ReplaceFirstBits:
			{
				clientId--;
				byte b4 = (byte)Mathf.CeilToInt(Mathf.Log(Transports.Length, 2f));
				transportId = (byte)(clientId >> 64 - b4);
				connectionId = clientId << (int)b4 >> (int)b4;
				break;
			}
			case ConnectionIdSpreadMethod.MakeRoomFirstBits:
			{
				clientId--;
				byte b3 = (byte)Mathf.CeilToInt(Mathf.Log(Transports.Length, 2f));
				transportId = (byte)(clientId >> 64 - b3);
				connectionId = clientId << (int)b3;
				break;
			}
			case ConnectionIdSpreadMethod.ReplaceLastBits:
			{
				clientId--;
				byte b2 = (byte)Mathf.CeilToInt(Mathf.Log(Transports.Length, 2f));
				transportId = (byte)(clientId << 64 - b2 >> 64 - b2);
				connectionId = clientId >> (int)b2 << (int)b2;
				break;
			}
			case ConnectionIdSpreadMethod.MakeRoomLastBits:
			{
				clientId--;
				byte b = (byte)Mathf.CeilToInt(Mathf.Log(Transports.Length, 2f));
				transportId = (byte)(clientId << 64 - b >> 64 - b);
				connectionId = clientId >> (int)b;
				break;
			}
			case ConnectionIdSpreadMethod.Spread:
				clientId--;
				transportId = (byte)(clientId % (ulong)Transports.Length);
				connectionId = clientId / (ulong)Transports.Length;
				break;
			default:
				transportId = GetFirstSupportedTransportIndex();
				connectionId = Transports[transportId].ServerClientId;
				break;
			}
		}

		public byte GetFirstSupportedTransportIndex()
		{
			for (byte b = 0; b < Transports.Length; b++)
			{
				if (Transports[b].IsSupported)
				{
					return b;
				}
			}
			return 0;
		}
	}
}
