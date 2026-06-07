using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct FixedString128BytesMotionAdapter : IMotionAdapter<FixedString128Bytes, StringOptions>
	{
		public FixedString128Bytes Evaluate(ref FixedString128Bytes startValue, ref FixedString128Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			FixedString128Bytes start = startValue;
			FixedString128Bytes end = endValue;
			FixedString64Bytes customScrambleChars = options.CustomScrambleChars;
			Random randomState = RandomHelper.Create(options.RandomSeed, context.Time);
			FixedStringHelper.Interpolate(ref start, ref end, context.Progress, options.ScrambleMode, options.RichTextEnabled, ref randomState, ref customScrambleChars, out var result);
			return result;
		}

		FixedString128Bytes IMotionAdapter<FixedString128Bytes, StringOptions>.Evaluate(ref FixedString128Bytes startValue, ref FixedString128Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
