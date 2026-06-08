using System.Buffers;
using System.Runtime.InteropServices;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[MemoryPackable(GenerateType.Object)]
	public struct SimSessionJoin : NetMessage, IMemoryPackable<SimSessionJoin>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class SimSessionJoinFormatter : MemoryPackFormatter<SimSessionJoin>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionJoin value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref SimSessionJoin value)
			{
			}
		}

		static SimSessionJoin()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionJoin value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref SimSessionJoin value)
		{
		}
	}
}
