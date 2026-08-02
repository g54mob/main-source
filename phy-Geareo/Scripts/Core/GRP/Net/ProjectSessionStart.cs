using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct ProjectSessionStart : NetMessage, IMemoryPackable<ProjectSessionStart>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ProjectSessionStartFormatter : MemoryPackFormatter<ProjectSessionStart>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionStart value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ProjectSessionStart value)
			{
			}
		}

		public ProjectDataBinary project;

		static ProjectSessionStart()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionStart value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ProjectSessionStart value)
		{
		}
	}
}
