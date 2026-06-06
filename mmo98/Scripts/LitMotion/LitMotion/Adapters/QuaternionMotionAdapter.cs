using System.Runtime.InteropServices;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct QuaternionMotionAdapter : IMotionAdapter<Quaternion, NoOptions>
	{
		public Quaternion Evaluate(ref Quaternion startValue, ref Quaternion endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Quaternion.LerpUnclamped(startValue, endValue, context.Progress);
		}

		Quaternion IMotionAdapter<Quaternion, NoOptions>.Evaluate(ref Quaternion startValue, ref Quaternion endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
