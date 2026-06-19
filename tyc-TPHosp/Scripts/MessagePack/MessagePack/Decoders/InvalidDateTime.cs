using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidDateTime : IDateTimeDecoder
	{
		internal static readonly IDateTimeDecoder Instance = new InvalidDateTime();

		private InvalidDateTime()
		{
		}

		public DateTime Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
