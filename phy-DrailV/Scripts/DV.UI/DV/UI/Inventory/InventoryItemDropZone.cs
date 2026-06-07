using System.Collections.Generic;
using DV.InventorySystem;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.Inventory
{
	public class InventoryItemDropZone : MonoBehaviour
	{
		[SerializeField]
		private bool itemContainerDropZone;

		[SerializeField]
		private List<Image> hoverImages;

		private List<Color> defaultColors;

		private AInventoryProvider provider;

		private Color defaultColor;

		public bool ItemContainerDropZone => itemContainerDropZone;

		private void Awake()
		{
			if (hoverImages == null)
			{
				return;
			}
			defaultColors = new List<Color>();
			foreach (Image hoverImage in hoverImages)
			{
				defaultColors.Add(hoverImage.color);
			}
		}

		public void SetProvider(AInventoryProvider provider)
		{
			this.provider = provider;
		}

		public int GetBackpackTargetSlot()
		{
			return provider.Inventory.GetFirstFreeBackpackSlot();
		}

		public void UpdateDragState(InventorySlotDisplayData data)
		{
			if (itemContainerDropZone || hoverImages == null || hoverImages.Count <= 0)
			{
				return;
			}
			if (defaultColors == null)
			{
				defaultColors = new List<Color>();
				foreach (Image hoverImage in hoverImages)
				{
					defaultColors.Add(hoverImage.color);
				}
			}
			if (data == null)
			{
				for (int i = 0; i < hoverImages.Count; i++)
				{
					hoverImages[i].color = defaultColors[i];
				}
				return;
			}
			AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
			AItemContainer aItemContainer = ((activeContainer != null) ? activeContainer.NestedIn.firstNest : null);
			bool flag = false;
			if (aItemContainer != null)
			{
				GameObject gameObject = data.Spec?.GetGameObject();
				if (gameObject != null)
				{
					flag = aItemContainer.ValidItem(gameObject) && aItemContainer.IndexOf(gameObject) < 0 && aItemContainer.ItemCount < aItemContainer.Capacity;
				}
			}
			else
			{
				flag = GetBackpackTargetSlot() - 12 >= 0 && !data.IsLocked;
			}
			Color color = (flag ? UIColors.GREEN : UIColors.RED);
			foreach (Image hoverImage2 in hoverImages)
			{
				hoverImage2.color = color;
			}
		}
	}
}
