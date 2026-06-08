using System;

namespace MemoryPack
{
	public static class MemoryPackCode
	{
		public const int NullCollection = -1;

		public const byte WideTag = 250;

		public const byte ReferenceId = 250;

		public const byte Reserved1 = 250;

		public const byte Reserved2 = 251;

		public const byte Reserved3 = 252;

		public const byte Reserved4 = 253;

		public const byte Reserved5 = 254;

		public const byte NullObject = 255;

		internal static ReadOnlySpan<byte> NullCollectionData => default(ReadOnlySpan<byte>);

		internal static ReadOnlySpan<byte> ZeroCollectionData => default(ReadOnlySpan<byte>);
	}
}
