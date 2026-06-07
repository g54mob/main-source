using System;
using System.Collections;
using System.Collections.Generic;
using DV.UI;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class InventoryInputVR : MonoBehaviour
{
	public SettingsController settingsController;

	private Transform controllerRight;

	private Transform controllerLeft;

	private VRTK_InteractGrab_DV grabRight;

	private VRTK_InteractGrab_DV grabLeft;

	private VRTK_ControllerEvents controllerEventsRight;

	private VRTK_ControllerEvents controllerEventsLeft;

	private readonly VRTK_ControllerEvents.ButtonAlias inventoryButtonFallback = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;

	private readonly Dictionary<ControllerType_DV, VRTK_ControllerEvents.ButtonAlias> inventoryButtonDictionary = new Dictionary<ControllerType_DV, VRTK_ControllerEvents.ButtonAlias>
	{
		{
			ControllerType_DV.ViveWand,
			VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress
		},
		{
			ControllerType_DV.ValveIndex,
			VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress
		},
		{
			ControllerType_DV.RiftTouch,
			VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress
		},
		{
			ControllerType_DV.QuestTouch,
			VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress
		},
		{
			ControllerType_DV.WMR,
			VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress
		},
		{
			ControllerType_DV.HPReverbG2,
			VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress
		},
		{
			ControllerType_DV.Undefined,
			VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress
		},
		{
			ControllerType_DV.Cosmos,
			VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress
		}
	};

	public bool InventoryButtonPressed { get; private set; }

	public VRTK_ControllerEvents.ButtonAlias InventoryButton { get; private set; }

	public event Action<SDK_BaseController.ControllerHand> LongPressOn;

	public event Action<SDK_BaseController.ControllerHand> LongPressOff;

	public event Action<SDK_BaseController.ControllerHand> LongPressCancel;

	public event Action<SDK_BaseController.ControllerHand> ShortClickRequested;

	private void Start()
	{
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
	}

	private void OnDestroy()
	{
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		if (!UnloadWatcher.isQuitting)
		{
			SetupListenersForHand(SDK_BaseController.ControllerHand.Right, on: false);
			SetupListenersForHand(SDK_BaseController.ControllerHand.Left, on: false);
		}
	}

	private void OnControlsSet(SDK_BaseController.ControllerHand hand)
	{
		VRTK_ControllerReference controllerReferenceForHand = VRTK_DeviceFinder.GetControllerReferenceForHand(hand);
		switch (hand)
		{
		case SDK_BaseController.ControllerHand.Left:
			controllerLeft = VRTK_DeviceFinder.GetControllerLeftHand(getActual: true).transform;
			grabLeft = controllerLeft.GetComponentInChildren<VRTK_InteractGrab_DV>();
			controllerEventsLeft = controllerLeft.GetComponentInChildren<VRTK_ControllerEvents>();
			break;
		case SDK_BaseController.ControllerHand.Right:
			controllerRight = VRTK_DeviceFinder.GetControllerRightHand(getActual: true).transform;
			grabRight = controllerRight.GetComponentInChildren<VRTK_InteractGrab_DV>();
			controllerEventsRight = controllerRight.GetComponentInChildren<VRTK_ControllerEvents>();
			break;
		default:
			Debug.LogError("Controller not initialized properly. Given hand must be left or right.", this);
			break;
		}
		if (InventoryButton == VRTK_ControllerEvents.ButtonAlias.Undefined)
		{
			ControllerType_DV controllerTypeDV = controllerReferenceForHand.GetControllerTypeDV();
			if (inventoryButtonDictionary.TryGetValue(controllerTypeDV, out var value))
			{
				InventoryButton = value;
			}
			else
			{
				Debug.LogError($"Could not determine open inventory button based on given controller type '{controllerTypeDV}'. Using fallback value of '{inventoryButtonFallback}'");
				InventoryButton = inventoryButtonFallback;
			}
		}
		if (controllerLeft != null && controllerRight != null)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}
		SetupListenersForHand(hand, on: true);
	}

	private void SetupListenersForHand(SDK_BaseController.ControllerHand hand, bool on)
	{
		VRTK_ControllerEvents vRTK_ControllerEvents = ((hand == SDK_BaseController.ControllerHand.Right) ? controllerEventsRight : controllerEventsLeft);
		VRTK_InteractGrab_DV vRTK_InteractGrab_DV = ((hand == SDK_BaseController.ControllerHand.Right) ? grabRight : grabLeft);
		if (on)
		{
			vRTK_InteractGrab_DV.GrabButtonPressed += RequestPointer;
			vRTK_ControllerEvents.TriggerPressed += RequestPointer;
			vRTK_ControllerEvents.SubscribeToButtonAliasEvent(InventoryButton, startEvent: true, OnInventoryButtonPressed);
			return;
		}
		if (vRTK_InteractGrab_DV != null)
		{
			vRTK_InteractGrab_DV.GrabButtonPressed -= RequestPointer;
		}
		if (vRTK_ControllerEvents != null)
		{
			vRTK_ControllerEvents.TriggerPressed -= RequestPointer;
			vRTK_ControllerEvents.UnsubscribeToButtonAliasEvent(InventoryButton, startEvent: true, OnInventoryButtonPressed);
		}
	}

	private void OnInventoryButtonPressed(object sender, ControllerInteractionEventArgs e)
	{
		StartCoroutine(InventoryInteractionCoroutine(e.controllerReference.hand));
	}

	private IEnumerator InventoryInteractionCoroutine(SDK_BaseController.ControllerHand hand)
	{
		float startTime = Time.unscaledTime;
		VRTK_ControllerEvents controllerEvents = ((hand == SDK_BaseController.ControllerHand.Right) ? controllerEventsRight : controllerEventsLeft);
		bool isLongPress = false;
		if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.PauseMenu))
		{
			if (settingsController.HasChanges)
			{
				settingsController.RequestSwitchFromClose();
			}
			else
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: false);
			}
			yield break;
		}
		while (controllerEvents.IsButtonPressed(InventoryButton))
		{
			InventoryButtonPressed = true;
			if (Time.unscaledTime - startTime > 0.3f && !isLongPress)
			{
				isLongPress = true;
				this.LongPressOn?.Invoke(hand);
				RequestPointer(hand, enablePointer: true);
			}
			if (isLongPress && controllerEvents.triggerPressed)
			{
				InventoryButtonPressed = false;
				this.LongPressCancel?.Invoke(hand);
				yield break;
			}
			yield return null;
		}
		InventoryButtonPressed = false;
		if (Time.unscaledTime - startTime > 0.3f)
		{
			this.LongPressOff?.Invoke(hand);
		}
		else
		{
			this.ShortClickRequested?.Invoke(hand);
		}
	}

	private void RequestPointer(object sender, ControllerInteractionEventArgs e)
	{
		RequestPointer(e.controllerReference.hand, enablePointer: true);
	}

	public void RequestPointer(SDK_BaseController.ControllerHand hand, bool enablePointer)
	{
		if (!enablePointer || SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
		{
			SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, hand, enablePointer);
		}
	}

	public bool IsInteractionButtonPressed(SDK_BaseController.ControllerHand hand)
	{
		return ((hand == SDK_BaseController.ControllerHand.Right) ? controllerEventsRight : controllerEventsLeft).IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.TriggerPress);
	}

	public bool IsPointingWith(bool isRight)
	{
		SDK_BaseController.ControllerHand controllerHand = ((!isRight) ? SDK_BaseController.ControllerHand.Left : SDK_BaseController.ControllerHand.Right);
		return SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerHand == controllerHand;
	}
}
