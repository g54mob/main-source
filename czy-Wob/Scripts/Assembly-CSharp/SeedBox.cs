using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedBox : MonoBehaviour
{
	public Color defaultColor;

	public Color selectedColor;

	public Image rendererRef;

	public Image iconHolder;

	public GameObject counterObject;

	public TextMeshProUGUI counterText;

	private InventoryItem containedItem;

	private CursorUpdateArea updateAreaRef;

	private SeedPlantingGUIController controllerRef;

	public void SetContainedItem(InventoryItem itemRef, int number)
	{
		containedItem = itemRef;
		iconHolder.sprite = itemRef.icon;
		if (number == 1)
		{
			counterObject.SetActive(value: false);
			return;
		}
		counterObject.SetActive(value: true);
		counterText.text = number.ToString();
	}

	public void SetControllerRef(SeedPlantingGUIController newRef, CursorUpdateArea areaRef)
	{
		controllerRef = newRef;
		updateAreaRef = areaRef;
	}

	public InventoryItem GetContainedItem()
	{
		return containedItem;
	}

	public void OnClick()
	{
		controllerRef.SelectBox(this);
	}

	public void OnSelected()
	{
		rendererRef.color = selectedColor;
	}

	public void OnDeselected()
	{
		rendererRef.color = defaultColor;
	}

	public void OnCursorStay()
	{
		updateAreaRef.ReportCursorOverContent();
	}
}
