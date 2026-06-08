using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct NetProjectPlayerData : IMemoryPackable<NetProjectPlayerData>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class NetProjectPlayerDataFormatter : MemoryPackFormatter<NetProjectPlayerData>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetProjectPlayerData value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref NetProjectPlayerData value)
			{
			}
		}

		public ulong id;

		public float[] head;

		public float[] cursor;

		public ulong selected;

		public bool move;

		public bool rotate;

		static NetProjectPlayerData()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetProjectPlayerData value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref NetProjectPlayerData value)
		{
		}
	}
}
