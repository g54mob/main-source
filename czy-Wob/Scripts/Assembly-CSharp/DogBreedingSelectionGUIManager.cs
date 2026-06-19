using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogBreedingSelectionGUIManager : MonoBehaviour
{
	public GameObject dogBoxPrefab;

	public Transform dogBoxesHolder;

	public CursorUpdateArea updateAreaRef;

	public GameObject globalInputBlocker;

	public TextMeshProUGUI loadingDogTextA;

	public TextMeshProUGUI loadingDogTextB;

	public Transform dogRotationTransformA;

	public Transform dogRotationTransformB;

	public ObjectRotationArea dogARotArea;

	public ObjectRotationArea dogBRotArea;

	public TextMeshProUGUI activeDogNameA;

	public TextMeshProUGUI activeDogNameB;

	public TextScaleInOnLoad dogNameScaleEffectA;

	public TextScaleInOnLoad dogNameScaleEffectB;

	public InchwormBounce dogBouncerA;

	public InchwormBounce dogBouncerB;

	public Transform consoleCommandHolder;

	public GameObject consoleCommandPrefab;

	public CoreScrollbarUnityGUI consoleScrollbar;

	public GameObject dogSelectionButtonA;

	public GameObject dogSelectionButtonB;

	public GameObject clearDogSelectionButtonA;

	public GameObject clearDogSelectionButtonB;

	public TMP_InputField searchFilter;

	public GameObject applySearchFilterButton;

	public GameObject clearSearchFilterButton;

	private string currentSearchString = "";

	private string currentSearchStringInvariant = "";

	public List<GameObject> dogBoxesFades = new List<GameObject>();

	public List<DogStorageTab> allFilterTabs = new List<DogStorageTab>();

	public Image dogCircleA;

	public Image dogCircleB;

	public Color defaultDogCircleColor = Color.white;

	public Color selectedDogCircleColor;

	public TextMeshProUGUI fertilizedEggsText;

	public Color validEggNumberColor = Color.white;

	public Color invalidEggNumberColor;

	public CoreButtonUnityGUI breedButtonRef;

	public TextMeshProUGUI breedButtonText;

	public List<Image> breedButtonArrowImages;

	public Color enabledBreedButtonTextColor = Color.white;

	public Color disabledBreedButtonTextColor;

	public GameObject breedingConfirmationPopup;

	private bool GUIClosed;

	private bool travelInitiated;

	private Coroutine enableButtonRoutine;

	private int eggCount;

	private bool isLoadingDogA;

	private bool isLoadingDogB;

	private bool needsDogARefresh;

	private bool needsDogBRefresh;

	private GameObject currentlyRotatedDogA;

	private GameObject currentlyRotatedDogB;

	private SaveableDog selectedDogA;

	private SaveableDog selectedDogB;

	private DogStorageBox selectedBoxA;

	private DogStorageBox selectedBoxB;

	private SelectedDogArea selectedDogArea;

	private List<GameObject> instantiatedDogBoxes = new List<GameObject>();

	private List<DogLabelType> activeTabTypes = new List<DogLabelType>();

	private string storageFilterOnSound = "breedingSelectionMenu_filterOn";

	private string storageFilterOffSound = "breedingSelectionMenu_filterOff";

	private string menuOpenSound = "breedingSelectionMenu_open";

	private string menuCloseSound = "breedingSelectionMenu_close";

	private string breedButtonSound = "breedingSelectionMenu_breedButton";

	private string clickToSelectSound = "breedingSelectionMenu_selectionStart";

	private string selectionASound = "breedingSelectionMenu_selectionA";

	private string selectionBSound = "breedingSelectionMenu_selectionB";

	private string textPrintoutSound = "breedingSelectionMenu_consoleText";

	private string promptCancelSound = "breedingSelectionMenu_breedingPromptCancel";

	private string promptConfirmSound = "breedingSelectionMenu_breedingPromptConfirm";

	private string clearDogSound = "breedingSelectionMenu_clearDog";

	private string buttonUnlockedSound = "breedingSelectionMenu_buttonUnlocked";

	private string selectDogSound = "storage_selectDog";

	private string spacingString = "\n";

	private string welcomeString_4 = "";

	private Coroutine currentConsoleRoutine;

	private List<string> consoleQueueStrings = new List<string>();

	private List<float> consoleQueueDelays = new List<float>();

	private DogRegistration dogRegRef;

	private InventoryManager inventoryRef;

	public void OnGUIOpened()
	{
		travelInitiated = false;
		SFXOverlord.LockInWorldSFX(LockReason.DOG_BREEDING_SELECTION_GUI);
		Initialize();
		AudioController.Play(menuOpenSound);
		TutorialController.OnBreedingGUIOpened();
	}

	private void OnGUI()
	{
		consoleScrollbar.value = 0f;
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !TutorialController.IsTutorialActive() && !travelInitiated)
		{
			if (!breedingConfirmationPopup.activeSelf)
			{
				CloseGUI();
				return;
			}
			OnCancelBreedButtonPressed();
		}
		if (currentConsoleRoutine == null && consoleQueueStrings.Count > 0)
		{
			ProcessNextConsoleCommand();
		}
	}

	private void OnDestroy()
	{
		GUIClosed = true;
		AudioController.Play(menuCloseSound);
		SFXOverlord.UnlockInWorldSFX(LockReason.DOG_BREEDING_SELECTION_GUI);
	}

	public void CloseGUI()
	{
		GUIClosed = true;
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI).OnDogBreedingSelectionGUIClosed();
	}

	public void OnDogASelectionButtonPressed(bool playAudio = true)
	{
		if (playAudio)
		{
			AudioController.Play(clickToSelectSound);
		}
		if (selectedDogArea == SelectedDogArea.B && selectedDogB == null)
		{
			dogSelectionButtonB.SetActive(value: true);
			loadingDogTextB.gameObject.SetActive(value: true);
			loadingDogTextB.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		}
		selectedDogArea = SelectedDogArea.A;
		dogSelectionButtonA.SetActive(value: false);
		loadingDogTextA.gameObject.SetActive(value: true);
		loadingDogTextA.text = ScriptLocalization.GUI.GUI_BOX_SELECTDOG;
		dogCircleA.color = selectedDogCircleColor;
		dogCircleB.color = defaultDogCircleColor;
		SetDogBoxHolderEnabled(val: true);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_SELECTA);
	}

	public void OnDogBSelectionButtonPressed(bool playAudio = true)
	{
		if (playAudio)
		{
			AudioController.Play(clickToSelectSound);
		}
		if (selectedDogArea == SelectedDogArea.A && selectedDogA == null)
		{
			dogSelectionButtonA.SetActive(value: true);
			loadingDogTextA.gameObject.SetActive(value: true);
			loadingDogTextA.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		}
		selectedDogArea = SelectedDogArea.B;
		dogSelectionButtonB.SetActive(value: false);
		loadingDogTextB.gameObject.SetActive(value: true);
		loadingDogTextB.text = ScriptLocalization.GUI.GUI_BOX_SELECTDOG;
		dogCircleA.color = defaultDogCircleColor;
		dogCircleB.color = selectedDogCircleColor;
		SetDogBoxHolderEnabled(val: true);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_SELECTB);
	}

	public void WriteNoEggsError()
	{
		WriteConsoleCommand(spacingString);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_ERROREGGS);
		WriteConsoleCommand(spacingString);
	}

	public void OnBreedButtonPressed()
	{
		if (eggCount <= 0)
		{
			WriteNoEggsError();
			return;
		}
		breedingConfirmationPopup.SetActive(value: true);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_REQUESTSEQUENCE);
		AudioController.Play(breedButtonSound);
	}

	public void OnConfirmBreedButtonPressed()
	{
		if (selectedDogA == null || selectedDogB == null)
		{
			Debug.LogError("Missing valid saveable dogs!");
			return;
		}
		travelInitiated = true;
		AudioController.Play(promptConfirmSound);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_CONFIRMREQUEST);
		inventoryRef.playerInventory.RemoveUnfertilizedEggFromInventory();
		globalInputBlocker.SetActive(value: true);
		SFXOverlord.UnlockInWorldSFX(LockReason.DOG_BREEDING_SELECTION_GUI);
		SceneManagerBase globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		if (selectedDogA != null && selectedDogA.inWorld && !selectedDogA.inCocoon)
		{
			dogRegRef.SaveDog(dogRegRef.GetDogFromID(selectedDogA.dogID), inWorld: true);
			selectedDogA = dogRegRef.GetSaveableDogFromID(selectedDogA.dogID);
		}
		if (selectedDogB != null && selectedDogB.inWorld && !selectedDogB.inCocoon)
		{
			dogRegRef.SaveDog(dogRegRef.GetDogFromID(selectedDogB.dogID), inWorld: true);
			selectedDogB = dogRegRef.GetSaveableDogFromID(selectedDogB.dogID);
		}
		StartCoroutine(globalComponent.GoToBreedingCenter(selectedDogA, selectedDogB, BreedingCenterTravelSaveCallback));
	}

	private void BreedingCenterTravelSaveCallback(bool saveResult)
	{
		if (!saveResult)
		{
			travelInitiated = false;
			AudioController.Play(promptCancelSound);
			WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_ERRORSAVE);
			breedingConfirmationPopup.SetActive(value: false);
			SaveableDogEgg egg = new SaveableDogEgg(null, null, fertilizedStatus: false, null, newEmptyGut: false);
			inventoryRef.playerInventory.AddEggToInventory(egg);
			globalInputBlocker.SetActive(value: false);
		}
	}

	public void OnCancelBreedButtonPressed()
	{
		AudioController.Play(promptCancelSound);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_WITHDRAWREQUEST);
		breedingConfirmationPopup.SetActive(value: false);
	}

	public void ClearDogSelectionA()
	{
		AudioController.Play(clearDogSound);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_CLEARA);
		DeselectBox(selectedBoxA, SelectedDogArea.A);
		selectedDogA = null;
		selectedBoxA = null;
		dogSelectionButtonA.SetActive(value: true);
		clearDogSelectionButtonA.SetActive(value: false);
		if (currentlyRotatedDogA != null)
		{
			Object.Destroy(currentlyRotatedDogA);
			currentlyRotatedDogA = null;
		}
		if (selectedDogArea == SelectedDogArea.B && selectedDogB == null)
		{
			dogSelectionButtonB.SetActive(value: true);
			loadingDogTextB.gameObject.SetActive(value: true);
			loadingDogTextB.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		}
		dogCircleA.color = defaultDogCircleColor;
		OnDogASelectionButtonPressed(playAudio: false);
		UpdateBreedButtonStatus();
		dogARotArea.SetMouseInputAllowed(val: false);
	}

	public void ClearDogSelectionB()
	{
		AudioController.Play(clearDogSound);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_CLEARB);
		DeselectBox(selectedBoxB, SelectedDogArea.B);
		selectedDogB = null;
		selectedBoxB = null;
		dogSelectionButtonB.SetActive(value: true);
		clearDogSelectionButtonB.SetActive(value: false);
		if (currentlyRotatedDogB != null)
		{
			Object.Destroy(currentlyRotatedDogB);
			currentlyRotatedDogB = null;
		}
		if (selectedDogArea == SelectedDogArea.A && selectedDogA == null)
		{
			dogSelectionButtonA.SetActive(value: true);
			loadingDogTextA.gameObject.SetActive(value: true);
			loadingDogTextA.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		}
		dogCircleB.color = defaultDogCircleColor;
		OnDogBSelectionButtonPressed(playAudio: false);
		UpdateBreedButtonStatus();
		dogBRotArea.SetMouseInputAllowed(val: false);
	}

	private void DestroyBoxForDogID(ulong dogUID)
	{
		for (int num = instantiatedDogBoxes.Count - 1; num >= 0; num--)
		{
			if (instantiatedDogBoxes[num].GetComponent<DogStorageBox>().associatedDogID == dogUID)
			{
				Object.Destroy(instantiatedDogBoxes[num]);
				instantiatedDogBoxes.RemoveAt(num);
				break;
			}
		}
	}

	public void OnStorageTabSelected(DogLabelType selectedType)
	{
		if (!activeTabTypes.Contains(selectedType))
		{
			AudioController.Play(storageFilterOnSound);
			activeTabTypes.Add(selectedType);
			RefreshUI();
			WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_FILTERADD);
		}
	}

	public void OnStorageTabDeselected(DogLabelType deselctedType)
	{
		if (activeTabTypes.Contains(deselctedType))
		{
			AudioController.Play(storageFilterOffSound);
			activeTabTypes.Remove(deselctedType);
			RefreshUI();
			WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_FILTERREMOVE);
		}
	}

	private void Initialize()
	{
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		inventoryRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		for (int i = 0; i < allFilterTabs.Count; i++)
		{
			allFilterTabs[i].SetBreedingRef(this);
		}
		activeDogNameA.text = "";
		activeDogNameB.text = "";
		loadingDogTextA.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		loadingDogTextB.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		applySearchFilterButton.SetActive(value: true);
		clearSearchFilterButton.SetActive(value: false);
		dogCircleA.color = defaultDogCircleColor;
		dogCircleB.color = defaultDogCircleColor;
		clearDogSelectionButtonA.SetActive(value: false);
		clearDogSelectionButtonB.SetActive(value: false);
		dogARotArea.SetMouseInputAllowed(val: false);
		dogBRotArea.SetMouseInputAllowed(val: false);
		eggCount = inventoryRef.GetNumberOfHeldEggs(fertilized: false);
		fertilizedEggsText.text = eggCount.ToString();
		if (eggCount > 0)
		{
			fertilizedEggsText.color = validEggNumberColor;
		}
		else
		{
			fertilizedEggsText.color = invalidEggNumberColor;
		}
		RefreshUI();
		SetBreedButtonEnabled(val: false);
		SetDogBoxHolderEnabled(val: false);
		globalInputBlocker.SetActive(value: false);
		breedingConfirmationPopup.SetActive(value: false);
		float delay = 0.5f;
		float delay2 = 0.5f;
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_WELCOME_0010, delay);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_WELCOME_0020, delay2);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_WELCOME_0030, delay2);
		WriteConsoleCommand(welcomeString_4, delay2);
		if (eggCount <= 0)
		{
			WriteNoEggsError();
		}
	}

	private void RefreshUI()
	{
		PopulateBoxes();
	}

	private void PopulateBoxes()
	{
		selectedBoxA = null;
		selectedBoxB = null;
		for (int num = instantiatedDogBoxes.Count - 1; num >= 0; num--)
		{
			Object.Destroy(instantiatedDogBoxes[num]);
		}
		instantiatedDogBoxes.Clear();
		int num2 = 0;
		List<SaveableDog> allOwnedDogs = dogRegRef.GetAllOwnedDogs();
		List<SaveableDog> list = new List<SaveableDog>();
		List<string> list2 = new List<string>();
		List<SaveableDog> list3 = new List<SaveableDog>();
		for (int i = 0; i < allOwnedDogs.Count; i++)
		{
			if (allOwnedDogs[i].brain.dogAge >= DogAge.ADULT && !allOwnedDogs[i].inCocoon && !allOwnedDogs[i].brain.isDead)
			{
				list.Add(allOwnedDogs[i]);
				continue;
			}
			list3.Add(allOwnedDogs[i]);
			if (allOwnedDogs[i].brain.isDead)
			{
				list2.Add(ScriptLocalization.GUI.GUI_BOX_DEAD);
			}
			else if (allOwnedDogs[i].brain.dogAge < DogAge.ADULT)
			{
				list2.Add(ScriptLocalization.GUI.GUI_BOX_NOTOLD);
			}
			else if (allOwnedDogs[i].inCocoon)
			{
				list2.Add(ScriptLocalization.GUI.GUI_BOX_COCOON);
			}
			else
			{
				list2.Add("");
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			AddDogBox(list[j], isValid: true, num2);
			num2++;
		}
		for (int k = 0; k < list3.Count; k++)
		{
			AddDogBox(list3[k], isValid: false, num2, list2[k]);
			num2++;
		}
	}

	public void OnSearchFilterApplied()
	{
		if (searchFilter.text.Length != 0)
		{
			currentSearchString = searchFilter.text.ToLower();
			currentSearchStringInvariant = searchFilter.text.ToLowerInvariant();
			clearSearchFilterButton.SetActive(value: true);
			RefreshUI();
		}
	}

	public void OnSearchFilterCleared()
	{
		currentSearchString = "";
		currentSearchStringInvariant = "";
		searchFilter.SetTextWithoutNotify("");
		clearSearchFilterButton.SetActive(value: false);
		RefreshUI();
	}

	private bool DoesDogPassFilters(SaveableDog dog)
	{
		DogLabelType dogLabelType = dog.labelType;
		if (dogLabelType == DogLabelType.NONE && dog.favorite)
		{
			dogLabelType = DogLabelType.STAR;
		}
		if (activeTabTypes.Count > 0 && !activeTabTypes.Contains(dogLabelType))
		{
			return false;
		}
		if (currentSearchString.Length > 0)
		{
			string text = dog.dogName.ToLower();
			string text2 = dog.dogName.ToLowerInvariant();
			if (!text.Contains(currentSearchString) && !text2.Contains(currentSearchString) && !text.Contains(currentSearchStringInvariant) && !text2.Contains(currentSearchStringInvariant))
			{
				return false;
			}
		}
		return true;
	}

	private void AddDogBox(SaveableDog dog, bool isValid, int workingIndex, string invalidReason = "")
	{
		bool flag = false;
		bool flag2 = false;
		if (selectedDogA != null && selectedDogA.dogID == dog.dogID)
		{
			flag = true;
		}
		else if (selectedDogB != null && selectedDogB.dogID == dog.dogID)
		{
			flag2 = true;
		}
		if (DoesDogPassFilters(dog) || flag || flag2)
		{
			GameObject gameObject = Object.Instantiate(dogBoxPrefab);
			instantiatedDogBoxes.Add(gameObject);
			gameObject.transform.SetParent(dogBoxesHolder);
			gameObject.transform.localScale = Vector3.one;
			DogStorageBox component = gameObject.GetComponent<DogStorageBox>();
			component.SetDog(dog.dogID, dogRegRef, null, updateAreaRef, workingIndex, this);
			if (flag)
			{
				selectedBoxA = component;
				component.SetBoxChosen(ScriptLocalization.GUI.GUI_BOX_SELECTED);
			}
			else if (flag2)
			{
				selectedBoxB = component;
				component.SetBoxChosen(ScriptLocalization.GUI.GUI_BOX_SELECTED);
			}
			if (!isValid)
			{
				gameObject.GetComponent<DogStorageBox>().SetLocked(invalidReason);
			}
		}
	}

	public void SelectBox(DogStorageBox boxRef)
	{
		if ((selectedDogArea == SelectedDogArea.A && selectedBoxA != null && boxRef.associatedDogID == selectedBoxA.associatedDogID) || (selectedDogArea == SelectedDogArea.B && selectedBoxB != null && boxRef.associatedDogID == selectedBoxB.associatedDogID))
		{
			return;
		}
		boxRef.SetBoxChosen(ScriptLocalization.GUI.GUI_BOX_SELECTED);
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(boxRef.associatedDogID);
		if (selectedDogArea == SelectedDogArea.A)
		{
			if (selectedBoxA != null)
			{
				DeselectBox(selectedBoxA, SelectedDogArea.A);
			}
			selectedDogA = saveableDogFromID;
			selectedBoxA = boxRef;
			activeDogNameA.text = saveableDogFromID.dogName;
			dogNameScaleEffectA.RequestScaleIn();
			dogARotArea.SetMouseInputAllowed(val: true);
			clearDogSelectionButtonA.SetActive(value: true);
			AudioController.Play(selectionASound);
			string gUI_BREED_READYA = ScriptLocalization.GUI.GUI_BREED_READYA;
			int length = gUI_BREED_READYA.IndexOf("[");
			int num = gUI_BREED_READYA.IndexOf("]");
			string commandString = gUI_BREED_READYA.Substring(0, length) + saveableDogFromID.dogName + gUI_BREED_READYA.Substring(num + 1);
			WriteConsoleCommand(commandString);
		}
		else if (selectedDogArea == SelectedDogArea.B)
		{
			if (selectedBoxB != null)
			{
				DeselectBox(selectedBoxB, SelectedDogArea.B);
			}
			selectedDogB = saveableDogFromID;
			selectedBoxB = boxRef;
			activeDogNameB.text = saveableDogFromID.dogName;
			dogNameScaleEffectB.RequestScaleIn();
			dogBRotArea.SetMouseInputAllowed(val: true);
			clearDogSelectionButtonB.SetActive(value: true);
			AudioController.Play(selectionBSound);
			string gUI_BREED_READYB = ScriptLocalization.GUI.GUI_BREED_READYB;
			int length2 = gUI_BREED_READYB.IndexOf("[");
			int num2 = gUI_BREED_READYB.IndexOf("]");
			string commandString2 = gUI_BREED_READYB.Substring(0, length2) + saveableDogFromID.dogName + gUI_BREED_READYB.Substring(num2 + 1);
			WriteConsoleCommand(commandString2);
		}
		else
		{
			Debug.LogError("No dog area selected when box is selected!");
		}
		UpdateBreedButtonStatus();
		CreateRotationDog(saveableDogFromID, selectedDogArea);
	}

	private void DeselectBox(DogStorageBox boxRef, SelectedDogArea dogType)
	{
		switch (dogType)
		{
		case SelectedDogArea.A:
			dogBouncerA.StopBounce();
			dogNameScaleEffectA.EndCurrentScale();
			activeDogNameA.text = "";
			break;
		case SelectedDogArea.B:
			dogBouncerB.StopBounce();
			dogNameScaleEffectB.EndCurrentScale();
			activeDogNameB.text = "";
			break;
		}
		if (boxRef != null)
		{
			boxRef.SetUnlocked();
			boxRef.SetBoxDeselected();
		}
		switch (dogType)
		{
		case SelectedDogArea.A:
			if (boxRef != null && selectedDogA != null && !DoesDogPassFilters(selectedDogA))
			{
				DestroyBoxForDogID(selectedBoxA.associatedDogID);
				selectedBoxA = null;
				selectedDogA = null;
			}
			break;
		case SelectedDogArea.B:
			if (boxRef != null && selectedDogB != null && !DoesDogPassFilters(selectedDogB))
			{
				DestroyBoxForDogID(selectedBoxB.associatedDogID);
				selectedBoxB = null;
				selectedDogB = null;
			}
			break;
		}
		UpdateBreedButtonStatus();
	}

	private void SetDogBoxHolderEnabled(bool val)
	{
		for (int i = 0; i < dogBoxesFades.Count; i++)
		{
			dogBoxesFades[i].SetActive(!val);
		}
	}

	private void UpdateBreedButtonStatus()
	{
		if (selectedDogA != null && selectedDogB != null && eggCount > 0)
		{
			SetBreedButtonEnabled(val: true);
		}
		else
		{
			SetBreedButtonEnabled(val: false);
		}
	}

	private void SetBreedButtonEnabled(bool val, bool fromRoutine = false)
	{
		if (!fromRoutine)
		{
			if (val == breedButtonRef.interactable)
			{
				return;
			}
			if (enableButtonRoutine != null)
			{
				StopCoroutine(enableButtonRoutine);
				enableButtonRoutine = null;
			}
			if (val && !breedButtonRef.interactable)
			{
				enableButtonRoutine = StartCoroutine(EnableButtonRoutine());
				return;
			}
		}
		breedButtonRef.interactable = val;
		Color color = enabledBreedButtonTextColor;
		if (!val)
		{
			color = disabledBreedButtonTextColor;
		}
		breedButtonText.color = color;
		for (int i = 0; i < breedButtonArrowImages.Count; i++)
		{
			breedButtonArrowImages[i].color = color;
		}
	}

	private IEnumerator EnableButtonRoutine()
	{
		SetBreedButtonEnabled(val: true, fromRoutine: true);
		yield return new WaitForSecondsRealtime(0.5f);
		WriteConsoleCommand(spacingString);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_ALLMET);
		WriteConsoleCommand(ScriptLocalization.GUI.GUI_BREED_AWAIT);
		WriteConsoleCommand(spacingString);
		AudioController.Play(buttonUnlockedSound);
		enableButtonRoutine = null;
	}

	private void CreateRotationDog(SaveableDog sd, SelectedDogArea areaForDog)
	{
		if (isLoadingDogA && areaForDog == SelectedDogArea.A)
		{
			needsDogARefresh = true;
			return;
		}
		if (isLoadingDogB && areaForDog == SelectedDogArea.B)
		{
			needsDogBRefresh = true;
			return;
		}
		switch (areaForDog)
		{
		case SelectedDogArea.A:
			if (currentlyRotatedDogA != null)
			{
				Object.Destroy(currentlyRotatedDogA);
				currentlyRotatedDogA = null;
			}
			isLoadingDogA = true;
			loadingDogTextA.text = ScriptLocalization.GUI.GUI_LOADING;
			loadingDogTextA.gameObject.SetActive(value: true);
			dogRegRef.RequestNewDog(dogRotationTransformA.position, dogRotationTransformA.rotation, sd.dogGene, null, manualDog: false, dogProfile: sd.dogProfile, callback: OnNewDogACreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: sd.brain.dogAge, customDogAgeProgress: sd.brain.dogAgeProgress);
			break;
		case SelectedDogArea.B:
			if (currentlyRotatedDogB != null)
			{
				Object.Destroy(currentlyRotatedDogB);
				currentlyRotatedDogB = null;
			}
			isLoadingDogB = true;
			loadingDogTextB.text = ScriptLocalization.GUI.GUI_LOADING;
			loadingDogTextB.gameObject.SetActive(value: true);
			dogRegRef.RequestNewDog(dogRotationTransformB.position, dogRotationTransformB.rotation, sd.dogGene, null, manualDog: false, dogProfile: sd.dogProfile, callback: OnNewDogBCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: sd.brain.dogAge, customDogAgeProgress: sd.brain.dogAgeProgress);
			break;
		}
	}

	private void OnNewDogACreated(GameObject dog)
	{
		if (GUIClosed)
		{
			Object.Destroy(dog);
			return;
		}
		isLoadingDogA = false;
		if (selectedDogA == null)
		{
			Object.Destroy(dog);
			needsDogARefresh = false;
		}
		else if (needsDogARefresh)
		{
			Object.Destroy(dog);
			needsDogARefresh = false;
			if (selectedBoxA != null)
			{
				CreateRotationDog(dogRegRef.GetSaveableDogFromID(selectedBoxA.associatedDogID), SelectedDogArea.A);
			}
			else
			{
				loadingDogTextA.gameObject.SetActive(value: false);
			}
		}
		else
		{
			currentlyRotatedDogA = dog;
			dogBouncerA.RequestBounce();
			loadingDogTextA.gameObject.SetActive(value: false);
			dogRegRef.MakeDogSuitableForUIDisplay(dog);
			AudioController.Play(selectDogSound);
			dog.transform.SetParent(dogRotationTransformA, worldPositionStays: true);
		}
	}

	private void OnNewDogBCreated(GameObject dog)
	{
		if (GUIClosed)
		{
			Object.Destroy(dog);
			return;
		}
		isLoadingDogB = false;
		if (selectedDogB == null)
		{
			Object.Destroy(dog);
			needsDogBRefresh = false;
		}
		else if (needsDogBRefresh)
		{
			Object.Destroy(dog);
			needsDogBRefresh = false;
			if (selectedBoxB != null)
			{
				CreateRotationDog(dogRegRef.GetSaveableDogFromID(selectedBoxB.associatedDogID), SelectedDogArea.B);
			}
			else
			{
				loadingDogTextB.gameObject.SetActive(value: false);
			}
		}
		else
		{
			currentlyRotatedDogB = dog;
			dogBouncerB.RequestBounce();
			loadingDogTextB.gameObject.SetActive(value: false);
			dogRegRef.MakeDogSuitableForUIDisplay(dog);
			AudioController.Play(selectDogSound);
			dog.transform.SetParent(dogRotationTransformB, worldPositionStays: true);
		}
	}

	private void WriteConsoleCommand(string commandString, float delay = 0.1f)
	{
		consoleQueueStrings.Add(commandString);
		consoleQueueDelays.Add(delay);
	}

	private void ProcessNextConsoleCommand()
	{
		string commandString = consoleQueueStrings[0];
		float delay = consoleQueueDelays[0];
		consoleQueueStrings.RemoveAt(0);
		consoleQueueDelays.RemoveAt(0);
		currentConsoleRoutine = StartCoroutine(ConsoleWriteWithDelay(commandString, delay));
	}

	private IEnumerator ConsoleWriteWithDelay(string commandString, float delay)
	{
		yield return new WaitForSecondsRealtime(delay);
		Object.Instantiate(consoleCommandPrefab, consoleCommandHolder).GetComponent<BreedingConsoleCommand>().SetText(commandString);
		AudioController.Play(textPrintoutSound);
		currentConsoleRoutine = null;
	}
}
