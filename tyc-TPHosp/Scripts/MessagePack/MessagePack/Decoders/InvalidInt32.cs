using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidInt32 : IInt32Decoder
	{
		internal static readonly IInt32Decoder Instance = new InvalidInt32();

		private InvalidInt32()
		{
		}

		public int Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
