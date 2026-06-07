using System;
using System.Collections;
using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Motorways.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Popups
{
	[RequireComponent(typeof(DelegateCanvasGroup))]
	public class BasePopup : MonoBehaviour, IReusable, ICreatedInScopeHandler, IReleasedFromScopeHandler, MenuNavigation.IObserver, InputState.IObserver
	{
		[Dependency]
		protected IScope appScope;

		[Dependency]
		protected readonly PopupParent _popupParent;

		[Dependency]
		protected MenuNavigation navigation;

		[Dependency]
		protected InputState inputState;

		[Dependency]
		private LocaleDatabase _localeDatabase;

		private readonly List<VariableDeviceSelectable> _allButtons = new List<VariableDeviceSelectable>();

		[SerializeField]
		private float _tweenDuration;

		[SerializeField]
		private VariableDeviceSelectable _firstFocus;

		protected DelegateCanvasGroup _delegateCanvasGroup;

		private Coroutine _tweenCoroutine;

		private readonly List<LocalizedTextUI> _allLocalizedText = new List<LocalizedTextUI>();

		protected bool isFullyVisible;

		public bool IsFullyVisible => isFullyVisible;

		private void Awake()
		{
			_delegateCanvasGroup = GetComponent<DelegateCanvasGroup>();
		}

		public void OnCreatedInScope(IScope scope)
		{
			base.transform.SetParent(_popupParent.transform, worldPositionStays: false);
			_delegateCanvasGroup.SetInteractable(isInteractable: false);
			_delegateCanvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			_delegateCanvasGroup.Alpha = 0f;
			isFullyVisible = false;
			RegisterAllLocalizedTextChildren();
		}

		public void OnReleasedFromScope(IScope scope)
		{
			UnregisterLocalizedTextChildren();
		}

		public virtual bool CanBeDismissed()
		{
			return true;
		}

		public virtual void OnOpened(float delay)
		{
			appScope.Get<IInputState>().BlockAllInput = true;
			OnReceivedFocus();
			TweenInOut(isIn: true, OnTweenComplete, delay);
			void OnTweenComplete()
			{
				appScope.Get<IInputState>().BlockAllInput = false;
				isFullyVisible = true;
			}
		}

		public virtual void OnClosed(Action onComplete = null, bool skipTransition = false)
		{
			OnLostFocus();
			isFullyVisible = false;
			TweenInOut(isIn: false, onComplete, 0f, skipTransition);
		}

		public void OnReceivedFocus()
		{
			RegisterButtons();
			_delegateCanvasGroup.SetInteractable(isInteractable: true);
			_delegateCanvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
		}

		public void OnLostFocus()
		{
			UnregisterButtons();
			_delegateCanvasGroup.SetInteractable(isInteractable: false);
			_delegateCanvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
		}

		public virtual void OnPopupClosed()
		{
		}

		private void TweenInOut(bool isIn, Action onTweenComplete, float delay = 0f, bool skipTransition = false)
		{
			_tweenCoroutine = StartCoroutine(TweenInOutCoroutine(isIn, onTweenComplete, delay, skipTransition));
		}

		private IEnumerator TweenInOutCoroutine(bool isIn, Action onTweenComplete, float delay, bool skipTransition)
		{
			if (!skipTransition)
			{
				yield return new WaitForSeconds(delay);
			}
			float time = 0f;
			float startAlpha = _delegateCanvasGroup.Alpha;
			float targetAlpha = (isIn ? 1 : 0);
			if (!skipTransition)
			{
				while (time < _tweenDuration)
				{
					float t = time / _tweenDuration;
					_delegateCanvasGroup.Alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
					time += Time.deltaTime;
					yield return null;
				}
			}
			_delegateCanvasGroup.Alpha = targetAlpha;
			if (!isIn)
			{
				OnPopupClosed();
			}
			onTweenComplete?.Invoke();
			_tweenCoroutine = null;
		}

		protected virtual void RegisterAllLocalizedTextChildren()
		{
			UnregisterLocalizedTextChildren();
			GetComponentsInChildren(includeInactive: true, _allLocalizedText);
			for (int i = 0; i < _allLocalizedText.Count; i++)
			{
				if (!_allLocalizedText[i].isInitialized)
				{
					_allLocalizedText[i].HandleParentAllocated(appScope);
				}
				_localeDatabase.AddLocalizedObject(_allLocalizedText[i]);
			}
		}

		protected virtual void UnregisterLocalizedTextChildren()
		{
			for (int i = 0; i < _allLocalizedText.Count; i++)
			{
				_allLocalizedText[i].Unregister();
				_localeDatabase.RemoveLocalizedObject(_allLocalizedText[i]);
			}
			_allLocalizedText.Clear();
		}

		private void RegisterButtons()
		{
			GetComponentsInChildren(includeInactive: true, _allButtons);
			for (int i = 0; i < _allButtons.Count; i++)
			{
				if (!_allButtons[i].IsInitialized)
				{
					_allButtons[i].Initialize(appScope);
				}
			}
			if (Diagnostics.Verify(_firstFocus != null) && appScope.Get<InputState>().CurrentInputTypeRequiresFocus)
			{
				navigation.SetNewFocus(_firstFocus);
			}
			navigation.Subscribe(this);
			inputState.Subscribe(this);
		}

		public virtual void UnregisterButtons()
		{
			foreach (VariableDeviceSelectable allButton in _allButtons)
			{
				allButton.Unregister();
			}
			_allButtons.Clear();
			navigation.Unsubscribe(this);
			inputState.Unsubscribe(this);
		}

		public virtual void Reset()
		{
			_allButtons.Clear();
			isFullyVisible = false;
		}

		public void OnMoveCursorWithNullFocus()
		{
			navigation.SetNewFocus(_firstFocus);
		}

		public void OnMoveCursor(Selectable currentFocus, MoveDirection direction)
		{
		}

		public void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			if (InputState.DeviceInputTypeRequiresFocus(newInputType))
			{
				navigation.SetNewFocus(_firstFocus);
			}
			else
			{
				navigation.ClearFocus(allowAutomaticFocus: false);
			}
		}
	}
}
