using System;
using DV;
using DV.CabControls;
using DV.InventorySystem;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class ControllerPipa : MonoBehaviour
{
	private const bool PIPA_GLOBAL_SWITCH = false;

	private static float[] MATERIAL_TOUCH_PARAMS = new float[2] { 0.83f, 0.26f };

	[NonSerialized]
	public VRTK_InteractGrab grab;

	private static Material touchMaterial;

	private static Material originalMaterial;

	private Renderer pipaRenderer;

	private int thirdCameraLayer;

	private int defaultLayer;

	private void Start()
	{
		pipaRenderer = GetComponentInChildren<Renderer>(includeInactive: true);
		pipaRenderer.enabled = false;
		if (originalMaterial == null)
		{
			originalMaterial = pipaRenderer.material;
			touchMaterial = UnityEngine.Object.Instantiate(originalMaterial);
			touchMaterial.SetFloat("_FPOW", MATERIAL_TOUCH_PARAMS[0]);
			touchMaterial.SetFloat("_R0", MATERIAL_TOUCH_PARAMS[1]);
		}
		defaultLayer = pipaRenderer.gameObject.layer;
		thirdCameraLayer = LayerMask.NameToLayer("Ignore Raycast");
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
		if ((bool)grab)
		{
			if (on)
			{
				grab.interactTouch.ControllerTouchInteractableObject += OnTouch;
				grab.interactTouch.ControllerUntouchInteractableObject += OnUntouch;
				grab.ControllerGrabInteractableObject += OnGrab;
				grab.ControllerUngrabInteractableObject += OnUngrab;
				InventoryViewVR.Instance.BigInventoryOpenChanged += OnBigInventoryOpenChanged;
			}
			else
			{
				grab.interactTouch.ControllerTouchInteractableObject -= OnTouch;
				grab.interactTouch.ControllerUntouchInteractableObject -= OnUntouch;
				grab.ControllerGrabInteractableObject -= OnGrab;
				grab.ControllerUngrabInteractableObject -= OnUngrab;
				InventoryViewVR.Instance.BigInventoryOpenChanged -= OnBigInventoryOpenChanged;
			}
		}
	}

	private void OnBigInventoryOpenChanged()
	{
		pipaRenderer.gameObject.layer = (InventoryViewVR.Instance.BigInventoryOpen ? thirdCameraLayer : defaultLayer);
	}

	private void OnTouch(object _, ObjectInteractEventArgs e)
	{
		if (!base.isActiveAndEnabled)
		{
			return;
		}
		VRTK_InteractableObject vRTK_InteractableObject = (e.target ? e.target.GetComponent<VRTK_InteractableObject>() : null);
		if ((bool)vRTK_InteractableObject && IsUsableOrGrabbable(vRTK_InteractableObject))
		{
			pipaRenderer.material = touchMaterial;
			if (!IsGrabbedItemOrItemInBelt(vRTK_InteractableObject))
			{
				DoHaptics(vRTK_InteractableObject);
			}
		}
	}

	private void OnUntouch(object _, ObjectInteractEventArgs e)
	{
		if (base.isActiveAndEnabled)
		{
			pipaRenderer.material = originalMaterial;
			VRTK_InteractableObject vRTK_InteractableObject = (e.target ? e.target.GetComponent<VRTK_InteractableObject>() : null);
			if ((bool)vRTK_InteractableObject && IsUsableOrGrabbable(vRTK_InteractableObject) && !IsGrabbedItemOrItemInBelt(vRTK_InteractableObject))
			{
				DoHaptics(vRTK_InteractableObject);
			}
		}
	}

	private void DoHaptics(VRTK_InteractableObject interactable)
	{
		if ((!GamePreferences.Get<bool>(Preferences.TouchInteraction) || interactable.GetComponent<IControlTouchBehaviourVRTK>() == null) && interactable.GetComponent<VRTK_InteractHaptics>() == null)
		{
			HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(grab.gameObject), HapticIntensityType.Normal);
		}
	}

	private void OnGrab(object _, ObjectInteractEventArgs __)
	{
		pipaRenderer.enabled = false;
	}

	private void OnUngrab(object _, ObjectInteractEventArgs __)
	{
		if (!SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen)
		{
			pipaRenderer.enabled = false;
		}
	}

	private bool IsUsableOrGrabbable(VRTK_InteractableObject interactable)
	{
		if ((bool)interactable)
		{
			if (!interactable.isUsable)
			{
				return interactable.isGrabbable;
			}
			return true;
		}
		return false;
	}

	private bool IsGrabbedItemOrItemInBelt(VRTK_InteractableObject interactable)
	{
		ItemBase itemBase = ((interactable != null) ? interactable.GetComponent<ItemBase>() : null);
		if (itemBase != null)
		{
			if (!itemBase.IsGrabbed())
			{
				return itemBase.IsInBelt();
			}
			return true;
		}
		return false;
	}
}
