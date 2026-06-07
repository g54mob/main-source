using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct FixedString64BytesMotionAdapter : IMotionAdapter<FixedString64Bytes, StringOptions>
	{
		public FixedString64Bytes Evaluate(ref FixedString64Bytes startValue, ref FixedString64Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			FixedString64Bytes start = startValue;
			FixedString64Bytes end = endValue;
			FixedString64Bytes customScrambleChars = options.CustomScrambleChars;
			Random randomState = RandomHelper.Create(options.RandomSeed, context.Time);
			FixedStringHelper.Interpolate(ref start, ref end, context.Progress, options.ScrambleMode, options.RichTextEnabled, ref randomState, ref customScrambleChars, out var result);
			return result;
		}

		FixedString64Bytes IMotionAdapter<FixedString64Bytes, StringOptions>.Evaluate(ref FixedString64Bytes startValue, ref FixedString64Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
