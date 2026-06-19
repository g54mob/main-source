using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidUInt32 : IUInt32Decoder
	{
		internal static readonly IUInt32Decoder Instance = new InvalidUInt32();

		private InvalidUInt32()
		{
		}

		public uint Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
