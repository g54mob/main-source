using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidDouble : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new InvalidDouble();

		private InvalidDouble()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
