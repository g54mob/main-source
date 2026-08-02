using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct SimSessionStart : NetMessage, IMemoryPackable<SimSessionStart>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class SimSessionStartFormatter : MemoryPackFormatter<SimSessionStart>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionStart value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref SimSessionStart value)
			{
			}
		}

		public ProjectDataBinary project;

		public int[] keys;

		static SimSessionStart()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionStart value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref SimSessionStart value)
		{
		}
	}
}
