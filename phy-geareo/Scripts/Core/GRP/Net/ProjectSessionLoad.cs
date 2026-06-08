using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct ProjectSessionLoad : NetMessage, IMemoryPackable<ProjectSessionLoad>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ProjectSessionLoadFormatter : MemoryPackFormatter<ProjectSessionLoad>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionLoad value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ProjectSessionLoad value)
			{
			}
		}

		public bool join;

		public string message;

		public ProjectDataBinary project;

		static ProjectSessionLoad()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionLoad value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ProjectSessionLoad value)
		{
		}
	}
}
