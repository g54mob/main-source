using DV.CabControls;
using DV.InventorySystem;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class ToggleInteractionStyle : MonoBehaviour
{
	private GrabMethodValues currentGrabMethod = GrabMethodValues.Undefined;

	private VRTK_InteractableObject interactionTargetInteractable;

	private VRTK_InteractGrab_DV grab;

	private VRTK_InteractUse_DV use;

	private ItemBeltVR itemBeltVR;

	private ControllerType_DV controllerType;

	private SDK_BaseController.ControllerHand hand;

	private TouchpadInputInterpreter touchpadInputInterpreter;

	private VRTK_ControllerEvents controllerEvents;

	private bool ignoreNextUngrab;

	private bool forceDropOnFirstGrabRelease;

	private VRTK_ControllerEvents.ButtonAlias itemGrabButton;

	private void Awake()
	{
		VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
	}

	public void Initialize()
	{
		grab = GetComponent<VRTK_InteractGrab_DV>();
		use = GetComponent<VRTK_InteractUse_DV>();
		touchpadInputInterpreter = GetComponent<TouchpadInputInterpreter>();
		controllerType = VRTK_ControllerReference.GetControllerReference(base.gameObject).GetControllerTypeDV();
		itemGrabButton = SetupDeviceSpecificControls.grabButtonDictionary[controllerType];
		itemBeltVR = InventoryViewVR.Instance.beltVR;
		hand = VRTK_DeviceFinder.GetControllerHand(base.gameObject);
		controllerEvents = grab.GetComponentInChildren<VRTK_ControllerEvents>();
		SetupListeners(on: true);
		OnGrabMethodPreferenceUpdated();
	}

	private void OnDestroy()
	{
		VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SetStateAndFixIfNeeded();
			grab.ControllerGrabInteractableObject += OnBeginInteraction;
			grab.ControllerUngrabInteractableObject += OnEndInteraction;
			grab.GrabButtonReleased += OnGrabButtonReleased;
			grab.AboutToForceGrab += OnAboutToForceGrab;
			GamePreferences.RegisterToPreferenceUpdated(Preferences.ItemHoldType, OnGrabMethodPreferenceUpdated);
			itemBeltVR.ItemEquippedFromBelt += OnItemEquippedFromBelt;
			SetWandListeners(on: true);
		}
		else
		{
			grab.ControllerGrabInteractableObject -= OnBeginInteraction;
			grab.ControllerUngrabInteractableObject -= OnEndInteraction;
			grab.GrabButtonReleased -= OnGrabButtonReleased;
			grab.AboutToForceGrab -= OnAboutToForceGrab;
			use.UseModifierEnabled -= OnUseModified;
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.ItemHoldType, OnGrabMethodPreferenceUpdated);
			itemBeltVR.ItemEquippedFromBelt -= OnItemEquippedFromBelt;
			SetWandListeners(on: false);
		}
	}

	private void SetWandListeners(bool on)
	{
		if (controllerType == ControllerType_DV.ViveWand && !(touchpadInputInterpreter == null))
		{
			if (on)
			{
				grab.DropItemButtonPressed += OnWandDropItemButtonPressed;
			}
			else
			{
				grab.DropItemButtonPressed -= OnWandDropItemButtonPressed;
			}
		}
	}

	private void OnWandDropItemButtonPressed(object sender, ControllerInteractionEventArgs e)
	{
		if (controllerEvents.triggerClicked)
		{
			GameObject grabbedObject = grab.GetGrabbedObject();
			if (!(grabbedObject == null) && !(grabbedObject.GetComponent<ItemBase>() == null))
			{
				ignoreNextUngrab = false;
				ReleaseItemProcess(byUngrabButton: false);
			}
		}
	}

	private void OnItemEquippedFromBelt(SDK_BaseController.ControllerHand hand)
	{
		if (hand == this.hand && currentGrabMethod == GrabMethodValues.ClickHold)
		{
			forceDropOnFirstGrabRelease = controllerType == ControllerType_DV.ViveWand || controllerType == ControllerType_DV.Undefined;
		}
	}

	private void OnUseModified()
	{
		if (controllerType != ControllerType_DV.ViveWand && controllerType != ControllerType_DV.Undefined)
		{
			ignoreNextUngrab = true;
			forceDropOnFirstGrabRelease = false;
		}
	}

	private void OnAboutToForceGrab(bool isItem, bool usingGrabButton)
	{
		if (isItem)
		{
			forceDropOnFirstGrabRelease = !usingGrabButton;
		}
	}

	private void SetStateAndFixIfNeeded()
	{
		currentGrabMethod = (GrabMethodValues)GamePreferences.Get<int>(Preferences.ItemHoldType);
		if (currentGrabMethod == GrabMethodValues.Undefined || (controllerType == ControllerType_DV.ViveWand && currentGrabMethod == GrabMethodValues.Hold))
		{
			switch (controllerType)
			{
			case ControllerType_DV.ViveWand:
				currentGrabMethod = GrabMethodValues.ClickHold;
				break;
			case ControllerType_DV.ValveIndex:
				currentGrabMethod = GrabMethodValues.Hold;
				break;
			default:
				currentGrabMethod = GrabMethodValues.ClickHold;
				break;
			}
			GamePreferences.Set(Preferences.ItemHoldType, currentGrabMethod);
		}
	}

	private void OnGrabMethodPreferenceUpdated()
	{
		SetStateAndFixIfNeeded();
		if (controllerType != ControllerType_DV.ViveWand && controllerType != ControllerType_DV.Undefined)
		{
			use.UseModifierEnabled -= OnUseModified;
			if (currentGrabMethod == GrabMethodValues.ClickHold)
			{
				use.UseModifierEnabled += OnUseModified;
			}
		}
	}

	private void OnBeginInteraction(object sender, ObjectInteractEventArgs e)
	{
		IInteractionStyleTarget component = e.target.GetComponent<IInteractionStyleTarget>();
		if (ValidInteractionTarget(component))
		{
			interactionTargetInteractable = component.Interactable;
			if (currentGrabMethod == GrabMethodValues.ClickHold)
			{
				interactionTargetInteractable.holdButtonToGrab = false;
				ignoreNextUngrab = true;
			}
		}
	}

	private bool ValidInteractionTarget(IInteractionStyleTarget interactionStyleTarget)
	{
		if (interactionStyleTarget != null && interactionStyleTarget is Component)
		{
			return interactionStyleTarget.Interactable != null;
		}
		return false;
	}

	private void OnEndInteraction(object sender, ObjectInteractEventArgs e)
	{
		if (interactionTargetInteractable == null)
		{
			if (grab.grabButton != itemGrabButton)
			{
				grab.grabButton = itemGrabButton;
			}
			return;
		}
		if (interactionTargetInteractable.GetGrabbingObject() == null)
		{
			interactionTargetInteractable.holdButtonToGrab = true;
		}
		ignoreNextUngrab = false;
		forceDropOnFirstGrabRelease = false;
		interactionTargetInteractable = null;
	}

	private void OnGrabButtonReleased(object sender, ControllerInteractionEventArgs e)
	{
		if (!e.controllerReference.IsWandOrUndefined() || (!(interactionTargetInteractable == null) && !interactionTargetInteractable.GetComponent<ItemBase>()))
		{
			ReleaseItemProcess(byUngrabButton: false);
		}
	}

	private void ReleaseItemProcess(bool byUngrabButton)
	{
		if (!interactionTargetInteractable)
		{
			return;
		}
		if (currentGrabMethod == GrabMethodValues.Hold)
		{
			if (byUngrabButton)
			{
				grab.ForceRelease(applyGrabbingObjectVelocity: true);
			}
		}
		else if (currentGrabMethod == GrabMethodValues.ClickHold)
		{
			if (!forceDropOnFirstGrabRelease && ignoreNextUngrab)
			{
				ignoreNextUngrab = false;
			}
			else
			{
				grab.ForceRelease(applyGrabbingObjectVelocity: true);
			}
		}
	}
}
