using System.Runtime.InteropServices;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct ColorMotionAdapter : IMotionAdapter<Color, NoOptions>
	{
		public Color Evaluate(ref Color startValue, ref Color endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Color.LerpUnclamped(startValue, endValue, context.Progress);
		}

		Color IMotionAdapter<Color, NoOptions>.Evaluate(ref Color startValue, ref Color endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
