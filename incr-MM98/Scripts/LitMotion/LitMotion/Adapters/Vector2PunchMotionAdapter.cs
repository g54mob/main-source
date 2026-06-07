using System.Runtime.InteropServices;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct Vector2PunchMotionAdapter : IMotionAdapter<Vector2, PunchOptions>
	{
		public Vector2 Evaluate(ref Vector2 startValue, ref Vector2 endValue, ref PunchOptions options, in MotionEvaluationContext context)
		{
			VibrationHelper.EvaluateStrength(in endValue, in options.Frequency, in options.DampingRatio, in context.Progress, out var result);
			return startValue + result;
		}

		Vector2 IMotionAdapter<Vector2, PunchOptions>.Evaluate(ref Vector2 startValue, ref Vector2 endValue, ref PunchOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
