using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidInt64 : IInt64Decoder
	{
		internal static readonly IInt64Decoder Instance = new InvalidInt64();

		private InvalidInt64()
		{
		}

		public long Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
