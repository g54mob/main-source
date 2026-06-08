using MemoryPack.Internal;
using UnityEngine;

namespace MemoryPack
{
	[Preserve]
	internal sealed class AnimationCurveFormatter : MemoryPackFormatter<AnimationCurve>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref AnimationCurve? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, ref AnimationCurve? value)
		{
		}
	}
}
