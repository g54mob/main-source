using System.Collections;
using System.Collections.Generic;
using ClockStone;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BreedingGUI : MonoBehaviour
{
	public Canvas canvasRef;

	public GameObject reflection;

	public GameObject globalBlocker;

	public GameObject mainGUIHolder;

	public GameObject curtainsGUIHolder;

	public Animator curtainsAnimator;

	public GameObject singleCurtain;

	public GameObject breedingObjects;

	public TextMeshProUGUI generationText;

	public GameObject finalDogEggPopup;

	public GameObject skipCutsceneButton;

	public GameObject goHomeButton;

	public Image selectedDogIconHolderA;

	public Image selectedDogIconHolderB;

	public Image selectedDogIconHolderFinal;

	public GameObject clearDogButtonA;

	public GameObject clearDogButtonB;

	public GameObject clearDogButtonFinal;

	public TextMeshProUGUI dogASelectionText;

	public TextMeshProUGUI dogBSelectionText;

	public TextMeshProUGUI dogFinalSelectionText;

	public CoreButtonUnityGUI selectionButtonA;

	public CoreButtonUnityGUI selectionButtonB;

	public CoreButtonUnityGUI selectionButtonFinal;

	public GameObject breedingSelectors;

	public GameObject finalSelector;

	public GameObject stabilityHolder;

	public GameObject generationHolder;

	public Gradient simulationStabilityGradient;

	public TextMeshProUGUI simulationStabilityPercentageText;

	private float previousStability = 1f;

	public CoreButtonUnityGUI breedingButton;

	private ColorBlock breedingButtonColorBlockEnabled;

	public ColorBlock breedingButtonColorBlockDisabled;

	public TextMeshProUGUI breedingButtonText;

	private Color breedingButtonTextColorEnabled = Color.white;

	private Color breedingButtonTextColorDisabled = new Color(1f, 1f, 1f, 0.5f);

	public CoreButtonUnityGUI finalSelectionButton;

	private ColorBlock finalSelectionButtonColorBlockEnabled;

	public ColorBlock finalSelectionButtonColorBlockDisabled;

	public TextMeshProUGUI finalSelectionButtonText;

	private Color finalSelectionButtonTextColorEnabled = Color.white;

	private Color finalSelectionButtonTextColorDisabled = new Color(1f, 1f, 1f, 0.5f);

	public GameObject backButton;

	public GameObject modeButtons;

	public GameObject promptHolder;

	public GameObject promptBouncer;

	public TextMeshProUGUI promptText;

	public TextScaleInOnLoad promptScale;

	public GameObject modeButtonBouncerA;

	public GameObject modeButtonBouncerB;

	public GameObject breedButtonBouncer;

	public GameObject finalSelectionButtonBouncer;

	public GameObject selectionABouncer;

	public GameObject selectionBBouncer;

	public GameObject selectionFinalBouncer;

	private float buttonBounceInTime = 1f;

	private Inchworm.EaseStyle buttonBounceStyle = Inchworm.EaseStyle.ElasticOut;

	public GameObject cutsceneObjects;

	public GameObject goHomePrompt;

	public GameObject runesRenderCam;

	public DogRuneHolder cutsceneRune;

	public GameObject cutsceneRuneGraphic;

	public GameObject cutsceneRenderHolder;

	public GameObject sequencingRenderHolder;

	public GameObject sequencingPopup;

	public Animator runesHolderAnimator;

	public GameObject message_01;

	public GameObject message_02;

	public GameObject message_03;

	public List<GameObject> runes = new List<GameObject>();

	public List<GameObject> runePrefabs = new List<GameObject>();

	private string runesSweepInTrigger = "SweepIn";

	public GameObject peekRoomPrefab;

	private GameObject instantiatedPeekRoom;

	private string runeSound = "rune_bwong";

	private string breedButtonSound = "breedingCenter_BreedButton";

	private string clickToSelectButtonSound = "breedingCenter_ClickToSelectButton";

	private string continueButtonSound = "breedingCenter_ContinueButton";

	private string finishButtonSound = "breedingCenter_FinishButton";

	private string selectDogSound = "breedingCenter_SelectDogButton";

	private string skipButtonSound = "breedingCenter_SkipCutsceneButton";

	private string removeSelectedDogSound = "breedingCenter_RemoveSelectedDog";

	private string leaveEarlyPopupSound = "breedingCenter_LeavePopup";

	private string confirmLeaveEarlySound = "breedingCenter_PopupLeaveConfirm";

	private string cancelLeaveEarlySound = "breedingCenter_PopupStay";

	private string categoryBackSound = "breedingCenter_CategoryBack";

	private string finalEggSound = "breedingCenter_FinalEgg";

	private string curtainsOpenAnimation = "CurtainsOpen";

	private string curtainsCloseAnimation = "CurtainsClose";

	private GameObject peekableA;

	private GameObject peekableB;

	private bool dogASpawned;

	private bool dogBSpawned;

	private ulong? selectedDogA;

	private ulong? selectedDogB;

	private ulong? selectedDogFinal;

	private SaveableDog initialBreedingDogA;

	private SaveableDog initialBreedingDogB;

	private int currentGeneration;

	private string lastLanguage;

	private List<int> selectedRunes = new List<int>();

	private Coroutine sequencingRoutine;

	private Coroutine initialPeekRoutine;

	private bool travelInitiated;

	private Inchworm inchwormRef;

	private GUIManagerPens guiRef;

	private ObjectGrabber grabberRef;

	private DogRegistration dogRegRef;

	private MusicPlaylistController musicRef;

	private BreedingController breedingControllerRef;

	private void Awake()
	{
		lastLanguage = LocalizationManager.CurrentLanguage;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		guiRef.DisableBG(LockReason.BREEDING_GUI, blur: false);
		guiRef.SetGUIInteractiveStatus(status: false, LockReason.BREEDING_GUI);
		canvasRef.worldCamera = registrationScript.GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
		breedingButtonColorBlockEnabled = breedingButton.colors;
		finalSelectionButtonColorBlockEnabled = finalSelectionButton.colors;
		ClearSelectedDogs();
		OnSwitchToDogBreedingButtonPressed(bounce: false);
		HideBreedingObjects();
		singleCurtain.SetActive(value: false);
		globalBlocker.SetActive(value: false);
		runesRenderCam.SetActive(value: false);
		cutsceneObjects.SetActive(value: false);
		finalDogEggPopup.SetActive(value: false);
		skipCutsceneButton.SetActive(value: false);
		cutsceneRuneGraphic.SetActive(value: false);
		cutsceneRenderHolder.SetActive(value: false);
		sequencingRenderHolder.SetActive(value: false);
		reflection.SetActive(value: true);
		musicRef = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>();
		musicRef.SetGameLocation(GameLocation.BREEDING_CENTER);
	}

	public void Initialize()
	{
		travelInitiated = false;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		List<PlacedObjectInfo> allPlacedObjects = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER).GetAllRooms()[0].GetComponent<RoomBase>().GetAllPlacedObjects();
		for (int i = 0; i < allPlacedObjects.Count; i++)
		{
			breedingControllerRef = allPlacedObjects[i].objectRef.GetComponentInChildren<BreedingController>();
			if (breedingControllerRef != null)
			{
				allPlacedObjects[i].objectRef.transform.position += Vector3.down * 0.75f;
				break;
			}
		}
		if (breedingControllerRef == null)
		{
			Debug.LogError("No breeding controller found!");
		}
		sequencingPopup.SetActive(value: false);
		message_01.SetActive(value: false);
		message_02.SetActive(value: false);
		message_03.SetActive(value: false);
		for (int j = 0; j < runes.Count; j++)
		{
			runes[j].SetActive(value: false);
		}
		goHomePrompt.SetActive(value: false);
		guiRef.SetGUIInteractiveStatus(status: true, LockReason.BREEDING_GUI);
	}

	private void Update()
	{
		if (LocalizationManager.CurrentLanguage != lastLanguage)
		{
			OnLanguageUpdated();
		}
		if (Random.value < (1f - previousStability) * 0.015f)
		{
			float num = 1f - previousStability;
			if (Random.value > 0.75f)
			{
				musicRef.RequestPitchBend(num, Random.Range(0.05f, 0.5f) * num, Random.Range(0.05f, 0.5f) * num);
			}
			else
			{
				musicRef.RequestPitchModulation(Random.Range(0.5f, 1f) * num);
			}
		}
		if (GameControls.actions.CloseMenu.WasPressed && goHomePrompt.activeSelf && !travelInitiated)
		{
			CancelGoHome();
		}
	}

	public void OnLanguageUpdated()
	{
		SetGeneration(currentGeneration);
	}

	public void OnBackButtonPressed()
	{
		AudioController.Play(categoryBackSound);
		ClearSelectedDogs();
		SetBreedingUIVis(val: false);
		SetFinalSelectionUIVis(val: false);
		backButton.SetActive(value: false);
		ShowPrompt(ScriptLocalization.GUI.GUI_BREEDSIM_CROSSORSELECT);
		StartCoroutine(BounceInModeButtons());
	}

	public void OnExitButtonPressed()
	{
		AudioController.Play(leaveEarlyPopupSound);
		goHomePrompt.SetActive(value: true);
		guiRef.DisableBG(LockReason.BREEDING_PROMPT);
	}

	public void ConfirmGoHome()
	{
		travelInitiated = true;
		AudioController.Play(confirmLeaveEarlySound);
		globalBlocker.SetActive(value: true);
		CheatEngine.DestroyAllDogs(null, safeDestroy: true, fromScript: true);
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBreeding>(GlobalObject.SCENE_MANAGER).GoHome();
	}

	public void CancelGoHome()
	{
		AudioController.Play(cancelLeaveEarlySound);
		goHomePrompt.SetActive(value: false);
		guiRef.EnableBG(LockReason.BREEDING_PROMPT);
	}

	public void SetGeneration(int num)
	{
		lastLanguage = LocalizationManager.CurrentLanguage;
		string gUI_BREEDSIM_GEN = ScriptLocalization.GUI.GUI_BREEDSIM_GEN;
		int length = gUI_BREEDSIM_GEN.IndexOf("[");
		int num2 = gUI_BREEDSIM_GEN.IndexOf("]");
		currentGeneration = num;
		generationText.text = gUI_BREEDSIM_GEN.Substring(0, length) + currentGeneration + gUI_BREEDSIM_GEN.Substring(num2 + 1);
	}

	public void HideBreedingObjects()
	{
		breedingObjects.SetActive(value: false);
	}

	public void ShowBreedingObjects()
	{
		StartCoroutine(ShowBreedingObjectsRoutine());
	}

	private IEnumerator ShowBreedingObjectsRoutine()
	{
		float panelEaseTime = 0.5f;
		breedingObjects.SetActive(value: true);
		generationHolder.SetActive(value: true);
		modeButtons.SetActive(value: false);
		promptHolder.SetActive(value: false);
		stabilityHolder.SetActive(value: false);
		SetBreedingUIVis(val: false);
		backButton.SetActive(value: false);
		SetFinalSelectionUIVis(val: false);
		generationText.GetComponent<TextScaleInOnLoad>().RequestScaleIn();
		inchwormRef.RequestEase(generationHolder, new Vector3(0f, -1f, 0f), panelEaseTime, adjustStartingPos: true, Inchworm.EaseStyle.OutBack, Inchworm.EaseType.Position, null, Inchworm.EasePriority.Normal, keepSameParent: true);
		yield return new WaitForSeconds(panelEaseTime * 0.75f);
		stabilityHolder.SetActive(value: true);
		inchwormRef.RequestEase(stabilityHolder, new Vector3(0f, -1f, 0f), panelEaseTime, adjustStartingPos: true, Inchworm.EaseStyle.OutBack, Inchworm.EaseType.Position, null, Inchworm.EasePriority.Normal, keepSameParent: true);
		yield return new WaitForSeconds(panelEaseTime);
		WaitForEndOfFrame stabilityWait = new WaitForEndOfFrame();
		float rawStability = breedingControllerRef.GetStability();
		float changeTime = 1f;
		float totalChange = previousStability - rawStability;
		musicRef.RequestPitchBend(1f - rawStability, 0.5f, 0.25f, force: true);
		float visibleStability = previousStability;
		while (visibleStability > rawStability)
		{
			simulationStabilityPercentageText.text = Mathf.RoundToInt(visibleStability * 100f) + "%";
			simulationStabilityPercentageText.color = simulationStabilityGradient.Evaluate(1f - visibleStability);
			yield return stabilityWait;
			visibleStability -= totalChange * Time.deltaTime * changeTime;
			if (visibleStability < rawStability)
			{
				visibleStability = rawStability;
			}
		}
		previousStability = rawStability;
		simulationStabilityPercentageText.text = Mathf.RoundToInt(rawStability * 100f) + "%";
		simulationStabilityPercentageText.color = simulationStabilityGradient.Evaluate(1f - rawStability);
		StartCoroutine(ShowPromptWithBounce(ScriptLocalization.GUI.GUI_BREEDSIM_CROSSORSELECT));
		yield return new WaitForSeconds(0.25f);
		yield return StartCoroutine(BounceInModeButtons());
	}

	private IEnumerator BounceInModeButtons()
	{
		modeButtons.SetActive(value: true);
		modeButtonBouncerA.transform.localScale = Vector3.zero;
		modeButtonBouncerB.transform.localScale = Vector3.zero;
		inchwormRef.RequestEaseToScale(modeButtonBouncerA, Vector3.one, buttonBounceInTime, buttonBounceStyle);
		yield return new WaitForSeconds(0.15f);
		inchwormRef.RequestEaseToScale(modeButtonBouncerB, Vector3.one, buttonBounceInTime, buttonBounceStyle);
		yield return new WaitForSeconds(0.25f);
	}

	public void InitializeBreeding(SaveableDog initialDogA, SaveableDog initialDogB)
	{
		initialBreedingDogA = initialDogA;
		initialBreedingDogB = initialDogB;
		SaveableDogGene saveableDogGene;
		if (initialDogA == null || initialDogA.dogGene == null)
		{
			saveableDogGene = new SaveableDogGene();
			saveableDogGene.dogGene = CheatEngine.cheatRef.defaultDogGene;
			saveableDogGene.domRecGene = CheatEngine.cheatRef.defaultDomRecDogGene;
			saveableDogGene.geneVersion = MasterDogGene.currentGeneticVersion;
			Debug.LogError("No initial dog A set for breeding.");
		}
		else
		{
			saveableDogGene = initialDogA.dogGene;
		}
		SaveableDogGene saveableDogGene2;
		if (initialDogB == null || initialDogB.dogGene == null)
		{
			saveableDogGene2 = new SaveableDogGene();
			saveableDogGene2.dogGene = CheatEngine.cheatRef.defaultDogGene;
			saveableDogGene2.domRecGene = CheatEngine.cheatRef.defaultDomRecDogGene;
			saveableDogGene2.geneVersion = MasterDogGene.currentGeneticVersion;
			Debug.LogError("No initial dog B set for breeding.");
		}
		else
		{
			saveableDogGene2 = initialDogB.dogGene;
		}
		ObjectGrabber globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		breedingControllerRef.BreedSelectedDogs(saveableDogGene, saveableDogGene2, playSounds: false);
		guiRef.ShowBreedingPenGUI();
		guiRef.ShowHUD();
		guiRef.EnableBG(LockReason.BREEDING_GUI);
		globalComponent.EnableGrabber(LockReason.BREEDING_GUI);
		GoalsController.ReportGoalEvent(GoalCondition.BREED_DOGS);
	}

	public void OnDogASelectionButtonPressed()
	{
		AudioController.Play(clickToSelectButtonSound);
		grabberRef.EnterDogSelectionMode(OnDogASelected);
		dogASelectionText.gameObject.SetActive(value: true);
		dogASelectionText.text = ScriptLocalization.GUI.GUI_BOX_SELECTDOG;
		clearDogButtonA.SetActive(value: true);
		selectionButtonA.interactable = false;
		selectionButtonB.interactable = false;
	}

	public void OnDogBSelectionButtonPressed()
	{
		AudioController.Play(clickToSelectButtonSound);
		grabberRef.EnterDogSelectionMode(OnDogBSelected);
		dogBSelectionText.gameObject.SetActive(value: true);
		dogBSelectionText.text = ScriptLocalization.GUI.GUI_BOX_SELECTDOG;
		clearDogButtonB.SetActive(value: true);
		selectionButtonA.interactable = false;
		selectionButtonB.interactable = false;
	}

	public void OnDogFinalSelectionButtonPressed()
	{
		AudioController.Play(clickToSelectButtonSound);
		grabberRef.EnterDogSelectionMode(OnDogFinalSelected);
		dogFinalSelectionText.gameObject.SetActive(value: true);
		dogFinalSelectionText.text = ScriptLocalization.GUI.GUI_BOX_SELECTDOG;
		clearDogButtonFinal.SetActive(value: true);
		selectionButtonFinal.interactable = false;
	}

	public void OnDogASelected(RaycastHit hitRef)
	{
		if (!(hitRef.transform == null))
		{
			SelectDogA(dogRegRef.GetSaveableDogFromDog(hitRef.transform.root.gameObject));
		}
	}

	public void OnDogBSelected(RaycastHit hitRef)
	{
		if (!(hitRef.transform == null))
		{
			SelectDogB(dogRegRef.GetSaveableDogFromDog(hitRef.transform.root.gameObject));
		}
	}

	public void OnDogFinalSelected(RaycastHit hitRef)
	{
		if (!(hitRef.transform == null))
		{
			SelectDogFinal(dogRegRef.GetSaveableDogFromDog(hitRef.transform.root.gameObject));
		}
	}

	public void SelectDogA(SaveableDog sd)
	{
		AudioController.Play(selectDogSound);
		selectedDogA = sd.dogID;
		clearDogButtonA.SetActive(value: true);
		selectedDogIconHolderA.enabled = true;
		selectedDogIconHolderA.sprite = dogRegRef.GetDefaultThumbnailForDogID(sd.dogID);
		dogASelectionText.gameObject.SetActive(value: false);
		UpdateBreedingButton();
		grabberRef.SelectBreedingDogA(dogRegRef.GetDogFromID(sd.dogID));
		selectionButtonA.interactable = false;
		selectionButtonB.interactable = !selectedDogB.HasValue;
	}

	public void SelectDogB(SaveableDog sd)
	{
		AudioController.Play(selectDogSound);
		selectedDogB = sd.dogID;
		clearDogButtonB.SetActive(value: true);
		selectedDogIconHolderB.enabled = true;
		selectedDogIconHolderB.sprite = dogRegRef.GetDefaultThumbnailForDogID(sd.dogID);
		dogBSelectionText.gameObject.SetActive(value: false);
		UpdateBreedingButton();
		grabberRef.SelectBreedingDogB(dogRegRef.GetDogFromID(sd.dogID));
		selectionButtonB.interactable = false;
		selectionButtonA.interactable = !selectedDogA.HasValue;
	}

	public void SelectDogFinal(SaveableDog sd)
	{
		AudioController.Play(selectDogSound);
		selectedDogFinal = sd.dogID;
		clearDogButtonFinal.SetActive(value: true);
		selectedDogIconHolderFinal.enabled = true;
		selectedDogIconHolderFinal.sprite = dogRegRef.GetDefaultThumbnailForDogID(sd.dogID);
		dogFinalSelectionText.gameObject.SetActive(value: false);
		UpdateFinalSelectionButton();
		grabberRef.SelectBreedingDogFinal(dogRegRef.GetDogFromID(sd.dogID));
	}

	public void ClearSelectedDogs()
	{
		ClearDogA(playSounds: false);
		ClearDogB(playSounds: false);
		ClearDogFinal(playSounds: false);
	}

	public void ClearDogA(bool playSounds = true)
	{
		if (playSounds)
		{
			AudioController.Play(removeSelectedDogSound);
		}
		selectedDogA = null;
		clearDogButtonA.SetActive(value: false);
		selectedDogIconHolderA.sprite = null;
		selectedDogIconHolderA.enabled = false;
		dogASelectionText.gameObject.SetActive(value: true);
		dogASelectionText.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		UpdateBreedingButton();
		grabberRef.ClearBreedingDogA();
		grabberRef.ExitDogSelectionMode();
		selectionButtonA.interactable = true;
	}

	public void ClearDogB(bool playSounds = true)
	{
		if (playSounds)
		{
			AudioController.Play(removeSelectedDogSound);
		}
		selectedDogB = null;
		clearDogButtonB.SetActive(value: false);
		selectedDogIconHolderB.sprite = null;
		selectedDogIconHolderB.enabled = false;
		dogBSelectionText.gameObject.SetActive(value: true);
		dogBSelectionText.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		UpdateBreedingButton();
		grabberRef.ClearBreedingDogB();
		grabberRef.ExitDogSelectionMode();
		selectionButtonB.interactable = true;
	}

	public void ClearDogFinal(bool playSounds = true)
	{
		if (playSounds)
		{
			AudioController.Play(removeSelectedDogSound);
		}
		selectedDogFinal = null;
		clearDogButtonFinal.SetActive(value: false);
		selectedDogIconHolderFinal.sprite = null;
		selectedDogIconHolderFinal.enabled = false;
		dogFinalSelectionText.gameObject.SetActive(value: true);
		dogFinalSelectionText.text = ScriptLocalization.GUI.GUI_BOX_CLICK;
		UpdateFinalSelectionButton();
		grabberRef.ClearBreedingDogFinal();
		grabberRef.ExitDogSelectionMode();
		selectionButtonFinal.interactable = true;
	}

	public void OnBreedDogsButtonPressed()
	{
		if (!selectedDogA.HasValue || !selectedDogB.HasValue)
		{
			Debug.LogError("Missing valid dog ID!");
			return;
		}
		AudioController.Play(breedButtonSound);
		breedingControllerRef.BreedSelectedDogs(dogRegRef.GetSaveableDogFromID(selectedDogA.Value).dogGene, dogRegRef.GetSaveableDogFromID(selectedDogB.Value).dogGene);
		ClearDogA(playSounds: false);
		ClearDogB(playSounds: false);
		if (previousStability <= 0f)
		{
			GoalsController.ReportGoalEvent(GoalCondition.UNSTABLE_CROSSBREED);
		}
	}

	public void ShowPrompt(string newText)
	{
		promptText.text = newText;
		promptHolder.SetActive(value: true);
		promptScale.RequestScaleIn();
	}

	public IEnumerator ShowPromptWithBounce(string newText)
	{
		promptText.text = "";
		promptScale.enabled = false;
		promptHolder.SetActive(value: true);
		promptBouncer.transform.localScale = Vector3.zero;
		inchwormRef.RequestEaseToScale(promptBouncer, Vector3.one, buttonBounceInTime, buttonBounceStyle);
		yield return new WaitForSeconds(0.1f);
		promptText.text = newText;
		promptScale.enabled = true;
		promptScale.RequestScaleIn();
	}

	private void SetFinalSelectionUIVis(bool val)
	{
		finalSelector.SetActive(val);
		finalSelectionButton.transform.parent.gameObject.SetActive(val);
		if (val)
		{
			selectionFinalBouncer.transform.localScale = Vector3.zero;
			inchwormRef.RequestEaseToScale(selectionFinalBouncer, Vector3.one, buttonBounceInTime, buttonBounceStyle);
		}
	}

	private void SetBreedingUIVis(bool val, bool bounce = true)
	{
		breedingSelectors.SetActive(val);
		breedingButton.transform.parent.gameObject.SetActive(val);
		if (val && bounce)
		{
			selectionABouncer.transform.localScale = Vector3.zero;
			inchwormRef.RequestEaseToScale(selectionABouncer, Vector3.one, buttonBounceInTime, buttonBounceStyle);
			selectionBBouncer.transform.localScale = Vector3.zero;
			inchwormRef.RequestEaseToScale(selectionBBouncer, Vector3.one, buttonBounceInTime, buttonBounceStyle, null, Inchworm.EasePriority.Normal, 0.15f);
		}
	}

	public void OnSwitchToDogSelectionButtonPressed()
	{
		AudioController.Play(continueButtonSound);
		ClearSelectedDogs();
		SetBreedingUIVis(val: false);
		SetFinalSelectionUIVis(val: true);
		backButton.SetActive(value: true);
		modeButtons.SetActive(value: false);
		ShowPrompt(ScriptLocalization.GUI.GUI_BREEDSIM_SELECTRESULT);
		finalSelector.SetActive(value: true);
		breedingSelectors.SetActive(value: false);
		breedingButton.transform.parent.gameObject.SetActive(value: false);
		finalSelectionButton.transform.parent.gameObject.SetActive(value: true);
		finalSelectionButtonBouncer.transform.localScale = Vector3.zero;
		inchwormRef.RequestEaseToScale(finalSelectionButtonBouncer, Vector3.one, buttonBounceInTime, buttonBounceStyle, null, Inchworm.EasePriority.Normal, 0.15f);
		OnDogFinalSelectionButtonPressed();
		if (selectedDogA.HasValue)
		{
			grabberRef.ClearBreedingDogA();
		}
		if (selectedDogB.HasValue)
		{
			grabberRef.ClearBreedingDogB();
		}
		if (selectedDogFinal.HasValue)
		{
			grabberRef.SelectBreedingDogFinal(dogRegRef.GetDogFromID(selectedDogFinal.Value));
		}
	}

	public void OnSwitchToDogBreedingButtonPressed(bool bounce = true)
	{
		if (bounce)
		{
			AudioController.Play(continueButtonSound);
		}
		ClearSelectedDogs();
		SetBreedingUIVis(val: true, bounce);
		SetFinalSelectionUIVis(val: false);
		backButton.SetActive(value: true);
		modeButtons.SetActive(value: false);
		ShowPrompt(ScriptLocalization.GUI.GUI_BREEDSIM_SELECTDOGS);
		finalSelector.SetActive(value: false);
		breedingSelectors.SetActive(value: true);
		breedingButton.transform.parent.gameObject.SetActive(value: true);
		finalSelectionButton.transform.parent.gameObject.SetActive(value: false);
		if (bounce)
		{
			breedButtonBouncer.transform.localScale = Vector3.zero;
			inchwormRef.RequestEaseToScale(breedButtonBouncer, Vector3.one, buttonBounceInTime, buttonBounceStyle);
			OnDogASelectionButtonPressed();
		}
		if (selectedDogFinal.HasValue)
		{
			grabberRef.ClearBreedingDogFinal();
		}
		if (selectedDogA.HasValue)
		{
			grabberRef.SelectBreedingDogA(dogRegRef.GetDogFromID(selectedDogA.Value));
		}
		if (selectedDogB.HasValue)
		{
			grabberRef.SelectBreedingDogB(dogRegRef.GetDogFromID(selectedDogB.Value));
		}
	}

	public void OnSelectFinalDogButtonPressed()
	{
		if (!selectedDogFinal.HasValue)
		{
			Debug.LogError("No valid final dog selected!");
			return;
		}
		AudioController.Play(finishButtonSound);
		sequencingRoutine = StartCoroutine(SequencingRoutine());
	}

	private IEnumerator SequencingRoutine()
	{
		WaitForSeconds finalWait = new WaitForSeconds(3f);
		WaitForSeconds runicWait = new WaitForSeconds(0.25f);
		WaitForSeconds quickWait = new WaitForSeconds(1.5f);
		WaitForSeconds standardWait = new WaitForSeconds(3f);
		breedingControllerRef.AddFinalEggToInventory(dogRegRef.GetSaveableDogFromID(selectedDogFinal.Value), initialBreedingDogA, initialBreedingDogB);
		goHomeButton.SetActive(value: false);
		skipCutsceneButton.SetActive(value: true);
		guiRef.SetPauseMenuLockedStatus(val: true);
		runesRenderCam.SetActive(value: true);
		sequencingRenderHolder.SetActive(value: true);
		sequencingPopup.SetActive(value: true);
		runesHolderAnimator.SetTrigger(runesSweepInTrigger);
		yield return new WaitForSeconds(1f);
		message_01.SetActive(value: true);
		yield return quickWait;
		message_01.SetActive(value: false);
		message_02.SetActive(value: true);
		yield return standardWait;
		message_02.SetActive(value: false);
		message_03.SetActive(value: true);
		AudioController.StopMusic(3f);
		SFXOverlord.LockInWorldSFX(LockReason.BREEDING_GUI);
		yield return standardWait;
		message_03.SetActive(value: false);
		selectedRunes.Clear();
		for (int i = 0; i < runes.Count; i++)
		{
			int num = Random.Range(0, runePrefabs.Count);
			runes[i].SetActive(value: true);
			selectedRunes.Add(num);
			runes[i].GetComponent<DogRuneHolder>().SetRune(runePrefabs[num]);
			AudioController.Play(runeSound);
			yield return runicWait;
		}
		yield return finalWait;
		sequencingRoutine = null;
		breedingControllerRef.OnFinalDogSelected();
	}

	public IEnumerator PeekRuneRoutine()
	{
		WaitForSeconds runicWait = new WaitForSeconds(0.25f);
		runesRenderCam.SetActive(value: true);
		cutsceneRuneGraphic.SetActive(value: true);
		cutsceneRenderHolder.SetActive(value: true);
		for (int i = 0; i < selectedRunes.Count; i++)
		{
			cutsceneRune.SetRune(runePrefabs[selectedRunes[i]], bounce: false);
			yield return runicWait;
		}
		runesRenderCam.SetActive(value: false);
		cutsceneRuneGraphic.SetActive(value: false);
		yield return new WaitForSeconds(1f);
	}

	public void SetupPeekRoom()
	{
		instantiatedPeekRoom = Object.Instantiate(peekRoomPrefab, Vector3.one * 1000f, Quaternion.identity);
		ShowPeekRoom();
	}

	private void UpdateBreedingButton()
	{
		bool flag = true;
		if (!selectedDogA.HasValue || !selectedDogB.HasValue)
		{
			flag = false;
		}
		breedingButton.interactable = flag;
		if (flag)
		{
			breedingButton.colors = breedingButtonColorBlockEnabled;
			breedingButtonText.color = breedingButtonTextColorEnabled;
		}
		else
		{
			breedingButton.colors = breedingButtonColorBlockDisabled;
			breedingButtonText.color = breedingButtonTextColorDisabled;
		}
	}

	private void UpdateFinalSelectionButton()
	{
		bool flag = true;
		if (!selectedDogFinal.HasValue)
		{
			flag = false;
		}
		finalSelectionButton.interactable = flag;
		if (flag)
		{
			finalSelectionButton.colors = finalSelectionButtonColorBlockEnabled;
			finalSelectionButtonText.color = finalSelectionButtonTextColorEnabled;
		}
		else
		{
			finalSelectionButton.colors = finalSelectionButtonColorBlockDisabled;
			finalSelectionButtonText.color = finalSelectionButtonTextColorDisabled;
		}
	}

	private void OnDogAInstantiated(GameObject dog)
	{
		peekableA = dog;
		dogASpawned = true;
		instantiatedPeekRoom.GetComponent<PeekRoom>().PlacePeekDogA(peekableA);
		peekableA.GetComponent<DogIndicatorController>().DisableEntireIndicator();
	}

	private void OnDogBInstantiated(GameObject dog)
	{
		peekableB = dog;
		dogBSpawned = true;
		instantiatedPeekRoom.GetComponent<PeekRoom>().PlacePeekDogB(peekableB);
		peekableB.GetComponent<DogIndicatorController>().DisableEntireIndicator();
	}

	private void ShowPeekRoom()
	{
		StartCoroutine(WaitForDogSpawn());
	}

	private IEnumerator WaitForDogSpawn()
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		ObjectRegistration regRef = ObjectRegistration.GetRegistrationScript();
		globalBlocker.SetActive(value: true);
		curtainsAnimator.enabled = true;
		curtainsGUIHolder.SetActive(value: true);
		curtainsAnimator.Play(curtainsCloseAnimation);
		yield return new WaitForSeconds(1f);
		mainGUIHolder.SetActive(value: false);
		breedingObjects.SetActive(value: false);
		CheatEngine.DestroyAllDogs(null, safeDestroy: true, fromScript: true);
		runesRenderCam.SetActive(value: false);
		cutsceneRenderHolder.SetActive(value: true);
		sequencingRenderHolder.SetActive(value: false);
		guiRef.HideHUD();
		grabberRef.DisableGrabber(LockReason.BREEDING_GUI);
		DogAge dogAge = DogAge.ADULT;
		DogAge dogAge2 = DogAge.ADULT;
		float num = 0f;
		float num2 = 0f;
		SaveableDogProfile saveableDogProfile = null;
		SaveableDogProfile saveableDogProfile2 = null;
		SaveableDog dogA = regRef.saveLoadManager.GetDogA();
		SaveableDog dogB = regRef.saveLoadManager.GetDogB();
		SaveableDogGene saveableDogGene;
		if (dogA == null || dogA.dogGene == null)
		{
			saveableDogGene = new SaveableDogGene();
			saveableDogGene.dogGene = CheatEngine.cheatRef.defaultDogGene;
			saveableDogGene.domRecGene = CheatEngine.cheatRef.defaultDomRecDogGene;
			saveableDogGene.geneVersion = MasterDogGene.currentGeneticVersion;
			Debug.LogError("No initial dog A set for breeding.");
		}
		else
		{
			saveableDogGene = dogA.dogGene;
			saveableDogProfile = dogA.dogProfile;
			dogAge = dogA.brain.dogAge;
			num = dogA.brain.dogAgeProgress;
		}
		SaveableDogGene saveableDogGene2;
		if (dogB == null || dogB.dogGene == null)
		{
			saveableDogGene2 = new SaveableDogGene();
			saveableDogGene2.dogGene = CheatEngine.cheatRef.defaultDogGene;
			saveableDogGene2.domRecGene = CheatEngine.cheatRef.defaultDomRecDogGene;
			saveableDogGene2.geneVersion = MasterDogGene.currentGeneticVersion;
			Debug.LogError("No initial dog B set for breeding.");
		}
		else
		{
			saveableDogGene2 = dogB.dogGene;
			saveableDogProfile2 = dogB.dogProfile;
			dogAge2 = dogB.brain.dogAge;
			num2 = dogB.brain.dogAgeProgress;
		}
		DogRegistration dogRegistration = dogRegRef;
		Vector3 position = instantiatedPeekRoom.transform.position;
		Quaternion identity = Quaternion.identity;
		SaveableDogGene gene = saveableDogGene;
		SaveableDogProfile dogProfile = saveableDogProfile;
		DogAge customDogAge = dogAge;
		float customDogAgeProgress = num;
		dogRegistration.RequestNewDog(position, identity, gene, null, manualDog: false, OnDogAInstantiated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: false, forceCacheThumbnails: false, dummyDog: false, dogProfile, customDogAge, customDogAgeProgress);
		DogRegistration dogRegistration2 = dogRegRef;
		Vector3 position2 = instantiatedPeekRoom.transform.position;
		Quaternion identity2 = Quaternion.identity;
		SaveableDogGene gene2 = saveableDogGene2;
		dogProfile = saveableDogProfile2;
		customDogAge = dogAge2;
		customDogAgeProgress = num2;
		dogRegistration2.RequestNewDog(position2, identity2, gene2, null, manualDog: false, OnDogBInstantiated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: false, forceCacheThumbnails: false, dummyDog: false, dogProfile, customDogAge, customDogAgeProgress);
		while (!dogASpawned || !dogBSpawned)
		{
			yield return frameWait;
		}
		if (peekableA != null && peekableB != null)
		{
			Collider[] componentsInChildren = peekableA.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				Collider[] componentsInChildren2 = peekableB.GetComponentsInChildren<Collider>();
				foreach (Collider collider2 in componentsInChildren2)
				{
					Physics.IgnoreCollision(collider, collider2);
				}
			}
		}
		guiRef.EnableBG(LockReason.BREEDING_GUI);
		singleCurtain.SetActive(value: false);
		curtainsAnimator.Play(curtainsOpenAnimation);
		initialPeekRoutine = StartCoroutine(PeekRoutine());
	}

	private IEnumerator PeekRoutine()
	{
		reflection.SetActive(value: false);
		globalBlocker.SetActive(value: false);
		cutsceneObjects.SetActive(value: true);
		yield return StartCoroutine(instantiatedPeekRoom.GetComponent<PeekRoom>().PeekRoutine(this));
		initialPeekRoutine = null;
		StartCoroutine(GoBackHomeRoutine());
	}

	public void SkipCutscene()
	{
		if (sequencingRoutine != null)
		{
			StopCoroutine(sequencingRoutine);
			sequencingRoutine = null;
		}
		if (initialPeekRoutine != null)
		{
			StopCoroutine(initialPeekRoutine);
			initialPeekRoutine = null;
		}
		if (instantiatedPeekRoom != null)
		{
			instantiatedPeekRoom.GetComponent<PeekRoom>().OnRoutineStoppedEarly();
		}
		AudioController.Play(skipButtonSound);
		StartCoroutine(GoBackHomeRoutine());
	}

	private IEnumerator GoBackHomeRoutine()
	{
		skipCutsceneButton.SetActive(value: false);
		cutsceneRuneGraphic.SetActive(value: false);
		curtainsAnimator.enabled = true;
		curtainsGUIHolder.SetActive(value: true);
		curtainsAnimator.Play(curtainsCloseAnimation);
		yield return new WaitForSeconds(1f);
		finalDogEggPopup.SetActive(value: true);
		AudioController.Play(finalEggSound);
		yield return new WaitForSeconds(3f);
		cutsceneObjects.SetActive(value: false);
		skipCutsceneButton.SetActive(value: false);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		Object.Destroy(peekableA);
		Object.Destroy(peekableB);
		Object.Destroy(instantiatedPeekRoom);
		registrationScript.GetGlobalComponent<SceneManagerBreeding>(GlobalObject.SCENE_MANAGER).GoHome();
	}
}
