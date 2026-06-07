using System.Runtime.InteropServices;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct Vector3MotionAdapter : IMotionAdapter<Vector3, NoOptions>
	{
		public Vector3 Evaluate(ref Vector3 startValue, ref Vector3 endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Vector3.LerpUnclamped(startValue, endValue, context.Progress);
		}

		Vector3 IMotionAdapter<Vector3, NoOptions>.Evaluate(ref Vector3 startValue, ref Vector3 endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
