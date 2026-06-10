using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class AnimationFrameReference : MonoBehaviour
{
	[Serializable]
	public class AnimationReference
	{
		public string name;

		public bool isArms;

		public CitizenAnimationController.IdleAnimationState idle;

		public CitizenAnimationController.ArmsBoolSate arms;

		public List<AnimationAnchorRef> anim;
	}

	[Serializable]
	public class AnimationAnchorRef
	{
		public CitizenOutfitController.CharacterAnchor anchor;

		public Vector3 localPos;

		public Quaternion localRot;
	}

	[Header("Database")]
	public List<AnimationReference> reference;

	public List<AnimationReference> walkingReference;

	public List<AnimationReference> runningReference;

	[Header("Capture")]
	public CitizenOutfitController captureFrom;

	public CitizenAnimationController.IdleAnimationState captureIdle;

	public CitizenAnimationController.ArmsBoolSate captureArms;

	private static AnimationFrameReference _instance;

	public static AnimationFrameReference Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public AnimationReference GetAnimationReference(CitizenAnimationController.ArmsBoolSate arms, string seed)
	{
		return null;
	}

	public AnimationReference GetAnimationReference(CitizenAnimationController.IdleAnimationState idle, string seed)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CaptureState()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CaptureWalkingState()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CaptureRunningState()
	{
	}
}
