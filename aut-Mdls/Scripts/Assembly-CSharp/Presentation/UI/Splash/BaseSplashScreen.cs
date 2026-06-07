using System;
using System.Collections;
using DG.Tweening;
using Data.Variables;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Presentation.UI.Splash
{
	public class BaseSplashScreen : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[Header("UI Elements")]
		[SerializeField]
		private CanvasGroup _screen;

		[SerializeField]
		private CanvasGroup _content;

		[SerializeField]
		private float _duration = 5f;

		[SerializeField]
		private bool _fadeIn = true;

		[SerializeField]
		private bool _fadeOut;

		[Header("Skipping")]
		[SerializeField]
		private bool _skippable = true;

		[SerializeField]
		private bool _firstTimeSkippable;

		[SerializeField]
		private InputActionReference _skipInput;

		[SerializeField]
		protected string _playerPrefsKey;

		[SerializeField]
		protected FloatVariableSO _masterVolume;

		private Coroutine _durationCoroutine;

		private bool _allowedToSkip;

		private bool _hasSkipped;

		private int _orderIndex;

		public Action<int> OnSplashCompleted = delegate
		{
		};

		public virtual void Initialize(int orderIndex)
		{
			base.gameObject.SetActive(value: false);
			_orderIndex = orderIndex;
			if (!_fadeIn)
			{
				base.gameObject.SetActive(value: true);
				_screen.alpha = 1f;
			}
			if (_skippable)
			{
				_skipInput.action.performed += SkipInputActionPerformed;
			}
		}

		public virtual void Show()
		{
			if (_fadeIn)
			{
				base.gameObject.SetActive(value: true);
				_screen.DOFade(1f, 0.3f).From(0f);
				_content.DOFade(1f, 0.5f).From(0f).SetDelay(1f)
					.OnComplete(OnContentShowing);
			}
			else
			{
				_content.DOFade(1f, 0.1f).From(0f).OnComplete(OnContentShowing);
			}
			if (_duration > 0f)
			{
				_durationCoroutine = StartCoroutine(WaitToProceed());
			}
		}

		protected virtual void OnContentShowing()
		{
			_allowedToSkip = true;
		}

		private IEnumerator WaitToProceed()
		{
			yield return new WaitForSeconds(_duration);
			SplashComplete();
		}

		protected virtual void SplashComplete()
		{
			if (_durationCoroutine != null)
			{
				StopCoroutine(_durationCoroutine);
			}
			if (_skippable)
			{
				_skipInput.action.performed -= SkipInputActionPerformed;
				PlayerPrefs.SetInt(_playerPrefsKey, 1);
			}
			if (_fadeOut)
			{
				_content.DOFade(0f, 0.2f).OnComplete(OnFadeOutComplete);
			}
			else
			{
				OnFadeOutComplete();
			}
		}

		private void OnFadeOutComplete()
		{
			OnSplashCompleted(_orderIndex);
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		private bool TryCanSkip()
		{
			if (_hasSkipped)
			{
				return false;
			}
			if (base.gameObject.activeSelf && _skippable && _allowedToSkip)
			{
				if (_firstTimeSkippable || PlayerPrefs.GetInt(_playerPrefsKey) == 1)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (TryCanSkip())
			{
				_hasSkipped = true;
				SplashComplete();
			}
		}

		private void SkipInputActionPerformed(InputAction.CallbackContext obj)
		{
			if (TryCanSkip())
			{
				_hasSkipped = true;
				SplashComplete();
			}
		}
	}
}
