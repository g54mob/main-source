using System.Runtime.InteropServices;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct Vector2MotionAdapter : IMotionAdapter<Vector2, NoOptions>
	{
		public Vector2 Evaluate(ref Vector2 startValue, ref Vector2 endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Vector2.LerpUnclamped(startValue, endValue, context.Progress);
		}

		Vector2 IMotionAdapter<Vector2, NoOptions>.Evaluate(ref Vector2 startValue, ref Vector2 endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
