using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrowableBox : MonoBehaviour
{
	public Color defaultColor;

	public Color selectedColor;

	public Image rendererRef;

	public Image iconHolder;

	public GameObject counterObject;

	public TextMeshProUGUI counterText;

	private GrowableObject containedItem;

	private GardenSignGUIController controllerRef;

	public void SetContainedItem(GrowableObject itemRef, int number)
	{
		containedItem = itemRef;
		iconHolder.sprite = itemRef.finalObject.icon;
		if (number == 1)
		{
			counterObject.SetActive(value: false);
			return;
		}
		counterObject.SetActive(value: true);
		counterText.text = number.ToString();
	}

	public void SetControllerRef(GardenSignGUIController newRef)
	{
		controllerRef = newRef;
	}

	public GrowableObject GetContainedItem()
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
}
