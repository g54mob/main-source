using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidUInt64 : IUInt64Decoder
	{
		internal static readonly IUInt64Decoder Instance = new InvalidUInt64();

		private InvalidUInt64()
		{
		}

		public ulong Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
