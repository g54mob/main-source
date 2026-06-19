using System.Runtime.InteropServices;
using Unity.Entities;

namespace Pug.ECS.Serialization.DOTS100
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct ChunkOld
	{
		[FieldOffset(0)]
		public int ArchetypeIndexForSerialization;

		[FieldOffset(8)]
		public Entity metaChunkEntity;

		[FieldOffset(16)]
		public int CountForSerialization;

		[FieldOffset(28)]
		public int ListWithEmptySlotsIndex;

		[FieldOffset(32)]
		public uint Flags;

		[FieldOffset(40)]
		public ulong SequenceNumber;

		public const int kSerializedHeaderSize = 40;

		public const int kBufferOffset = 64;

		[FieldOffset(64)]
		public unsafe fixed byte Buffer[4];

		public const int kChunkSize = 16384;

		public const int kBufferSize = 16320;

		public const int kMaximumEntitiesPerChunk = 2040;

		public const int kChunkBufferSize = 16320;
	}
}
