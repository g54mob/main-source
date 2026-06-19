using System.Collections.Generic;
using ClockStone;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MutationGUI : MonoBehaviour
{
	public GameObject mutationHeader;

	public GameObject toggleDogCircle;

	public TextMeshProUGUI dogNameText;

	public GameObject noMutationsObject;

	public Transform activeDogHolderTransform;

	public Transform inactiveDogHolderTransform;

	public Scrollbar scrollRef;

	public GameObject mutationInfoPrefab;

	public RectTransform mutationInfoTransform;

	public RectTransform sliderAreaTransform;

	public Camera mutatedLegColorCam;

	public Camera originalLegColorCam;

	public Camera mutatedBodyColorCam;

	public Camera originalBodyColorCam;

	public Camera mutatedNoseEarColorCam;

	public Camera originalNoseEarColorCam;

	public Renderer mutatedLegColorRenderer;

	public Renderer originalLegColorRenderer;

	public Renderer mutatedBodyColorRenderer;

	public Renderer originalBodyColorRenderer;

	public Renderer mutatedNoseEarColorRenderer;

	public Renderer originalNoseEarColorRenderer;

	private string mutationUI_enter = "mutationUI_enter";

	private string mutationJingle = "mutation_screen_jingle";

	private float initialOffset = 50f;

	private float mutationOffset = 100f;

	private float finalMutationOffset = 25f;

	private bool legColorMutation;

	private bool bodyColorMutation;

	private bool noseEarColorMutation;

	private string newDogGene;

	private Cocoon associatedCocoon;

	private SaveableDog associatedDog;

	private int infoCount;

	private bool swapRequested;

	private bool GUIClosed;

	private GameObject createdDogMutated;

	private GameObject createdDogOriginal;

	private Dictionary<GutFloraMutationEffect, FloraMutationInfo> floraMapping;

	private GUIManagerPens guiRef;

	private DogRegistration dogRegRef;

	private DogGutsManager gutsManagerRef;

	private MusicPlaylistController playlistRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		gutsManagerRef = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		playlistRef = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>();
		guiRef.DisableBG(LockReason.MUTATION_GUI);
		noMutationsObject.SetActive(value: false);
		playlistRef.Pause();
		SFXOverlord.LockInWorldSFX(LockReason.MUTATION_GUI);
		SFXOverlord.SetMusicVolumeOverride(enabled: false, 1f);
		AudioController.Play(mutationUI_enter);
		AudioController.PlayMusic(mutationJingle);
		guiRef.SetGUIInteractiveStatus(status: false, LockReason.MUTATION_GUI);
	}

	private void OnDestroy()
	{
		playlistRef.Unpause();
		SFXOverlord.UnlockInWorldSFX(LockReason.MUTATION_GUI);
		guiRef.SetGUIInteractiveStatus(status: true, LockReason.MUTATION_GUI);
	}

	private void LateUpdate()
	{
		if (swapRequested)
		{
			SwapDogsInternal();
		}
	}

	public void SetCocoonRef(Cocoon newRef)
	{
		associatedCocoon = newRef;
	}

	public void SetAssociatedDog(SaveableDog newDog, GameObject oldDog, string newGene, Dictionary<GutFloraMutationEffect, FloraMutationInfo> newFloraMapping)
	{
		createdDogOriginal = oldDog;
		oldDog.transform.SetParent(inactiveDogHolderTransform);
		oldDog.transform.localPosition = Vector3.zero;
		oldDog.transform.localRotation = Quaternion.identity;
		newDogGene = newGene;
		associatedDog = newDog;
		dogNameText.text = newDog.dogName;
		floraMapping = newFloraMapping;
		CreateDogs();
	}

	public void OnAcceptClicked()
	{
		SaveableDogGene saveableDogGene = new SaveableDogGene();
		saveableDogGene.dogGene = newDogGene;
		saveableDogGene.domRecGene = associatedDog.dogGene.domRecGene;
		saveableDogGene.geneVersion = MasterDogGene.currentGeneticVersion;
		saveableDogGene.puppyCode = associatedDog.dogGene.puppyCode;
		saveableDogGene.childCode = associatedDog.dogGene.childCode;
		saveableDogGene.teenCode = associatedDog.dogGene.teenCode;
		saveableDogGene.youngAdultCode = associatedDog.dogGene.youngAdultCode;
		associatedDog.dogGene = saveableDogGene;
		CloseUI();
	}

	public void SwapDogs()
	{
		swapRequested = true;
	}

	private void SwapDogsInternal()
	{
		swapRequested = false;
		if (createdDogMutated.transform.parent == activeDogHolderTransform)
		{
			toggleDogCircle.SetActive(value: false);
			createdDogOriginal.transform.SetParent(activeDogHolderTransform);
			createdDogMutated.transform.SetParent(inactiveDogHolderTransform);
		}
		else
		{
			toggleDogCircle.SetActive(value: true);
			createdDogMutated.transform.SetParent(activeDogHolderTransform);
			createdDogOriginal.transform.SetParent(inactiveDogHolderTransform);
		}
		createdDogMutated.transform.localPosition = Vector3.zero;
		createdDogOriginal.transform.localPosition = Vector3.zero;
	}

	private void CloseUI()
	{
		guiRef.EnableBG(LockReason.MUTATION_GUI);
		dogRegRef.UpdateSaveableDog(associatedDog);
		associatedCocoon.MutationUIFinishedCallback();
		GUIClosed = true;
		Object.Destroy(base.gameObject);
	}

	private void CreateDogs()
	{
		SaveableDogGene saveableDogGene = new SaveableDogGene();
		saveableDogGene.dogGene = newDogGene;
		saveableDogGene.domRecGene = associatedDog.dogGene.domRecGene;
		saveableDogGene.geneVersion = MasterDogGene.currentGeneticVersion;
		dogRegRef.RequestNewDog(activeDogHolderTransform.position, activeDogHolderTransform.rotation, saveableDogGene, null, manualDog: false, dogProfile: associatedDog.dogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: associatedDog.brain.dogAge, customDogAgeProgress: associatedDog.brain.dogAgeProgress);
	}

	private void OnNewDogCreated(GameObject dog)
	{
		createdDogMutated = dog;
		dogRegRef.MakeDogSuitableForUIDisplay(dog);
		dog.transform.SetParent(activeDogHolderTransform);
		if (createdDogOriginal != null)
		{
			FindMutations();
		}
		if (GUIClosed)
		{
			Object.Destroy(dog);
		}
	}

	private Sprite GetIconForProperty(GeneticProperty propertyRef)
	{
		foreach (FloraMutationInfo value in floraMapping.Values)
		{
			if (value.changedProperties.Contains(propertyRef) && value.uniqueFlora.Count > 0)
			{
				return gutsManagerRef.GetFloraForPath(value.uniqueFlora[0]).gutFloraPreviewSprite;
			}
		}
		return null;
	}

	private void FindMutations()
	{
		MasterDogGene component = createdDogMutated.GetComponent<MasterDogGene>();
		MasterDogGene component2 = createdDogOriginal.GetComponent<MasterDogGene>();
		DogLooks component3 = createdDogMutated.GetComponent<DogLooks>();
		DogLooks component4 = createdDogOriginal.GetComponent<DogLooks>();
		float bodyPatternTextureAlpha = component3.GetBodyPatternTextureAlpha();
		float bodyPatternTextureAlpha2 = component4.GetBodyPatternTextureAlpha();
		Material legMaterial = component3.GetLegMaterial();
		Material legMaterial2 = component4.GetLegMaterial();
		Material bodyMainMaterial = component3.GetBodyMainMaterial();
		Material bodyMainMaterial2 = component4.GetBodyMainMaterial();
		Material noseEarMaterial = component3.GetNoseEarMaterial();
		Material noseEarMaterial2 = component4.GetNoseEarMaterial();
		Material bodyPatternMaterial = component3.GetBodyPatternMaterial();
		Material bodyPatternMaterial2 = component4.GetBodyPatternMaterial();
		float num = 0.05f;
		bool flag = true;
		if ((bodyPatternTextureAlpha == 0f && bodyPatternTextureAlpha2 == 0f) || (component3.GetBodyPatternMaterial() == null && component4.GetBodyPatternMaterial() == null))
		{
			flag = false;
		}
		bool flag2 = true;
		if (component3.GetTailType() == TailType.NO_TAIL)
		{
			flag2 = false;
		}
		Sprite sprite = null;
		GeneticProperty propertyRef = GeneticProperty.LegColorBMinus;
		GeneticProperty propertyRef2 = GeneticProperty.BodyColorBMinus;
		GeneticProperty propertyRef3 = GeneticProperty.NoseEarColorBMinus;
		for (int i = 0; i < component.dogGenes.Count; i++)
		{
			Gene gene = component.dogGenes[i];
			float num2 = 0f;
			float num3 = 0f;
			float minValue = 0f;
			float maxValue = 0f;
			GeneticProperty geneticProperty = ((!gene.plusMinus) ? component.GetGeneticPropertyFromKeyString(gene.key) : component.GetGeneticPropertyFromKeyString(component.GetPlusStringForGene(gene.key)));
			switch (geneticProperty)
			{
			case GeneticProperty.PatternMetallicPlus:
			case GeneticProperty.PatternSmoothnessPlus:
				if (!flag)
				{
					continue;
				}
				break;
			default:
				if ((gene.geneCategory == GeneCategory.PATTERN && !flag) || (!flag2 && (geneticProperty == GeneticProperty.TailNum || geneticProperty == GeneticProperty.TailScaleMinus || geneticProperty == GeneticProperty.TailScalePlus)))
				{
					continue;
				}
				if (geneticProperty == GeneticProperty.TailNum)
				{
					if (component3.GetTailNumber() == component4.GetTailNumber())
					{
						continue;
					}
					break;
				}
				if (geneticProperty == GeneticProperty.HeadNumber)
				{
					if (component3.GetHeadCount() == component4.GetHeadCount() || component3.useOldHead)
					{
						continue;
					}
					break;
				}
				if (geneticProperty == GeneticProperty.HeadSizeMinus || geneticProperty == GeneticProperty.HeadSizePlus)
				{
					if (component3.useOldHead)
					{
						continue;
					}
					break;
				}
				if (geneticProperty == GeneticProperty.LegPairsBack)
				{
					if (component3.GetBackLegPairCount() == component4.GetBackLegPairCount())
					{
						continue;
					}
					break;
				}
				if (geneticProperty == GeneticProperty.LegPairsFront)
				{
					if (component3.GetFrontLegPairCount() == component4.GetFrontLegPairCount())
					{
						continue;
					}
					break;
				}
				if (geneticProperty == GeneticProperty.EarCurlLeft || geneticProperty == GeneticProperty.EarCurlRight)
				{
					continue;
				}
				switch (geneticProperty)
				{
				case GeneticProperty.EarModAPlus:
				case GeneticProperty.EarModAMinus:
				{
					EarType earType = component3.GetEarType();
					if (earType == EarType.BLUNT || earType == EarType.BULBOUS || earType == EarType.HORN || earType == EarType.SHEPHERD || component3.useOldHead)
					{
						continue;
					}
					break;
				}
				case GeneticProperty.HornSizePlus:
				case GeneticProperty.HornSizeMinus:
					if (component3.GetHornType() == HornType.NO_HORNS || component3.useOldHead)
					{
						continue;
					}
					break;
				case GeneticProperty.SnoutModAPlus:
				case GeneticProperty.SnoutModAMinus:
				case GeneticProperty.SnoutModBPlus:
				case GeneticProperty.SnoutModBMinus:
				case GeneticProperty.SnoutModCPlus:
				case GeneticProperty.SnoutModCMinus:
					if (component3.useOldHead)
					{
						continue;
					}
					break;
				case GeneticProperty.NoseModAPlus:
				case GeneticProperty.NoseModAMinus:
					if (component3.useOldHead)
					{
						continue;
					}
					break;
				case GeneticProperty.WingSizePlus:
				case GeneticProperty.WingSizeMinus:
				{
					if (component3.GetWingType() == WingType.NO_WINGS)
					{
						continue;
					}
					bool domRecPropertyStatus = component.GetDomRecPropertyStatus(GeneticDomRecProperty.WING_ISSUES);
					bool domRecPropertyStatus2 = component.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_LEFT_WING);
					bool domRecPropertyStatus3 = component.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_RIGHT_WING);
					if (domRecPropertyStatus2 && domRecPropertyStatus3 && domRecPropertyStatus)
					{
						continue;
					}
					break;
				}
				default:
					if (gene.geneSwapCategory != GeneSwapCategory.COLOR_SWAP)
					{
						break;
					}
					if (gene.geneCategory == GeneCategory.BODY)
					{
						if (MathUtil.ColorDifference(bodyMainMaterial2.color, bodyMainMaterial.color) > num || MathUtil.ColorDifference(bodyMainMaterial2.GetColor("_EmissionColor"), bodyMainMaterial.GetColor("_EmissionColor")) > num)
						{
							bodyColorMutation = true;
							propertyRef2 = geneticProperty;
						}
					}
					else if (gene.geneCategory == GeneCategory.PATTERN)
					{
						if ((bodyPatternMaterial2 == null && bodyPatternMaterial != null) || (bodyPatternMaterial2 != null && bodyPatternMaterial == null) || (geneticProperty != GeneticProperty.PatternAlpha && geneticProperty != GeneticProperty.PatternColorBPlus && geneticProperty != GeneticProperty.PatternColorGPlus && geneticProperty != GeneticProperty.PatternColorRPlus) || MathUtil.ColorDifference(bodyPatternMaterial2.color, bodyPatternMaterial.color) > num || MathUtil.ColorDifference(bodyPatternMaterial2.GetColor("_EmissionColor"), bodyPatternMaterial.GetColor("_EmissionColor")) > num)
						{
							bodyColorMutation = true;
							propertyRef2 = geneticProperty;
						}
					}
					else if (gene.geneCategory == GeneCategory.LEGS)
					{
						if (!(legMaterial == null) && (MathUtil.ColorDifference(legMaterial2.color, legMaterial.color) > num || MathUtil.ColorDifference(legMaterial2.GetColor("_EmissionColor"), legMaterial.GetColor("_EmissionColor")) > num))
						{
							legColorMutation = true;
							propertyRef = geneticProperty;
						}
					}
					else if (gene.geneCategory == GeneCategory.HEAD && (MathUtil.ColorDifference(noseEarMaterial2.color, noseEarMaterial.color) > num || MathUtil.ColorDifference(noseEarMaterial2.GetColor("_EmissionColor"), noseEarMaterial.GetColor("_EmissionColor")) > num))
					{
						noseEarColorMutation = true;
						propertyRef3 = geneticProperty;
					}
					continue;
				}
				break;
			case GeneticProperty.BodyMetallicPlus:
			case GeneticProperty.BodyGlossPlus:
			case GeneticProperty.LegMetallicPlus:
			case GeneticProperty.LegGlossPlus:
			case GeneticProperty.NoseEarMetallicPlus:
			case GeneticProperty.NoseEarGlossPlus:
				break;
			}
			if (gene.plusMinus)
			{
				GeneticProperty geneticPropertyFromKeyString = component.GetGeneticPropertyFromKeyString(component.GetPlusStringForGene(gene.key));
				GeneticProperty geneticPropertyFromKeyString2 = component.GetGeneticPropertyFromKeyString(component.GetMinusStringForGene(gene.key));
				maxValue = component.GetGeneValues(geneticPropertyFromKeyString).GetMaxValue();
				minValue = 0f - component.GetGeneValues(geneticPropertyFromKeyString2).GetMaxValue();
				num2 = component.GetGeneValues(geneticPropertyFromKeyString).GetValue() - component.GetGeneValues(geneticPropertyFromKeyString2).GetValue();
				num3 = component2.GetGeneValues(geneticPropertyFromKeyString).GetValue() - component2.GetGeneValues(geneticPropertyFromKeyString2).GetValue();
			}
			else if (gene.geneType != GeneType.LOOPED)
			{
				GeneticProperty geneticPropertyFromKeyString3 = component.GetGeneticPropertyFromKeyString(gene.key);
				minValue = component.GetGeneValues(geneticPropertyFromKeyString3).GetMinValue();
				maxValue = component.GetGeneValues(geneticPropertyFromKeyString3).GetMaxValue();
				num2 = component.GetGeneValues(geneticPropertyFromKeyString3).GetValue();
				num3 = component2.GetGeneValues(geneticPropertyFromKeyString3).GetValue();
			}
			if (num2 != num3)
			{
				sprite = GetIconForProperty(geneticProperty);
				AddMutationInfoToGUI(gene.localizedName, num3, num2, minValue, maxValue, sprite);
			}
		}
		if (flag && component.GetRandomSeedString() != component2.GetRandomSeedString())
		{
			bodyColorMutation = true;
		}
		if (bodyColorMutation)
		{
			mutatedBodyColorCam.gameObject.SetActive(value: true);
			originalBodyColorCam.gameObject.SetActive(value: true);
			mutatedBodyColorRenderer.materials = new Material[2] { bodyMainMaterial, bodyPatternMaterial };
			originalBodyColorRenderer.materials = new Material[2] { bodyMainMaterial2, bodyPatternMaterial2 };
			sprite = GetIconForProperty(propertyRef2);
			AddColorMutationInfoToGUI(ScriptLocalization.Genetics.GENE_BODYCOLOR, sprite, body: true);
		}
		else
		{
			mutatedBodyColorCam.gameObject.SetActive(value: false);
			originalBodyColorCam.gameObject.SetActive(value: false);
		}
		if (legColorMutation)
		{
			mutatedLegColorCam.gameObject.SetActive(value: true);
			originalLegColorCam.gameObject.SetActive(value: true);
			mutatedLegColorRenderer.material = new Material(legMaterial);
			originalLegColorRenderer.material = new Material(legMaterial2);
			mutatedLegColorRenderer.material.SetFloat("_Chub", 0f);
			originalLegColorRenderer.material.SetFloat("_Chub", 0f);
			sprite = GetIconForProperty(propertyRef);
			AddColorMutationInfoToGUI(ScriptLocalization.Genetics.GENE_LEGCOLOR, sprite, body: false, legs: true);
		}
		else
		{
			mutatedLegColorCam.gameObject.SetActive(value: false);
			originalLegColorCam.gameObject.SetActive(value: false);
		}
		if (noseEarColorMutation)
		{
			mutatedNoseEarColorCam.gameObject.SetActive(value: true);
			originalNoseEarColorCam.gameObject.SetActive(value: true);
			mutatedNoseEarColorRenderer.material = noseEarMaterial;
			originalNoseEarColorRenderer.material = noseEarMaterial2;
			sprite = GetIconForProperty(propertyRef3);
			AddColorMutationInfoToGUI(ScriptLocalization.Genetics.GENE_NOSEEARCOLOR, sprite, body: false, legs: false, noseEars: true);
		}
		else
		{
			mutatedNoseEarColorCam.gameObject.SetActive(value: false);
			originalNoseEarColorCam.gameObject.SetActive(value: false);
		}
		AddAgeUpInfoToGUI(associatedDog.brain.dogAge - 1, associatedDog.brain.dogAge);
		if (infoCount == 0)
		{
			noMutationsObject.SetActive(value: true);
		}
		else
		{
			noMutationsObject.SetActive(value: false);
		}
		scrollRef.value = 1f;
	}

	private void AddAgeUpInfoToGUI(DogAge oldAge, DogAge newAge)
	{
		infoCount += 2;
		GameObject gameObject = Object.Instantiate(mutationInfoPrefab, mutationInfoTransform);
		MutationInfo component = gameObject.GetComponent<MutationInfo>();
		component.floraIcon.gameObject.SetActive(value: false);
		component.SetUpdatedAge(oldAge, newAge);
		PositionMutationInfo(gameObject);
		component.AnimateAge();
	}

	private void AddMutationInfoToGUI(string mutationName, float originalValue, float newValue, float minValue, float maxValue, Sprite floraIcon)
	{
		infoCount++;
		GameObject gameObject = Object.Instantiate(mutationInfoPrefab, mutationInfoTransform);
		MutationInfo component = gameObject.GetComponent<MutationInfo>();
		if (floraIcon == null)
		{
			component.floraIcon.enabled = false;
		}
		else
		{
			component.floraIcon.sprite = floraIcon;
		}
		component.SetMutationString(mutationName);
		component.SetUpdatedValues(originalValue, newValue, minValue, maxValue);
		PositionMutationInfo(gameObject);
	}

	private void AddColorMutationInfoToGUI(string mutationName, Sprite floraIcon, bool body = false, bool legs = false, bool noseEars = false)
	{
		infoCount++;
		GameObject gameObject = Object.Instantiate(mutationInfoPrefab, mutationInfoTransform);
		MutationInfo component = gameObject.GetComponent<MutationInfo>();
		if (floraIcon == null)
		{
			component.floraIcon.enabled = false;
		}
		else
		{
			component.floraIcon.sprite = floraIcon;
		}
		component.SetMutationString(mutationName);
		component.SetUpdatedMaterials(body, legs, noseEars);
		PositionMutationInfo(gameObject);
	}

	private void AddPartMutationInfoToGUI(string partName, Sprite floraIcon)
	{
		infoCount++;
		GameObject gameObject = Object.Instantiate(mutationInfoPrefab, mutationInfoTransform);
		MutationInfo component = gameObject.GetComponent<MutationInfo>();
		component.SetUpdatedParts();
		component.SetMutationString(partName);
		if (floraIcon == null)
		{
			component.floraIcon.enabled = false;
		}
		else
		{
			component.floraIcon.sprite = floraIcon;
		}
		PositionMutationInfo(gameObject);
	}

	private void PositionMutationInfo(GameObject obj)
	{
		obj.transform.localPosition = Vector3.zero + Vector3.up * mutationOffset * infoCount;
		float num = (float)infoCount * mutationOffset + finalMutationOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num);
		mutationInfoTransform.anchoredPosition3D = new Vector3(mutationInfoTransform.anchoredPosition3D.x, (0f - num) / 2f - initialOffset, 0f);
	}
}
