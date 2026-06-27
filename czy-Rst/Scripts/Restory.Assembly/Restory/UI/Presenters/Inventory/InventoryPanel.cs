using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Elements.Condition;
using Restory.EventSystems.ExitEvents;
using Restory.Gameplay.Common;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.GameView;
using Restory.Gameplay.Inventory;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.StorageSystem;
using Restory.StorageSystem.StorageElements;
using Restory.UI.Presenters.Inventory.StorageSlotElements;
using Restory.UI.Views.Inventory;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Inventory
{
	public sealed class InventoryPanel : MonoBehaviour, IDisposable, IActiveStateSwitchRequester, IExitablePanel
	{
		private enum State
		{
			None = 0,
			Work = 1,
			DeviceDisassemble = 2,
			EmptyDisassemble = 3
		}

		private class ItemsSorting : IComparer<IReadOnlyStorageSlot>
		{
			public bool Invert { get; set; }

			public int Compare(IReadOnlyStorageSlot x, IReadOnlyStorageSlot y)
			{
				if (!(x.Item is StorageItemElement storageItemElement) || !(y.Item is StorageItemElement storageItemElement2))
				{
					return 0;
				}
				int conditionOrder = GetConditionOrder(storageItemElement.ElementData.Condition);
				int conditionOrder2 = GetConditionOrder(storageItemElement2.ElementData.Condition);
				if (!Invert)
				{
					return conditionOrder2.CompareTo(conditionOrder);
				}
				return conditionOrder.CompareTo(conditionOrder2);
			}

			private static int GetConditionOrder(ElementConditionBase condition)
			{
				if (!(condition is PerfectElementCondition))
				{
					if (!(condition is DirtyElementCondition))
					{
						if (condition is DamagedElementCondition)
						{
							return 2;
						}
						return int.MaxValue;
					}
					return 1;
				}
				return 0;
			}
		}

		[SerializeField]
		private InventoryPanelView view;

		[SerializeField]
		private InventoryPanelFilter filter;

		[SerializeField]
		private InventoryPanelItems items;

		private IInventory inventory;

		private StorageElasticElementsDropService dropService;

		private StorageElasticElementsDragService dragService;

		private DeviceService deviceService;

		private DisassembleStateMachine disassembleStateMachine;

		private CameraDirectionSwitcher cameraDirectionSwitcher;

		private DisassembleGameMode disassembleGameMode;

		private readonly List<IReadOnlyStorageSlot> filteredItems = new List<IReadOnlyStorageSlot>();

		private readonly List<IReadOnlyStorageSlot> selectedItems = new List<IReadOnlyStorageSlot>();

		private readonly ItemsSorting itemsSorting = new ItemsSorting();

		private State state;

		private bool isFilterLocked;

		public bool IsVisible => view.Visible;

		public bool IsPointerOverInventory { get; private set; }

		public event Action OnIsVisibleChanged;

		[Inject]
		private void Construct(IInventory inventory, StorageElasticElementsDropService dropService, StorageElasticElementsDragService dragService, DeviceService deviceService, DisassembleStateMachine disassembleStateMachine, CameraDirectionSwitcher cameraDirectionSwitcher, DisassembleGameMode disassembleGameMode)
		{
			this.inventory = inventory;
			this.dropService = dropService;
			this.dragService = dragService;
			this.deviceService = deviceService;
			this.disassembleStateMachine = disassembleStateMachine;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.disassembleGameMode = disassembleGameMode;
		}

		public void Dispose()
		{
			Unsubscribe();
			view.Clear();
			filter.Clear();
			filteredItems.Clear();
			selectedItems.Clear();
		}

		public void Show()
		{
			if (!IsVisible)
			{
				filter.Init();
				Subscribe();
				UpdateItems();
				SortItems();
				UpdateView();
				ResolveDisassembleStateChanged();
				view.Show();
				cameraDirectionSwitcher.AddBlocker(this);
				dragService.IsInventoryOpen = true;
				this.OnIsVisibleChanged?.Invoke();
			}
		}

		public void Hide()
		{
			if (IsVisible)
			{
				view.Hide();
				state = State.None;
				isFilterLocked = false;
				Unsubscribe();
				filteredItems.Clear();
				selectedItems.Clear();
				cameraDirectionSwitcher.RemoveBlocker(this);
				IsPointerOverInventory = false;
				dragService.IsInventoryOpen = false;
				this.OnIsVisibleChanged?.Invoke();
			}
		}

		public void OnExitEvent()
		{
			Hide();
		}

		private void Subscribe()
		{
			filter.Subscribe();
			InventoryPanelFilter inventoryPanelFilter = filter;
			inventoryPanelFilter.DevicePartInfosChanged = (Action<InventoryPanelFilter>)Delegate.Combine(inventoryPanelFilter.DevicePartInfosChanged, new Action<InventoryPanelFilter>(OnFiltersChanged));
			InventoryPanelFilter inventoryPanelFilter2 = filter;
			inventoryPanelFilter2.SortChanged = (Action<InventoryPanelFilter>)Delegate.Combine(inventoryPanelFilter2.SortChanged, new Action<InventoryPanelFilter>(OnSortChanged));
			items.ItemSelected += OnItemSelected;
			items.ItemDrag += OnItemDrag;
			view.CloseClick += OnCloseClick;
			view.DropClick += OnDropClick;
			view.PointerEnter += OnPointerEnter;
			view.PointerExit += OnPointerExit;
			inventory.StorageElements.StorageChanged += OnStorageChanged;
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
		}

		private void Unsubscribe()
		{
			inventory.StorageElements.StorageChanged -= OnStorageChanged;
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			view.DropClick -= OnDropClick;
			view.CloseClick -= OnCloseClick;
			view.PointerEnter -= OnPointerEnter;
			view.PointerExit -= OnPointerExit;
			items.ItemSelected -= OnItemSelected;
			items.ItemDrag -= OnItemDrag;
			InventoryPanelFilter inventoryPanelFilter = filter;
			inventoryPanelFilter.SortChanged = (Action<InventoryPanelFilter>)Delegate.Remove(inventoryPanelFilter.SortChanged, new Action<InventoryPanelFilter>(OnSortChanged));
			InventoryPanelFilter inventoryPanelFilter2 = filter;
			inventoryPanelFilter2.DevicePartInfosChanged = (Action<InventoryPanelFilter>)Delegate.Remove(inventoryPanelFilter2.DevicePartInfosChanged, new Action<InventoryPanelFilter>(OnFiltersChanged));
			filter.Unsubscribe();
		}

		private void UpdateItems()
		{
			filteredItems.Clear();
			foreach (IReadOnlyStorageSlot storageElement in inventory.StorageElements)
			{
				if (storageElement.Item is StorageItemElement storageItemElement && filter.DevicePartInfos.Contains(storageItemElement.ElementData.Info))
				{
					filteredItems.Add(storageElement);
				}
			}
		}

		private void SortItems()
		{
			itemsSorting.Invert = filter.Sort;
			filteredItems.Sort(itemsSorting);
		}

		private void DropSelectedItems()
		{
			if (dropService.IsProcess)
			{
				return;
			}
			List<IReadOnlyStorageSlot> list = (from i in items.UIItems
				where i.Selected
				select i.Item).ToList();
			if (list.Count == 0)
			{
				return;
			}
			if (state != State.EmptyDisassemble)
			{
				dropService.DropItems(inventory.StorageElements, list);
				return;
			}
			using List<IReadOnlyStorageSlot>.Enumerator enumerator = list.GetEnumerator();
			if (enumerator.MoveNext())
			{
				IReadOnlyStorageSlot current = enumerator.Current;
				if (disassembleGameMode.TryCreateEmptyDevice(current.Item.DeviceNameLocalizationKey))
				{
					dropService.DropItems(inventory.StorageElements, list);
					disassembleStateMachine.Enter<DetectionDisassembleState>();
				}
			}
		}

		private void UpdateView()
		{
			UpdateFiltersView();
			UpdateItemsView();
			UpdateSelectedCount();
			UpdateDropButton();
		}

		private void UpdateFiltersView()
		{
			filter.Visible = inventory.StorageElements.Size > 0;
		}

		private void UpdateItemsView()
		{
			items.SetItems(filteredItems);
		}

		private void UpdateSelectedCount()
		{
			int selectedCount = items.UIItems.Count((StorageSlotElement i) => i.Selected);
			view.SelectedCount = selectedCount;
		}

		private void UpdateDropButton()
		{
			view.DropButtonVisibility = view.SelectedCount > 0 && state != State.Work;
		}

		private void OnFiltersChanged(InventoryPanelFilter p)
		{
			UpdateItems();
			SortItems();
			UpdateItemsView();
			UpdateSelectedCount();
			UpdateDropButton();
		}

		private void OnSortChanged(InventoryPanelFilter p)
		{
			SortItems();
			UpdateItemsView();
			UpdateSelectedCount();
			UpdateDropButton();
		}

		private void OnCloseClick(InventoryPanelView v)
		{
			Hide();
		}

		private void OnDropClick(InventoryPanelView v)
		{
			DropSelectedItems();
		}

		private void OnPointerEnter(InventoryPanelView v)
		{
			IsPointerOverInventory = true;
			dragService.IsPointerOverInventory = true;
		}

		private void OnPointerExit(InventoryPanelView v)
		{
			IsPointerOverInventory = false;
			dragService.IsPointerOverInventory = false;
		}

		private void OnItemSelected(InventoryPanelItems p, StorageSlotElement pi)
		{
			if (pi.Selected)
			{
				pi.Deselect();
				selectedItems.Remove(pi.Item);
			}
			else
			{
				pi.Select();
				selectedItems.Add(pi.Item);
			}
			UpdateSelectedCount();
			UpdateDropButton();
			if (state == State.EmptyDisassemble)
			{
				if (pi.Selected)
				{
					items.DisableNotCompatibleItems(pi.Item.Item.DeviceNameLocalizationKey);
				}
				else if (view.SelectedCount == 0)
				{
					items.EnableAllItems();
				}
			}
		}

		private void OnItemDrag(InventoryPanelItems p, StorageSlotElement pi)
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is DetectionDisassembleState || activeState is EmptyDisassembleState)
			{
				dragService.StartDragFromInventory(pi);
			}
		}

		private void OnStorageChanged(IStorage storage)
		{
			filter.UpdateStorageInfo();
			UpdateFiltersView();
			UpdateItems();
			UpdateItemsView();
			UpdateSelectedCount();
			UpdateDropButton();
		}

		private void ResolveDisassembleStateChanged()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is DisabledDisassembleState))
			{
				if (!(activeState is EmptyDisassembleState))
				{
					if (!(activeState is TransitionToCleaningDisassembleState))
					{
						SetDeviceDisassembleState();
					}
				}
				else
				{
					SetEmptyDisassembleState();
				}
			}
			else
			{
				SetWorkState();
			}
		}

		private void ReselectFilteredItems()
		{
			List<StorageSlotElement> list = items.UIItems.Where((StorageSlotElement i) => selectedItems.Contains(i.Item)).ToList();
			selectedItems.Clear();
			foreach (StorageSlotElement item in list)
			{
				item.Select();
			}
			UpdateSelectedCount();
			UpdateDropButton();
		}

		private void SetWorkState()
		{
			if (state != State.Work)
			{
				state = State.Work;
				filter.Release();
				isFilterLocked = false;
				selectedItems.Clear();
				UpdateDropButton();
			}
		}

		private void SetEmptyDisassembleState()
		{
			if (state != State.EmptyDisassemble)
			{
				state = State.EmptyDisassemble;
				filter.Release();
				isFilterLocked = false;
				selectedItems.Clear();
				UpdateDropButton();
			}
		}

		private void SetDeviceDisassembleState()
		{
			LockFilter();
			if (state != State.DeviceDisassemble)
			{
				state = State.DeviceDisassemble;
				if (selectedItems.Count > 0)
				{
					ReselectFilteredItems();
				}
			}
		}

		private void LockFilter()
		{
			if (!isFilterLocked && (bool)deviceService.PlacedDeviceContainer)
			{
				filter.Lock(deviceService.PlacedDeviceContainer.Device.Info);
				isFilterLocked = true;
			}
		}
	}
}
