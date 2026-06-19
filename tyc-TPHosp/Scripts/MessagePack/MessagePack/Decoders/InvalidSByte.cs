using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidSByte : ISByteDecoder
	{
		internal static readonly ISByteDecoder Instance = new InvalidSByte();

		private InvalidSByte()
		{
		}

		public sbyte Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
