using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace UniversalInventorySystem
{
	public class ItemDragHandler : MonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler, IBeginDragHandler
	{
		[Inject]
		private InventoryHandler inventoryHandler;

		[HideInInspector]
		public Canvas canvas;

		private RectTransform rectTransform;

		[HideInInspector]
		public InventoryUI invUI;

		private int index;

		public void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (invUI.togglableObject.activeInHierarchy)
			{
				if (invUI.inv.interactiable != InventoryProtection.Locked && invUI.GetInventory().slots[index].hasItem && invUI.GetInventory().slots[index].amount > 0 && (Mathf.RoundToInt(invUI.GetInventory().slots[index].amount / 2) > 0 || eventData.button != PointerEventData.InputButton.Right))
				{
					invUI.dragObj.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
					InventoryHandler.OnDragItemEventArgs odi = new InventoryHandler.OnDragItemEventArgs(invUI.inv, rectTransform.anchoredPosition, invUI.slots[int.Parse(base.transform.parent.name)]);
					inventoryHandler.BroadcastUIEvent(BroadcastEventType.ItemDragged, null, odi);
					invUI.isDraging = true;
				}
			}
			else
			{
				invUI.dragObj.SetActive(value: false);
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			invUI.canvas.GetComponent<ItemDropHandler>().OnDrop(eventData);
			if (invUI.shouldSwap)
			{
				float num = float.MaxValue;
				int targetSlot = 0;
				for (int i = 0; i < invUI.slots.Count; i++)
				{
					float num2 = Vector3.Distance(invUI.dragObj.transform.position, invUI.slots[i].GetComponent<RectTransform>().position);
					if (num2 <= num)
					{
						num = num2;
						targetSlot = i;
					}
				}
				if (invUI.dragObj.GetComponent<DragSlot>().GetAmount() >= 0)
				{
					invUI.inv.SwapItemsInCertainAmountInSlots(int.Parse(base.transform.parent.name), targetSlot, invUI.dragObj.GetComponent<DragSlot>().GetAmount());
				}
			}
			invUI.dragObj.SetActive(value: false);
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			float num = float.MaxValue;
			index = 0;
			for (int i = 0; i < invUI.slots.Count; i++)
			{
				float num2 = Vector3.Distance(rectTransform.position, invUI.slots[i].GetComponent<RectTransform>().position);
				if (num2 <= num)
				{
					num = num2;
					index = i;
				}
			}
			invUI.dragSlotNumber = index;
			if (!invUI.GetInventory().slots[index].hasItem || (Mathf.RoundToInt(invUI.GetInventory().slots[index].amount / 2) <= 0 && eventData.button == PointerEventData.InputButton.Right))
			{
				return;
			}
			invUI.dragObj.SetActive(value: true);
			GameObject dragObj = invUI.dragObj;
			RectTransform component = dragObj.GetComponent<RectTransform>();
			component.position = rectTransform.position;
			Vector2 sizeDelta = invUI.slots[index].GetComponent<RectTransform>().sizeDelta;
			component.sizeDelta = sizeDelta;
			for (int j = 0; j < dragObj.transform.childCount; j++)
			{
				Transform child = dragObj.transform.GetChild(j);
				if (child.TryGetComponent<Image>(out var component2))
				{
					for (int k = 0; k < invUI.slots[index].transform.childCount; k++)
					{
						if (invUI.slots[index].transform.GetChild(k).TryGetComponent<Image>(out var _))
						{
							component2.material.SetFloat("_Size", invUI.outlineSize);
							component2.material.SetColor("_Color", invUI.outlineColor);
							child.GetComponent<RectTransform>().sizeDelta = invUI.slots[index].transform.GetChild(k).GetComponent<RectTransform>().sizeDelta;
							child.GetComponent<RectTransform>().localPosition = invUI.slots[index].transform.GetChild(k).GetComponent<RectTransform>().localPosition;
							break;
						}
					}
				}
				else
				{
					if (!child.TryGetComponent<TextMeshProUGUI>(out var component4))
					{
						continue;
					}
					for (int l = 0; l < invUI.slots[index].transform.childCount; l++)
					{
						if (invUI.slots[index].transform.GetChild(l).TryGetComponent<TextMeshProUGUI>(out component4))
						{
							child.GetComponent<RectTransform>().sizeDelta = invUI.slots[index].transform.GetChild(l).GetComponent<RectTransform>().sizeDelta;
							child.GetComponent<RectTransform>().localPosition = invUI.slots[index].transform.GetChild(l).GetComponent<RectTransform>().localPosition;
							TextMeshProUGUI component5 = child.GetComponent<TextMeshProUGUI>();
							component5.fontSize = component4.fontSize;
							component5.color = component4.color;
							component5.alignment = component4.alignment;
							break;
						}
					}
				}
			}
			DragSlot component6 = dragObj.GetComponent<DragSlot>();
			int amount;
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				amount = invUI.inv.slots[index].amount;
				component6.SetAmount(amount);
			}
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				amount = Mathf.RoundToInt((float)invUI.inv.slots[index].amount / 2f);
				component6.SetAmount(amount);
			}
			else
			{
				amount = invUI.inv.slots[index].amount;
				component6.SetAmount(amount);
			}
			component6.SetInventory(invUI.GetInventory());
			component6.SetInventoryUI(invUI);
			component6.SetItem(invUI.GetInventory().slots[index].item);
			component6.SetSlotNumber(index);
			component6.SetDurability(invUI.GetInventory().slots[index].durability);
			if (invUI.GetInventory().slots[index].item.hasDurability && invUI.GetInventory().slots[index].item.durabilityImages.Count > 0)
			{
				Image componentInChildren = dragObj.GetComponentInChildren<Image>();
				componentInChildren.color = new Color(1f, 1f, 1f, 1f);
				componentInChildren.sprite = InventoryUI.GetNearestSprite(invUI.GetInventory(), invUI.GetInventory().slots[index].durability, index);
			}
			else
			{
				Image componentInChildren2 = dragObj.GetComponentInChildren<Image>();
				componentInChildren2.color = new Color(1f, 1f, 1f, 1f);
				componentInChildren2.sprite = invUI.inv.slots[index].item.sprite;
			}
			if (invUI.showAmount && invUI.GetInventory()[index].item.showAmount)
			{
				dragObj.GetComponentInChildren<TextMeshProUGUI>().text = amount.ToString();
			}
			else
			{
				dragObj.GetComponentInChildren<TextMeshProUGUI>().text = "";
			}
		}
	}
}
