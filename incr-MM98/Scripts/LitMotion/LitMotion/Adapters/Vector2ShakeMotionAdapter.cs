using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct Vector2ShakeMotionAdapter : IMotionAdapter<Vector2, ShakeOptions>
	{
		public Vector2 Evaluate(ref Vector2 startValue, ref Vector2 endValue, ref ShakeOptions options, in MotionEvaluationContext context)
		{
			VibrationHelper.EvaluateStrength(in endValue, in options.Frequency, in options.DampingRatio, in context.Progress, out var result);
			float2 float5 = RandomHelper.NextFloat2(options.RandomSeed, context.Time, new float2(-1f, -1f), new float2(1f, 1f));
			return startValue + new Vector2(result.x * float5.x, result.y * float5.y);
		}

		Vector2 IMotionAdapter<Vector2, ShakeOptions>.Evaluate(ref Vector2 startValue, ref Vector2 endValue, ref ShakeOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
