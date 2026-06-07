using System.Collections;
using UnityEngine;

public class Tweener : MonoBehaviour
{
	private static Tweener _instance;

	public static Tweener Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameObject().AddComponent<Tweener>();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		if (!(_instance == null) && !(_instance == this))
		{
			Object.Destroy(base.gameObject);
		}
	}

	public static Coroutine StartTween(float duration, Easing easing, bool useUnscaledTime = false, params IPropertyTweener[] propertyTweeners)
	{
		return Instance.StartCoroutine(TweenRoutine(duration, EasingFunctions.Get(easing), useUnscaledTime, propertyTweeners));
	}

	public static Coroutine StartTween(float duration, EasingFunctions.EasingFunction easingFunction, bool useUnscaledTime = false, params IPropertyTweener[] propertyTweeners)
	{
		return Instance.StartCoroutine(TweenRoutine(duration, easingFunction, useUnscaledTime, propertyTweeners));
	}

	public static IEnumerator TweenRoutine(float duration, Easing easing, bool useUnscaledTime = false, params IPropertyTweener[] propertyTweeners)
	{
		return TweenRoutine(duration, EasingFunctions.Get(easing), useUnscaledTime, propertyTweeners);
	}

	public static IEnumerator TweenRoutine(float duration, EasingFunctions.EasingFunction easingFunction, bool useUnscaledTime = false, params IPropertyTweener[] propertyTweeners)
	{
		if (propertyTweeners.IsNullOrEmpty())
		{
			yield break;
		}
		int propertyTweenerCount = propertyTweeners.Length;
		if (duration <= 0f)
		{
			for (int i = 0; i < propertyTweenerCount; i++)
			{
				propertyTweeners[i].UpdateProgress(1f);
			}
			yield break;
		}
		float time = 0f;
		while (time < duration)
		{
			yield return null;
			time = Mathf.Min(duration, time + (useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime));
			float progress = easingFunction(0f, 1f, time, duration);
			for (int j = 0; j < propertyTweenerCount; j++)
			{
				propertyTweeners[j].UpdateProgress(progress);
			}
		}
	}

	public static void StopTween(Coroutine coroutine)
	{
		if (coroutine != null)
		{
			Instance?.StopCoroutine(coroutine);
		}
	}
}
