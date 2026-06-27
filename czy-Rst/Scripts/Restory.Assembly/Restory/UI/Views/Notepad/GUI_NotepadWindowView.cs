using System;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Notepad
{
	public sealed class GUI_NotepadWindowView : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IKeyUpHandler, IKeyDownHandler
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Button closeButton;

		[SerializeField]
		private Button pinButton;

		[SerializeField]
		private GUI_PresetSwitcher pinButtonPresetSwitcher;

		[SerializeField]
		private string pinButtonDefaultPresetName = "PinButton_Default";

		[SerializeField]
		private string pinButtonPinnedPresetName = "PinButton_Pinned";

		[SerializeField]
		private GUI_SlidingPanelTweener slidingPanelTweener;

		[SerializeField]
		private GameObject emptySurfaceMessage;

		private bool isVisible = true;

		private bool isSlidingMode;

		public bool IsVisible => isVisible;

		public bool IsRolledOut => slidingPanelTweener.State == SlidingPanelState.Open;

		public bool IsSlidingMode => isSlidingMode;

		public bool IsPinned
		{
			get
			{
				return pinButtonPresetSwitcher.ActivePresetName == pinButtonPinnedPresetName;
			}
			set
			{
				if (value)
				{
					pinButtonPresetSwitcher.ActivatePreset(pinButtonPinnedPresetName);
				}
				else
				{
					pinButtonPresetSwitcher.ActivatePreset(pinButtonDefaultPresetName);
				}
			}
		}

		public event Action<GUI_NotepadWindowView> OnCloseButtonClicked = delegate
		{
		};

		public event Action<GUI_NotepadWindowView> OnPinButtonClicked = delegate
		{
		};

		public event Action<GUI_NotepadWindowView> OnPointerEntered = delegate
		{
		};

		public event Action<GUI_NotepadWindowView> OnPointerExited = delegate
		{
		};

		public event Action<GUI_NotepadWindowView, KeyEventData> OnKeyUpped = delegate
		{
		};

		public event Action<GUI_NotepadWindowView, KeyEventData> OnKeyDowned = delegate
		{
		};

		public event Action<SlidingPanelState> OnSlidingStateChanged;

		private void Awake()
		{
			closeButton.gameObject.SetActive(!isSlidingMode);
			pinButton.gameObject.SetActive(isSlidingMode);
		}

		private void OnEnable()
		{
			closeButton.onClick.AddListener(ResolveCloseButtonClicked);
			pinButton.onClick.AddListener(ResolvePinButtonClicked);
			slidingPanelTweener.OnTransitionComplete += ResolveSlidingTransitionComplete;
		}

		public void OnDisable()
		{
			closeButton.onClick.RemoveListener(ResolveCloseButtonClicked);
			pinButton.onClick.RemoveListener(ResolvePinButtonClicked);
			slidingPanelTweener.OnTransitionComplete -= ResolveSlidingTransitionComplete;
		}

		public void SetViewMode(bool isSlidingMode)
		{
			if (this.isSlidingMode != isSlidingMode)
			{
				SwitchViewMode();
			}
			else if (isSlidingMode && !isVisible)
			{
				isVisible = true;
				UpdateCanvasGroup();
				closeButton.gameObject.SetActive(value: false);
				pinButton.gameObject.SetActive(value: true);
				slidingPanelTweener.TransitionToState(SlidingPanelState.Peeking);
			}
		}

		public void Show()
		{
			if (!isVisible)
			{
				isVisible = true;
				UpdateCanvasGroup();
				if (isSlidingMode)
				{
					slidingPanelTweener.TransitionToState(SlidingPanelState.Peeking);
				}
				else
				{
					slidingPanelTweener.SetState(SlidingPanelState.Open);
				}
			}
		}

		public void Hide()
		{
			if (isVisible)
			{
				isVisible = false;
				if (isSlidingMode)
				{
					slidingPanelTweener.TransitionToState(SlidingPanelState.Hidden);
					return;
				}
				slidingPanelTweener.SetState(SlidingPanelState.Hidden);
				UpdateCanvasGroup();
			}
		}

		public void RollOut()
		{
			if (IsVisible && isSlidingMode && !IsRolledOut)
			{
				slidingPanelTweener.TransitionToState(SlidingPanelState.Open);
			}
		}

		public void RollIn()
		{
			if (IsVisible && isSlidingMode && IsRolledOut)
			{
				slidingPanelTweener.TransitionToState(SlidingPanelState.Peeking);
			}
		}

		public void SwitchEmptyWorkspaceMessage(bool shouldBeVisible)
		{
			emptySurfaceMessage.SetActive(shouldBeVisible);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.OnPointerEntered(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			this.OnPointerExited(this);
		}

		private void ResolveCloseButtonClicked()
		{
			this.OnCloseButtonClicked(this);
		}

		private void ResolvePinButtonClicked()
		{
			this.OnPinButtonClicked(this);
		}

		public void OnKeyUp(KeyEventData eventData)
		{
			this.OnKeyUpped(this, eventData);
		}

		public void OnKeyDown(KeyEventData eventData)
		{
			this.OnKeyDowned(this, eventData);
		}

		private void ResolveSlidingTransitionComplete()
		{
			if (slidingPanelTweener.State == SlidingPanelState.Hidden)
			{
				closeButton.gameObject.SetActive(value: true);
				pinButton.gameObject.SetActive(value: false);
				UpdateCanvasGroup();
			}
			this.OnSlidingStateChanged?.Invoke(slidingPanelTweener.State);
		}

		private void SwitchViewMode()
		{
			isSlidingMode = !isSlidingMode;
			if (isSlidingMode)
			{
				isVisible = true;
				closeButton.gameObject.SetActive(value: false);
				pinButton.gameObject.SetActive(value: true);
				slidingPanelTweener.TransitionToState(SlidingPanelState.Peeking);
				UpdateCanvasGroup();
			}
			else
			{
				isVisible = false;
				slidingPanelTweener.TransitionToState(SlidingPanelState.Hidden);
			}
		}

		private void UpdateCanvasGroup()
		{
			canvasGroup.alpha = (isVisible ? 1 : 0);
			canvasGroup.blocksRaycasts = isVisible;
			canvasGroup.interactable = isVisible;
		}

		public void Clear()
		{
		}
	}
}
