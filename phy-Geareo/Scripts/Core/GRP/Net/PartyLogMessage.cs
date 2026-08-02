using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct PartyLogMessage : NetMessage, IMemoryPackable<PartyLogMessage>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PartyLogMessageFormatter : MemoryPackFormatter<PartyLogMessage>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartyLogMessage value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PartyLogMessage value)
			{
			}
		}

		public string message;

		public PartyLogMessage(string message)
		{
			this.message = null;
		}

		static PartyLogMessage()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartyLogMessage value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PartyLogMessage value)
		{
		}
	}
}
