using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogStorageBox : MonoBehaviour
{
	public int boxIndex;

	public ulong associatedDogID;

	public SaveableDogCore associatedCore;

	public DogCore associatedCoreObject;

	public DogMemorial associatedMemorial;

	public BoxType boxType = BoxType.STORAGE;

	public SelectionType selectionType = SelectionType.STORAGE;

	public Image dogIcon;

	public GameObject coreIcon;

	public GameObject memorialIcon;

	public GameObject cocoonIcon;

	public GameObject labelIconHolder;

	public Image labelIconImage;

	public Image frontImage;

	public Image backingImage;

	public Image disabledImage;

	public TextMeshProUGUI lockedReasonText;

	public DogLabelType labelType;

	private float lockedIconAlpha = 0.5f;

	private ColorBlock chosenColorBlock;

	private ColorBlock selectedColorBlock;

	private ColorBlock deselectedColorBlock;

	private bool buttonEnabled;

	private CursorUpdateArea owningCursorUpdateArea;

	private CoreButtonUnityGUI buttonRef;

	private DogStorageGUIManager storageGUIRef;

	private DogBreedingSelectionGUIManager breedingGUIRef;

	private void Awake()
	{
		buttonRef = GetComponent<CoreButtonUnityGUI>();
		deselectedColorBlock = default(ColorBlock);
		deselectedColorBlock.colorMultiplier = 1f;
		deselectedColorBlock.normalColor = buttonRef.colors.normalColor;
		deselectedColorBlock.selectedColor = buttonRef.colors.normalColor;
		deselectedColorBlock.disabledColor = buttonRef.colors.disabledColor;
		deselectedColorBlock.pressedColor = buttonRef.colors.pressedColor;
		deselectedColorBlock.highlightedColor = buttonRef.colors.highlightedColor;
		selectedColorBlock = default(ColorBlock);
		selectedColorBlock.colorMultiplier = 1f;
		selectedColorBlock.normalColor = buttonRef.colors.pressedColor;
		selectedColorBlock.selectedColor = buttonRef.colors.pressedColor;
		selectedColorBlock.disabledColor = buttonRef.colors.disabledColor;
		selectedColorBlock.pressedColor = buttonRef.colors.pressedColor;
		selectedColorBlock.highlightedColor = buttonRef.colors.highlightedColor;
		chosenColorBlock = default(ColorBlock);
		chosenColorBlock.colorMultiplier = 1f;
		chosenColorBlock.normalColor = buttonRef.colors.highlightedColor;
		chosenColorBlock.selectedColor = buttonRef.colors.highlightedColor;
		chosenColorBlock.disabledColor = buttonRef.colors.highlightedColor;
		chosenColorBlock.pressedColor = buttonRef.colors.highlightedColor;
		chosenColorBlock.highlightedColor = buttonRef.colors.highlightedColor;
		buttonRef.colors = deselectedColorBlock;
		lockedReasonText.gameObject.SetActive(value: false);
	}

	public void Recycle()
	{
		dogIcon.sprite = null;
		base.transform.SetParent(null);
	}

	public bool IsButtonEnabled()
	{
		return buttonEnabled;
	}

	public void OnBoxStay()
	{
		if (owningCursorUpdateArea != null)
		{
			owningCursorUpdateArea.ReportCursorOverContent();
		}
	}

	public void OnBoxClicked()
	{
		if (storageGUIRef != null)
		{
			storageGUIRef.SelectBox(this);
		}
		else if (breedingGUIRef != null)
		{
			breedingGUIRef.SelectBox(this);
		}
	}

	public void SetBoxSelected()
	{
		buttonRef.colors = selectedColorBlock;
	}

	public void SetBoxDeselected()
	{
		buttonRef.colors = deselectedColorBlock;
		buttonRef.OnDeselect(null);
		buttonRef.enabled = false;
		buttonRef.enabled = true;
	}

	public void SetBoxChosen(string reason)
	{
		buttonRef.colors = chosenColorBlock;
		buttonRef.interactable = false;
		buttonRef.OnDeselect(null);
		lockedReasonText.text = reason;
		lockedReasonText.gameObject.SetActive(value: true);
		Image component = dogIcon.GetComponent<Image>();
		Image component2 = coreIcon.GetComponent<Image>();
		Image component3 = cocoonIcon.GetComponent<Image>();
		Image component4 = memorialIcon.GetComponent<Image>();
		dogIcon.color = new Color(component.color.r, component.color.g, component.color.b, lockedIconAlpha);
		component2.color = new Color(component2.color.r, component2.color.g, component2.color.b, lockedIconAlpha);
		labelIconImage.color = new Color(labelIconImage.color.r, labelIconImage.color.g, labelIconImage.color.b, lockedIconAlpha);
		component3.color = new Color(component3.color.r, component3.color.g, component3.color.b, lockedIconAlpha);
		component4.color = new Color(component4.color.r, component4.color.g, component4.color.b, lockedIconAlpha);
	}

	public void SetMemorialObject(DogMemorial memorialRef, DogRegistration dogRegRef, DogStorageGUIManager storageGUI, CursorUpdateArea areaRef, int index, DogBreedingSelectionGUIManager breedingGUI = null)
	{
		SetEnabled(val: true);
		associatedCore = null;
		associatedCoreObject = null;
		associatedMemorial = memorialRef;
		storageGUIRef = storageGUI;
		breedingGUIRef = breedingGUI;
		owningCursorUpdateArea = areaRef;
		boxIndex = index;
		coreIcon.SetActive(value: false);
		cocoonIcon.SetActive(value: false);
		memorialIcon.SetActive(value: true);
		selectionType = SelectionType.PENS;
		labelType = memorialRef.labelType;
		if (labelType == DogLabelType.NONE)
		{
			labelIconImage.sprite = null;
			labelIconHolder.SetActive(value: false);
		}
		else
		{
			labelIconHolder.SetActive(value: true);
			labelIconImage.sprite = dogRegRef.GetSpriteForLabel(labelType);
		}
		if (memorialRef.thumbSet != null && memorialRef.thumbSet.defaultPortrait != null)
		{
			dogIcon.sprite = memorialRef.thumbSet.defaultPortrait.Load();
		}
	}

	public void SetDogCoreObject(DogCore coreRef, DogRegistration dogRegRef, DogStorageGUIManager storageGUI, CursorUpdateArea areaRef, int index, DogBreedingSelectionGUIManager breedingGUI = null)
	{
		SetEnabled(val: true);
		associatedCore = null;
		associatedMemorial = null;
		associatedCoreObject = coreRef;
		storageGUIRef = storageGUI;
		breedingGUIRef = breedingGUI;
		owningCursorUpdateArea = areaRef;
		boxIndex = index;
		coreIcon.SetActive(value: true);
		cocoonIcon.SetActive(value: false);
		memorialIcon.SetActive(value: false);
		selectionType = SelectionType.PENS;
		labelType = coreRef.labelType;
		if (labelType == DogLabelType.NONE)
		{
			labelIconImage.sprite = null;
			labelIconHolder.SetActive(value: false);
		}
		else
		{
			labelIconHolder.SetActive(value: true);
			labelIconImage.sprite = dogRegRef.GetSpriteForLabel(labelType);
		}
		if (coreRef.thumbSet != null && coreRef.thumbSet.defaultPortrait != null)
		{
			dogIcon.sprite = coreRef.thumbSet.defaultPortrait.Load();
		}
	}

	public void SetDogCore(SaveableDogCore coreRef, DogRegistration dogRegRef, DogStorageGUIManager storageGUI, CursorUpdateArea areaRef, int index, DogBreedingSelectionGUIManager breedingGUI = null)
	{
		SetEnabled(val: true);
		associatedCore = coreRef;
		associatedMemorial = null;
		associatedCoreObject = null;
		storageGUIRef = storageGUI;
		breedingGUIRef = breedingGUI;
		owningCursorUpdateArea = areaRef;
		boxIndex = index;
		coreIcon.SetActive(value: true);
		cocoonIcon.SetActive(value: false);
		memorialIcon.SetActive(value: false);
		labelType = coreRef.labelType;
		if (labelType == DogLabelType.NONE)
		{
			labelIconImage.sprite = null;
			labelIconHolder.SetActive(value: false);
		}
		else
		{
			labelIconHolder.SetActive(value: true);
			labelIconImage.sprite = dogRegRef.GetSpriteForLabel(labelType);
		}
		dogIcon.sprite = coreRef.defaultThumbnail;
	}

	public void SetDog(ulong dogUID, DogRegistration dogRegRef, DogStorageGUIManager storageGUI, CursorUpdateArea areaRef, int index, DogBreedingSelectionGUIManager breedingGUI = null)
	{
		SetEnabled(val: true);
		associatedDogID = dogUID;
		storageGUIRef = storageGUI;
		breedingGUIRef = breedingGUI;
		owningCursorUpdateArea = areaRef;
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(dogUID);
		boxIndex = index;
		coreIcon.SetActive(value: false);
		cocoonIcon.SetActive(saveableDogFromID.inCocoon);
		memorialIcon.SetActive(value: false);
		labelType = saveableDogFromID.labelType;
		if (saveableDogFromID.favorite)
		{
			labelType = DogLabelType.STAR;
		}
		if (labelType == DogLabelType.NONE)
		{
			labelIconImage.sprite = null;
			labelIconHolder.SetActive(value: false);
		}
		else
		{
			labelIconHolder.SetActive(value: true);
			labelIconImage.sprite = dogRegRef.GetSpriteForLabel(labelType);
		}
		dogIcon.sprite = dogRegRef.GetDefaultThumbnailForDogID(dogUID, useCocoonSprite: false);
	}

	public void SetEnabled(bool val)
	{
		dogIcon.enabled = val;
		frontImage.enabled = val;
		backingImage.enabled = val;
		disabledImage.enabled = !val;
		if (!val)
		{
			storageGUIRef = null;
			breedingGUIRef = null;
			dogIcon.sprite = null;
			coreIcon.SetActive(value: false);
			cocoonIcon.SetActive(value: false);
			memorialIcon.SetActive(value: false);
			labelIconHolder.SetActive(value: false);
		}
		else
		{
			SetBoxDeselected();
		}
		buttonEnabled = val;
	}

	public void SetLocked(string reason)
	{
		SetBoxDeselected();
		buttonRef.interactable = false;
		backingImage.raycastTarget = false;
		lockedReasonText.text = reason;
		lockedReasonText.gameObject.SetActive(value: true);
		Image component = dogIcon.GetComponent<Image>();
		Image component2 = cocoonIcon.GetComponent<Image>();
		dogIcon.color = new Color(component.color.r, component.color.g, component.color.b, lockedIconAlpha);
		labelIconImage.color = new Color(labelIconImage.color.r, labelIconImage.color.g, labelIconImage.color.b, lockedIconAlpha);
		component2.color = new Color(component2.color.r, component2.color.g, component2.color.b, lockedIconAlpha);
	}

	public void SetUnlocked()
	{
		buttonRef.interactable = true;
		backingImage.raycastTarget = true;
		buttonRef.OnDeselect(null);
		lockedReasonText.gameObject.SetActive(value: false);
		Image component = dogIcon.GetComponent<Image>();
		Image component2 = cocoonIcon.GetComponent<Image>();
		dogIcon.color = new Color(component.color.r, component.color.g, component.color.b, 1f);
		labelIconImage.color = new Color(labelIconImage.color.r, labelIconImage.color.g, labelIconImage.color.b, 1f);
		component2.color = new Color(component2.color.r, component2.color.g, component2.color.b, 1f);
	}
}
