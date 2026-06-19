using System;
using System.Collections;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	public static class MyCoroutines
	{
		private static CoroutineOwner _coroutineOwner;

		private static CoroutineOwner CoroutineOwner
		{
			get
			{
				if (_coroutineOwner != null)
				{
					return _coroutineOwner;
				}
				GameObject gameObject = new GameObject("Static Coroutine Owner");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				_coroutineOwner = gameObject.AddComponent<CoroutineOwner>();
				return _coroutineOwner;
			}
		}

		public static Coroutine StartCoroutine(this IEnumerator coroutine)
		{
			return CoroutineOwner.StartCoroutine(coroutine);
		}

		public static Coroutine StartNext(this Coroutine coroutine, IEnumerator nextCoroutine)
		{
			return StartNextCoroutine(coroutine, nextCoroutine).StartCoroutine();
		}

		public static Coroutine OnComplete(this Coroutine coroutine, Action onComplete)
		{
			return OnCompleteCoroutine(coroutine, onComplete).StartCoroutine();
		}

		public static void StopCoroutine(Coroutine coroutine)
		{
			CoroutineOwner.StopCoroutine(coroutine);
		}

		public static void StopAllCoroutines()
		{
			CoroutineOwner.StopAllCoroutines();
		}

		public static CoroutineGroup CreateGroup(MonoBehaviour owner = null)
		{
			return new CoroutineGroup((owner != null) ? owner : CoroutineOwner);
		}

		private static IEnumerator StartNextCoroutine(Coroutine coroutine, IEnumerator nextCoroutine)
		{
			yield return coroutine;
			yield return nextCoroutine.StartCoroutine();
		}

		private static IEnumerator OnCompleteCoroutine(Coroutine coroutine, Action onComplete)
		{
			yield return coroutine;
			onComplete?.Invoke();
		}
	}
}
