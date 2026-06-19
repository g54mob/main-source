using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidSingle : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new InvalidSingle();

		private InvalidSingle()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
