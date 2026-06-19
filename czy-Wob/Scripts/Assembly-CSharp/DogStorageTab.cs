using UnityEngine;
using UnityEngine.UI;

public class DogStorageTab : MonoBehaviour
{
	public DogLabelType tabType;

	public Color activeAndSelectedColor;

	private bool selected;

	private float deselectedXPos;

	private float selectedXPos = -25f;

	private ColorBlock selectedColorBlock;

	private ColorBlock deselectedColorBlock;

	private CoreButtonUnityGUI buttonRef;

	private DogStorageGUIManager storageManagerRef;

	private DogBreedingSelectionGUIManager breedingManagerRef;

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
		selectedColorBlock.selectedColor = activeAndSelectedColor;
		selectedColorBlock.disabledColor = buttonRef.colors.disabledColor;
		selectedColorBlock.pressedColor = activeAndSelectedColor;
		selectedColorBlock.highlightedColor = activeAndSelectedColor;
		buttonRef.colors = deselectedColorBlock;
	}

	public void SetStorageRef(DogStorageGUIManager newRef)
	{
		storageManagerRef = newRef;
	}

	public void SetBreedingRef(DogBreedingSelectionGUIManager newRef)
	{
		breedingManagerRef = newRef;
	}

	public void OnClicked()
	{
		if (selected)
		{
			SetDeselected();
		}
		else
		{
			SetSelected();
		}
	}

	public void SetSelected()
	{
		selected = true;
		buttonRef.colors = selectedColorBlock;
		buttonRef.OnDeselect(null);
		base.transform.localPosition = new Vector3(selectedXPos, base.transform.localPosition.y, base.transform.localPosition.z);
		if (storageManagerRef != null)
		{
			if (tabType == DogLabelType.CORE || tabType == DogLabelType.MEMORIAL)
			{
				storageManagerRef.OnCoreStorageTabSelected(tabType);
			}
			else
			{
				storageManagerRef.OnStorageTabSelected(tabType);
			}
		}
		if (breedingManagerRef != null)
		{
			breedingManagerRef.OnStorageTabSelected(tabType);
		}
	}

	public void SetDeselected()
	{
		selected = false;
		buttonRef.colors = deselectedColorBlock;
		buttonRef.OnDeselect(null);
		base.transform.localPosition = new Vector3(deselectedXPos, base.transform.localPosition.y, base.transform.localPosition.z);
		if (storageManagerRef != null)
		{
			if (tabType == DogLabelType.CORE || tabType == DogLabelType.MEMORIAL)
			{
				storageManagerRef.OnCoreStorageTabDeselected(tabType);
			}
			else
			{
				storageManagerRef.OnStorageTabDeselected(tabType);
			}
		}
		if (breedingManagerRef != null)
		{
			breedingManagerRef.OnStorageTabDeselected(tabType);
		}
	}
}
