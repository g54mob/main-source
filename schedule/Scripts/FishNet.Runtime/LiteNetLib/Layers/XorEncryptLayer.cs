using System.Net;

namespace LiteNetLib.Layers
{
	public class XorEncryptLayer : PacketLayerBase
	{
		private byte[] _byteKey;

		public XorEncryptLayer()
			: base(0)
		{
		}

		public XorEncryptLayer(byte[] key)
			: base(0)
		{
		}

		public XorEncryptLayer(string key)
			: base(0)
		{
		}

		public void SetKey(string key)
		{
		}

		public void SetKey(byte[] key)
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
