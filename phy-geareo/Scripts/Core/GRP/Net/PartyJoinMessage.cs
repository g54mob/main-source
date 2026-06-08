using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct PartyJoinMessage : NetMessage, IMemoryPackable<PartyJoinMessage>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PartyJoinMessageFormatter : MemoryPackFormatter<PartyJoinMessage>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartyJoinMessage value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PartyJoinMessage value)
			{
			}
		}

		public string username;

		public PartyJoinMessage(string username)
		{
			this.username = null;
		}

		static PartyJoinMessage()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartyJoinMessage value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PartyJoinMessage value)
		{
		}
	}
}
