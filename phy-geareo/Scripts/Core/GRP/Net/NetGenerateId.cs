using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct NetGenerateId : NetMessage, IMemoryPackable<NetGenerateId>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class NetGenerateIdFormatter : MemoryPackFormatter<NetGenerateId>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetGenerateId value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref NetGenerateId value)
			{
			}
		}

		public int tag;

		public int count;

		public ulong[] ids;

		static NetGenerateId()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetGenerateId value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref NetGenerateId value)
		{
		}
	}
}
