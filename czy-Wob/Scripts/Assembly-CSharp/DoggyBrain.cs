using System.Collections.Generic;
using HighlightingSystem;
using I2.Loc;
using UnityEngine;

public class DoggyBrain : MonoBehaviour
{
	public static Dictionary<DogAge, float> dogAgeToTimeDict = new Dictionary<DogAge, float>
	{
		{
			DogAge.NONE,
			0f
		},
		{
			DogAge.PUPPY,
			300f
		},
		{
			DogAge.CHILD,
			600f
		},
		{
			DogAge.TEEN,
			600f
		},
		{
			DogAge.YOUNG_ADULT,
			600f
		},
		{
			DogAge.ADULT,
			2100f
		}
	};

	public static Dictionary<CoreQuality, float> coreQualityToLifeExtensionDict = new Dictionary<CoreQuality, float>
	{
		{
			CoreQuality.LOW,
			150f
		},
		{
			CoreQuality.STANDARD,
			300f
		},
		{
			CoreQuality.HIGH,
			1200f
		}
	};

	public static float ancientMax = 10800f;

	private static Dictionary<DogAge, float> dogAgeToReinforcementWeightDict = new Dictionary<DogAge, float>
	{
		{
			DogAge.NONE,
			0f
		},
		{
			DogAge.PUPPY,
			1f
		},
		{
			DogAge.CHILD,
			1f
		},
		{
			DogAge.TEEN,
			0.85f
		},
		{
			DogAge.YOUNG_ADULT,
			0.6f
		},
		{
			DogAge.ADULT,
			0.4f
		},
		{
			DogAge.ANCIENT,
			0.25f
		}
	};

	public bool debugVis;

	public float debugViewer;

	public float debugDogAgeProgress;

	public DogAge debugDogAge = DogAge.PUPPY;

	public InventoryItem legItem;

	public InventoryItem tailItem;

	public InventoryItem bodyItem;

	public InventoryItem headItem;

	public InventoryItem wingItem;

	public InventoryItem dogCoreItem;

	public GameObject dogDeathPopParticleEffect;

	[HideInInspector]
	public static float minStressForHappiness = 0.5f;

	[HideInInspector]
	public static float minStressForBigHappiness = 0.8f;

	[HideInInspector]
	public static float maxStressForHappiness = 1f;

	[HideInInspector]
	public static float minAngerForHappiness = 0.5f;

	[HideInInspector]
	public static float minAngerForBigHappiness = 0.8f;

	[HideInInspector]
	public static float maxAngerForHappiness = 1f;

	[HideInInspector]
	public static float minEnergyForHappiness = 0.5f;

	[HideInInspector]
	public static float minEnergyForBigHappiness = 0.8f;

	[HideInInspector]
	public static float maxEnergyForHappiness = 1f;

	[HideInInspector]
	public static float minHungerForHappiness = 0.5f;

	[HideInInspector]
	public static float minHungerForBigHappiness = 0.8f;

	[HideInInspector]
	public static float maxHungerForHappiness = 1f;

	[HideInInspector]
	public static float minBoredomForHappiness = 0.5f;

	[HideInInspector]
	public static float minBoredomForBigHappiness = 0.8f;

	[HideInInspector]
	public static float maxBoredomForHappiness = 1f;

	private Hunger hunger;

	private Stress stress;

	private Energy energy;

	private Anger anger;

	private Boredom boredom;

	private DogPersonality personality;

	private float barfMax = 1f;

	private float barfMeter;

	private float barfDecayRate = 0.014f;

	private float baseChokingChance = 0.01f;

	private Dictionary<DogAge, float> ageToChokingChanceModifierDict = new Dictionary<DogAge, float>
	{
		{
			DogAge.PUPPY,
			10f
		},
		{
			DogAge.CHILD,
			5f
		},
		{
			DogAge.TEEN,
			2f
		},
		{
			DogAge.YOUNG_ADULT,
			1f
		},
		{
			DogAge.ADULT,
			0.75f
		},
		{
			DogAge.ANCIENT,
			0.75f
		}
	};

	private float hungerStressCutoff = 0.1f;

	private float hungerStressDecayRate = 0.01f;

	private float boredomFromHoldingObjectRate = 0.005f;

	private float needDistractionThreshold = 0.5f;

	private float secondaryNeedDistractionThreshold = 0.5f;

	private float criticalNeedThreshold = 0.33f;

	private float currentDogAgeProgress;

	private DogAge currentDogAge = DogAge.PUPPY;

	private bool isGhost;

	private bool hatchedFromEgg;

	private float endOfLifeModifier;

	private float endOfLifeModifierLow = -300f;

	private float endOfLifeModifierHigh = 900f;

	private float nearDeathOffset = 300f;

	private float dogLifeExtension;

	private float niceDogLikeChance = 0.75f;

	private float niceDogLikeChanceUpper = 0.9f;

	private float niceDogLikeChanceLower = 0.5f;

	private float niceDogDislikeChance;

	private float niceDogDislikeChanceUpper = 0.1f;

	private float niceDogDislikeChanceLower;

	private float standardDogLikeChance = 0.25f;

	private float standardDogLikeChanceUpper = 0.35f;

	private float standardDogLikeChanceLower;

	private float standardDogDislikeChance = 0.1f;

	private float standardDogDislikeChanceUpper = 0.2f;

	private float standardDogDislikeChanceLower;

	private float meanDogLikeChance;

	private float meanDogLikeChanceUpper = 0.1f;

	private float meanDogLikeChanceLower;

	private float meanDogDislikeChance = 0.5f;

	private float meanDogDislikeChanceUpper = 0.75f;

	private float meanDogDislikeChanceLower = 0.2f;

	private float dogDislikeInteractionAnger = -0.05f;

	private float maximumOpinionChance = 1f;

	private float minimumOpinionChance = 0.01f;

	private float maximumNumberOfWeighedOpinionInteractions = 30f;

	private Dictionary<ulong, int> dogOpinionCount = new Dictionary<ulong, int>();

	private Dictionary<ulong, Opinion> dogOpinions = new Dictionary<ulong, Opinion>();

	private List<ulong> witnesses = new List<ulong>();

	private bool deathEnabled = true;

	private bool isDead;

	private bool requiresDeath;

	private DeathReason deathReason;

	private bool hasShownNearDeathPopup;

	private bool hasShownHungerPainsPopup;

	private float currentMaxHungerTime;

	private float hungryForDeathTime = 480f;

	private float hungryForDeathWarningTime = 360f;

	private float needDistractionCheckTimer = 3f;

	private float currentNeedDistractionCheckTimer;

	private string lastValidBehaviorEnum;

	private LocalizedString lastValidReadableBehaviorName;

	private FeelingTowardsTarget lastValidBehaviorFeeling;

	private List<string> lastValidObjectProperties = new List<string>();

	private List<string> currentBehaviorCachedTargetProperties = new List<string>();

	private float timeSinceLastValidBehaviorFinished;

	private float reinforcementTimerForLastValidBehavior = 5f;

	private List<string> reusablePropertyList = new List<string>();

	private List<string> reinforcementKeyList = new List<string>();

	private Dictionary<string, float> keyToReinforcementDict = new Dictionary<string, float>();

	private float propertyLockoutTimer = 5f;

	private List<string> propertyLockouts = new List<string>();

	private List<float> propertyLockoutTimers = new List<float>();

	private float praiseReinforcementValue = 2.5f;

	private float scoldReinforcementvalue = -2.5f;

	private int maxReinforcementScore = 10;

	private float maxReinforcementMultiplier = 0.95f;

	private bool emotionParticlesLocked;

	private int currentAngrySteamParticles = -1;

	private int currentStressParticles = -1;

	private float stuckStress = -0.025f;

	private float praisedStress = 0.025f;

	private float scoldedStress = -0.05f;

	private float personalityDistractionWeight = 0.1f;

	private float reinforcementDistractionWeight = 0.1f;

	public AnimationCurve goofSleepWeightCurve;

	public AnimationCurve layaboutSleepWeightCurve;

	public AnimationCurve foodAverseHungerCurve;

	public AnimationCurve foodObsessedHungerCurve;

	public AnimationCurve standardHungerCurve;

	public AnimationCurve mischieviousBoredomCurve;

	public AnimationCurve politeBoredomCurve;

	private int potentialEggs;

	private float roomDistractionCheckRate = 3f;

	private float currentRoomDistractionTimer = 3f;

	private string deathPop = "dog_death_pop";

	private DogAI aiRef;

	private DogGut dogGutRef;

	private SleepBehavior sleepRef;

	private FaceController faceRef;

	private MouthController mouthRef;

	private DogPoopController poopRef;

	private CocoonController cocoonRef;

	private BoundingBoxComponent bbcRef;

	private DogEggLayingController eggRef;

	private DogParticleController particleRef;

	private DogIndicatorController indicatorRef;

	private List<TailController> tailControllers = new List<TailController>();

	private bool initialized;

	private bool isDisplayDog;

	private GUIManagerPens guiRef;

	private SceneManagerBase sceneRef;

	private DogRegistration dogRegRef;

	private ResearchManager researchRef;

	private ConstructionManager constructionRef;

	public void PreCreate(bool savedDog = false, bool traitsAllowed = true, SaveableDogPersonality customPersonality = null)
	{
		InitializeNeeds();
		if (CheatEngine.cheatRef != null && CheatEngine.cheatRef.forceBrainAge && !savedDog)
		{
			DebugSetDogAgeAndProgress(CheatEngine.cheatRef.debugDogAge, CheatEngine.cheatRef.debugDogAgeProgress);
		}
		if (!savedDog)
		{
			if (customPersonality != null)
			{
				personality = customPersonality.LoadPersonality();
			}
			else
			{
				personality = new DogPersonality(traitsAllowed);
			}
		}
		LockNeeds();
	}

	public bool isInitialized()
	{
		return initialized;
	}

	public void Initialize(bool permanentPlayerDog)
	{
		aiRef = GetComponent<DogAI>();
		faceRef = GetComponent<FaceController>();
		mouthRef = GetComponent<MouthController>();
		poopRef = GetComponent<DogPoopController>();
		bbcRef = GetComponent<BoundingBoxComponent>();
		eggRef = GetComponent<DogEggLayingController>();
		particleRef = GetComponent<DogParticleController>();
		indicatorRef = GetComponent<DogIndicatorController>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		sceneRef = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		researchRef = registrationScript.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER);
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		dogGutRef = GetComponent<DogGutController>().GetDogGut();
		initialized = true;
		tailControllers.AddRange(GetComponentsInChildren<TailController>());
		CheckCocoonable();
		if (permanentPlayerDog && !isGhost)
		{
			UnlockNeeds();
		}
	}

	private void Update()
	{
		if (!isDead && initialized && !isDisplayDog)
		{
			TickBrainAge();
			UpdateCurrentNeed();
			BarfCheck();
			CheckNeedDistractions();
			CheckRoomBasedDistractions();
			UpdateEmotionalVisuals();
			UpdateBehaviorReinforcementTimers();
			if (hunger.GetPercentageValue() <= hungerStressCutoff)
			{
				stress.UpdateValue((0f - hungerStressDecayRate) * Time.deltaTime);
			}
			if (mouthRef.IsCarryingObject())
			{
				boredom.UpdateValue(boredomFromHoldingObjectRate * Time.deltaTime);
			}
			if (debugVis)
			{
				UpdateDebugVars();
			}
		}
	}

	public void SetIsGhost()
	{
		isGhost = true;
		hunger.SetFrozen(val: true);
		hunger.LockNeed();
		energy.SetFrozen(val: true);
		energy.LockNeed();
	}

	public bool IsGhost()
	{
		return isGhost;
	}

	public static string GetReadableNameForDogAge(DogAge specifiedAge)
	{
		switch (specifiedAge)
		{
		case DogAge.PUPPY:
			return ScriptLocalization.GUI.GUI_AGE_PUPPY;
		case DogAge.CHILD:
			return ScriptLocalization.GUI.GUI_AGE_JUV;
		case DogAge.TEEN:
			return ScriptLocalization.GUI.GUI_AGE_TEEN;
		case DogAge.YOUNG_ADULT:
			return ScriptLocalization.GUI.GUI_AGE_YOUNGAD;
		case DogAge.ADULT:
			return ScriptLocalization.GUI.GUI_AGE_ADULT;
		case DogAge.ANCIENT:
			return ScriptLocalization.GUI.GUI_AGE_ANCIENT;
		default:
			Debug.LogError("No string found for specified age: " + specifiedAge);
			return ScriptLocalization.GUI.GUI_AGE_AGELESS;
		}
	}

	public void SetIsDisplayDog()
	{
		isDisplayDog = true;
		SetNeedsFrozen(val: true);
		LockEmotionParticles();
	}

	public bool GetIsDisplayDog()
	{
		return isDisplayDog;
	}

	public void LockNeeds()
	{
		anger.LockNeed();
		stress.LockNeed();
		hunger.LockNeed();
		energy.LockNeed();
		boredom.LockNeed();
	}

	public void UnlockNeeds()
	{
		anger.UnlockNeed();
		stress.UnlockNeed();
		hunger.UnlockNeed();
		energy.UnlockNeed();
		boredom.UnlockNeed();
	}

	public void SetNeedsFrozen(bool val)
	{
		anger.SetFrozen(val);
		stress.SetFrozen(val);
		hunger.SetFrozen(val);
		energy.SetFrozen(val);
		boredom.SetFrozen(val);
	}

	public void UpdateDebugVars()
	{
		debugDogAge = currentDogAge;
		debugDogAgeProgress = currentDogAgeProgress;
	}

	public float GetBarfMeter()
	{
		return barfMeter;
	}

	public void LoadDogAgeFromSavedDog(DogAge newAge, float newAgeProgress, float? newEndOfLifeModifier = null, float? newLifeExtension = null)
	{
		currentDogAge = newAge;
		currentDogAgeProgress = newAgeProgress;
		if (newEndOfLifeModifier.HasValue)
		{
			SetEndOfLifeModifier(newEndOfLifeModifier.Value);
		}
		if (newLifeExtension.HasValue)
		{
			SetLifeExtension(newLifeExtension.Value);
		}
		CheckCocoonable();
	}

	public void LoadBarfMeterFromSavedDog(float newVal)
	{
		barfMeter = newVal;
	}

	public bool IsDead()
	{
		return isDead;
	}

	public bool DoesDogRequireDeath()
	{
		return requiresDeath;
	}

	public DeathReason GetDeathReason()
	{
		return deathReason;
	}

	public void SetHasShownHungerPainsPopup(bool val)
	{
		hasShownHungerPainsPopup = val;
	}

	public void SetHasShownNearDeathPopup(bool val)
	{
		hasShownNearDeathPopup = val;
	}

	public bool HasDogShownNearDeathPopup()
	{
		return hasShownNearDeathPopup;
	}

	public bool HasDogShownHungerPainsPopup()
	{
		return hasShownHungerPainsPopup;
	}

	public bool IsFullyGrown()
	{
		return currentDogAge >= DogAge.ADULT;
	}

	public bool DidDogHatchFromEgg()
	{
		return hatchedFromEgg;
	}

	public void SetDogHatchedFromEgg(bool status)
	{
		hatchedFromEgg = status;
	}

	public DogAge GetCurrentDogAge()
	{
		return currentDogAge;
	}

	public float GetCurrentDogAgeProgress()
	{
		return currentDogAgeProgress;
	}

	public float GetDogAgeRatio(DogAge overrideAge = DogAge.NONE)
	{
		float num = 0f;
		float num2 = 0f;
		foreach (DogAge value in EnumUtils.GetValues<DogAge>())
		{
			if (value == DogAge.NONE)
			{
				continue;
			}
			num += 1f;
			if (overrideAge != DogAge.NONE)
			{
				if (overrideAge == value)
				{
					num2 = num;
				}
			}
			else if (currentDogAge == value)
			{
				num2 = num;
			}
		}
		return num2 / num;
	}

	private void InitializeNeeds()
	{
		anger = base.gameObject.AddComponent<Anger>();
		hunger = base.gameObject.AddComponent<Hunger>();
		stress = base.gameObject.AddComponent<Stress>();
		energy = base.gameObject.AddComponent<Energy>();
		boredom = base.gameObject.AddComponent<Boredom>();
		hunger.SetDoggyBrain(this);
		energy.SetDoggyBrain(this);
	}

	private bool ShowDeathNearPopup(string popupHeader, string popupBody, CoreButton.OnClickDelegate yesCallback, CoreButton.OnClickDelegate noCallback)
	{
		if (!GameSettings.IsDogDeathEnabled())
		{
			return true;
		}
		if (guiRef == null || !guiRef.GetGUIInteractiveStatus())
		{
			return false;
		}
		if (GameSettings.IsPassiveModeEnabled())
		{
			if (GameSettings.PassiveModeDeathNotificationOption() == GameSettings.PassiveNotificationsOption.SMALL_NOTIF)
			{
				guiRef.ShowPassiveModeNotification(popupHeader, popupBody, dogRegRef.GetDefaultThumbnailForDog(base.gameObject));
				return true;
			}
			if (GameSettings.PassiveModeDeathNotificationOption() == GameSettings.PassiveNotificationsOption.DISABLED)
			{
				return true;
			}
		}
		guiRef.RequestGenericPopup(popupHeader, popupBody, yesCallback, noCallback);
		return true;
	}

	private void MoveCameraToDog()
	{
		Camera.main.GetComponent<PenFocus>().RequestFollowCam(aiRef.GetComponent<LegController>().bodyFront.transform);
		dogRegRef.SelectDog(base.gameObject);
	}

	public void DebugSetCurrentMaxHungerTimeToRightBeforeWarning()
	{
		hunger.SetValue(0f);
		currentMaxHungerTime = hungryForDeathWarningTime - 3f;
	}

	private void UpdateCurrentNeed()
	{
		if (!PauseController.IsPaused())
		{
			energy.Decay();
			hunger.Decay();
			boredom.Decay();
		}
		anger.Decay();
		stress.Decay();
		if (hunger.GetPercentageValue() == 0f && !TutorialController.IsTutorialActive() && GameSettings.IsDogDeathEnabled())
		{
			if (GameSettings.IsPassiveModeEnabled() && !GameSettings.PassiveModeDeathByStarvation())
			{
				return;
			}
			currentMaxHungerTime += Time.deltaTime;
			if (DoesDogRequireDeath() || IsDead())
			{
				return;
			}
			if (currentMaxHungerTime >= hungryForDeathTime)
			{
				PrepareToDie(DeathReason.HUNGER);
			}
			else if (currentMaxHungerTime >= hungryForDeathWarningTime && !hasShownHungerPainsPopup)
			{
				string dogName = dogRegRef.GetSaveableDogFromDog(base.gameObject).dogName;
				string text = ScriptLocalization.GUI.GUI_POPUP_NEARDEATH_HUNGER;
				if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeDeathNotificationOption() == GameSettings.PassiveNotificationsOption.SMALL_NOTIF)
				{
					text = ScriptLocalization.GUI.GUI_POPUP_NEARDEATH_HUNGER_SHORT;
				}
				int length = text.IndexOf("[");
				int num = text.IndexOf("]");
				text = text.Substring(0, length) + dogName + text.Substring(num + 1);
				if (ShowDeathNearPopup(ScriptLocalization.GUI.GUI_POPUP_NEARDEATH_HUNGER_HEADER, text, MoveCameraToDog, null))
				{
					hasShownHungerPainsPopup = true;
				}
			}
		}
		else
		{
			currentMaxHungerTime = 0f;
			hasShownHungerPainsPopup = false;
		}
	}

	public bool CanLayEgg()
	{
		return eggRef.ReadyToLayEggs();
	}

	public bool CanLayCapsule()
	{
		if (eggRef.CanLayCapsule() && researchRef.DoesUnlockedResearchExist())
		{
			return true;
		}
		return false;
	}

	public Need GetCurrentNeed(bool closeToFailure = false)
	{
		if (IsHungry(closeToFailure))
		{
			return Need.Hunger;
		}
		if (IsTired(closeToFailure))
		{
			return Need.Energy;
		}
		if (IsAngry())
		{
			return Need.Anger;
		}
		if (IsStressed())
		{
			return Need.Stress;
		}
		if (IsBored(closeToFailure))
		{
			return Need.Boredom;
		}
		return Need.None;
	}

	public NeedBase GetNeedForType(Need need)
	{
		switch (need)
		{
		case Need.Anger:
			return anger;
		case Need.Hunger:
			return hunger;
		case Need.Stress:
			return stress;
		case Need.Energy:
			return energy;
		case Need.Boredom:
			return boredom;
		default:
			Debug.LogError(string.Concat("Invalid Need: ", need, " passed into GetNeedForType"));
			return null;
		}
	}

	public float GetCurrentNeedScore(Need need)
	{
		if (need == Need.Random)
		{
			return 0f;
		}
		return GetNeedForType(need).GetNeedScore();
	}

	public float GetPotentialNeedScore(Need need, float addedValue)
	{
		if (need == Need.Random)
		{
			return 0f;
		}
		return GetNeedForType(need).GetPotentialNeedScore(addedValue);
	}

	public float GetValueForNeed(Need need)
	{
		return GetNeedForType(need).GetValue();
	}

	public float GetPercentageValueForNeed(Need need)
	{
		return GetNeedForType(need).GetPercentageValue();
	}

	public void OnBehaviorStarted()
	{
	}

	public void OnBehaviorFinished(DogBehaviorBase behavior)
	{
	}

	private void UpdateBehaviorReinforcementTimers()
	{
		for (int num = propertyLockoutTimers.Count - 1; num >= 0; num--)
		{
			propertyLockoutTimers[num] -= Time.deltaTime;
			if (propertyLockoutTimers[num] <= 0f)
			{
				propertyLockouts.RemoveAt(num);
				propertyLockoutTimers.RemoveAt(num);
			}
		}
		if (lastValidBehaviorEnum != null)
		{
			timeSinceLastValidBehaviorFinished += Time.deltaTime;
			if (timeSinceLastValidBehaviorFinished >= reinforcementTimerForLastValidBehavior)
			{
				ClearSavedBehaviorForReinforcement();
			}
		}
	}

	public void StoreNewBehaviorTargetProperties(GameObject target)
	{
		currentBehaviorCachedTargetProperties.Clear();
		currentBehaviorCachedTargetProperties.AddRange(ObjectUtil.GetAllPropertiesForObject(target));
	}

	public void StoreBehaviorForReinforcement(DogBehaviorBase behavior)
	{
		lastValidObjectProperties.Clear();
		timeSinceLastValidBehaviorFinished = 0f;
		lastValidBehaviorFeeling = FeelingTowardsTarget.NONE;
		if (behavior == null)
		{
			return;
		}
		lastValidReadableBehaviorName = behavior.localizedName;
		if (behavior.reinforcementRetarget == DogBehaviorEnum.NONE)
		{
			lastValidBehaviorEnum = behavior.GetEnum().ToString();
		}
		else
		{
			lastValidBehaviorEnum = behavior.reinforcementRetarget.ToString();
		}
		if (behavior.IsTargeted())
		{
			lastValidBehaviorFeeling = behavior.feelingTowardsTarget;
			GameObject targetObject = aiRef.GetTargetObject();
			if (targetObject == null)
			{
				lastValidObjectProperties.AddRange(currentBehaviorCachedTargetProperties);
			}
			else
			{
				lastValidObjectProperties.AddRange(ObjectUtil.GetAllPropertiesForObject(targetObject));
			}
		}
		currentBehaviorCachedTargetProperties.Clear();
		lastValidObjectProperties.AddRange(ObjectUtil.GetAllPropertiesForObject(mouthRef.GetCarriedObject()));
	}

	public void ClearSavedBehaviorForReinforcement()
	{
		timeSinceLastValidBehaviorFinished = 0f;
		lastValidBehaviorEnum = null;
		lastValidReadableBehaviorName = null;
		lastValidObjectProperties.Clear();
	}

	private void ReinforceLastValidBehavior(float value)
	{
		DogBehaviorBase currentBehavior = aiRef.GetCurrentBehavior();
		if (currentBehavior != null && currentBehavior.IsBehaviorValidForReinforcement())
		{
			StoreBehaviorForReinforcement(aiRef.GetCurrentBehavior());
		}
		if (lastValidBehaviorEnum == null)
		{
			lastValidObjectProperties.Clear();
			lastValidObjectProperties.AddRange(ObjectUtil.GetAllPropertiesForObject(mouthRef.GetCarriedObject()));
			for (int i = 0; i < lastValidObjectProperties.Count; i++)
			{
				ReinforceProperty(lastValidObjectProperties[i], value);
			}
			lastValidObjectProperties.Clear();
			return;
		}
		ReinforceProperty(lastValidBehaviorEnum, value, lastValidReadableBehaviorName);
		if (lastValidBehaviorFeeling == FeelingTowardsTarget.NEGATIVE)
		{
			if (value > 0f)
			{
				value *= -1f;
			}
			else if (value < 0f)
			{
				return;
			}
		}
		for (int j = 0; j < lastValidObjectProperties.Count; j++)
		{
			ReinforceProperty(lastValidObjectProperties[j], value);
		}
	}

	private void ReinforceProperty(string property, float value, string customReadableName = null)
	{
		if (!propertyLockouts.Contains(property))
		{
			value *= dogAgeToReinforcementWeightDict[currentDogAge];
			if (!keyToReinforcementDict.ContainsKey(property))
			{
				reinforcementKeyList.Add(property);
				keyToReinforcementDict[property] = 0f;
			}
			float val = keyToReinforcementDict[property];
			keyToReinforcementDict[property] += value;
			if (keyToReinforcementDict[property] > (float)maxReinforcementScore)
			{
				keyToReinforcementDict[property] = maxReinforcementScore;
			}
			if (keyToReinforcementDict[property] < (float)(-maxReinforcementScore) && value < 0f)
			{
				keyToReinforcementDict[property] = -maxReinforcementScore;
			}
			float percentageOfRange = MathUtil.GetPercentageOfRange(val, -maxReinforcementScore, maxReinforcementScore);
			float percentageOfRange2 = MathUtil.GetPercentageOfRange(keyToReinforcementDict[property], -maxReinforcementScore, maxReinforcementScore);
			string property2 = customReadableName;
			if (customReadableName == null)
			{
				property2 = GetReadableNameForProperty(property);
			}
			indicatorRef.OnPropertyReinforced(property2, percentageOfRange, percentageOfRange2);
			propertyLockouts.Add(property);
			propertyLockoutTimers.Add(propertyLockoutTimer);
		}
	}

	public string GetReadableNameForProperty(string property)
	{
		switch (property)
		{
		case "FOOD":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_FOOD;
		case "DOG":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_DOG;
		case "EGG":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_EGG;
		case "CAPSULE":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_CAPSULE;
		case "TOY":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_TOY;
		case "PLANT":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_PLANT;
		case "ACCESSORY":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_ACCESSORY;
		case "COCOON":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_COCOON;
		case "PUDDLE":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_PUDDLE;
		case "POOP":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_POOP;
		case "FOOD_DISPENSOR":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_FOODDISPENSER;
		case "PHYSICS_PLANT":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_PLANT;
		case "DOG_DEN":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_DOGDEN;
		case "HOLE":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_HOLE;
		case "DIRT_CLUMP":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_DIRTCLUMP;
		case "DOG_CORE":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_DOGCORE;
		case "SEED_PACKET":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_SEEDPACKET;
		case "DEN_UPGRADE":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_DENUPGRADE;
		case "SNOWBALL":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_SNOWBALL;
		case "GIFT":
			return ScriptLocalization.BehaviorsAndCommands.PROPERTY_GIFT;
		default:
			return null;
		}
	}

	public float GetReinforcementMultiplierForBehaviorTargetCombo(DogBehaviorBase behavior, GameObject target)
	{
		if (target == null)
		{
			return GetReinforcementMultiplierForBehavior(behavior);
		}
		FeelingTowardsTarget feelings = FeelingTowardsTarget.NONE;
		if (behavior.IsTargeted())
		{
			feelings = behavior.feelingTowardsTarget;
		}
		float reinforcementMultiplierForBehavior = GetReinforcementMultiplierForBehavior(behavior);
		float reinforcementMultiplierForTarget = GetReinforcementMultiplierForTarget(target, feelings);
		return (reinforcementMultiplierForBehavior + reinforcementMultiplierForTarget) / 2f;
	}

	public float GetReinforcementMultiplierForTarget(GameObject target, FeelingTowardsTarget feelings = FeelingTowardsTarget.NONE)
	{
		reusablePropertyList.Clear();
		reusablePropertyList.AddRange(ObjectUtil.GetAllPropertiesForObject(target));
		return GetReinforcementMultiplierForPropertyList(reusablePropertyList, feelings);
	}

	public float GetReinforcementMultiplierForBehavior(DogBehaviorBase behavior)
	{
		string property = behavior.GetEnum().ToString();
		if (behavior.reinforcementRetarget != DogBehaviorEnum.NONE)
		{
			property = behavior.reinforcementRetarget.ToString();
		}
		return GetReinforcementMultiplierForProperty(property, FeelingTowardsTarget.NONE);
	}

	public float GetHighestExistingBehaviorReinforcementMultiplier()
	{
		float num = 0f;
		for (int i = 0; i < reinforcementKeyList.Count; i++)
		{
			float num2 = keyToReinforcementDict[reinforcementKeyList[i]];
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	private float GetReinforcementMultiplierForPropertyList(List<string> properties, FeelingTowardsTarget targetFeeling)
	{
		if (properties.Count == 0)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 0; i < properties.Count; i++)
		{
			num += GetReinforcementMultiplierForProperty(properties[i], targetFeeling);
		}
		return num / (float)properties.Count;
	}

	public float GetReinforcementMultiplierForProperty(string property, FeelingTowardsTarget targetFeeling)
	{
		if (!keyToReinforcementDict.ContainsKey(property))
		{
			return 0f;
		}
		float num = keyToReinforcementDict[property];
		if (num == 0f)
		{
			return 0f;
		}
		float num2 = Mathf.Abs(num) / (float)maxReinforcementScore * maxReinforcementMultiplier;
		if (targetFeeling == FeelingTowardsTarget.NEGATIVE)
		{
			num2 *= -1f;
		}
		if (num > 0f)
		{
			return num2;
		}
		return 0f - num2;
	}

	public void OnDogPraised()
	{
		ReinforceLastValidBehavior(praiseReinforcementValue);
		UpdateStress(praisedStress);
		particleRef.RequestHappyUpdateParticles();
	}

	public void OnDogScolded()
	{
		ReinforceLastValidBehavior(scoldReinforcementvalue);
		UpdateStress(scoldedStress);
		if (aiRef.GetCurrentBehavior() != null && aiRef.GetCurrentBehavior().userCancelable && !DoesDogRequireDeath())
		{
			aiRef.ForceInterruptBehavior();
		}
		mouthRef.DropObject();
	}

	public Dictionary<ulong, Opinion> GetDogOpinions()
	{
		return dogOpinions;
	}

	public Dictionary<ulong, int> GetDogOpinionsCount()
	{
		return dogOpinionCount;
	}

	public Dictionary<string, float> GetReinforcementDict()
	{
		return keyToReinforcementDict;
	}

	public void SetReinforcementDictFromSavedBrain(SerializableDictionary<string, float> reinforcement)
	{
		reinforcement.Load(keyToReinforcementDict);
		reinforcementKeyList.AddRange(keyToReinforcementDict.Keys);
	}

	public void SetDogOpinionsFromSavedBrain(SerializableDictionary<ulong, Opinion> opinions)
	{
		opinions.Load(dogOpinions);
	}

	public void SetDogOpinionsCountFromSavedBrain(SerializableDictionary<ulong, int> opinionsCount)
	{
		opinionsCount.Load(dogOpinionCount);
	}

	public bool HasInteractedWithDog(GameObject dog)
	{
		ulong iDFromDog = dogRegRef.GetIDFromDog(dog);
		if (!dogOpinions.ContainsKey(iDFromDog))
		{
			return false;
		}
		return true;
	}

	public Opinion GetFeelingTowardsTarget(GameObject target)
	{
		if (!target.transform.root.CompareTag(Tags.DOG))
		{
			return Opinion.NEUTRAL;
		}
		ulong iDFromDog = dogRegRef.GetIDFromDog(target.transform.root.gameObject);
		if (!dogOpinions.ContainsKey(iDFromDog))
		{
			return Opinion.NEUTRAL;
		}
		return dogOpinions[iDFromDog];
	}

	public void OnInteractedWithByDog(GameObject otherDog, FeelingTowardsTarget interactionType)
	{
		GenerateDogOpinion(otherDog, interactionType);
		otherDog.GetComponent<DoggyBrain>().GenerateDogOpinion(base.gameObject, FeelingTowardsTarget.NONE);
		if (GetFeelingTowardsTarget(otherDog) == Opinion.DISLIKE)
		{
			UpdateAnger(dogDislikeInteractionAnger);
		}
		else if (GetFeelingTowardsTarget(otherDog) == Opinion.LIKE && interactionType == FeelingTowardsTarget.POSITIVE)
		{
			UpdateAnger(0f - dogDislikeInteractionAnger);
		}
		if (interactionType != FeelingTowardsTarget.NEGATIVE)
		{
			return;
		}
		FixationBase currentFixation = aiRef.GetCurrentFixation();
		DogBehaviorBase currentBehavior = aiRef.GetCurrentBehavior();
		DistractionBase currentDistraction = aiRef.GetCurrentDistraction();
		GameObject gameObject = null;
		if (currentBehavior != null)
		{
			gameObject = currentBehavior.GetTarget();
		}
		if (currentBehavior != null && gameObject != null && gameObject.transform.root == otherDog)
		{
			if (currentDistraction != null && currentDistraction.IsRunningBehavior())
			{
				aiRef.OnDistractionDone(currentDistraction);
			}
			if (currentFixation != null && currentFixation.IsRunningBehavior())
			{
				aiRef.OnFixationDone();
			}
		}
	}

	public float GetOpinionOfDogReinforcementPercentage(GameObject otherDog)
	{
		ulong iDFromDog = dogRegRef.GetIDFromDog(otherDog);
		if (dogOpinions.ContainsKey(iDFromDog))
		{
			return MathUtil.GetPercentageOfRange(dogOpinionCount[iDFromDog], 1f, maximumNumberOfWeighedOpinionInteractions);
		}
		return 0f;
	}

	public void GenerateDogOpinion(GameObject otherDog, FeelingTowardsTarget associatedFeelings)
	{
		ulong iDFromDog = dogRegRef.GetIDFromDog(otherDog);
		Opinion opinion = Opinion.NEUTRAL;
		if (dogOpinions.ContainsKey(iDFromDog))
		{
			opinion = dogOpinions[iDFromDog];
			dogOpinionCount[iDFromDog]++;
			float percentageOfRange = MathUtil.GetPercentageOfRange(dogOpinionCount[iDFromDog], 1f, maximumNumberOfWeighedOpinionInteractions);
			float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(1f - percentageOfRange, minimumOpinionChance, maximumOpinionChance);
			if (Random.value > valueOfRangePercentage)
			{
				return;
			}
		}
		else
		{
			dogOpinionCount[iDFromDog] = 1;
		}
		float value = Random.value;
		Opinion opinion2 = Opinion.NEUTRAL;
		switch (personality.GetNicenessPersonalityType())
		{
		case NicenessPersonalityType.NICE:
		{
			float num5 = niceDogLikeChance;
			float num6 = niceDogDislikeChance;
			switch (associatedFeelings)
			{
			case FeelingTowardsTarget.NEGATIVE:
				num5 = niceDogLikeChanceLower;
				num6 = niceDogDislikeChanceUpper;
				break;
			case FeelingTowardsTarget.POSITIVE:
				num5 = niceDogLikeChanceUpper;
				num6 = niceDogDislikeChanceLower;
				break;
			}
			if (value < num5)
			{
				opinion2 = Opinion.LIKE;
			}
			else if (value < num6)
			{
				opinion2 = Opinion.DISLIKE;
			}
			break;
		}
		case NicenessPersonalityType.MEAN:
		{
			float num3 = meanDogLikeChance;
			float num4 = meanDogDislikeChance;
			switch (associatedFeelings)
			{
			case FeelingTowardsTarget.NEGATIVE:
				num3 = meanDogLikeChanceLower;
				num4 = meanDogDislikeChanceUpper;
				break;
			case FeelingTowardsTarget.POSITIVE:
				num3 = meanDogLikeChanceUpper;
				num4 = meanDogDislikeChanceLower;
				break;
			}
			if (value < num3)
			{
				opinion2 = Opinion.LIKE;
			}
			else if (value < num4)
			{
				opinion2 = Opinion.DISLIKE;
			}
			break;
		}
		case NicenessPersonalityType.STANDARD:
		{
			float num = standardDogLikeChance;
			float num2 = standardDogDislikeChance;
			switch (associatedFeelings)
			{
			case FeelingTowardsTarget.NEGATIVE:
				num = standardDogLikeChanceLower;
				num2 = standardDogDislikeChanceUpper;
				break;
			case FeelingTowardsTarget.POSITIVE:
				num = standardDogLikeChanceUpper;
				num2 = standardDogDislikeChanceLower;
				break;
			}
			if (value < num)
			{
				opinion2 = Opinion.LIKE;
			}
			else if (value < num2)
			{
				opinion2 = Opinion.DISLIKE;
			}
			break;
		}
		}
		if ((opinion2 == Opinion.DISLIKE && opinion == Opinion.LIKE) || (opinion2 == Opinion.LIKE && opinion == Opinion.DISLIKE))
		{
			opinion2 = Opinion.NEUTRAL;
		}
		dogOpinions[iDFromDog] = opinion2;
	}

	public void OnBellyBackCollisionStart()
	{
	}

	public void OnStuck()
	{
		UpdateStress(stuckStress * Time.deltaTime);
	}

	public void OnBiteTaken()
	{
		StoreEggBite();
		float num = baseChokingChance;
		num *= ageToChokingChanceModifierDict[currentDogAge];
		if (Random.value <= num)
		{
			ChokeOnFood();
		}
	}

	private void ChokeOnFood()
	{
		if (!TutorialController.IsTutorialActive())
		{
			float newWeight = 10f;
			DistractionChoke newDistraction = new DistractionChoke(aiRef, newWeight);
			aiRef.TryAddNewDistraction(newDistraction, useTimeSinceLastDistraction: false);
		}
	}

	public void StoreEggBite()
	{
		potentialEggs = 1;
	}

	public void ClearEggBite()
	{
		potentialEggs--;
		if (potentialEggs < 0)
		{
			potentialEggs = 0;
		}
	}

	public void ClearAllEggBites()
	{
		potentialEggs = 0;
	}

	public int GetNumberOfEggBites()
	{
		return potentialEggs;
	}

	public DogPersonality GetPersonality()
	{
		return personality;
	}

	public void SetPersonality(DogPersonality newPersonality)
	{
		personality = newPersonality;
	}

	public float GetCurrentHunger()
	{
		return hunger.GetValue();
	}

	public float GetCurrentStress()
	{
		return stress.GetValue();
	}

	public float GetCurrentEnergy()
	{
		return energy.GetValue();
	}

	public float GetCurrentAnger()
	{
		return anger.GetValue();
	}

	public float GetCurrentBoredom()
	{
		return boredom.GetValue();
	}

	public void SetHunger(float val)
	{
		hunger.SetValue(val);
	}

	public void SetStress(float val)
	{
		stress.SetValue(val);
	}

	public void SetEnergy(float val)
	{
		energy.SetValue(val);
	}

	public void SetAnger(float val)
	{
		anger.SetValue(val);
	}

	public void SetBoredom(float val)
	{
		boredom.SetValue(val);
	}

	public bool CanBarf()
	{
		if (dogGutRef != null && dogGutRef.HasEatenTooMuchDirt())
		{
			return true;
		}
		return barfMeter >= barfMax;
	}

	private void BarfCheck()
	{
		if (barfMeter > 0f)
		{
			barfMeter -= Time.deltaTime * barfDecayRate;
			if (barfMeter < 0f)
			{
				barfMeter = 0f;
			}
		}
	}

	private void IncrementBarfMeter(float incAmount)
	{
		barfMeter += incAmount;
	}

	public void OnBarf()
	{
		barfMeter = 0f;
	}

	public void UpdateNeed(Need need, float updateAmount)
	{
		GetNeedForType(need).UpdateValue(updateAmount);
		OnNeedUpdated(need, updateAmount);
	}

	public void UpdateHunger(float updateAmount)
	{
		hunger.UpdateValue(updateAmount);
		OnNeedUpdated(Need.Hunger, updateAmount);
	}

	public void UpdateStress(float updateAmount)
	{
		stress.UpdateValue(updateAmount);
		OnNeedUpdated(Need.Stress, updateAmount);
	}

	public void UpdateEnergy(float updateAmount)
	{
		energy.UpdateValue(updateAmount);
		OnNeedUpdated(Need.Energy, updateAmount);
	}

	public void UpdateAnger(float updateAmount)
	{
		anger.UpdateValue(updateAmount);
		OnNeedUpdated(Need.Anger, updateAmount);
	}

	public void UpdateBoredom(float updateAmount)
	{
		boredom.UpdateValue(updateAmount);
		OnNeedUpdated(Need.Boredom, updateAmount);
	}

	private void OnNeedUpdated(Need need, float updateAmount)
	{
		if (emotionParticlesLocked || isDead || updateAmount == 0f)
		{
			return;
		}
		if (need == Need.Hunger && updateAmount > 0f)
		{
			float value = hunger.GetValue();
			if (value + updateAmount > hunger.GetMaxValue())
			{
				float incAmount = hunger.GetMaxValue() - value + updateAmount;
				IncrementBarfMeter(incAmount);
			}
		}
		if (need == Need.Boredom && updateAmount > 0f)
		{
			particleRef.RequestHappyUpdateParticles();
		}
		else if (need != Need.Energy && need != Need.Hunger && !GetNeedForType(need).DoesValueSolveForNeed(updateAmount))
		{
			switch (need)
			{
			case Need.Stress:
				particleRef.RequestStressUpdateParticles();
				break;
			case Need.Anger:
				particleRef.RequestAngryUpdateParticles();
				break;
			}
		}
	}

	public float GetCurrentMaxHungerTime()
	{
		return currentMaxHungerTime;
	}

	public void SetCurrentMaxHungerTime(float newVal)
	{
		currentMaxHungerTime = newVal;
	}

	public void DisableDeath()
	{
		deathEnabled = false;
	}

	public void PrepareToDie(DeathReason reasonForDeath)
	{
		if (!TutorialController.IsTutorialActive() && GameSettings.IsDogDeathEnabled())
		{
			requiresDeath = true;
			deathReason = reasonForDeath;
		}
	}

	public void Die(DeathReason reason)
	{
		if (!deathEnabled || !GameSettings.IsDogDeathEnabled())
		{
			return;
		}
		PenFocus component = Camera.main.GetComponent<PenFocus>();
		bool flag = false;
		if (component.IsCameraFollowingObject(base.gameObject))
		{
			flag = true;
		}
		BoundingBoxComponent component2 = GetComponent<BoundingBoxComponent>();
		float num = 3000f;
		float num2 = 3f;
		float maxBound = component2.GetMaxBound();
		Vector3 boxCenter = component2.GetBoxCenter();
		isDead = true;
		requiresDeath = false;
		aiRef.ForceInterruptBehavior();
		aiRef.AIEnabled = false;
		ObjectGrabber globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		if (globalComponent.GetGrabbedObject() == base.gameObject)
		{
			globalComponent.DropObject();
		}
		GetComponent<DogNoises>().OnDie();
		List<GameObject> list = new List<GameObject>();
		DogGut dogGut = GetComponent<DogGutController>().GetDogGut();
		List<GutFloraResource> list2 = new List<GutFloraResource>();
		List<GutFloraResource> list3 = new List<GutFloraResource>();
		list2.AddRange(dogGut.GetAllFloraTypes(boosted: false));
		list3.AddRange(dogGut.GetAllFloraTypes(boosted: true));
		GetComponent<LegController>().OnDie(legItem, num * 2f, boxCenter, maxBound, num2, list, list2, list3, dogDeathPopParticleEffect);
		GetComponent<FaceController>().OnDie(headItem, num / 3f, boxCenter, maxBound, num2, list, list2, list3, dogDeathPopParticleEffect);
		for (int i = 0; i < tailControllers.Count; i++)
		{
			tailControllers[i].OnDie(tailItem, num / 3f, boxCenter, maxBound, num2, list, list2, list3, dogDeathPopParticleEffect);
		}
		DogLooks component3 = GetComponent<DogLooks>();
		if (component3.leftWing != null)
		{
			List<WingController> list4 = new List<WingController>();
			list4.AddRange(component3.leftWing.GetComponentsInChildren<WingController>());
			for (int j = 0; j < list4.Count; j++)
			{
				list4[j].OnDie(wingItem, num / 3f, boxCenter, maxBound, num2, list, list2, list3, dogDeathPopParticleEffect);
			}
		}
		if (component3.rightWing != null)
		{
			List<WingController> list5 = new List<WingController>();
			list5.AddRange(component3.rightWing.GetComponentsInChildren<WingController>());
			for (int k = 0; k < list5.Count; k++)
			{
				list5[k].OnDie(wingItem, num / 3f, boxCenter, maxBound, num2, list, list2, list3, dogDeathPopParticleEffect);
			}
		}
		GameObject gameObject = new GameObject("Dog Body");
		component3.bodyFront.transform.parent.SetParent(gameObject.transform);
		component3.bodyRenderer.transform.parent.SetParent(gameObject.transform);
		ObjectUtil.ConvertObjectToFood(gameObject, bodyItem, component3.bodyRenderer.GetComponent<SkinnedMeshRenderer>().material.color, canSaveLoad: true, dogCoreItem, list2, list3);
		list.Add(gameObject);
		Highlighter[] componentsInChildren = gameObject.GetComponentsInChildren<Highlighter>();
		for (int l = 0; l < componentsInChildren.Length; l++)
		{
			componentsInChildren[l].ConstantOffImmediate();
		}
		AudioController.Play(deathPop);
		DogCore dogCore = gameObject.AddComponent<DogCore>();
		dogCore.SetDog(dogRegRef.GetSaveableDogFromDog(base.gameObject));
		if ((dogCore.thumbSet == null || dogCore.thumbSet.defaultPortrait == null) && dogRegRef.GetThumbnailRef() != null)
		{
			SaveableThumbSet saveableThumbsetForDogID = dogRegRef.GetThumbnailRef().GetSaveableThumbsetForDogID(dogRegRef.GetIDFromDog(base.gameObject));
			if (saveableThumbsetForDogID != null)
			{
				dogCore.thumbSet = saveableThumbsetForDogID;
			}
		}
		component3.bodyFront.GetComponent<Rigidbody>().AddExplosionForce(num, boxCenter, maxBound, num2);
		dogRegRef.ReleaseAndRemoveDog(dogRegRef.GetSaveableDogFromDog(base.gameObject));
		for (int m = 0; m < witnesses.Count; m++)
		{
			GameObject dogFromID = dogRegRef.GetDogFromID(witnesses[m]);
			if (!(dogFromID == null))
			{
				DistractionBase currentDistraction = dogFromID.GetComponent<DogAI>().GetCurrentDistraction();
				if (currentDistraction != null && !(currentDistraction.GetType() != typeof(DistractionWitnessDeath)))
				{
					((DistractionWitnessDeath)currentDistraction)?.RegisterPartsToEat(list);
				}
			}
		}
		if (flag)
		{
			bool forceInDen = GetComponent<DogDenController>().IsInDen();
			component.RequestFollowCam(gameObject.GetComponentInChildren<Rigidbody>().transform, forceInDen);
		}
		GoalsController.ReportGoalEvent(GoalCondition.WITNESS_DEATH);
		if (reason == DeathReason.HUNGER)
		{
			GoalsController.ReportGoalEvent(GoalCondition.STARVATION_DEATH);
		}
	}

	public void RegisterWitness(ulong dogUID)
	{
		if (!witnesses.Contains(dogUID))
		{
			witnesses.Add(dogUID);
		}
	}

	public void SetTailStatesOverride(TailController.TailState newState)
	{
		for (int i = 0; i < tailControllers.Count; i++)
		{
			tailControllers[i].SetTailStateOverride(newState);
		}
	}

	public void ClearTailStatesOverride()
	{
		for (int i = 0; i < tailControllers.Count; i++)
		{
			tailControllers[i].ClearTailStateOverride();
		}
	}

	public void LockEmotionParticles()
	{
		emotionParticlesLocked = true;
	}

	public void UnlockEmotionParticles()
	{
		emotionParticlesLocked = false;
	}

	private void UpdateEmotionalVisuals()
	{
		if (emotionParticlesLocked)
		{
			RemoveExistingEmotionalParticles();
			return;
		}
		if (!IsAngry() && currentAngrySteamParticles != -1)
		{
			faceRef.SetDefaultFace(Face.DEFAULT);
			particleRef.RequestParticlesEnd(currentAngrySteamParticles);
			currentAngrySteamParticles = -1;
		}
		if (!IsStressed() && currentStressParticles != -1)
		{
			faceRef.SetDefaultFace(Face.DEFAULT);
			particleRef.RequestParticlesEnd(currentStressParticles);
			currentStressParticles = -1;
		}
		if (IsAngry())
		{
			if (currentAngrySteamParticles == -1)
			{
				RemoveExistingEmotionalParticles();
				faceRef.SetDefaultFace(Face.ANGRY);
				currentAngrySteamParticles = particleRef.RequestAngrySteamParticlesStart();
			}
		}
		else if (IsStressed() && currentStressParticles == -1)
		{
			RemoveExistingEmotionalParticles();
			faceRef.SetDefaultFace(Face.WINCE);
			currentStressParticles = particleRef.RequestStressParticlesStart();
		}
	}

	private void RemoveExistingEmotionalParticles()
	{
		if (currentAngrySteamParticles != -1)
		{
			particleRef.RequestParticlesEnd(currentAngrySteamParticles);
			currentAngrySteamParticles = -1;
		}
		if (currentStressParticles != -1)
		{
			particleRef.RequestParticlesEnd(currentStressParticles);
			currentStressParticles = -1;
		}
	}

	public bool IsSleeping()
	{
		if (sleepRef == null)
		{
			sleepRef = GetComponent<SleepBehavior>();
			if (sleepRef == null)
			{
				return false;
			}
		}
		return sleepRef.IsSleeping();
	}

	public bool IsHungry(bool closeToFailure = false)
	{
		if (closeToFailure)
		{
			return hunger.GetPercentageValue() <= criticalNeedThreshold;
		}
		return hunger.GetPercentageValue() <= needDistractionThreshold;
	}

	public bool IsTired(bool closeToFailure = false)
	{
		if (closeToFailure)
		{
			return energy.GetPercentageValue() <= criticalNeedThreshold;
		}
		return energy.GetPercentageValue() <= needDistractionThreshold;
	}

	public bool IsBored(bool closeToFailure = false)
	{
		if (closeToFailure)
		{
			return boredom.GetPercentageValue() <= criticalNeedThreshold;
		}
		return boredom.GetPercentageValue() <= needDistractionThreshold;
	}

	public bool IsStressed()
	{
		return stress.GetPercentageValue() <= secondaryNeedDistractionThreshold;
	}

	public bool IsAngry()
	{
		return anger.GetPercentageValue() <= secondaryNeedDistractionThreshold;
	}

	public bool IsHappy()
	{
		if (hunger.GetPercentageValue() < minHungerForHappiness || hunger.GetPercentageValue() > maxHungerForHappiness)
		{
			return false;
		}
		if (stress.GetPercentageValue() < minStressForHappiness || stress.GetPercentageValue() > maxStressForHappiness)
		{
			return false;
		}
		if (energy.GetPercentageValue() < minEnergyForHappiness || energy.GetPercentageValue() > maxEnergyForHappiness)
		{
			return false;
		}
		if (anger.GetPercentageValue() < minAngerForHappiness || anger.GetPercentageValue() > maxAngerForHappiness)
		{
			return false;
		}
		if (boredom.GetPercentageValue() < minBoredomForHappiness || anger.GetPercentageValue() > maxBoredomForHappiness)
		{
			return false;
		}
		return true;
	}

	public float GetHappyPercentage()
	{
		if (!IsHappy())
		{
			return 0f;
		}
		return (0f + MathUtil.GetPercentageOfRange(hunger.GetPercentageValue(), minHungerForHappiness, maxHungerForHappiness) + MathUtil.GetPercentageOfRange(energy.GetPercentageValue(), minEnergyForHappiness, maxEnergyForHappiness)) / 2f;
	}

	private void CheckRoomBasedDistractions()
	{
		currentRoomDistractionTimer += Time.deltaTime;
		if (!(currentRoomDistractionTimer < roomDistractionCheckRate))
		{
			currentRoomDistractionTimer = 0f;
			int numberOfActiveMusicPlayers = bbcRef.GetCurrentRoom().GetNumberOfActiveMusicPlayers();
			if (numberOfActiveMusicPlayers == 1)
			{
				bool shouldSway = personality.GetEnergyPersonality() == EnergyPersonalityType.LAYABOUT;
				DistractionDance newDistraction = new DistractionDance(aiRef, 1f, shouldSway);
				aiRef.TryAddNewDistraction(newDistraction);
			}
			else if (numberOfActiveMusicPlayers > 1 && personality.GetLoudnessPersonalityType() != LoudnessPersonalityType.QUIET)
			{
				DistractionBarkRandomly newDistraction2 = new DistractionBarkRandomly(aiRef, 1f, rapid: true);
				aiRef.TryAddNewDistraction(newDistraction2);
			}
		}
	}

	private void CheckNeedDistractions()
	{
		if (DoesDogRequireDeath() && !isGhost)
		{
			if (GameSettings.IsDogDeathEnabled())
			{
				float newWeight = 1f;
				DistractionDie newDistraction = new DistractionDie(aiRef, newWeight, deathReason);
				aiRef.TryAddNewDistraction(newDistraction, useTimeSinceLastDistraction: false, autoTest: true, ignoreLocks: true);
				return;
			}
			requiresDeath = false;
		}
		if (CanBarf() && !isGhost)
		{
			float newWeight2 = 1f;
			DistractionBarf newDistraction2 = new DistractionBarf(aiRef, newWeight2);
			if (aiRef.TryAddNewDistraction(newDistraction2, useTimeSinceLastDistraction: false))
			{
				return;
			}
		}
		if (poopRef.NeedsToPoop() && !isGhost)
		{
			float newWeight3 = 1f;
			DistractionPoop newDistraction3 = new DistractionPoop(aiRef, newWeight3);
			if (aiRef.TryAddNewDistraction(newDistraction3, useTimeSinceLastDistraction: false))
			{
				return;
			}
		}
		if (CanLayEgg() && !isGhost)
		{
			float newWeight4 = 1f;
			DistractionLayEggs newDistraction4 = new DistractionLayEggs(aiRef, newWeight4);
			if (aiRef.TryAddNewDistraction(newDistraction4))
			{
				return;
			}
		}
		if (currentNeedDistractionCheckTimer >= 0f)
		{
			currentNeedDistractionCheckTimer -= Time.deltaTime;
			return;
		}
		currentNeedDistractionCheckTimer = needDistractionCheckTimer;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		DogBehaviorBase currentBehavior = aiRef.GetCurrentBehavior();
		if (hunger.GetPercentageValue() < needDistractionThreshold)
		{
			flag3 = true;
			if (currentBehavior != null && aiRef.WillBehaviorSolveForNeed(currentBehavior, Need.Hunger))
			{
				return;
			}
			float time = (needDistractionThreshold - hunger.GetPercentageValue()) / needDistractionThreshold;
			DistractionNeed newDistraction5 = new DistractionNeed(newWeight: (personality.GetFoodPersonality() == FoodPersonalityType.FOOD_AVERSE) ? foodAverseHungerCurve.Evaluate(time) : ((personality.GetFoodPersonality() != FoodPersonalityType.FOOD_OBSESSED) ? standardHungerCurve.Evaluate(time) : foodObsessedHungerCurve.Evaluate(time)), newAIRef: aiRef, need: Need.Hunger);
			if (aiRef.CanTryRunDistraction(newDistraction5, useTimeSinceLastDistraction: false))
			{
				if (!aiRef.DoesNewDistractionPassRandomCheck(newDistraction5))
				{
					flag3 = false;
				}
				else if (aiRef.TryAddNewDistraction(newDistraction5, useTimeSinceLastDistraction: true, autoTest: false))
				{
					return;
				}
			}
		}
		if (IsSleeping())
		{
			return;
		}
		if (energy.GetPercentageValue() < needDistractionThreshold)
		{
			if (currentBehavior != null && aiRef.WillBehaviorSolveForNeed(currentBehavior, Need.Energy))
			{
				return;
			}
			flag2 = true;
			float num = (needDistractionThreshold - energy.GetPercentageValue()) / needDistractionThreshold;
			if (personality.GetEnergyPersonality() == EnergyPersonalityType.GOOF)
			{
				num = goofSleepWeightCurve.Evaluate(num);
			}
			else if (personality.GetEnergyPersonality() == EnergyPersonalityType.LAYABOUT)
			{
				num = layaboutSleepWeightCurve.Evaluate(num);
			}
			bool ignorePriority = false;
			if (energy.GetPercentageValue() <= 0f)
			{
				ignorePriority = true;
			}
			DistractionNeed newDistraction6 = new DistractionNeed(aiRef, num, Need.Energy);
			if (aiRef.CanTryRunDistraction(newDistraction6, useTimeSinceLastDistraction: false, ignoreLocks: false, ignorePriority))
			{
				if (!aiRef.DoesNewDistractionPassRandomCheck(newDistraction6))
				{
					flag2 = false;
				}
				else if (aiRef.TryAddNewDistraction(newDistraction6, useTimeSinceLastDistraction: true, autoTest: false))
				{
					return;
				}
			}
		}
		if (boredom.GetPercentageValue() < needDistractionThreshold)
		{
			if (currentBehavior != null && aiRef.WillBehaviorSolveForNeed(currentBehavior, Need.Boredom))
			{
				return;
			}
			flag5 = true;
			float num2 = (needDistractionThreshold - boredom.GetPercentageValue()) / needDistractionThreshold;
			if (personality.GetMischiefPersonality() == MischiefPersonalityType.MISCHEVIOUS)
			{
				num2 = mischieviousBoredomCurve.Evaluate(num2);
			}
			else if (personality.GetMischiefPersonality() == MischiefPersonalityType.POLITE)
			{
				num2 = politeBoredomCurve.Evaluate(num2);
			}
			DistractionNeed newDistraction7 = new DistractionNeed(aiRef, num2, Need.Boredom);
			if (aiRef.CanTryRunDistraction(newDistraction7))
			{
				if (!aiRef.DoesNewDistractionPassRandomCheck(newDistraction7))
				{
					flag5 = false;
				}
				else if (aiRef.TryAddNewDistraction(newDistraction7, useTimeSinceLastDistraction: true, autoTest: false))
				{
					return;
				}
			}
		}
		if (stress.GetPercentageValue() < needDistractionThreshold)
		{
			if (currentBehavior != null && aiRef.WillBehaviorSolveForNeed(currentBehavior, Need.Stress))
			{
				return;
			}
			flag4 = true;
			float newWeight5 = (needDistractionThreshold - stress.GetPercentageValue()) / needDistractionThreshold;
			DistractionNeed newDistraction8 = new DistractionNeed(aiRef, newWeight5, Need.Stress);
			if (aiRef.CanTryRunDistraction(newDistraction8) && !aiRef.DoesNewDistractionPassRandomCheck(newDistraction8))
			{
				flag4 = false;
			}
			if (aiRef.TryAddNewDistraction(newDistraction8, useTimeSinceLastDistraction: true, autoTest: false))
			{
				return;
			}
		}
		if (anger.GetPercentageValue() < needDistractionThreshold)
		{
			if (currentBehavior != null && aiRef.WillBehaviorSolveForNeed(currentBehavior, Need.Anger))
			{
				return;
			}
			flag = true;
			float newWeight6 = (needDistractionThreshold - anger.GetPercentageValue()) / needDistractionThreshold;
			DistractionNeed newDistraction9 = new DistractionNeed(aiRef, newWeight6, Need.Anger);
			if (aiRef.CanTryRunDistraction(newDistraction9) && !aiRef.DoesNewDistractionPassRandomCheck(newDistraction9))
			{
				flag = false;
			}
			if (aiRef.TryAddNewDistraction(newDistraction9, useTimeSinceLastDistraction: true, autoTest: false))
			{
				return;
			}
		}
		if ((flag3 || flag2 || flag4 || flag || flag5) && personality.GetLoudnessPersonalityType() != LoudnessPersonalityType.QUIET)
		{
			float newWeight7 = 1f;
			DistractionBark newDistraction10 = new DistractionBark(aiRef, newWeight7);
			if (aiRef.TryAddNewDistraction(newDistraction10))
			{
				return;
			}
		}
		if (CanLayCapsule() && !isGhost)
		{
			float newWeight8 = 0.5f;
			DistractionLayEggs newDistraction11 = new DistractionLayEggs(aiRef, newWeight8, layCapsule: true);
			if (aiRef.TryAddNewDistraction(newDistraction11))
			{
				return;
			}
		}
		if (personality.GetSocialPersonality() == SocialPersonalityType.ALOOF)
		{
			if (currentBehavior == null || currentBehavior.fixationType != FixationType.GET_AWAY_FROM_DOGS)
			{
				ulong? roomUID = bbcRef.GetRoomUID();
				if (roomUID.HasValue && constructionRef.GetObjectForUID(roomUID.Value).GetComponent<RoomBase>().GetNumberOfDogsInRoom() > 1)
				{
					float newWeight9 = personalityDistractionWeight;
					DistractionMoveAwayFromDogs newDistraction12 = new DistractionMoveAwayFromDogs(aiRef, newWeight9);
					if (aiRef.TryAddNewDistraction(newDistraction12))
					{
						return;
					}
				}
			}
		}
		else if (personality.GetSocialPersonality() == SocialPersonalityType.SOCIAL && (currentBehavior == null || currentBehavior.fixationType != FixationType.GET_CLOSER_TO_DOGS))
		{
			ulong? roomUID2 = bbcRef.GetRoomUID();
			if (roomUID2.HasValue && constructionRef.GetObjectForUID(roomUID2.Value).GetComponent<RoomBase>().GetNumberOfDogsInRoom() <= 1)
			{
				float newWeight10 = personalityDistractionWeight;
				DistractionMoveTowardsDogs newDistraction13 = new DistractionMoveTowardsDogs(aiRef, newWeight10);
				if (aiRef.TryAddNewDistraction(newDistraction13))
				{
					return;
				}
			}
		}
		if ((personality.GetMischiefPersonality() == MischiefPersonalityType.MISCHEVIOUS || personality.GetLoudnessPersonalityType() == LoudnessPersonalityType.LOUD) && personality.GetLoudnessPersonalityType() != LoudnessPersonalityType.QUIET && (currentBehavior == null || (currentBehavior.fixationType != FixationType.BARK_RANDOMLY && currentBehavior.fixationType != FixationType.BARK_RAPIDLY)))
		{
			float newWeight11 = personalityDistractionWeight;
			DistractionBarkRandomly newDistraction14 = new DistractionBarkRandomly(aiRef, newWeight11);
			if (aiRef.TryAddNewDistraction(newDistraction14))
			{
				return;
			}
		}
		if (currentBehavior == null)
		{
			float newWeight12 = reinforcementDistractionWeight * MathUtil.GetPercentageOfRange(GetHighestExistingBehaviorReinforcementMultiplier(), -maxReinforcementScore, maxReinforcementScore);
			DistractionReinforcement newDistraction15 = new DistractionReinforcement(aiRef, newWeight12);
			aiRef.TryAddNewDistraction(newDistraction15);
		}
	}

	private void TickBrainAge()
	{
		if (!isGhost && sceneRef.GetGameMode() == GameMode.HOME && !PauseController.IsPaused())
		{
			SetDogAgeProgress(currentDogAgeProgress + Time.deltaTime);
		}
	}

	public void DebugSetDogAgeProgress(float newProgress)
	{
		currentDogAgeProgress = newProgress;
		CheckCocoonable();
		CheckDeathFromOldAge();
	}

	public void DebugSetDogAgeAndProgress(DogAge newAge, float newProgress)
	{
		currentDogAge = newAge;
		DebugSetDogAgeProgress(newProgress);
	}

	private void SetDogAge(DogAge newAge)
	{
		currentDogAge = newAge;
		CheckCocoonable();
	}

	private void SetDogAgeProgress(float newAge)
	{
		currentDogAgeProgress = newAge;
		CheckCocoonable(canAutoCocoon: true);
		CheckDeathFromOldAge();
	}

	public bool IsReadyForCocoon()
	{
		if (isGhost)
		{
			return false;
		}
		if (currentDogAge >= DogAge.ADULT)
		{
			return false;
		}
		return currentDogAgeProgress >= dogAgeToTimeDict[currentDogAge];
	}

	public void SetDogAgeProgressToCocoonable()
	{
		currentDogAgeProgress = dogAgeToTimeDict[currentDogAge];
		CheckCocoonable();
	}

	private void CheckCocoonable(bool canAutoCocoon = false)
	{
		if (currentDogAge >= DogAge.ADULT || isDisplayDog || isGhost || (TutorialController.IsTutorialActive() && !TutorialController.CanTickDogBrainAge()))
		{
			return;
		}
		if (cocoonRef == null)
		{
			cocoonRef = GetComponent<CocoonController>();
			if (cocoonRef == null)
			{
				return;
			}
		}
		if (currentDogAgeProgress >= dogAgeToTimeDict[currentDogAge])
		{
			currentDogAgeProgress = dogAgeToTimeDict[currentDogAge];
			cocoonRef.SetReadyForCocoon();
			if (canAutoCocoon && GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoPupate() && !dogRegRef.AreDogsBeingLoaded())
			{
				cocoonRef.EnterCocoon();
			}
		}
	}

	public float GetLifeExtension()
	{
		return dogLifeExtension;
	}

	public static string GetReadableMinutesAlive(DogAge doggyAge, float dogAgeProgress)
	{
		float num = 0f;
		if (doggyAge > DogAge.PUPPY)
		{
			num += dogAgeToTimeDict[DogAge.PUPPY];
		}
		if (doggyAge > DogAge.CHILD)
		{
			num += dogAgeToTimeDict[DogAge.CHILD];
		}
		if (doggyAge > DogAge.TEEN)
		{
			num += dogAgeToTimeDict[DogAge.TEEN];
		}
		if (doggyAge > DogAge.YOUNG_ADULT)
		{
			num += dogAgeToTimeDict[DogAge.YOUNG_ADULT];
		}
		num = ((doggyAge < DogAge.ADULT) ? (num + Mathf.Min(dogAgeProgress, dogAgeToTimeDict[doggyAge])) : (num + dogAgeProgress));
		num = Mathf.Floor(num / 60f);
		string result = ScriptLocalization.GUI.GUI_STRG_MIN;
		if (num != 1f)
		{
			result = ScriptLocalization.GUI.GUI_STRG_MINS;
			int num2 = result.IndexOf("[");
			int num3 = result.IndexOf("]");
			result = result.Substring(0, num2) + result.Substring(num3 + 1);
			result = result.Insert(num2, num.ToString());
		}
		return result;
	}

	public void SetLifeExtension(float newValue)
	{
		dogLifeExtension = newValue;
	}

	public void AddLifeExtension(float addition)
	{
		dogLifeExtension += addition;
		if (addition <= 0f)
		{
			Debug.LogError("Attempting to add a life extension of: " + addition);
			return;
		}
		hasShownNearDeathPopup = false;
		if (requiresDeath && deathReason == DeathReason.OLD_AGE)
		{
			requiresDeath = false;
			deathReason = DeathReason.NONE;
		}
	}

	public float GetEndOfLifeModifier()
	{
		return endOfLifeModifier;
	}

	public void SetEndOfLifeModifier(float newValue)
	{
		endOfLifeModifier = Mathf.Clamp(newValue, endOfLifeModifierLow, endOfLifeModifierHigh);
	}

	public void GenerateEndOfLifeModifier()
	{
		endOfLifeModifier = Random.Range(endOfLifeModifierLow, endOfLifeModifierHigh);
	}

	public float GetAncientPercentage()
	{
		if (currentDogAge != DogAge.ANCIENT)
		{
			return 0f;
		}
		float num = 1f;
		float num2 = dogAgeToTimeDict[DogAge.ADULT];
		if (GameSettings.IsCustomAverageAdultDogLifespanSet())
		{
			float num3 = GameSettings.GetAverageAdultDogLifespanInMinutes() * 60;
			num = num3 / num2;
			num2 = num3;
		}
		return Mathf.Min((currentDogAgeProgress - (num2 + endOfLifeModifier * num)) / ancientMax, 1f);
	}

	private void CheckDeathFromOldAge()
	{
		if (dogRegRef == null || isDisplayDog || isGhost || currentDogAge < DogAge.ADULT || DoesDogRequireDeath() || IsDead() || !GameSettings.IsDogDeathEnabled())
		{
			return;
		}
		float num = 1f;
		float num2 = dogAgeToTimeDict[DogAge.ADULT];
		if (GameSettings.IsCustomAverageAdultDogLifespanSet())
		{
			float num3 = GameSettings.GetAverageAdultDogLifespanInMinutes() * 60;
			num = num3 / num2;
			num2 = num3;
		}
		if (currentDogAge == DogAge.ADULT && dogLifeExtension > 0f && currentDogAgeProgress > num2 + endOfLifeModifier * num)
		{
			currentDogAge = DogAge.ANCIENT;
			GetComponent<DogIndicatorController>().UpdateAge();
			SaveableDog saveableDogFromDog = dogRegRef.GetSaveableDogFromDog(base.gameObject);
			dogRegRef.SaveDog(base.gameObject, saveableDogFromDog.inWorld, saveableDogFromDog.inCocoon);
			if (GoalsController.GetCounterForCondition(GoalCondition.ANCIENT_DOG) == 0)
			{
				GoalsController.SetGoalEvent(GoalCondition.ANCIENT_DOG, 1);
			}
		}
		if (currentDogAgeProgress >= num2 + endOfLifeModifier * num + dogLifeExtension)
		{
			PrepareToDie(DeathReason.OLD_AGE);
		}
		else if (!hasShownNearDeathPopup && currentDogAgeProgress >= num2 + endOfLifeModifier * num + dogLifeExtension - nearDeathOffset)
		{
			string dogName = dogRegRef.GetSaveableDogFromDog(base.gameObject).dogName;
			string text = ScriptLocalization.GUI.GUI_POPUP_NEARDEATH_OLD;
			if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeDeathNotificationOption() == GameSettings.PassiveNotificationsOption.SMALL_NOTIF)
			{
				text = ScriptLocalization.GUI.GUI_POPUP_NEARDEATH_OLD_SHORT;
			}
			int length = text.IndexOf("[");
			int num4 = text.IndexOf("]");
			text = text.Substring(0, length) + dogName + text.Substring(num4 + 1);
			if (ShowDeathNearPopup(ScriptLocalization.GUI.GUI_POPUP_NEARDEATH_OLD_HEADER, text, MoveCameraToDog, null))
			{
				hasShownNearDeathPopup = true;
			}
		}
	}
}
