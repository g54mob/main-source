using MemoryPack.Internal;
using UnityEngine;

namespace MemoryPack
{
	[Preserve]
	internal sealed class RectOffsetFormatter : MemoryPackFormatter<RectOffset>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref RectOffset? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, ref RectOffset? value)
		{
		}
	}
}
