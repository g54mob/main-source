using System.Net;

namespace LiteNetLib.Layers
{
	public sealed class Crc32cLayer : PacketLayerBase
	{
		public Crc32cLayer()
			: base(0)
		{
		}

		public override void ProcessInboundPacket(ref IPEndPoint endPoint, ref byte[] data, ref int offset, ref int length)
		{
		}

		public override void ProcessOutBoundPacket(ref IPEndPoint endPoint, ref byte[] data, ref int offset, ref int length)
		{
		}
	}
}
