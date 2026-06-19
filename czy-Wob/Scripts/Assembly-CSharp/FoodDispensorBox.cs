using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodDispensorBox : MonoBehaviour
{
	public Image iconHolder;

	public TextMeshProUGUI nameText;

	public CoreButtonUnityGUI boxButton;

	private int associatedIndex;

	private InventoryItem associatedItem;

	private string mysteryString = "????";

	private CursorUpdateArea updateAreaRef;

	private FoodDispensorBoxes boxesRef;

	public void SetBoxesRef(FoodDispensorBoxes newRef, CursorUpdateArea areaRef)
	{
		boxesRef = newRef;
		updateAreaRef = areaRef;
	}

	public void SetAssociatedItem(InventoryItem newItem, int index, bool unlocked)
	{
		associatedIndex = index;
		associatedItem = newItem;
		iconHolder.sprite = newItem.icon;
		if (unlocked)
		{
			boxButton.interactable = true;
			iconHolder.color = Color.white;
			nameText.text = newItem.itemNameLocalized;
		}
		else
		{
			nameText.text = mysteryString;
			boxButton.interactable = false;
			iconHolder.color = Color.black;
		}
	}

	public InventoryItem GetAssociateditem()
	{
		return associatedItem;
	}

	public void Deselect()
	{
	}

	public void OnBoxSelected()
	{
		boxButton.Select();
		boxesRef.OnBoxSelected(associatedIndex, fromBox: true);
	}

	public void OnCursorStay()
	{
		updateAreaRef.ReportCursorOverContent();
	}
}
