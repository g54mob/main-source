using System.Buffers;
using GRP.Net;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct SampleMessage : NetMessage, IMemoryPackable<SampleMessage>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class SampleMessageFormatter : MemoryPackFormatter<SampleMessage>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SampleMessage value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref SampleMessage value)
			{
			}
		}

		public string text;

		public int id;

		public int[] numbers;

		static SampleMessage()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SampleMessage value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref SampleMessage value)
		{
		}
	}
}
