using System.Collections;
using Events;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	public abstract class NotificationWithDuration : MonoBehaviour
	{
		[SerializeField]
		protected CanvasGroup _canvasGroup;

		[SerializeField]
		protected UIMenuManagerLocator _menuManagerLocator;

		[Header("Behaviour")]
		[SerializeField]
		private BaseEvent _hideHUDUIEvent;

		[SerializeField]
		private BaseEvent _showHUDUIEvent;

		private float _duration = 10f;

		protected bool _isOnTimer;

		protected bool _isPaused;

		private Coroutine _timerCoroutine;

		private void Awake()
		{
			_hideHUDUIEvent.Register(OnHideHUDUI);
			_showHUDUIEvent.Register(OnShowHUDUI);
		}

		protected virtual void OnDestroy()
		{
			_hideHUDUIEvent.UnRegister(OnHideHUDUI);
			_showHUDUIEvent.UnRegister(OnShowHUDUI);
		}

		public virtual void Show()
		{
			AnimateIn();
		}

		protected abstract void AnimateIn();

		protected void SetupTimer(float duration)
		{
			if (duration > 0f)
			{
				_duration = duration;
				_isOnTimer = true;
			}
		}

		protected void StartTimer()
		{
			if (_isOnTimer)
			{
				KillCoroutine();
				_timerCoroutine = StartCoroutine(Timer());
			}
		}

		private void KillCoroutine()
		{
			if (_timerCoroutine != null)
			{
				StopCoroutine(_timerCoroutine);
				_timerCoroutine = null;
			}
		}

		private IEnumerator Timer()
		{
			float elapsedTime = 0f;
			while (elapsedTime < _duration)
			{
				bool flag = _menuManagerLocator == null || !_menuManagerLocator.UIMenuManager.IsCurrentlyShowingAnyMenuOrModal();
				if (!_isPaused && flag)
				{
					elapsedTime += Time.deltaTime;
				}
				yield return null;
			}
			RemoveNotification();
		}

		protected virtual void RemoveNotification()
		{
			KillCoroutine();
		}

		private void OnShowHUDUI()
		{
			_canvasGroup.alpha = 1f;
			if (_isOnTimer)
			{
				_isPaused = false;
			}
		}

		private void OnHideHUDUI()
		{
			_canvasGroup.alpha = 0f;
			if (_isOnTimer)
			{
				_isPaused = true;
			}
		}
	}
}
