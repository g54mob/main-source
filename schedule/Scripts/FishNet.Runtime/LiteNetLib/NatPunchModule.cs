using System.Collections.Concurrent;
using System.Net;
using LiteNetLib.Utils;

namespace LiteNetLib
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

		private readonly NetManager _socket;

		private readonly ConcurrentQueue<RequestEventData> _requestEvents;

		private readonly ConcurrentQueue<SuccessEventData> _successEvents;

		private readonly NetDataReader _cacheReader;

		private readonly NetDataWriter _cacheWriter;

		private readonly NetPacketProcessor _netPacketProcessor;

		private INatPunchListener _natPunchListener;

		public const int MaxTokenLength = 256;

		public bool UnsyncedEvents;

		internal NatPunchModule(NetManager socket)
		{
		}

		internal void ProcessMessage(IPEndPoint senderEndPoint, NetPacket packet)
		{
		}

		public void Init(INatPunchListener listener)
		{
		}

		private void Send<T>(T packet, IPEndPoint target) where T : class, new()
		{
		}

		public void NatIntroduce(IPEndPoint hostInternal, IPEndPoint hostExternal, IPEndPoint clientInternal, IPEndPoint clientExternal, string additionalInfo)
		{
		}

		public void PollEvents()
		{
		}

		public void SendNatIntroduceRequest(string host, int port, string additionalInfo)
		{
		}

		public void SendNatIntroduceRequest(IPEndPoint masterServerEndPoint, string additionalInfo)
		{
		}

		private void OnNatIntroductionRequest(NatIntroduceRequestPacket req, IPEndPoint senderEndPoint)
		{
		}

		private void OnNatIntroductionResponse(NatIntroduceResponsePacket req)
		{
		}

		private void OnNatPunch(NatPunchPacket req, IPEndPoint senderEndPoint)
		{
		}
	}
}
