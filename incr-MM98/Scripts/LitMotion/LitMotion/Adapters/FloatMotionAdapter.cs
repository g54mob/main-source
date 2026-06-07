using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct FloatMotionAdapter : IMotionAdapter<float, NoOptions>
	{
		public float Evaluate(ref float startValue, ref float endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return math.lerp(startValue, endValue, context.Progress);
		}

		float IMotionAdapter<float, NoOptions>.Evaluate(ref float startValue, ref float endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
