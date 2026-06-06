using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct DoubleMotionAdapter : IMotionAdapter<double, NoOptions>
	{
		public double Evaluate(ref double startValue, ref double endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return math.lerp(startValue, endValue, context.Progress);
		}

		double IMotionAdapter<double, NoOptions>.Evaluate(ref double startValue, ref double endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
