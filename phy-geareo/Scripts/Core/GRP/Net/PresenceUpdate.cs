using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct PresenceUpdate : NetMessage, IMemoryPackable<PresenceUpdate>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PresenceUpdateFormatter : MemoryPackFormatter<PresenceUpdate>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PresenceUpdate value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PresenceUpdate value)
			{
			}
		}

		public ulong id;

		public byte[] data;

		static PresenceUpdate()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PresenceUpdate value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PresenceUpdate value)
		{
		}
	}
}
