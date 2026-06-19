using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidBytes : IBytesDecoder
	{
		internal static readonly IBytesDecoder Instance = new InvalidBytes();

		private InvalidBytes()
		{
		}

		public byte[] Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
