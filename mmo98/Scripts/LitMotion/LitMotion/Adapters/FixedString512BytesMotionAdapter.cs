using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct FixedString512BytesMotionAdapter : IMotionAdapter<FixedString512Bytes, StringOptions>
	{
		public FixedString512Bytes Evaluate(ref FixedString512Bytes startValue, ref FixedString512Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			FixedString512Bytes start = startValue;
			FixedString512Bytes end = endValue;
			FixedString64Bytes customScrambleChars = options.CustomScrambleChars;
			Random randomState = RandomHelper.Create(options.RandomSeed, context.Time);
			FixedStringHelper.Interpolate(ref start, ref end, context.Progress, options.ScrambleMode, options.RichTextEnabled, ref randomState, ref customScrambleChars, out var result);
			return result;
		}

		FixedString512Bytes IMotionAdapter<FixedString512Bytes, StringOptions>.Evaluate(ref FixedString512Bytes startValue, ref FixedString512Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
