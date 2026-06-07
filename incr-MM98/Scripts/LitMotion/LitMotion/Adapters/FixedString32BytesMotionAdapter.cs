using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct FixedString32BytesMotionAdapter : IMotionAdapter<FixedString32Bytes, StringOptions>
	{
		public FixedString32Bytes Evaluate(ref FixedString32Bytes startValue, ref FixedString32Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			FixedString32Bytes start = startValue;
			FixedString32Bytes end = endValue;
			FixedString64Bytes customScrambleChars = options.CustomScrambleChars;
			Random randomState = RandomHelper.Create(options.RandomSeed, context.Time);
			FixedStringHelper.Interpolate(ref start, ref end, context.Progress, options.ScrambleMode, options.RichTextEnabled, ref randomState, ref customScrambleChars, out var result);
			return result;
		}

		FixedString32Bytes IMotionAdapter<FixedString32Bytes, StringOptions>.Evaluate(ref FixedString32Bytes startValue, ref FixedString32Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
