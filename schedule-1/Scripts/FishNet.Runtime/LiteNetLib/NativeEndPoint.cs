using System.Net;

namespace LiteNetLib
{
	internal class NativeEndPoint : IPEndPoint
	{
		public readonly byte[] NativeAddress;

		public NativeEndPoint(byte[] address)
			: base(null, 0)
		{
		}
	}
}
