using System;
using System.Collections;
using UnityEngine;

namespace MateoRyhr
{
	public static class Lerper
	{
		public static float LerpFloat(float a, float b, float t)
		{
			return a + (b - a) * t;
		}

		public static void LerpFloat(this MonoBehaviour mb, float start, float target, float lerpDuration, Action<float> action, bool fixedUpdate, AnimationCurve curve = null)
		{
			mb.StartCoroutine(LerpFloatRoutine(start, target, lerpDuration, action, fixedUpdate, curve));
		}

		public static void LerpFloatScaledDeltaTime(this MonoBehaviour mb, float start, float target, float lerpDuration, Action<float> action, AnimationCurve curve = null)
		{
			mb.StartCoroutine(LerpFloatScaledDeltaTimeRoutine(start, target, lerpDuration, action, curve));
		}

		public static void LerpVector(this MonoBehaviour mb, Vector3 start, Vector3 target, float lerpDuration, Action<Vector3> action, bool fixedUpdate, bool timeScaled, AnimationCurve curve = null)
		{
			mb.StartCoroutine(LerpVectorRoutine(start, target, lerpDuration, action, fixedUpdate, timeScaled, curve));
		}

		public static void LerpFloatFollowingCurve(this MonoBehaviour mb, float totalTime, AnimationCurve curve, Action<float> SetValue, bool fixedUpdate)
		{
			mb.StartCoroutine(LerpFloatFollowingCurve(totalTime, curve, SetValue, fixedUpdate));
		}

		private static IEnumerator LerpFloatRoutine(float start, float target, float lerpDuration, Action<float> action, bool fixedUpdate, AnimationCurve curve = null)
		{
			float timeElapsed = 0f;
			while (timeElapsed < lerpDuration)
			{
				float t = curve?.Evaluate(timeElapsed / lerpDuration) ?? (timeElapsed / lerpDuration);
				float obj = Mathf.Lerp(start, target, t);
				action(obj);
				if (fixedUpdate)
				{
					timeElapsed += Time.fixedDeltaTime;
					yield return new WaitForFixedUpdate();
				}
				else
				{
					timeElapsed += Time.deltaTime;
					yield return null;
				}
			}
			action(target);
		}

		private static IEnumerator LerpFloatScaledDeltaTimeRoutine(float start, float target, float lerpDuration, Action<float> action, AnimationCurve curve = null)
		{
			float timeElapsed = 0f;
			lerpDuration /= Time.timeScale;
			while (timeElapsed < lerpDuration)
			{
				float t = curve?.Evaluate(timeElapsed / lerpDuration) ?? (timeElapsed / lerpDuration);
				float obj = Mathf.Lerp(start, target, t);
				action(obj);
				timeElapsed += Time.deltaTime / Time.timeScale;
				yield return new WaitForSeconds(Time.deltaTime);
			}
			action(target);
		}

		private static IEnumerator LerpVectorRoutine(Vector3 start, Vector3 target, float lerpDuration, Action<Vector3> action, bool fixedUpdate, bool timeScaled, AnimationCurve curve = null)
		{
			float timeElapsed = 0f;
			float lerpDurationRealtime = lerpDuration;
			while (timeElapsed < lerpDuration)
			{
				lerpDuration = (timeScaled ? (lerpDurationRealtime / Time.timeScale) : lerpDurationRealtime);
				float t = curve?.Evaluate(timeElapsed / lerpDuration) ?? (timeElapsed / lerpDuration);
				Vector3 obj = Vector3.Lerp(start, target, t);
				action(obj);
				if (fixedUpdate)
				{
					timeElapsed += (timeScaled ? (Time.fixedDeltaTime / Time.timeScale) : Time.fixedDeltaTime);
					yield return new WaitForFixedUpdate();
				}
				else
				{
					timeElapsed += (timeScaled ? (Time.deltaTime / Time.timeScale) : Time.deltaTime);
					yield return null;
				}
			}
		}

		private static IEnumerator LerpFloatFollowingCurve(float totalTime, AnimationCurve curve, Action<float> SetValue, bool fixedUpdate)
		{
			float timeElapsed = 0f;
			float obj;
			while (timeElapsed < totalTime)
			{
				obj = curve.Evaluate(timeElapsed / totalTime);
				SetValue(obj);
				if (fixedUpdate)
				{
					timeElapsed += Time.fixedDeltaTime;
					yield return new WaitForFixedUpdate();
				}
				else
				{
					timeElapsed += Time.deltaTime;
					yield return null;
				}
			}
			obj = curve.Evaluate(1f);
			SetValue(obj);
		}
	}
}
