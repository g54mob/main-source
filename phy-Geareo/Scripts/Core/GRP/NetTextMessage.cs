using System.Buffers;
using GRP.Net;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct NetTextMessage : NetMessage, IMemoryPackable<NetTextMessage>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class NetTextMessageFormatter : MemoryPackFormatter<NetTextMessage>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetTextMessage value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref NetTextMessage value)
			{
			}
		}

		public string message;

		public NetTextMessage(string message)
		{
			this.message = null;
		}

		static NetTextMessage()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetTextMessage value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref NetTextMessage value)
		{
		}
	}
}
