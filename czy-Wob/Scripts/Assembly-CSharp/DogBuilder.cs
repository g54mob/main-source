using System.Collections;
using System.Collections.Generic;
using InControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class DogBuilder : MonoBehaviour
{
	public GameObject mainContent;

	public GameObject introContent;

	public Camera builderCam;

	public DepthOfField DOFRef;

	public GameObject doneArrowRef;

	public GameObject sliderPrefab;

	public GameObject choicePrefab;

	public GameObject spawnButtonRef;

	public TMP_InputField inputField;

	public Scrollbar verticalScrollbar;

	public RectTransform sliderContent;

	public Transform sliderStartTransform;

	public TextMeshProUGUI puppyButtonTextRef;

	public TextMeshProUGUI dogsLeftNumTextRef;

	private int dogMax = 2;

	private int currentDogCount;

	private float sliderOffset = -100f;

	private bool initialSliderValuesSet;

	private List<DogBuilderSlider> sliders = new List<DogBuilderSlider>();

	private bool builderActive;

	private GameObject currentDog;

	private MasterDogGene currentMasterGene;

	private bool isPuppy;

	private Gene patternNumGene;

	private Gene patternIntensityGene;

	private Slider patternNumSlider;

	private Slider patternTypeSlider;

	private Slider patternIntensitySlider;

	private bool needsIntensitySet;

	private float activeTabPos = 170f;

	private float inactiveTabPos = 200f;

	private GameObject activeGeneTab;

	private GeneCategory currentGeneCategory;

	private bool isRotatingDog;

	private Vector3 mousePosStart = Vector3.zero;

	private Quaternion startRot = Quaternion.identity;

	private string currentGene;

	private List<DogBuilderSlider> slidersToUpdate = new List<DogBuilderSlider>();

	private Coroutine currentRoutine;

	private DogHome dogHomeRef;

	private PenFocus penFocusRef;

	private ObjectGrabber grabberRef;

	private DogRegistration dogRegRef;

	private Transform mainCamTransform;

	private CursorController cursorRef;

	private void Awake()
	{
		mainCamTransform = Camera.main.transform;
		penFocusRef = mainCamTransform.gameObject.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogHomeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void Start()
	{
		introContent.SetActive(value: true);
		mainContent.SetActive(value: false);
		Setup();
	}

	private void Update()
	{
		if (isRotatingDog)
		{
			cursorRef.SetCursor(CursorController.CursorType.GRABBING2D);
			UpdateDogRotation();
		}
	}

	private void LateUpdate()
	{
		if (slidersToUpdate.Count > 0 && !Input.GetMouseButton(0))
		{
			RebuildDog();
		}
	}

	public void OnIntroFinished()
	{
		introContent.SetActive(value: false);
		mainContent.SetActive(value: true);
		ActivateBuilder();
	}

	public void SetGeneCategory(GeneCategory newGeneCategory, GameObject activeTab = null)
	{
		if (activeGeneTab != null)
		{
			RectTransform component = activeGeneTab.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(inactiveTabPos, component.anchoredPosition.y);
		}
		if (activeTab != null)
		{
			RectTransform component2 = activeTab.GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2(activeTabPos, component2.anchoredPosition.y);
		}
		activeGeneTab = activeTab;
		if (currentGeneCategory != newGeneCategory)
		{
			currentGeneCategory = newGeneCategory;
			RemoveSliders();
			CreateSliders();
			SetInitialSliderValues();
		}
	}

	public void TogglePuppyMode()
	{
		isPuppy = !isPuppy;
		slidersToUpdate.Clear();
		initialSliderValuesSet = false;
		if (!isPuppy)
		{
			puppyButtonTextRef.text = "Adult";
		}
		else
		{
			puppyButtonTextRef.text = "Puppy";
		}
		if (isPuppy)
		{
			CheatEngine.ForceBrainAge(val: false);
		}
		else
		{
			CheatEngine.ForceBrainAge(val: true);
			CheatEngine.cheatRef.debugDogAge = DogAge.ADULT;
		}
		RebuildDog();
	}

	public void CreateDefaultDog()
	{
		slidersToUpdate.Clear();
		initialSliderValuesSet = false;
		currentGene = currentMasterGene.GenerateNewGene();
		needsIntensitySet = true;
		RebuildDog();
	}

	public void StartDogRotation()
	{
		isRotatingDog = true;
		mousePosStart = InputManager.MouseProvider.GetPosition();
		startRot = currentDog.transform.rotation;
	}

	private void UpdateDogRotation()
	{
		if (GameControls.actions.Interact.WasReleased || GameControls.actions.Cancel.WasReleased || GameControls.actions.CloseMenu.WasReleased || InputManager.MouseProvider.GetButtonWasReleased(Mouse.MiddleButton) || currentDog == null)
		{
			isRotatingDog = false;
			return;
		}
		Vector3 vector = InputManager.MouseProvider.GetPosition();
		float num = vector.x - mousePosStart.x;
		float num2 = vector.y - mousePosStart.y;
		Vector3 vector2 = new Vector3(0f, 0f - num, 0f - num2) / 2f;
		currentDog.transform.rotation = Quaternion.Euler(startRot.eulerAngles + vector2);
	}

	public void MutateGene()
	{
		slidersToUpdate.Clear();
		initialSliderValuesSet = false;
		currentGene = MasterDogGene.MutateGenome(currentGene);
		RebuildDog();
	}

	public void RandomizeGene()
	{
		if (!(currentMasterGene == null))
		{
			slidersToUpdate.Clear();
			initialSliderValuesSet = false;
			currentGene = currentMasterGene.GenerateNewGene(randomizeGene: true);
			RebuildDog();
		}
	}

	public void SpawnGeneratedDog()
	{
		GameObject targetRoom = dogHomeRef.GetTargetRoom();
		if (!(targetRoom == null))
		{
			SaveableDogGene saveableDogGene = new SaveableDogGene();
			saveableDogGene.dogGene = currentGene;
			saveableDogGene.geneVersion = MasterDogGene.currentGeneticVersion;
			Vector3 posForRoom = dogHomeRef.GetPosForRoom(0uL, targetRoom);
			dogRegRef.RequestNewDog(posForRoom, Quaternion.identity, saveableDogGene, null, manualDog: false, OnGeneratedDogSpawned);
			currentDogCount++;
			UpdateDogsLeftText();
			if (currentDogCount >= dogMax)
			{
				doneArrowRef.SetActive(value: true);
				spawnButtonRef.GetComponent<Button>().interactable = false;
			}
			RandomizeDogName();
		}
	}

	private void UpdateDogsLeftText()
	{
		int num = dogMax - currentDogCount;
		dogsLeftNumTextRef.text = (dogMax - currentDogCount).ToString();
		if (num == 1)
		{
			dogsLeftNumTextRef.text += " dog left";
		}
		else
		{
			dogsLeftNumTextRef.text += " dogs left";
		}
	}

	public void RandomizeDogName()
	{
		inputField.text = dogRegRef.ChooseRandomDogNameNonDestructive();
	}

	private void OnGeneratedDogSpawned(GameObject newDog)
	{
		SaveableDog saveableDogFromDog = dogRegRef.GetSaveableDogFromDog(newDog);
		saveableDogFromDog.dogName = inputField.text;
		dogRegRef.UpdateSaveableDog(saveableDogFromDog);
		dogRegRef.RefreshSelectedDog();
		newDog.GetComponent<DoggyBrain>().DisableDeath();
		newDog.GetComponent<DoggyBrain>().SetNeedsFrozen(val: true);
		newDog.GetComponent<DogEggLayingController>().enabled = false;
		newDog.GetComponent<DogIndicatorController>().UpdateName(saveableDogFromDog.dogName);
		newDog.GetComponent<DogIndicatorController>().DisableEntireIndicator();
	}

	public void ActivateBuilder()
	{
		if (!builderActive)
		{
			CreateSliders();
			doneArrowRef.SetActive(value: false);
			builderActive = true;
			needsIntensitySet = true;
			dogRegRef.RequestNewDog(base.transform.position, base.transform.localRotation, null, null, manualDog: false, DogCreationCallback, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: false);
			UpdateDogsLeftText();
		}
	}

	private void Setup()
	{
		if (grabberRef != null)
		{
			grabberRef.enabled = false;
		}
		CheatEngine.ToggleUI(val: false, fromScript: true);
		CheatEngine.ToggleAI(val: false, fromScript: true);
		mainCamTransform.GetComponent<PenFocus>().SetInputAllowed(val: false, LockReason.DOG_BUILDER);
		RandomizeDogName();
		DOFRef.aperture = 1f;
	}

	private void OnDisable()
	{
		DeactivateBuilder();
	}

	public void CloseBuilder()
	{
		DeactivateBuilder();
		mainContent.SetActive(value: false);
	}

	private void DeactivateBuilder()
	{
		builderActive = false;
		RemoveSliders();
		Object.Destroy(currentDog);
		if (grabberRef != null)
		{
			grabberRef.enabled = true;
		}
		CheatEngine.ToggleUI(val: true, fromScript: true);
		CheatEngine.ToggleAI(val: true, fromScript: true);
		DOFRef.aperture = 0f;
		if (mainCamTransform != null)
		{
			mainCamTransform.GetComponent<PenFocus>().SetInputAllowed(val: true, LockReason.DOG_BUILDER);
		}
		List<GameObject> allDogs = dogRegRef.GetAllDogs();
		for (int i = 0; i < allDogs.Count; i++)
		{
			if (!(allDogs[i] == null))
			{
				allDogs[i].GetComponent<DoggyBrain>().SetNeedsFrozen(val: false);
				DogIndicatorController component = allDogs[i].GetComponent<DogIndicatorController>();
				if (component != null)
				{
					component.DisableEntireIndicator();
				}
			}
		}
	}

	private void RemoveSliders()
	{
		slidersToUpdate.Clear();
		patternNumSlider = null;
		patternTypeSlider = null;
		patternIntensitySlider = null;
		for (int num = sliders.Count - 1; num >= 0; num--)
		{
			Object.Destroy(sliders[num].gameObject);
		}
		sliders.Clear();
		initialSliderValuesSet = false;
	}

	private void CreateSliders()
	{
		Vector3 position = sliderStartTransform.position;
		Transform parent = sliderStartTransform.parent;
		sliderStartTransform.SetParent(null);
		int num = 0;
		MasterDogGene component = dogRegRef.globalDogprefab.GetComponent<MasterDogGene>();
		for (int i = 0; i < component.dogGenes.Count; i++)
		{
			if (component.dogGenes[i].key == "PatternAlpha")
			{
				patternIntensityGene = component.dogGenes[i];
			}
			if (component.dogGenes[i].key == "PatternNum")
			{
				patternNumGene = component.dogGenes[i];
			}
		}
		if (currentGeneCategory == GeneCategory.PATTERN)
		{
			for (int j = 0; j < component.dogGenes.Count; j++)
			{
				if (component.dogGenes[j].geneCategory == currentGeneCategory)
				{
					if ((component.dogGenes[j].geneType == GeneType.LOOPED && component.dogGenes[j].geneCategory != GeneCategory.PATTERN) || component.dogGenes[j].key == "PatternType")
					{
						AddChoice(component.dogGenes[j], num);
					}
					else
					{
						AddSlider(component.dogGenes[j], num);
					}
					num++;
				}
			}
		}
		else
		{
			for (int num2 = component.dogGenes.Count - 1; num2 >= 0; num2--)
			{
				if (component.dogGenes[num2].geneCategory == currentGeneCategory && !(component.dogGenes[num2].key == "NoseType") && !(component.dogGenes[num2].key == "HeadNumber"))
				{
					if (component.dogGenes[num2].geneType == GeneType.LOOPED)
					{
						AddChoice(component.dogGenes[num2], num);
					}
					else
					{
						AddSlider(component.dogGenes[num2], num);
					}
					num++;
				}
			}
		}
		float num3 = 50f;
		float num4 = (float)sliders.Count * (0f - sliderOffset);
		sliderContent.sizeDelta = new Vector2(0f, num4 + num3);
		sliderStartTransform.SetParent(parent);
		sliderStartTransform.position = position;
		RectTransform component2 = sliderStartTransform.GetComponent<RectTransform>();
		component2.anchoredPosition3D = new Vector3(component2.anchoredPosition3D.x, num4 / 2f - num3, component2.anchoredPosition3D.z);
		verticalScrollbar.value = 1f;
	}

	private void AddSlider(Gene gene, int index)
	{
		GameObject obj = Object.Instantiate(sliderPrefab);
		obj.transform.SetParent(sliderStartTransform);
		obj.transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
		obj.transform.localPosition = new Vector3(0f, (float)index * sliderOffset, 0f);
		DogBuilderSlider component = obj.GetComponent<DogBuilderSlider>();
		component.geneRef = gene;
		string text = component.geneRef.key;
		if (component.geneRef.readableName.Length > 1)
		{
			text = component.geneRef.readableName;
		}
		obj.GetComponentInChildren<TextMeshProUGUI>().text = text;
		Slider component2 = obj.GetComponent<Slider>();
		if (gene.plusMinus)
		{
			component2.minValue = -1f;
			component2.maxValue = 1f;
		}
		else if (gene.geneType == GeneType.LOOPED)
		{
			component2.minValue = 0f;
			component2.maxValue = 1f;
		}
		else
		{
			component2.minValue = 0f;
			component2.maxValue = 1f;
		}
		sliders.Add(component);
		if (gene.key == "PatternAlpha")
		{
			patternIntensitySlider = component2;
		}
		if (gene.key == "PatternType")
		{
			patternTypeSlider = component2;
		}
		if (gene.key == "PatternNum")
		{
			patternNumSlider = component2;
		}
	}

	private void AddChoice(Gene gene, int index)
	{
		GameObject gameObject = Object.Instantiate(choicePrefab);
		gameObject.transform.SetParent(sliderStartTransform);
		gameObject.transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
		gameObject.transform.localPosition = new Vector3(0f, (float)index * sliderOffset, 0f);
		DogBuilderSlider sliderScript = gameObject.GetComponent<DogBuilderSlider>();
		sliderScript.geneRef = gene;
		GeneticProperty geneticPropertyFromKeyString = currentMasterGene.GetGeneticPropertyFromKeyString(gene.key);
		sliderScript.SetMaxValue(currentMasterGene.GetPropertyCountForLoopedGene(geneticPropertyFromKeyString));
		sliderScript.leftButton.onClick.AddListener(delegate
		{
			RequestSliderUpdate(sliderScript);
		});
		sliderScript.rightButton.onClick.AddListener(delegate
		{
			RequestSliderUpdate(sliderScript);
		});
		string text = sliderScript.geneRef.key;
		if (sliderScript.geneRef.readableName.Length > 1)
		{
			text = sliderScript.geneRef.readableName;
		}
		gameObject.transform.Find("GeneNameText").GetComponent<TextMeshProUGUI>().text = text;
		sliders.Add(sliderScript);
	}

	private void RequestSliderUpdate(DogBuilderSlider newSlider)
	{
		if (!slidersToUpdate.Contains(newSlider))
		{
			slidersToUpdate.Add(newSlider);
		}
	}

	public void UpdateSliderControlledGenePlusMinus(Gene geneRef, float newValue)
	{
		GeneticProperty geneticPropertyPlusFromKeyString = currentMasterGene.GetGeneticPropertyPlusFromKeyString(geneRef.key);
		GeneticProperty geneticPropertyMinusFromKeyString = currentMasterGene.GetGeneticPropertyMinusFromKeyString(geneRef.key);
		string geneString = currentMasterGene.GetGeneString(geneticPropertyPlusFromKeyString);
		string geneString2 = currentMasterGene.GetGeneString(geneticPropertyMinusFromKeyString);
		GeneValue geneValues = currentMasterGene.GetGeneValues(geneticPropertyPlusFromKeyString);
		GeneValue geneValues2 = currentMasterGene.GetGeneValues(geneticPropertyMinusFromKeyString);
		float neededVal = 0f;
		float neededVal2 = 0f;
		if (newValue > 0f)
		{
			neededVal = newValue;
		}
		else if (newValue < 0f)
		{
			neededVal2 = 0f - newValue;
		}
		string geneSequenceFromValues = MathUtil.GetGeneSequenceFromValues(neededVal, geneValues.GetMinValue(), geneValues.GetMaxValue(), geneString.Length);
		string geneSequenceFromValues2 = MathUtil.GetGeneSequenceFromValues(neededVal2, geneValues2.GetMinValue(), geneValues2.GetMaxValue(), geneString2.Length);
		currentMasterGene.UpdateGeneString(geneticPropertyPlusFromKeyString, geneSequenceFromValues);
		currentMasterGene.UpdateGeneString(geneticPropertyMinusFromKeyString, geneSequenceFromValues2);
		string fullGene = currentMasterGene.GetFullGene();
		currentGene = fullGene;
	}

	public void UpdateSliderControlledGene(Gene geneRef, float newValue)
	{
		GeneticProperty geneticPropertyFromKeyString = currentMasterGene.GetGeneticPropertyFromKeyString(geneRef.key);
		GeneValue geneValues = currentMasterGene.GetGeneValues(geneticPropertyFromKeyString);
		string geneString = currentMasterGene.GetGeneString(geneticPropertyFromKeyString);
		string geneSequenceFromValues = MathUtil.GetGeneSequenceFromValues(newValue, geneValues.GetMinValue(), geneValues.GetMaxValue(), geneString.Length);
		currentMasterGene.UpdateGeneString(geneticPropertyFromKeyString, geneSequenceFromValues);
		string fullGene = currentMasterGene.GetFullGene();
		currentGene = fullGene;
	}

	public void UpdateSliderControlledGeneLooped(Gene geneRef, float newValue)
	{
		GeneticProperty geneticPropertyFromKeyString = currentMasterGene.GetGeneticPropertyFromKeyString(geneRef.key);
		int length = currentMasterGene.GetStoredGeneStringForKey(geneRef.key).Length;
		string text = "";
		if (geneRef.discrete)
		{
			int length2 = currentMasterGene.GetGeneString(geneticPropertyFromKeyString).Length;
			float num = (float)length2 / (float)length;
			if (length == length2)
			{
				text = MathUtil.GetGeneSequenceFromValues(0f, 0f, 1f, length);
			}
			else
			{
				text = MathUtil.GetGeneSequenceFromValues(0f, 0f, 1f, length - length2);
				int startIndex = Mathf.Min(Mathf.FloorToInt(newValue / num) * length2, length - length2);
				float num2 = newValue % num;
				float neededVal = num2 / num;
				if (num2 == 0f && newValue != 0f)
				{
					neededVal = 1f;
				}
				string geneSequenceFromValues = MathUtil.GetGeneSequenceFromValues(neededVal, 0f, 1f, length2);
				text = text.Insert(startIndex, geneSequenceFromValues);
			}
		}
		else
		{
			text = MathUtil.GetGeneSequenceFromValues(newValue, 0f, 1f, length);
		}
		currentMasterGene.UpdateGeneString(geneticPropertyFromKeyString, text);
		string fullGene = currentMasterGene.GetFullGene();
		currentGene = fullGene;
	}

	public void RebuildDog()
	{
		for (int i = 0; i < slidersToUpdate.Count; i++)
		{
			if (slidersToUpdate[i].geneRef.plusMinus)
			{
				UpdateSliderControlledGenePlusMinus(slidersToUpdate[i].geneRef, slidersToUpdate[i].GetComponent<Slider>().value);
			}
			else if ((slidersToUpdate[i].geneRef.geneType == GeneType.LOOPED && slidersToUpdate[i].geneRef.geneCategory != GeneCategory.PATTERN) || slidersToUpdate[i].geneRef.key == "PatternType")
			{
				UpdateSliderControlledGeneLooped(slidersToUpdate[i].geneRef, slidersToUpdate[i].GetComponent<DogBuilderSlider>().GetChoiceValue());
			}
			else if (slidersToUpdate[i].geneRef.geneType == GeneType.LOOPED)
			{
				UpdateSliderControlledGeneLooped(slidersToUpdate[i].geneRef, slidersToUpdate[i].GetComponent<Slider>().value);
			}
			else
			{
				UpdateSliderControlledGene(slidersToUpdate[i].geneRef, slidersToUpdate[i].GetComponent<Slider>().value);
			}
		}
		slidersToUpdate.Clear();
		penFocusRef.SetBlurUpdate(newVal: false);
		penFocusRef.DisableMotionBlur(MotionBlurLockReason.DOG_BUILDER);
		SaveableDogGene saveableDogGene = new SaveableDogGene();
		saveableDogGene.dogGene = currentGene;
		saveableDogGene.geneVersion = MasterDogGene.currentGeneticVersion;
		DogRegistration dogRegistration = dogRegRef;
		Vector3 position = base.transform.position;
		Quaternion rotation = currentDog.transform.rotation;
		DogRequest.DogRequestCallback callback = DogCreationCallback;
		dogRegistration.RequestNewDog(position, rotation, saveableDogGene, null, manualDog: false, callback, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: false);
	}

	private void DogCreationCallback(GameObject newDog)
	{
		if (currentDog != null)
		{
			Object.Destroy(currentDog);
		}
		currentDog = newDog;
		currentMasterGene = currentDog.GetComponent<MasterDogGene>();
		currentDog.transform.SetParent(builderCam.transform);
		currentDog.transform.localPosition = new Vector3(-4f, 1f, 10f);
		currentGene = currentDog.GetComponent<DogLooks>().dogGene.dogGene;
		currentDog.GetComponent<LegController>().bodyBack.GetComponent<Rigidbody>().isKinematic = true;
		currentDog.GetComponent<LegController>().bodyFront.GetComponent<Rigidbody>().isKinematic = true;
		currentDog.GetComponent<DogAI>().SetEnabled(enabledVal: false);
		Object.Destroy(currentDog.GetComponent<DogIndicatorController>());
		Object.Destroy(currentDog.GetComponent<DogEggLayingController>());
		if (currentRoutine != null)
		{
			StopCoroutine(currentRoutine);
			currentRoutine = null;
		}
		currentRoutine = StartCoroutine(BlurEnable());
		if (!initialSliderValuesSet)
		{
			SetInitialSliderValues();
		}
		if (needsIntensitySet)
		{
			UpdateSliderControlledGene(patternNumGene, 0.5f);
			UpdateSliderControlledGene(patternIntensityGene, 0.5f);
			if (patternIntensitySlider != null)
			{
				patternNumSlider.value = 0.5f;
				patternTypeSlider.value = 0f;
				patternIntensitySlider.value = 0.5f;
			}
		}
		needsIntensitySet = false;
	}

	private IEnumerator BlurEnable()
	{
		yield return new WaitForSeconds(1f);
		penFocusRef.SetBlurUpdate(newVal: true);
		penFocusRef.EnableMotionBlur(MotionBlurLockReason.DOG_BUILDER);
		currentRoutine = null;
	}

	private void SetInitialSliderValues()
	{
		initialSliderValuesSet = true;
		for (int i = 0; i < sliders.Count; i++)
		{
			Gene geneRef = sliders[i].geneRef;
			Slider component = sliders[i].GetComponent<Slider>();
			if (geneRef.plusMinus)
			{
				SetSliderValuePlusMinus(geneRef, component);
			}
			else if ((geneRef.geneType == GeneType.LOOPED && geneRef.geneCategory != GeneCategory.PATTERN) || geneRef.key == "PatternType")
			{
				SetSliderValueLooped(geneRef, sliders[i].GetComponent<DogBuilderSlider>());
			}
			else
			{
				SetSliderValue(geneRef, component);
			}
		}
	}

	private void SetSliderValue(Gene sliderGene, Slider sliderRef)
	{
		float floatFromGeneSequence = MathUtil.GetFloatFromGeneSequence(currentMasterGene.GetStoredGeneStringForKey(sliderGene.key), 0f, 1f);
		sliderRef.onValueChanged.RemoveAllListeners();
		sliderRef.GetComponent<Slider>().value = floatFromGeneSequence;
		sliderRef.onValueChanged.AddListener(delegate
		{
			RequestSliderUpdate(sliderRef.GetComponent<DogBuilderSlider>());
		});
	}

	private void SetSliderValuePlusMinus(Gene sliderGene, Slider sliderRef)
	{
		GeneticProperty geneticPropertyPlusFromKeyString = currentMasterGene.GetGeneticPropertyPlusFromKeyString(sliderGene.key);
		GeneticProperty geneticPropertyMinusFromKeyString = currentMasterGene.GetGeneticPropertyMinusFromKeyString(sliderGene.key);
		string geneString = currentMasterGene.GetGeneString(geneticPropertyPlusFromKeyString);
		string geneString2 = currentMasterGene.GetGeneString(geneticPropertyMinusFromKeyString);
		float floatFromGeneSequence = MathUtil.GetFloatFromGeneSequence(geneString, 0f, 1f);
		float floatFromGeneSequence2 = MathUtil.GetFloatFromGeneSequence(geneString2, 0f, 1f);
		float value = floatFromGeneSequence - floatFromGeneSequence2;
		sliderRef.onValueChanged.RemoveAllListeners();
		sliderRef.GetComponent<Slider>().value = value;
		sliderRef.onValueChanged.AddListener(delegate
		{
			RequestSliderUpdate(sliderRef.GetComponent<DogBuilderSlider>());
		});
	}

	private void SetSliderValueLooped(Gene sliderGene, DogBuilderSlider sliderRef)
	{
		GeneticProperty geneticPropertyFromKeyString = currentMasterGene.GetGeneticPropertyFromKeyString(sliderGene.key);
		int activeLoopedGeneSet = currentMasterGene.GetActiveLoopedGeneSet(geneticPropertyFromKeyString);
		sliderRef.SetCurrentValue(activeLoopedGeneSet + 1);
	}
}
