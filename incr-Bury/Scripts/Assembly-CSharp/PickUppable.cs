using System;
using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;

public class PickUppable : MonoBehaviour
{
	[Header("Item Identity")]
	[SerializeField]
	private ItemIdentity itemIdentity;

	[SerializeField]
	private PickUpType pickUpType;

	[SerializeField]
	private StarOrbsToSpawnWhenDeposited starOrbsToSpawnWhenDeposited;

	public bool starOrbFromMilestone;

	public int additionalOneStarOrbsToSpawnWhenDeposited;

	[Header("Hold Offsets")]
	public Vector3 held_PositionOffset;

	public Vector3 held_RotationOffset;

	[Header("Interactions")]
	public bool canPickUp = true;

	public bool canBeKicked = true;

	public bool enableGravityWhenInteractedWith;

	private bool hasBeenActivated_MileStone;

	private bool hasBeenInteractedWithByPlayer;

	private bool hasVoidBoxMovedAboveGroundAfterSpawn;

	public bool recentlyThrown;

	public float recentlyThrown_Time_Curr;

	private const float RECENTLY_THROWN_TIME = 3f;

	public bool dontTorqueWhenDropped;

	[Header("Currency Values")]
	public int coinValue;

	public float holeJuiceValue;

	public int starOrbsValue;

	private Renderer[] allRenderers;

	private Collider[] allColliders;

	private Rigidbody rb;

	public bool isHeld;

	[SerializeField]
	private float heldDrag;

	[SerializeField]
	private float heldAngularDrag;

	private float startingDrag;

	private float startingAngularDrag;

	private Collider lastHitCollider;

	public Action OnThrown_Action;

	public Action OnPickUp_Action;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player feedback_Impact;

	public BerryCultist_AI cultistScript;

	public int cultistCoinValue;

	private Berry berryScript;

	public bool hasBeenDepositedInHole;

	public const float ANOMALOUSMATERIAL_SLIGHTGRAVITY = 3f;

	[Header("Void Box Params")]
	public bool isBonusVoidBox;

	[Header("Breakable")]
	private bool hasBroken;

	[SerializeField]
	private GameObject brokenPrefab;

	[Header("Milestone Related")]
	public bool isFunPhysicsFakeMilestone;

	public int smoothie_holePrestigeJuice;

	public int JUICED_amt;

	private float autoStarOrbPop_Timer = 8f;

	private bool hasUpgradedSomethingThisThrow;

	private bool hasBrokenSomethingThisRound;

	[Header("Large Objects")]
	public bool isLargeEnoughToNotImmediatelyDeposit;

	private bool isLargeAndDepositing;

	private float largeItem_DepositBuffer = 1.5f;

	private float impactNoise_Buffer;

	public bool doNotEnablePhysicsWhenHit;

	public bool doNotFreezeAtNight;

	public bool doNotDestroyInHole;

	[Header("Disk")]
	public int disk_Index;

	[Header("Black Star Orb")]
	public int puzzleIdentity_Index = -1;

	[Header("Gnome")]
	public bool isGnome;

	[Header("Star Orb Model Swap")]
	public MeshFilter starOrb_Star_MeshFilter;

	[Header("Cassette")]
	public int cassetteIndex;

	private const float FLING_ARCFROMDIST_MIN = 8f;

	private const float FLING_ARCFROMDIST_MAX = 50f;

	private const float FLING_ARCFROMDIST_MULT = 0.4f;

	public virtual void Awake()
	{
		rb = GetComponent<Rigidbody>();
		startingDrag = rb.linearDamping;
		startingAngularDrag = rb.angularDamping;
		SetDrag_NotHeld();
		ReferenceCollidersAndRenderers();
	}

	private void Start()
	{
		if (itemIdentity == ItemIdentity.Cultist)
		{
			cultistScript = GetComponent<BerryCultist_AI>();
			cultistCoinValue = ShopAndUpgradesManager.Singleton.BerryCoinValueList[cultistScript.GetBerryTier()];
		}
		else if (pickUpType == PickUpType.Berry)
		{
			berryScript = GetComponent<Berry>();
			if (berryScript != null && berryScript.berryTier != 100)
			{
				coinValue = ShopAndUpgradesManager.Singleton.BerryCoinValueList[berryScript.berryTier];
			}
		}
		else if (pickUpType == PickUpType.VoidBox || pickUpType == PickUpType.AnomalousMaterial)
		{
			DisableColliders_Local();
		}
		GameManager.Singleton.allSpawnedPickuppables.Add(this);
	}

	private void OnDestroy()
	{
		GameManager.Singleton.allSpawnedPickuppables.Remove(this);
	}

	public void StartLargeObjectDepositingTimer()
	{
		isLargeAndDepositing = true;
		DisableColliders_Local();
	}

	private void Update()
	{
		if (isLargeEnoughToNotImmediatelyDeposit && isLargeAndDepositing)
		{
			if (largeItem_DepositBuffer > 0f)
			{
				largeItem_DepositBuffer -= Time.deltaTime;
				return;
			}
			GameManager.Singleton.SpawnStarOrbsFromHoleDeposit(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void FixedUpdate()
	{
		if (pickUpType == PickUpType.VoidBox)
		{
			if (!rb.useGravity)
			{
				if (base.transform.position.y > 5.5f)
				{
					rb.AddForce(Vector3.down * 3f, ForceMode.Acceleration);
				}
				else if (base.transform.position.y < 1f)
				{
					if (hasVoidBoxMovedAboveGroundAfterSpawn)
					{
						rb.useGravity = true;
					}
					rb.AddForce(Vector3.down * 3f, ForceMode.Acceleration);
				}
			}
		}
		else if (pickUpType == PickUpType.AnomalousMaterial)
		{
			if (base.transform.position.y > 7f)
			{
				rb.AddForce(Vector3.down * 3f, ForceMode.Acceleration);
			}
			if (base.transform.position.y < 2.5f)
			{
				rb.AddForce(Vector3.up * 2.25f, ForceMode.Acceleration);
			}
		}
		if ((pickUpType == PickUpType.VoidBox || pickUpType == PickUpType.AnomalousMaterial) && !hasVoidBoxMovedAboveGroundAfterSpawn && base.transform.position.y > 1.8f)
		{
			EnableColliders_Local();
			rb.useGravity = false;
			hasVoidBoxMovedAboveGroundAfterSpawn = true;
		}
		if (recentlyThrown_Time_Curr > 0f)
		{
			recentlyThrown = true;
			recentlyThrown_Time_Curr -= Time.fixedDeltaTime;
			if (recentlyThrown_Time_Curr <= 0f)
			{
				recentlyThrown = false;
			}
		}
		HandleAutoStarOrbPopping();
		HandleImpactNoiseBuffer();
	}

	private void HandleImpactNoiseBuffer()
	{
		if (impactNoise_Buffer > 0f)
		{
			impactNoise_Buffer -= Time.fixedDeltaTime;
		}
	}

	public void OnPickUp()
	{
		if (OnPickUp_Action != null)
		{
			OnPickUp_Action();
		}
		rb.isKinematic = false;
		SetDrag_Held();
		isHeld = true;
		lastHitCollider = null;
		hasBeenInteractedWithByPlayer = true;
		hasUpgradedSomethingThisThrow = false;
		recentlyThrown = false;
		recentlyThrown_Time_Curr = 0f;
	}

	public void OnDrop()
	{
		if (OnThrown_Action != null)
		{
			OnThrown_Action();
		}
		if (!GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			rb.isKinematic = false;
		}
		if (enableGravityWhenInteractedWith)
		{
			rb.useGravity = true;
		}
		SetDrag_NotHeld();
		isHeld = false;
		_ = pickUpType;
		_ = 3;
		ResetRecentlyThrownTime();
		hasBeenInteractedWithByPlayer = true;
	}

	public void ResetRecentlyThrownTime()
	{
		recentlyThrown_Time_Curr = 3f;
		recentlyThrown = true;
	}

	public void OnKick()
	{
		PlayImpactFeedback(_playSFX: true);
		if (!GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			rb.isKinematic = false;
		}
		if (enableGravityWhenInteractedWith)
		{
			rb.useGravity = true;
		}
		_ = pickUpType;
		_ = 3;
		if (itemIdentity == ItemIdentity.Cultist)
		{
			cultistScript.faceAndNoiseHandler.PlayNegativeNoise();
		}
		hasBeenInteractedWithByPlayer = true;
	}

	public void SetDrag_NotHeld()
	{
		rb.linearDamping = startingDrag;
		rb.angularDamping = startingAngularDrag;
	}

	public void SetDrag_Held()
	{
		rb.linearDamping = heldDrag;
		rb.angularDamping = heldAngularDrag;
	}

	public virtual void OnUseHeld()
	{
	}

	public virtual void UpdateHoldPosAndRot(HoldSpotHelper _holdSpotHelper)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider != lastHitCollider)
		{
			if (collision.gameObject.CompareTag("ConveyorBelt"))
			{
				return;
			}
			float num = collision.impulse.magnitude / Time.fixedDeltaTime;
			if (num > 200f)
			{
				PlayImpactFeedback(_playSFX: true, num);
			}
			lastHitCollider = collision.collider;
		}
		if (pickUpType == PickUpType.AnomalousMaterial)
		{
			if ((!hasBeenInteractedWithByPlayer && !collision.gameObject.CompareTag("PopGunDart")) || (!(collision.impulse.sqrMagnitude >= 1000f) && !collision.gameObject.CompareTag("PopGunDart")) || hasBroken)
			{
				return;
			}
			try
			{
				PickUppable component = collision.gameObject.transform.root.GetComponent<PickUppable>();
				if (component.GetItemIdentity() == ItemIdentity.AnomalousMaterial)
				{
					component.hasBeenInteractedWithByPlayer = true;
				}
			}
			catch
			{
			}
			BreakStarOrb();
		}
		else if (itemIdentity == ItemIdentity.StarWand)
		{
			if (hasUpgradedSomethingThisThrow || !recentlyThrown || GameManager.Singleton.gameState != GameManager.GameState.Playing || collision.collider.gameObject.layer != 9)
			{
				return;
			}
			BerryCultist_AI component2 = collision.collider.transform.root.gameObject.GetComponent<BerryCultist_AI>();
			if (!component2 || component2.GetBerryTier() >= 12)
			{
				return;
			}
			if (PlayerStats.Singleton.starOrbs >= UpgradeTreeManager.Singleton.cultists_UpgradePrices[component2.GetBerryTier() + 1])
			{
				if (component2.GetCanMerge())
				{
					component2.DisallowMerging();
					string cultistsName = component2.cultistsName;
					int berryTier = component2.GetBerryTier();
					Vector3 position = component2.transform.position;
					UnityEngine.Object.Destroy(collision.collider.transform.root.gameObject);
					BerryCultist_AI berryCultist_AI = UpgradeTreeManager.Singleton.SpawnANewCultistFromUpgradeButtonClick(berryTier + 1, _randomizeName: false);
					berryCultist_AI.cultistsName = cultistsName;
					berryCultist_AI.transform.position = position;
					int num2 = UpgradeTreeManager.Singleton.cultists_UpgradePrices[berryCultist_AI.GetBerryTier()];
					PlayerStats.Singleton.SpendStarOrbs(num2);
					if (berryTier == 11)
					{
						PlayerStats.Singleton.reimbursementStars += num2;
					}
					hasUpgradedSomethingThisThrow = true;
					recentlyThrown = false;
					recentlyThrown_Time_Curr = 0f;
					if (berryTier + 1 > PlayerStats.Singleton.highestBerryTierGrown && berryTier < 11)
					{
						PlayerStats.Singleton.highestBerryTierGrown++;
					}
					AudioManager.Singleton.PlayUpgradeCultistSFX(berryCultist_AI.transform.position, berryTier == 11);
					GameObject obj2 = UnityEngine.Object.Instantiate(GameManager.Singleton.prefabBank.cultistUpgradeParticles_Prefab, berryCultist_AI.transform.position, Quaternion.identity);
					obj2.transform.SetParent(berryCultist_AI.transform);
					obj2.transform.localPosition = Vector3.zero;
					GameManager.Singleton.OnBerryBuddyUpgraded_CallEvent();
				}
			}
			else
			{
				AudioManager.Singleton.PlayCannotUpgradeCultistSFX(base.transform.position);
				recentlyThrown = false;
				recentlyThrown_Time_Curr = 0f;
			}
		}
		else
		{
			if (itemIdentity == ItemIdentity.SledgeHammer)
			{
				if (!recentlyThrown || GameManager.Singleton.gameState != GameManager.GameState.Playing || !collision.transform.root.gameObject.CompareTag("Walls"))
				{
					return;
				}
				try
				{
					BreakableWall component3 = collision.transform.root.GetComponent<BreakableWall>();
					if (PlayerStats.Singleton.SledgeHammer_Tier >= component3.wallTier)
					{
						if (component3.wallTier == 1 && !GameManager.Singleton.demo_HasBrokenTier2Wall)
						{
							GameManager.Singleton.demo_HasBrokenTier2Wall = true;
						}
						recentlyThrown = false;
						recentlyThrown_Time_Curr = 0f;
						component3.BreakWall(base.transform.position);
					}
					return;
				}
				catch
				{
					return;
				}
			}
			if (itemIdentity == ItemIdentity.Misc && !doNotEnablePhysicsWhenHit && collision.collider.transform.root.gameObject.CompareTag("PickUp") && enableGravityWhenInteractedWith)
			{
				rb.isKinematic = false;
				rb.useGravity = true;
			}
		}
	}

	private void BreakStarOrb()
	{
		SpawnBrokenVersion();
		if (puzzleIdentity_Index != -1)
		{
			PlayerStats.Singleton.IncreaseStarOrbs(10);
			AudioManager.Singleton.PlaySFX_BlackStarOrbSpookyRiff();
			GameManager.Singleton.radioInScene.StartPlayingStatic(8f);
			VcrIntroManager.Singleton.StartGlitchedOutBlackStarOrbEffect();
			PuzzleManager.Singleton.SetBlackStarOrbState_Collected(puzzleIdentity_Index);
		}
		else
		{
			PlayerStats.Singleton.IncreaseStarOrbs(starOrbsValue);
			AudioManager.Singleton.PlayStarOrbCollectSFX(base.transform.position);
			if (starOrbFromMilestone)
			{
				PlayerStats.Singleton.RemoveOrbFromSpawnedButNotDeposited((int)starOrbsToSpawnWhenDeposited);
			}
		}
		AudioManager.Singleton.PlayStarOrbShatterSFX(base.transform.position);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void SpawnBrokenVersion()
	{
		if (!hasBroken)
		{
			UnityEngine.Object.Instantiate(brokenPrefab, base.transform.position, base.transform.rotation).transform.localScale = base.transform.localScale;
			hasBroken = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (itemIdentity == ItemIdentity.Cultist && other.CompareTag("MilestoneActivator"))
		{
			cultistScript.Ragdoll();
		}
		if (pickUpType == PickUpType.MilestoneObject)
		{
			if (other.CompareTag("MilestoneActivator"))
			{
				ActivateMilestoneObjectPhysics();
			}
		}
		else if (pickUpType == PickUpType.Berry && itemIdentity != ItemIdentity.Cultist)
		{
			if (other.CompareTag("LaunchTowardsHole"))
			{
				float value = Vector3.Distance(base.transform.position, GameManager.Singleton.GetYardObject().transform.position) * 0.4f;
				value = Mathf.Clamp(value, 8f, 50f);
				Vector3 linearVelocity = FlingUtility.CalculateArcVelocity(base.transform.position, GameManager.Singleton.GetYardObject().transform.position, value);
				rb.linearVelocity = linearVelocity;
			}
		}
		else if (pickUpType == PickUpType.AnomalousMaterial)
		{
			if (hasVoidBoxMovedAboveGroundAfterSpawn && other.CompareTag("PoolVacuum"))
			{
				rb.AddForce(new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(4f, 7f), UnityEngine.Random.Range(-2f, 2f)), ForceMode.VelocityChange);
			}
			if (other.CompareTag("Blender"))
			{
				BreakStarOrb();
			}
		}
		else if (pickUpType == PickUpType.Tool)
		{
			if (other.CompareTag("PoolVacuum"))
			{
				rb.AddForce(new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(4f, 7f), UnityEngine.Random.Range(-2f, 2f)) * 3f, ForceMode.VelocityChange);
			}
		}
		else if (pickUpType == PickUpType.VoidBox && other.CompareTag("GravEnabler") && hasBeenInteractedWithByPlayer)
		{
			rb.useGravity = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (pickUpType == PickUpType.VoidBox && other.CompareTag("GravEnabler"))
		{
			rb.useGravity = false;
		}
	}

	public void ActivateMilestoneObjectPhysics()
	{
		if (!GameManager.Singleton.hasTimerElapsed_IsNighttime && !hasBeenActivated_MileStone)
		{
			rb.isKinematic = false;
			Debug.Log("Milestone activated!");
			hasBeenActivated_MileStone = true;
			canBeKicked = true;
		}
	}

	public void PlayImpactFeedback(bool _playSFX = false, float _impactForce = -1f)
	{
		if (GameManager.Singleton.gameState != GameManager.GameState.Playing)
		{
			return;
		}
		feedback_Impact?.PlayFeedbacks();
		if (!_playSFX)
		{
			return;
		}
		if (pickUpType == PickUpType.Berry)
		{
			AudioManager.Singleton.PlayBerryImpactSFX(base.transform.position);
		}
		if (pickUpType == PickUpType.MilestoneObject)
		{
			if (rb.isKinematic || impactNoise_Buffer > 0f)
			{
				return;
			}
			if (_impactForce > 5000f)
			{
				AudioManager.Singleton.PlayMilestoneImpactSFX(base.transform.position, 1f);
				impactNoise_Buffer = 0.2f;
			}
			else if (_impactForce > 0f)
			{
				AudioManager.Singleton.PlayMilestoneImpactSFX(base.transform.position, 0.6f);
				impactNoise_Buffer = 0.2f;
			}
		}
		if (itemIdentity == ItemIdentity.Cultist && _impactForce > 2500f)
		{
			cultistScript.faceAndNoiseHandler.PlayNegativeNoise();
		}
	}

	private void ReferenceCollidersAndRenderers()
	{
		allRenderers = base.gameObject.GetComponentsInChildren<Renderer>();
		allColliders = base.gameObject.GetComponentsInChildren<Collider>();
	}

	public void DisableColliders_Local()
	{
		Collider[] array = allColliders;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = false;
		}
	}

	public void EnableColliders_Local()
	{
		Collider[] array = allColliders;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = true;
		}
	}

	public ItemIdentity GetItemIdentity()
	{
		return itemIdentity;
	}

	public PickUpType GetPickUpType()
	{
		return pickUpType;
	}

	public StarOrbsToSpawnWhenDeposited GetNumOfOrbsToSpawnAtDeposited()
	{
		return starOrbsToSpawnWhenDeposited;
	}

	public void SetNumOfOrbsToSpawnAtDeposited(StarOrbsToSpawnWhenDeposited _worth)
	{
		starOrbsToSpawnWhenDeposited = _worth;
		switch (_worth)
		{
		case StarOrbsToSpawnWhenDeposited.None:
			starOrbsValue = 0;
			break;
		case StarOrbsToSpawnWhenDeposited.One:
			starOrbsValue = 1;
			break;
		case StarOrbsToSpawnWhenDeposited.Five:
			starOrbsValue = 5;
			break;
		case StarOrbsToSpawnWhenDeposited.Ten:
			starOrbsValue = 10;
			break;
		case StarOrbsToSpawnWhenDeposited.TwentyFive:
			starOrbsValue = 25;
			break;
		case StarOrbsToSpawnWhenDeposited.Fifty:
			starOrbsValue = 50;
			break;
		case StarOrbsToSpawnWhenDeposited.OneHundo:
			starOrbsValue = 100;
			break;
		case StarOrbsToSpawnWhenDeposited.TwoHundoFifty:
			starOrbsValue = 250;
			break;
		case StarOrbsToSpawnWhenDeposited.FiveHundo:
			starOrbsValue = 500;
			break;
		case StarOrbsToSpawnWhenDeposited.OneThousand:
			starOrbsValue = 1000;
			break;
		}
	}

	public void MakeUsABonusVoidBox(bool _addToPlayerStats = true)
	{
		isBonusVoidBox = true;
		if (_addToPlayerStats)
		{
			PlayerStats.Singleton.bonusVoidBoxesFromFossilsSpawnedCurrently++;
		}
	}

	private void HandleAutoStarOrbPopping()
	{
		if (itemIdentity == ItemIdentity.AnomalousMaterial && puzzleIdentity_Index == -1 && PlayerStats.Singleton.autoPopStarOrbs_Unlocked && GameManager.Singleton.gameState == GameManager.GameState.Playing && !GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			if (autoStarOrbPop_Timer > 0f)
			{
				autoStarOrbPop_Timer -= Time.fixedDeltaTime;
			}
			else if (!hasBroken)
			{
				BreakStarOrb();
			}
		}
	}

	public void DisableCollisionForACertainTime(float _timeToDisableColl)
	{
		StartCoroutine(CollisionToggleForATime(_timeToDisableColl));
	}

	private IEnumerator CollisionToggleForATime(float _timeToDisableColl)
	{
		DisableColliders_Local();
		yield return new WaitForSeconds(_timeToDisableColl);
		EnableColliders_Local();
	}

	public void MakeKinematic()
	{
		rb.isKinematic = true;
	}

	public bool GetHasBeenActivated()
	{
		return hasBeenActivated_MileStone;
	}
}
