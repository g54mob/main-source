using System;
using System.Collections.Generic;
using DV.Common;
using DV.InventorySystem;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DV.UI.Inventory
{
	public class InventorySlotVisualController : UIBehaviour
	{
		[SerializeField]
		private Image unlockedImage;

		[SerializeField]
		private Image lockedImage;

		[SerializeField]
		private Image itemImage;

		[SerializeField]
		private Image beltVisibleImage;

		[SerializeField]
		private List<Image> containerAccessImages;

		[SerializeField]
		private ButtonDV lockButton;

		[SerializeField]
		private ButtonDV getButton;

		[SerializeField]
		private ButtonDV toggleBeltButton;

		[SerializeField]
		private ButtonDV resetBeltButton;

		[SerializeField]
		private ButtonDV itemContainerAccessButton;

		[SerializeField]
		private ButtonDV inventoryButton;

		[SerializeField]
		private Image itemContainerAccessDragImage;

		[SerializeField]
		private Image itemContainerAccessButtonHoverImage;

		[SerializeField]
		private Sprite containerAccessSprite;

		[SerializeField]
		private Sprite magazineLoadSprite;

		[SerializeField]
		private Sprite magazineUnloadSprite;

		private Sprite fallbackSprite;

		private InventorySlotDisplayData dataToUseOnEnable;

		private InventorySlotDisplayData currentData;

		private UIDragElement dragElement;

		public bool dragDisabled;

		[NonSerialized]
		public AItemContainer controllerContainer;

		[NonSerialized]
		public bool isHandSlot;

		private InventoryUIController uIController;

		private DV.InventorySystem.Inventory inventory;

		private Color validHoverColor = UIColors.GREEN;

		private Color invalidHoverColor = UIColors.RED;

		private Color neutralHoverColor;

		private Color neutralContainerAccessButtonHoverColor;

		private UIElementTooltipNonLocalizedTextWithIcons tooltip;

		private AItemContainer itemSlotContainer;

		private InventorySlotDisplayData DraggedData
		{
			get
			{
				if (!(uIController != null))
				{
					return null;
				}
				return uIController.draggedData;
			}
		}

		private AItemContainer ActiveContainer
		{
			get
			{
				if (!(inventory != null))
				{
					return null;
				}
				return inventory.ItemContainerRegistry.ActiveContainer;
			}
		}

		protected override void Awake()
		{
			fallbackSprite = itemImage.sprite;
			base.Awake();
			neutralHoverColor = itemContainerAccessDragImage.color;
			neutralContainerAccessButtonHoverColor = itemContainerAccessButtonHoverImage.color;
		}

		protected override void OnEnable()
		{
			if (dataToUseOnEnable != null)
			{
				UpdateVisuals(dataToUseOnEnable);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (itemSlotContainer != null)
			{
				itemSlotContainer.ItemContainerDataChanged -= OnItemSlotContainerDataChanged;
				itemSlotContainer.AboutToBeDestroyed -= OnItemSlotContainerAboutToBeDestroyed;
			}
		}

		public void AddInventoryReferences(AInventoryUIController controller)
		{
			uIController = controller as InventoryUIController;
			if (uIController != null)
			{
				inventory = uIController.provider.Inventory;
			}
			else
			{
				Debug.LogError("InventorySlotVisualController: Missing InventoryUIController reference InventoryUIController. Some visuals will be wrong.", this);
			}
		}

		public void UpdateVisuals(InventorySlotDisplayData data)
		{
			if (data == null)
			{
				Debug.LogError("InventorySlotVisualController needs valid data to properly set the visuals. Aborting...", this);
				return;
			}
			if (!base.gameObject.activeInHierarchy)
			{
				dataToUseOnEnable = data;
				return;
			}
			dataToUseOnEnable = null;
			if (itemSlotContainer != null)
			{
				itemSlotContainer.ItemContainerDataChanged -= OnItemSlotContainerDataChanged;
				itemSlotContainer.AboutToBeDestroyed -= OnItemSlotContainerAboutToBeDestroyed;
			}
			Sprite sprite = null;
			IInventoryItemSpec spec = data.Spec;
			bool flag = spec != null;
			if (flag)
			{
				sprite = (data.IsGhost ? spec.ItemIconSpriteDropped : spec.ItemIconSprite);
				itemSlotContainer = data.ItemContainer;
				if (itemSlotContainer != null)
				{
					itemSlotContainer.ItemContainerDataChanged += OnItemSlotContainerDataChanged;
					itemSlotContainer.AboutToBeDestroyed += OnItemSlotContainerAboutToBeDestroyed;
				}
			}
			else
			{
				itemSlotContainer = null;
			}
			if (sprite == null)
			{
				sprite = fallbackSprite;
			}
			itemImage.sprite = sprite;
			itemImage.gameObject.SetActive(flag);
			if (!tooltip)
			{
				tooltip = GetComponent<UIElementTooltipNonLocalizedTextWithIcons>();
			}
			tooltip.icons.Clear();
			if (flag)
			{
				if (itemSlotContainer == null || itemSlotContainer.ItemCount <= 0)
				{
					tooltip.text = spec.LocalizedName + "\n" + spec.LocalizedDescription;
				}
				else
				{
					tooltip.text = $"{spec.LocalizedName} ({itemSlotContainer.ItemCount})";
					int itemCount = itemSlotContainer.ItemCount;
					int num = 0;
					for (int i = 0; i < itemSlotContainer.Capacity; i++)
					{
						GameObject gameObject = itemSlotContainer[i];
						IInventoryItemSpec inventoryItemSpec = ((gameObject != null) ? gameObject.GetComponent<IInventoryItemSpec>() : null);
						if (inventoryItemSpec != null)
						{
							tooltip.icons.Add(inventoryItemSpec.ItemIconSprite);
							if (++num >= itemCount)
							{
								break;
							}
						}
					}
				}
			}
			else
			{
				tooltip.text = "";
			}
			if (data.IsLockable && flag)
			{
				lockButton.gameObject.SetActive(value: true);
				lockedImage.gameObject.SetActive(data.IsLocked);
				unlockedImage.gameObject.SetActive(value: true);
			}
			else
			{
				lockButton.gameObject.SetActive(value: false);
			}
			if (dragElement == null)
			{
				dragElement = GetComponent<UIDragElement>();
			}
			bool flag2 = dragElement.IsDragging || (data.Spec != null && !data.IsGhost);
			dragElement.enabled = !dragDisabled && flag2;
			bool active = data.ItemGetterAllowed && data.IsItemGetter && data.IsGhost && !dragElement.IsDragging;
			getButton.gameObject.SetActive(active);
			bool flag3 = data.BeltAllowed && data.IsBelt;
			beltVisibleImage.gameObject.SetActive(data.BeltVisible);
			toggleBeltButton.gameObject.SetActive(flag3);
			resetBeltButton.gameObject.SetActive(flag3 && data.BeltVisible);
			currentData = data;
			UpdateButtonsAndHovers(DraggedData, inventoryButton.IsHovered, itemContainerAccessButton.IsHovered);
		}

		private void OnItemSlotContainerAboutToBeDestroyed(AItemContainer container)
		{
			itemSlotContainer.ItemContainerDataChanged -= OnItemSlotContainerDataChanged;
			itemSlotContainer.AboutToBeDestroyed -= OnItemSlotContainerAboutToBeDestroyed;
			itemSlotContainer = null;
		}

		private void OnItemSlotContainerDataChanged(AItemContainer container, int sourceindex, int destinationindex)
		{
			UpdateVisuals(currentData);
		}

		public void HoverUpdate(InventorySlotDisplayData draggedData, bool hovered)
		{
			UpdateButtonsAndHovers(draggedData, hovered, itemContainerAccessButton.IsHovered);
		}

		public void DragUpdate(InventorySlotDisplayData draggedData, bool dragStart)
		{
			UpdateButtonsAndHovers(draggedData, inventoryButton.IsHovered, itemContainerAccessButton.IsHovered);
		}

		public void ItemContainerAccessHoverUpdate(InventorySlotDisplayData draggedData, bool hovered)
		{
			UpdateButtonsAndHovers(draggedData, inventoryButton.IsHovered, hovered);
		}

		private void UpdateButtonsAndHovers(InventorySlotDisplayData draggedData, bool slotHovered, bool accessHovered)
		{
			if (currentData == null)
			{
				return;
			}
			bool flag = draggedData != null;
			GameObject item = (flag ? draggedData.Spec.GetGameObject() : null);
			bool flag2 = slotHovered || accessHovered;
			bool flag3 = (flag2 || flag) && currentData.ContainerAccessAllowed && !currentData.IsGhost && itemSlotContainer != null;
			if (flag3 && itemSlotContainer != null && !itemSlotContainer.DirectInteractionAllowed)
			{
				flag3 = itemSlotContainer.QuickDropAllowed && ((!flag || !(draggedData.ItemContainer != itemSlotContainer)) ? (slotHovered && itemSlotContainer[0] != null) : itemSlotContainer.ValidItem(item));
			}
			if (flag3)
			{
				Sprite sprite = ((!itemSlotContainer.DirectInteractionAllowed) ? ((itemSlotContainer[0] != null) ? magazineUnloadSprite : magazineLoadSprite) : containerAccessSprite);
				foreach (Image containerAccessImage in containerAccessImages)
				{
					containerAccessImage.sprite = sprite;
				}
			}
			if (itemContainerAccessButton.gameObject.activeSelf != flag3)
			{
				itemContainerAccessButton.gameObject.SetActive(flag3);
			}
			if (!flag2)
			{
				return;
			}
			if (!flag)
			{
				itemContainerAccessDragImage.color = neutralHoverColor;
				itemContainerAccessButtonHoverImage.color = neutralContainerAccessButtonHoverColor;
				return;
			}
			IInventoryItemSpec spec = currentData.Spec;
			if (spec != null && spec == draggedData.Spec)
			{
				itemContainerAccessDragImage.color = ((currentData.IsGhost || accessHovered) ? neutralHoverColor : invalidHoverColor);
				itemContainerAccessButtonHoverImage.color = neutralHoverColor;
				return;
			}
			if (accessHovered)
			{
				bool flag4 = itemSlotContainer.ValidItem(item) && (!itemSlotContainer.DirectInteractionAllowed || (itemSlotContainer.ItemCount < itemSlotContainer.Capacity && itemSlotContainer.IndexOf(item) < 0));
				itemContainerAccessDragImage.color = (flag4 ? validHoverColor : invalidHoverColor);
				itemContainerAccessButtonHoverImage.color = (flag4 ? validHoverColor : invalidHoverColor);
				return;
			}
			bool isHandData = draggedData.IsHandData;
			bool isContainerData = currentData.IsContainerData;
			if (isHandData)
			{
				bool flag5 = false;
				if (currentData.IsHandData)
				{
					itemContainerAccessDragImage.color = invalidHoverColor;
					itemContainerAccessButtonHoverImage.color = invalidHoverColor;
				}
				else
				{
					flag5 = ((!isContainerData) ? (!currentData.IsGhost && inventory.CanAddItem(item)) : controllerContainer.ValidItem(item));
					itemContainerAccessDragImage.color = (flag5 ? neutralHoverColor : invalidHoverColor);
					itemContainerAccessButtonHoverImage.color = (flag5 ? validHoverColor : invalidHoverColor);
				}
				return;
			}
			bool isContainerData2 = draggedData.IsContainerData;
			GameObject gameObject = spec?.GetGameObject();
			if (isHandSlot)
			{
				bool flag6 = false;
				flag6 = ((gameObject == null) ? (!draggedData.IsHandData) : ((!isContainerData2) ? inventory.CanAddItem(gameObject) : (ActiveContainer?.ValidItem(gameObject) ?? false)));
				itemContainerAccessDragImage.color = (flag6 ? neutralHoverColor : invalidHoverColor);
				itemContainerAccessButtonHoverImage.color = (flag6 ? validHoverColor : invalidHoverColor);
				return;
			}
			if (isContainerData)
			{
				bool flag7 = false;
				flag7 = isContainerData2 || ((spec != null) ? (controllerContainer.ValidItem(item) && ((!draggedData.IsLocked && !draggedData.IsItemGetter) || inventory.CanAddItem(gameObject))) : controllerContainer.ValidItem(item));
				itemContainerAccessDragImage.color = (flag7 ? neutralHoverColor : invalidHoverColor);
				itemContainerAccessButtonHoverImage.color = (flag7 ? validHoverColor : invalidHoverColor);
				return;
			}
			bool flag8;
			int num;
			if (isContainerData2)
			{
				flag8 = false;
				if (spec == null)
				{
					flag8 = !draggedData.IsLocked;
					goto IL_04c4;
				}
				if (!currentData.IsGhost)
				{
					AItemContainer activeContainer = ActiveContainer;
					if ((object)activeContainer != null && activeContainer.ValidItem(gameObject))
					{
						num = (((!currentData.IsLocked && !currentData.IsItemGetter) || inventory.CanAddItem(item)) ? 1 : 0);
						goto IL_04c2;
					}
				}
				num = 0;
				goto IL_04c2;
			}
			bool flag9 = false;
			flag9 = ((!(gameObject == null)) ? (!draggedData.IsLocked && !currentData.IsLocked && !currentData.IsGhost) : (!draggedData.IsLocked));
			itemContainerAccessDragImage.color = (flag9 ? neutralHoverColor : invalidHoverColor);
			itemContainerAccessButtonHoverImage.color = (flag9 ? validHoverColor : invalidHoverColor);
			return;
			IL_04c4:
			itemContainerAccessDragImage.color = (flag8 ? neutralHoverColor : invalidHoverColor);
			itemContainerAccessButtonHoverImage.color = (flag8 ? validHoverColor : invalidHoverColor);
			return;
			IL_04c2:
			flag8 = (byte)num != 0;
			goto IL_04c4;
		}
	}
}
