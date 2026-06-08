using System.Buffers;
using GRP.Net;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct NetAlterMessage : NetMessage, IMemoryPackable<NetAlterMessage>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class NetAlterMessageFormatter : MemoryPackFormatter<NetAlterMessage>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetAlterMessage value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref NetAlterMessage value)
			{
			}
		}

		public string message;

		public NetAlterMessage(string message)
		{
			this.message = null;
		}

		static NetAlterMessage()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetAlterMessage value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref NetAlterMessage value)
		{
		}
	}
}
