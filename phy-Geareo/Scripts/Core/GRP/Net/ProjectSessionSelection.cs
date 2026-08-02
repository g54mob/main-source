using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct ProjectSessionSelection : NetMessage, IMemoryPackable<ProjectSessionSelection>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ProjectSessionSelectionFormatter : MemoryPackFormatter<ProjectSessionSelection>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionSelection value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ProjectSessionSelection value)
			{
			}
		}

		public ulong playerId;

		public ulong[] ids;

		static ProjectSessionSelection()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionSelection value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ProjectSessionSelection value)
		{
		}
	}
}
