using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidExt : IExtDecoder
	{
		internal static readonly IExtDecoder Instance = new InvalidExt();

		private InvalidExt()
		{
		}

		public ExtensionResult Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
