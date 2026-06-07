using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct Vector3ShakeMotionAdapter : IMotionAdapter<Vector3, ShakeOptions>
	{
		public Vector3 Evaluate(ref Vector3 startValue, ref Vector3 endValue, ref ShakeOptions options, in MotionEvaluationContext context)
		{
			VibrationHelper.EvaluateStrength(in endValue, in options.Frequency, in options.DampingRatio, in context.Progress, out var result);
			float3 float5 = RandomHelper.NextFloat3(options.RandomSeed, context.Time, new float3(-1f, -1f, -1f), new float3(1f, 1f, 1f));
			return startValue + new Vector3(result.x * float5.x, result.y * float5.y, result.z * float5.z);
		}

		Vector3 IMotionAdapter<Vector3, ShakeOptions>.Evaluate(ref Vector3 startValue, ref Vector3 endValue, ref ShakeOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
