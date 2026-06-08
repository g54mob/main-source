using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Dorfromantik
{
	public class IdleScreenTrigger : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<KeyValuePair<InputAction, bool>, bool> _003C_003E9__19_0;

			internal bool _003CButtonPressed_003Eb__19_0(KeyValuePair<InputAction, bool> x)
			{
				return x.Value;
			}
		}

		private sealed class _003CResetGameAfterTimer_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public IdleScreenTrigger _003C_003E4__this;

			public float resetDuration;

			private float _003Ctimer_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CResetGameAfterTimer_003Ed__27(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				IdleScreenTrigger idleScreenTrigger = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003Ctimer_003E5__2 = 0f;
					break;
				case 1:
					_003C_003E1__state = -1;
					break;
				}
				if (_003Ctimer_003E5__2 < resetDuration)
				{
					_003Ctimer_003E5__2 += Time.deltaTime;
					idleScreenTrigger.currentIdleScreen.SetResettingProgress(_003Ctimer_003E5__2 / resetDuration);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				idleScreenTrigger.currentIdleScreen.SetResettingProgress(1f);
				idleScreenTrigger.saveGameLoadingInitiator.SetSelectedGameMode(OverwritingSingleton<GameSession>.Instance.GameMode);
				idleScreenTrigger.saveGameLoadingInitiator.DeleteAutosaveOfSelectedGameMode();
				idleScreenTrigger.saveGameLoadingInitiator.SetSelectedGameMode(idleScreenTrigger.tutorialGameMode);
				idleScreenTrigger.saveGameLoadingInitiator.NewGameInSelectedGameMode();
				idleScreenTrigger.settingsRouter.ChangeLanguage(Language.English);
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		[SerializeField]
		private float idleTimeBeforeShowingIdleScreen = 600f;

		[SerializeField]
		private float resetTimeAfterShowingIdleScreen = 30f;

		[SerializeField]
		private List<InputActionReference> inputButtonsToHoldDownForManualTrigger;

		[SerializeField]
		private InputActionReference inputToPressRepeatedlyWhileHoldingDown;

		[SerializeField]
		private int neededPressCount = 10;

		[SerializeField]
		private AssetReference idleScreenReference;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private SaveGameLoadingInitiator saveGameLoadingInitiator;

		[SerializeField]
		private GameMode tutorialGameMode;

		private float idleTimer;

		private Dictionary<InputAction, bool> buttonHeldDown = new Dictionary<InputAction, bool>();

		private int repeatedButtonPressCount;

		private IdleScreen currentIdleScreen;

		private Tween idleScreenFadeTween;

		private Coroutine resetCoroutine;

		private AsyncOperationHandle<GameObject> currentIdleScreenLoadingHandle;

		private bool manualReset;

		private void Start()
		{
			InputSystem.onActionChange += delegate(object obj, InputActionChange change)
			{
				if (change == InputActionChange.ActionPerformed)
				{
					ResetIdleTimer(null);
				}
			};
			foreach (InputActionReference item in inputButtonsToHoldDownForManualTrigger)
			{
				buttonHeldDown.Add(item.action, value: false);
				item.action.started += StartHoldingDown;
				item.action.canceled += StopHoldingDown;
			}
			inputToPressRepeatedlyWhileHoldingDown.action.performed += ButtonPressed;
		}

		private void ButtonPressed(InputAction.CallbackContext obj)
		{
			if (Enumerable.All(buttonHeldDown, (KeyValuePair<InputAction, bool> x) => x.Value))
			{
				Debug.Log($"Press button while all others are held down, count: {repeatedButtonPressCount}");
				repeatedButtonPressCount++;
				if (repeatedButtonPressCount >= neededPressCount)
				{
					ShowIdleScreen(resetImmediately: true);
				}
			}
			else
			{
				Debug.Log("Press button while not all others are held down; " + ListHelper.ListDebugString(Enumerable.ToList(buttonHeldDown.Values)));
				repeatedButtonPressCount = 0;
			}
		}

		private void StopHoldingDown(InputAction.CallbackContext context)
		{
			buttonHeldDown[context.action] = false;
			repeatedButtonPressCount = 0;
		}

		private void StartHoldingDown(InputAction.CallbackContext context)
		{
			buttonHeldDown[context.action] = true;
		}

		private void ResetIdleTimer(InputControl inputControl)
		{
			idleTimer = 0f;
		}

		private void Update()
		{
			idleTimer += Time.deltaTime;
			if (idleTimer > idleTimeBeforeShowingIdleScreen)
			{
				ShowIdleScreen();
			}
		}

		private void ShowIdleScreen(bool resetImmediately = false)
		{
			idleTimer = 0f;
			repeatedButtonPressCount = 0;
			manualReset = resetImmediately;
			if (!currentIdleScreen)
			{
				currentIdleScreenLoadingHandle = idleScreenReference.InstantiateAsync(base.transform);
				currentIdleScreenLoadingHandle.Completed += OnIdleScreenLoadingCompleted;
			}
		}

		private void OnIdleScreenLoadingCompleted(AsyncOperationHandle<GameObject> asyncOperationHandle)
		{
			currentIdleScreen = asyncOperationHandle.Result.GetComponent<IdleScreen>();
			idleScreenFadeTween = TweenSettingsExtensions.From(DOTweenModuleUI.DOFade(currentIdleScreen.CanvasGroup, 1f, 0.5f), 0f);
			TweenSettingsExtensions.OnComplete(idleScreenFadeTween, IdleScreenCompletelyVisible);
		}

		private void IdleScreenCompletelyVisible()
		{
			currentIdleScreen.OnHide += HideIdleScreen;
			EventSystem.current.GetComponent<InputSystemUIInputModule>().enabled = false;
			inputRouter.SetIsSplashScreenActive(splashScreenActive: true);
			resetCoroutine = StartCoroutine(ResetGameAfterTimer(manualReset ? 0f : resetTimeAfterShowingIdleScreen));
		}

		private IEnumerator ResetGameAfterTimer(float resetDuration)
		{
			return new _003CResetGameAfterTimer_003Ed__27(0)
			{
				_003C_003E4__this = this,
				resetDuration = resetDuration
			};
		}

		private void HideIdleScreen()
		{
			if (resetCoroutine != null)
			{
				StopCoroutine(resetCoroutine);
			}
			currentIdleScreen.OnHide -= HideIdleScreen;
			idleScreenFadeTween = DOTweenModuleUI.DOFade(currentIdleScreen.CanvasGroup, 0f, 1f);
			TweenSettingsExtensions.OnComplete(idleScreenFadeTween, OnIdleScreenCompletelyHidden);
			Singleton<MainMenuUi>.Instance.SwitchToScreen(MainMenuScreenType.NavigationBar);
			EventSystem.current.GetComponent<InputSystemUIInputModule>().enabled = true;
			inputRouter.SetIsSplashScreenActive(splashScreenActive: false);
		}

		private void OnIdleScreenCompletelyHidden()
		{
			UnityEngine.Object.Destroy(currentIdleScreen.gameObject);
			Addressables.Release(currentIdleScreen.gameObject);
			currentIdleScreen = null;
		}

		private void OnDestroy()
		{
			foreach (InputActionReference item in inputButtonsToHoldDownForManualTrigger)
			{
				item.action.started -= StartHoldingDown;
				item.action.canceled -= StopHoldingDown;
			}
			inputToPressRepeatedlyWhileHoldingDown.action.performed -= ButtonPressed;
		}

		private void _003CStart_003Eb__18_0(object obj, InputActionChange change)
		{
			if (change == InputActionChange.ActionPerformed)
			{
				ResetIdleTimer(null);
			}
		}
	}
}
