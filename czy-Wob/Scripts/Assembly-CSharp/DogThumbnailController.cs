using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogThumbnailController : MonoBehaviour
{
	public GameObject dogStorageBoxPrefab;

	public GameObject gutButton;

	public GameObject gutContents;

	public TextMeshProUGUI dogNameText;

	public GameObject dogGutGUIPrefab;

	public GameObject thumbnailPrefab;

	public Sprite cocoonPortraitSprite;

	public Sprite cocoonPortraitSpriteLowRes;

	public Image selectedDogPortraitSprite;

	public GameObject dogAgeHolder;

	public TextMeshProUGUI dogAgeText;

	public Image selectedDogTrait1;

	public Image selectedDogTrait2;

	public Image selectedDogTrait3;

	public Image selectedDogTrait4;

	public Image selectedDogTrait5;

	public Image selectedDogTrait6;

	public List<StatBar> statBars = new List<StatBar>();

	public Tooltip traitTooltip;

	public Need hoveredNeed = Need.None;

	public GameObject followCamButton;

	public GameObject followCamCancelButton;

	public GameObject dogPortraitButton;

	public Sprite gluttonTraitIcon;

	public Sprite foodAverseTraitIcon;

	public Sprite socialTraitIcon;

	public Sprite aloofTraitIcon;

	public Sprite layaboutTraitIcon;

	public Sprite highEnergyTraitIcon;

	public Sprite rudeTraitIcon;

	public Sprite politeTraitIcon;

	public Sprite peacefulTraitIcon;

	public Sprite antagonisticTraitIcon;

	public Sprite unpettableTraitIcon;

	public Sprite loudTraitIcon;

	public Sprite quietTraitIcon;

	private List<ulong> thumbKeys = new List<ulong>();

	private Dictionary<ulong, DogThumbnail> currentThumbs = new Dictionary<ulong, DogThumbnail>();

	private List<ulong> neededCocoonableIDs = new List<ulong>();

	private List<ulong> thumbSetKeys = new List<ulong>();

	private Dictionary<ulong, ThumbnailSet> thumbSets = new Dictionary<ulong, ThumbnailSet>();

	private List<DogStorageBox> dogStorageBoxes = new List<DogStorageBox>();

	private float dogsPerRow = 10f;

	private float separationY = 85f;

	private float separationX = 90f;

	private ulong? currentlySelectedDog;

	private SaveableDog currentlySelectedSaveableDog;

	private string lastLanguage;

	private DogGutGUIManager dogGutGUIRef;

	private PenFocus camFocus;

	private GUIManagerPens guiRef;

	private ObjectGrabber grabberRef;

	private DogRegistration dogRegRef;

	private SceneManagerBase sceneRef;

	private DoggyBrain selectedBrainRef;

	private DogGutsManager gutsManagerRef;

	private bool initialized;

	private void Awake()
	{
		lastLanguage = LocalizationManager.CurrentLanguage;
		dogNameText.text = "";
		dogAgeHolder.SetActive(value: false);
		dogPortraitButton.SetActive(value: false);
		selectedDogPortraitSprite.sprite = null;
		camFocus = Camera.main.GetComponent<PenFocus>();
		UpdateTraits(null);
		OnTraitHoverStop();
		traitTooltip.gameObject.SetActive(value: false);
	}

	private void Start()
	{
		Initialize();
	}

	public void Initialize(GUIManagerPens pensGUIRef = null)
	{
		if (!initialized)
		{
			initialized = true;
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			if (pensGUIRef != null)
			{
				guiRef = pensGUIRef;
			}
			else
			{
				guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
			}
			grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
			sceneRef = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
			dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
			gutsManagerRef = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
			dogRegRef.SetThumbnailRef(this);
			followCamCancelButton.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (LocalizationManager.CurrentLanguage != lastLanguage)
		{
			OnLanguageUpdated();
		}
		if (camFocus == null)
		{
			camFocus = Camera.main.GetComponent<PenFocus>();
		}
		if (currentlySelectedSaveableDog != null && !currentlySelectedSaveableDog.inCocoon && sceneRef.GetGameMode() == GameMode.HOME)
		{
			gutButton.SetActive(value: true);
			gutContents.SetActive(value: true);
		}
		else
		{
			gutButton.SetActive(value: false);
			gutContents.SetActive(value: false);
		}
		UpdateFollowCamCancelButton();
		if (!guiRef.GetGUIInteractiveStatus())
		{
			traitTooltip.gameObject.SetActive(value: false);
		}
	}

	public ulong? GetCurrentlySelectedDogID()
	{
		return currentlySelectedDog;
	}

	public void SetCocoonableDog(ulong dogID)
	{
		if (sceneRef.GetGameMode() != GameMode.HOME)
		{
			return;
		}
		if (currentThumbs.ContainsKey(dogID))
		{
			currentThumbs[dogID].SetCocoonableState(newState: true);
			if (neededCocoonableIDs.Contains(dogID))
			{
				neededCocoonableIDs.Remove(dogID);
			}
		}
		else if (!neededCocoonableIDs.Contains(dogID))
		{
			neededCocoonableIDs.Add(dogID);
		}
	}

	private void CheckCocoonableThumbs(ulong dogID)
	{
		if (neededCocoonableIDs.Contains(dogID))
		{
			neededCocoonableIDs.Remove(dogID);
			SetCocoonableDog(dogID);
		}
	}

	private void UpdateFollowCamCancelButton()
	{
		bool activeSelf = followCamCancelButton.activeSelf;
		if (activeSelf != camFocus.FollowCamActive())
		{
			followCamCancelButton.SetActive(!activeSelf);
		}
	}

	public void RefreshThumbnailForDogID(ulong dogID)
	{
		if (currentThumbs.ContainsKey(dogID))
		{
			currentThumbs[dogID].Refresh();
			if (currentlySelectedDog == dogID)
			{
				OnDogSelected(dogID);
			}
		}
	}

	public List<ulong> GetOrderedDogUIDs()
	{
		List<ulong> list = new List<ulong>();
		list.AddRange(thumbKeys);
		return list;
	}

	public int GetDogCount()
	{
		return thumbKeys.Count;
	}

	public void SelectNextDog()
	{
		if (currentlySelectedDog.HasValue)
		{
			int num = thumbKeys.IndexOf(currentlySelectedDog.Value) + 1;
			if (num >= thumbKeys.Count)
			{
				num = 0;
			}
			OnDogSelected(thumbKeys[num]);
		}
	}

	public void SelectPreviousDog()
	{
		if (currentlySelectedDog.HasValue)
		{
			int num = thumbKeys.IndexOf(currentlySelectedDog.Value) - 1;
			if (num < 0)
			{
				num = thumbKeys.Count - 1;
			}
			OnDogSelected(thumbKeys[num]);
		}
	}

	public void OnDogSelected(ulong? dogID, bool fromDoubleClick = false)
	{
		if (!dogID.HasValue)
		{
			return;
		}
		grabberRef.DeactivateIndicator();
		OnDogDeselected(currentlySelectedDog, fromDoubleClick);
		currentlySelectedDog = dogID;
		followCamButton.SetActive(value: true);
		dogPortraitButton.SetActive(value: true);
		GameObject dogFromID = dogRegRef.GetDogFromID(dogID.Value);
		if (dogFromID != null)
		{
			DogGutController component = dogFromID.GetComponent<DogGutController>();
			if (component != null)
			{
				gutsManagerRef.RenderGut(component.GetDogGut());
			}
		}
		if (camFocus.FollowCamActive())
		{
			FocusOnDog(currentlySelectedDog.Value);
		}
		if (!dogID.HasValue || !currentThumbs.ContainsKey(dogID.Value))
		{
			return;
		}
		currentlySelectedSaveableDog = dogRegRef.GetSaveableDogFromID(dogID.Value);
		currentThumbs[dogID.Value].SetSelected(selectedVal: true);
		dogNameText.text = currentlySelectedSaveableDog.dogName;
		dogAgeHolder.SetActive(value: true);
		if (currentlySelectedSaveableDog.isGhost)
		{
			dogAgeText.text = ScriptLocalization.GUI.GUI_AGE_GHOST;
		}
		else
		{
			dogAgeText.text = DoggyBrain.GetReadableNameForDogAge(currentlySelectedSaveableDog.brain.dogAge);
		}
		if (currentlySelectedSaveableDog.inCocoon)
		{
			selectedDogPortraitSprite.sprite = cocoonPortraitSprite;
			GameObject cocoonForDogID = GetCocoonForDogID(dogID.Value);
			if (cocoonForDogID != null)
			{
				GameObject indicator = cocoonForDogID.GetComponent<Cocoon>().GetIndicator();
				if (indicator != null)
				{
					indicator.GetComponent<CocoonIndicator>().OnDogSelected();
				}
			}
			for (int i = 0; i < statBars.Count; i++)
			{
				statBars[i].SetBrainRef(null);
				statBars[i].SetSaveableDogRef(currentlySelectedSaveableDog);
			}
			UpdateTraits(currentlySelectedSaveableDog);
			return;
		}
		GameObject dogFromID2 = dogRegRef.GetDogFromID(dogID.Value);
		if (dogFromID2 != null)
		{
			selectedBrainRef = dogFromID2.GetComponent<DoggyBrain>();
			selectedDogPortraitSprite.sprite = dogRegRef.GetDefaultThumbnailForDogID(dogID, useCocoonSprite: true, highQuality: true);
			dogFromID2.GetComponent<DogIndicatorController>().OnDogSelected();
			for (int j = 0; j < statBars.Count; j++)
			{
				statBars[j].SetBrainRef(selectedBrainRef);
				statBars[j].SetSaveableDogRef(currentlySelectedSaveableDog);
			}
		}
		UpdateTraits(dogRegRef.GetSaveableDogFromDog(dogFromID2));
	}

	public void OnHungerIndicatorHoverStart()
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			hoveredNeed = Need.Hunger;
			traitTooltip.gameObject.SetActive(value: true);
			traitTooltip.SetItem(ScriptLocalization.GUI.GUI_HUD_HUNGER, ScriptLocalization.GUI.GUI_HUD_HUNGER_DESC, unlocked: true);
		}
	}

	public void OnEnergyIndicatorHoverStart()
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			hoveredNeed = Need.Energy;
			traitTooltip.gameObject.SetActive(value: true);
			traitTooltip.SetItem(ScriptLocalization.GUI.GUI_HUD_ENERGY, ScriptLocalization.GUI.GUI_HUD_ENERGY_DESC, unlocked: true);
		}
	}

	public void OnStressIndicatorHoverStart()
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			hoveredNeed = Need.Stress;
			traitTooltip.gameObject.SetActive(value: true);
			traitTooltip.SetItem(ScriptLocalization.GUI.GUI_HUD_STRESS, ScriptLocalization.GUI.GUI_HUD_STRESS_DESC, unlocked: true);
		}
	}

	public void OnBoredomIconHoverStart()
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			hoveredNeed = Need.Boredom;
			traitTooltip.gameObject.SetActive(value: true);
			traitTooltip.SetItem(ScriptLocalization.GUI.GUI_HUD_BOREDOM, ScriptLocalization.GUI.GUI_HUD_BOREDOM_DESC, unlocked: true);
		}
	}

	public void OnNeedIndicatorHover()
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			traitTooltip.HoverBehavior();
		}
	}

	public void OnHungerIndicatorHoverStop()
	{
		if (hoveredNeed == Need.Hunger)
		{
			hoveredNeed = Need.None;
			traitTooltip.gameObject.SetActive(value: false);
		}
	}

	public void OnEnergyIndicatorHoverStop()
	{
		if (hoveredNeed == Need.Energy)
		{
			hoveredNeed = Need.None;
			traitTooltip.gameObject.SetActive(value: false);
		}
	}

	public void OnStressIndicatorHoverStop()
	{
		if (hoveredNeed == Need.Stress)
		{
			hoveredNeed = Need.None;
			traitTooltip.gameObject.SetActive(value: false);
		}
	}

	public void OnBoredomIndicatorHoverStop()
	{
		if (hoveredNeed == Need.Boredom)
		{
			hoveredNeed = Need.None;
			traitTooltip.gameObject.SetActive(value: false);
		}
	}

	public void OnTraitHoverStart(int index)
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			traitTooltip.SetItem(GetTraitInfoForIndex(index));
			traitTooltip.gameObject.SetActive(value: true);
		}
	}

	public void OnTraitHover()
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			if (!traitTooltip.gameObject.activeSelf)
			{
				traitTooltip.gameObject.SetActive(value: true);
			}
			traitTooltip.HoverBehavior();
		}
	}

	public void OnTraitHoverStop()
	{
		traitTooltip.gameObject.SetActive(value: false);
	}

	public void OnAgeHoverStart()
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			string fullBoxText = "ERROR!";
			if (currentlySelectedSaveableDog.inCocoon)
			{
				fullBoxText = DoggyBrain.GetReadableMinutesAlive(currentlySelectedSaveableDog.brain.dogAge, currentlySelectedSaveableDog.brain.dogAgeProgress);
			}
			else if (selectedBrainRef != null)
			{
				fullBoxText = DoggyBrain.GetReadableMinutesAlive(selectedBrainRef.GetCurrentDogAge(), selectedBrainRef.GetCurrentDogAgeProgress());
			}
			traitTooltip.SetFullBoxText(fullBoxText);
			traitTooltip.gameObject.SetActive(value: true);
		}
	}

	public void OnAgeHover()
	{
		if (guiRef.GetGUIInteractiveStatus() && guiRef.IsInputAllowed())
		{
			traitTooltip.HoverBehavior();
		}
	}

	public void OnAgeHoverStop()
	{
		traitTooltip.gameObject.SetActive(value: false);
	}

	public void OnLanguageUpdated()
	{
		lastLanguage = LocalizationManager.CurrentLanguage;
		if (currentlySelectedSaveableDog != null)
		{
			UpdateTraits(currentlySelectedSaveableDog);
			if (currentlySelectedSaveableDog.isGhost)
			{
				dogAgeText.text = ScriptLocalization.GUI.GUI_AGE_GHOST;
			}
			else
			{
				dogAgeText.text = DoggyBrain.GetReadableNameForDogAge(currentlySelectedSaveableDog.brain.dogAge);
			}
		}
	}

	private void UpdateTraits(SaveableDog dog)
	{
		OnTraitHoverStop();
		SetTraitForIndex(1, activeValue: false);
		SetTraitForIndex(2, activeValue: false);
		SetTraitForIndex(3, activeValue: false);
		SetTraitForIndex(4, activeValue: false);
		SetTraitForIndex(5, activeValue: false);
		SetTraitForIndex(6, activeValue: false);
		if (dog != null)
		{
			SaveableDogPersonality personality = dog.brain.personality;
			int num = 0;
			if (personality.foodPersonality != FoodPersonalityType.STANDARD)
			{
				num++;
				SetFoodPersonalityTraitForIndex(num, personality.foodPersonality);
			}
			if (personality.socialPersonality != SocialPersonalityType.STANDARD)
			{
				num++;
				SetSocialPersonalityTraitForIndex(num, personality.socialPersonality);
			}
			if (personality.energyPersonality != EnergyPersonalityType.STANDARD)
			{
				num++;
				SetEnergyPersonalityTraitForIndex(num, personality.energyPersonality);
			}
			if (personality.mischiefPersonality != MischiefPersonalityType.STANDARD)
			{
				num++;
				SetMischiefPersonalityTraitForIndex(num, personality.mischiefPersonality);
			}
			if (personality.nicenessPersonality != NicenessPersonalityType.STANDARD)
			{
				num++;
				SetNicenessPersonalityTraitForIndex(num, personality.nicenessPersonality);
			}
			if (personality.pettablePersonality != PettablePersonalityType.LIKES_PETTING)
			{
				num++;
				SetPettablePersonalityTraitForIndex(num, personality.pettablePersonality);
			}
			if (personality.loudnessPersonality != LoudnessPersonalityType.STANDARD)
			{
				num++;
				SetLoudnessPersonalityTraitForIndex(num, personality.loudnessPersonality);
			}
		}
	}

	private void SetFoodPersonalityTraitForIndex(int index, FoodPersonalityType trait)
	{
		switch (trait)
		{
		case FoodPersonalityType.FOOD_OBSESSED:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LIKESFOOD_NAME, ScriptLocalization.GUI.GUI_TRAIT_LIKESFOOD_DESC, gluttonTraitIcon);
			break;
		case FoodPersonalityType.FOOD_AVERSE:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESFOOD_NAME, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESFOOD_DESC, foodAverseTraitIcon);
			break;
		}
	}

	private void SetSocialPersonalityTraitForIndex(int index, SocialPersonalityType trait)
	{
		switch (trait)
		{
		case SocialPersonalityType.SOCIAL:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LIKESSOCIAL_NAME, ScriptLocalization.GUI.GUI_TRAIT_LIKESSOCIAL_DESC, socialTraitIcon);
			break;
		case SocialPersonalityType.ALOOF:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESSOCIAL_NAME, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESSOCIAL_DESC, aloofTraitIcon);
			break;
		}
	}

	private void SetEnergyPersonalityTraitForIndex(int index, EnergyPersonalityType trait)
	{
		switch (trait)
		{
		case EnergyPersonalityType.LAYABOUT:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LIKESSLEEP_NAME, ScriptLocalization.GUI.GUI_TRAIT_LIKESSLEEP_DESC, layaboutTraitIcon);
			break;
		case EnergyPersonalityType.GOOF:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESSLEEP_NAME, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESSLEEP_DESC, highEnergyTraitIcon);
			break;
		}
	}

	private void SetMischiefPersonalityTraitForIndex(int index, MischiefPersonalityType trait)
	{
		switch (trait)
		{
		case MischiefPersonalityType.POLITE:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESMISCHIEF_NAME, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESMISCHIEF_DESC, politeTraitIcon);
			break;
		case MischiefPersonalityType.MISCHEVIOUS:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LIKESMISCHIEF_NAME, ScriptLocalization.GUI.GUI_TRAIT_LIKESMISCHIEF_DESC, rudeTraitIcon);
			break;
		}
	}

	private void SetNicenessPersonalityTraitForIndex(int index, NicenessPersonalityType trait)
	{
		switch (trait)
		{
		case NicenessPersonalityType.NICE:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_NICE_NAME, ScriptLocalization.GUI.GUI_TRAIT_NICE_DESC, peacefulTraitIcon);
			break;
		case NicenessPersonalityType.MEAN:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_MEAN_NAME, ScriptLocalization.GUI.GUI_TRAIT_MEAN_DESC, antagonisticTraitIcon);
			break;
		}
	}

	private void SetPettablePersonalityTraitForIndex(int index, PettablePersonalityType trait)
	{
		if (trait == PettablePersonalityType.DISLIKES_PETTING)
		{
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_UNPETTABLE_NAME, ScriptLocalization.GUI.GUI_TRAIT_UNPETTABLE_DESC, unpettableTraitIcon);
		}
	}

	private void SetLoudnessPersonalityTraitForIndex(int index, LoudnessPersonalityType trait)
	{
		switch (trait)
		{
		case LoudnessPersonalityType.LOUD:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LOUD_NAME, ScriptLocalization.GUI.GUI_TRAIT_LOUD_DESC, loudTraitIcon);
			break;
		case LoudnessPersonalityType.QUIET:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_QUIET_NAME, ScriptLocalization.GUI.GUI_TRAIT_QUIET_DESC, quietTraitIcon);
			break;
		}
	}

	private DogPersonalityTrait GetTraitInfoForIndex(int index)
	{
		switch (index)
		{
		case 1:
			return selectedDogTrait1.GetComponent<DogPersonalityTrait>();
		case 2:
			return selectedDogTrait2.GetComponent<DogPersonalityTrait>();
		case 3:
			return selectedDogTrait3.GetComponent<DogPersonalityTrait>();
		case 4:
			return selectedDogTrait4.GetComponent<DogPersonalityTrait>();
		case 5:
			return selectedDogTrait5.GetComponent<DogPersonalityTrait>();
		case 6:
			return selectedDogTrait6.GetComponent<DogPersonalityTrait>();
		default:
			Debug.LogError("No trait for index: " + index);
			return null;
		}
	}

	private void SetTraitForIndex(int index, bool activeValue, string traitName = "", string traitDescription = "", Sprite icon = null)
	{
		Image image2 = null;
		switch (index)
		{
		case 1:
			image2 = selectedDogTrait1;
			break;
		case 2:
			image2 = selectedDogTrait2;
			break;
		case 3:
			image2 = selectedDogTrait3;
			break;
		case 4:
			image2 = selectedDogTrait4;
			break;
		case 5:
			image2 = selectedDogTrait5;
			break;
		case 6:
			image2 = selectedDogTrait6;
			break;
		}
		if (image2 == null)
		{
			Debug.LogError("Attempting to access a trait for index " + index + " but no UI exists that maps to that index.");
			return;
		}
		image2.sprite = icon;
		image2.gameObject.SetActive(activeValue);
		image2.GetComponent<DogPersonalityTrait>().SetTrait(traitName, traitDescription);
	}

	public SaveableThumbSet GetSaveableThumbsetForDogID(ulong? dogID)
	{
		if (currentThumbs.ContainsKey(dogID.Value))
		{
			return new SaveableThumbSet(currentThumbs[dogID.Value].GetThumbnailSet());
		}
		return null;
	}

	public ThumbnailSet GetThumbnailSetForDogID(ulong dogID)
	{
		return thumbSets[dogID];
	}

	public Sprite GetDefaultThumbnailForDogID(ulong? dogID)
	{
		if (thumbSets.ContainsKey(dogID.Value))
		{
			return thumbSets[dogID.Value].defaultThumb;
		}
		return null;
	}

	private void OnDogDeselected(ulong? dogID, bool forceDisableTag = false)
	{
		currentlySelectedDog = null;
		currentlySelectedSaveableDog = null;
		if (camFocus.GetFollowTarget() == null)
		{
			followCamButton.SetActive(value: false);
		}
		dogPortraitButton.SetActive(value: false);
		UpdateTraits(null);
		dogNameText.text = "";
		dogAgeHolder.SetActive(value: false);
		selectedDogPortraitSprite.sprite = null;
		for (int i = 0; i < statBars.Count; i++)
		{
			statBars[i].SetBrainRef(null);
			statBars[i].SetSaveableDogRef(null);
		}
		if (!dogID.HasValue || !currentThumbs.ContainsKey(dogID.Value))
		{
			return;
		}
		currentThumbs[dogID.Value].SetSelected(selectedVal: false);
		if (!dogRegRef.GetSaveableDogFromID(dogID.Value).inCocoon)
		{
			dogRegRef.GetDogFromID(dogID.Value).GetComponent<DogIndicatorController>().OnDogDeselected(forceDisableTag);
			return;
		}
		GameObject cocoonForDogID = GetCocoonForDogID(dogID.Value);
		if (cocoonForDogID != null)
		{
			GameObject indicator = cocoonForDogID.GetComponent<Cocoon>().GetIndicator();
			if (indicator != null)
			{
				indicator.GetComponent<CocoonIndicator>().OnDogDeselected();
			}
		}
	}

	public bool HasThumbBeenPlacedForDogID(ulong dogID)
	{
		return currentThumbs.ContainsKey(dogID);
	}

	public DogStorageBox GetUsableDogStorageBox()
	{
		if (dogStorageBoxes.Count == 0)
		{
			return Object.Instantiate(dogStorageBoxPrefab).GetComponent<DogStorageBox>();
		}
		DogStorageBox dogStorageBox = dogStorageBoxes[0];
		dogStorageBox.gameObject.SetActive(value: true);
		dogStorageBoxes.RemoveAt(0);
		return dogStorageBox;
	}

	public void RecycleDogStorageBox(DogStorageBox box)
	{
		box.Recycle();
		box.gameObject.SetActive(value: false);
		dogStorageBoxes.Add(box);
	}

	public void CacheThumbnailForDogID(ulong dogID)
	{
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(dogID);
		if (!saveableDogFromID.inWorld || sceneRef.GetGameMode() != GameMode.HOME)
		{
			if (saveableDogFromID.thumbSet != null)
			{
				thumbSetKeys.Add(dogID);
				thumbSets[dogID] = saveableDogFromID.thumbSet.Load();
				GameObject gameObject = Object.Instantiate(dogStorageBoxPrefab);
				gameObject.SetActive(value: false);
				dogStorageBoxes.Add(gameObject.GetComponent<DogStorageBox>());
			}
		}
		else
		{
			if (HasThumbBeenPlacedForDogID(dogID))
			{
				return;
			}
			GameObject obj = Object.Instantiate(thumbnailPrefab);
			DogThumbnail component = obj.GetComponent<DogThumbnail>();
			obj.transform.SetParent(base.transform);
			obj.transform.localScale = Vector3.one;
			obj.transform.localRotation = Quaternion.identity;
			if (!thumbSetKeys.Contains(dogID))
			{
				thumbSetKeys.Add(dogID);
				if (saveableDogFromID.inCocoon && saveableDogFromID.thumbSet != null)
				{
					thumbSets[dogID] = saveableDogFromID.thumbSet.Load();
					component.SetDog(dogRegRef, dogID, this);
				}
				else
				{
					component.SetDog(dogRegRef, dogID, this);
					thumbSets[dogID] = component.GetThumbnailSet();
				}
			}
			else
			{
				component.SetDog(dogRegRef, dogID, this);
			}
			thumbKeys.Add(dogID);
			currentThumbs[dogID] = component;
			PlaceThumb(component, currentThumbs.Count);
			if (!currentlySelectedDog.HasValue)
			{
				OnDogSelected(dogID);
			}
			CheckCocoonableThumbs(dogID);
		}
	}

	public void ClearAllThumbnailsForDog(ulong dogID, bool fromHatch = false)
	{
		RemoveDog(dogID, fromHatch);
		if (thumbSetKeys.Contains(dogID))
		{
			thumbSets.Remove(dogID);
			thumbSetKeys.Remove(dogID);
		}
	}

	public void RemoveDog(ulong dogID, bool fromHatch = false)
	{
		if (!currentThumbs.ContainsKey(dogID))
		{
			return;
		}
		Object.Destroy(currentThumbs[dogID].gameObject);
		thumbKeys.Remove(dogID);
		currentThumbs.Remove(dogID);
		for (int i = 0; i < thumbKeys.Count; i++)
		{
			PlaceThumb(currentThumbs[thumbKeys[i]], i + 1);
		}
		if (dogID == currentlySelectedDog && !fromHatch)
		{
			if (thumbKeys.Count > 0)
			{
				OnDogSelected(thumbKeys[0]);
			}
			else
			{
				OnDogDeselected(dogID);
			}
		}
	}

	private void PlaceThumb(DogThumbnail thumb, int thumbNum)
	{
		float num = thumb.thumbnailBox.sprite.bounds.extents.x * 2f + separationX;
		float num2 = thumb.thumbnailBox.sprite.bounds.extents.y * 2f + separationY;
		float num3 = (float)Mathf.CeilToInt((float)thumbNum / dogsPerRow) - 1f;
		float num4 = (float)(thumbNum - 1) - num3 * dogsPerRow;
		thumb.transform.localPosition = new Vector3(num4 * num, num3 * num2, 0f);
	}

	public void ShowSelectedGut()
	{
		if (!currentlySelectedDog.HasValue)
		{
			return;
		}
		if (dogGutGUIRef != null)
		{
			Debug.LogError("Attempting to open the gut GUI when it's already open.");
			return;
		}
		camFocus.DisableModularZoom();
		guiRef.DisableBG(LockReason.GUT_GUI);
		GameObject gameObject = Object.Instantiate(dogGutGUIPrefab, Vector3.zero, Quaternion.identity);
		dogGutGUIRef = gameObject.GetComponent<DogGutGUIManager>();
		GameObject dogFromID = dogRegRef.GetDogFromID(currentlySelectedDog.Value);
		if (dogFromID == null)
		{
			CloseGutGUI();
			return;
		}
		dogGutGUIRef.SetControllerRef(this);
		dogGutGUIRef.SetAssociatedDog(dogFromID);
		dogGutGUIRef.SetDogGut(dogFromID.GetComponent<DogGutController>().GetDogGut());
		dogGutGUIRef.OnGUIOpened();
	}

	public void CloseGutGUIIfOpened()
	{
		if (dogGutGUIRef != null)
		{
			dogGutGUIRef.CloseGUI();
		}
	}

	public void CloseGutGUI()
	{
		if (!(dogGutGUIRef == null))
		{
			Object.Destroy(dogGutGUIRef.gameObject);
			dogGutGUIRef = null;
			camFocus.EnableModularZoom(camFocus.GetFocusedRoom());
			guiRef.EnableBG(LockReason.GUT_GUI);
		}
	}

	public void FocusOnSelectedDog()
	{
		if (followCamCancelButton.activeSelf)
		{
			camFocus.ClearFollowCam(fromRoomFocus: false, playSounds: true, playPenFocusSound: false);
		}
		else
		{
			FocusOnDog(currentlySelectedDog);
		}
	}

	private void FocusOnDog(ulong? dogID)
	{
		if (!dogID.HasValue)
		{
			return;
		}
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(dogID.Value);
		if (saveableDogFromID.inCocoon)
		{
			FocusOnCocoon(saveableDogFromID);
			return;
		}
		GameObject dogFromID = dogRegRef.GetDogFromID(dogID.Value);
		if (!(dogFromID == null))
		{
			GameObject bodyFront = dogFromID.GetComponent<LegController>().bodyFront;
			FocusOnObject(bodyFront);
		}
	}

	public GameObject GetCocoonForDogID(ulong dogID)
	{
		List<GameObject> allObjectsForTag = ObjectRegistration.GetRegistrationScript().GetAllObjectsForTag(TagsEnum.COCOON);
		for (int i = 0; i < allObjectsForTag.Count; i++)
		{
			if (allObjectsForTag[i].GetComponent<Cocoon>().GetAssociatedDogID() == dogID)
			{
				return allObjectsForTag[i];
			}
		}
		return null;
	}

	private void FocusOnCocoon(SaveableDog sd)
	{
		GameObject cocoonForDogID = GetCocoonForDogID(sd.dogID);
		if (cocoonForDogID != null)
		{
			FocusOnObject(cocoonForDogID.GetComponent<Cocoon>().GetFocusTransform().gameObject);
		}
		else
		{
			Debug.LogError("No cocoon found for Dog: " + sd.dogName);
		}
	}

	private void FocusOnObject(GameObject focusObj)
	{
		camFocus.RequestFollowCam(focusObj.transform);
	}
}
