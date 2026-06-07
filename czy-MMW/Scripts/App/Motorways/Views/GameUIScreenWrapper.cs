using System.Collections.Generic;
using Client;
using Factory;
using JetBrains.Annotations;
using Motorways.Models;
using Motorways.UI;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways.Views
{
	public class GameUIScreenWrapper : GameUIScreen
	{
		[EnumTypedArray(typeof(DeviceCategory))]
		public GameUIScreen[] screens;

		private readonly List<ClockView> _additionalClockViews = new List<ClockView>();

		private readonly List<ScoreView> _additionalScoreViews = new List<ScoreView>();

		public DeviceCategory selectedScreen;

		private ClockView _mainClockView;

		private ScoreView _mainScoreView;

		private Vector3 _worldGridSize = Vector3.zero;

		private RectTransform _currentActiveRectTransform;

		[Button(null)]
		[UsedImplicitly]
		public void UpdateSelectedScreen()
		{
			SetScreenForDeviceCategory(selectedScreen);
		}

		public override RectTransform GetRectTransform()
		{
			return _currentActiveRectTransform;
		}

		protected override Transform GetUpgradeBarTransform()
		{
			UpgradeBarWrapper upgradeBarWrapper = base.UpgradeBar as UpgradeBarWrapper;
			if (Diagnostics.Verify(upgradeBarWrapper != null, "The upgrade bar isn't a wrapper but the UI is!"))
			{
				return upgradeBarWrapper.upgradeBars[(int)selectedScreen].transform;
			}
			return base.GetUpgradeBarTransform();
		}

		public void SetScreenForDeviceCategory(DeviceCategory deviceCategory)
		{
			selectedScreen = deviceCategory;
			foreach (ScoreView additionalScoreView in _additionalScoreViews)
			{
				additionalScoreView.electiveUpgradeTicker.SetActive(value: false);
				additionalScoreView.SetupView();
			}
			for (int i = 0; i < screens.Length; i++)
			{
				GameUIScreen gameUIScreen = screens[i];
				if (i == (int)selectedScreen)
				{
					gameUIScreen.GetComponent<DelegateCanvasGroup>().SetInteractable(isInteractable: true);
					gameUIScreen.GetComponent<DelegateCanvasGroup>().SetBlocksRaycasts(doesBlockRaycasts: true);
					gameUIScreen.GetComponent<DelegateCanvasGroup>().Alpha = 1f;
					playableArea = gameUIScreen.playableArea;
					_currentActiveRectTransform = gameUIScreen.GetRectTransform();
					gameUIScreen.transform.SetParent(base.transform.parent);
					_gameCamera.AttachCameraToCanvas(gameUIScreen.GetComponent<Canvas>(), CameraLayer.UI);
				}
				else
				{
					gameUIScreen.GetComponent<DelegateCanvasGroup>().SetInteractable(isInteractable: false);
					gameUIScreen.GetComponent<DelegateCanvasGroup>().SetBlocksRaycasts(doesBlockRaycasts: false);
					gameUIScreen.GetComponent<DelegateCanvasGroup>().Alpha = 0f;
					gameUIScreen.transform.SetParent(base.transform);
				}
			}
		}

		public override void SetUIVisible(bool visible, bool instantly = false, bool forceHide = false, bool forceHideWorldGrid = false)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetUIVisible(visible, instantly, forceHide, forceHideWorldGrid);
			}
			base.SetUIVisible(visible, instantly, forceHide, forceHideWorldGrid);
		}

		public override void SetScoreVisible(bool visible)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetScoreVisible(visible);
			}
			base.SetScoreVisible(visible);
		}

		public override TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			foreach (ClockView additionalClockView in _additionalClockViews)
			{
				if (additionalClockView != _mainClockView)
				{
					ClockView clockView = additionalClockView;
					if (clockView.ClockModel == null)
					{
						ClockModel clockModel = (clockView.ClockModel = _mainClockView.ClockModel);
					}
					additionalClockView.Tick(timeInterval, stepAlpha);
				}
			}
			foreach (ScoreView additionalScoreView in _additionalScoreViews)
			{
				if (additionalScoreView != _mainScoreView)
				{
					ScoreView scoreView = additionalScoreView;
					if (scoreView.ScoreModel == null)
					{
						ScoreModel scoreModel = (scoreView.ScoreModel = _mainScoreView.ScoreModel);
					}
					additionalScoreView.Tick(timeInterval, stepAlpha);
				}
			}
			TickResult result = base.Tick(timeInterval, stepAlpha);
			_worldGrid.localScale = _worldGridSize;
			return result;
		}

		protected override void SetElectiveUpgradeAvailable(bool available)
		{
			foreach (ScoreView additionalScoreView in _additionalScoreViews)
			{
				additionalScoreView.electiveUpgradeAnimator.SetBool(ScoreView.UpgradeAvailableId, available);
			}
			base.SetElectiveUpgradeAvailable(available);
		}

		public override void SetDrawButtonsVisible(bool visible)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetDrawButtonsVisible(visible);
			}
			base.SetDrawButtonsVisible(visible);
		}

		public override void SetVcrButtonState(bool paused, TimeScale timeScale)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetVcrButtonState(paused, timeScale);
			}
			base.SetVcrButtonState(paused, timeScale);
			foreach (ClockView additionalClockView in _additionalClockViews)
			{
				additionalClockView.IsVisuallyPaused = paused;
			}
		}

		public override void OnPausePressed()
		{
			base.OnPausePressed();
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnPausePressed();
			}
		}

		public override void OnPlayPressed()
		{
			base.OnPlayPressed();
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnPlayPressed();
			}
		}

		public override void OnFastForwardPressed()
		{
			base.OnFastForwardPressed();
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnFastForwardPressed();
			}
		}

		public override void OnExtraFastForwardPressed()
		{
			base.OnExtraFastForwardPressed();
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnExtraFastForwardPressed();
			}
		}

		public override void SetClockVisibility(bool visible)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetClockVisibility(visible);
			}
			base.SetClockVisibility(visible);
		}

		public override void SetMenuButtonVisible(bool visible)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetMenuButtonVisible(visible);
			}
			base.SetMenuButtonVisible(visible);
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].TransitionIn(outScreen);
			}
			base.TransitionIn(outScreen);
			selectedScreen = (((float)Screen.width / (float)Screen.height < 1.5f) ? DeviceCategory.Tablet : DeviceCategory.Desktop);
			SetScreenForDeviceCategory(selectedScreen);
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].TransitionOut(inScreen);
			}
			base.TransitionOut(inScreen);
		}

		public override void OnTransitionedIn()
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnTransitionedIn();
			}
			base.OnTransitionedIn();
			SetScreenForDeviceCategory(selectedScreen);
		}

		public override void OnTransitionedOut()
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnTransitionedOut();
			}
			base.OnTransitionedOut();
		}

		public override void InitScreen(IScope gameScope, bool blocksGameInput)
		{
			_worldGridSize = _worldGrid.localScale;
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].InitScreen(gameScope, blocksGameInput);
			}
			base.InitScreen(gameScope, blocksGameInput);
			_worldGrid.localScale = _worldGridSize;
		}

		public override void OnCreatedInScope(IScope scope)
		{
			GameUIScreen[] array = screens;
			foreach (GameUIScreen unboundObject in array)
			{
				scope.Assemble(unboundObject);
			}
			base.OnCreatedInScope(scope);
			_mainClockView = scope.Get<ClockView>();
			_mainScoreView = scope.Get<ScoreView>();
			ClockView[] componentsInChildren = GetComponentsInChildren<ClockView>();
			foreach (ClockView clockView in componentsInChildren)
			{
				if (clockView != _mainClockView)
				{
					_additionalClockViews.Add(clockView);
					scope.Assemble(clockView);
					clockView.ClockModel = _mainClockView.ClockModel;
				}
			}
			ScoreView[] componentsInChildren2 = GetComponentsInChildren<ScoreView>();
			foreach (ScoreView scoreView in componentsInChildren2)
			{
				if (scoreView != _mainScoreView)
				{
					_additionalScoreViews.Add(scoreView);
					scope.Assemble(scoreView);
					scoreView.ScoreModel = _mainScoreView.ScoreModel;
				}
			}
			_currentActiveRectTransform = screens[0].GetRectTransform();
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnReleasedFromScope(scope);
			}
			base.OnReleasedFromScope(scope);
			_additionalClockViews.Clear();
			_additionalScoreViews.Clear();
		}

		public override void Reset()
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Reset();
			}
			base.Reset();
		}

		public override void ScaleToCamera()
		{
			GameUIScreen[] array = screens;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ScaleToCamera();
			}
			base.ScaleToCamera();
		}
	}
}
