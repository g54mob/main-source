using System.Collections.Generic;
using DV.Common;
using DV.InventorySystem;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI.Inventory
{
	public class UIElementTooltipWithContainerContentIcons : UIElementTooltip, ITooltipIcons
	{
		private InventoryGridElement gridElement;

		private List<Sprite> icons = new List<Sprite>();

		public List<Sprite> GetIcons()
		{
			icons.Clear();
			if (gridElement == null)
			{
				gridElement = GetComponentInParent<InventoryGridElement>();
			}
			if (gridElement == null)
			{
				return icons;
			}
			AItemContainer aItemContainer = gridElement.Data?.ItemContainer;
			if (aItemContainer == null)
			{
				return icons;
			}
			for (int i = 0; i < aItemContainer.Capacity; i++)
			{
				GameObject gameObject = aItemContainer[i];
				IInventoryItemSpec inventoryItemSpec = ((gameObject != null) ? gameObject.GetComponent<IInventoryItemSpec>() : null);
				if (inventoryItemSpec != null)
				{
					Sprite itemIconSprite = inventoryItemSpec.ItemIconSprite;
					if (!(itemIconSprite == null))
					{
						icons.Add(itemIconSprite);
					}
				}
			}
			return icons;
		}
	}
}
