using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct PresenceEnd : NetMessage, IMemoryPackable<PresenceEnd>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PresenceEndFormatter : MemoryPackFormatter<PresenceEnd>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PresenceEnd value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PresenceEnd value)
			{
			}
		}

		public ulong id;

		static PresenceEnd()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PresenceEnd value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PresenceEnd value)
		{
		}
	}
}
