using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidInt16 : IInt16Decoder
	{
		internal static readonly IInt16Decoder Instance = new InvalidInt16();

		private InvalidInt16()
		{
		}

		public short Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
