namespace MessagePack.Decoders
{
	internal sealed class Int64Int64 : IInt64Decoder
	{
		internal static readonly IInt64Decoder Instance = new Int64Int64();

		private Int64Int64()
		{
		}

		public long Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 9;
			return (long)(((ulong)bytes[offset + 1] << 56) | ((ulong)bytes[offset + 2] << 48) | ((ulong)bytes[offset + 3] << 40) | ((ulong)bytes[offset + 4] << 32) | ((ulong)bytes[offset + 5] << 24) | ((ulong)bytes[offset + 6] << 16) | ((ulong)bytes[offset + 7] << 8) | bytes[offset + 8]);
		}
	}
}
