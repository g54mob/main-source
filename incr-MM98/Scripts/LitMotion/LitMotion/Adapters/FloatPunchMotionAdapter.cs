using System.Runtime.InteropServices;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct FloatPunchMotionAdapter : IMotionAdapter<float, PunchOptions>
	{
		public float Evaluate(ref float startValue, ref float endValue, ref PunchOptions options, in MotionEvaluationContext context)
		{
			VibrationHelper.EvaluateStrength(in endValue, in options.Frequency, in options.DampingRatio, in context.Progress, out var result);
			return startValue + result;
		}

		float IMotionAdapter<float, PunchOptions>.Evaluate(ref float startValue, ref float endValue, ref PunchOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
