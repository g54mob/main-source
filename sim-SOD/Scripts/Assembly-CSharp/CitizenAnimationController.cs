using System;
using System.Collections.Generic;
using UnityEngine;

public class CitizenAnimationController : MonoBehaviour
{
	public enum ArmsBoolSate
	{
		none = 0,
		armsResting = 1,
		armsTyping = 2,
		armsUse = 3,
		armsLocking = 4,
		armsCuffed = 5,
		armsConsuming = 6,
		armsOneShotUse = 7,
		armsSmoking = 8,
		armsSmokingPipe = 9,
		armsReading = 10,
		armsFleeing = 11
	}

	public enum IdleAnimationState
	{
		none = 0,
		sitting = 1,
		sweeping = 2,
		warmingHands = 3,
		telephone = 4,
		washingHands = 5,
		cleaningBar = 6,
		bargingDoor = 7,
		cookingChopping = 8,
		cookingFrying = 9,
		sitAgainstWall = 10,
		leanAgainstWall = 11,
		showering = 12,
		rubbingEyes = 13,
		cowering = 14,
		checkPulse = 15,
		brushingTeeth = 16,
		pickUpFromFloor = 17,
		danceTwist = 18,
		danceWatusi = 19,
		stackingObjects = 20,
		stackingObjectsCrouching = 21
	}

	[Serializable]
	public class CitizenPhysics
	{
		public CitizenOutfitController.AnchorConfig anchorConfig;

		public Collider coll;

		public Rigidbody rb;
	}

	[Serializable]
	public class RagdollSnapshot
	{
		public CitizenOutfitController.AnchorConfig anchorConfig;

		public Vector3 localPos;

		public Quaternion localRot;
	}

	[Serializable]
	public class RagdollSnapshotWorld
	{
		public CitizenOutfitController.AnchorConfig anchorConfig;

		public Vector3 worldPos;

		public Quaternion worldRot;
	}

	public Human cit;

	public Animator mainAnimator;

	public GameObject spawnedUmbrella;

	public Transform umbrellaCanopy;

	public float armsLayerDesiredWeight;

	public float umbreallLayerDesiredWeight;

	public float oneShotUseReset;

	public ArmsBoolSate armsBoolAnimationState;

	public IdleAnimationState idleAnimationState;

	public bool flipToRightAnimation;

	public bool paused;

	public bool umbrella;

	public float unpausedAnimatorSpeed;

	[Header("Human Components")]
	public Transform armsParent;

	public BoxCollider newBoxCollider;

	[NonSerialized]
	public Rigidbody upperTorsoRB;

	[Header("Ragdoll")]
	public Dictionary<CitizenOutfitController.CharacterAnchor, CitizenPhysics> physicsComponents;

	[NonSerialized]
	public List<Rigidbody> createdRBs;

	[NonSerialized]
	public List<CharacterJoint> createdJoints;

	[NonSerialized]
	public List<Collider> createdColliders;

	[NonSerialized]
	public RagdollSFXController sfx;

	private CharacterJoint headJoint;

	private CharacterJoint upperTorsoJoint;

	private CharacterJoint midriffJoint;

	private CharacterJoint leftUpperArmJoint;

	private CharacterJoint leftLowerArmJoint;

	private CharacterJoint leftHandJoint;

	private CharacterJoint rightUpperArmJoint;

	private CharacterJoint rightLowerArmJoint;

	private CharacterJoint rightHandJoint;

	private CharacterJoint leftUpperLegJoint;

	private CharacterJoint leftLowerLegJoint;

	private CharacterJoint rightUpperLegJoint;

	private CharacterJoint rightLowerLegJoint;

	private CharacterJoint rightFootJoint;

	private CharacterJoint leftFootJoint;

	[NonSerialized]
	public List<RagdollSnapshot> ragdollSnapshot;

	[Header("Debug")]
	public float debugMainAnimatorSpeed;

	public void ForceUpdateAnimationSate(bool onBecomeVisibile = false)
	{
	}

	public void UpdateMovementSpeed()
	{
	}

	public void SetArmsBoolState(ArmsBoolSate newState)
	{
	}

	public void SetUmbrella(bool val)
	{
	}

	public void SetCarryingItem(bool val)
	{
	}

	public void SetCarryItemType(int carryType)
	{
	}

	public void SetInCombat(bool val)
	{
	}

	public void SetCombatArmsOverride(int val)
	{
	}

	public void SetRestrained(bool val)
	{
	}

	public void SetIdleAnimationState(IdleAnimationState newState)
	{
	}

	public void SetInBed(bool val, bool isLowBed, bool onRightSide = false, bool instant = false)
	{
	}

	public void FlipAnimationToRight(bool val)
	{
	}

	public void SetDead(bool val)
	{
	}

	public void TriggerTrip()
	{
	}

	public void CancelTrip()
	{
	}

	public void AttackTrigger()
	{
	}

	public void ThrowTrigger()
	{
	}

	public void AbortAttackTrigger()
	{
	}

	public void BlockTrigger(float blockDelay, bool perfect = false)
	{
	}

	public void TakeDamageRecoil(Vector3 hitPosition)
	{
	}

	public void SetPauseAnimation(bool val)
	{
	}

	public void SetRagdoll(bool val, bool dead = false)
	{
	}

	private void ApplyRagdollJointSettings(ref CharacterJoint joint)
	{
	}

	public List<RagdollSnapshot> GetLimbSnapshot()
	{
		return null;
	}

	public List<RagdollSnapshotWorld> GetLimbSnapshotWorld()
	{
		return null;
	}

	public void LoadLimbSnapshot(List<RagdollSnapshot> snapshot)
	{
	}

	public void LoadLimbSnapshot(List<RagdollSnapshotWorld> snapshot)
	{
	}
}
