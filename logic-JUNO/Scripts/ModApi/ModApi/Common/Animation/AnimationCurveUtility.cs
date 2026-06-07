using System;
using UnityEngine;

namespace ModApi.Common.Animation
{
	public static class AnimationCurveUtility
	{
		public static void SetTangents(this AnimationCurve animationCurve, AnimationCurveTangentMode tangentMode)
		{
			switch (tangentMode)
			{
			case AnimationCurveTangentMode.Constant:
				animationCurve.SetTangentsConstant();
				break;
			case AnimationCurveTangentMode.Linear:
				animationCurve.SetTangentsLinear();
				break;
			case AnimationCurveTangentMode.Auto:
				animationCurve.SetTangentsAuto();
				break;
			case AnimationCurveTangentMode.ClampedAuto:
				animationCurve.SetTangentsClampedAuto();
				break;
			case AnimationCurveTangentMode.Free:
				break;
			}
		}

		public static void SetTangentsAuto(this AnimationCurve curve)
		{
			Keyframe[] keys = curve.keys;
			keys.SetTangentsAuto();
			curve.keys = keys;
		}

		public static void SetTangentsAuto(this Keyframe[] keys)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				int num = i - 1;
				int num2 = i + 1;
				float num3 = 0f;
				float num4 = 0f;
				if (num < 0)
				{
					num4 = (keys[num2].value - keys[i].value) / (keys[num2].time - keys[i].time);
					num3 = num4;
				}
				else if (num2 >= keys.Length)
				{
					num3 = (keys[i].value - keys[num].value) / (keys[i].time - keys[num].time);
					num4 = num3;
				}
				else
				{
					num3 = (keys[i].value - keys[num].value) / (keys[i].time - keys[num].time);
					num4 = (keys[num2].value - keys[i].value) / (keys[num2].time - keys[i].time);
				}
				keys[i].inTangent = (num3 + num4) / 2f;
				keys[i].outTangent = keys[i].inTangent;
			}
		}

		public static void SetTangentsClampedAuto(this AnimationCurve curve)
		{
			Keyframe[] keys = curve.keys;
			keys.SetTangentsClampedAuto();
			curve.keys = keys;
		}

		public static void SetTangentsClampedAuto(this Keyframe[] keys)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				int num = i - 1;
				int num2 = i + 1;
				if (num < 0 || num2 >= keys.Length || (keys[num2].value <= keys[num].value && keys[i].value >= keys[num].value) || (keys[num2].value >= keys[num].value && keys[i].value <= keys[num].value))
				{
					keys[i].inTangent = 0f;
					keys[i].outTangent = 0f;
					continue;
				}
				float num3 = keys[num2].time - keys[num].time;
				float num4 = keys[num2].value - keys[num].value;
				float num5 = Mathf.Abs(num4);
				float num6 = num5 / 4f;
				float num7 = System.Math.Abs(keys[i].value - keys[num].value);
				float num8 = 0f;
				num8 = ((!(num7 >= num6)) ? Mathf.Lerp(num4 / num3, 0f, (num6 - num7) / num6) : ((!(num7 <= num5 - num6)) ? Mathf.Lerp(0f, num4 / num3, (num5 - num7) / num6) : (num4 / num3)));
				keys[i].inTangent = num8;
				keys[i].outTangent = num8;
			}
		}

		public static void SetTangentsConstant(this AnimationCurve curve)
		{
			Keyframe[] keys = curve.keys;
			keys.SetTangentsConstant();
			curve.keys = keys;
		}

		public static void SetTangentsConstant(this Keyframe[] keys)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				keys[i].inTangent = float.PositiveInfinity;
				keys[i].outTangent = float.PositiveInfinity;
			}
		}

		public static void SetTangentsLinear(this AnimationCurve curve)
		{
			Keyframe[] keys = curve.keys;
			keys.SetTangentsLinear();
			curve.keys = keys;
		}

		public static void SetTangentsLinear(this Keyframe[] keys)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				int num = i - 1;
				int num2 = i + 1;
				keys[i].inTangent = ((num < 0) ? 0f : ((keys[i].value - keys[num].value) / (keys[i].time - keys[num].time)));
				keys[i].outTangent = ((num2 >= keys.Length) ? 0f : ((keys[num2].value - keys[i].value) / (keys[num2].time - keys[i].time)));
			}
		}
	}
}
