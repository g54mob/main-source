using System;
using Helpers.Extensions;
using Restory.Data.Localization;
using Restory.ObjectPools;
using Restory.StorageSystem;
using Restory.StorageSystem.StorageElements;
using Restory.UI.Views.StorageSlotElements;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Inventory.StorageSlotElements
{
	public sealed class StorageSlotElement : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private StorageSlotElementView view;

		[SerializeField]
		private Vector2 tooltipOffset = Vector2.right * 5f;

		private IReadOnlyStorageSlot item;

		private InventoryItemTooltipView currentTooltip;

		private TooltipContainer tooltipContainer;

		private InventoryItemTooltipViewPool inventoryItemTooltipPool;

		private LocalizationSystem localizationSystem;

		private bool isHolding;

		public IReadOnlyStorageSlot Item => item;

		public StorageSlotElementView View => view;

		public bool Selected => view.Selected;

		public event Action<StorageSlotElement> OnSelectedChanged;

		public event Action<StorageSlotElement> OnDrag;

		[Inject]
		private void Construct(InventoryItemTooltipViewPool inventoryItemTooltipPool, TooltipContainer tooltipContainer, LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
			this.inventoryItemTooltipPool = inventoryItemTooltipPool;
			this.tooltipContainer = tooltipContainer;
		}

		private void OnEnable()
		{
			view.PointerClick += OnPointerClick;
			view.PointerEnter += OnPointerEnter;
			view.PointerExit += OnPointerExit;
			view.PointerDown += OnPointerDown;
			view.PointerUp += OnPointerUp;
			view.PointerMove += OnPointerMove;
			if (item != null)
			{
				item.SlotChanged += OnSlotChanged;
			}
			UpdateView();
		}

		private void OnDisable()
		{
			if (item != null)
			{
				item.SlotChanged -= OnSlotChanged;
			}
			view.PointerExit -= OnPointerExit;
			view.PointerEnter -= OnPointerEnter;
			view.PointerClick -= OnPointerClick;
			view.PointerDown -= OnPointerDown;
			view.PointerUp -= OnPointerUp;
			view.PointerMove -= OnPointerMove;
			if (currentTooltip != null)
			{
				tooltipContainer.RemoveTooltip(currentTooltip);
				inventoryItemTooltipPool.Release(currentTooltip);
				currentTooltip = null;
			}
		}

		public void SetItem(IReadOnlyStorageSlot item)
		{
			if (this.item != null)
			{
				this.item.SlotChanged -= OnSlotChanged;
			}
			this.item = item;
			if (this.item != null)
			{
				this.item.SlotChanged += OnSlotChanged;
			}
			UpdateView();
		}

		public void Select()
		{
			view.Selected = true;
		}

		public void Deselect()
		{
			view.Selected = false;
		}

		public void Show()
		{
			view.Show();
		}

		public void Hide()
		{
			view.Hide();
		}

		public void Enable()
		{
			view.Enable();
		}

		public void Disable()
		{
			view.Disable();
		}

		private void UpdateView()
		{
			if (item != null && item.Item is StorageItemElement storageItemElement)
			{
				view.UpdateElement(storageItemElement.Icon, storageItemElement.ElementData.Condition);
			}
		}

		private void OnPointerClick(StorageSlotElementView _)
		{
			this.OnSelectedChanged?.Invoke(this);
		}

		private void OnPointerEnter(StorageSlotElementView _)
		{
			if (item != null && item.Item != null)
			{
				if (currentTooltip == null)
				{
					currentTooltip = inventoryItemTooltipPool.Get<InventoryItemTooltipView>();
				}
				currentTooltip.Title = localizationSystem.GetTranslation(item.Item.NameLocalizationKey);
				currentTooltip.Desc = localizationSystem.GetTranslation(item.Item.DeviceNameLocalizationKey);
				Rect worldRect = (view.transform as RectTransform).GetWorldRect();
				Vector2 vector = new Vector2(worldRect.xMax, worldRect.yMax);
				vector = RectTransformUtility.WorldToScreenPoint(null, vector);
				vector += tooltipOffset;
				RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)tooltipContainer.transform, vector, null, out vector);
				currentTooltip.transform.position = vector;
				tooltipContainer.AddTooltip(currentTooltip);
			}
		}

		private void OnPointerExit(StorageSlotElementView _)
		{
			if (currentTooltip != null)
			{
				tooltipContainer.RemoveTooltip(currentTooltip);
				inventoryItemTooltipPool.Release(currentTooltip);
				currentTooltip = null;
			}
		}

		private void OnPointerDown(StorageSlotElementView _)
		{
			isHolding = true;
		}

		private void OnPointerUp(StorageSlotElementView _)
		{
			isHolding = false;
		}

		private void OnPointerMove(StorageSlotElementView _)
		{
			if (isHolding)
			{
				isHolding = false;
				this.OnDrag?.Invoke(this);
			}
		}

		private void OnSlotChanged(IReadOnlyStorageSlot slot)
		{
			UpdateView();
		}

		void ICleanableComponent.Clean()
		{
			this.OnSelectedChanged = null;
			this.OnDrag = null;
			if (item != null)
			{
				item.SlotChanged -= OnSlotChanged;
			}
			view.PointerExit -= OnPointerExit;
			view.PointerEnter -= OnPointerEnter;
			view.PointerClick -= OnPointerClick;
			view.PointerDown -= OnPointerDown;
			view.PointerUp -= OnPointerUp;
			view.PointerMove -= OnPointerMove;
			if (currentTooltip != null)
			{
				tooltipContainer.RemoveTooltip(currentTooltip);
				inventoryItemTooltipPool.Release(currentTooltip);
				currentTooltip = null;
			}
		}
	}
}
