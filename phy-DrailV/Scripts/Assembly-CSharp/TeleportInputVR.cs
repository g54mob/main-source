using System;
using System.Collections.Generic;
using DV.CabControls;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class TeleportInputVR : MonoBehaviour
{
	private VRTK_ControllerEvents controllerEvents;

	private VRTK_ControllerEvents.ButtonAlias teleportButton;

	private bool isViveWand;

	private bool teleportAborted;

	private VRTK_InteractGrab grab;

	private readonly Dictionary<ControllerType_DV, VRTK_ControllerEvents.ButtonAlias> teleportButtonDictionary = new Dictionary<ControllerType_DV, VRTK_ControllerEvents.ButtonAlias>
	{
		{
			ControllerType_DV.ViveWand,
			VRTK_ControllerEvents.ButtonAlias.GripPress
		},
		{
			ControllerType_DV.ValveIndex,
			VRTK_ControllerEvents.ButtonAlias.ButtonOnePress
		},
		{
			ControllerType_DV.RiftTouch,
			VRTK_ControllerEvents.ButtonAlias.ButtonOnePress
		},
		{
			ControllerType_DV.QuestTouch,
			VRTK_ControllerEvents.ButtonAlias.ButtonOnePress
		},
		{
			ControllerType_DV.WMR,
			VRTK_ControllerEvents.ButtonAlias.TouchpadPress
		},
		{
			ControllerType_DV.HPReverbG2,
			VRTK_ControllerEvents.ButtonAlias.ButtonOnePress
		},
		{
			ControllerType_DV.Cosmos,
			VRTK_ControllerEvents.ButtonAlias.ButtonOnePress
		}
	};

	public VRTK_ControllerEvents.ButtonAlias TeleportButton => teleportButton;

	public bool IsHighPrioritySpecialCase => isViveWand;

	public event Action TeleportButtonPressed;

	public event Action TeleportButtonReleased;

	public event Action TeleportAbortRequested;

	private void Awake()
	{
		controllerEvents = GetComponentInParent<VRTK_ControllerEvents>();
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(controllerEvents.gameObject);
		ControllerType_DV controllerTypeDV = controllerReference.GetControllerTypeDV();
		isViveWand = controllerReference.IsWandOrUndefined();
		if (isViveWand)
		{
			grab = controllerEvents.GetComponentInParent<VRTK_InteractGrab>();
		}
		if (!teleportButtonDictionary.TryGetValue(controllerTypeDV, out teleportButton))
		{
			teleportButton = teleportButtonDictionary[ControllerType_DV.ViveWand];
		}
		SetupListeners(on: true);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			controllerEvents.SubscribeToButtonAliasEvent(teleportButton, startEvent: true, OnTeleportRequestStart);
			if (isViveWand)
			{
				grab.ControllerGrabInteractableObject += OnControllerGrabInteractableObject;
				controllerEvents.SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: true, TriggerClicked);
				controllerEvents.SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: false, TriggerUnclicked);
			}
			return;
		}
		controllerEvents.UnsubscribeToButtonAliasEvent(teleportButton, startEvent: true, OnTeleportRequestStart);
		controllerEvents.UnsubscribeToButtonAliasEvent(teleportButton, startEvent: false, OnTeleportRequestEnd);
		if (isViveWand)
		{
			grab.ControllerGrabInteractableObject -= OnControllerGrabInteractableObject;
			controllerEvents.UnsubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: true, TriggerClicked);
			controllerEvents.UnsubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: false, TriggerUnclicked);
		}
	}

	private void TriggerClicked(object sender, ControllerInteractionEventArgs e)
	{
		GameObject grabbedObject = grab.GetGrabbedObject();
		if (!(grabbedObject == null) && !(grabbedObject.GetComponent<ItemBase>() == null))
		{
			teleportAborted = true;
			this.TeleportAbortRequested?.Invoke();
		}
	}

	private void TriggerUnclicked(object sender, ControllerInteractionEventArgs e)
	{
		if (teleportAborted)
		{
			teleportAborted = controllerEvents.IsButtonPressed(teleportButton);
		}
	}

	private void OnControllerGrabInteractableObject(object sender, ObjectInteractEventArgs e)
	{
		if (isViveWand && controllerEvents.IsButtonPressed(teleportButton))
		{
			teleportAborted = true;
			this.TeleportAbortRequested?.Invoke();
		}
	}

	private void OnTeleportRequestStart(object sender, ControllerInteractionEventArgs e)
	{
		if (!teleportAborted)
		{
			controllerEvents.SubscribeToButtonAliasEvent(teleportButton, startEvent: false, OnTeleportRequestEnd);
			this.TeleportButtonPressed?.Invoke();
		}
	}

	private void OnTeleportRequestEnd(object sender, ControllerInteractionEventArgs e)
	{
		controllerEvents.UnsubscribeToButtonAliasEvent(teleportButton, startEvent: false, OnTeleportRequestEnd);
		if (teleportAborted)
		{
			teleportAborted = controllerEvents.triggerClicked;
		}
		else
		{
			this.TeleportButtonReleased?.Invoke();
		}
	}
}
