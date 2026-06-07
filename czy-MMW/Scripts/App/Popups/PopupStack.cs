using System;
using System.Collections;
using System.Collections.Generic;
using Client;
using Factory;
using UnityEngine;

namespace Popups
{
	public class PopupStack
	{
		[Dependency]
		private readonly IScope _appScope;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private PopupParent _popupParent;

		[Dependency]
		private ScreenStack _screenStack;

		private readonly List<BasePopup> _popupStack = new List<BasePopup>();

		private IScreen _occludedScreen;

		private Coroutine _tweenCoroutine;

		private float _blurStrengthBefore = -1f;

		private float _blurRangeBefore = -1f;

		private float _blurOffsetBefore = -1f;

		public bool HasActivePopups => _popupStack.Count > 0;

		public bool HasVisiblePopups { get; private set; }

		public T PushConfirmationPopup<T>(StringId mainPromptStringId, Action onClosed, StringId additionalInfoStringId) where T : AbstractConfirmationPopup
		{
			T val = PushPopup<T>();
			val.Initialise(_appScope, mainPromptStringId, onClosed, additionalInfoStringId);
			return val;
		}

		public T PushConfirmationPopup<T>(StringId mainPromptStringId, Action onNoPressed, Action onYesPressed, StringId additionalInfoStringId) where T : AbstractConfirmationPopup
		{
			T val = PushPopup<T>();
			val.Initialise(_appScope, mainPromptStringId, onNoPressed, onYesPressed, additionalInfoStringId);
			return val;
		}

		public T PushPopup<T>(float delay = 0f, bool ignoreScreen = false) where T : BasePopup
		{
			HasVisiblePopups = true;
			T val = _appScope.Get<T>();
			float num = delay;
			if (_popupStack.Count > 0)
			{
				_popupStack[_popupStack.Count - 1].OnLostFocus();
			}
			else
			{
				_occludedScreen = null;
				if (!ignoreScreen)
				{
					_occludedScreen = _screenStack.GetTopVisibleScreen();
				}
				_occludedScreen?.OnLostFocus();
				num += _popupParent.FirstPopupDelay;
				TweenInOut(isIn: true, null, num);
			}
			List<IThemeComponent> list = new List<IThemeComponent>();
			val.GetComponentsInChildren(includeInactive: true, list);
			_occludedScreen?.RegisterAdditionalThemeComponents(list);
			_popupStack.Add(val);
			val.OnOpened(num);
			return val;
		}

		public BasePopup GetTopPopup()
		{
			if (Diagnostics.Verify(HasActivePopups, "No active popups currently."))
			{
				return _popupStack[_popupStack.Count - 1];
			}
			return null;
		}

		public void PopPopup(bool skipTransition = false)
		{
			if (_popupStack.Count <= 0)
			{
				return;
			}
			BasePopup poppedPopup = _popupStack[_popupStack.Count - 1];
			_popupStack.RemoveAt(_popupStack.Count - 1);
			poppedPopup.OnClosed(delegate
			{
				_appScope.Release(poppedPopup);
				if (_popupStack.Count > 0)
				{
					_popupStack[_popupStack.Count - 1].OnReceivedFocus();
				}
				else
				{
					_occludedScreen?.OnGainedFocus();
					HasVisiblePopups = false;
					TweenInOut(isIn: false);
				}
			}, skipTransition);
			List<IThemeComponent> list = new List<IThemeComponent>();
			poppedPopup.GetComponentsInChildren(includeInactive: true, list);
			_occludedScreen?.UnregisterAdditionalThemeComponents(list);
		}

		private void TweenInOut(bool isIn, Action thenExecute = null, float delay = 0f)
		{
			if (_tweenCoroutine != null)
			{
				_gameCamera.StopCoroutine(_tweenCoroutine);
			}
			_tweenCoroutine = _gameCamera.StartCoroutine(TweenInOutCoroutine(isIn, thenExecute, delay));
		}

		private void ResetCachedValues()
		{
			_blurStrengthBefore = -1f;
			_blurRangeBefore = -1f;
			_blurOffsetBefore = -1f;
		}

		public void ResetReturnBlur()
		{
			_blurStrengthBefore = 0f;
			_blurRangeBefore = 0f;
			_blurOffsetBefore = 0f;
		}

		private IEnumerator TweenInOutCoroutine(bool isIn, Action thenExecute, float delay = 0f)
		{
			yield return new WaitForSeconds(delay);
			float time = 0f;
			if (isIn)
			{
				_blurStrengthBefore = ((_blurStrengthBefore < 0f) ? _gameCamera.customBlur.Strength : _blurStrengthBefore);
				_blurRangeBefore = ((_blurRangeBefore < 0f) ? _gameCamera.customBlur.LevelsRange : _blurRangeBefore);
				_blurOffsetBefore = ((_blurOffsetBefore < 0f) ? _gameCamera.customBlur.LevelsOffset : _blurOffsetBefore);
			}
			float startBlurStrength = _gameCamera.customBlur.Strength;
			float startBlurRange = _gameCamera.customBlur.LevelsRange;
			float startBlurOffset = _gameCamera.customBlur.LevelsOffset;
			float targetBlurStrength = (isIn ? _popupParent.FullBlurStrength : _blurStrengthBefore);
			float targetBlurRange = (isIn ? _popupParent.FullBlurRange : _blurRangeBefore);
			float targetBlurOffset = (isIn ? _popupParent.FullBlurOffset() : _blurOffsetBefore);
			while (time < _popupParent.TweenDuration)
			{
				float t = time / _popupParent.TweenDuration;
				float strength = Mathf.Lerp(startBlurStrength, targetBlurStrength, t);
				float levelsRange = Mathf.Lerp(startBlurRange, targetBlurRange, t);
				float levelsOffset = Mathf.Lerp(startBlurOffset, targetBlurOffset, t);
				_gameCamera.customBlur.Strength = strength;
				_gameCamera.customBlur.LevelsRange = levelsRange;
				_gameCamera.customBlur.LevelsOffset = levelsOffset;
				time += Time.deltaTime;
				yield return null;
			}
			_gameCamera.customBlur.Strength = targetBlurStrength;
			_gameCamera.customBlur.LevelsRange = targetBlurRange;
			_gameCamera.customBlur.LevelsOffset = targetBlurOffset;
			thenExecute?.Invoke();
			if (!isIn)
			{
				ResetCachedValues();
			}
		}
	}
}
