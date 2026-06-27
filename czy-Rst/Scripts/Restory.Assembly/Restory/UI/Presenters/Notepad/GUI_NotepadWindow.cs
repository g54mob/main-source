using System;
using Restory.Gameplay.Common;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameView;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Views.Notepad;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UI.Presenters.Notepad
{
	public sealed class GUI_NotepadWindow : MonoBehaviour, IInitializable, IDisposable, IActiveStateSwitchRequester
	{
		[SerializeField]
		private GUI_NotepadWindowView view;

		[SerializeField]
		private GUI_NotepadDevicePanel devicePanel;

		[SerializeField]
		private GUI_NotepadElementsPanel elementsPanel;

		private DeviceService deviceService;

		private CameraDirectionSwitcher cameraDirectionSwitcher;

		private DisassembleStateMachine disassembleStateMachine;

		private NotepadInteractiveWorkplaceItem notepadInteractiveWorkplaceItem;

		private GUI_RewiredPanelInputModule rewiredPanelInputModule;

		private bool pointerInside;

		private bool hotkeyPressed;

		private bool isSubscribed;

		public bool IsVisible => view.IsVisible;

		public bool IsRolledOut => view.IsRolledOut;

		public bool IsSlidingMode => view.IsSlidingMode;

		public bool IsPointerInside => pointerInside;

		public event Action OnIsVisibleChanged;

		public event Action<SlidingPanelState> OnSlidingStateChanged;

		[Inject]
		private void Construct(DeviceService deviceService, CameraDirectionSwitcher cameraDirectionSwitcher, DisassembleStateMachine disassembleStateMachine, NotepadInteractiveWorkplaceItem notepadInteractiveWorkplaceItem, GUI_RewiredPanelInputModule rewiredPanelInputModule)
		{
			this.deviceService = deviceService;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.disassembleStateMachine = disassembleStateMachine;
			this.notepadInteractiveWorkplaceItem = notepadInteractiveWorkplaceItem;
			this.rewiredPanelInputModule = rewiredPanelInputModule;
		}

		public void Initialize()
		{
			Hide();
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
		}

		public void Dispose()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			pointerInside = false;
			hotkeyPressed = false;
			Unsubscribe();
			view.Clear();
			devicePanel.Clear();
			elementsPanel.Clear();
		}

		private void Subscribe()
		{
			if (!isSubscribed)
			{
				isSubscribed = true;
				view.OnCloseButtonClicked += ResolveCloseButtonClicked;
				view.OnPinButtonClicked += ResolvePinButtonClicked;
				view.OnSlidingStateChanged += ResolveSlidingStateChanged;
				view.OnPointerEntered += ResolvePointerEntered;
				view.OnPointerExited += ResolvePointerExited;
				view.OnKeyUpped += ResolveOnKeyUpped;
				view.OnKeyDowned += ResolveOnKeyDowned;
				deviceService.OnPlacedDeviceChanged += ResolvePlacedDeviceChanged;
				deviceService.OnPlacedDeviceQualityChanged += ResolvePlacedDeviceQualityChanged;
			}
		}

		private void Unsubscribe()
		{
			if (isSubscribed)
			{
				isSubscribed = false;
				view.OnCloseButtonClicked -= ResolveCloseButtonClicked;
				view.OnPinButtonClicked -= ResolvePinButtonClicked;
				view.OnSlidingStateChanged -= ResolveSlidingStateChanged;
				view.OnPointerEntered -= ResolvePointerEntered;
				view.OnPointerExited -= ResolvePointerExited;
				view.OnKeyUpped -= ResolveOnKeyUpped;
				view.OnKeyDowned -= ResolveOnKeyDowned;
				deviceService.OnPlacedDeviceChanged -= ResolvePlacedDeviceChanged;
				deviceService.OnPlacedDeviceQualityChanged -= ResolvePlacedDeviceQualityChanged;
			}
		}

		public void Show()
		{
			if (!IsVisible)
			{
				SetHasShownOnFirstDrag();
				UpdateInfoFromCurrentDevice();
				Subscribe();
				elementsPanel.Subscribe();
				view.IsPinned = notepadInteractiveWorkplaceItem.WindowIsPinned;
				view.Show();
				UpdateRollInOut();
				cameraDirectionSwitcher.AddBlocker(this);
				this.OnIsVisibleChanged?.Invoke();
			}
		}

		public void Hide()
		{
			if (IsVisible)
			{
				cameraDirectionSwitcher.RemoveBlocker(this);
				Unsubscribe();
				elementsPanel.Unsubscribe();
				view.Hide();
				this.OnIsVisibleChanged?.Invoke();
			}
		}

		public void RollOut()
		{
			view.RollOut();
		}

		public void RollIn()
		{
			view.RollIn();
		}

		public void OnExitEvent()
		{
			Hide();
		}

		public void UpdateInfoFromCurrentDevice()
		{
			DeviceContainer placedDeviceContainer = deviceService.PlacedDeviceContainer;
			if (!placedDeviceContainer || !placedDeviceContainer.Device)
			{
				devicePanel.Clear();
				SwitchPanels(isWorkspaceEmpty: true);
				return;
			}
			devicePanel.SetCurrentDeviceInfo(placedDeviceContainer);
			SwitchPanels(isWorkspaceEmpty: false);
			elementsPanel.Init(placedDeviceContainer);
			elementsPanel.RequestUpdateElementsViewsAndPresenters();
		}

		private void SwitchPanels(bool isWorkspaceEmpty)
		{
			devicePanel.SetVisibility(!isWorkspaceEmpty);
			elementsPanel.SetVisibility(!isWorkspaceEmpty);
			view.SwitchEmptyWorkspaceMessage(isWorkspaceEmpty);
		}

		private bool SetHasShownOnFirstDrag()
		{
			if (!notepadInteractiveWorkplaceItem.HasShownOnFirstDrag)
			{
				notepadInteractiveWorkplaceItem.HasShownOnFirstDrag = true;
				return true;
			}
			return false;
		}

		private void UpdateRollInOut(bool rollOut = false)
		{
			if (pointerInside || hotkeyPressed || notepadInteractiveWorkplaceItem.WindowIsPinned || rollOut)
			{
				view.RollOut();
			}
			else
			{
				view.RollIn();
			}
		}

		private void ResolveCloseButtonClicked(GUI_NotepadWindowView notepadView)
		{
			Hide();
		}

		private void ResolvePinButtonClicked(GUI_NotepadWindowView notepadView)
		{
			notepadInteractiveWorkplaceItem.WindowIsPinned = !notepadInteractiveWorkplaceItem.WindowIsPinned;
			view.IsPinned = notepadInteractiveWorkplaceItem.WindowIsPinned;
			UpdateRollInOut();
		}

		private void ResolveSlidingStateChanged(SlidingPanelState state)
		{
			if ((uint)(state - 2) <= 1u)
			{
				rewiredPanelInputModule.AddSelectedPanel(view.gameObject);
			}
			else
			{
				rewiredPanelInputModule.RemoveSelectedPanel(view.gameObject);
			}
			this.OnSlidingStateChanged?.Invoke(state);
		}

		private void ResolvePointerEntered(GUI_NotepadWindowView notepadView)
		{
			pointerInside = true;
			UpdateRollInOut();
		}

		private void ResolvePointerExited(GUI_NotepadWindowView notepadView)
		{
			pointerInside = false;
			UpdateRollInOut();
		}

		private void ResolveOnKeyUpped(GUI_NotepadWindowView notepadView, KeyEventData eventData)
		{
			if (eventData.ActionId == 90)
			{
				hotkeyPressed = false;
				UpdateRollInOut();
			}
		}

		private void ResolveOnKeyDowned(GUI_NotepadWindowView notepadView, KeyEventData eventData)
		{
			if (eventData.ActionId == 90)
			{
				hotkeyPressed = true;
				UpdateRollInOut();
			}
		}

		private void ResolvePlacedDeviceChanged()
		{
			UpdateInfoFromCurrentDevice();
		}

		private void ResolvePlacedDeviceQualityChanged()
		{
			DeviceContainer placedDeviceContainer = deviceService.PlacedDeviceContainer;
			if ((bool)placedDeviceContainer)
			{
				devicePanel.SetCurrentDeviceInfo(placedDeviceContainer);
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			if (!notepadInteractiveWorkplaceItem.IsActive)
			{
				return;
			}
			bool rollOut = SetHasShownOnFirstDrag();
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is TransitionToCleaningDisassembleState) && !(activeState is PaintingDisassembleState))
			{
				if (!(activeState is DisabledDisassembleState))
				{
					if (!(activeState is DetectionDisassembleState))
					{
						if (activeState is EmptyDisassembleState)
						{
							view.IsPinned = notepadInteractiveWorkplaceItem.WindowIsPinned;
							view.SetViewMode(isSlidingMode: true);
							if (IsVisible)
							{
								UpdateInfoFromCurrentDevice();
								Subscribe();
							}
						}
					}
					else
					{
						if (!view.IsSlidingMode)
						{
							view.IsPinned = notepadInteractiveWorkplaceItem.WindowIsPinned;
							view.SetViewMode(isSlidingMode: true);
							UpdateRollInOut(rollOut);
						}
						if (!elementsPanel.IsSubscribed)
						{
							UpdateInfoFromCurrentDevice();
							Subscribe();
							elementsPanel.Subscribe();
						}
					}
				}
				else
				{
					view.IsPinned = notepadInteractiveWorkplaceItem.WindowIsPinned;
					view.SetViewMode(isSlidingMode: false);
					Unsubscribe();
					elementsPanel.Unsubscribe();
					cameraDirectionSwitcher.RemoveBlocker(this);
				}
			}
			else
			{
				view.IsPinned = notepadInteractiveWorkplaceItem.WindowIsPinned;
				view.SetViewMode(isSlidingMode: false);
				Unsubscribe();
				elementsPanel.Unsubscribe();
			}
			this.OnIsVisibleChanged?.Invoke();
		}
	}
}
