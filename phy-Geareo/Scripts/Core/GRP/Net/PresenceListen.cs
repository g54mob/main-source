using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct PresenceListen : NetMessage, IMemoryPackable<PresenceListen>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PresenceListenFormatter : MemoryPackFormatter<PresenceListen>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PresenceListen value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PresenceListen value)
			{
			}
		}

		public short[] channels;

		static PresenceListen()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PresenceListen value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PresenceListen value)
		{
		}
	}
}
