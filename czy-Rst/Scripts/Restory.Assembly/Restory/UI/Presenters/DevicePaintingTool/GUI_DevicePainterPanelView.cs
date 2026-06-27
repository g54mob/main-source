using System;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using Restory.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_DevicePainterPanelView : UIBehaviour
	{
		[SerializeField]
		private GUI_PresetSwitcher switchVisibilityButtonPresetSwitcher;

		[SerializeField]
		private Button switchVisibilityButton;

		[SerializeField]
		private Button clearPaintButton;

		[SerializeField]
		private Button undoButton;

		[SerializeField]
		private Button redoButton;

		[SerializeField]
		private Button switchButton;

		[SerializeField]
		private Button exitButton;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private GUI_SlidingPanelTweener slidingPanelTweener;

		public SlidingPanelState CurrentVisibilityState => slidingPanelTweener.State;

		public event Action OnVisibilitySwitchRequested;

		public event Action OnPaintClearRequested;

		public event Action OnUndoActionRequested;

		public event Action OnRedoActionRequested;

		public event Action OnSwitchRequested;

		public event Action OnExitRequested;

		protected override void OnDisable()
		{
			if (switchVisibilityButton.MonoShellExists())
			{
				switchVisibilityButton.onClick.RemoveListener(ResolveMinimizeButtonClicked);
			}
			if (clearPaintButton.MonoShellExists())
			{
				clearPaintButton.onClick.RemoveListener(ResolveClearPaintButtonClicked);
			}
			if (undoButton.MonoShellExists())
			{
				undoButton.onClick.RemoveListener(ResolveOnUndoButtonClicked);
			}
			if (redoButton.MonoShellExists())
			{
				redoButton.onClick.RemoveListener(ResolveOnRedoButtonClicked);
			}
			if (switchButton.MonoShellExists())
			{
				switchButton.onClick.RemoveListener(ResolveSwitchButtonClicked);
			}
			if (exitButton.MonoShellExists())
			{
				exitButton.onClick.RemoveListener(ResolveExitButtonClicked);
			}
			if (slidingPanelTweener.MonoShellExists())
			{
				slidingPanelTweener.OnTransitionComplete -= ResolveSlidingPanelTransitionComplete;
			}
			base.OnDisable();
		}

		public void Show()
		{
			SwitchVisibility(shouldBeFullyOpen: true);
			slidingPanelTweener.OnTransitionComplete -= ResolveSlidingPanelTransitionComplete;
			slidingPanelTweener.OnTransitionComplete += ResolveSlidingPanelTransitionComplete;
			switchVisibilityButton.onClick.AddListener(ResolveMinimizeButtonClicked);
			clearPaintButton.onClick.AddListener(ResolveClearPaintButtonClicked);
			undoButton.onClick.AddListener(ResolveOnUndoButtonClicked);
			redoButton.onClick.AddListener(ResolveOnRedoButtonClicked);
			switchButton.onClick.AddListener(ResolveSwitchButtonClicked);
			exitButton.onClick.AddListener(ResolveExitButtonClicked);
			canvasGroup.alpha = 1f;
		}

		public void Hide()
		{
			canvasGroup.interactable = false;
			switchVisibilityButton.onClick.RemoveListener(ResolveMinimizeButtonClicked);
			clearPaintButton.onClick.RemoveListener(ResolveClearPaintButtonClicked);
			undoButton.onClick.RemoveListener(ResolveOnUndoButtonClicked);
			redoButton.onClick.RemoveListener(ResolveOnRedoButtonClicked);
			switchButton.onClick.RemoveListener(ResolveSwitchButtonClicked);
			exitButton.onClick.RemoveListener(ResolveExitButtonClicked);
			slidingPanelTweener.TransitionToState(SlidingPanelState.Hidden);
		}

		public void SwitchVisibility(bool shouldBeFullyOpen)
		{
			if (shouldBeFullyOpen)
			{
				slidingPanelTweener.TransitionToState(SlidingPanelState.Open);
				switchVisibilityButtonPresetSwitcher.ActivatePreset(PresetName.Normal);
			}
			else
			{
				slidingPanelTweener.TransitionToState(SlidingPanelState.Peeking);
				switchVisibilityButtonPresetSwitcher.ActivatePreset(PresetName.Hidden);
			}
		}

		public void SetUndoButtonInteractable(bool isInteractable)
		{
			if (undoButton.TryGetComponent<GUI_PresetSwitcher>(out var component))
			{
				PresetName presetName = (isInteractable ? PresetName.Ready : PresetName.NotReady);
				component.ActivatePreset(presetName);
			}
		}

		public void SetRedoButtonInteractable(bool isInteractable)
		{
			if (redoButton.TryGetComponent<GUI_PresetSwitcher>(out var component))
			{
				PresetName presetName = (isInteractable ? PresetName.Ready : PresetName.NotReady);
				component.ActivatePreset(presetName);
			}
		}

		private void ResolveMinimizeButtonClicked()
		{
			this.OnVisibilitySwitchRequested?.Invoke();
		}

		private void ResolveClearPaintButtonClicked()
		{
			this.OnPaintClearRequested?.Invoke();
		}

		private void ResolveOnRedoButtonClicked()
		{
			this.OnRedoActionRequested?.Invoke();
		}

		private void ResolveOnUndoButtonClicked()
		{
			this.OnUndoActionRequested?.Invoke();
		}

		private void ResolveSwitchButtonClicked()
		{
			this.OnSwitchRequested?.Invoke();
		}

		private void ResolveExitButtonClicked()
		{
			this.OnExitRequested?.Invoke();
		}

		private void ResolveSlidingPanelTransitionComplete()
		{
			switch (slidingPanelTweener.State)
			{
			case SlidingPanelState.Hidden:
				if (slidingPanelTweener.MonoShellExists())
				{
					slidingPanelTweener.OnTransitionComplete -= ResolveSlidingPanelTransitionComplete;
				}
				if ((bool)canvasGroup)
				{
					canvasGroup.alpha = 0f;
				}
				break;
			case SlidingPanelState.Peeking:
				if ((bool)canvasGroup)
				{
					canvasGroup.interactable = true;
				}
				break;
			case SlidingPanelState.Open:
				if ((bool)canvasGroup)
				{
					canvasGroup.interactable = true;
				}
				break;
			}
		}
	}
}
