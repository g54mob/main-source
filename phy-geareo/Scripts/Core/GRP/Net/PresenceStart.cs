using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct PresenceStart : NetMessage, IMemoryPackable<PresenceStart>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PresenceStartFormatter : MemoryPackFormatter<PresenceStart>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PresenceStart value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PresenceStart value)
			{
			}
		}

		public ulong playerId;

		public ulong id;

		public short channel;

		public string key;

		public byte[] data;

		static PresenceStart()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PresenceStart value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PresenceStart value)
		{
		}
	}
}
