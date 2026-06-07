using System;
using System.Net;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common.Pooling;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Transport;

namespace Coherence.Flux
{
	public class Flux
	{
		private enum Mode
		{
			Open = 0,
			Listen = 1
		}

		private readonly IPort port;

		private Mode mode;

		private IPEndPoint singleEndPoint;

		private string lastHost;

		private ushort roomId;

		private Logger logger;

		public const int roomByteCount = 2;

		private readonly object sendLock;

		private readonly Pool<PooledInOctetStream> streamPool;

		public event Action<IInOctetStream, IPEndPoint> OnPacketReceived
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

		public event Action<uint> OnPacketSent
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

		public Flux(IPort port, Logger logger)
		{
		}

		public void Open(string hostAndPort)
		{
		}

		public void Listen(EndpointData endpoint)
		{
		}

		public void SendPacket(ArraySegment<byte> packet)
		{
		}

		public void SendPacketTo(ArraySegment<byte> packet, IPEndPoint endpoint)
		{
		}

		public void SetRoomId(ushort roomId)
		{
		}

		private void SetSingleEndPoint(string hostAndPort)
		{
		}

		private void ReportDataReceived(byte[] data, IPEndPoint receivedFrom, object state)
		{
		}

		private IPEndPoint GetEndpoint(EndpointData endpointData)
		{
			return null;
		}
	}
}
