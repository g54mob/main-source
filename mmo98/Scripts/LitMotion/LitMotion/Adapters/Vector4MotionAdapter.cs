using System.Runtime.InteropServices;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct Vector4MotionAdapter : IMotionAdapter<Vector4, NoOptions>
	{
		public Vector4 Evaluate(ref Vector4 startValue, ref Vector4 endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Vector4.LerpUnclamped(startValue, endValue, context.Progress);
		}

		Vector4 IMotionAdapter<Vector4, NoOptions>.Evaluate(ref Vector4 startValue, ref Vector4 endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
