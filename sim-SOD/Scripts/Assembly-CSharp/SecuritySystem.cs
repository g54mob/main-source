using System.Collections.Generic;
using UnityEngine;

public class SecuritySystem : Machine
{
	public enum SecuritySystemType
	{
		camera = 0,
		sentry = 1
	}

	[Header("Security System Components")]
	public SecuritySystemType system;

	public Animator anim;

	public GameObject laser;

	public Light laserLight;

	[Tooltip("Switch state")]
	public bool isActive;

	[Tooltip("Is the animation controller not at the end of an animation?")]
	public bool isAnimating;

	public Actor trackingTarget;

	public bool acquiredTarget;

	public MeshRenderer rend;

	public Transform rotationPivotTransform;

	public Quaternion desiredPivotRotation;

	public Transform selfTransform;

	public Quaternion desiredSelfRotation;

	public Transform muzzleTransform;

	public float seekUpdateProgress;

	public float forgetProgress;

	private float pulseProgress;

	private float focusFlashCounter;

	public List<NewAIController.TrackingTarget> activeTargets;

	public float sweepProgress;

	private InterfaceController.AwarenessIcon awarenessIcon;

	private float sentryFireProgress;

	[Header("Settings")]
	public AnimationCurve cameraSweep;

	[Tooltip("How much time in seconds before this sounds an alarm/fires")]
	public float focusGraceTime;

	[Tooltip("How much time before this stops tracking a target that it has previously seen")]
	public float focusGiveUpTime;

	public void Setup(Interactable newInteractable, bool inheritOpenStatusFromInteractable = true)
	{
	}

	public override void CreateEvidence()
	{
	}

	public void SetActive(bool open, bool skipAnimation = false)
	{
	}

	private void UpdateMaterial()
	{
	}

	public override void OnInvestigate(Actor newTarget, int escalation)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	public void ResetFocus()
	{
	}
}
