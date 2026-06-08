using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct ProjectDataBinary : IMemoryPackable<ProjectDataBinary>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ProjectDataBinaryFormatter : MemoryPackFormatter<ProjectDataBinary>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectDataBinary value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ProjectDataBinary value)
			{
			}
		}

		public byte[] data;

		public static ProjectDataBinary FromProjectData(ProjectData projectData)
		{
			return default(ProjectDataBinary);
		}

		public ProjectData ToProjectData()
		{
			return null;
		}

		static ProjectDataBinary()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectDataBinary value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ProjectDataBinary value)
		{
		}
	}
}
