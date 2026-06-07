using System;
using System.Threading;
using R3.Triggers;
using UnityEngine;

namespace R3
{
	public static class MonoBehaviourExtensions
	{
		internal static CancellationToken GetDestroyCancellationToken(this MonoBehaviour value)
		{
			return value.destroyCancellationToken;
		}

		public static T AddTo<T>(this T disposable, GameObject gameObject) where T : IDisposable
		{
			if (gameObject == null)
			{
				disposable.Dispose();
				return disposable;
			}
			ObservableDestroyTrigger observableDestroyTrigger = gameObject.GetComponent<ObservableDestroyTrigger>();
			if (observableDestroyTrigger == null)
			{
				observableDestroyTrigger = gameObject.AddComponent<ObservableDestroyTrigger>();
			}
			if (!observableDestroyTrigger.IsActivated && !observableDestroyTrigger.gameObject.activeInHierarchy)
			{
				observableDestroyTrigger.TryStartActivateMonitoring();
			}
			observableDestroyTrigger.AddDisposableOnDestroy(disposable);
			return disposable;
		}

		public static T AddTo<T>(this T disposable, Component gameObjectComponent) where T : IDisposable
		{
			if (gameObjectComponent == null)
			{
				disposable.Dispose();
				return disposable;
			}
			if (gameObjectComponent.gameObject.activeInHierarchy && gameObjectComponent is MonoBehaviour monoBehaviour)
			{
				disposable.RegisterTo(monoBehaviour.destroyCancellationToken);
				return disposable;
			}
			return disposable.AddTo(gameObjectComponent.gameObject);
		}
	}
}
