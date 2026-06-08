using MemoryPack.Internal;
using UnityEngine;

namespace MemoryPack
{
	[Preserve]
	internal sealed class GradientFormatter : MemoryPackFormatter<Gradient>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref Gradient? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, ref Gradient? value)
		{
		}
	}
}
