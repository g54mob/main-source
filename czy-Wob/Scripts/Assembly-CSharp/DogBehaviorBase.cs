using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[Serializable]
public class DogBehaviorBase : MonoBehaviour
{
	public string readableName;

	public LocalizedString localizedName;

	public BehaviorPriority priority = BehaviorPriority.Medium;

	public FixationType fixationType;

	public IndicatorAction associatedIndicatorAction;

	public bool userCancelable = true;

	public bool debugMustRun;

	public bool autoAddToDog = true;

	public bool cancelOnInvalidRotation;

	public bool cancelFromLoudNoises;

	public GhostAllowance ghostsAllowed;

	public bool requireMouth;

	public bool dropTargetBeforeRunning = true;

	public bool canDistractDogs;

	public bool ambientFocusAllowed = true;

	public bool advertise = true;

	public bool allowedInBreedingCenter;

	public float lockoutTime;

	public FeelingTowardsTarget feelingTowardsTarget;

	public bool canTargetPlacedObjects = true;

	public DogBehaviorEnum reinforcementRetarget;

	public bool canReinforce = true;

	public ReservableObjectType targetReservableType;

	public bool flipReservationRequirements;

	public List<TagsEnum> tags = new List<TagsEnum>();

	public List<TagsEnum> heldObjectTags = new List<TagsEnum>();

	public List<TargetConditionType> targetConditionEnums = new List<TargetConditionType>();

	public List<SerializableTargetCondition> targetConditions = new List<SerializableTargetCondition>();

	public bool requireLOSToTarget;

	public List<TagsEnum> additionalRetargetingTags = new List<TagsEnum>();

	public RetargetStrategy retargetingStrategy = RetargetStrategy.SAME_TAG;

	public List<BehaviorLocationInfo> preferredLocationInfoEnum = new List<BehaviorLocationInfo>();

	public List<SerializablePreferredLocationInfo> preferredLocationInfo = new List<SerializablePreferredLocationInfo>();

	public List<StartConditionType> startConditionEnums = new List<StartConditionType>();

	public List<SerializableStartCondition> startConditions = new List<SerializableStartCondition>();

	public List<NeedLoot> needLoot = new List<NeedLoot>();

	public List<NeedLoot> needLootForTarget = new List<NeedLoot>();

	public List<NeedLoot> falseAds = new List<NeedLoot>();

	public List<PersonalityScoreModifier> personalityScoreModifiers = new List<PersonalityScoreModifier>();

	public List<DogAction> preActions = new List<DogAction>();

	public List<DogAction> actions = new List<DogAction>();

	public AfterExitConditionsMet afterExitConditions;

	public List<ExitConditionType> exitConditionEnums = new List<ExitConditionType>();

	public List<SerializableExitCondition> exitConditions = new List<SerializableExitCondition>();

	public List<NeedLoot> earlyEndLoot = new List<NeedLoot>();

	protected BehaviorRole role;

	protected DogBehaviorEnum behaviorEnum;

	protected float continuousPayoutLootTimer = 1f;

	protected DogAI associatedAI;

	protected GameObject associatedDog;

	protected GameObject positionRefObj;

	protected bool isRunningBehavior;

	protected bool exitConditionsMet;

	protected bool canBeReplaced;

	protected float currentLockoutTime;

	protected bool preActionsFinished;

	protected int actionIndex;

	protected bool runningAction;

	protected bool heldObjectTagsOverride;

	protected float distractionTimerMin = 1f;

	protected float currentDistractionTimer;

	protected float defaultDogDistractionWeight = 0.1f;

	protected float positiveRelationshipDistractionMultiplier = 2f;

	protected float negativeRelationshipDistractionMultiplier = 0.2f;

	protected float aloofDistractionMultiplier = 0.2f;

	protected float socialDistractionMultiplier = 2f;

	protected RoomBase reservedTilesRoom;

	protected List<Vector2Int> reservedTiles = new List<Vector2Int>();

	protected List<GameObject> dogList = new List<GameObject>();

	protected DogRegistration dogRegRef;

	protected MouthController mouthRef;

	protected Vector3 storedPosition;

	protected GameObject storedObject;

	protected ulong storedRoomUID;

	protected Vector2Int? storedGridSquare;

	protected DenExpansion storedDenExpansion;

	private void Awake()
	{
		if (debugMustRun)
		{
			Debug.LogWarning(string.Concat("WARNING: Behavior: ", base.gameObject, " is marked DebugMustRun. Make sure this is what you want."));
		}
		SetProperties();
		ResetPreActions();
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		AddLocationActions();
	}

	private void Start()
	{
		AssignEnum();
	}

	private void Update()
	{
		UpdateBehavior();
	}

	protected virtual void UpdateBehavior()
	{
		UpdateLockoutTimer();
		if (!isRunningBehavior)
		{
			return;
		}
		if (cancelOnInvalidRotation && !associatedAI.IsValidRotation())
		{
			associatedAI.ForceInterruptBehavior();
			return;
		}
		if (preActionsFinished)
		{
			AwardNeedLoot(PayoutTime.CONTINUOUS);
			if (canDistractDogs)
			{
				DistractNearbyDogs();
			}
		}
		if (!runningAction)
		{
			if (!preActionsFinished)
			{
				ExecuteBehavior();
			}
			else if (actionIndex < actions.Count)
			{
				ExecuteBehavior();
			}
			else if (preActionsFinished)
			{
				CheckExitConditions();
			}
		}
		if (heldObjectTags.Count > 0)
		{
			if (mouthRef == null)
			{
				mouthRef = associatedDog.GetComponent<MouthController>();
			}
			if (!heldObjectTagsOverride && mouthRef.GetCarriedObject() == null)
			{
				associatedAI.ForceInterruptBehavior();
			}
		}
	}

	public void StoreGridSquare(Vector2Int newSquare)
	{
		storedGridSquare = newSquare;
	}

	public Vector2Int? GetStoredGridSquare()
	{
		return storedGridSquare;
	}

	public void StoreRoomUID(ulong roomUID)
	{
		storedRoomUID = roomUID;
	}

	public ulong GetStoredRoomUID()
	{
		return storedRoomUID;
	}

	public void StoreDenExpansion(DenExpansion expansionRef)
	{
		storedDenExpansion = expansionRef;
	}

	public DenExpansion GetStoredDenExpansion()
	{
		return storedDenExpansion;
	}

	public void StorePosition(Vector3 newPos)
	{
		storedPosition = newPos;
	}

	public Vector3 GetStoredPosition()
	{
		return storedPosition;
	}

	public void StoreObject(GameObject obj)
	{
		storedObject = obj;
	}

	public GameObject GetStoredObject()
	{
		return storedObject;
	}

	private void AddLocationActions()
	{
		for (int i = 0; i < preferredLocationInfo.Count; i++)
		{
			switch (preferredLocationInfo[i].type)
			{
			case BehaviorLocationInfo.PREFER_BUSY_LOCATION:
				preActions.Insert(0, DogAction.WALK_TO_HIGH_DOG_TRAFFIC_POINT);
				break;
			case BehaviorLocationInfo.PREFER_EMPTY_LOCATION:
				preActions.Insert(0, DogAction.WALK_TO_LOW_DOG_TRAFFIC_POINT);
				break;
			case BehaviorLocationInfo.PREFER_ISOLATED_LOCATION:
				preActions.Insert(0, DogAction.WALK_TO_ISOLATED_POINT);
				break;
			case BehaviorLocationInfo.PREFER_NON_DEN_ISOLATED_LOCATION:
				preActions.Insert(0, DogAction.WALK_TO_ISOLATED_POINT_DEN_DISCOURAGED);
				break;
			case BehaviorLocationInfo.PREFER_NEST_ISOLATED_LOCATION:
				preActions.Insert(0, DogAction.WALK_TO_ISOLATED_POINT_NEST_ENCOURAGED);
				break;
			case BehaviorLocationInfo.PREFER_BEDROOM_ISOLATED_LOCATION:
				preActions.Insert(0, DogAction.WALK_TO_ISOLATED_POINT_BEDROOM_ENCOURAGED);
				break;
			}
		}
	}

	public virtual float GetNeedAdvertisement(Need need, GameObject potentialTarget = null)
	{
		if (!advertise)
		{
			return 0f;
		}
		bool flag = false;
		float num = 0f;
		for (int i = 0; i < falseAds.Count; i++)
		{
			if (falseAds[i].dogNeed == need)
			{
				flag = true;
				num += falseAds[i].amount;
			}
		}
		if (flag)
		{
			return num;
		}
		for (int j = 0; j < needLoot.Count; j++)
		{
			if (needLoot[j].dogNeed == need && needLoot[j].payoutTime != PayoutTime.CONTINUOUS)
			{
				num += needLoot[j].amount;
			}
		}
		return num;
	}

	public bool PreActionsFinished()
	{
		return preActionsFinished;
	}

	private void DistractNearbyDogs()
	{
		if (associatedAI != null && associatedAI.GetCurrentGameMode() == GameMode.BREEDING)
		{
			return;
		}
		currentDistractionTimer -= Time.deltaTime;
		if (currentDistractionTimer > 0f)
		{
			return;
		}
		currentDistractionTimer = distractionTimerMin;
		DoggyBrain component = associatedDog.GetComponent<DoggyBrain>();
		SocialPersonalityType socialPersonality = component.GetPersonality().GetSocialPersonality();
		dogRegRef.GetNearbyDogList(associatedDog, ref dogList);
		for (int i = 0; i < dogList.Count; i++)
		{
			float num = defaultDogDistractionWeight;
			switch (component.GetFeelingTowardsTarget(dogList[i]))
			{
			case Opinion.LIKE:
				num *= positiveRelationshipDistractionMultiplier;
				break;
			case Opinion.DISLIKE:
				num *= negativeRelationshipDistractionMultiplier;
				break;
			}
			switch (socialPersonality)
			{
			case SocialPersonalityType.ALOOF:
				num *= aloofDistractionMultiplier;
				break;
			case SocialPersonalityType.SOCIAL:
				num *= socialDistractionMultiplier;
				break;
			}
			DistractionDogBehavior newDistraction = new DistractionDogBehavior(dogList[i].GetComponent<DogAI>(), num, this, associatedAI.GetTargetObject());
			dogList[i].GetComponent<DogAI>().TryAddNewDistraction(newDistraction);
		}
	}

	private void UpdateLockoutTimer()
	{
		if (currentLockoutTime > 0f)
		{
			currentLockoutTime -= Time.deltaTime;
			if (currentLockoutTime < 0f)
			{
				currentLockoutTime = 0f;
			}
		}
	}

	public void SetRole(BehaviorRole newRole)
	{
		role = newRole;
	}

	public bool IsRunningBehavior()
	{
		return isRunningBehavior;
	}

	public bool IsRunningMainBehavior()
	{
		if (isRunningBehavior && preActionsFinished)
		{
			return true;
		}
		return false;
	}

	public bool CanBeReplaced()
	{
		return canBeReplaced;
	}

	public virtual bool IsTargeted()
	{
		return false;
	}

	public virtual bool IsRoomBehavior()
	{
		return false;
	}

	public virtual bool IsReserveBehavior()
	{
		return false;
	}

	public virtual bool IsPairedBehavior()
	{
		return false;
	}

	public virtual bool IsCreateBuildableObjectBehavior()
	{
		return false;
	}

	public virtual GameObject GetTarget()
	{
		return null;
	}

	public virtual RoomBase GetTargetRoom()
	{
		return null;
	}

	public virtual ReservableObject GetTargetReservableObject()
	{
		return null;
	}

	public DogBehaviorEnum GetEnum()
	{
		return behaviorEnum;
	}

	public virtual DogBehaviorTargetedEnum GetTargetedEnum()
	{
		Debug.LogError("Attempting to grab a targeted enum for a non-targeted behavior: " + base.gameObject.name);
		return DogBehaviorTargetedEnum.NONE;
	}

	public virtual DogBehaviorRoomEnum GetRoomEnum()
	{
		Debug.LogError("Attempting to grab a room enum for a non-room behavior: " + base.gameObject.name);
		return DogBehaviorRoomEnum.NONE;
	}

	public virtual DogBehaviorReserveEnum GetReserveEnum()
	{
		Debug.LogError("Attempting to grab a reserve enum for a non-reserve behavior: " + base.gameObject.name);
		return DogBehaviorReserveEnum.NONE;
	}

	protected virtual void AssignEnum()
	{
		behaviorEnum = (DogBehaviorEnum)Enum.Parse(typeof(DogBehaviorEnum), base.gameObject.name);
	}

	protected virtual void SetProperties()
	{
	}

	private void ResetPreActions()
	{
		if (preActions.Count == 0)
		{
			preActionsFinished = true;
		}
		else
		{
			preActionsFinished = false;
		}
	}

	public virtual void HandleLoudNoise(GameObject noiseSource)
	{
		if (cancelFromLoudNoises)
		{
			HandleInterruption(noiseSource);
		}
	}

	public virtual void HandleInterruption(GameObject source, bool surpriseParticles = true)
	{
		if (surpriseParticles)
		{
			associatedDog.GetComponent<DogParticleController>().RequestSurpriseParticlesStart();
		}
		associatedAI.ForceInterruptBehavior(source);
	}

	public void SetAssociatedDog(GameObject dog)
	{
		associatedDog = dog;
		associatedAI = dog.GetComponent<DogAI>();
		positionRefObj = dog.GetComponent<LegController>().bodyFront;
	}

	public virtual void StartBehavior()
	{
		if (!ambientFocusAllowed)
		{
			associatedDog.GetComponent<FaceController>().SetAmbientFocusAllowed(val: false);
		}
		associatedAI.OnBehaviorStarted();
		for (int i = 0; i < exitConditions.Count; i++)
		{
			exitConditions[i].ResetCondition();
		}
		if (mouthRef == null)
		{
			mouthRef = associatedDog.GetComponent<MouthController>();
		}
		GameObject carriedObject = mouthRef.GetCarriedObject();
		if (carriedObject != null)
		{
			if (requireMouth)
			{
				if (!IsTargeted() || GetTarget() != carriedObject)
				{
					mouthRef.DropObject();
				}
			}
			else if (IsTargeted() && dropTargetBeforeRunning && GetTarget() == carriedObject)
			{
				associatedDog.GetComponent<MouthController>().DropObject();
			}
		}
		actionIndex = 0;
		canBeReplaced = false;
		runningAction = false;
		isRunningBehavior = true;
		exitConditionsMet = false;
		heldObjectTagsOverride = false;
		ResetPreActions();
		associatedDog.GetComponent<DoggyBrain>().StoreNewBehaviorTargetProperties(GetTarget());
	}

	public void SetHeldObjectTagsOverride(bool val)
	{
		heldObjectTagsOverride = val;
	}

	public bool IsBehaviorValidForReinforcement()
	{
		if (!canReinforce)
		{
			return false;
		}
		if (associatedDog == null)
		{
			return false;
		}
		if (PreActionsFinished())
		{
			return true;
		}
		if (!IsTargeted())
		{
			return false;
		}
		GameObject target = GetTarget();
		if (target == null)
		{
			return false;
		}
		target = target.transform.root.gameObject;
		if (mouthRef != null && mouthRef.GetCarriedObject() == target)
		{
			return true;
		}
		return false;
	}

	public virtual void FinishBehavior(bool naturalFinish = true, GameObject objectCause = null)
	{
		if (associatedDog != null && (naturalFinish || IsBehaviorValidForReinforcement()))
		{
			associatedDog.GetComponent<DoggyBrain>().StoreBehaviorForReinforcement(this);
		}
		currentLockoutTime = lockoutTime;
		if (!ambientFocusAllowed)
		{
			FaceController component = associatedDog.GetComponent<FaceController>();
			if (component != null)
			{
				component.SetAmbientFocusAllowed(val: true);
			}
		}
		if (!preActionsFinished)
		{
			for (int i = actionIndex; i < preActions.Count; i++)
			{
				FinalizeAction(preActions[i], naturalFinish);
			}
		}
		else
		{
			for (int j = 0; j < actions.Count; j++)
			{
				FinalizeAction(actions[j], naturalFinish);
			}
		}
		isRunningBehavior = false;
		InputSimulator globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InputSimulator>(GlobalObject.INPUT_SIMULATOR);
		if (globalComponent != null)
		{
			globalComponent.ClearInputForDog(base.gameObject);
		}
		if (!naturalFinish && objectCause != null)
		{
			AwardEarlyFinishLoot();
		}
		else if (naturalFinish)
		{
			AwardNeedLoot(PayoutTime.END);
		}
		ReleaseReservedTiles();
		ReleaseReservedExpansion();
		associatedAI.OnBehaviorFinished(naturalFinish);
	}

	public void AwardBehaviorDefinedLoot()
	{
		AwardNeedLoot(PayoutTime.BEHAVIOR_DEFINED);
	}

	public void AwardBehaviorDefinedAndValuedLoot(float customAmount)
	{
		AwardNeedLoot(PayoutTime.BEHAVIOR_DEFINED_AND_VALUED, customAmount);
	}

	protected virtual void AwardNeedLoot(PayoutTime time, float? customAmount = null)
	{
		float num = 0f;
		for (int i = 0; i < needLoot.Count; i++)
		{
			if (needLoot[i].payoutTime == time)
			{
				num = ((time == PayoutTime.CONTINUOUS) ? (needLoot[i].amount * Time.deltaTime / continuousPayoutLootTimer) : ((time != PayoutTime.BEHAVIOR_DEFINED_AND_VALUED || !customAmount.HasValue) ? needLoot[i].amount : customAmount.Value));
				associatedAI.UpdateNeed(needLoot[i].dogNeed, num, modifyViaPersonality: true);
			}
		}
		if (!(associatedAI.GetTargetObject() != null) || needLootForTarget.Count <= 0)
		{
			return;
		}
		DogAI component = associatedAI.GetTargetObject().transform.root.GetComponent<DogAI>();
		if (!(component != null))
		{
			return;
		}
		for (int j = 0; j < needLootForTarget.Count; j++)
		{
			if (needLootForTarget[j].payoutTime == time)
			{
				component.UpdateNeed(amount: (time != PayoutTime.CONTINUOUS) ? needLootForTarget[j].amount : (needLootForTarget[j].amount * Time.deltaTime / continuousPayoutLootTimer), need: needLootForTarget[j].dogNeed, modifyViaPersonality: true);
			}
		}
	}

	protected virtual void AwardEarlyFinishLoot()
	{
		for (int i = 0; i < earlyEndLoot.Count; i++)
		{
			associatedAI.UpdateNeed(earlyEndLoot[i].dogNeed, earlyEndLoot[i].amount);
		}
	}

	protected virtual void ExecuteBehavior()
	{
		if (!preActionsFinished)
		{
			RunAction(preActions[actionIndex]);
		}
		else
		{
			RunAction(actions[actionIndex]);
		}
	}

	protected virtual void RunAction(DogAction action)
	{
		runningAction = true;
		switch (action)
		{
		case DogAction.BOW:
			associatedDog.GetComponent<PlayBow>().RequestPlayBow(ActionFinishedCallback);
			break;
		case DogAction.BUCK:
			associatedDog.GetComponent<BodyBuck>().RequestBuck(ActionFinishedCallback);
			break;
		case DogAction.BUCK_CHAIN:
			associatedDog.GetComponent<BodyBuck>().RequestContinuousBucking();
			ActionFinishedCallback();
			break;
		case DogAction.SLEEP:
			associatedDog.GetComponent<SleepBehavior>().RequestSleep(ActionFinishedCallback);
			break;
		case DogAction.LIE_DOWN:
			associatedDog.GetComponent<LieDownBehavior>().RequestLieDown(ActionFinishedCallback);
			break;
		case DogAction.RUCKUS:
			associatedDog.GetComponent<RuckusBehavior>().RequestRuckus(ActionFinishedCallback);
			break;
		case DogAction.GROUND_GOOF:
			associatedDog.GetComponent<GroundGoofBehavior>().RequestGoof(ActionFinishedCallback);
			break;
		case DogAction.STANDING_WOBBLE:
			associatedDog.GetComponent<WobbleBehavior>().RequestWobble(ruckus: false, ActionFinishedCallback);
			break;
		case DogAction.STANDING_WOBBLE_RUCKUS:
			associatedDog.GetComponent<WobbleBehavior>().RequestWobble(ruckus: true, ActionFinishedCallback);
			break;
		case DogAction.WALK_TO_RANDOM_POINT:
			TargetPointHelper.TargetRandomConnectedPoint(associatedDog, ActionFinishedCallback);
			break;
		case DogAction.EXPLORE:
			TargetPointHelper.TargetExploratoryPoint(associatedDog, ActionFinishedCallback);
			break;
		case DogAction.WALK_TO_ISOLATED_POINT:
			TargetPointHelper.TargetIsolatedPoint(associatedDog, ActionFinishedCallback, this);
			break;
		case DogAction.WALK_TO_ISOLATED_POINT_DEN_DISCOURAGED:
			TargetPointHelper.TargetIsolatedPoint(associatedDog, ActionFinishedCallback, this, densAllowed: false);
			break;
		case DogAction.WALK_TO_ISOLATED_POINT_NEST_ENCOURAGED:
			TargetPointHelper.TargetIsolatedPoint(associatedDog, ActionFinishedCallback, this, densAllowed: true, densRequired: false, nestEncouraged: true);
			break;
		case DogAction.WALK_TO_ISOLATED_POINT_BEDROOM_ENCOURAGED:
			TargetPointHelper.TargetIsolatedPoint(associatedDog, ActionFinishedCallback, this, densAllowed: true, densRequired: false, nestEncouraged: false, bedroomEncouraged: true);
			break;
		case DogAction.WALK_TO_LOW_DOG_TRAFFIC_POINT:
			TargetPointHelper.TargetLowDogTrafficPoint(associatedDog, ActionFinishedCallback, this);
			break;
		case DogAction.WALK_TO_HIGH_DOG_TRAFFIC_POINT:
			TargetPointHelper.TargetHighDogTrafficPoint(associatedDog, ActionFinishedCallback, this);
			break;
		case DogAction.WALK_TO_SPECIFIC_POINT:
			TargetPointHelper.TargetGivenPosition(associatedDog, storedPosition, ActionFinishedCallback, useLooseFacingOffset: false, useSuperLooseFacingOffset: false, isGroundPosition: true);
			break;
		case DogAction.WALK_TO_DEN:
			TargetPointHelper.TargetIsolatedPoint(associatedDog, ActionFinishedCallback, this, densAllowed: true, densRequired: true);
			break;
		case DogAction.BARK:
			associatedDog.GetComponent<BarkBehavior>().RequestBark();
			ActionFinishedCallback();
			break;
		case DogAction.RAPID_BARK:
			associatedDog.GetComponent<BarkBehavior>().RequestBark(rapid: true);
			ActionFinishedCallback();
			break;
		case DogAction.HOWL:
			associatedDog.GetComponent<HowlBehavior>().RequestHowl(ActionFinishedCallback);
			break;
		case DogAction.BARF:
			associatedDog.GetComponent<BarfBehavior>().RequestBarf(ActionFinishedCallback);
			break;
		case DogAction.CHOKE_ON_FOOD:
			associatedDog.GetComponent<ChokeOnFoodBehavior>().RequestChoke(ActionFinishedCallback);
			break;
		case DogAction.LAY_EGGS:
			associatedDog.GetComponent<DogEggLayingController>().LayEggs(ActionFinishedCallback);
			break;
		case DogAction.LAY_CAPSULE:
			associatedDog.GetComponent<DogEggLayingController>().LayEggs(ActionFinishedCallback, layCapsuleInstead: true);
			break;
		case DogAction.POOP:
			associatedDog.GetComponent<DogPoopController>().Poop();
			ActionFinishedCallback();
			break;
		case DogAction.WAIT_ONE_SECOND:
			StartCoroutine(WaitRoutine(1f));
			break;
		case DogAction.LEVITATE_TARGET:
			associatedDog.GetComponent<LevitateBehavior>().RequestLevitate(null, ActionFinishedCallback);
			break;
		case DogAction.FLY:
			associatedDog.GetComponent<FlyBehavior>().RequestFly(ActionFinishedCallback);
			break;
		case DogAction.SIT:
			associatedDog.GetComponent<SitBehavior>().RequestSit(ActionFinishedCallback);
			break;
		case DogAction.SCRATCH_AT_GROUND:
			associatedDog.GetComponent<DogDenController>().RequestScratchAtGround(ActionFinishedCallback);
			break;
		case DogAction.SNEEZE:
			associatedDog.GetComponent<SneezeBehavior>().RequestSneeze(ActionFinishedCallback);
			break;
		case DogAction.DEATH_KNELL:
			associatedDog.GetComponent<DeathKnellBehavior>().RequestDeathKnell();
			ActionFinishedCallback();
			break;
		case DogAction.EXPAND_DEN:
			storedDenExpansion.GetAssociatedInterior().ExpandDen();
			ActionFinishedCallback();
			break;
		case DogAction.OVERRIDE_HELD_OBJECT_TAGS:
			SetHeldObjectTagsOverride(val: true);
			ActionFinishedCallback();
			break;
		case DogAction.ROLL_OVER:
			associatedDog.GetComponent<RollOverBehavior>().RequestRollOver(ActionFinishedCallback);
			break;
		case DogAction.PLAY_DEAD:
			associatedDog.GetComponent<PlayDeadBehavior>().RequestPlayDead();
			ActionFinishedCallback();
			break;
		case DogAction.GROWL:
			associatedDog.GetComponent<DogNoises>().RequestGrowl();
			ActionFinishedCallback();
			break;
		default:
			Debug.LogError("Unimplemented action: " + action);
			runningAction = false;
			break;
		}
	}

	public IEnumerator WaitRoutine(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		ActionFinishedCallback();
	}

	public void ReservePositionInRoom(Vector3 position, RoomBase room)
	{
		Vector2Int gridSquareForPositionAndRoom = ObjectPlacementManager.GetGridSquareForPositionAndRoom(position, room);
		reservedTiles.Add(gridSquareForPositionAndRoom);
		reservedTiles.Add(new Vector2Int(gridSquareForPositionAndRoom.x + 1, gridSquareForPositionAndRoom.y));
		reservedTiles.Add(new Vector2Int(gridSquareForPositionAndRoom.x + 1, gridSquareForPositionAndRoom.y + 1));
		reservedTiles.Add(new Vector2Int(gridSquareForPositionAndRoom.x, gridSquareForPositionAndRoom.y + 1));
		reservedTiles.Add(new Vector2Int(gridSquareForPositionAndRoom.x - 1, gridSquareForPositionAndRoom.y));
		reservedTiles.Add(new Vector2Int(gridSquareForPositionAndRoom.x, gridSquareForPositionAndRoom.y - 1));
		reservedTiles.Add(new Vector2Int(gridSquareForPositionAndRoom.x - 1, gridSquareForPositionAndRoom.y - 1));
		reservedTiles.Add(new Vector2Int(gridSquareForPositionAndRoom.x - 1, gridSquareForPositionAndRoom.y + 1));
		reservedTiles.Add(new Vector2Int(gridSquareForPositionAndRoom.x + 1, gridSquareForPositionAndRoom.y - 1));
		reservedTilesRoom = room;
		for (int i = 0; i < reservedTiles.Count; i++)
		{
			room.ReserveTile(reservedTiles[i]);
		}
	}

	public void ReleaseReservedExpansion()
	{
		if (storedDenExpansion != null)
		{
			storedDenExpansion.ClearDogRegistration();
		}
	}

	public void ReleaseReservedTiles()
	{
		if (reservedTilesRoom == null)
		{
			reservedTiles.Clear();
			return;
		}
		for (int i = 0; i < reservedTiles.Count; i++)
		{
			reservedTilesRoom.ReleaseTile(reservedTiles[i]);
		}
		reservedTiles.Clear();
		reservedTilesRoom = null;
	}

	protected virtual void FinalizeAction(DogAction action, bool naturalFinish)
	{
		switch (action)
		{
		case DogAction.SLEEP:
			associatedDog.GetComponent<SleepBehavior>().RequestWakeUp();
			break;
		case DogAction.LIE_DOWN:
			associatedDog.GetComponent<LieDownBehavior>().RequestStandUp();
			break;
		case DogAction.RUCKUS:
			associatedDog.GetComponent<RuckusBehavior>().RequestRuckusEnd();
			break;
		case DogAction.BUCK:
			associatedDog.GetComponent<BodyBuck>().RequestBuckStop();
			break;
		case DogAction.BUCK_CHAIN:
			associatedDog.GetComponent<BodyBuck>().StopContinuousBucking();
			break;
		case DogAction.GROUND_GOOF:
			associatedDog.GetComponent<GroundGoofBehavior>().RequestGoofEnd();
			break;
		case DogAction.STANDING_WOBBLE:
			associatedDog.GetComponent<WobbleBehavior>().RequestWobbleStop();
			break;
		case DogAction.STANDING_WOBBLE_RUCKUS:
			associatedDog.GetComponent<WobbleBehavior>().RequestWobbleStop();
			break;
		case DogAction.WALK_TO_RANDOM_POINT:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.EXPLORE:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.WALK_TO_ISOLATED_POINT:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.WALK_TO_ISOLATED_POINT_DEN_DISCOURAGED:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.WALK_TO_ISOLATED_POINT_NEST_ENCOURAGED:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.WALK_TO_ISOLATED_POINT_BEDROOM_ENCOURAGED:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.WALK_TO_LOW_DOG_TRAFFIC_POINT:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.WALK_TO_HIGH_DOG_TRAFFIC_POINT:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.WALK_TO_SPECIFIC_POINT:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.WALK_TO_DEN:
			associatedDog.GetComponent<WalkController>().RemoveFacingTarget();
			associatedDog.GetComponent<LegController>().StopSimulatedWalk();
			break;
		case DogAction.BARK:
			associatedDog.GetComponent<BarkBehavior>().RequestStopBarking();
			break;
		case DogAction.RAPID_BARK:
			associatedDog.GetComponent<BarkBehavior>().RequestStopBarking();
			break;
		case DogAction.HOWL:
			associatedDog.GetComponent<HowlBehavior>().RequestStop();
			break;
		case DogAction.BARF:
			associatedDog.GetComponent<BarfBehavior>().RequestStopBarfing();
			break;
		case DogAction.CHOKE_ON_FOOD:
			associatedDog.GetComponent<ChokeOnFoodBehavior>().RequestStopChoking();
			break;
		case DogAction.LEVITATE_TARGET:
			associatedDog.GetComponent<LevitateBehavior>().RequestStopLevitating();
			break;
		case DogAction.FLY:
			associatedDog.GetComponent<FlyBehavior>().RequestStopFlying();
			break;
		case DogAction.SIT:
			associatedDog.GetComponent<SitBehavior>().RequestStandUp();
			break;
		case DogAction.SNEEZE:
			associatedDog.GetComponent<SneezeBehavior>().RequestSneezeStop();
			break;
		case DogAction.SCRATCH_AT_GROUND:
			associatedDog.GetComponent<DogDenController>().RequestStopScratchingAtGround();
			break;
		case DogAction.DEATH_KNELL:
			associatedDog.GetComponent<DeathKnellBehavior>().RequestStopDeathKnell(naturalFinish);
			break;
		case DogAction.ROLL_OVER:
			associatedDog.GetComponent<RollOverBehavior>().RequestStandUp();
			break;
		case DogAction.PLAY_DEAD:
			associatedDog.GetComponent<PlayDeadBehavior>().RequestStopPlayingDead();
			break;
		}
	}

	protected void ActionFinishedCallback()
	{
		actionIndex++;
		runningAction = false;
		if (!preActionsFinished && actionIndex - 1 < preActions.Count)
		{
			FinalizeAction(preActions[actionIndex - 1], naturalFinish: true);
			if (actionIndex >= preActions.Count)
			{
				OnPreActionsFinished();
			}
		}
	}

	protected void OnPreActionsFinished()
	{
		actionIndex = 0;
		preActionsFinished = true;
	}

	protected virtual bool NeedsCancel()
	{
		return false;
	}

	protected virtual void CheckExitConditions()
	{
		if (exitConditionsMet)
		{
			if (NeedsCancel())
			{
				FinishBehavior(naturalFinish: false);
			}
			return;
		}
		for (int i = 0; i < exitConditions.Count; i++)
		{
			if (exitConditions[i] != null)
			{
				exitConditions[i].UpdateCondition();
				if (!exitConditions[i].ConditionMet(associatedDog))
				{
					return;
				}
			}
		}
		exitConditionsMet = true;
		switch (afterExitConditions)
		{
		case AfterExitConditionsMet.FINISH:
			FinishBehavior();
			break;
		case AfterExitConditionsMet.REPLACEMENT_ALLOWED:
			canBeReplaced = true;
			break;
		}
	}

	public virtual BehaviorPriority GetPriority()
	{
		return priority;
	}

	public virtual bool InternalStartConditionsMet()
	{
		if (currentLockoutTime > 0f)
		{
			return false;
		}
		for (int i = 0; i < startConditions.Count; i++)
		{
			if (!startConditions[i].ConditionMet(associatedDog))
			{
				return false;
			}
		}
		if (!HeldObjectTagsValid())
		{
			return false;
		}
		return true;
	}

	public bool HeldObjectTagsValid()
	{
		if (heldObjectTags.Count == 0)
		{
			return true;
		}
		GameObject carriedObject = associatedDog.GetComponent<MouthController>().GetCarriedObject();
		if (carriedObject == null)
		{
			return false;
		}
		if (heldObjectTags.Contains(TagsEnum.ALL))
		{
			return true;
		}
		for (int i = 0; i < heldObjectTags.Count; i++)
		{
			if (carriedObject.CompareTag(Tags.GetTagFromTagsEnum(heldObjectTags[i])))
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool ExternalRequirementsMet()
	{
		return true;
	}

	public virtual bool TargetConditionsMet(GameObject potentialTarget)
	{
		return true;
	}

	public virtual bool PairedTargetConditionsMet(GameObject potentialPairedDog)
	{
		return true;
	}

	public virtual List<TagsEnum> GetWantedTags()
	{
		return tags;
	}

	public virtual float GetLockoutTime()
	{
		return lockoutTime;
	}

	public virtual List<string> GetAllProperties()
	{
		return new List<string>();
	}
}
