using System.Collections;
using Events;
using Logic.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils.Analytics.IntervalHandlers
{
	public abstract class AbstractAnalyticsIntervalHandler : MonoBehaviour
	{
		[SerializeField]
		private float _intervalDurationSeconds = 60f;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _preLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _preResetPersistentSOsEvent;

		[SerializeField]
		private FactoryLoader _factoryLoader;

		private Coroutine _coroutine;

		private void Awake()
		{
			_finishedLoadingSaveEvent.Register(Initialize);
			_preLoadingSaveEvent.Register(HandleStartLoadingSave);
			_preResetPersistentSOsEvent.Register(HandlePreResetPersistentSO);
		}

		private void HandleStartLoadingSave()
		{
			if (_coroutine != null)
			{
				TrySendAnalytics();
				StopCoroutine(_coroutine);
			}
		}

		protected virtual void Initialize()
		{
			_coroutine = StartCoroutine(SendCoroutine());
		}

		private void HandlePreResetPersistentSO()
		{
			if (_factoryLoader.HasFinishedLoadingSave)
			{
				TrySendAnalytics();
			}
		}

		protected virtual void OnDestroy()
		{
			_finishedLoadingSaveEvent.UnRegister(Initialize);
			_preLoadingSaveEvent.UnRegister(HandleStartLoadingSave);
			_preResetPersistentSOsEvent.UnRegister(HandlePreResetPersistentSO);
			if (_coroutine != null)
			{
				StopCoroutine(_coroutine);
			}
		}

		private IEnumerator SendCoroutine()
		{
			while (true)
			{
				if (!SceneManager.GetActiveScene().name.Equals("Factory"))
				{
					yield return new WaitForSeconds(1f);
					continue;
				}
				yield return new WaitForSeconds(_intervalDurationSeconds);
				TrySendAnalytics();
			}
		}

		public abstract void TrySendAnalytics();
	}
}
