using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemReceiverExample : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerUpHandler
{
	private RectTransform myTransform;

	private Vector3 originalPosition;

	public UltimateRadialButtonInfo newRadialButtonInfo;

	private int itemCount;

	private static List<int> usedIndex = new List<int>();

	public Sprite placeholderIcon;

	private void Start()
	{
		myTransform = GetComponent<RectTransform>();
		originalPosition = myTransform.localPosition;
	}

	public void OnDrag(PointerEventData eventData)
	{
		myTransform.position = eventData.position;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		int currentButtonIndex = UltimateRadialMenu.GetUltimateRadialMenu("ItemWheelExample").CurrentButtonIndex;
		if (currentButtonIndex >= 0 && !usedIndex.Contains(currentButtonIndex) && !newRadialButtonInfo.ExistsOnRadialMenu())
		{
			UltimateRadialMenu.RegisterToRadialMenu("ItemWheelExample", UseItem, newRadialButtonInfo, currentButtonIndex);
			usedIndex.Add(currentButtonIndex);
		}
		itemCount++;
		if (newRadialButtonInfo.ExistsOnRadialMenu())
		{
			newRadialButtonInfo.UpdateText(itemCount.ToString());
		}
		myTransform.localPosition = originalPosition;
	}

	private void UseItem()
	{
		itemCount--;
		newRadialButtonInfo.UpdateText(itemCount.ToString());
		if (itemCount <= 0)
		{
			usedIndex.Remove(newRadialButtonInfo.GetButtonIndex);
			newRadialButtonInfo.UpdateText("Text");
			newRadialButtonInfo.radialButton.icon.sprite = placeholderIcon;
			newRadialButtonInfo.RemoveInfoFromRadialButton();
		}
	}
}
