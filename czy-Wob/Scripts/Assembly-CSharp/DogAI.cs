using System.Collections.Generic;
using UnityEngine;

public class DogAI : MonoBehaviour
{
	public struct TransformAndPos
	{
		public bool valid;

		public Transform transform;

		public Vector3 closestPosition;

		public TransformAndPos(Transform t, Vector3 p, bool v = true)
		{
			valid = v;
			transform = t;
			closestPosition = p;
		}
	}

	public bool AIEnabled;

	public AIMode currentMode;

	public bool debugLogging;

	private string behaviorHolderName = "behavior_holder";

	private string templatePath = "DogBehaviors";

	private float maxXRot = 45f;

	private float maxZRot = 45f;

	private Transform continuousFacingTarget;

	private RaycastHit[] results = new RaycastHit[100];

	private List<DogBehaviorBase> wantedTagKeys = new List<DogBehaviorBase>();

	private Dictionary<DogBehaviorBase, List<TagsEnum>> wantedTags = new Dictionary<DogBehaviorBase, List<TagsEnum>>();

	private DogBehaviorBase currentBehavior;

	public List<GameObject> behaviorList;

	private List<GameObject> behaviorObjects = new List<GameObject>();

	private List<DogBehaviorBase> behaviorScripts = new List<DogBehaviorBase>();

	private List<DogBehaviorBase> potentialBehaviors = new List<DogBehaviorBase>();

	private Dictionary<IndicatorAction, int> actionToBehaviorIndexDict = new Dictionary<IndicatorAction, int>();

	private float gracePeriodTimer = 2f;

	private float currentGracePeriodTimer;

	private float needBonus = 2f;

	private float roomSwitchCost = 0.75f;

	private float playerHeldObjectBonus = 1f;

	private float minTargetDistance = 3f;

	private float maxTargetDistance = 20f;

	private float minTargetDistanceMultiplier = 1.2f;

	private float maxTargetDistanceMultiplier = 0.2f;

	private Dictionary<int, float> behaviorLockouts = new Dictionary<int, float>();

	private RoomBase targetRoom;

	private GameObject targetObject;

	private ReservableObject targetReservableObject;

	private Dictionary<DogBehaviorBase, List<GameObject>> potentialTargetObjects = new Dictionary<DogBehaviorBase, List<GameObject>>();

	private List<float> potentialFixationScores = new List<float>();

	private List<ScorableFixation> potentialFixations = new List<ScorableFixation>();

	private FixationBase currentFixation;

	private DistractionBase currentDistraction;

	private float timeSinceLastDistraction;

	private float minTimeBetweenDistractions = 1f;

	[HideInInspector]
	public Dictionary<FixationType, List<DogBehaviorBase>> fixationTypeBehaviorMapping = new Dictionary<FixationType, List<DogBehaviorBase>>();

	public List<FixationType> fixationLockoutKeys = new List<FixationType>();

	public Dictionary<FixationType, float> fixationLockoutMap = new Dictionary<FixationType, float>();

	private bool distractionsLocked;

	private bool currentCommandUserIssued;

	private Need currentNeedOverride = Need.None;

	private float currentHappyParticleTimer;

	private float happyParticleCheckRate = 1f;

	private Transform refTransform;

	private Transform refTransformBack;

	private float socialPersonalityDogTargetModifier = 2f;

	private float aloofPersonalityDogTargetModifier = 0.25f;

	private float mischiefPersonalityTargetBonus = 2f;

	private float mischiefPersonalityTargetPenalty = 0.15f;

	private float energyBonusModifier = 2f;

	private float energyPenalityModifier = 0.25f;

	private float layaboutEnergyMod = 0.75f;

	private float goofEnergyMod = 1.1f;

	private float bigFeelingsBonusNice = 2f;

	private float smallFeelingsBonusNice = 1.25f;

	private float bigFeelingsPenaltyNice = 0.1f;

	private float bigFeelingsBonusMean = 1.25f;

	private float bigFeelingsPenaltyMean = 0.1f;

	private float smallFeelingsPenaltyMean = 0.75f;

	private float feelingsSynergyBonus = 1.25f;

	private float feelingsSynergyPenalty = 0.75f;

	private float teethingScoreBonus = 2f;

	private float bittenAnger = -0.1f;

	private float bittenStress = -0.1f;

	private float growlAnger = -0.05f;

	private float growlStress = -0.05f;

	private float angerOnStrongCollision = -0.05f;

	private float stressOnStrongCollision = -0.02f;

	private float lovesPickupBoredom = 0.05f;

	private float hatesPickupStress = -0.1f;

	private float hatesPickupAnger = -0.1f;

	private bool debugVis;

	private GameMode gameMode;

	private DogLooks looksRef;

	private DoggyBrain brainRef;

	private DogNoises dogNoisesRef;

	private LegController legController;

	private WalkController walkController;

	private FaceController faceController;

	private DogPoopController poopControllerRef;

	private DogIndicatorController indicatorRef;

	private DogParticleController particleControllerRef;

	private NodeAssociationController associationController;

	private ObjectGrabber grabberRef;

	private NavmeshHelper navmeshRef;

	private DogRegistration dogRegRef;

	private SceneManagerBase sceneRef;

	private ObjectRegistration objRegRef;

	private InventoryManager inventoryRef;

	private ConstructionManager constructionRef;

	private void Awake()
	{
		AIEnabled = false;
	}

	public void Initialize()
	{
		InitializeDogBehaviors();
		looksRef = GetComponent<DogLooks>();
		legController = GetComponent<LegController>();
		walkController = GetComponent<WalkController>();
		faceController = GetComponent<FaceController>();
		indicatorRef = GetComponent<DogIndicatorController>();
		poopControllerRef = GetComponent<DogPoopController>();
		particleControllerRef = GetComponent<DogParticleController>();
		associationController = GetComponent<NodeAssociationController>();
		objRegRef = ObjectRegistration.GetRegistrationScript();
		sceneRef = objRegRef.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		navmeshRef = objRegRef.GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
		dogRegRef = objRegRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		inventoryRef = objRegRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		constructionRef = objRegRef.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		grabberRef = objRegRef.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER, nullAllowed: true);
		gameMode = objRegRef.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode();
		brainRef = GetComponent<DoggyBrain>();
		dogNoisesRef = GetComponent<DogNoises>();
		refTransform = legController.bodyFront.transform;
		refTransformBack = legController.bodyBack.transform;
		if (CheatEngine.cheatRef != null)
		{
			AIEnabled = CheatEngine.cheatRef.AIEnabled;
		}
	}

	private void Update()
	{
		if (!AIEnabled || brainRef.IsDead())
		{
			return;
		}
		if (currentGracePeriodTimer > 0f)
		{
			currentGracePeriodTimer -= Time.deltaTime;
			return;
		}
		UpdateFixationLockouts();
		if (currentFixation == null && (currentBehavior == null || currentBehavior.CanBeReplaced()))
		{
			FindNewFixation();
		}
		timeSinceLastDistraction += Time.deltaTime;
		if (currentDistraction != null && !currentCommandUserIssued)
		{
			currentDistraction.Update();
		}
		if (currentFixation != null && (currentDistraction == null || (currentBehavior != null && currentBehavior.CanBeReplaced())) && !currentCommandUserIssued)
		{
			currentFixation.Update();
		}
		if (currentBehavior != null && currentBehavior.IsTargeted() && currentBehavior.GetTarget() == null)
		{
			ForceInterruptBehavior();
		}
		else if (currentBehavior != null && currentBehavior.IsRoomBehavior() && currentBehavior.GetTargetRoom() == null)
		{
			ForceInterruptBehavior();
		}
		else if (currentBehavior != null && currentBehavior.IsReserveBehavior() && currentBehavior.GetTargetReservableObject() == null)
		{
			ForceInterruptBehavior();
		}
	}

	private void OnDestroy()
	{
		ForceInterruptBehavior();
	}

	public void SetAIMode(AIMode newMode)
	{
		currentMode = newMode;
	}

	public GameMode GetCurrentGameMode()
	{
		return gameMode;
	}

	public void SetTargetNeedOverride(Need newNeed)
	{
		currentNeedOverride = newNeed;
		if (currentNeedOverride != Need.None && currentBehavior != null && !WillBehaviorSolveForNeed(currentBehavior, currentNeedOverride))
		{
			ForceInterruptBehavior();
		}
	}

	public void SetContinuousFacingTarget(Transform target)
	{
		continuousFacingTarget = target;
		walkController.SetFacingTarget(target);
	}

	public bool RequirementFilled(Requirement requirement)
	{
		switch (requirement)
		{
		case Requirement.ALL_LEGS_GROUNDED:
			return legController.AllLegsGrounded();
		case Requirement.ANY_LEG_GROUNDED:
			return legController.AnyLegGrounded();
		case Requirement.NO_LEGS_GROUNDED:
			return !legController.AllLegsGrounded();
		case Requirement.ACTOR_ROTATION_VALID:
			return IsValidRotation();
		case Requirement.ACTOR_ROTATION_INVALID:
			return !IsValidRotation();
		case Requirement.HAS_WINGS:
			return looksRef.GetWingType() != WingType.NO_WINGS;
		case Requirement.NEED_REQUIREMENT:
			return false;
		case Requirement.CAN_BARF:
			return brainRef.CanBarf();
		case Requirement.NO_EDIBLE_OBJECTS_EXIST:
			if (objRegRef.DoObjectsExistForTag(TagsEnum.FOOD) || objRegRef.DoObjectsExistForTag(TagsEnum.POOP))
			{
				return false;
			}
			return true;
		case Requirement.GAME_MODE_HOME:
			return gameMode == GameMode.HOME;
		case Requirement.CASUAL_POOP:
			if (poopControllerRef.NeedsToPoop())
			{
				return !poopControllerRef.NeedsToPoopImmediately();
			}
			return false;
		case Requirement.EMERGENCY_POOP:
			return poopControllerRef.NeedsToPoopImmediately();
		case Requirement.HAS_COMPLETED_DEN:
			return DogDenManager.CanDogAccessAnyCompletedDen(dogRegRef.GetIDFromDog(base.gameObject)).HasValue;
		default:
			Debug.LogError("Invalid requirement: " + requirement);
			return false;
		}
	}

	public bool IsValidRotation()
	{
		if (refTransform == null)
		{
			return false;
		}
		Vector3 eulerAngles = refTransform.eulerAngles;
		if (AngleUtil.GetAngleDiff(0f, eulerAngles.x) > maxXRot || AngleUtil.GetAngleDiff(0f, eulerAngles.z) > maxZRot)
		{
			return false;
		}
		return true;
	}

	public bool IsValidRotationForSit()
	{
		if (refTransform == null)
		{
			return false;
		}
		if (AngleUtil.GetAngleDiff(0f, refTransformBack.eulerAngles.x) > maxXRot)
		{
			return false;
		}
		return true;
	}

	public DogBehaviorBase GetCurrentBehavior()
	{
		return currentBehavior;
	}

	public FixationBase GetCurrentFixation()
	{
		return currentFixation;
	}

	public DistractionBase GetCurrentDistraction()
	{
		return currentDistraction;
	}

	public void SetEnabled(bool enabledVal, bool fromCheat = false)
	{
		if ((!fromCheat || currentMode == AIMode.STANDARD) && (!enabledVal || !(CheatEngine.cheatRef != null) || CheatEngine.cheatRef.AIEnabled))
		{
			AIEnabled = enabledVal;
			if (!AIEnabled && currentBehavior != null && currentBehavior.userCancelable)
			{
				currentBehavior.FinishBehavior(naturalFinish: false);
			}
		}
	}

	public void ReplaceCurrentBehaviorWithType(DogBehaviorBase newBehaviorType, BehaviorRole role = BehaviorRole.Actor)
	{
		DogBehaviorBase dogBehaviorBase = null;
		for (int i = 0; i < behaviorScripts.Count; i++)
		{
			if (behaviorScripts[i].GetType() == newBehaviorType.GetType())
			{
				dogBehaviorBase = behaviorScripts[i];
				break;
			}
		}
		if (dogBehaviorBase != null)
		{
			SetCurrentBehavior(dogBehaviorBase, role);
			return;
		}
		Debug.LogError(string.Concat("No valid new behavior found for behavior type: ", newBehaviorType, " for Dog: ", base.gameObject));
	}

	public void RequestInterruptBehavior()
	{
		ForceInterruptBehavior();
	}

	public void OnLevitatedByDog(GameObject dogWhomLevitatedMe)
	{
		DogPersonality personality = brainRef.GetPersonality();
		SocialPersonalityType socialPersonality = personality.GetSocialPersonality();
		PettablePersonalityType pettablePersonalityType = personality.GetPettablePersonalityType();
		NicenessPersonalityType nicenessPersonalityType = personality.GetNicenessPersonalityType();
		if (pettablePersonalityType == PettablePersonalityType.DISLIKES_PETTING)
		{
			if (nicenessPersonalityType == NicenessPersonalityType.MEAN)
			{
				brainRef.UpdateAnger(hatesPickupAnger);
			}
			else
			{
				brainRef.UpdateStress(hatesPickupStress);
			}
		}
		else if (socialPersonality == SocialPersonalityType.SOCIAL)
		{
			brainRef.UpdateBoredom(lovesPickupBoredom);
		}
	}

	public void OnGrowledAtByDog(GameObject growlingDog)
	{
		DogPersonality personality = brainRef.GetPersonality();
		MischiefPersonalityType mischiefPersonality = personality.GetMischiefPersonality();
		NicenessPersonalityType nicenessPersonalityType = personality.GetNicenessPersonalityType();
		if (nicenessPersonalityType != NicenessPersonalityType.NICE)
		{
			brainRef.UpdateAnger(growlAnger);
		}
		if (nicenessPersonalityType == NicenessPersonalityType.MEAN)
		{
			brainRef.UpdateAnger(growlAnger);
			DistractionGrowl newDistraction = new DistractionGrowl(this, 1f, growlingDog);
			TryAddNewDistraction(newDistraction, useTimeSinceLastDistraction: false);
		}
		else
		{
			brainRef.UpdateStress(growlStress);
		}
		switch (mischiefPersonality)
		{
		case MischiefPersonalityType.POLITE:
			GetComponent<MouthController>().DropObject();
			break;
		case MischiefPersonalityType.STANDARD:
			if (Random.value < 0.5f)
			{
				GetComponent<MouthController>().DropObject();
			}
			break;
		}
	}

	public void OnComplainedAtByDog(GameObject complainerDog)
	{
		DogPersonality personality = brainRef.GetPersonality();
		MischiefPersonalityType mischiefPersonality = personality.GetMischiefPersonality();
		if (personality.GetNicenessPersonalityType() == NicenessPersonalityType.MEAN)
		{
			brainRef.UpdateAnger(growlAnger);
			DistractionGrowl newDistraction = new DistractionGrowl(this, 0.5f, complainerDog);
			TryAddNewDistraction(newDistraction, useTimeSinceLastDistraction: false);
		}
		switch (mischiefPersonality)
		{
		case MischiefPersonalityType.POLITE:
			GetComponent<MouthController>().DropObject();
			break;
		case MischiefPersonalityType.MISCHEVIOUS:
		{
			DistractionComplain newDistraction2 = new DistractionComplain(this, 1f, complainerDog);
			TryAddNewDistraction(newDistraction2, useTimeSinceLastDistraction: false);
			break;
		}
		case MischiefPersonalityType.STANDARD:
			if (Random.value < 0.25f)
			{
				GetComponent<MouthController>().DropObject();
			}
			break;
		}
	}

	public void OnBittenByDog(GameObject biteDog)
	{
		NicenessPersonalityType nicenessPersonalityType = brainRef.GetPersonality().GetNicenessPersonalityType();
		if (nicenessPersonalityType != NicenessPersonalityType.NICE)
		{
			brainRef.UpdateAnger(bittenAnger);
		}
		if (nicenessPersonalityType == NicenessPersonalityType.MEAN)
		{
			brainRef.UpdateAnger(bittenAnger);
			brainRef.UpdateStress(bittenStress / 4f);
		}
		else
		{
			brainRef.UpdateStress(bittenStress);
		}
		ForceInterruptBehavior(biteDog);
		dogNoisesRef.OnDogHurt();
	}

	public void OnGrabbedByPlayer()
	{
		DogPersonality personality = brainRef.GetPersonality();
		SocialPersonalityType socialPersonality = personality.GetSocialPersonality();
		NicenessPersonalityType nicenessPersonalityType = personality.GetNicenessPersonalityType();
		if (personality.GetPettablePersonalityType() == PettablePersonalityType.DISLIKES_PETTING)
		{
			if (nicenessPersonalityType == NicenessPersonalityType.MEAN)
			{
				brainRef.UpdateAnger(hatesPickupAnger);
			}
			else
			{
				brainRef.UpdateStress(hatesPickupStress);
			}
		}
		else if (socialPersonality == SocialPersonalityType.SOCIAL)
		{
			brainRef.UpdateBoredom(lovesPickupBoredom);
		}
	}

	public void OnStrongCollision(GameObject collidingObject)
	{
		if (collidingObject == base.gameObject)
		{
			return;
		}
		if (collidingObject.transform.root.GetComponent<Pipe>() == null)
		{
			if ((collidingObject.CompareTag(Tags.DOG) && brainRef.GetFeelingTowardsTarget(collidingObject) == Opinion.DISLIKE) || brainRef.GetPersonality().GetNicenessPersonalityType() == NicenessPersonalityType.MEAN)
			{
				brainRef.UpdateAnger(angerOnStrongCollision);
			}
			else
			{
				brainRef.UpdateStress(stressOnStrongCollision);
			}
		}
		if (collidingObject.GetComponent<Pipe>() == null && collidingObject.GetComponent<RoomBase>() == null)
		{
			dogNoisesRef.OnDogBumped();
		}
	}

	public void ForceInterruptBehavior(GameObject objectCause = null)
	{
		if (objectCause != null && currentBehavior != null && currentBehavior.priority == BehaviorPriority.Critical)
		{
			return;
		}
		if (currentBehavior == null || !currentBehavior.IsRunningBehavior())
		{
			if (walkController != null)
			{
				walkController.RemoveFacingTarget();
			}
			currentBehavior = null;
		}
		else
		{
			currentBehavior.FinishBehavior(naturalFinish: false, objectCause);
			walkController.RemoveFacingTarget();
		}
	}

	public bool FindNewTargetedBehavior(GameObject objToTarget, bool forceInterrupt)
	{
		if (currentBehavior != null && currentBehavior.IsTargeted() && currentBehavior.GetTarget() != null && currentBehavior.GetTarget().transform.root == objToTarget.transform.root)
		{
			return true;
		}
		return FindNewBehavior(objToTarget, Need.None, null, FixationType.NONE, forceInterrupt);
	}

	public bool FindNewNeedBehavior(Need need, bool forceInterrupt, GameObject neededTarget = null)
	{
		if (currentBehavior != null && WillBehaviorSolveForNeed(currentBehavior, need))
		{
			return true;
		}
		bool forceInterrupt2 = forceInterrupt;
		return FindNewBehavior(neededTarget, need, null, FixationType.NONE, forceInterrupt2);
	}

	public bool FindNewFixationTypeBehavior(FixationType fixationType, bool forceInterrupt, GameObject neededTarget = null)
	{
		if (currentBehavior != null && fixationTypeBehaviorMapping.ContainsKey(fixationType) && fixationTypeBehaviorMapping[fixationType].Contains(currentBehavior))
		{
			return true;
		}
		bool forceInterrupt2 = forceInterrupt;
		return FindNewBehavior(neededTarget, Need.None, null, fixationType, forceInterrupt2);
	}

	public bool FindNewReinforcedBehavior(bool forceInterrupt, GameObject neededTarget = null)
	{
		if (currentBehavior != null && brainRef.GetReinforcementMultiplierForBehavior(currentBehavior) > 0f)
		{
			return true;
		}
		bool forceInterrupt2 = forceInterrupt;
		return FindNewBehavior(neededTarget, Need.None, null, FixationType.NONE, forceInterrupt2, userIssued: false, null, requireReinforcement: true);
	}

	public DogBehaviorBase GetBehaviorForIndicatorAction(IndicatorAction actionRef)
	{
		return behaviorScripts[actionToBehaviorIndexDict[actionRef]];
	}

	public bool TryRunIndicatorBehavior(IndicatorAction actionRef, GameObject target, Vector3? associatedPosition = null, Vector2Int? associatedGridSquare = null)
	{
		bool flag = false;
		if (!brainRef.DoesDogRequireDeath() && (currentBehavior == null || currentBehavior.userCancelable))
		{
			flag = TryRunBehavior(GetBehaviorForIndicatorAction(actionRef), target, forceInterrupt: true, userIssued: true, associatedPosition, associatedGridSquare);
		}
		if (flag)
		{
			bool targetIsDog = false;
			if (target != null && target.CompareTag(Tags.DOG))
			{
				targetIsDog = true;
			}
			string text = IndicatorActionButton.GetSuccessTextForAction(actionRef, targetIsDog);
			if (target != null)
			{
				string text2 = "";
				ObjectID component = target.GetComponent<ObjectID>();
				if (component != null)
				{
					text2 = ((!target.CompareTag(Tags.DOG)) ? ((string)component.item.itemNameLocalized) : dogRegRef.GetSaveableDogFromDog(target).dogName);
				}
				else
				{
					PlacedObjectID component2 = target.GetComponent<PlacedObjectID>();
					if (component2 != null && inventoryRef != null)
					{
						RoomCustomizationObject customizationObjectForPath = inventoryRef.GetCustomizationObjectForPath(component2.GetResourceString());
						if (customizationObjectForPath != null)
						{
							text2 = customizationObjectForPath.GetName();
						}
					}
				}
				int num = text.IndexOf('[');
				int num2 = text.IndexOf(']');
				if (num != -1 && num2 != -1)
				{
					text = text.Substring(0, num) + text2 + text.Substring(num2 + 1);
				}
			}
			indicatorRef.OnCommandObeyed(text, associatedPosition);
		}
		else
		{
			indicatorRef.OnCommandIgnored();
		}
		return flag;
	}

	public bool TryRunBehavior(DogBehaviorBase behavior, GameObject target, bool forceInterrupt, bool userIssued = false, Vector3? associatedPosition = null, Vector2Int? associatedGridSquare = null)
	{
		if (currentBehavior != null && currentBehavior.name == behavior.name && GetTargetObject() == target && (!associatedPosition.HasValue || associatedPosition.Value == currentBehavior.GetStoredPosition()))
		{
			return true;
		}
		return FindNewBehavior(target, Need.None, behavior, FixationType.NONE, forceInterrupt, userIssued, associatedPosition);
	}

	public void OnFixationDone()
	{
		currentFixation = null;
		ForceInterruptBehavior();
	}

	public void OnDistractionDone(DistractionBase distractionRef)
	{
		if (distractionRef != currentDistraction)
		{
			distractionRef.PreDestroy();
			return;
		}
		if (currentDistraction != null)
		{
			currentDistraction.PreDestroy();
		}
		currentDistraction = null;
	}

	private void UpdateFixationLockouts()
	{
		for (int num = fixationLockoutKeys.Count - 1; num >= 0; num--)
		{
			fixationLockoutMap[fixationLockoutKeys[num]] -= Time.deltaTime;
			if (fixationLockoutMap[fixationLockoutKeys[num]] <= 0f)
			{
				fixationLockoutMap.Remove(fixationLockoutKeys[num]);
				fixationLockoutKeys.RemoveAt(num);
			}
		}
	}

	private void FindNewFixation()
	{
		potentialFixations.Clear();
		potentialFixationScores.Clear();
		if (gameMode == GameMode.BREEDING)
		{
			FindNewBehavior();
			return;
		}
		if (!fixationLockoutMap.ContainsKey(FixationType.DOG))
		{
			FixationDog.ScoreAndAddFixations(base.gameObject, ref potentialFixations, ref potentialFixationScores);
		}
		if (!fixationLockoutMap.ContainsKey(FixationType.ROOM))
		{
			FixationRoom.ScoreAndAddFixations(base.gameObject, ref potentialFixations, ref potentialFixationScores);
		}
		if (!fixationLockoutMap.ContainsKey(FixationType.OBJECT))
		{
			FixationObject.ScoreAndAddFixations(base.gameObject, ref potentialFixations, ref potentialFixationScores);
		}
		if (!fixationLockoutMap.ContainsKey(FixationType.HAPPINESS))
		{
			FixationHappy.ScoreAndAddFixations(base.gameObject, ref potentialFixations, ref potentialFixationScores);
		}
		if (!fixationLockoutMap.ContainsKey(FixationType.HOARD_OBJECTS))
		{
			FixationHoardObjects.ScoreAndAddFixations(base.gameObject, ref potentialFixations, ref potentialFixationScores);
		}
		if (!fixationLockoutMap.ContainsKey(FixationType.BUILD_DEN) && !brainRef.IsGhost())
		{
			FixationBuildDen.ScoreAndAddFixations(base.gameObject, ref potentialFixations, ref potentialFixationScores);
		}
		if (!fixationLockoutMap.ContainsKey(FixationType.EXPAND_DEN) && !brainRef.IsGhost())
		{
			FixationExpandDen.ScoreAndAddFixations(base.gameObject, ref potentialFixations, ref potentialFixationScores);
		}
		if (!fixationLockoutMap.ContainsKey(FixationType.DEFAULT))
		{
			FixationDefault.ScoreAndAddFixations(base.gameObject, ref potentialFixations, ref potentialFixationScores);
		}
		if (potentialFixations.Count == 0)
		{
			FindNewBehavior();
			return;
		}
		ScorableFixation weightedRandom = ListUtil.GetWeightedRandom(potentialFixations, potentialFixationScores);
		currentFixation = GetFixationFromScorableFixation(weightedRandom);
		if (!fixationLockoutKeys.Contains(weightedRandom.fixationType))
		{
			fixationLockoutKeys.Add(weightedRandom.fixationType);
		}
		fixationLockoutMap[weightedRandom.fixationType] = currentFixation.GetLockoutTime();
	}

	private FixationBase GetFixationFromScorableFixation(ScorableFixation sf)
	{
		switch (sf.fixationType)
		{
		case FixationType.DOG:
			return new FixationDog(this, (GameObject)sf.target);
		case FixationType.ROOM:
			return new FixationRoom(this);
		case FixationType.OBJECT:
			return new FixationObject(this, (GameObject)sf.target);
		case FixationType.HAPPINESS:
			return new FixationHappy(this);
		case FixationType.HOARD_OBJECTS:
			return new FixationHoardObjects(this);
		case FixationType.BUILD_DEN:
			return new FixationBuildDen(this);
		case FixationType.EXPAND_DEN:
			return new FixationExpandDen(this);
		case FixationType.DEFAULT:
			return new FixationDefault(this);
		default:
			Debug.LogError("No fixation built for type: " + sf.fixationType);
			return new FixationBase(this);
		}
	}

	public void LockDistractions()
	{
		distractionsLocked = true;
	}

	public void UnlockDistractions()
	{
		distractionsLocked = false;
	}

	public bool CanTryRunDistraction(DistractionBase newDistraction, bool useTimeSinceLastDistraction = true, bool ignoreLocks = false, bool ignorePriority = false)
	{
		if (distractionsLocked && !ignoreLocks)
		{
			return false;
		}
		if (!ignorePriority && currentDistraction != null && !currentDistraction.CanBeReplaced(newDistraction, ignorePriority))
		{
			return false;
		}
		if (useTimeSinceLastDistraction && timeSinceLastDistraction < minTimeBetweenDistractions)
		{
			return false;
		}
		return true;
	}

	public bool DoesNewDistractionPassRandomCheck(DistractionBase newDistraction)
	{
		float num = newDistraction.GetWeight();
		if (num >= 1f)
		{
			return true;
		}
		if (currentDistraction != null)
		{
			num /= 2f;
		}
		if (Random.value > num)
		{
			return false;
		}
		return true;
	}

	public bool TryAddNewDistraction(DistractionBase newDistraction, bool useTimeSinceLastDistraction = true, bool autoTest = true, bool ignoreLocks = false)
	{
		if (brainRef.IsDead())
		{
			return false;
		}
		if (autoTest)
		{
			if (!CanTryRunDistraction(newDistraction, useTimeSinceLastDistraction, ignoreLocks))
			{
				return false;
			}
			if (!DoesNewDistractionPassRandomCheck(newDistraction))
			{
				return false;
			}
		}
		if (!newDistraction.FindNewBehavior(forceInterrupt: true))
		{
			return false;
		}
		if (currentDistraction != null)
		{
			OnDistractionDone(currentDistraction);
		}
		timeSinceLastDistraction = 0f;
		currentDistraction = newDistraction;
		return true;
	}

	public void OnObjectInFrontOfFace(GameObject obj)
	{
		walkController.OnObjectInFrontOfFace(obj);
	}

	public bool FindNewBehavior(GameObject neededTarget = null, Need neededNeed = Need.None, DogBehaviorBase neededBehavior = null, FixationType neededFixationType = FixationType.NONE, bool forceInterrupt = false, bool userIssued = false, Vector3? associatedPosition = null, bool requireReinforcement = false)
	{
		if (!AIEnabled && !userIssued)
		{
			return false;
		}
		if (faceController.AILocked() && !userIssued)
		{
			return false;
		}
		if (userIssued)
		{
			forceInterrupt = true;
		}
		if (!forceInterrupt && currentBehavior != null && currentBehavior.IsRunningBehavior() && !currentBehavior.CanBeReplaced())
		{
			return false;
		}
		if (currentCommandUserIssued && !userIssued && !forceInterrupt)
		{
			return false;
		}
		FindPotentialBehaviors(neededTarget, neededNeed, neededBehavior, neededFixationType, forceInterrupt, requireReinforcement);
		UpdateWantedTags();
		FindPotentialTargets(neededTarget);
		bool num = ChooseBehavior();
		ClearReferences();
		if (num && userIssued)
		{
			currentCommandUserIssued = true;
		}
		else
		{
			currentCommandUserIssued = false;
		}
		if (num && associatedPosition.HasValue)
		{
			GetCurrentBehavior().StorePosition(associatedPosition.Value);
		}
		return num;
	}

	public void UpdateNeed(Need need, float amount, bool modifyViaPersonality = false)
	{
		if (need == Need.Random)
		{
			float value = Random.value;
			need = ((value <= 0.2f) ? Need.Energy : ((!(value <= 0.4f)) ? ((value <= 0.6f) ? Need.Boredom : ((!(value <= 0.8f)) ? Need.Stress : Need.Anger)) : Need.Hunger));
		}
		if (modifyViaPersonality)
		{
			if (brainRef.GetPersonality().GetEnergyPersonality() == EnergyPersonalityType.LAYABOUT)
			{
				amount *= layaboutEnergyMod;
			}
			else if (brainRef.GetPersonality().GetEnergyPersonality() == EnergyPersonalityType.GOOF)
			{
				amount *= goofEnergyMod;
			}
		}
		brainRef.UpdateNeed(need, amount);
	}

	public GameObject GetTargetObject()
	{
		return targetObject;
	}

	public RoomBase GetTargetRoom()
	{
		return targetRoom;
	}

	public ReservableObject GetTargetReservableObject()
	{
		return targetReservableObject;
	}

	public List<GameObject> GetPotentialTargets(DogBehaviorBase behavior)
	{
		return potentialTargetObjects[behavior];
	}

	private TransformAndPos CleanCastToPosition(Vector3 pos, GameObject targetObj = null)
	{
		Vector3 position = legController.internalFacingObj.transform.position;
		int num = RaycastUtil.NavmeshCastAllNonAlloc(position, pos - position, Vector3.Distance(position, pos) + 0.005f, results);
		if (associationController.debugVis)
		{
			Debug.DrawLine(position, pos, Color.black, 0.2f);
		}
		Vector3 p = pos;
		float num2 = float.PositiveInfinity;
		Transform t = targetObj.transform;
		for (int i = 0; i < num; i++)
		{
			if (!(results[i].transform.root == base.gameObject.transform.root))
			{
				if (!(results[i].transform.root == targetObj.transform.root))
				{
					return new TransformAndPos(null, Vector3.zero, v: false);
				}
				float num3 = Vector3.Distance(position, results[i].point);
				if (num3 < num2)
				{
					num2 = num3;
					p = results[i].point;
					t = results[i].transform;
				}
			}
		}
		return new TransformAndPos(t, p);
	}

	public TransformAndPos GetBestTransformAndPosForTarget(GameObject target, bool topLevel = true, int chosenHeadIndex = 0)
	{
		Vector3 position = faceController.GetDogHeadForIndex(chosenHeadIndex).mouthTransform.position;
		TransformAndPos result = new TransformAndPos(null, Vector3.zero, v: false);
		if (!target.activeSelf)
		{
			return result;
		}
		InteractableBase component = target.transform.root.GetComponent<InteractableBase>();
		if (component != null && component.HasCustomInteractionPoint())
		{
			result.closestPosition = component.GetInteractionPoint();
			result.transform = component.GetInteractionPointTransform();
			return result;
		}
		Collider component2 = target.GetComponent<Collider>();
		if (component2 != null && target.layer != RaycastUtil.collisionHelperLayer && target.layer != RaycastUtil.collisionHelperBodyLayer && target.layer != RaycastUtil.collideAndIgnoreRaycasts && target.layer != RaycastUtil.collideAndIgnoreRaycastsAndRouting)
		{
			Vector3 vector = component2.ClosestPointOnBounds(position);
			if (vector != position)
			{
				component2.Raycast(new Ray(position, Vector3.Normalize(vector - position)), out var hitInfo, Vector3.Distance(position, vector) + Vector3.Distance(vector, component2.transform.position));
				if (hitInfo.transform == null)
				{
					component2.Raycast(new Ray(position, Vector3.Normalize(component2.transform.position - position)), out hitInfo, Vector3.Distance(position, component2.transform.position));
				}
				if (hitInfo.transform != null)
				{
					vector = hitInfo.point;
				}
			}
			TransformAndPos transformAndPos = CleanCastToPosition(vector, target);
			if (transformAndPos.transform != null)
			{
				result = new TransformAndPos(transformAndPos.transform, transformAndPos.closestPosition);
			}
		}
		else if (topLevel && target.GetComponentsInChildren<Collider>().Length == 0)
		{
			return new TransformAndPos(target.transform, target.transform.position);
		}
		float num = Vector3.Distance(position, result.closestPosition);
		if (result.transform == null)
		{
			num = float.PositiveInfinity;
		}
		for (int i = 0; i < target.transform.childCount; i++)
		{
			if (target.transform.GetChild(i) == null || target.transform.GetChild(i).localScale == Vector3.zero)
			{
				continue;
			}
			TransformAndPos bestTransformAndPosForTarget = GetBestTransformAndPosForTarget(target.transform.GetChild(i).gameObject, topLevel: false);
			if (!(bestTransformAndPosForTarget.transform == null) && !(bestTransformAndPosForTarget.transform.localScale == Vector3.zero))
			{
				float num2 = Vector3.Distance(position, bestTransformAndPosForTarget.closestPosition);
				if (num2 < num)
				{
					num = num2;
					result = bestTransformAndPosForTarget;
				}
			}
		}
		return result;
	}

	public Transform GetBestPosTransformForTarget(GameObject target)
	{
		return GetBestTransformAndPosForTarget(target).transform;
	}

	public Vector3 GetBestPosForTarget(GameObject target)
	{
		TransformAndPos bestTransformAndPosForTarget = GetBestTransformAndPosForTarget(target);
		if (bestTransformAndPosForTarget.valid)
		{
			return bestTransformAndPosForTarget.closestPosition;
		}
		return ObjectUtil.GetObjCenter(target);
	}

	public bool CanRaycastToObject(GameObject target)
	{
		if (target.transform.root.tag == Tags.DOG)
		{
			return CanRaycastToDog(target);
		}
		Vector3 bestPosForTarget = GetBestPosForTarget(target);
		GameObject internalFacingObj = legController.internalFacingObj;
		Vector3 hitPoint = Vector3.zero;
		Vector3 hitPoint2 = Vector3.zero;
		if (!ObjectUtil.GetStageHitpoint(internalFacingObj.transform.position, ref hitPoint) || !ObjectUtil.GetStageHitpoint(bestPosForTarget, ref hitPoint2))
		{
			return false;
		}
		bool result = false;
		float dist = Vector3.Distance(hitPoint2, hitPoint);
		int num = RaycastUtil.GoodRaycastAllNonAlloc(hitPoint, hitPoint2 - hitPoint, dist, results);
		for (int i = 0; i < num; i++)
		{
			if (!(results[i].transform.root.tag == Tags.DOG))
			{
				if (results[i].transform.root != target.transform.root)
				{
					return false;
				}
				result = true;
			}
		}
		return result;
	}

	public bool CanRaycastToDog(GameObject dog)
	{
		BoundingBoxComponent boundingBoxComponent = dog.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = dog.AddComponent<BoundingBoxComponent>();
		}
		Transform mouthTransform = faceController.GetDogHeadForIndex(0).mouthTransform;
		BoxCollider boxCollider = dog.AddComponent<BoxCollider>();
		boxCollider.size = boundingBoxComponent.GetBoxSize();
		boxCollider.center = boundingBoxComponent.GetBoxCenter();
		Vector3 position = mouthTransform.position;
		Vector3 vector = boxCollider.ClosestPointOnBounds(position);
		if (vector != position)
		{
			boxCollider.Raycast(new Ray(position, Vector3.Normalize(vector - position)), out var hitInfo, Vector3.Distance(position, vector) + Vector3.Distance(vector, boxCollider.transform.position));
			if (hitInfo.transform == null)
			{
				boxCollider.Raycast(new Ray(position, Vector3.Normalize(boxCollider.transform.position - position)), out hitInfo, Vector3.Distance(position, boxCollider.transform.position));
			}
			vector = hitInfo.point;
		}
		Object.Destroy(boxCollider);
		GameObject gameObject = mouthTransform.gameObject;
		float dist = Vector3.Distance(vector, gameObject.transform.position);
		bool result = false;
		int num = RaycastUtil.GoodRaycastAllNonAlloc(gameObject.transform.position, vector - gameObject.transform.position, dist, results);
		for (int i = 0; i < num; i++)
		{
			if (!(results[i].transform.root == base.gameObject.transform.root))
			{
				if (results[i].transform.root != dog.transform.root)
				{
					return false;
				}
				result = true;
			}
		}
		return result;
	}

	private void InitializeDogBehaviors()
	{
		Object[] array = Resources.LoadAll(templatePath);
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject = (GameObject)array[i];
			if (gameObject.GetComponent<DogBehaviorBase>().autoAddToDog)
			{
				behaviorList.Add(gameObject);
			}
		}
		AddNeededScripts();
		GameObject gameObject2 = new GameObject(behaviorHolderName);
		gameObject2.transform.SetParent(base.transform);
		for (int j = 0; j < behaviorList.Count; j++)
		{
			behaviorLockouts[j] = 0f;
			GameObject gameObject3 = Object.Instantiate(behaviorList[j]);
			gameObject3.name = behaviorList[j].name;
			gameObject3.transform.SetParent(gameObject2.transform);
			behaviorObjects.Add(gameObject3);
			DogBehaviorBase component = gameObject3.GetComponent<DogBehaviorBase>();
			if (component.associatedIndicatorAction != IndicatorAction.NONE)
			{
				actionToBehaviorIndexDict[component.associatedIndicatorAction] = behaviorScripts.Count;
			}
			component.SetAssociatedDog(base.gameObject);
			behaviorScripts.Add(component);
			if (component.fixationType != FixationType.NONE)
			{
				if (!fixationTypeBehaviorMapping.ContainsKey(component.fixationType))
				{
					fixationTypeBehaviorMapping[component.fixationType] = new List<DogBehaviorBase>();
				}
				fixationTypeBehaviorMapping[component.fixationType].Add(component);
			}
		}
	}

	private void AddNeededScripts()
	{
		base.gameObject.AddComponent<PlayBow>();
		base.gameObject.AddComponent<FlyBehavior>();
		base.gameObject.AddComponent<SitBehavior>();
		base.gameObject.AddComponent<EatBehavior>();
		base.gameObject.AddComponent<BarkBehavior>();
		base.gameObject.AddComponent<HowlBehavior>();
		base.gameObject.AddComponent<BarfBehavior>();
		base.gameObject.AddComponent<SleepBehavior>();
		base.gameObject.AddComponent<WobbleBehavior>();
		base.gameObject.AddComponent<SneezeBehavior>();
		base.gameObject.AddComponent<RuckusBehavior>();
		base.gameObject.AddComponent<LieDownBehavior>();
		base.gameObject.AddComponent<WatchTVBehavior>();
		base.gameObject.AddComponent<LevitateBehavior>();
		base.gameObject.AddComponent<GhostEatBehavior>();
		base.gameObject.AddComponent<RollOverBehavior>();
		base.gameObject.AddComponent<PlayDeadBehavior>();
		base.gameObject.AddComponent<GroundGoofBehavior>();
		base.gameObject.AddComponent<DeathKnellBehavior>();
		base.gameObject.AddComponent<ThrowObjectBehavior>();
		base.gameObject.AddComponent<ShakeObjectBehavior>();
		base.gameObject.AddComponent<ChokeOnFoodBehavior>();
	}

	private bool ChooseBehavior()
	{
		MathUtil.ShuffleList(ref potentialBehaviors);
		List<float> list = new List<float>();
		List<BehaviorTargetCombo> list2 = new List<BehaviorTargetCombo>();
		for (int i = 0; i < potentialBehaviors.Count; i++)
		{
			if (!potentialBehaviors[i].ExternalRequirementsMet())
			{
				continue;
			}
			if (!potentialBehaviors[i].IsTargeted() && !potentialBehaviors[i].IsRoomBehavior() && !potentialBehaviors[i].IsReserveBehavior())
			{
				float behaviorScore = GetBehaviorScore(potentialBehaviors[i], null);
				list.Add(behaviorScore);
				BehaviorTargetCombo item = new BehaviorTargetCombo(potentialBehaviors[i], null);
				list2.Add(item);
				continue;
			}
			for (int j = 0; j < potentialTargetObjects[potentialBehaviors[i]].Count; j++)
			{
				GameObject gameObject = potentialTargetObjects[potentialBehaviors[i]][j];
				if (!ObjectConnectionsManager.IsObjectConsumedByAnyGhost(gameObject))
				{
					float behaviorScore2 = GetBehaviorScore(potentialBehaviors[i], gameObject);
					list.Add(behaviorScore2);
					BehaviorTargetCombo item2 = new BehaviorTargetCombo(potentialBehaviors[i], gameObject);
					list2.Add(item2);
				}
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			list[k] = Mathf.Pow(list[k], 2f);
			list[k] *= 1000f;
		}
		if (debugVis)
		{
			MonoBehaviour.print(" ");
			for (int l = 0; l < list2.Count; l++)
			{
				MonoBehaviour.print(string.Concat(list2[l].behavior, " :", list2[l].target, " : ", list[l]));
			}
		}
		int index = 0;
		BehaviorTargetCombo? behaviorTargetCombo = null;
		while (list2.Count > 0)
		{
			BehaviorTargetCombo weightedRandom = ListUtil.GetWeightedRandom(list2, list, ref index);
			GameObject target = weightedRandom.target;
			if (target == null)
			{
				behaviorTargetCombo = weightedRandom;
				break;
			}
			InteractableBase component = target.GetComponent<InteractableBase>();
			Vector3 hitPoint = ((!(component != null)) ? ObjectUtil.GetObjCenter(target) : component.GetInteractionPoint());
			ObjectUtil.GetStageHitpoint(hitPoint, ref hitPoint);
			if (navmeshRef.GetPath(base.gameObject, hitPoint).Length != 0)
			{
				behaviorTargetCombo = weightedRandom;
				break;
			}
			list.RemoveAt(index);
			list2.RemoveAt(index);
		}
		if (!behaviorTargetCombo.HasValue)
		{
			return false;
		}
		if (currentBehavior != null)
		{
			ForceInterruptBehavior();
		}
		BehaviorTargetCombo value = behaviorTargetCombo.Value;
		SetCurrentBehavior(value.behavior, BehaviorRole.Actor, value.target);
		return true;
	}

	private Dictionary<Need, float> GetCurrentNeedScores()
	{
		Dictionary<Need, float> dictionary = new Dictionary<Need, float>();
		foreach (Need value in EnumUtils.GetValues<Need>())
		{
			if (value != Need.None)
			{
				dictionary[value] = brainRef.GetCurrentNeedScore(value);
			}
		}
		return dictionary;
	}

	private Dictionary<Need, float> GetPotentialNeedScores(DogBehaviorBase behavior, GameObject potentialTarget = null)
	{
		Dictionary<Need, float> dictionary = new Dictionary<Need, float>();
		foreach (Need value in EnumUtils.GetValues<Need>())
		{
			if (value != Need.None)
			{
				dictionary[value] = brainRef.GetPotentialNeedScore(value, behavior.GetNeedAdvertisement(value, potentialTarget));
			}
		}
		return dictionary;
	}

	private float GetBehaviorScore(DogBehaviorBase behavior, GameObject target)
	{
		float num = 1f;
		ulong? roomUID = GetComponent<BoundingBoxComponent>().GetRoomUID();
		ulong? num2 = null;
		BoundingBoxComponent boundingBoxComponent = null;
		if (target != null)
		{
			if (behavior.IsReserveBehavior())
			{
				num2 = target.transform.root.GetComponent<BuildObjectInfo>().GetUID();
			}
			else
			{
				boundingBoxComponent = target.GetComponent<BoundingBoxComponent>();
				num2 = boundingBoxComponent.GetRoomUID();
			}
		}
		if (behavior.debugMustRun)
		{
			return 1000f;
		}
		Dictionary<Need, float> currentNeedScores = GetCurrentNeedScores();
		SocialPersonalityType socialPersonality = brainRef.GetPersonality().GetSocialPersonality();
		MischiefPersonalityType mischiefPersonality = brainRef.GetPersonality().GetMischiefPersonality();
		NicenessPersonalityType nicenessPersonalityType = brainRef.GetPersonality().GetNicenessPersonalityType();
		float num3 = 1f;
		if (behavior.IsTargeted())
		{
			Dictionary<Need, float> potentialNeedScores = GetPotentialNeedScores(behavior, target);
			foreach (Need key in potentialNeedScores.Keys)
			{
				num3 += (currentNeedScores[key] - potentialNeedScores[key]) * needBonus;
			}
			if (grabberRef != null && target != null && grabberRef.GetGrabbedObject() == target.transform.root.gameObject)
			{
				num3 += playerHeldObjectBonus;
			}
			if (target != null)
			{
				DogBehaviorTargetedEnum targetedEnum = behavior.GetTargetedEnum();
				InteractableBase component = target.transform.root.gameObject.GetComponent<InteractableBase>();
				num3 = ((!(component != null)) ? float.NegativeInfinity : (num3 * component.GetMultiplierForBehavior(targetedEnum)));
				if (target.CompareTag(Tags.DOG))
				{
					switch (socialPersonality)
					{
					case SocialPersonalityType.ALOOF:
						num3 *= aloofPersonalityDogTargetModifier;
						break;
					case SocialPersonalityType.SOCIAL:
						num3 *= socialPersonalityDogTargetModifier;
						break;
					}
					if (target.GetComponent<DoggyBrain>().IsSleeping() && mischiefPersonality == MischiefPersonalityType.MISCHEVIOUS && (nicenessPersonalityType != NicenessPersonalityType.MEAN || brainRef.GetFeelingTowardsTarget(target) != Opinion.DISLIKE))
					{
						num3 = 0f;
					}
				}
				else if (target.CompareTag(Tags.POOP) || target.CompareTag(Tags.EGG))
				{
					switch (mischiefPersonality)
					{
					case MischiefPersonalityType.POLITE:
						num3 *= mischiefPersonalityTargetPenalty;
						break;
					case MischiefPersonalityType.MISCHEVIOUS:
						num3 *= mischiefPersonalityTargetBonus;
						break;
					}
				}
				if (component != null && component.IsObjectInUseByAnotherDog(GetComponent<ObjectID>().GetUID()))
				{
					switch (mischiefPersonality)
					{
					case MischiefPersonalityType.POLITE:
						num3 *= mischiefPersonalityTargetPenalty;
						break;
					case MischiefPersonalityType.MISCHEVIOUS:
						num3 *= mischiefPersonalityTargetBonus;
						break;
					}
				}
			}
			if ((brainRef.GetCurrentDogAge() == DogAge.CHILD || brainRef.GetCurrentDogAge() == DogAge.TEEN) && behavior.requireMouth)
			{
				num *= teethingScoreBonus;
			}
			num += num3;
		}
		else if (behavior.IsRoomBehavior())
		{
			Dictionary<Need, float> potentialNeedScores = GetPotentialNeedScores(behavior, target);
			foreach (Need key2 in potentialNeedScores.Keys)
			{
				num3 += (currentNeedScores[key2] - potentialNeedScores[key2]) * needBonus;
			}
			if (target != null)
			{
				DogBehaviorRoomEnum roomEnum = behavior.GetRoomEnum();
				RoomBase component2 = target.transform.root.gameObject.GetComponent<RoomBase>();
				num3 = ((!(component2 != null)) ? float.NegativeInfinity : (num3 * component2.GetBehaviorScoreMultiplier(roomEnum)));
			}
			num += num3;
		}
		else if (behavior.IsReserveBehavior())
		{
			Dictionary<Need, float> potentialNeedScores = GetPotentialNeedScores(behavior, target);
			foreach (Need key3 in potentialNeedScores.Keys)
			{
				num3 += (currentNeedScores[key3] - potentialNeedScores[key3]) * needBonus;
			}
			if (target != null)
			{
				DogBehaviorReserveEnum reserveEnum = behavior.GetReserveEnum();
				ReservableObject component3 = target.GetComponent<ReservableObject>();
				num3 = ((!(component3 != null)) ? float.NegativeInfinity : (num3 * component3.GetBehaviorScoreMultiplier(reserveEnum)));
				if (!behavior.flipReservationRequirements)
				{
					float num4 = component3.GetNumberOfReservations();
					num3 /= num4 + 1f;
				}
			}
			num += num3;
		}
		else
		{
			num += 1f;
			Dictionary<Need, float> potentialNeedScores = GetPotentialNeedScores(behavior);
			foreach (Need key4 in currentNeedScores.Keys)
			{
				num += (currentNeedScores[key4] - potentialNeedScores[key4]) * needBonus;
			}
		}
		EnergyPersonalityType energyPersonality = brainRef.GetPersonality().GetEnergyPersonality();
		if (WillBehaviorSolveForNeed(behavior, Need.Energy))
		{
			switch (energyPersonality)
			{
			case EnergyPersonalityType.GOOF:
				num *= energyPenalityModifier;
				break;
			case EnergyPersonalityType.LAYABOUT:
				num *= energyBonusModifier;
				break;
			}
		}
		else if (WillBehaviorSolveForNeed(behavior, Need.Energy, inverse: true))
		{
			switch (energyPersonality)
			{
			case EnergyPersonalityType.GOOF:
				num *= energyBonusModifier;
				break;
			case EnergyPersonalityType.LAYABOUT:
				num *= energyPenalityModifier;
				break;
			}
		}
		float num5 = 1f;
		FeelingTowardsTarget feelingTowardsTarget = behavior.feelingTowardsTarget;
		if (nicenessPersonalityType == NicenessPersonalityType.NICE || (brainRef.IsHappy() && nicenessPersonalityType == NicenessPersonalityType.STANDARD))
		{
			switch (feelingTowardsTarget)
			{
			case FeelingTowardsTarget.POSITIVE:
				num5 = feelingsSynergyBonus;
				break;
			case FeelingTowardsTarget.NEGATIVE:
				num5 = feelingsSynergyPenalty;
				break;
			}
		}
		else if (nicenessPersonalityType == NicenessPersonalityType.MEAN || (brainRef.IsAngry() && nicenessPersonalityType == NicenessPersonalityType.STANDARD))
		{
			switch (feelingTowardsTarget)
			{
			case FeelingTowardsTarget.POSITIVE:
				num5 = feelingsSynergyPenalty;
				break;
			case FeelingTowardsTarget.NEGATIVE:
				num5 = feelingsSynergyBonus;
				break;
			}
		}
		num *= num5;
		Opinion opinion = Opinion.NEUTRAL;
		if (target != null)
		{
			opinion = brainRef.GetFeelingTowardsTarget(target);
		}
		switch (opinion)
		{
		case Opinion.LIKE:
			switch (feelingTowardsTarget)
			{
			case FeelingTowardsTarget.POSITIVE:
				num *= bigFeelingsBonusNice;
				break;
			case FeelingTowardsTarget.NONE:
				num *= smallFeelingsBonusNice;
				break;
			case FeelingTowardsTarget.NEGATIVE:
				num *= bigFeelingsPenaltyNice;
				break;
			}
			break;
		case Opinion.DISLIKE:
			switch (feelingTowardsTarget)
			{
			case FeelingTowardsTarget.POSITIVE:
				num *= bigFeelingsPenaltyMean;
				break;
			case FeelingTowardsTarget.NONE:
				num *= smallFeelingsPenaltyMean;
				break;
			case FeelingTowardsTarget.NEGATIVE:
				num *= bigFeelingsBonusMean;
				break;
			}
			break;
		case Opinion.NEUTRAL:
			if (feelingTowardsTarget == FeelingTowardsTarget.NONE)
			{
				num *= smallFeelingsBonusNice;
			}
			break;
		}
		for (int i = 0; i < behavior.personalityScoreModifiers.Count; i++)
		{
			if (behavior.personalityScoreModifiers[i].DoesPersonalityGetModifier(brainRef.GetPersonality()))
			{
				num *= behavior.personalityScoreModifiers[i].scoreMultiplier;
			}
		}
		if (roomUID != num2)
		{
			float num6 = RoomPathfinder.EstimatePathDistance(roomUID, num2, constructionRef);
			if (num6 != 0f && num6 != -1f)
			{
				for (int j = 0; (float)j < num6; j++)
				{
					num *= roomSwitchCost;
				}
			}
		}
		if (boundingBoxComponent != null)
		{
			Vector3 position = faceController.GetDogHeadForIndex(0).mouthTransform.position;
			Vector3 boxCenter = boundingBoxComponent.GetBoxCenter();
			float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(MathUtil.GetPercentageOfRange(Mathf.Clamp(Vector3.Distance(position, boxCenter), minTargetDistance, maxTargetDistance), minTargetDistance, maxTargetDistance), minTargetDistanceMultiplier, maxTargetDistanceMultiplier);
			num *= valueOfRangePercentage;
		}
		num += num * brainRef.GetReinforcementMultiplierForBehaviorTargetCombo(behavior, target);
		return num / (float)behavior.GetPriority();
	}

	public void OnBehaviorStarted()
	{
		brainRef.OnBehaviorStarted();
	}

	public void OnBehaviorFinished(bool naturalFinish)
	{
		currentCommandUserIssued = false;
		indicatorRef.OnCommandFinished();
		brainRef.OnBehaviorFinished(currentBehavior);
		if (debugVis)
		{
			MonoBehaviour.print("Finishing behavior: " + currentBehavior);
		}
		if (debugLogging)
		{
			MonoBehaviour.print(string.Concat(base.gameObject, " Finishing: ", currentBehavior, " Natural: ", naturalFinish.ToString()));
		}
		currentBehavior = null;
		currentGracePeriodTimer = gracePeriodTimer;
		if (continuousFacingTarget != null)
		{
			walkController.SetFacingTarget(continuousFacingTarget);
		}
		legController.StopSimulatedWalk();
	}

	public void SetGracePeriodTimer()
	{
		currentGracePeriodTimer = gracePeriodTimer;
	}

	public bool SetCurrentBehaviorViaFixationDistraction(DogBehaviorBase newBehavior, BehaviorRole role = BehaviorRole.Actor, GameObject target = null)
	{
		return SetCurrentBehavior(newBehavior, role, target);
	}

	private void TryAddHappyParticles()
	{
		currentHappyParticleTimer += Time.deltaTime;
		if (!(currentHappyParticleTimer < happyParticleCheckRate))
		{
			currentHappyParticleTimer = 0f;
			particleControllerRef.RequestHappyUpdateParticles();
		}
	}

	private bool SetCurrentBehavior(DogBehaviorBase newBehavior, BehaviorRole role = BehaviorRole.Actor, GameObject target = null)
	{
		if (debugLogging)
		{
			MonoBehaviour.print(string.Concat(base.gameObject, " Starting: ", newBehavior, " (Target: ", target, ")"));
		}
		if (currentBehavior != null && currentBehavior.IsRunningBehavior())
		{
			currentBehavior.FinishBehavior();
		}
		if (currentGracePeriodTimer > 0f)
		{
			currentGracePeriodTimer = 0f;
		}
		currentBehavior = newBehavior;
		currentBehavior.SetRole(role);
		RoomBase roomBase = null;
		ReservableObject reservableObject = null;
		if (target != null)
		{
			if (currentBehavior.IsRoomBehavior())
			{
				roomBase = target.GetComponent<RoomBase>();
				target = null;
				SetTargetRoom(roomBase);
			}
			else if (currentBehavior.IsReserveBehavior())
			{
				reservableObject = target.GetComponent<ReservableObject>();
				target = null;
				SetTargetReservableObject(reservableObject);
			}
			else
			{
				SetTargetObject(target);
			}
		}
		currentBehavior.StartBehavior();
		if (debugVis)
		{
			MonoBehaviour.print("Starting behavior: " + currentBehavior);
		}
		return true;
	}

	private void ClearReferences()
	{
		wantedTags.Clear();
		wantedTagKeys.Clear();
		potentialBehaviors.Clear();
		potentialTargetObjects.Clear();
	}

	private void UpdateWantedTags()
	{
		for (int i = 0; i < potentialBehaviors.Count; i++)
		{
			if (!wantedTags.ContainsKey(potentialBehaviors[i]))
			{
				wantedTags[potentialBehaviors[i]] = new List<TagsEnum>();
				wantedTagKeys.Add(potentialBehaviors[i]);
			}
			else
			{
				wantedTags[potentialBehaviors[i]].Clear();
			}
			wantedTags[potentialBehaviors[i]].AddRange(potentialBehaviors[i].GetWantedTags());
		}
	}

	private void FindPotentialBehaviors(GameObject neededTarget = null, Need neededNeed = Need.None, DogBehaviorBase neededBehavior = null, FixationType neededFixationType = FixationType.NONE, bool forceInterrupt = false, bool requireReinforcement = false)
	{
		for (int i = 0; i < behaviorScripts.Count; i++)
		{
			if ((behaviorScripts[i].allowedInBreedingCenter || gameMode != GameMode.BREEDING) && (behaviorScripts[i].ghostsAllowed != GhostAllowance.NOT_ALLOWED || !brainRef.IsGhost()) && (behaviorScripts[i].ghostsAllowed != GhostAllowance.REQUIRED || brainRef.IsGhost()) && (!requireReinforcement || !(brainRef.GetReinforcementMultiplierForBehavior(behaviorScripts[i]) <= 0f)) && (behaviorScripts[i].advertise || !(neededBehavior == null)) && (!(neededTarget != null) || behaviorScripts[i].IsTargeted()) && (neededNeed == Need.None || WillBehaviorSolveForNeed(behaviorScripts[i], neededNeed)) && (currentNeedOverride == Need.None || WillBehaviorSolveForNeed(behaviorScripts[i], currentNeedOverride)) && (!(neededBehavior != null) || !(neededBehavior.name != behaviorScripts[i].name)) && (neededFixationType == FixationType.NONE || (fixationTypeBehaviorMapping.ContainsKey(neededFixationType) && fixationTypeBehaviorMapping[neededFixationType].Contains(behaviorScripts[i]))) && behaviorScripts[i].InternalStartConditionsMet() && CanBehaviorReplaceCurrent(behaviorScripts[i], neededTarget, forceInterrupt))
			{
				potentialBehaviors.Add(behaviorScripts[i]);
			}
		}
	}

	public bool WillBehaviorSolveForNeed(DogBehaviorBase behavior, Need need, bool inverse = false)
	{
		if (behavior == null)
		{
			return false;
		}
		float num = behavior.GetNeedAdvertisement(need);
		if (inverse)
		{
			num *= -1f;
		}
		return brainRef.GetNeedForType(need).DoesValueSolveForNeed(num);
	}

	public bool CanBehaviorReplaceCurrent(DogBehaviorBase behavior, GameObject target, bool forceInterrupt = false)
	{
		if (currentBehavior == null)
		{
			return true;
		}
		if (behavior == currentBehavior && target == behavior.GetTarget())
		{
			return false;
		}
		if (forceInterrupt)
		{
			return true;
		}
		if (!currentBehavior.IsRunningBehavior())
		{
			return true;
		}
		if (currentBehavior.CanBeReplaced() && GetBehaviorScore(currentBehavior, currentBehavior.GetTarget()) < GetBehaviorScore(behavior, target))
		{
			return true;
		}
		return false;
	}

	private void FindPotentialTargets(GameObject neededTarget = null)
	{
		potentialTargetObjects.Clear();
		for (int i = 0; i < wantedTagKeys.Count; i++)
		{
			if (!potentialTargetObjects.ContainsKey(wantedTagKeys[i]))
			{
				potentialTargetObjects[wantedTagKeys[i]] = new List<GameObject>();
			}
		}
		List<ReservableObject> list = new List<ReservableObject>();
		for (int j = 0; j < potentialBehaviors.Count; j++)
		{
			list.Clear();
			if (!potentialBehaviors[j].IsReserveBehavior())
			{
				continue;
			}
			Debug.LogError("Behavior reinforcement not implemented for reservable behaviors.");
			ReservableObjectType targetReservableType = potentialBehaviors[j].targetReservableType;
			if (targetReservableType == ReservableObjectType.NONE || !objRegRef.DoReservableObjectsExistForType(targetReservableType))
			{
				continue;
			}
			list = objRegRef.GetAllReservableObjectsOfType(targetReservableType);
			for (int k = 0; k < list.Count; k++)
			{
				if (!(list[k] == null) && potentialBehaviors[j].flipReservationRequirements != list[k].CanReserveObject(GetComponent<ObjectID>().GetUID()) && constructionRef.IsDogInRoomConnectedToRoom(base.gameObject, list[k].transform.root.GetComponent<BuildObjectInfo>().GetUID()))
				{
					potentialTargetObjects[potentialBehaviors[j]].Add(list[k].gameObject);
				}
			}
		}
		List<GameObject> list2 = new List<GameObject>();
		for (int l = 0; l < wantedTagKeys.Count; l++)
		{
			list2.Clear();
			for (int m = 0; m < wantedTags[wantedTagKeys[l]].Count; m++)
			{
				TagsEnum tagType = wantedTags[wantedTagKeys[l]][m];
				if (!objRegRef.DoObjectsExistForTag(tagType))
				{
					continue;
				}
				list2 = objRegRef.GetAllObjectsForTag(tagType);
				for (int n = 0; n < list2.Count; n++)
				{
					if (!(list2[n] == base.gameObject) && (!(neededTarget != null) || !(list2[n] != neededTarget)) && (wantedTagKeys[l].canTargetPlacedObjects || !(list2[n] != null) || !(list2[n].GetComponent<PlaceableObject>() != null)) && (wantedTagKeys[l].targetConditions.Count <= 0 || wantedTagKeys[l].TargetConditionsMet(list2[n])) && constructionRef.IsDogInRoomConnectedToObject(base.gameObject, list2[n]))
					{
						potentialTargetObjects[wantedTagKeys[l]].Add(list2[n]);
					}
				}
			}
		}
	}

	public void SetTargetObject(GameObject newObj)
	{
		targetObject = newObj;
		if (targetObject != null)
		{
			if (targetObject.tag == Tags.DOG)
			{
				targetObject = targetObject.GetComponent<LegController>().bodyFront;
			}
			walkController.SetFacingTarget(targetObject.transform);
		}
	}

	public void SetTargetRoom(RoomBase room)
	{
		targetRoom = room;
	}

	public void SetTargetReservableObject(ReservableObject obj)
	{
		if (targetReservableObject != null && targetReservableObject != obj)
		{
			targetReservableObject.RemoveReservation(GetComponent<ObjectID>().GetUID());
		}
		targetReservableObject = obj;
	}

	public void ClearTargetObject()
	{
		targetObject = null;
		walkController.RemoveFacingTarget();
		faceController.StopFocus();
	}

	public void ClearTargetRoom()
	{
		targetRoom = null;
	}

	public void ClearTargetReservableObject()
	{
		if (!(targetReservableObject == null))
		{
			targetReservableObject.RemoveReservation(GetComponent<ObjectID>().GetUID());
			targetReservableObject = null;
		}
	}
}
