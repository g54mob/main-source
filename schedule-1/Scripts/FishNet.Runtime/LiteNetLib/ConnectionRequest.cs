using System.Net;
using LiteNetLib.Utils;

namespace LiteNetLib
{
	public class ConnectionRequest
	{
		private readonly NetManager _listener;

		private int _used;

		internal NetConnectRequestPacket InternalPacket;

		public readonly IPEndPoint RemoteEndPoint;

		public NetDataReader Data => null;

		internal ConnectionRequestResult Result { get; private set; }

		internal void UpdateRequest(NetConnectRequestPacket connectRequest)
		{
		}

		private bool TryActivate()
		{
			return false;
		}

		internal ConnectionRequest(IPEndPoint remoteEndPoint, NetConnectRequestPacket requestPacket, NetManager listener)
		{
		}

		public NetPeer AcceptIfKey(string key)
		{
			return null;
		}

		public NetPeer Accept()
		{
			return null;
		}

		public void Reject(byte[] rejectData, int start, int length, bool force)
		{
		}

		public void Reject(byte[] rejectData, int start, int length)
		{
		}

		public void RejectForce(byte[] rejectData, int start, int length)
		{
		}

		public void RejectForce()
		{
		}

		public void RejectForce(byte[] rejectData)
		{
		}

		public void RejectForce(NetDataWriter rejectData)
		{
		}

		public void Reject()
		{
		}

		public void Reject(byte[] rejectData)
		{
		}

		public void Reject(NetDataWriter rejectData)
		{
		}
	}
}
