using System;
using System.Collections;
using UnityEngine;

public class BerryCultist_AI : MonoBehaviour
{
	public enum AirState
	{
		Ragdolled = 0,
		Grounded = 1,
		Airborne = 2
	}

	private Rigidbody rb;

	public AirState airState = AirState.Grounded;

	private AirState airStatePrevFrame;

	[SerializeField]
	private GameObject stepOnHelperObject;

	[Header("Hover")]
	[SerializeField]
	private GameObject hoverFeetCheckPOS;

	[SerializeField]
	private LayerMask hoverGroundCheckMask;

	[SerializeField]
	private float hoverHeight;

	[SerializeField]
	private float hoverForceAmount;

	[SerializeField]
	private float hoverDampening;

	[Header("Constraints")]
	private RigidbodyConstraints Constraints_Ragdoll;

	private RigidbodyConstraints Constraints_GroundedOrAirborne = (RigidbodyConstraints)80;

	[Header("Ik Targets")]
	[SerializeField]
	private Rigidbody leftLeg_TargetRB;

	[SerializeField]
	private Rigidbody rightLeg_TargetRB;

	[Header("Movement and Torque")]
	[SerializeField]
	private float torqueToFace;

	[SerializeField]
	private float faceMovingDirTorque;

	[Header("Ragdoll State")]
	[SerializeField]
	private float ragdollRecoveryTime;

	private float ragdollRecoveryTime_Curr;

	[SerializeField]
	private float veloMagToAlwaysRagdoll;

	[SerializeField]
	private float veloMag;

	[Header("Movement")]
	[SerializeField]
	private float maxMovementSpeed;

	[SerializeField]
	private float acceleration;

	[SerializeField]
	private Vector2 newDestMinMaxTimes;

	private float findNewDest_TimerCurr;

	[SerializeField]
	private Vector3 destinationCurr;

	[SerializeField]
	private GameObject debug_DestinationVisualizer;

	private float forcedNewDestinationBuffer_Curr;

	private Vector2 searchableAreaX = new Vector2(-17f, 17f);

	private Vector2 searchableAreaZ = new Vector2(-36f, 12f);

	[SerializeField]
	private int berryTier;

	[Header("Seed Params")]
	[SerializeField]
	private int goldenBerrySeedMulti;

	private bool canMerge = true;

	public string cultistsName;

	[SerializeField]
	private GameObject canUpgrade_Particles;

	[SerializeField]
	private Animator legAnimator;

	private bool hasCheckedForNighttime;

	public CultistFaceAndNoiseHandler faceAndNoiseHandler;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		faceAndNoiseHandler = GetComponent<CultistFaceAndNoiseHandler>();
		rb.inertiaTensor = rb.inertiaTensor;
		rb.inertiaTensorRotation = rb.inertiaTensorRotation;
	}

	private void Start()
	{
		OnAirStateChanged();
		GetNewDestination();
		if (!GameManager.Singleton.spawnedCultists.Contains(this))
		{
			GameManager.Singleton.spawnedCultists.Add(this);
			StartCoroutine(WaitASec_ThenCheckForAllPumpkinsAchievement());
		}
		PlayerStats singleton = PlayerStats.Singleton;
		singleton.OnStarOrbsChanged_Action = (Action)Delegate.Combine(singleton.OnStarOrbsChanged_Action, new Action(ShowOrHideCanUpgradeParticles));
		ShowOrHideCanUpgradeParticles();
		AchievementChecks();
	}

	private IEnumerator WaitASec_ThenCheckForAllPumpkinsAchievement()
	{
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		GameManager.Singleton.NewBerryBuddy_CheckForAchievements();
	}

	private void OnDestroy()
	{
		GameManager.Singleton.spawnedCultists.Remove(this);
		PlayerStats singleton = PlayerStats.Singleton;
		singleton.OnStarOrbsChanged_Action = (Action)Delegate.Remove(singleton.OnStarOrbsChanged_Action, new Action(ShowOrHideCanUpgradeParticles));
	}

	private void ShowOrHideCanUpgradeParticles()
	{
		if (GetBerryTier() < 11)
		{
			if (HasEnoughStarsToUpgrade())
			{
				canUpgrade_Particles.SetActive(value: true);
			}
			else
			{
				canUpgrade_Particles.SetActive(value: false);
			}
		}
	}

	public bool HasEnoughStarsToUpgrade()
	{
		if (GetBerryTier() + 1 >= UpgradeTreeManager.Singleton.cultists_UpgradePrices.Count)
		{
			return false;
		}
		if (PlayerStats.Singleton.starOrbs >= UpgradeTreeManager.Singleton.cultists_UpgradePrices[GetBerryTier() + 1])
		{
			return true;
		}
		return false;
	}

	private void Update()
	{
		if (airState == AirState.Ragdolled)
		{
			HandleRagdollRecovery();
		}
		else if (airState == AirState.Grounded)
		{
			if (veloMag > veloMagToAlwaysRagdoll)
			{
				Ragdoll();
			}
		}
		else
		{
			_ = airState;
			_ = 2;
		}
	}

	private void FixedUpdate()
	{
		veloMag = rb.linearVelocity.magnitude;
		if (airState != AirState.Ragdolled)
		{
			HandleGroundHover();
			HandleTorqueToFaceDirection();
			HandleTorqueToFaceMoveDirection();
		}
		if (airState == AirState.Grounded)
		{
			HandleRoaming();
		}
		if (airState != airStatePrevFrame)
		{
			OnAirStateChanged();
		}
		airStatePrevFrame = airState;
		if (!hasCheckedForNighttime && GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			hasCheckedForNighttime = true;
			legAnimator.speed = 0f;
			ParticleSystem[] componentsInChildren = canUpgrade_Particles.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Pause();
			}
		}
	}

	private void HandleTorqueToFaceDirection()
	{
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(0f, base.transform.eulerAngles.y, 0f), torqueToFace * Time.fixedDeltaTime);
	}

	private void HandleTorqueToFaceMoveDirection()
	{
		if (rb.linearVelocity.sqrMagnitude > 0.1f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(rb.linearVelocity), faceMovingDirTorque * Time.fixedDeltaTime);
		}
	}

	private void HandleGroundHover()
	{
		Vector3 down = Vector3.down;
		Ray ray = new Ray(hoverFeetCheckPOS.transform.position, down);
		float num = 1.05f;
		if (Physics.Raycast(ray, out var hitInfo, hoverHeight * num, hoverGroundCheckMask))
		{
			airState = AirState.Grounded;
			float distance = hitInfo.distance;
			float num2 = (hoverHeight - distance) * hoverForceAmount;
			float num3 = (0f - rb.linearVelocity.y) * hoverDampening;
			try
			{
				rb.AddForce(Vector3.up * (num2 + num3), ForceMode.Acceleration);
			}
			catch
			{
			}
			if ((bool)stepOnHelperObject)
			{
				stepOnHelperObject.transform.position = hitInfo.point;
			}
		}
		else
		{
			airState = AirState.Airborne;
		}
	}

	private void OnAirStateChanged()
	{
		if (airState == AirState.Ragdolled)
		{
			rightLeg_TargetRB.isKinematic = false;
			leftLeg_TargetRB.isKinematic = false;
			rb.constraints = Constraints_Ragdoll;
		}
		else if (airState == AirState.Grounded)
		{
			rightLeg_TargetRB.isKinematic = true;
			leftLeg_TargetRB.isKinematic = true;
			rb.constraints = Constraints_GroundedOrAirborne;
		}
		else if (airState == AirState.Airborne)
		{
			rightLeg_TargetRB.isKinematic = true;
			leftLeg_TargetRB.isKinematic = true;
			rb.constraints = Constraints_GroundedOrAirborne;
		}
	}

	public void Ragdoll()
	{
		ResetRagdollRecoveryTimer();
		airState = AirState.Ragdolled;
		faceAndNoiseHandler.PlayNegativeNoise();
	}

	public void ReturnFromRagdoll()
	{
		if (!GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			airState = AirState.Grounded;
		}
	}

	private void TorqueToRotation(Rigidbody rb, Quaternion targetRotation, float torqueForce)
	{
		(targetRotation * Quaternion.Inverse(rb.rotation)).ToAngleAxis(out var angle, out var axis);
		if (angle > 180f)
		{
			angle -= 360f;
		}
		if (!(Mathf.Abs(angle) < 0.01f))
		{
			axis.Normalize();
			float num = angle * (MathF.PI / 180f);
			Vector3 torque = axis * num * torqueForce;
			rb.AddTorque(torque, ForceMode.Force);
		}
	}

	private void ResetRagdollRecoveryTimer()
	{
		ragdollRecoveryTime_Curr = ragdollRecoveryTime;
	}

	private void HandleRagdollRecovery()
	{
		if (veloMag > veloMagToAlwaysRagdoll)
		{
			ResetRagdollRecoveryTimer();
		}
		if (ragdollRecoveryTime_Curr > 0f)
		{
			ragdollRecoveryTime_Curr -= Time.deltaTime;
		}
		else
		{
			ReturnFromRagdoll();
		}
	}

	private void HandleRoaming()
	{
		Vector3 position = base.transform.position;
		position.y = 0f;
		MoveRigidBodyUpToAForce((destinationCurr - position).normalized * acceleration, maxMovementSpeed);
		if (findNewDest_TimerCurr > 0f)
		{
			findNewDest_TimerCurr -= Time.deltaTime;
		}
		else
		{
			GetNewDestination();
		}
		if (forcedNewDestinationBuffer_Curr > 0f)
		{
			forcedNewDestinationBuffer_Curr -= Time.deltaTime;
		}
	}

	private void GetNewDestination()
	{
		destinationCurr = new Vector3(UnityEngine.Random.Range(searchableAreaX.x, searchableAreaX.y), 0f, UnityEngine.Random.Range(searchableAreaZ.x, searchableAreaZ.y));
		debug_DestinationVisualizer.transform.position = destinationCurr;
		findNewDest_TimerCurr = UnityEngine.Random.Range(newDestMinMaxTimes.x, newDestMinMaxTimes.y);
	}

	public void MoveRigidBodyUpToAForce(Vector3 desiredVelocity, float maxForce)
	{
		Vector3 force = (desiredVelocity - rb.linearVelocity) * rb.mass / Time.fixedDeltaTime;
		if (force.magnitude > maxForce)
		{
			force = force.normalized * maxForce;
		}
		rb.AddForce(force);
	}

	private void OnCollisionEnter(Collision other)
	{
		other.collider.transform.root.gameObject.CompareTag("PickUp");
		if (other.collider.transform.root.gameObject.layer == 6 && forcedNewDestinationBuffer_Curr <= 0f)
		{
			findNewDest_TimerCurr = 0f;
			forcedNewDestinationBuffer_Curr = 1.25f;
		}
	}

	private void AddCuteMergePhysics()
	{
		Ragdoll();
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.AddForce(Vector3.up * 7.5f, ForceMode.VelocityChange);
		rb.AddTorque(base.transform.right * 15f, ForceMode.VelocityChange);
	}

	public int GetBerryTier()
	{
		return berryTier;
	}

	public void DisallowMerging()
	{
		canMerge = false;
	}

	public bool GetCanMerge()
	{
		return canMerge;
	}

	public void AchievementChecks()
	{
		if (berryTier == 0)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Blueberry"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Blueberry");
			}
		}
		else if (berryTier == 1)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Raspberry"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Raspberry");
			}
		}
		else if (berryTier == 2)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Strawberry"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Strawberry");
			}
		}
		else if (berryTier == 3)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Kiwi"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Kiwi");
			}
		}
		else if (berryTier == 4)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Plum"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Plum");
			}
		}
		else if (berryTier == 5)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Apple"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Apple");
			}
		}
		else if (berryTier == 6)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Pear"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Pear");
			}
		}
		else if (berryTier == 7)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Peach"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Peach");
			}
		}
		else if (berryTier == 8)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Banana"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Banana");
			}
		}
		else if (berryTier == 9)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Pineapple"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Pineapple");
			}
		}
		else if (berryTier == 10)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Watermelon"))
			{
				AchievementHelper.UnlockAchievement("ACH_Buddy_Watermelon");
			}
		}
		else if (berryTier == 11 && !AchievementHelper.IsAchievementUnlocked("ACH_Buddy_Pumpkin"))
		{
			AchievementHelper.UnlockAchievement("ACH_Buddy_Pumpkin");
		}
	}
}
