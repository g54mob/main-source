using DV.CabControls;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class WheelRotatorHaptics : MonoBehaviour
{
	private const float GRAB_HAPTIC_STRENGTH = 0.05f;

	private const float TOUCH_HAPTIC_STRENGTH = 0.03f;

	[Tooltip("Enable haptics when controller is overlapping but not grabbing")]
	public bool enableWhenTouching = true;

	public float notchAngle = 1f;

	private WheelBase wheel;

	private VRTK_InteractableObject interactable;

	public bool touchedByLeft;

	public bool touchedByRight;

	public bool grabbedByLeft;

	public bool grabbedByRight;

	private void Start()
	{
		wheel = GetComponent<WheelBase>();
		interactable = GetComponent<VRTK_InteractableObject>();
		SetupListeners(on: true);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			wheel.ValueChanged += OnValueChanged;
			interactable.InteractableObjectTouched += OnTouched;
			interactable.InteractableObjectGrabbed += OnGrabbed;
			interactable.InteractableObjectUntouched += OnUntouched;
			interactable.InteractableObjectUngrabbed += OnUngrabbed;
		}
		else
		{
			wheel.ValueChanged -= OnValueChanged;
			interactable.InteractableObjectTouched -= OnTouched;
			interactable.InteractableObjectGrabbed -= OnGrabbed;
			interactable.InteractableObjectUntouched -= OnUntouched;
			interactable.InteractableObjectUngrabbed -= OnUngrabbed;
		}
	}

	private void OnGrabbed(object sender, InteractableObjectEventArgs e)
	{
		if (e.interactingObject == VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left).scriptAlias)
		{
			grabbedByLeft = true;
		}
		if (e.interactingObject == VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right).scriptAlias)
		{
			grabbedByRight = true;
		}
	}

	private void OnTouched(object sender, InteractableObjectEventArgs e)
	{
		if (e.interactingObject == VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left).scriptAlias)
		{
			touchedByLeft = true;
		}
		if (e.interactingObject == VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right).scriptAlias)
		{
			touchedByRight = true;
		}
	}

	private void OnUngrabbed(object sender, InteractableObjectEventArgs e)
	{
		if (e.interactingObject == VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left).scriptAlias)
		{
			grabbedByLeft = false;
		}
		if (e.interactingObject == VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right).scriptAlias)
		{
			grabbedByRight = false;
		}
	}

	private void OnUntouched(object sender, InteractableObjectEventArgs e)
	{
		if (e.interactingObject == VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left).scriptAlias)
		{
			touchedByLeft = false;
		}
		if (e.interactingObject == VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right).scriptAlias)
		{
			touchedByRight = false;
		}
	}

	private void OnValueChanged(ValueChangedEventArgs e)
	{
		if ((interactable.IsGrabbed() || interactable.IsTouched()) && e.delta > notchAngle)
		{
			if (grabbedByLeft || (touchedByLeft && enableWhenTouching))
			{
				HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left), grabbedByLeft ? HapticIntensityType.Strong : HapticIntensityType.Weak);
			}
			if (grabbedByRight || (touchedByRight && enableWhenTouching))
			{
				HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right), grabbedByRight ? HapticIntensityType.Strong : HapticIntensityType.Weak);
			}
		}
	}
}
