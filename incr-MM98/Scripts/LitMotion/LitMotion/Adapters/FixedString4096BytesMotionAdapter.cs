using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct FixedString4096BytesMotionAdapter : IMotionAdapter<FixedString4096Bytes, StringOptions>
	{
		public FixedString4096Bytes Evaluate(ref FixedString4096Bytes startValue, ref FixedString4096Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			FixedString4096Bytes start = startValue;
			FixedString4096Bytes end = endValue;
			FixedString64Bytes customScrambleChars = options.CustomScrambleChars;
			Random randomState = RandomHelper.Create(options.RandomSeed, context.Time);
			FixedStringHelper.Interpolate(ref start, ref end, context.Progress, options.ScrambleMode, options.RichTextEnabled, ref randomState, ref customScrambleChars, out var result);
			return result;
		}

		FixedString4096Bytes IMotionAdapter<FixedString4096Bytes, StringOptions>.Evaluate(ref FixedString4096Bytes startValue, ref FixedString4096Bytes endValue, ref StringOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
