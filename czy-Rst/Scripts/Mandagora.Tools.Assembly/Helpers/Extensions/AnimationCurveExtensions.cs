using UnityEngine;

namespace Helpers.Extensions
{
	public static class AnimationCurveExtensions
	{
		public static AnimationCurve GetInvertedCurve(this AnimationCurve sourceCurve)
		{
			Keyframe[] keys = sourceCurve.keys;
			Keyframe[] array = new Keyframe[keys.Length];
			for (int i = 0; i < keys.Length; i++)
			{
				float value = keys[i].value;
				float time = keys[i].time;
				array[i] = new Keyframe(value, time);
				if (keys[i].inTangent != 0f)
				{
					array[i].inTangent = 1f / keys[i].inTangent;
				}
				if (keys[i].outTangent != 0f)
				{
					array[i].outTangent = 1f / keys[i].outTangent;
				}
			}
			return new AnimationCurve(array);
		}
	}
}
