using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyBox
{
	public static class MyDelayedActions
	{
		public static Coroutine DelayedAction(float waitSeconds, Action action, bool unscaled = false)
		{
			return DelayedActionCoroutine(waitSeconds, action, unscaled).StartCoroutine();
		}

		public static void DelayedAction(Action action)
		{
			Coroutine().StartCoroutine();
			IEnumerator Coroutine()
			{
				yield return null;
				action?.Invoke();
			}
		}

		public static Coroutine DelayedAction(this MonoBehaviour invoker, float waitSeconds, Action action, bool unscaled = false)
		{
			return invoker.StartCoroutine(DelayedActionCoroutine(waitSeconds, action, unscaled));
		}

		public static Coroutine DelayedAction(this MonoBehaviour invoker, Action action)
		{
			return invoker.StartCoroutine(Coroutine());
			IEnumerator Coroutine()
			{
				yield return null;
				action?.Invoke();
			}
		}

		public static IEnumerator DelayedUiSelection(GameObject objectToSelect)
		{
			yield return null;
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(objectToSelect);
		}

		public static Coroutine DelayedUiSelection(this MonoBehaviour invoker, GameObject objectToSelect)
		{
			return invoker.StartCoroutine(DelayedUiSelection(objectToSelect));
		}

		private static IEnumerator DelayedActionCoroutine(float waitSeconds, Action action, bool unscaled = false)
		{
			if (unscaled)
			{
				yield return new WaitForSecondsRealtime(waitSeconds);
			}
			else
			{
				yield return new WaitForSeconds(waitSeconds);
			}
			action?.Invoke();
		}
	}
}
