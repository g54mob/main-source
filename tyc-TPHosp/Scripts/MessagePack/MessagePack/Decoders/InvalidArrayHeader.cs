using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidArrayHeader : IArrayHeaderDecoder
	{
		internal static readonly IArrayHeaderDecoder Instance = new InvalidArrayHeader();

		private InvalidArrayHeader()
		{
		}

		public uint Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
