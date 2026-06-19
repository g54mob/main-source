using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public static class TutorialController
{
	private static ulong dogID;

	private static GameObject currentPopup = null;

	private static TutorialState currentTutorialState = TutorialState.WELCOME_CONVO;

	private static bool initialEggCollected = false;

	private static bool waitingForBreedingGUIToOpen = false;

	private static bool incubatorHeld = false;

	private static bool incubatorPlaced = false;

	private static List<ulong> incubators = new List<ulong>();

	private static bool dispenserHeld = false;

	private static bool dispenserPlaced = false;

	private static List<ulong> dispensers = new List<ulong>();

	private static List<GameObject> worldArrows = new List<GameObject>();

	private static List<GameObject> foodWithArrows = new List<GameObject>();

	private static GUIManagerPens guiRef;

	private static SceneManagerBase sceneRef;

	private static ObjectRegistration regRef;

	private static DogRegistration dogRegRef;

	private static PlayerInventory inventoryRef;

	private static TutorialObjects tutorialObjectsRef;

	private static ResearchManager researchManagerRef;

	private static ConstructionManager constructionRef;

	private static Coroutine currentRoutine = null;

	public static void OnSceneChange()
	{
		StopTutorialCoroutine();
	}

	public static bool IsTutorialActive()
	{
		if (!CheatEngine.cheatRef.tutorialEnabled)
		{
			return false;
		}
		if (currentTutorialState > TutorialState.FINAL_UNLOCKS)
		{
			return false;
		}
		return true;
	}

	private static void StopTutorialCoroutine()
	{
		if (currentRoutine != null)
		{
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			if (registrationScript != null)
			{
				registrationScript.StopCoroutine(currentRoutine);
				currentRoutine = null;
			}
		}
	}

	public static void ResetTutorial()
	{
		currentTutorialState = TutorialState.WELCOME_CONVO;
		initialEggCollected = false;
		waitingForBreedingGUIToOpen = false;
		incubatorHeld = false;
		incubatorPlaced = false;
		dispenserHeld = false;
		dispenserPlaced = false;
		incubators.Clear();
		dispensers.Clear();
		worldArrows.Clear();
		foodWithArrows.Clear();
	}

	public static TutorialState GetCurrentState()
	{
		return currentTutorialState;
	}

	public static InventoryItem GetStartingSeedPacket()
	{
		return tutorialObjectsRef.startingSeedPacket;
	}

	public static bool HasInitialEggBeenCollected()
	{
		return initialEggCollected;
	}

	public static void SetInitialEggCollected(bool status)
	{
		initialEggCollected = status;
	}

	public static void ReportEggCollected()
	{
		if (!initialEggCollected)
		{
			initialEggCollected = true;
			DisplayPopUp(ScriptLocalization.Tutorial.TUT_0200_FOUNDEGG, EggPopupClosed);
		}
	}

	public static void EggPopupClosed()
	{
		waitingForBreedingGUIToOpen = true;
		DestroyCurrentPopUp();
		guiRef.SetBreedingArrowVis(val: true);
	}

	public static void OnBreedingGUIOpened()
	{
		if (waitingForBreedingGUIToOpen)
		{
			guiRef.SetBreedingArrowVis(val: false);
			waitingForBreedingGUIToOpen = false;
			DisplayPopUp(ScriptLocalization.Tutorial.TUT_0210_CROSSBREED, BreedingGUIPopupClosed, blurBG: true, stomp: false);
		}
	}

	public static void BreedingGUIPopupClosed()
	{
		DestroyCurrentPopUp();
	}

	public static void SetCurrentState(TutorialState newState)
	{
		currentTutorialState = newState;
	}

	public static void RunCurrentState()
	{
		if (CheatEngine.cheatRef.tutorialEnabled)
		{
			if (regRef == null)
			{
				regRef = ObjectRegistration.GetRegistrationScript();
			}
			if (guiRef == null)
			{
				guiRef = regRef.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
			}
			if (sceneRef == null)
			{
				sceneRef = regRef.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
			}
			if (dogRegRef == null)
			{
				dogRegRef = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
			}
			if (inventoryRef == null)
			{
				inventoryRef = regRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
			}
			if (researchManagerRef == null)
			{
				researchManagerRef = regRef.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER);
			}
			if (constructionRef == null)
			{
				constructionRef = regRef.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
			}
			if (tutorialObjectsRef == null)
			{
				tutorialObjectsRef = regRef.GetGlobalComponent<TutorialObjects>(GlobalObject.TUTORIAL, nullAllowed: true);
			}
			switch (currentTutorialState)
			{
			case TutorialState.WELCOME_CONVO:
				WelcomeConvoState();
				break;
			case TutorialState.NEW_DOG_CONVO:
				InitialDogCreation();
				break;
			case TutorialState.DOG_STORAGE_CONVO:
				DogStorageState();
				break;
			case TutorialState.DOG_STORAGE_OPEN_WAIT:
				WaitForStorageScreenOpenState();
				break;
			case TutorialState.DOG_STORAGE_CLOSE_WAIT:
				WaitForStorageScreenCloseState();
				break;
			case TutorialState.DOG_HATCH_CONVO:
				DogJustHatchedState();
				break;
			case TutorialState.DISPENSER_BUILD_PROMPT:
				DispenserBuildPromptState();
				break;
			case TutorialState.FEED_DOG_PROMPT:
				FeedPromptState();
				break;
			case TutorialState.MUTATION_CONVO:
				MutationConvoState();
				break;
			case TutorialState.MUTATION_PROMPT:
				MutationState();
				break;
			case TutorialState.MUTATION_WAIT:
				MutationWaitState();
				break;
			case TutorialState.MUTATION_FINISHED_CONVO:
				MutationFinishedState();
				break;
			case TutorialState.INCUBATOR_BUILD_PROMPT:
				IncubatorBuildPromptState();
				break;
			case TutorialState.INCUBATOR_USE_PROMPT:
				IncubatorUsePromptState();
				break;
			case TutorialState.FINAL_UNLOCKS:
				TutorialOverState();
				break;
			}
		}
	}

	public static string GetCurrentTutorialTipText()
	{
		switch (currentTutorialState)
		{
		case TutorialState.DISPENSER_BUILD_PROMPT:
			return ScriptLocalization.Tutorial.TUT_INST_0030_PLACEFOOD;
		case TutorialState.FEED_DOG_PROMPT:
			return ScriptLocalization.Tutorial.TUT_INST_0040_FEED;
		case TutorialState.MUTATION_PROMPT:
			return ScriptLocalization.Tutorial.TUT_INST_0050_PUPATE;
		case TutorialState.INCUBATOR_BUILD_PROMPT:
			return ScriptLocalization.Tutorial.TUT_INST_0010_PLACEINC;
		case TutorialState.INCUBATOR_USE_PROMPT:
			return ScriptLocalization.Tutorial.TUT_INST_0020_HATCH;
		default:
			return "";
		}
	}

	public static void AdvanceCurrentState()
	{
		DestroyCurrentPopUp();
		guiRef.DisableAllTutorialArrows();
		currentTutorialState++;
		RunCurrentState();
	}

	private static void WelcomeConvoState()
	{
		WaitForSeconds(1.5f, InitialWaitCallback);
	}

	private static void InitialWaitCallback()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0010_WELCOME, Intro2);
	}

	private static void Intro2()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0020_BASIC, Intro3);
	}

	private static void Intro3()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0030_LETSDOG, AdvanceCurrentState);
	}

	private static void InitialDogCreation()
	{
		DestroyCurrentPopUp();
		constructionRef.GetAllRooms();
		BoundingBoxComponent component = constructionRef.GetAllRooms()[0].GetComponent<BoundingBoxComponent>();
		ObjectSpawnParticles component2 = Object.Instantiate(tutorialObjectsRef.dogSpawnParticles, component.GetBoxCenter(), Quaternion.identity).GetComponent<ObjectSpawnParticles>();
		component2.SetSpawnNewDog();
		component2.SetTraitsAllowed(val: false);
		component2.SetSpawnCallback(InitialDogCreationCallback);
		component2.SetDogAge(DogAge.YOUNG_ADULT);
		if (LocalizationManager.CurrentLanguage.ToLower() == GameSettings.GetLanguageStringForLanguage(Language.ENGLISH))
		{
			component2.SetDogProfile(tutorialObjectsRef.initialDogProfile);
		}
	}

	private static void InitialDogCreationCallback(GameObject newDog)
	{
		currentRoutine = ObjectRegistration.GetRegistrationScript().StartCoroutine(OnNewDogCreatedRoutine(newDog));
	}

	private static IEnumerator OnNewDogCreatedRoutine(GameObject newDog)
	{
		newDog.GetComponent<DogIndicatorController>().DisableEntireIndicator();
		yield return new WaitForSeconds(1f);
		currentRoutine = null;
		Object.Instantiate(tutorialObjectsRef.dogNamingPopup).GetComponent<DogNameInput>().SetDogRef(dogRegRef.GetSaveableDogFromDog(newDog).dogID);
	}

	private static void IncubatorIntroPopup()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0040_FIRSTDOG, AdvanceCurrentState);
	}

	private static void IncubatorBuildPromptState()
	{
		researchManagerRef.UnlockSpecificResearch(tutorialObjectsRef.incubatorResearchable);
		guiRef.ShowObjectUnlockGUI(tutorialObjectsRef.incubatorResearchable, WaitForIncubatorBuild, 0f);
	}

	private static void WaitForIncubatorBuild()
	{
		guiRef.ShowTutorialTip(ScriptLocalization.Tutorial.TUT_INST_0010_PLACEINC);
		if (constructionRef.IsInStandardMode())
		{
			guiRef.SetPlacementArrowVis(val: true);
		}
		else if (constructionRef.IsInPlacementMode())
		{
			guiRef.SetUtilitiesArrowVis(val: true);
		}
	}

	public static void OnFoodDispensed(GameObject food)
	{
		TutorialState tutorialState = currentTutorialState;
		if (tutorialState == TutorialState.FEED_DOG_PROMPT)
		{
			foodWithArrows.Add(food);
		}
	}

	public static void OnEnterStandardMode()
	{
		switch (currentTutorialState)
		{
		case TutorialState.INCUBATOR_BUILD_PROMPT:
			guiRef.SetUtilitiesArrowVis(val: false);
			guiRef.SetPlacementArrowVis(val: true);
			guiRef.SetPlayArrowVis(val: false);
			if (incubatorPlaced)
			{
				AdvanceCurrentState();
			}
			break;
		case TutorialState.DISPENSER_BUILD_PROMPT:
			guiRef.SetUtilitiesArrowVis(val: false);
			guiRef.SetPlacementArrowVis(val: true);
			guiRef.SetPlayArrowVis(val: false);
			if (dispenserPlaced)
			{
				AdvanceCurrentState();
			}
			break;
		}
	}

	public static void OnEnterPlacementMode()
	{
		switch (currentTutorialState)
		{
		case TutorialState.INCUBATOR_BUILD_PROMPT:
			guiRef.SetPlacementArrowVis(val: false);
			break;
		case TutorialState.DISPENSER_BUILD_PROMPT:
			guiRef.SetPlacementArrowVis(val: false);
			break;
		}
	}

	public static void OnUtilitiesTabVisible()
	{
		switch (currentTutorialState)
		{
		case TutorialState.INCUBATOR_BUILD_PROMPT:
			guiRef.SetUtilitiesArrowVis(val: false);
			guiRef.SetIncubatorArrowVis(!incubatorPlaced);
			break;
		case TutorialState.DISPENSER_BUILD_PROMPT:
			guiRef.SetUtilitiesArrowVis(val: false);
			guiRef.SetFoodDispenserArrowVis(!dispenserPlaced);
			break;
		}
	}

	public static void OnUtilitiesTabHidden()
	{
		switch (currentTutorialState)
		{
		case TutorialState.INCUBATOR_BUILD_PROMPT:
			guiRef.SetIncubatorArrowVis(val: false);
			guiRef.SetUtilitiesArrowVis(!incubatorPlaced && !incubatorHeld);
			break;
		case TutorialState.DISPENSER_BUILD_PROMPT:
			guiRef.SetFoodDispenserArrowVis(val: false);
			guiRef.SetUtilitiesArrowVis(!dispenserPlaced && !dispenserHeld);
			break;
		}
	}

	private static bool IsObjectDispenser(RoomCustomizationObject objRef)
	{
		return objRef.GetName() == tutorialObjectsRef.foodDispensorResearchable.roomCustomizationObjectUnlock.GetName();
	}

	private static bool IsObjectIncubator(RoomCustomizationObject objRef)
	{
		return objRef.GetName() == tutorialObjectsRef.incubatorResearchable.roomCustomizationObjectUnlock.GetName();
	}

	public static void OnObjectPlaced(PlacedObjectInfo placementInfo)
	{
		if (tutorialObjectsRef == null)
		{
			return;
		}
		if (IsObjectIncubator(placementInfo.customizationRef))
		{
			if (!incubators.Contains(placementInfo.objectID.Value))
			{
				incubators.Add(placementInfo.objectID.Value);
			}
			incubatorPlaced = true;
		}
		else if (IsObjectDispenser(placementInfo.customizationRef))
		{
			if (!dispensers.Contains(placementInfo.objectID.Value))
			{
				dispensers.Add(placementInfo.objectID.Value);
			}
			dispenserPlaced = true;
		}
		switch (currentTutorialState)
		{
		case TutorialState.INCUBATOR_BUILD_PROMPT:
			guiRef.SetPlayArrowVis(incubatorPlaced);
			if (incubatorPlaced)
			{
				guiRef.SetUtilitiesArrowVis(val: false);
			}
			break;
		case TutorialState.DISPENSER_BUILD_PROMPT:
			guiRef.SetPlayArrowVis(dispenserPlaced);
			if (dispenserPlaced)
			{
				guiRef.SetUtilitiesArrowVis(val: false);
			}
			break;
		}
	}

	public static void OnObjectRemoved(PlacedObjectInfo placementInfo)
	{
		if (tutorialObjectsRef == null)
		{
			return;
		}
		if (IsObjectIncubator(placementInfo.customizationRef))
		{
			if (incubators.Contains(placementInfo.objectID.Value))
			{
				incubators.Remove(placementInfo.objectID.Value);
			}
			if (incubators.Count == 0)
			{
				incubatorPlaced = false;
			}
		}
		else if (IsObjectDispenser(placementInfo.customizationRef))
		{
			if (dispensers.Contains(placementInfo.objectID.Value))
			{
				dispensers.Remove(placementInfo.objectID.Value);
			}
			if (dispensers.Count == 0)
			{
				dispenserPlaced = false;
			}
		}
		switch (currentTutorialState)
		{
		case TutorialState.INCUBATOR_BUILD_PROMPT:
			guiRef.SetPlayArrowVis(incubatorPlaced);
			if (!incubatorPlaced)
			{
				guiRef.SetUtilitiesArrowVis(val: true);
			}
			break;
		case TutorialState.DISPENSER_BUILD_PROMPT:
			guiRef.SetPlayArrowVis(dispenserPlaced);
			if (!dispenserPlaced)
			{
				guiRef.SetUtilitiesArrowVis(val: true);
			}
			break;
		}
	}

	public static void OnPlacementStart(RoomCustomizationObject placedObject)
	{
		incubatorHeld = false;
		dispenserHeld = false;
		if (IsObjectDispenser(placedObject))
		{
			dispenserHeld = true;
		}
		else if (IsObjectIncubator(placedObject))
		{
			incubatorHeld = true;
		}
		switch (currentTutorialState)
		{
		case TutorialState.INCUBATOR_BUILD_PROMPT:
			guiRef.SetUtilitiesArrowVis(!incubatorHeld);
			break;
		case TutorialState.DISPENSER_BUILD_PROMPT:
			guiRef.SetUtilitiesArrowVis(!dispenserHeld);
			break;
		}
	}

	public static void OnPlacementEnd()
	{
		incubatorHeld = false;
		dispenserHeld = false;
	}

	public static void OnDogHatched()
	{
		TutorialState tutorialState = currentTutorialState;
		if (tutorialState == TutorialState.INCUBATOR_USE_PROMPT)
		{
			DestroyAllArrows();
			guiRef.HideTutorialTip();
		}
	}

	public static void OnDogNamed()
	{
		switch (currentTutorialState)
		{
		case TutorialState.NEW_DOG_CONVO:
			AdvanceCurrentState();
			break;
		case TutorialState.INCUBATOR_USE_PROMPT:
			AdvanceCurrentState();
			break;
		case TutorialState.FINAL_UNLOCKS:
			AdvanceCurrentState();
			break;
		}
	}

	public static void OnCocoonCreated()
	{
		TutorialState tutorialState = currentTutorialState;
		if (tutorialState == TutorialState.MUTATION_PROMPT)
		{
			guiRef.HideTutorialTip();
			AdvanceCurrentState();
		}
	}

	public static void OnDogMutationFinished()
	{
		TutorialState tutorialState = currentTutorialState;
		if (tutorialState == TutorialState.MUTATION_WAIT)
		{
			AdvanceCurrentState();
		}
	}

	private static void IncubatorUsePromptState()
	{
		guiRef.HideTutorialTip();
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0050_GREAT, IncubatorTipState);
		List<GameObject> allRooms = constructionRef.GetAllRooms();
		for (int i = 0; i < allRooms.Count; i++)
		{
			RoomBase component = constructionRef.GetAllRooms()[i].GetComponent<RoomBase>();
			for (int j = 0; j < incubators.Count; j++)
			{
				GameObject objectForUID = component.GetObjectForUID(incubators[j]);
				if (objectForUID != null)
				{
					GameObject gameObject = Object.Instantiate(tutorialObjectsRef.tutorialArrow3D, objectForUID.transform);
					BoundingBoxComponent component2 = objectForUID.GetComponent<BoundingBoxComponent>();
					gameObject.transform.position = component2.GetBoxCenter() + Vector3.up * (component2.GetBoxSize().y / 2f + 5f);
					worldArrows.Add(gameObject);
				}
			}
		}
	}

	private static void IncubatorTipState()
	{
		DestroyCurrentPopUp();
		guiRef.ShowTutorialTip(ScriptLocalization.Tutorial.TUT_INST_0020_HATCH);
	}

	private static void DogStorageState()
	{
		DestroyAllArrows();
		guiRef.HideTutorialTip();
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0060_CONGRATS, AdvanceCurrentState);
	}

	private static void WaitForStorageScreenOpenState()
	{
		guiRef.SetStorageArrowVis(val: true);
	}

	public static void OnDogStorageScreenOpened()
	{
		if (currentTutorialState == TutorialState.DOG_STORAGE_OPEN_WAIT)
		{
			guiRef.SetStorageArrowVis(val: false);
			DisplayPopUp(ScriptLocalization.Tutorial.TUT_0070_DOGOVERVIEW, StoragePopup2, blurBG: true, stomp: false);
		}
	}

	private static void StoragePopup2()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0080_REMOVED, AdvanceCurrentState, blurBG: true, stomp: false);
	}

	private static void WaitForStorageScreenCloseState()
	{
		guiRef.SetStorageExitArrowVis(val: true);
	}

	public static void OnDogStorageScreenClosed()
	{
		if (currentTutorialState == TutorialState.DOG_STORAGE_CLOSE_WAIT && dogRegRef.GetAllDogs().Count != 0)
		{
			AdvanceCurrentState();
		}
	}

	private static void DogJustHatchedState()
	{
		DestroyAllArrows();
		guiRef.HideTutorialTip();
		GameObject gameObject = dogRegRef.GetAllDogs()[0];
		dogID = dogRegRef.GetIDFromDog(gameObject);
		gameObject.GetComponent<DoggyBrain>().LockNeeds();
		CheatEngine.SetDogHunger((int)dogID, 0.4f, fromScript: true);
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0090_HUNGRY, AdvanceCurrentState);
	}

	private static void DispenserBuildPromptState()
	{
		researchManagerRef.UnlockSpecificResearch(tutorialObjectsRef.foodDispensorResearchable);
		guiRef.ShowObjectUnlockGUI(tutorialObjectsRef.foodDispensorResearchable, WaitForDispenserBuild, 0f);
	}

	private static void WaitForDispenserBuild()
	{
		guiRef.ShowTutorialTip(ScriptLocalization.Tutorial.TUT_INST_0030_PLACEFOOD);
		if (constructionRef.IsInStandardMode())
		{
			guiRef.SetPlacementArrowVis(val: true);
		}
		else if (constructionRef.IsInPlacementMode())
		{
			guiRef.SetUtilitiesArrowVis(val: true);
		}
	}

	private static void FeedPromptState()
	{
		List<GameObject> allRooms = constructionRef.GetAllRooms();
		for (int i = 0; i < allRooms.Count; i++)
		{
			RoomBase component = constructionRef.GetAllRooms()[i].GetComponent<RoomBase>();
			for (int j = 0; j < dispensers.Count; j++)
			{
				GameObject objectForUID = component.GetObjectForUID(dispensers[j]);
				if (objectForUID != null)
				{
					GameObject gameObject = Object.Instantiate(tutorialObjectsRef.tutorialArrow3D, objectForUID.transform);
					BoundingBoxComponent component2 = objectForUID.GetComponent<BoundingBoxComponent>();
					gameObject.transform.position = component2.GetBoxCenter() + Vector3.up * (component2.GetBoxSize().y / 2f + 5f);
					worldArrows.Add(gameObject);
				}
			}
		}
		CheatEngine.cheatRef.AIEnabled = false;
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0100_FOODCOMMAND, DisplayVerticalDraggingPopup);
	}

	private static void DisplayVerticalDraggingPopup()
	{
		CursorController globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		ControlManager globalComponent2 = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
		string tUT_0110_GRABANDDRAG = ScriptLocalization.Tutorial.TUT_0110_GRABANDDRAG;
		int length = tUT_0110_GRABANDDRAG.IndexOf('[');
		int num = tUT_0110_GRABANDDRAG.IndexOf(']');
		string currentActiveBindingForCommand = globalComponent2.GetCurrentActiveBindingForCommand(ControlCommand.DRAG_MODE_VERTICAL, globalComponent);
		tUT_0110_GRABANDDRAG = tUT_0110_GRABANDDRAG.Substring(0, length) + currentActiveBindingForCommand + tUT_0110_GRABANDDRAG.Substring(num + 1);
		DisplayPopUp(tUT_0110_GRABANDDRAG, OnCommandPopupClosed);
	}

	private static void OnCommandPopupClosed()
	{
		DestroyCurrentPopUp();
		CheatEngine.cheatRef.AIEnabled = true;
		guiRef.ShowTutorialTip(ScriptLocalization.Tutorial.TUT_INST_0040_FEED);
		currentRoutine = ObjectRegistration.GetRegistrationScript().StartCoroutine(FeedWaitRoutine());
	}

	public static bool CanTickDogBrainAge()
	{
		if (currentTutorialState < TutorialState.MUTATION_CONVO)
		{
			return false;
		}
		return true;
	}

	private static IEnumerator FeedWaitRoutine()
	{
		WaitForSeconds secondsWait = new WaitForSeconds(0.5f);
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		DoggyBrain dogBrain = null;
		while (true)
		{
			if (dogBrain == null)
			{
				GameObject dogFromID = dogRegRef.GetDogFromID(dogID);
				if (dogFromID != null)
				{
					dogBrain = dogFromID.GetComponent<DoggyBrain>();
				}
				if (dogBrain == null)
				{
					yield return secondsWait;
					continue;
				}
			}
			for (int num = foodWithArrows.Count - 1; num >= 0; num--)
			{
				if (foodWithArrows[num] == null)
				{
					foodWithArrows.RemoveAt(num);
				}
				else
				{
					foodWithArrows[num].GetComponent<ObjectIndicatorController>().EnableTutorialArrow(tutorialObjectsRef.tutorialArrowBillboard);
				}
			}
			bool active = foodWithArrows.Count == 0;
			for (int num2 = worldArrows.Count - 1; num2 >= 0; num2--)
			{
				if (worldArrows[num2] == null)
				{
					worldArrows.RemoveAt(num2);
				}
				else
				{
					worldArrows[num2].SetActive(active);
				}
			}
			if (dogBrain.GetCurrentHunger() >= 0.7f)
			{
				break;
			}
			yield return frameWait;
		}
		currentRoutine = null;
		dogBrain.UnlockNeeds();
		DestroyAllArrows();
		AdvanceCurrentState();
	}

	private static void MutationConvoState()
	{
		guiRef.HideTutorialTip();
		dogRegRef.GetDogFromID(dogID).GetComponent<DoggyBrain>().SetDogAgeProgressToCocoonable();
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0120_PUPATE, CameraControlsConvo);
	}

	private static void CameraControlsConvo()
	{
		CursorController globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		ControlManager globalComponent2 = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
		bool num = globalComponent.IsSystemMouseActive();
		string tUT_0130_MOVECAM = ScriptLocalization.Tutorial.TUT_0130_MOVECAM;
		int length = tUT_0130_MOVECAM.IndexOf('[');
		int num2 = tUT_0130_MOVECAM.IndexOf(']');
		string text = ScriptLocalization.GUI.GUI_CONTROLS_RIGHTSTICK;
		if (num)
		{
			text = ScriptLocalization.GUI.GUI_CONTROLS_RIGHTCLICK;
		}
		else if (!GameControls.isLeftStickDefault)
		{
			text = ScriptLocalization.GUI.GUI_CONTROLS_LEFTSTICK;
		}
		tUT_0130_MOVECAM = tUT_0130_MOVECAM.Substring(0, length) + text + tUT_0130_MOVECAM.Substring(num2 + 1);
		length = tUT_0130_MOVECAM.IndexOf('[');
		num2 = tUT_0130_MOVECAM.IndexOf(']');
		text = ScriptLocalization.GUI.GUI_CONTROLS_DPAD;
		if (num)
		{
			text = ScriptLocalization.GUI.GUI_CONTROLS_MIDDLECLICK;
		}
		tUT_0130_MOVECAM = tUT_0130_MOVECAM.Substring(0, length) + text + tUT_0130_MOVECAM.Substring(num2 + 1);
		length = tUT_0130_MOVECAM.IndexOf('[');
		num2 = tUT_0130_MOVECAM.IndexOf(']');
		text = ScriptLocalization.GUI.GUI_CONTROLS_SCROLLWHEEL;
		if (!num)
		{
			text = globalComponent2.GetCurrentActiveBindingForCommand(ControlCommand.ZOOM_IN, globalComponent) + " / " + globalComponent2.GetCurrentActiveBindingForCommand(ControlCommand.ZOOM_OUT, globalComponent);
		}
		tUT_0130_MOVECAM = tUT_0130_MOVECAM.Substring(0, length) + text + tUT_0130_MOVECAM.Substring(num2 + 1);
		DisplayPopUp(tUT_0130_MOVECAM, AdvanceCurrentState);
	}

	private static void MutationState()
	{
		guiRef.ShowTutorialTip(ScriptLocalization.Tutorial.TUT_INST_0050_PUPATE);
	}

	private static void MutationWaitState()
	{
	}

	private static void MutationFinishedState()
	{
		WaitForSeconds(1.5f, MutationFinishedConvo);
	}

	private static void MutationFinishedConvo()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0140_GOODPUPATION, NewEggConvo);
	}

	private static void NewEggConvo()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0150_INCUBATE, NewEggConvo2);
	}

	private static void NewEggConvo2()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0160_INCUBATEINFO, AdvanceCurrentState);
	}

	private static void TutorialOverState()
	{
		ControlManager globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
		guiRef.HideTutorialTip();
		string tUT_0170_DESTROY = ScriptLocalization.Tutorial.TUT_0170_DESTROY;
		int length = tUT_0170_DESTROY.IndexOf('[');
		int num = tUT_0170_DESTROY.IndexOf(']');
		string currentKeyboardBindingForCommand = globalComponent.GetCurrentKeyboardBindingForCommand(ControlCommand.DESTROY_HELD_OBJECT);
		tUT_0170_DESTROY = tUT_0170_DESTROY.Substring(0, length) + currentKeyboardBindingForCommand + tUT_0170_DESTROY.Substring(num + 1);
		DisplayPopUp(tUT_0170_DESTROY, SavePrompt);
	}

	private static void SavePrompt()
	{
		CursorController globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		ControlManager globalComponent2 = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
		guiRef.HideTutorialTip();
		string tUT_0180_SAVE = ScriptLocalization.Tutorial.TUT_0180_SAVE;
		int length = tUT_0180_SAVE.IndexOf('[');
		int num = tUT_0180_SAVE.IndexOf(']');
		string currentActiveBindingForCommand = globalComponent2.GetCurrentActiveBindingForCommand(ControlCommand.PAUSE, globalComponent);
		tUT_0180_SAVE = tUT_0180_SAVE.Substring(0, length) + currentActiveBindingForCommand + tUT_0180_SAVE.Substring(num + 1);
		DisplayPopUp(tUT_0180_SAVE, TutorialOverState2);
	}

	private static void TutorialOverState2()
	{
		DisplayPopUp(ScriptLocalization.Tutorial.TUT_0190_BASIC, TutorialComplete);
	}

	private static void TutorialComplete()
	{
		DestroyCurrentPopUp();
		AdvanceCurrentState();
		GoalsController.SetGoalEvent(GoalCondition.COMPLETE_TUTORIAL, 1);
	}

	private static void DisplayPopUp(string message, CoreButton.OnClickDelegate callback = null, bool blurBG = true, bool stomp = true)
	{
		string text = "";
		for (int i = 0; i < message.Length; i++)
		{
			if (message[i] == '\\' && i + 1 < message.Length && message[i + 1] == 'n')
			{
				i++;
				text += "\n";
			}
			else
			{
				text += message[i];
			}
		}
		message = text;
		bool flag = true;
		if (currentPopup == null)
		{
			flag = false;
			currentPopup = Object.Instantiate(tutorialObjectsRef.tutorialTipPopup);
			guiRef.DisableBG(LockReason.TUTORIAL);
			if (!blurBG)
			{
				guiRef.DisableBlur();
			}
		}
		TutorialPopup component = currentPopup.GetComponent<TutorialPopup>();
		component.SetMessageText(message);
		component.SetCallback(callback);
		if (!flag)
		{
			component.SetStomp(stomp);
		}
	}

	private static void DestroyCurrentPopUp()
	{
		guiRef.EnableBG(LockReason.TUTORIAL);
		if (!(currentPopup == null))
		{
			currentPopup.GetComponent<TutorialPopup>().RequestDestroy();
			currentPopup = null;
		}
	}

	private static void WaitForSeconds(float seconds, TutorialCallback callback)
	{
		currentRoutine = ObjectRegistration.GetRegistrationScript().StartCoroutine(WaitRoutine(seconds, callback));
	}

	private static IEnumerator WaitRoutine(float seconds, TutorialCallback callback)
	{
		yield return new WaitForSeconds(seconds);
		currentRoutine = null;
		callback();
	}

	private static void DestroyAllArrows()
	{
		for (int num = worldArrows.Count - 1; num >= 0; num--)
		{
			Object.Destroy(worldArrows[num]);
		}
		for (int num2 = foodWithArrows.Count - 1; num2 >= 0; num2--)
		{
			if (foodWithArrows[num2] != null)
			{
				foodWithArrows[num2].GetComponent<ObjectIndicatorController>().DisableTutorialArrow();
			}
		}
		worldArrows.Clear();
		foodWithArrows.Clear();
	}
}
