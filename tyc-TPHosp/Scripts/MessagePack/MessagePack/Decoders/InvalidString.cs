using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidString : IStringDecoder
	{
		internal static readonly IStringDecoder Instance = new InvalidString();

		private InvalidString()
		{
		}

		public string Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
