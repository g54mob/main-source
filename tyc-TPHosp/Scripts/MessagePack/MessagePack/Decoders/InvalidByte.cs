using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidByte : IByteDecoder
	{
		internal static readonly IByteDecoder Instance = new InvalidByte();

		private InvalidByte()
		{
		}

		public byte Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
