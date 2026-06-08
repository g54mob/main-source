using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct SimSessionUpdate : NetMessage, IMemoryPackable<SimSessionUpdate>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class SimSessionUpdateFormatter : MemoryPackFormatter<SimSessionUpdate>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionUpdate value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref SimSessionUpdate value)
			{
			}
		}

		public ProjectSimState state;

		static SimSessionUpdate()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionUpdate value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref SimSessionUpdate value)
		{
		}
	}
}
