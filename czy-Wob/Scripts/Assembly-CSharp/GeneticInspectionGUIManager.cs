using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneticInspectionGUIManager : MonoBehaviour
{
	public DogStorageGUIManager storageGUIRef;

	public GameObject storageDogTransform;

	public Transform geneticInspectionDogTransformAdult;

	public Transform geneticInspectionDogTransformYoungAdult;

	public Transform geneticInspectionDogTransformTeen;

	public Transform geneticInspectionDogTransformChild;

	public Transform geneticInspectionDogTransformPuppy;

	public GameObject colorInfo;

	public GameObject geneticInfo;

	public Transform geneticContentHolder;

	public Transform geneticContentHolderDomRec;

	public TextMeshProUGUI headerText;

	public TextMeshProUGUI domRecGeneString;

	private string storedDomRecGeneString;

	private List<GeneticDomRecProperty> currentLinkedProperties = new List<GeneticDomRecProperty>();

	public GameObject loadingDogText;

	public Transform dogRotationTransform;

	public Camera legColorCam;

	public Camera bodyColorCam;

	public Camera noseEarColorCam;

	public Renderer legColorRenderer;

	public Renderer bodyColorRenderer;

	public Renderer noseEarColorRenderer;

	public Color selectedAgeColor;

	public TextMeshProUGUI ageText;

	public CoreSliderUnityGUI ageSliderPuppy;

	public CoreSliderUnityGUI ageSliderChild;

	public CoreSliderUnityGUI ageSliderTeen;

	public CoreSliderUnityGUI ageSliderYoungAdult;

	public CoreSliderUnityGUI ageSliderAdult;

	private CoreSliderUnityGUI currentAgeSlider;

	public List<Image> ageCirclesPuppy;

	public List<Image> ageCirclesChild;

	public List<Image> ageCirclesTeen;

	public List<Image> ageCirclesYoungAdult;

	public List<Image> ageCirclesAdult;

	public GameObject domRecInfoPopup;

	private DogAge currentDogAge;

	private DogAge startingDogAge;

	private SaveableDogGene currentDogGene;

	private SaveableDogProfile currentDogProfile;

	private float currentDogAgeProgress = -1f;

	private bool currentDogIsGhost;

	private bool isLoadingDog;

	private bool needsDogRefresh;

	private bool firstPass;

	private GameObject activeRotationDog;

	private GameObject rotationDogAdult;

	private GameObject rotationDogYoungAdult;

	private GameObject rotationDogTeen;

	private GameObject rotationDogChild;

	private GameObject rotationDogPuppy;

	private string mysteryString = "????????";

	private string mysteryValueString = "???";

	private List<GeneInfo> geneticsList = new List<GeneInfo>();

	private bool GUIClosed;

	private DogRegistration dogRegRef;

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			OnExitButtonPressed();
		}
	}

	private void OnEnable()
	{
		GUIClosed = false;
		storageDogTransform.SetActive(value: false);
		colorInfo.SetActive(value: false);
		domRecInfoPopup.SetActive(value: false);
		legColorCam.gameObject.SetActive(value: true);
		bodyColorCam.gameObject.SetActive(value: true);
		noseEarColorCam.gameObject.SetActive(value: true);
		firstPass = true;
		currentDogGene = null;
		domRecGeneString.text = "";
		currentDogAge = DogAge.NONE;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void OnDisable()
	{
		GUIClosed = true;
		storageDogTransform.SetActive(value: true);
		legColorCam.gameObject.SetActive(value: false);
		bodyColorCam.gameObject.SetActive(value: false);
		noseEarColorCam.gameObject.SetActive(value: false);
		DestroyRotationDogs();
		ClearAllGeneticInfos();
	}

	public void OnExitButtonPressed()
	{
		if (domRecInfoPopup.activeSelf)
		{
			CloseDomRecInfoPopup();
			return;
		}
		GUIClosed = true;
		storageGUIRef.CloseGeneticInspectionGUIManager();
	}

	public void OpenDomRecInfoPopup()
	{
		domRecInfoPopup.SetActive(value: true);
	}

	public void CloseDomRecInfoPopup()
	{
		domRecInfoPopup.SetActive(value: false);
	}

	public void SetSaveableDog(SaveableDog dog)
	{
		SetStartingDogAge(dog.brain.dogAge);
		CreateRotationDog(dog);
		UpdateHeader(dog.dogName);
	}

	public void SetSaveableDogCore(SaveableDogCore core)
	{
		SetStartingDogAge(core.dogAge);
		CreateRotationDog(core);
		UpdateHeader(core.dogName);
	}

	public void SetDogCore(DogCore core)
	{
		SetStartingDogAge(core.dogAge);
		CreateRotationDog(core);
		UpdateHeader(core.dogName);
	}

	public void SetDogMemorial(DogMemorial memorial)
	{
		SetStartingDogAge(memorial.dogAge);
		CreateRotationDog(memorial);
		UpdateHeader(memorial.dogName);
	}

	private void SetStartingDogAge(DogAge newAge)
	{
		if (newAge == DogAge.ANCIENT)
		{
			newAge = DogAge.ADULT;
		}
		startingDogAge = newAge;
		SetAgeSliderForStartingAge();
		currentAgeSlider.SetValueWithoutNotify((float)newAge);
		OnAgeValueChanged();
	}

	private void SetAgeSliderForStartingAge()
	{
		if (startingDogAge == DogAge.NONE || startingDogAge == DogAge.ANCIENT)
		{
			Debug.LogError("Invalid starting dog age. Forcing to Adult.");
			startingDogAge = DogAge.ADULT;
		}
		ageSliderPuppy.gameObject.SetActive(value: false);
		ageSliderChild.gameObject.SetActive(value: false);
		ageSliderTeen.gameObject.SetActive(value: false);
		ageSliderYoungAdult.gameObject.SetActive(value: false);
		ageSliderAdult.gameObject.SetActive(value: false);
		switch (startingDogAge)
		{
		case DogAge.PUPPY:
			currentAgeSlider = ageSliderPuppy;
			break;
		case DogAge.CHILD:
			currentAgeSlider = ageSliderChild;
			break;
		case DogAge.TEEN:
			currentAgeSlider = ageSliderTeen;
			break;
		case DogAge.YOUNG_ADULT:
			currentAgeSlider = ageSliderYoungAdult;
			break;
		case DogAge.ADULT:
			currentAgeSlider = ageSliderAdult;
			break;
		}
		currentAgeSlider.gameObject.SetActive(value: true);
	}

	public void OnAgeValueChanged()
	{
		DogAge dogAge = (DogAge)currentAgeSlider.value;
		if (dogAge == currentDogAge)
		{
			return;
		}
		currentDogAge = dogAge;
		ageText.text = DoggyBrain.GetReadableNameForDogAge(currentDogAge);
		if (currentDogAge == DogAge.PUPPY)
		{
			for (int i = 0; i < ageCirclesPuppy.Count; i++)
			{
				ageCirclesPuppy[i].color = selectedAgeColor;
			}
			for (int j = 0; j < ageCirclesChild.Count; j++)
			{
				ageCirclesChild[j].color = Color.white;
			}
			for (int k = 0; k < ageCirclesTeen.Count; k++)
			{
				ageCirclesTeen[k].color = Color.white;
			}
			for (int l = 0; l < ageCirclesYoungAdult.Count; l++)
			{
				ageCirclesYoungAdult[l].color = Color.white;
			}
			for (int m = 0; m < ageCirclesAdult.Count; m++)
			{
				ageCirclesAdult[m].color = Color.white;
			}
		}
		else if (currentDogAge == DogAge.CHILD)
		{
			for (int n = 0; n < ageCirclesPuppy.Count; n++)
			{
				ageCirclesPuppy[n].color = selectedAgeColor;
			}
			for (int num = 0; num < ageCirclesChild.Count; num++)
			{
				ageCirclesChild[num].color = selectedAgeColor;
			}
			for (int num2 = 0; num2 < ageCirclesTeen.Count; num2++)
			{
				ageCirclesTeen[num2].color = Color.white;
			}
			for (int num3 = 0; num3 < ageCirclesYoungAdult.Count; num3++)
			{
				ageCirclesYoungAdult[num3].color = Color.white;
			}
			for (int num4 = 0; num4 < ageCirclesAdult.Count; num4++)
			{
				ageCirclesAdult[num4].color = Color.white;
			}
		}
		else if (currentDogAge == DogAge.TEEN)
		{
			for (int num5 = 0; num5 < ageCirclesPuppy.Count; num5++)
			{
				ageCirclesPuppy[num5].color = selectedAgeColor;
			}
			for (int num6 = 0; num6 < ageCirclesChild.Count; num6++)
			{
				ageCirclesChild[num6].color = selectedAgeColor;
			}
			for (int num7 = 0; num7 < ageCirclesTeen.Count; num7++)
			{
				ageCirclesTeen[num7].color = selectedAgeColor;
			}
			for (int num8 = 0; num8 < ageCirclesYoungAdult.Count; num8++)
			{
				ageCirclesYoungAdult[num8].color = Color.white;
			}
			for (int num9 = 0; num9 < ageCirclesAdult.Count; num9++)
			{
				ageCirclesAdult[num9].color = Color.white;
			}
		}
		else if (currentDogAge == DogAge.YOUNG_ADULT)
		{
			for (int num10 = 0; num10 < ageCirclesPuppy.Count; num10++)
			{
				ageCirclesPuppy[num10].color = selectedAgeColor;
			}
			for (int num11 = 0; num11 < ageCirclesChild.Count; num11++)
			{
				ageCirclesChild[num11].color = selectedAgeColor;
			}
			for (int num12 = 0; num12 < ageCirclesTeen.Count; num12++)
			{
				ageCirclesTeen[num12].color = selectedAgeColor;
			}
			for (int num13 = 0; num13 < ageCirclesYoungAdult.Count; num13++)
			{
				ageCirclesYoungAdult[num13].color = selectedAgeColor;
			}
			for (int num14 = 0; num14 < ageCirclesAdult.Count; num14++)
			{
				ageCirclesAdult[num14].color = Color.white;
			}
		}
		else if (currentDogAge == DogAge.ADULT)
		{
			for (int num15 = 0; num15 < ageCirclesPuppy.Count; num15++)
			{
				ageCirclesPuppy[num15].color = selectedAgeColor;
			}
			for (int num16 = 0; num16 < ageCirclesChild.Count; num16++)
			{
				ageCirclesChild[num16].color = selectedAgeColor;
			}
			for (int num17 = 0; num17 < ageCirclesTeen.Count; num17++)
			{
				ageCirclesTeen[num17].color = selectedAgeColor;
			}
			for (int num18 = 0; num18 < ageCirclesYoungAdult.Count; num18++)
			{
				ageCirclesYoungAdult[num18].color = selectedAgeColor;
			}
			for (int num19 = 0; num19 < ageCirclesAdult.Count; num19++)
			{
				ageCirclesAdult[num19].color = selectedAgeColor;
			}
		}
		CreateRotationDogInternal();
	}

	private void UpdateHeader(string dogName)
	{
		headerText.text = ScriptLocalization.GUI.GUI_GENINSP_HEADER;
		headerText.text = headerText.text.Replace("[DOG NAME]", dogName);
		headerText.GetComponent<TextScaleInOnLoad>().RequestScaleIn();
	}

	private void CreateRotationDog(DogMemorial am)
	{
		currentDogGene = am.dogGene;
		currentDogProfile = am.dogProfile;
		currentDogAgeProgress = 0f;
		currentDogIsGhost = false;
		CreateRotationDogInternal();
	}

	private void CreateRotationDog(SaveableDog sd)
	{
		currentDogGene = sd.dogGene;
		currentDogProfile = sd.dogProfile;
		currentDogAgeProgress = sd.brain.dogAgeProgress;
		currentDogIsGhost = sd.isGhost;
		CreateRotationDogInternal();
	}

	private void CreateRotationDog(SaveableDogCore sc)
	{
		currentDogGene = sc.dogGene;
		currentDogProfile = sc.dogProfile;
		currentDogAgeProgress = 0f;
		currentDogIsGhost = false;
		CreateRotationDogInternal();
	}

	private void CreateRotationDog(DogCore ac)
	{
		currentDogGene = ac.dogGene;
		currentDogProfile = ac.dogProfile;
		currentDogAgeProgress = 0f;
		currentDogIsGhost = false;
		CreateRotationDogInternal();
	}

	private void DestroyRotationDogs()
	{
		activeRotationDog = null;
		if (rotationDogAdult != null)
		{
			Object.Destroy(rotationDogAdult);
			rotationDogAdult = null;
		}
		if (rotationDogYoungAdult != null)
		{
			Object.Destroy(rotationDogYoungAdult);
			rotationDogYoungAdult = null;
		}
		if (rotationDogTeen != null)
		{
			Object.Destroy(rotationDogTeen);
			rotationDogTeen = null;
		}
		if (rotationDogChild != null)
		{
			Object.Destroy(rotationDogChild);
			rotationDogChild = null;
		}
		if (rotationDogPuppy != null)
		{
			Object.Destroy(rotationDogPuppy);
			rotationDogPuppy = null;
		}
	}

	private void CreateRotationDogInternal()
	{
		if (isLoadingDog)
		{
			needsDogRefresh = true;
		}
		else
		{
			if (currentDogGene == null)
			{
				return;
			}
			if (activeRotationDog != null)
			{
				if (rotationDogPuppy != null)
				{
					rotationDogPuppy.transform.SetParent(geneticInspectionDogTransformPuppy);
					rotationDogPuppy.transform.localPosition = Vector3.zero;
				}
				if (rotationDogChild != null)
				{
					rotationDogChild.transform.SetParent(geneticInspectionDogTransformChild);
					rotationDogChild.transform.localPosition = Vector3.zero;
				}
				if (rotationDogTeen != null)
				{
					rotationDogTeen.transform.SetParent(geneticInspectionDogTransformTeen);
					rotationDogTeen.transform.localPosition = Vector3.zero;
				}
				if (rotationDogYoungAdult != null)
				{
					rotationDogYoungAdult.transform.SetParent(geneticInspectionDogTransformYoungAdult);
					rotationDogYoungAdult.transform.localPosition = Vector3.zero;
				}
				if (rotationDogAdult != null)
				{
					rotationDogAdult.transform.SetParent(geneticInspectionDogTransformAdult);
					rotationDogAdult.transform.localPosition = Vector3.zero;
				}
			}
			activeRotationDog = null;
			if (currentDogAge == DogAge.PUPPY && rotationDogPuppy != null)
			{
				activeRotationDog = rotationDogPuppy;
			}
			else if (currentDogAge == DogAge.CHILD && rotationDogChild != null)
			{
				activeRotationDog = rotationDogChild;
			}
			else if (currentDogAge == DogAge.TEEN && rotationDogTeen != null)
			{
				activeRotationDog = rotationDogTeen;
			}
			else if (currentDogAge == DogAge.YOUNG_ADULT && rotationDogYoungAdult != null)
			{
				activeRotationDog = rotationDogYoungAdult;
			}
			else if (currentDogAge == DogAge.ADULT && rotationDogAdult != null)
			{
				activeRotationDog = rotationDogAdult;
			}
			if (activeRotationDog != null)
			{
				OnNewDogCreated(activeRotationDog);
				return;
			}
			string storedDogCodeForAge = GetStoredDogCodeForAge(currentDogAge);
			SaveableDogGene saveableDogGeneFromCode = currentDogGene;
			if (storedDogCodeForAge != null && storedDogCodeForAge.Length > 0)
			{
				saveableDogGeneFromCode = dogRegRef.GetSaveableDogGeneFromCode(storedDogCodeForAge);
			}
			else if (currentDogAge > startingDogAge)
			{
				saveableDogGeneFromCode = currentDogGene;
			}
			else if (currentDogAge < startingDogAge)
			{
				for (int i = 1; i < (int)startingDogAge; i++)
				{
					string storedDogCodeForAge2 = GetStoredDogCodeForAge((DogAge)i);
					if (storedDogCodeForAge2 != null && storedDogCodeForAge2.Length > 0)
					{
						saveableDogGeneFromCode = dogRegRef.GetSaveableDogGeneFromCode(storedDogCodeForAge2);
						break;
					}
				}
			}
			isLoadingDog = true;
			loadingDogText.SetActive(value: true);
			dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, saveableDogGeneFromCode, null, manualDog: false, dogProfile: currentDogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: currentDogAge, customDogAgeProgress: currentDogAgeProgress, traitsAllowed: true, useTemporaryID: false, customDogPersonality: null, customFloraPool: null, respectMaxDogs: true, isGhost: currentDogIsGhost);
		}
	}

	private string GetStoredDogCodeForAge(DogAge age)
	{
		switch (age)
		{
		case DogAge.PUPPY:
			return currentDogGene.puppyCode;
		case DogAge.CHILD:
			return currentDogGene.childCode;
		case DogAge.TEEN:
			return currentDogGene.teenCode;
		case DogAge.YOUNG_ADULT:
			return currentDogGene.youngAdultCode;
		default:
			return null;
		}
	}

	private void OnNewDogCreated(GameObject dog)
	{
		if (GUIClosed)
		{
			Object.Destroy(dog);
			return;
		}
		isLoadingDog = false;
		if (needsDogRefresh)
		{
			Object.Destroy(dog);
			needsDogRefresh = false;
			CreateRotationDogInternal();
			return;
		}
		activeRotationDog = dog;
		if (currentDogAge == DogAge.PUPPY)
		{
			rotationDogPuppy = dog;
		}
		else if (currentDogAge == DogAge.CHILD)
		{
			rotationDogChild = dog;
		}
		else if (currentDogAge == DogAge.TEEN)
		{
			rotationDogTeen = dog;
		}
		else if (currentDogAge == DogAge.YOUNG_ADULT)
		{
			rotationDogYoungAdult = dog;
		}
		else if (currentDogAge == DogAge.ADULT)
		{
			rotationDogAdult = dog;
		}
		loadingDogText.SetActive(value: false);
		dogRegRef.MakeDogSuitableForUIDisplay(dog);
		dog.transform.SetParent(dogRotationTransform);
		dog.transform.localPosition = Vector3.zero;
		ShowDogGenetics(!firstPass);
	}

	private void ShowDogGenetics(bool refresh = false)
	{
		if (!refresh)
		{
			ClearAllGeneticInfos();
		}
		if (activeRotationDog == null)
		{
			return;
		}
		firstPass = false;
		DogLooks component = activeRotationDog.GetComponent<DogLooks>();
		Material legMaterial = component.GetLegMaterial();
		Material bodyMainMaterial = component.GetBodyMainMaterial();
		Material noseEarMaterial = component.GetNoseEarMaterial();
		Material bodyPatternMaterial = component.GetBodyPatternMaterial();
		colorInfo.SetActive(value: true);
		noseEarColorRenderer.material = noseEarMaterial;
		legColorRenderer.material = new Material(legMaterial);
		bodyColorRenderer.materials = new Material[2] { bodyMainMaterial, bodyPatternMaterial };
		legColorRenderer.material.SetFloat("_Chub", 0f);
		int num = 0;
		MasterDogGene component2 = activeRotationDog.GetComponent<MasterDogGene>();
		for (int i = 0; i < component2.dogGenes.Count; i++)
		{
			Gene gene = component2.dogGenes[i];
			if (gene.geneSwapCategory == GeneSwapCategory.COLOR_SWAP)
			{
				continue;
			}
			GeneticProperty geneticProperty = ((!gene.plusMinus) ? component2.GetGeneticPropertyFromKeyString(gene.key) : component2.GetGeneticPropertyFromKeyString(component2.GetPlusStringForGene(gene.key)));
			if (geneticProperty == GeneticProperty.HeadNumber || geneticProperty == GeneticProperty.TailNum || geneticProperty == GeneticProperty.WingNumber || geneticProperty == GeneticProperty.LegPairsFront || geneticProperty == GeneticProperty.LegPairsBack)
			{
				continue;
			}
			float geneValue = 0f;
			float minValue = 0f;
			float maxValue = 0f;
			if (gene.plusMinus)
			{
				GeneticProperty geneticPropertyFromKeyString = component2.GetGeneticPropertyFromKeyString(component2.GetPlusStringForGene(gene.key));
				GeneticProperty geneticPropertyFromKeyString2 = component2.GetGeneticPropertyFromKeyString(component2.GetMinusStringForGene(gene.key));
				maxValue = component2.GetGeneValues(geneticPropertyFromKeyString).GetDefaultMaxValue();
				minValue = 0f - component2.GetGeneValues(geneticPropertyFromKeyString2).GetDefaultMaxValue();
				geneValue = component2.GetGeneValues(geneticPropertyFromKeyString).GetValue() - component2.GetGeneValues(geneticPropertyFromKeyString2).GetValue();
				float? trueMaxValueForDisplay = component2.GetGeneValues(geneticPropertyFromKeyString).GetTrueMaxValueForDisplay();
				if (trueMaxValueForDisplay.HasValue)
				{
					maxValue = trueMaxValueForDisplay.Value;
					geneValue = component2.GetGeneValues(geneticPropertyFromKeyString).GetTrueValueForDisplay().Value - component2.GetGeneValues(geneticPropertyFromKeyString2).GetValue();
				}
			}
			else if (gene.geneType != GeneType.LOOPED)
			{
				GeneticProperty geneticPropertyFromKeyString3 = component2.GetGeneticPropertyFromKeyString(gene.key);
				minValue = component2.GetGeneValues(geneticPropertyFromKeyString3).GetMinValue();
				maxValue = component2.GetGeneValues(geneticPropertyFromKeyString3).GetDefaultMaxValue();
				geneValue = component2.GetGeneValues(geneticPropertyFromKeyString3).GetValue();
			}
			string text = gene.localizedName;
			switch (geneticProperty)
			{
			case GeneticProperty.WingSizePlus:
			case GeneticProperty.WingSizeMinus:
				if (GoalsController.GetCounterForCondition(GoalCondition.WINGS) == 0 && GoalsController.GetCounterForCondition(GoalCondition.ONE_WING) == 0)
				{
					text = mysteryString;
				}
				break;
			case GeneticProperty.HornSizePlus:
			case GeneticProperty.HornSizeMinus:
				if (GoalsController.GetCounterForCondition(GoalCondition.HORNS) == 0)
				{
					text = mysteryString;
				}
				break;
			}
			if (refresh)
			{
				if (text != mysteryString)
				{
					geneticsList[num].UpdateValues(geneValue, minValue, maxValue);
				}
				num++;
			}
			else
			{
				AddMutationInfoToGUI(text, geneValue, minValue, maxValue, text == mysteryString);
			}
		}
		num = 0;
		for (int j = 0; j < component2.dogGenes.Count; j++)
		{
			Gene gene2 = component2.dogGenes[j];
			if (gene2.geneSwapCategory == GeneSwapCategory.COLOR_SWAP)
			{
				continue;
			}
			GeneticProperty geneticProperty2 = ((!gene2.plusMinus) ? component2.GetGeneticPropertyFromKeyString(gene2.key) : component2.GetGeneticPropertyFromKeyString(component2.GetPlusStringForGene(gene2.key)));
			string text2 = gene2.localizedName;
			switch (geneticProperty2)
			{
			case GeneticProperty.HeadNumber:
				if (GoalsController.GetCounterForCondition(GoalCondition.MULTIPLE_HEADS) == 0)
				{
					text2 = mysteryString;
				}
				break;
			case GeneticProperty.TailNum:
				if (GoalsController.GetCounterForCondition(GoalCondition.MULTIPLE_TAILS) == 0)
				{
					text2 = mysteryString;
				}
				break;
			case GeneticProperty.WingNumber:
				if (GoalsController.GetCounterForCondition(GoalCondition.WINGS) == 0 && GoalsController.GetCounterForCondition(GoalCondition.ONE_WING) == 0)
				{
					text2 = mysteryString;
				}
				break;
			case GeneticProperty.LegPairsFront:
			case GeneticProperty.LegPairsBack:
				if (GoalsController.GetCounterForCondition(GoalCondition.MORE_THAN_4_LEGS) == 0)
				{
					text2 = mysteryString;
				}
				break;
			}
			switch (geneticProperty2)
			{
			case GeneticProperty.HeadNumber:
			{
				string text7 = component.GetHeadCount().ToString();
				if (text2 == mysteryString)
				{
					text7 = mysteryValueString;
				}
				if (refresh)
				{
					geneticsList[num].UpdateCenteredNumberValue(text7);
				}
				else
				{
					AddTextMutationInfoToGUI(text2, text7, null, number: true);
				}
				break;
			}
			case GeneticProperty.TailNum:
			{
				string text6 = component.GetTailNumber().ToString();
				if (text2 == mysteryString)
				{
					text6 = mysteryValueString;
				}
				if (refresh)
				{
					geneticsList[num].UpdateCenteredNumberValue(text6);
				}
				else
				{
					AddTextMutationInfoToGUI(text2, text6, null, number: true);
				}
				break;
			}
			case GeneticProperty.WingNumber:
			{
				string text4 = component.GetWingNumber().ToString();
				if (text2 == mysteryString)
				{
					text4 = mysteryValueString;
				}
				if (refresh)
				{
					geneticsList[num].UpdateCenteredNumberValue(text4);
				}
				else
				{
					AddTextMutationInfoToGUI(text2, text4, null, number: true);
				}
				break;
			}
			case GeneticProperty.LegPairsFront:
			{
				string text5 = component.GetFrontLegPairCount().ToString();
				if (text2 == mysteryString)
				{
					text5 = mysteryValueString;
				}
				if (refresh)
				{
					geneticsList[num].UpdateCenteredNumberValue(text5);
				}
				else
				{
					AddTextMutationInfoToGUI(text2, text5, null, number: true);
				}
				break;
			}
			case GeneticProperty.LegPairsBack:
			{
				string text3 = component.GetBackLegPairCount().ToString();
				if (text2 == mysteryString)
				{
					text3 = mysteryValueString;
				}
				if (refresh)
				{
					geneticsList[num].UpdateCenteredNumberValue(text3);
				}
				else
				{
					AddTextMutationInfoToGUI(text2, text3, null, number: true);
				}
				break;
			}
			}
			if (refresh)
			{
				num++;
			}
		}
		if (refresh)
		{
			return;
		}
		bool domRecPropertyStatus = component2.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_LEFT_LEG);
		bool domRecPropertyStatus2 = component2.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_RIGHT_LEG);
		bool domRecPropertyStatus3 = component2.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_LEFT_LEG);
		bool domRecPropertyStatus4 = component2.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_RIGHT_LEG);
		string text8 = "";
		if (domRecPropertyStatus)
		{
			text8 += ScriptLocalization.Genetics.DOMREC_MISSINGLEG_FRONTLEFT;
		}
		if (domRecPropertyStatus2)
		{
			if (text8.Length > 0)
			{
				text8 += ", ";
			}
			text8 += ScriptLocalization.Genetics.DOMREC_MISSINGLEG_FRONTRIGHT;
		}
		if (domRecPropertyStatus3)
		{
			if (text8.Length > 0)
			{
				text8 += ", ";
			}
			text8 += ScriptLocalization.Genetics.DOMREC_MISSINGLEG_BACKLEFT;
		}
		if (domRecPropertyStatus4)
		{
			if (text8.Length > 0)
			{
				text8 += ", ";
			}
			text8 += ScriptLocalization.Genetics.DOMREC_MISSINGLEG_BACKRIGHT;
		}
		if (!domRecPropertyStatus && !domRecPropertyStatus2 && !domRecPropertyStatus3 && !domRecPropertyStatus4)
		{
			text8 = ScriptLocalization.Genetics.DOMREC_MISSING_NONE;
		}
		else if (domRecPropertyStatus && domRecPropertyStatus2 && domRecPropertyStatus3 && domRecPropertyStatus4)
		{
			text8 = ScriptLocalization.Genetics.DOMREC_MISSING_ALL;
		}
		bool domRecPropertyStatus5 = component2.GetDomRecPropertyStatus(GeneticDomRecProperty.WING_ISSUES);
		bool flag = component2.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_LEFT_WING);
		bool flag2 = component2.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_RIGHT_WING);
		if (!domRecPropertyStatus5)
		{
			flag = false;
			flag2 = false;
		}
		string text9 = "";
		if (flag)
		{
			text9 += ScriptLocalization.Genetics.DOMREC_MISSINGWING_LEFT;
		}
		if (flag2)
		{
			if (text9.Length > 0)
			{
				text9 += ", ";
			}
			text9 += ScriptLocalization.Genetics.DOMREC_MISSINGWING_RIGHT;
		}
		if (!flag && !flag2)
		{
			text9 = ScriptLocalization.Genetics.DOMREC_MISSING_NONE;
		}
		else if (flag && flag2)
		{
			text9 = ScriptLocalization.Genetics.DOMREC_MISSING_ALL;
		}
		DogNoises component3 = activeRotationDog.GetComponent<DogNoises>();
		FaceController component4 = activeRotationDog.GetComponent<FaceController>();
		string dOMREC_HORNS = ScriptLocalization.Genetics.DOMREC_HORNS;
		string hornName = component.GetHornName();
		string dOMREC_HORN_STYLE = ScriptLocalization.Genetics.DOMREC_HORN_STYLE;
		string hornStyle = component.GetHornStyle();
		string dOMREC_WINGS = ScriptLocalization.Genetics.DOMREC_WINGS;
		string wingName = component.GetWingName();
		string dOMREC_MISSING_WINGS = ScriptLocalization.Genetics.DOMREC_MISSING_WINGS;
		if (GoalsController.GetCounterForCondition(GoalCondition.HORNS) == 0)
		{
			dOMREC_HORNS = mysteryString;
			dOMREC_HORN_STYLE = mysteryString;
			hornName = mysteryValueString;
			hornStyle = mysteryValueString;
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.WINGS) == 0 && GoalsController.GetCounterForCondition(GoalCondition.ONE_WING) == 0)
		{
			dOMREC_WINGS = mysteryString;
			dOMREC_MISSING_WINGS = mysteryString;
			wingName = mysteryValueString;
			text9 = mysteryValueString;
		}
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_PATTERN, component.GetPatternTypeString(), new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.NO_PATTERN,
			GeneticDomRecProperty.SPLOTCH_PATTERN,
			GeneticDomRecProperty.STRIPE_PATTERN,
			GeneticDomRecProperty.REPEATING_PATTERN
		});
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_MISSING_LEGS, text8, new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.MISSING_BACK_LEFT_LEG,
			GeneticDomRecProperty.MISSING_BACK_RIGHT_LEG,
			GeneticDomRecProperty.MISSING_FRONT_LEFT_LEG,
			GeneticDomRecProperty.MISSING_FRONT_RIGHT_LEG
		});
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_VOICE, component3.GetCurrentVoiceSetName(), new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.VOICE_HOARSE,
			GeneticDomRecProperty.VOICE_PITCH_LOW,
			GeneticDomRecProperty.VOICE_PITCH_HIGH
		});
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_EYES, component4.GetCurrentFaceSetName(), new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.EYELIDS,
			GeneticDomRecProperty.OBLONG_EYES,
			GeneticDomRecProperty.SMALL_PUPILS,
			GeneticDomRecProperty.MULTI_PUPILS,
			GeneticDomRecProperty.GEOMETRIC_EYES,
			GeneticDomRecProperty.DECORATIVE_EYES,
			GeneticDomRecProperty.LASHES_EYES,
			GeneticDomRecProperty.LONG_EYES,
			GeneticDomRecProperty.MISSING_PUPIL_EYES,
			GeneticDomRecProperty.HORIZONTAL_EYES,
			GeneticDomRecProperty.SPIRAL_EYES,
			GeneticDomRecProperty.TRIANGLE_EYES
		});
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_MOUTH, component4.GetCurrentMouthName(), new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.TEETH,
			GeneticDomRecProperty.V_MOUTH,
			GeneticDomRecProperty.MOUTH_SMILE,
			GeneticDomRecProperty.MOUTH_FROWN,
			GeneticDomRecProperty.MOUTH_CHEEKS,
			GeneticDomRecProperty.MOUTH_CUTOFF,
			GeneticDomRecProperty.MOUTH_WIGGLE,
			GeneticDomRecProperty.OPEN_MOUTH,
			GeneticDomRecProperty.MOUTH_POINTED,
			GeneticDomRecProperty.MOUTH_NEUTRAL,
			GeneticDomRecProperty.MOUTH_MISSING_TEETH
		});
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_NOSE, component.GetNoseName(), new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.NOSE_FLAT,
			GeneticDomRecProperty.NOSE_SQUISH,
			GeneticDomRecProperty.NOSE_STRETCH,
			GeneticDomRecProperty.NOSE_REPEATED,
			GeneticDomRecProperty.NOSE_EXTRUSION
		});
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_EARS, component.GetEarName(), new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.EAR_SHARP,
			GeneticDomRecProperty.EAR_CONIC,
			GeneticDomRecProperty.EAR_FILLED,
			GeneticDomRecProperty.EAR_FLOPPY,
			GeneticDomRecProperty.EAR_HALVED,
			GeneticDomRecProperty.TILTED_EARS,
			GeneticDomRecProperty.EAR_PARTIAL_FLOP
		});
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_EAR_CURL, component.GetSyncedCurlString(), new List<GeneticDomRecProperty> { GeneticDomRecProperty.EAR_CURL_SYNCED });
		AddTextMutationInfoToGUI(dOMREC_HORNS, hornName, new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.HORNS_NONE,
			GeneticDomRecProperty.HORNS_CURLED,
			GeneticDomRecProperty.HORNS_NUB,
			GeneticDomRecProperty.HORNS_THICK,
			GeneticDomRecProperty.HORNS_THIN
		});
		AddTextMutationInfoToGUI(dOMREC_HORN_STYLE, hornStyle, new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.HORNS_TRADITIONAL,
			GeneticDomRecProperty.HORNS_CURLED
		});
		AddTextMutationInfoToGUI(ScriptLocalization.Genetics.DOMREC_TAIL, component.GetTailName(), new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.NO_TAIL,
			GeneticDomRecProperty.THIN_TAIL,
			GeneticDomRecProperty.NUB_TAIL,
			GeneticDomRecProperty.FLAT_TAIL,
			GeneticDomRecProperty.STIFF_TAIL,
			GeneticDomRecProperty.BULBOUS_TAIL,
			GeneticDomRecProperty.TAIL_3D,
			GeneticDomRecProperty.REPEATED_TAIL,
			GeneticDomRecProperty.CURLED_TAIL,
			GeneticDomRecProperty.SLIGHTLY_CURLED_TAIL
		});
		AddTextMutationInfoToGUI(dOMREC_WINGS, wingName, new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.NO_WINGS,
			GeneticDomRecProperty.ALIGNMENT_EVIL,
			GeneticDomRecProperty.ALIGNMENT_GOOD,
			GeneticDomRecProperty.ALIGNMENT_NEUTRAL,
			GeneticDomRecProperty.WING_FEATHERS,
			GeneticDomRecProperty.WING_ISSUES
		});
		AddTextMutationInfoToGUI(dOMREC_MISSING_WINGS, text9, new List<GeneticDomRecProperty>
		{
			GeneticDomRecProperty.MISSING_LEFT_WING,
			GeneticDomRecProperty.MISSING_RIGHT_WING
		});
		storedDomRecGeneString = component2.GetDomRecGene();
		domRecGeneString.text = storedDomRecGeneString;
	}

	private void AddMutationInfoToGUI(string mutationName, float geneValue, float minValue, float maxValue, bool mysteryValue = false)
	{
		GeneInfo component = Object.Instantiate(geneticInfo, geneticContentHolder).GetComponent<GeneInfo>();
		component.SetMutationString(mutationName);
		component.SetValues(geneValue, minValue, maxValue, mysteryValue);
		geneticsList.Add(component);
	}

	private void AddTextMutationInfoToGUI(string mutationName, string geneValue, List<GeneticDomRecProperty> linkedProperties = null, bool number = false)
	{
		Transform parent = geneticContentHolder;
		if (linkedProperties != null)
		{
			parent = geneticContentHolderDomRec;
		}
		GeneInfo component = Object.Instantiate(geneticInfo, parent).GetComponent<GeneInfo>();
		if (number)
		{
			component.SetMutationStringAndCenteredNumber(mutationName, geneValue);
		}
		else
		{
			component.SetMutationStringAndCenteredText(mutationName, geneValue);
		}
		if (linkedProperties != null)
		{
			component.geneticInspectionRef = this;
			component.SetLinkedProperties(linkedProperties);
		}
		geneticsList.Add(component);
	}

	private void ClearAllGeneticInfos()
	{
		for (int i = 0; i < geneticsList.Count; i++)
		{
			Object.Destroy(geneticsList[i].gameObject);
		}
		geneticsList.Clear();
		colorInfo.SetActive(value: false);
	}

	public void OnDomRecGeneticsMouseOn(List<GeneticDomRecProperty> linkedProperties)
	{
		if (activeRotationDog == null)
		{
			OnDomRecGeneticsMouseOff(currentLinkedProperties);
		}
		else
		{
			if (ArePropertyListsEqual(currentLinkedProperties, linkedProperties))
			{
				return;
			}
			currentLinkedProperties.Clear();
			currentLinkedProperties.AddRange(linkedProperties);
			domRecGeneString.text = storedDomRecGeneString;
			List<int> list = new List<int>();
			MasterDogGene component = activeRotationDog.GetComponent<MasterDogGene>();
			for (int i = 0; i < linkedProperties.Count; i++)
			{
				for (int j = 0; j < component.domRecGenes.Count; j++)
				{
					if (component.domRecGenes[j].aa == linkedProperties[i] || component.domRecGenes[j].AA == linkedProperties[i] || component.domRecGenes[j].Aa == linkedProperties[i])
					{
						if (!list.Contains(j * 2))
						{
							list.Add(j * 2);
						}
						if (!list.Contains(j * 2 + 1))
						{
							list.Add(j * 2 + 1);
						}
					}
				}
			}
			list.Sort();
			for (int num = list.Count - 1; num >= 0; num--)
			{
				domRecGeneString.text = domRecGeneString.text.Insert(list[num] + 1, "</color>");
				domRecGeneString.text = domRecGeneString.text.Insert(list[num], "<color=blue>");
			}
		}
	}

	public void OnDomRecGeneticsMouseOff(List<GeneticDomRecProperty> linkedProperties)
	{
		if (ArePropertyListsEqual(currentLinkedProperties, linkedProperties))
		{
			currentLinkedProperties.Clear();
			domRecGeneString.text = storedDomRecGeneString;
		}
	}

	private bool ArePropertyListsEqual(List<GeneticDomRecProperty> listA, List<GeneticDomRecProperty> listB)
	{
		if (listA.Count != listB.Count)
		{
			return false;
		}
		for (int i = 0; i < listA.Count; i++)
		{
			bool flag = false;
			for (int j = 0; j < listB.Count; j++)
			{
				if (listB[j] == listA[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}
}
