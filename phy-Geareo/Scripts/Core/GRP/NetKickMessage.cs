using System.Buffers;
using GRP.Net;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct NetKickMessage : NetMessage, IMemoryPackable<NetKickMessage>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class NetKickMessageFormatter : MemoryPackFormatter<NetKickMessage>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetKickMessage value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref NetKickMessage value)
			{
			}
		}

		public string message;

		public NetKickMessage(string message)
		{
			this.message = null;
		}

		static NetKickMessage()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetKickMessage value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref NetKickMessage value)
		{
		}
	}
}
