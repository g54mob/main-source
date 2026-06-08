using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct ClusterState : IMemoryPackable<ClusterState>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class ClusterStateFormatter : MemoryPackFormatter<ClusterState>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ClusterState value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref ClusterState value)
			{
			}
		}

		public int index;

		public Float3 position;

		public Float3 rotation;

		public Float3 linearVelocity;

		public Float3 angularVelocity;

		public ClusterState(int index, Cluster cluster)
		{
			this.index = 0;
			position = default(Float3);
			rotation = default(Float3);
			linearVelocity = default(Float3);
			angularVelocity = default(Float3);
		}

		public bool IsDifferent(ClusterState other)
		{
			return false;
		}

		static ClusterState()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref ClusterState value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref ClusterState value)
		{
		}
	}
}
