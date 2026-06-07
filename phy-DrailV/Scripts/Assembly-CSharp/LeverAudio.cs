using System;
using System.Collections;
using DV.CabControls;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class LeverAudio : MonoBehaviour
{
	private const float ANG_VEL_VOLUME_SCALE_FACTOR = 0.1f;

	public AudioClip notchClip;

	public AudioClip dragClip;

	public AudioClip hitClip;

	public bool hitVibration;

	public float hitToleranceAngle = 2f;

	public float muteAfterStart = 0.5f;

	private HingeJointAngleFix hjaf;

	private Quaternion prevRotation;

	private float prevFixedTime;

	private float maxAngle;

	private float minAngle;

	private AudioSource notchSound;

	private AudioSource dragSound;

	private AudioSource hitSound;

	private bool muted = true;

	private bool justPlayedHit;

	private void Start()
	{
		if (!TryGetComponent<HingeJointAngleFix>(out hjaf))
		{
			Debug.LogError("LeverAudio's joint is null", base.gameObject);
			UnityEngine.Object.Destroy(this);
			return;
		}
		JointLimits limits = hjaf.joint.limits;
		maxAngle = limits.max;
		minAngle = limits.min;
		dragSound = NAudio.CreateSource(base.transform, dragClip).source;
		hitSound = NAudio.CreateSource(base.transform, hitClip, 1f, 1f, loop: false).source;
		SteppedJoint component = GetComponent<SteppedJoint>();
		if ((bool)component && (bool)notchClip)
		{
			notchSound = NAudio.CreateSource(base.transform, notchClip, 1f, 1f, loop: false).source;
			component.PositionChanged += PlayNotchSound;
		}
		muted = true;
		StartCoroutine(Unmute(muteAfterStart));
	}

	private IEnumerator Unmute(float timeout)
	{
		yield return WaitFor.Seconds(timeout);
		prevRotation = base.transform.rotation;
		prevFixedTime = Time.fixedTime;
		muted = false;
	}

	private void Update()
	{
		float fixedTime = Time.fixedTime;
		if (prevFixedTime == fixedTime)
		{
			return;
		}
		if (muted)
		{
			hitSound.Stop();
			dragSound.Stop();
			return;
		}
		Quaternion rotation = base.transform.rotation;
		(rotation * Quaternion.Inverse(prevRotation)).ToAngleAxis(out var angle, out var _);
		float num = angle * ((float)Math.PI / 180f) / Time.deltaTime;
		prevRotation = rotation;
		prevFixedTime = fixedTime;
		float num2 = num * 0.1f;
		bool isPlaying = dragSound.isPlaying;
		if (num2 == 0f && isPlaying)
		{
			dragSound.Stop();
		}
		else if (num2 != 0f && !isPlaying)
		{
			dragSound.volume = num2;
			dragSound.PlayRandomTime();
		}
		else if (isPlaying)
		{
			dragSound.volume = num2;
		}
		float angle2 = hjaf.Angle;
		if (!justPlayedHit && (angle2 >= maxAngle - hitToleranceAngle || angle2 <= minAngle + hitToleranceAngle))
		{
			hitSound.volume = num2 * 3f;
			hitSound.Play();
			if (hitVibration)
			{
				Vibrate(num2);
			}
			justPlayedHit = true;
		}
		if (justPlayedHit && angle2 <= maxAngle - hitToleranceAngle && angle2 >= minAngle + hitToleranceAngle)
		{
			justPlayedHit = false;
		}
	}

	private void Vibrate(float strength)
	{
		VRTK_InteractableObject componentInParent = base.gameObject.GetComponentInParent<VRTK_InteractableObject>();
		if ((bool)componentInParent)
		{
			HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(componentInParent.GetGrabbingObject()), strength);
		}
	}

	private void PlayNotchSound(ValueChangedEventArgs _)
	{
		if ((bool)notchSound)
		{
			notchSound.Play();
		}
	}
}
