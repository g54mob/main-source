using System;
using MessagePack.Internal;

namespace MessagePack.Decoders
{
	internal sealed class Ext8DateTime : IDateTimeDecoder
	{
		internal static readonly IDateTimeDecoder Instance = new Ext8DateTime();

		private Ext8DateTime()
		{
		}

		public DateTime Read(byte[] bytes, int offset, out int readSize)
		{
			byte num = bytes[checked(offset + 1)];
			sbyte b = (sbyte)bytes[offset + 2];
			if (num != 12 || b != -1)
			{
				throw new InvalidOperationException($"typeCode is invalid. typeCode:{b}");
			}
			uint num2 = (uint)((bytes[offset + 3] << 24) | (bytes[offset + 4] << 16) | (bytes[offset + 5] << 8) | bytes[offset + 6]);
			long num3 = (long)(((ulong)bytes[offset + 7] << 56) | ((ulong)bytes[offset + 8] << 48) | ((ulong)bytes[offset + 9] << 40) | ((ulong)bytes[offset + 10] << 32) | ((ulong)bytes[offset + 11] << 24) | ((ulong)bytes[offset + 12] << 16) | ((ulong)bytes[offset + 13] << 8) | bytes[offset + 14]);
			readSize = 15;
			return DateTimeConstants.UnixEpoch.AddSeconds(num3).AddTicks(num2 / 100);
		}
	}
}
