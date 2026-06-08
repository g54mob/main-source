using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using FlyingWormConsole3.LiteNetLib.Utils;

namespace FlyingWormConsole3.LiteNetLib
{
	public sealed class NatPunchModule
	{
		private struct RequestEventData
		{
			public IPEndPoint LocalEndPoint;

			public IPEndPoint RemoteEndPoint;

			public string Token;
		}

		private struct SuccessEventData
		{
			public IPEndPoint TargetEndPoint;

			public NatAddressType Type;

			public string Token;
		}

		private class NatIntroduceRequestPacket
		{
			public IPEndPoint Internal { get; set; }

			public string Token { get; set; }
		}

		private class NatIntroduceResponsePacket
		{
			public IPEndPoint Internal { get; set; }

			public IPEndPoint External { get; set; }

			public string Token { get; set; }
		}

		private class NatPunchPacket
		{
			public string Token { get; set; }

			public bool IsExternal { get; set; }
		}

		private readonly NetSocket _socket;

		private readonly Queue<RequestEventData> _requestEvents = new Queue<RequestEventData>();

		private readonly Queue<SuccessEventData> _successEvents = new Queue<SuccessEventData>();

		private readonly NetDataReader _cacheReader = new NetDataReader();

		private readonly NetDataWriter _cacheWriter = new NetDataWriter();

		private readonly NetPacketProcessor _netPacketProcessor = new NetPacketProcessor(256);

		private INatPunchListener _natPunchListener;

		public const int MaxTokenLength = 256;

		internal NatPunchModule(NetSocket socket)
		{
			_socket = socket;
			_netPacketProcessor.SubscribeReusable<NatIntroduceResponsePacket>(OnNatIntroductionResponse);
			_netPacketProcessor.SubscribeReusable<NatIntroduceRequestPacket, IPEndPoint>(OnNatIntroductionRequest);
			_netPacketProcessor.SubscribeReusable<NatPunchPacket, IPEndPoint>(OnNatPunch);
		}

		internal void ProcessMessage(IPEndPoint senderEndPoint, NetPacket packet)
		{
			lock (_cacheReader)
			{
				_cacheReader.SetSource(packet.RawData, 1, packet.Size);
				_netPacketProcessor.ReadAllPackets(_cacheReader, senderEndPoint);
			}
		}

		public void Init(INatPunchListener listener)
		{
			_natPunchListener = listener;
		}

		private void Send<T>(T packet, IPEndPoint target) where T : class, new()
		{
			SocketError errorCode = SocketError.Success;
			_cacheWriter.Reset();
			_cacheWriter.Put((byte)16);
			_netPacketProcessor.Write(_cacheWriter, packet);
			_socket.SendTo(_cacheWriter.Data, 0, _cacheWriter.Length, target, ref errorCode);
		}

		public void NatIntroduce(IPEndPoint hostInternal, IPEndPoint hostExternal, IPEndPoint clientInternal, IPEndPoint clientExternal, string additionalInfo)
		{
			NatIntroduceResponsePacket natIntroduceResponsePacket = new NatIntroduceResponsePacket
			{
				Token = additionalInfo
			};
			natIntroduceResponsePacket.Internal = hostInternal;
			natIntroduceResponsePacket.External = hostExternal;
			Send(natIntroduceResponsePacket, clientExternal);
			natIntroduceResponsePacket.Internal = clientInternal;
			natIntroduceResponsePacket.External = clientExternal;
			Send(natIntroduceResponsePacket, hostExternal);
		}

		public void PollEvents()
		{
			if (_natPunchListener == null || (_successEvents.Count == 0 && _requestEvents.Count == 0))
			{
				return;
			}
			lock (_successEvents)
			{
				while (_successEvents.Count > 0)
				{
					SuccessEventData successEventData = _successEvents.Dequeue();
					_natPunchListener.OnNatIntroductionSuccess(successEventData.TargetEndPoint, successEventData.Type, successEventData.Token);
				}
			}
			lock (_requestEvents)
			{
				while (_requestEvents.Count > 0)
				{
					RequestEventData requestEventData = _requestEvents.Dequeue();
					_natPunchListener.OnNatIntroductionRequest(requestEventData.LocalEndPoint, requestEventData.RemoteEndPoint, requestEventData.Token);
				}
			}
		}

		public void SendNatIntroduceRequest(string host, int port, string additionalInfo)
		{
			SendNatIntroduceRequest(NetUtils.MakeEndPoint(host, port), additionalInfo);
		}

		public void SendNatIntroduceRequest(IPEndPoint masterServerEndPoint, string additionalInfo)
		{
			string localIp = NetUtils.GetLocalIp(LocalAddrType.IPv4);
			if (string.IsNullOrEmpty(localIp))
			{
				localIp = NetUtils.GetLocalIp(LocalAddrType.IPv6);
			}
			Send(new NatIntroduceRequestPacket
			{
				Internal = NetUtils.MakeEndPoint(localIp, _socket.LocalPort),
				Token = additionalInfo
			}, masterServerEndPoint);
		}

		private void OnNatIntroductionRequest(NatIntroduceRequestPacket req, IPEndPoint senderEndPoint)
		{
			lock (_requestEvents)
			{
				_requestEvents.Enqueue(new RequestEventData
				{
					LocalEndPoint = req.Internal,
					RemoteEndPoint = senderEndPoint,
					Token = req.Token
				});
			}
		}

		private void OnNatIntroductionResponse(NatIntroduceResponsePacket req)
		{
			NatPunchPacket natPunchPacket = new NatPunchPacket
			{
				Token = req.Token
			};
			Send(natPunchPacket, req.Internal);
			SocketError errorCode = SocketError.Success;
			_socket.Ttl = 2;
			_socket.SendTo(new byte[1] { 17 }, 0, 1, req.External, ref errorCode);
			_socket.Ttl = 255;
			natPunchPacket.IsExternal = true;
			Send(natPunchPacket, req.External);
		}

		private void OnNatPunch(NatPunchPacket req, IPEndPoint senderEndPoint)
		{
			lock (_successEvents)
			{
				_successEvents.Enqueue(new SuccessEventData
				{
					TargetEndPoint = senderEndPoint,
					Type = (req.IsExternal ? NatAddressType.External : NatAddressType.Internal),
					Token = req.Token
				});
			}
		}
	}
}
