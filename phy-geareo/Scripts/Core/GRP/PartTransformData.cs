using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;
using UnityEngine;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct PartTransformData : IMemoryPackable<PartTransformData>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class PartTransformDataFormatter : MemoryPackFormatter<PartTransformData>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartTransformData value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref PartTransformData value)
			{
			}
		}

		public ulong id;

		public Float3 position;

		public Float3 rotation;

		public static PartTransformData Build(Part part)
		{
			return default(PartTransformData);
		}

		public static PartTransformData Build(Id id, Vector3 position, Quaternion rotation)
		{
			return default(PartTransformData);
		}

		static PartTransformData()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref PartTransformData value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref PartTransformData value)
		{
		}
	}
}
