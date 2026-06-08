using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct ProjectSessionChange : NetMessage, IMemoryPackable<ProjectSessionChange>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ProjectSessionChangeFormatter : MemoryPackFormatter<ProjectSessionChange>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionChange value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ProjectSessionChange value)
			{
			}
		}

		public string name;

		public ProjectChangeType type;

		public byte[] parts;

		public ulong[] ids;

		public int[] orders;

		public EntityData[] ParseEntities()
		{
			return null;
		}

		static ProjectSessionChange()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionChange value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ProjectSessionChange value)
		{
		}
	}
}
