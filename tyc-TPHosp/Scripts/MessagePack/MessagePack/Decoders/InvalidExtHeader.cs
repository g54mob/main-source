using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidExtHeader : IExtHeaderDecoder
	{
		internal static readonly IExtHeaderDecoder Instance = new InvalidExtHeader();

		private InvalidExtHeader()
		{
		}

		public ExtensionHeader Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
