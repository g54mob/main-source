using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	public class IngredientSlot : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image background;

		[SerializeField]
		private Image lockedIcon;

		[SerializeField]
		private bool lockedSlot;

		public static IngredientSlot currentHoveredSlot;

		public string authorizedItemName;

		public SlotableItem ItemSlotted { get; private set; }

		public event Action<bool, SlotableItem> OnItemSlotChanged;

		private void Start()
		{
			SlotableItem.OnItemDragged += LockSlot;
			if (lockedSlot)
			{
				background.sprite = MonoSingleton<UI_CocktailCraft>.Instance.LockedSlotSprite;
			}
			lockedIcon.enabled = lockedSlot;
		}

		private void LockSlot(bool p_itemDragged)
		{
			_ = ItemSlotted == null;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (ItemSlotted == null)
			{
				currentHoveredSlot = this;
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			currentHoveredSlot = null;
		}

		public bool IsAuthorised(string p_itemName)
		{
			if (lockedSlot)
			{
				return false;
			}
			if (ItemSlotted != null)
			{
				return false;
			}
			if (authorizedItemName == "")
			{
				return true;
			}
			return authorizedItemName == p_itemName;
		}

		public void AddItemToSlot(SlotableItem p_item)
		{
			if (ItemSlotted != null)
			{
				ItemSlotted.OnUnslottedItem -= UnslotItem;
			}
			ItemSlotted = p_item;
			background.sprite = ((ItemSlotted != null) ? MonoSingleton<UI_CocktailCraft>.Instance.usedSlotSprite : MonoSingleton<UI_CocktailCraft>.Instance.FreeSlotSprite);
			if (ItemSlotted != null)
			{
				ItemSlotted.OnUnslottedItem += UnslotItem;
				this.OnItemSlotChanged?.Invoke(arg1: true, ItemSlotted);
			}
		}

		public void UnslotItem()
		{
			if (ItemSlotted != null)
			{
				this.OnItemSlotChanged?.Invoke(arg1: false, ItemSlotted);
				ItemSlotted.OnUnslottedItem -= UnslotItem;
			}
			ItemSlotted = null;
			background.sprite = ((ItemSlotted != null) ? MonoSingleton<UI_CocktailCraft>.Instance.usedSlotSprite : MonoSingleton<UI_CocktailCraft>.Instance.FreeSlotSprite);
		}
	}
}
