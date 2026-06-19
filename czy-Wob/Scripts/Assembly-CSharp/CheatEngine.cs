using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DevConsole;
using SickDev.CommandSystem;
using UnityEngine;

public class CheatEngine : MonoBehaviour
{
	public bool publicBuild;

	[HideInInspector]
	public static bool fishPackEnabled = true;

	[HideInInspector]
	public static bool groceryPackEnabled = true;

	[HideInInspector]
	public static bool desertPackEnabled = true;

	[HideInInspector]
	public static bool basementPackEnabled = true;

	public bool demoMode;

	public bool saveModeBreedingOverride;

	public TextAsset debugSave;

	public bool clearDataOnLoad;

	public bool startWithAllResearchUnlocked;

	public bool tutorialEnabled = true;

	public bool muteMusic;

	public float cheatTimescale = 10f;

	public bool autoTimescale;

	public bool framerateUpdateOnTimescale;

	public float speedRampTime = 0.25f;

	public bool runInBackground = true;

	private bool slowmo;

	private float slowmoTimescale = 0.25f;

	private float slowmoSpeedRamp = 0.25f;

	public bool inGameTimeEnabled = true;

	public bool forceBrainAge;

	public float debugDogAgeProgress;

	public DogAge debugDogAge = DogAge.ADULT;

	public bool enableUI = true;

	private bool previousUIValue = true;

	public bool AIEnabled = true;

	private bool previousAIValue = true;

	private Language currentLanugage = Language.ENGLISH;

	public bool randomDogGenes;

	public string defaultDogGene;

	public string defaultDomRecDogGene;

	public DogProfile defaultDogProfile;

	public SaveableDogGene defaultDogGeneFull;

	public bool manualDogGenetics;

	public CheatLooks cheatLooks;

	private bool gifMode;

	private int cheatFramerate = -1;

	private float totalTimePassed;

	private bool isSpeedRamping;

	private float previousTargetTimescale;

	private float targetTimescale;

	private int targetFramerate;

	private float targetFixedDelta;

	private float previousTimescale;

	private int previousFramerate;

	private float previousFixedDelta;

	private static int maxItemsPerCommand = 50;

	private bool resetCheatTimescale;

	private float resetCheatTimescaleTarget;

	private bool speedRampRoutineActive;

	private float originalfixedDelta;

	private string unscaledYName = "UNSCALEDTIME_Y";

	private GameObject GUIRef;

	private GUIManagerPens guiRef;

	private DogRegistration dogRegRef;

	public static CheatEngine cheatRef;

	private void Awake()
	{
		originalfixedDelta = Time.fixedDeltaTime;
		cheatRef = this;
	}

	private void Start()
	{
		if (runInBackground)
		{
			Application.runInBackground = true;
		}
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		GUIRef = registrationScript.GetGlobalObject(GlobalObject.GUI, nullAllowed: true);
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION, nullAllowed: true);
		if (dogRegRef != null)
		{
			UpdateUIStatus();
			UpdateAIEnabledStatus();
			previousAIValue = AIEnabled;
		}
		if (startWithAllResearchUnlocked)
		{
			UnlockAllResearch(fromScript: true);
		}
	}

	public void ToggleSlowmo()
	{
		slowmo = !slowmo;
		if (slowmo)
		{
			autoTimescale = true;
			framerateUpdateOnTimescale = true;
			cheatTimescale = slowmoTimescale;
			speedRampTime = slowmoSpeedRamp;
		}
		else
		{
			autoTimescale = false;
		}
	}

	public static bool CanRunCommand()
	{
		if (TutorialController.IsTutorialActive())
		{
			Console.LogError("Commands are disabled during the tutorial.");
			return false;
		}
		SceneManagerBase globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER, nullAllowed: true);
		if (globalComponent != null && globalComponent.GetGameMode() == GameMode.BREEDING)
		{
			Console.LogError("Commands are disabled during breeding.");
			return false;
		}
		return true;
	}

	[Command]
	public static void SetDogMax(int num)
	{
		if (CanRunCommand())
		{
			if (num < 1)
			{
				num = 1;
			}
			if (num > 50)
			{
				num = 50;
			}
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).UpdateDogMax(num);
		}
	}

	[Command]
	public static void UnlockAdditionalPens(int count)
	{
		if (CanRunCommand())
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME).UnlockAdditionalPens(count);
		}
	}

	[Command]
	public static void KillDog(int dogID)
	{
		if (CanRunCommand())
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID((ulong)dogID)
				.GetComponent<DoggyBrain>()
				.PrepareToDie(DeathReason.NONE);
		}
	}

	[Command]
	public static void AddUnfertilizedEggToInventory(int number = 1)
	{
		if (CanRunCommand())
		{
			number = Mathf.Min(number, maxItemsPerCommand);
			PlayerInventory playerInventory = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
			for (int i = 0; i < number; i++)
			{
				SaveableDogEgg egg = new SaveableDogEgg(null, null, fertilizedStatus: false, null, newEmptyGut: false);
				playerInventory.AddEggToInventory(egg);
			}
		}
	}

	[Command]
	public static void SendGoalEvent(string conditionString, int val = 1)
	{
		conditionString = conditionString.ToLowerInvariant();
		foreach (GoalCondition value in EnumUtils.GetValues<GoalCondition>())
		{
			if (value.ToString().ToLowerInvariant() == conditionString)
			{
				GoalsController.ReportGoalEvent(value, val);
				break;
			}
		}
	}

	[Command]
	public static void SetFoodPersonality(int dogID, string personalityName)
	{
		if (CanRunCommand())
		{
			personalityName = personalityName.ToLowerInvariant();
			DogPersonality personality = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID((ulong)dogID)
				.GetComponent<DoggyBrain>()
				.GetPersonality();
			if ("food obsessed".Contains(personalityName))
			{
				personality.SetFoodPersonality(FoodPersonalityType.FOOD_OBSESSED);
			}
			else if ("food averse".Contains(personalityName))
			{
				personality.SetFoodPersonality(FoodPersonalityType.FOOD_AVERSE);
			}
			else if ("standard".Contains(personalityName))
			{
				personality.SetFoodPersonality(FoodPersonalityType.STANDARD);
			}
		}
	}

	[Command]
	public static void SetSocialPersonality(int dogID, string personalityName)
	{
		if (CanRunCommand())
		{
			personalityName = personalityName.ToLowerInvariant();
			DogPersonality personality = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID((ulong)dogID)
				.GetComponent<DoggyBrain>()
				.GetPersonality();
			if ("social".Contains(personalityName))
			{
				personality.SetSocialPersonality(SocialPersonalityType.SOCIAL);
			}
			else if ("aloof".Contains(personalityName))
			{
				personality.SetSocialPersonality(SocialPersonalityType.ALOOF);
			}
			else if ("standard".Contains(personalityName))
			{
				personality.SetSocialPersonality(SocialPersonalityType.STANDARD);
			}
		}
	}

	[Command]
	public static void SetEnergyPersonality(int dogID, string personalityName)
	{
		if (CanRunCommand())
		{
			personalityName = personalityName.ToLowerInvariant();
			DogPersonality personality = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID((ulong)dogID)
				.GetComponent<DoggyBrain>()
				.GetPersonality();
			if ("layabout".Contains(personalityName))
			{
				personality.SetEnergyPersonality(EnergyPersonalityType.LAYABOUT);
			}
			else if ("goof".Contains(personalityName))
			{
				personality.SetEnergyPersonality(EnergyPersonalityType.GOOF);
			}
			else if ("standard".Contains(personalityName))
			{
				personality.SetEnergyPersonality(EnergyPersonalityType.STANDARD);
			}
		}
	}

	[Command]
	public static void SetMischiefPersonality(int dogID, string personalityName)
	{
		if (CanRunCommand())
		{
			personalityName = personalityName.ToLowerInvariant();
			DogPersonality personality = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID((ulong)dogID)
				.GetComponent<DoggyBrain>()
				.GetPersonality();
			if ("mischievious".Contains(personalityName))
			{
				personality.SetMischiefPersonality(MischiefPersonalityType.MISCHEVIOUS);
			}
			else if ("polite".Contains(personalityName))
			{
				personality.SetMischiefPersonality(MischiefPersonalityType.POLITE);
			}
			else if ("standard".Contains(personalityName))
			{
				personality.SetMischiefPersonality(MischiefPersonalityType.STANDARD);
			}
		}
	}

	[Command]
	public static void SetNicenessPersonality(int dogID, string personalityName)
	{
		if (CanRunCommand())
		{
			personalityName = personalityName.ToLowerInvariant();
			DogPersonality personality = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID((ulong)dogID)
				.GetComponent<DoggyBrain>()
				.GetPersonality();
			if ("nice".Contains(personalityName))
			{
				personality.SetNicenessPersonality(NicenessPersonalityType.NICE);
			}
			else if ("mean".Contains(personalityName))
			{
				personality.SetNicenessPersonality(NicenessPersonalityType.MEAN);
			}
			else if ("standard".Contains(personalityName))
			{
				personality.SetNicenessPersonality(NicenessPersonalityType.STANDARD);
			}
		}
	}

	[Command]
	public static void SetPettablePersonality(int dogID, string personalityName)
	{
		if (CanRunCommand())
		{
			personalityName = personalityName.ToLowerInvariant();
			DogPersonality personality = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID((ulong)dogID)
				.GetComponent<DoggyBrain>()
				.GetPersonality();
			if ("likes_petting".Contains(personalityName))
			{
				personality.SetPettablePersonality(PettablePersonalityType.LIKES_PETTING);
			}
			else if ("dislikes_petting".Contains(personalityName))
			{
				personality.SetPettablePersonality(PettablePersonalityType.DISLIKES_PETTING);
			}
		}
	}

	[Command]
	public static void SpawnDog(int num = 1)
	{
		if (CanRunCommand())
		{
			DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
			for (int i = 0; i < num; i++)
			{
				globalComponent.TrySpawnDog();
			}
		}
	}

	[Command]
	public static void ImportDog(string dogCode)
	{
		if (CanRunCommand())
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).TryImportDog(dogCode, null);
		}
	}

	[Command]
	public static void SpawnItem(string itemName, int num = 1)
	{
		if (!CanRunCommand())
		{
			return;
		}
		num = Mathf.Min(num, maxItemsPerCommand);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		InventoryManager globalComponent = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		InventoryItem itemByName = globalComponent.GetItemByName(itemName);
		if (!(itemByName == null) && itemByName.canSpawnThroughCheats && (itemByName.setType != ItemSet.FISH || fishPackEnabled) && (itemByName.setType != ItemSet.GROCERY || groceryPackEnabled) && (itemByName.setType != ItemSet.DESERT || desertPackEnabled) && (itemByName.setType != ItemSet.BASEMENT || basementPackEnabled))
		{
			DogHome globalComponent2 = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
			GameObject targetRoom = globalComponent2.GetTargetRoom();
			if (!(targetRoom == null))
			{
				Vector3 posForRoom = globalComponent2.GetPosForRoom(0uL, targetRoom);
				globalComponent.SpawnMultipleItems(itemByName, num, posForRoom);
			}
		}
	}

	[Command]
	public static void UnlockAllResearch(bool fromScript = false)
	{
		if (fromScript || CanRunCommand())
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER).DebugUnlockAllResearch();
		}
	}

	[Command]
	public static void SetCheatTimescale(float val, bool fromScript = false)
	{
		if (fromScript || CanRunCommand())
		{
			cheatRef.cheatTimescale = val;
		}
	}

	[Command]
	public static void AutoTimescale(bool val, bool fromScript = false)
	{
		if (fromScript || CanRunCommand())
		{
			cheatRef.autoTimescale = val;
		}
	}

	[Command]
	public static void FramerateUpdateOnTimescale(bool val, bool fromScript = false)
	{
		if (fromScript || CanRunCommand())
		{
			cheatRef.framerateUpdateOnTimescale = val;
		}
	}

	[Command]
	public static void SetSpeedRampTime(float val)
	{
		if (CanRunCommand())
		{
			cheatRef.speedRampTime = val;
		}
	}

	[Command]
	public static void ForceBrainAge(bool val, bool fromScript = false)
	{
		if (fromScript || CanRunCommand())
		{
			cheatRef.forceBrainAge = val;
		}
	}

	[Command]
	public static void SetDebugDogAge(string val)
	{
		if (!CanRunCommand())
		{
			return;
		}
		foreach (DogAge value in EnumUtils.GetValues<DogAge>())
		{
			if (value.ToString().Contains(val))
			{
				cheatRef.debugDogAge = value;
				return;
			}
		}
		Debug.LogError("No valid age found for: " + val);
	}

	[Command]
	public static void SetDebugDogAgeProgress(float val)
	{
		if (CanRunCommand())
		{
			cheatRef.debugDogAgeProgress = val;
		}
	}

	[Command]
	public static void ToggleUI(bool val, bool fromScript = false)
	{
		if (fromScript || CanRunCommand())
		{
			cheatRef.enableUI = val;
		}
	}

	[Command]
	public static void ToggleAI(bool val, bool fromScript = false)
	{
		if (fromScript || CanRunCommand())
		{
			cheatRef.AIEnabled = val;
		}
	}

	[Command]
	public static void RandomDogGenes(bool val)
	{
		if (CanRunCommand())
		{
			cheatRef.randomDogGenes = val;
		}
	}

	[Command]
	public static void SetDefaultDogGene(string val)
	{
		if (CanRunCommand())
		{
			cheatRef.defaultDogGene = val;
		}
	}

	[Command]
	public static void SetDefaultDogGeneEncoded(string val)
	{
		if (CanRunCommand())
		{
			cheatRef.defaultDogGene = MathUtil.GeneticDecode(val);
		}
	}

	[Command]
	public static void SetDefaultDomRecGene(string val)
	{
		if (CanRunCommand())
		{
			cheatRef.defaultDomRecDogGene = val;
		}
	}

	[Command]
	public static void SetDefaultDomRecGeneEncoded(string val)
	{
		if (CanRunCommand())
		{
			cheatRef.defaultDomRecDogGene = MathUtil.GeneticDecode(val);
		}
	}

	[Command]
	public static void ManualDogGenetics(bool val)
	{
		if (CanRunCommand())
		{
			cheatRef.manualDogGenetics = val;
		}
	}

	[Command]
	public static void DestroyDog(ulong dogID)
	{
		if (CanRunCommand())
		{
			Object.Destroy(GetDogFromID(dogID));
		}
	}

	[Command]
	public static void DestroyAllDogs(GameObject particles = null, bool safeDestroy = false, bool fromScript = false, bool fromTravel = false)
	{
		if (fromScript || CanRunCommand())
		{
			KillAllDogs(null, particles, safeDestroy, fromTravel);
		}
	}

	[Command]
	public static void SetDogAgeProgress(int dogID, float ageProgress)
	{
		if (CanRunCommand())
		{
			GetDogFromID((ulong)dogID).GetComponent<DoggyBrain>().DebugSetDogAgeProgress(ageProgress);
		}
	}

	[Command]
	public static void SetDogHunger(int dogID, float val, bool fromScript = false)
	{
		if (fromScript || CanRunCommand())
		{
			DoggyBrain component = GetDogFromID((ulong)dogID).GetComponent<DoggyBrain>();
			component.UpdateHunger(val - component.GetCurrentHunger());
		}
	}

	[Command]
	public static void SetDogStress(int dogID, float val)
	{
		if (CanRunCommand())
		{
			DoggyBrain component = GetDogFromID((ulong)dogID).GetComponent<DoggyBrain>();
			component.UpdateStress(val - component.GetCurrentStress());
		}
	}

	[Command]
	public static void SetDogBoredom(int dogID, float val)
	{
		if (CanRunCommand())
		{
			DoggyBrain component = GetDogFromID((ulong)dogID).GetComponent<DoggyBrain>();
			component.UpdateBoredom(val - component.GetCurrentBoredom());
		}
	}

	[Command]
	public static void SetDogAnger(int dogID, float val)
	{
		if (CanRunCommand())
		{
			DoggyBrain component = GetDogFromID((ulong)dogID).GetComponent<DoggyBrain>();
			component.UpdateAnger(val - component.GetCurrentAnger());
		}
	}

	[Command]
	public static void SetDogEnergy(int dogID, float val)
	{
		if (CanRunCommand())
		{
			DoggyBrain component = GetDogFromID((ulong)dogID).GetComponent<DoggyBrain>();
			component.UpdateEnergy(val - component.GetCurrentEnergy());
		}
	}

	public static void ResetCheatTimescale(float newTarget)
	{
		cheatRef.resetCheatTimescale = true;
		cheatRef.resetCheatTimescaleTarget = newTarget;
	}

	public static GameObject GetDogFromID(ulong dogID)
	{
		return ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID(dogID);
	}

	private void Update()
	{
		Shader.SetGlobalFloat(unscaledYName, Time.unscaledTime);
		if (!(dogRegRef == null))
		{
			HandleInput();
			if (enableUI != previousUIValue)
			{
				UpdateUIStatus();
			}
			if (AIEnabled != previousAIValue)
			{
				UpdateAIEnabledStatus();
			}
			if (isSpeedRamping)
			{
				SpeedRamp();
			}
		}
	}

	private void CheckLanguageUpdateDebug()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (currentLanugage == Language.JAPANESE)
			{
				currentLanugage = Language.ENGLISH;
			}
			else
			{
				currentLanugage++;
			}
			GameSettings.ApplyGameLanguage(currentLanugage, save: true);
		}
	}

	public void UpdateTime(int hours)
	{
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GlobalClock>(GlobalObject.GLOBAL_CLOCK).AddTimespan(new TimeSpan(0f, 0, hours));
	}

	private void UpdateBrainAges()
	{
		List<GameObject> objectsForTag = TagGrabber.GetObjectsForTag(TagsEnum.DOG);
		for (int i = 0; i < objectsForTag.Count; i++)
		{
			objectsForTag[i].GetComponent<DoggyBrain>().DebugSetDogAgeAndProgress(debugDogAge, debugDogAgeProgress);
		}
	}

	private void SpeedRamp()
	{
		float num = totalTimePassed / speedRampTime;
		float num2 = previousTimescale + (targetTimescale - previousTimescale) * num;
		if (num2 > 100f || num2 < 0f)
		{
			num2 = Mathf.Clamp(num2, 0f, 100f);
		}
		Time.timeScale = num2;
		Time.fixedDeltaTime = previousFixedDelta + (targetFixedDelta - previousFixedDelta) * num;
		Application.targetFrameRate = previousFramerate + (int)((float)(targetFramerate - previousFramerate) * num);
		if (totalTimePassed >= speedRampTime)
		{
			isSpeedRamping = false;
			Time.timeScale = targetTimescale;
			Time.fixedDeltaTime = targetFixedDelta;
			if (targetFramerate == 60)
			{
				GlobalProperties.UpdateTargetFramerate();
			}
			else
			{
				Application.targetFrameRate = targetFramerate;
			}
		}
		else
		{
			totalTimePassed += Time.deltaTime;
			if (totalTimePassed > speedRampTime)
			{
				totalTimePassed = speedRampTime;
			}
		}
	}

	private void UpdateFramerate(bool cheatMode)
	{
		cheatFramerate = (int)(60f / cheatTimescale);
		previousFixedDelta = Time.fixedDeltaTime;
		previousFramerate = Application.targetFrameRate;
		if (cheatMode)
		{
			targetFramerate = cheatFramerate - 60;
			targetFixedDelta = originalfixedDelta * (60f / (float)cheatFramerate);
		}
		else
		{
			targetFramerate = 60;
			targetFixedDelta = originalfixedDelta;
		}
	}

	private void UpdateUIStatus()
	{
		if (!(guiRef == null))
		{
			guiRef.SetUIVisibilityForPhotoMode(enableUI);
			previousUIValue = enableUI;
		}
	}

	private void UpdateAIEnabledStatus()
	{
		foreach (GameObject item in TagGrabber.GetObjectsForTag(TagsEnum.DOG))
		{
			item.GetComponent<DogAI>().SetEnabled(AIEnabled, fromCheat: true);
		}
		previousAIValue = AIEnabled;
	}

	private void HandleInput()
	{
		if (GameControls.actions.CheatConsoleKey1.IsPressed && GameControls.actions.CheatConsoleKey2.WasPressed)
		{
			Console.Open();
			return;
		}
		bool flag = false;
		if (autoTimescale || (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.T) && !publicBuild))
		{
			flag = true;
		}
		if (!speedRampRoutineActive && flag)
		{
			if (previousTargetTimescale != cheatTimescale)
			{
				if (framerateUpdateOnTimescale && cheatTimescale < 1f)
				{
					targetTimescale = cheatTimescale;
					previousTargetTimescale = cheatTimescale;
					previousTimescale = Time.timeScale;
					UpdateFramerate(cheatMode: true);
					isSpeedRamping = true;
					totalTimePassed = 0f;
				}
				else
				{
					targetTimescale = cheatTimescale;
					Time.timeScale = cheatTimescale;
				}
			}
		}
		else if (!speedRampRoutineActive && Time.timeScale == cheatTimescale && targetTimescale == cheatTimescale)
		{
			if (framerateUpdateOnTimescale && cheatTimescale < 1f)
			{
				targetTimescale = 1f;
				previousTargetTimescale = 1f;
				previousTimescale = Time.timeScale;
				UpdateFramerate(cheatMode: false);
				isSpeedRamping = true;
				totalTimePassed = 0f;
			}
			else
			{
				targetTimescale = 1f;
				Time.timeScale = 1f;
			}
		}
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.U) && !publicBuild)
		{
			enableUI = !enableUI;
		}
		if (GameControls.actions.Pause.WasPressed && !demoMode && guiRef != null && guiRef.GetCurrentMode() == GUIMode.PLAY && guiRef.GetGUIInteractiveStatus())
		{
			guiRef.ShowPauseMenu();
		}
		if (resetCheatTimescale && Time.timeScale == 1f && !flag && !speedRampRoutineActive && !isSpeedRamping)
		{
			resetCheatTimescale = false;
			framerateUpdateOnTimescale = false;
			cheatTimescale = resetCheatTimescaleTarget;
		}
	}

	public void RequestSpeedRamp(float holdTime = 2f, float waitTime = 0f)
	{
		if (!speedRampRoutineActive)
		{
			StartCoroutine(SpeedRampRoutine(holdTime, waitTime));
		}
	}

	private IEnumerator SpeedRampRoutine(float holdTime, float waitTime = 0f)
	{
		speedRampRoutineActive = true;
		CinemachineBrain camBrainRef = Camera.main.GetComponent<CinemachineBrain>();
		bool previousIgnoreTimescale = camBrainRef.m_IgnoreTimeScale;
		camBrainRef.m_IgnoreTimeScale = false;
		yield return new WaitForSeconds(waitTime);
		float previousRampTime = speedRampTime;
		float previousCheatTimescale = cheatTimescale;
		bool previousFramerateUpdate = framerateUpdateOnTimescale;
		speedRampTime = 0.1f;
		cheatTimescale = 0.1f;
		framerateUpdateOnTimescale = true;
		targetTimescale = cheatTimescale;
		previousTargetTimescale = cheatTimescale;
		previousTimescale = Time.timeScale;
		UpdateFramerate(cheatMode: true);
		isSpeedRamping = true;
		totalTimePassed = 0f;
		float time = speedRampTime + holdTime;
		yield return new WaitForSecondsRealtime(time);
		cheatTimescale = previousCheatTimescale;
		framerateUpdateOnTimescale = previousFramerateUpdate;
		targetTimescale = 1f;
		previousTargetTimescale = 1f;
		speedRampTime = previousRampTime;
		previousTimescale = Time.timeScale;
		UpdateFramerate(cheatMode: false);
		isSpeedRamping = true;
		totalTimePassed = 0f;
		speedRampRoutineActive = false;
		camBrainRef.m_IgnoreTimeScale = previousIgnoreTimescale;
	}

	public static void KillAllDogs(DogRegistration dogReg = null, GameObject particles = null, bool safeDestroy = false, bool fromTravel = false)
	{
		if (dogReg == null)
		{
			dogReg = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		}
		List<GameObject> allDogs = dogReg.GetAllDogs();
		while (allDogs.Count > 0)
		{
			if (!safeDestroy)
			{
				dogReg.SaveDog(allDogs[0], inWorld: false);
			}
			if (particles != null)
			{
				Object.Instantiate(particles, allDogs[0].GetComponent<BoundingBoxComponent>().GetBoxCenter(), Quaternion.identity);
			}
			if (safeDestroy)
			{
				DogRegistration.SafeDestroy(allDogs[0], fromTravel);
			}
			else
			{
				Object.Destroy(allDogs[0]);
			}
			allDogs.RemoveAt(0);
		}
	}
}
