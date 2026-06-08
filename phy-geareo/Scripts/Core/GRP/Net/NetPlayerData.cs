using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP.Net
{
	[MemoryPackable(GenerateType.Object)]
	public struct NetPlayerData : IMemoryPackable<NetPlayerData>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class NetPlayerDataFormatter : MemoryPackFormatter<NetPlayerData>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetPlayerData value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref NetPlayerData value)
			{
			}
		}

		public ulong id;

		public string username;

		public bool isProjectSession;

		public bool isSimSession;

		static NetPlayerData()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref NetPlayerData value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref NetPlayerData value)
		{
		}
	}
}
