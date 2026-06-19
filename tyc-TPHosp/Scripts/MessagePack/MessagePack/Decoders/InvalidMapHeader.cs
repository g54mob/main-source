using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidMapHeader : IMapHeaderDecoder
	{
		internal static readonly IMapHeaderDecoder Instance = new InvalidMapHeader();

		private InvalidMapHeader()
		{
		}

		public uint Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
