using UnityEngine;

namespace MoreMountains.Tools
{
	public static class MMAnimationCurves
	{
		public static AnimationCurve LerpAnimationCurves(AnimationCurve a, AnimationCurve b, float t, int samplePoints = 20)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			float a2 = Mathf.Min(a.keys[0].time, b.keys[0].time);
			float b2 = Mathf.Max(a.keys[a.length - 1].time, b.keys[b.length - 1].time);
			Keyframe[] array = new Keyframe[samplePoints + 1];
			for (int i = 0; i <= samplePoints; i++)
			{
				float time = Mathf.Lerp(a2, b2, (float)i / (float)samplePoints);
				float a3 = a.Evaluate(time);
				float b3 = b.Evaluate(time);
				float value = Mathf.Lerp(a3, b3, t);
				array[i] = new Keyframe(time, value);
			}
			animationCurve.keys = array;
			for (int j = 0; j < animationCurve.keys.Length; j++)
			{
				animationCurve.SmoothTangents(j, 0f);
			}
			return animationCurve;
		}
	}
}
