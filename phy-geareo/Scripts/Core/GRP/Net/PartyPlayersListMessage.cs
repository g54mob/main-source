using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct PartyPlayersListMessage : NetMessage, IMemoryPackable<PartyPlayersListMessage>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PartyPlayersListMessageFormatter : MemoryPackFormatter<PartyPlayersListMessage>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartyPlayersListMessage value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PartyPlayersListMessage value)
			{
			}
		}

		public NetPlayerData[] players;

		static PartyPlayersListMessage()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartyPlayersListMessage value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PartyPlayersListMessage value)
		{
		}
	}
}
