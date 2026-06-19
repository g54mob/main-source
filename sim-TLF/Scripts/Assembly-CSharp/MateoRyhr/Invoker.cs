using System;
using System.Collections;
using UnityEngine;

namespace MateoRyhr
{
	public static class Invoker
	{
		public static void Invoke(this MonoBehaviour mb, Action f, float delay)
		{
			mb.StartCoroutine(InvokeRoutine(f, delay));
		}

		private static IEnumerator InvokeRoutine(Action f, float delay)
		{
			yield return new WaitForSecondsRealtime(delay);
			f();
		}

		public static void InvokeScaledDeltaTime(this MonoBehaviour mb, Action f, float delay)
		{
			mb.StartCoroutine(InvokeRoutineScaledDeltaTime(f, delay));
		}

		private static IEnumerator InvokeRoutineScaledDeltaTime(Action f, float delay)
		{
			while (Time.timeScale == 0f)
			{
				yield return null;
			}
			float num;
			delay = (num = delay / Mathf.Clamp(Time.timeScale, 0.01f, float.PositiveInfinity));
			float delayInScale = num;
			float timeElapsed = 0f;
			while (timeElapsed < delayInScale)
			{
				while (Time.timeScale == 0f)
				{
					yield return null;
				}
				timeElapsed += Time.deltaTime / Time.timeScale;
				yield return null;
			}
			f();
		}

		public static void InvokeRepeatingScaledDeltaTime(this MonoBehaviour mb, Action f, float delay)
		{
			mb.StartCoroutine(mb.InvokeRepeatingRoutineScaledDeltaTime(f, delay));
		}

		private static IEnumerator InvokeRepeatingRoutineScaledDeltaTime(this MonoBehaviour mb, Action f, float delay)
		{
			while (Time.timeScale == 0f)
			{
				yield return null;
			}
			float num;
			delay = (num = delay / Mathf.Clamp(Time.timeScale, 0.01f, float.PositiveInfinity));
			float delayInScale = num;
			float timeElapsed = 0f;
			while (timeElapsed < delayInScale)
			{
				if (Time.timeScale > 0f)
				{
					timeElapsed += Time.deltaTime / Time.timeScale;
				}
				yield return null;
			}
			f();
			mb.StartCoroutine(mb.InvokeRepeatingRoutineScaledDeltaTime(f, delay));
		}

		public static void InvokeRepeating(this MonoBehaviour mb, Action f, float delay)
		{
			mb.StartCoroutine(mb.InvokeRepeatingRoutine(f, delay));
		}

		private static IEnumerator InvokeRepeatingRoutine(this MonoBehaviour mb, Action f, float delay)
		{
			yield return new WaitForSecondsRealtime(delay);
			f();
			mb.StartCoroutine(mb.InvokeRepeatingRoutine(f, delay));
		}
	}
}
