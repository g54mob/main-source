using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct PartyChatMessage : NetMessage, IMemoryPackable<PartyChatMessage>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PartyChatMessageFormatter : MemoryPackFormatter<PartyChatMessage>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartyChatMessage value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PartyChatMessage value)
			{
			}
		}

		public string message;

		public PartyChatMessage(string message)
		{
			this.message = null;
		}

		static PartyChatMessage()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartyChatMessage value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PartyChatMessage value)
		{
		}
	}
}
