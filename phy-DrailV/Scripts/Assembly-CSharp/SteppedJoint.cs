using System;
using DV.CabControls;
using DV.VR;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class SteppedJoint : MonoBehaviour
{
	private const int MAX_STEPS = 50;

	[Range(2f, 50f)]
	public int notches = 3;

	public bool invertDirection;

	[NonSerialized]
	public bool isSpringActive = true;

	public bool useInnerLimitSpring;

	public int innerLimitMinNotch;

	public int innerLimitMaxNotch;

	private HingeJoint joint;

	private HingeJointAngleFix jointAngleFix;

	private VRTK_InteractableObject interactable;

	private int currentNotch;

	private int lastNotch;

	private float angleRange;

	private float cachedAngle = float.MinValue;

	private float innerLimitMinAngle;

	private float innerLimitMaxAngle;

	public float SingleNotchAngle { get; protected set; }

	public event Action<ValueChangedEventArgs> PositionChanged;

	private void Start()
	{
		joint = base.gameObject.GetComponent<HingeJoint>();
		interactable = base.gameObject.GetComponent<VRTK_InteractableObject>();
		jointAngleFix = base.gameObject.GetComponent<HingeJointAngleFix>();
		if (!jointAngleFix)
		{
			jointAngleFix = base.gameObject.AddComponent<HingeJointAngleFix>();
		}
		notches = Mathf.Clamp(notches, 2, 50);
		angleRange = (joint.useLimits ? (joint.limits.max - joint.limits.min) : 360f);
		SingleNotchAngle = angleRange / (float)(notches + (joint.useLimits ? (-1) : 0));
		if (joint.spring.spring == 0f)
		{
			Debug.LogWarning("Joint spring is set to 0, snapping to positions won't work");
		}
		joint.useSpring = true;
		float a = AngleForNotch(innerLimitMinNotch);
		float b = AngleForNotch(innerLimitMaxNotch);
		innerLimitMinAngle = Mathf.Min(a, b);
		innerLimitMaxAngle = Mathf.Max(a, b);
	}

	private void Update()
	{
		float angle = jointAngleFix.Angle;
		if (angle == cachedAngle)
		{
			return;
		}
		cachedAngle = angle;
		currentNotch = (int)Mathf.Round((angle - joint.limits.min) / SingleNotchAngle);
		float num = (float)currentNotch * SingleNotchAngle + joint.limits.min;
		if (num <= -180f)
		{
			num += 360f;
		}
		if (useInnerLimitSpring)
		{
			num = Mathf.Clamp(num, innerLimitMinAngle, innerLimitMaxAngle);
		}
		if (currentNotch < 0)
		{
			currentNotch += notches;
		}
		if (isSpringActive)
		{
			JointSpring spring = joint.spring;
			if (spring.targetPosition != num)
			{
				spring.targetPosition = num;
				joint.spring = spring;
			}
		}
		if (currentNotch != lastNotch)
		{
			int num2 = currentNotch - lastNotch;
			if (num2 < -notches / 2)
			{
				num2 += notches;
			}
			else if (num2 > notches / 2)
			{
				num2 -= notches;
			}
			if (invertDirection)
			{
				num2 *= -1;
			}
			InvokePositionChanged(num2);
			if ((bool)interactable && interactable.IsGrabbed())
			{
				VRTK_ControllerReference vRTK_ControllerReference = VRTK_ControllerReference.GetControllerReference(interactable.GetGrabbingObject());
				if (vRTK_ControllerReference.scriptAlias == null && interactable.GetGrabbingObject().TryGetComponent<TelegrabInteractionHandler.FakeController>(out var component))
				{
					vRTK_ControllerReference = component.realController;
				}
				HapticUtils.DoHapticPulse(vRTK_ControllerReference, HapticIntensityType.Weak);
			}
		}
		lastNotch = currentNotch;
	}

	private float AngleForNotch(int notch)
	{
		if (invertDirection)
		{
			return joint.limits.max - (float)notch * SingleNotchAngle;
		}
		return joint.limits.min + (float)notch * SingleNotchAngle;
	}

	public void InvokePositionChanged(float delta)
	{
		this.PositionChanged?.Invoke(new ValueChangedEventArgs(lastNotch, currentNotch, delta));
	}
}
