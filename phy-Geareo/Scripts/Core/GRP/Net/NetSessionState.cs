using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct NetSessionState : NetMessage, IMemoryPackable<NetSessionState>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class NetSessionStateFormatter : MemoryPackFormatter<NetSessionState>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetSessionState value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref NetSessionState value)
			{
			}
		}

		public int tag;

		public bool started;

		public bool host;

		public bool joined;

		static NetSessionState()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetSessionState value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref NetSessionState value)
		{
		}
	}
}
