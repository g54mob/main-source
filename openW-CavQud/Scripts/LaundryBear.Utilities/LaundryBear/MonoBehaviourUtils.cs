using System;
using System.Collections;
using UnityEngine;

namespace LaundryBear
{
	public static class MonoBehaviourUtils
	{
		public static bool TryDestroyComponent<T>(this Transform transform) where T : UnityEngine.Object
		{
			T component = transform.GetComponent<T>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
				return true;
			}
			return false;
		}

		public static Coroutine ExecuteAfterTime(this MonoBehaviour behaviour, float time, Func<float> timeFunc, Action onComplete)
		{
			return behaviour.StartCoroutine(ExecuteAfterCoroutine(time, timeFunc, onComplete));
		}

		public static Coroutine ExecuteAfterTime(this MonoBehaviour behaviour, float time, Action onComplete)
		{
			return behaviour.StartCoroutine(ExecuteAfterCoroutine(time, () => Time.deltaTime, onComplete));
		}

		public static Coroutine ExecuteOverTime(this MonoBehaviour behaviour, float time, Func<float> timeFunc, Action<float> onUpdate)
		{
			return behaviour.StartCoroutine(ExecuteOverCoroutine(time, timeFunc, onUpdate));
		}

		public static Coroutine ExecuteOverTime(this MonoBehaviour behaviour, float time, Action<float> onUpdate)
		{
			return behaviour.StartCoroutine(ExecuteOverCoroutine(time, () => Time.deltaTime, onUpdate));
		}

		private static IEnumerator ExecuteAfterCoroutine(float time, Func<float> timeFunc, Action onComplete)
		{
			float timer = 0f;
			while (timer < time)
			{
				timer = Mathf.Clamp(timer + timeFunc(), 0f, time);
				yield return null;
			}
			onComplete();
		}

		private static IEnumerator ExecuteOverCoroutine(float time, Func<float> timeFunc, Action<float> onUpdate)
		{
			float timer = 0f;
			while (timer < time)
			{
				timer = Mathf.Clamp(timer + timeFunc(), 0f, time);
				onUpdate(timer / time);
				yield return null;
			}
		}
	}
}
