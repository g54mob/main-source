using System.Runtime.InteropServices;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct FloatShakeMotionAdapter : IMotionAdapter<float, ShakeOptions>
	{
		public float Evaluate(ref float startValue, ref float endValue, ref ShakeOptions options, in MotionEvaluationContext context)
		{
			VibrationHelper.EvaluateStrength(in endValue, in options.Frequency, in options.DampingRatio, in context.Progress, out var result);
			float num = RandomHelper.NextFloat(options.RandomSeed, context.Time, -1f, 1f);
			return startValue + result * num;
		}

		float IMotionAdapter<float, ShakeOptions>.Evaluate(ref float startValue, ref float endValue, ref ShakeOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
