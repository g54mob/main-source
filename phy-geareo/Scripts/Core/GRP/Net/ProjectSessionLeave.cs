using System.Buffers;
using System.Runtime.InteropServices;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[MemoryPackable(GenerateType.Object)]
	public struct ProjectSessionLeave : NetMessage, IMemoryPackable<ProjectSessionLeave>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ProjectSessionLeaveFormatter : MemoryPackFormatter<ProjectSessionLeave>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionLeave value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ProjectSessionLeave value)
			{
			}
		}

		static ProjectSessionLeave()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ProjectSessionLeave value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ProjectSessionLeave value)
		{
		}
	}
}
