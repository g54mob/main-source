using System.Buffers;
using System.Runtime.InteropServices;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[MemoryPackable(GenerateType.Object)]
	public struct SimSessionLeave : NetMessage, IMemoryPackable<SimSessionLeave>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class SimSessionLeaveFormatter : MemoryPackFormatter<SimSessionLeave>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionLeave value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref SimSessionLeave value)
			{
			}
		}

		static SimSessionLeave()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref SimSessionLeave value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref SimSessionLeave value)
		{
		}
	}
}
