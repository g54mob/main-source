using System;
using DV.CabControls;
using DV.VR;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class SteppedPuller : MonoBehaviour
{
	private const int MAX_STEPS = 50;

	private const float CURRENT_FORCE_SQR_MAGNITUDE_THRESHOLD = 2500f;

	[Range(2f, 50f)]
	public int notches = 3;

	public bool invertEventDelta;

	private PullerBase puller;

	private ConfigurableJoint cj;

	private VRTK_InteractableObject interactableObjectVR;

	private int lastNotch;

	private float singleNotchStep;

	private float singleNotchStepNormalized;

	public event Action<ValueChangedEventArgs> PositionChanged;

	private void Start()
	{
		puller = GetComponent<PullerBase>();
		interactableObjectVR = base.gameObject.GetComponent<VRTK_InteractableObject>();
		cj = puller.GetComponent<ConfigurableJoint>();
		notches = Mathf.Clamp(notches, 2, 50);
		singleNotchStep = puller.GetTotalLinearLimitLength() / (float)notches;
		singleNotchStepNormalized = singleNotchStep / puller.GetTotalLinearLimitLength();
	}

	private void Update()
	{
		int num = Mathf.RoundToInt(puller.GetNormalizedPosition() / singleNotchStepNormalized);
		float percentPulled = (float)num * singleNotchStepNormalized;
		if (num != lastNotch)
		{
			int num2 = num - lastNotch;
			if (invertEventDelta)
			{
				num2 *= -1;
			}
			this.PositionChanged?.Invoke(new ValueChangedEventArgs(lastNotch, num, num2));
			if ((bool)interactableObjectVR && interactableObjectVR.IsGrabbed())
			{
				VRTK_ControllerReference vRTK_ControllerReference = VRTK_ControllerReference.GetControllerReference(interactableObjectVR.GetGrabbingObject());
				if (vRTK_ControllerReference.hand == SDK_BaseController.ControllerHand.None && interactableObjectVR.GetGrabbingObject().TryGetComponent<TelegrabInteractionHandler.FakeController>(out var component))
				{
					vRTK_ControllerReference = component.realController;
				}
				HapticUtils.DoHapticPulse(vRTK_ControllerReference, HapticIntensityType.Weak);
			}
		}
		else if (!puller.IsGrabbedOrHoverScrolled() && cj.currentForce.sqrMagnitude < 2500f)
		{
			puller.SetNormalizedPosition(percentPulled, moveItems: false);
		}
		lastNotch = num;
	}
}
