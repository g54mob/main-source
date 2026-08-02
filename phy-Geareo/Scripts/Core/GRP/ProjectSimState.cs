using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct ProjectSimState : IMemoryPackable<ProjectSimState>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ProjectSimStateFormatter : MemoryPackFormatter<ProjectSimState>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSimState value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ProjectSimState value)
			{
			}
		}

		public ClusterState[] clusters;

		static ProjectSimState()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSimState value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ProjectSimState value)
		{
		}
	}
}
