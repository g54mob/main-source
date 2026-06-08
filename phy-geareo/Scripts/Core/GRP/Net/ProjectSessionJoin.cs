using System.Buffers;
using System.Runtime.InteropServices;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[MemoryPackable(GenerateType.Object)]
	public struct ProjectSessionJoin : NetMessage, IMemoryPackable<ProjectSessionJoin>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ProjectSessionJoinFormatter : MemoryPackFormatter<ProjectSessionJoin>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionJoin value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ProjectSessionJoin value)
			{
			}
		}

		static ProjectSessionJoin()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionJoin value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ProjectSessionJoin value)
		{
		}
	}
}
