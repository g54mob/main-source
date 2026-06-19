namespace MessagePack.Decoders
{
	internal sealed class UInt64Int64 : IInt64Decoder
	{
		internal static readonly IInt64Decoder Instance = new UInt64Int64();

		private UInt64Int64()
		{
		}

		public long Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 9;
			return (long)(((ulong)bytes[checked(offset + 1)] << 56) | ((ulong)bytes[checked(offset + 2)] << 48) | ((ulong)bytes[checked(offset + 3)] << 40) | ((ulong)bytes[checked(offset + 4)] << 32) | ((ulong)bytes[checked(offset + 5)] << 24) | ((ulong)bytes[checked(offset + 6)] << 16) | ((ulong)bytes[checked(offset + 7)] << 8) | bytes[checked(offset + 8)]);
		}
	}
}
