using System.Runtime.InteropServices;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct Vector3PunchMotionAdapter : IMotionAdapter<Vector3, PunchOptions>
	{
		public Vector3 Evaluate(ref Vector3 startValue, ref Vector3 endValue, ref PunchOptions options, in MotionEvaluationContext context)
		{
			VibrationHelper.EvaluateStrength(in endValue, in options.Frequency, in options.DampingRatio, in context.Progress, out var result);
			return startValue + result;
		}

		Vector3 IMotionAdapter<Vector3, PunchOptions>.Evaluate(ref Vector3 startValue, ref Vector3 endValue, ref PunchOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
