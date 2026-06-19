using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidUInt16 : IUInt16Decoder
	{
		internal static readonly IUInt16Decoder Instance = new InvalidUInt16();

		private InvalidUInt16()
		{
		}

		public ushort Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
