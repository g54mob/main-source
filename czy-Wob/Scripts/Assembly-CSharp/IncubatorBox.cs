using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IncubatorBox : MonoBehaviour
{
	public Color defaultColor;

	public Color defaultColorDefaultEgg;

	public Color selectedColor;

	public Image rendererRef;

	public Image iconHolder;

	public GameObject counterObject;

	public TextMeshProUGUI counterText;

	private bool isDefault;

	private SaveableDogEgg containedItem;

	private CursorUpdateArea updateAreaRef;

	private IncubatorGUIController controllerRef;

	public void SetContainedItem(SaveableDogEgg eggRef, int number, bool defaultEgg = false)
	{
		containedItem = eggRef;
		iconHolder.sprite = controllerRef.eggItem.icon;
		if (number == 1)
		{
			counterObject.SetActive(value: false);
		}
		else
		{
			counterObject.SetActive(value: true);
			counterText.text = number.ToString();
		}
		isDefault = defaultEgg;
	}

	public bool IsDefaultEgg()
	{
		return isDefault;
	}

	public void SetControllerRef(IncubatorGUIController newRef, CursorUpdateArea areaRef)
	{
		controllerRef = newRef;
		updateAreaRef = areaRef;
	}

	public SaveableDogEgg GetContainedItem()
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
		if (isDefault)
		{
			rendererRef.color = defaultColorDefaultEgg;
		}
		else
		{
			rendererRef.color = defaultColor;
		}
	}

	public void OnCursorStay()
	{
		if (updateAreaRef != null)
		{
			updateAreaRef.ReportCursorOverContent();
		}
	}
}
