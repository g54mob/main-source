using UnityEngine;

namespace PajamaLlama.Extensions
{
	public static class AnimationCurveExtensions
	{
		public static bool TryEvaluate(this AnimationCurve animationCurve, float time, out float value)
		{
			if (time < 0f || animationCurve[animationCurve.length - 1].time < time)
			{
				value = 0f;
				return true;
			}
			value = animationCurve.Evaluate(time);
			return true;
		}
	}
}
