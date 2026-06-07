using System.Collections.Generic;
using DV.UIFramework;
using DV.Util;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DV.UI.Inventory
{
	public class InventoryUIInteractionObserver : MonoBehaviour
	{
		public delegate void InventorySlotDelegate(int slotIndex, InventorySectionController controller);

		public delegate void InventorySlotDragDelegate(int slotIndex, InventorySectionController controller, PointerEventData eventData, bool forced);

		public delegate void InventorySlotHoverChangedDelegate(int newIndex, int oldIndex, InventorySectionController controller);

		public delegate void InventorySlotSelectionChangedDelegate(int slotIndex, bool selected, InventorySectionController controller);

		public delegate void InventorySlotPressedChangedDelegate(int slotIndex, bool pressed, InventorySectionController controller);

		public class SlotObserver
		{
			public delegate void WrapperInteractionDelegate(InventoryGridElement element);

			public delegate void WrapperInteractionDragDelegate(InventoryGridElement element, PointerEventData pointerEventData, bool forced);

			public delegate void WrapperInteractionPressChangedDelegate(InventoryGridElement element, bool pressed);

			public delegate void WrapperInteractionHoverChangedDelegate(InventoryGridElement element, bool hovered);

			public InventoryGridElement element;

			public event WrapperInteractionDelegate LockClicked;

			public event WrapperInteractionDelegate GetClicked;

			public event WrapperInteractionDelegate BeltResetClicked;

			public event WrapperInteractionDelegate BeltToggleClicked;

			public event WrapperInteractionDelegate ItemContainerAccessClicked;

			public event WrapperInteractionDelegate SlotClicked;

			public event WrapperInteractionPressChangedDelegate SlotPressChanged;

			public event WrapperInteractionHoverChangedDelegate ItemContainerHoverChanged;

			public event WrapperInteractionDragDelegate DragStart;

			public event WrapperInteractionDragDelegate DragOngoing;

			public event WrapperInteractionDragDelegate DragEnd;

			public event WrapperInteractionDelegate Selected;

			public event WrapperInteractionDelegate Deselected;

			public SlotObserver(InventoryGridElement element)
			{
				this.element = element;
				IClickable clickable = ((element.lockButton != null) ? element.lockButton.GetComponent<IClickable>() : null);
				IClickable clickable2 = ((element.getButton != null) ? element.getButton.GetComponent<IClickable>() : null);
				IClickable clickable3 = ((element.beltResetButton != null) ? element.beltResetButton.GetComponent<IClickable>() : null);
				IClickable clickable4 = ((element.beltToggleButton != null) ? element.beltToggleButton.GetComponent<IClickable>() : null);
				IClickable clickable5 = ((element.itemContainerButton != null) ? element.itemContainerButton.GetComponent<IClickable>() : null);
				Button component = element.GetComponent<Button>();
				IClickable clickable6 = ((component != null) ? component.GetComponent<IClickable>() : null);
				IMarkable markable = ((component != null) ? component.GetComponent<IMarkable>() : null);
				UIDragElement component2 = element.GetComponent<UIDragElement>();
				if (clickable != null)
				{
					clickable.Clicked += OnLockClicked;
				}
				else
				{
					Debug.LogError($"Missing lock button for element {element}.", element);
				}
				if (clickable2 != null)
				{
					clickable2.Clicked += OnGetClicked;
				}
				else
				{
					Debug.LogError($"Missing get button for element {element}.", element);
				}
				if (clickable3 != null)
				{
					clickable3.Clicked += OnBeltResetClicked;
				}
				else
				{
					Debug.LogError($"Missing belt reset button for element {element}.", element);
				}
				if (clickable4 != null)
				{
					clickable4.Clicked += OnBeltToggleClicked;
				}
				else
				{
					Debug.LogError($"Missing belt toggle button for element {element}.", element);
				}
				if (clickable5 != null)
				{
					clickable5.Clicked += OnItemContainerAccessClicked;
					clickable5.HoverChanged += OnItemContainerAccessHoverChanged;
				}
				else
				{
					Debug.LogError($"Missing item container access button for element {element}.", element);
				}
				if (clickable6 != null)
				{
					clickable6.Clicked += OnSlotClicked;
					clickable6.PressChanged += OnSlotPressChanged;
				}
				else
				{
					Debug.LogError($"Missing slot button for element {element}.", element);
				}
				if (markable != null)
				{
					markable.MarkChanged += OnSlotSelected;
				}
				else
				{
					Debug.LogError($"Missing markable button for element {element}.", element);
				}
				if (component2 != null)
				{
					component2.DragStarted += OnDragStarted;
					component2.DragOngoing += OnDragOngoing;
					component2.DragEnded += OnDragEnded;
				}
				else
				{
					Debug.LogError($"Missing drag element for element {element}.", element);
				}
			}

			private void OnItemContainerAccessHoverChanged(IHoverable hoverable)
			{
				this.ItemContainerHoverChanged?.Invoke(element, hoverable.IsHovered);
			}

			private void OnSlotSelected(IMarkable markable)
			{
				if (markable.IsMarked)
				{
					this.Selected?.Invoke(element);
				}
				else
				{
					this.Deselected?.Invoke(element);
				}
			}

			private void OnDragStarted(PointerEventData eventData)
			{
				this.DragStart?.Invoke(element, eventData, forced: false);
			}

			private void OnDragOngoing(PointerEventData eventData)
			{
				this.DragOngoing?.Invoke(element, eventData, forced: false);
			}

			private void OnDragEnded(PointerEventData eventData, bool forced)
			{
				this.DragEnd?.Invoke(element, eventData, forced);
			}

			private void OnLockClicked(IClickable clickable)
			{
				this.LockClicked?.Invoke(element);
			}

			private void OnGetClicked(IClickable clickable)
			{
				this.GetClicked?.Invoke(element);
			}

			private void OnSlotClicked(IClickable clickable)
			{
				this.SlotClicked?.Invoke(element);
			}

			private void OnSlotPressChanged(IClickable clickable)
			{
				this.SlotPressChanged?.Invoke(element, clickable.IsPressed);
			}

			private void OnBeltResetClicked(IClickable clickable)
			{
				this.BeltResetClicked?.Invoke(element);
			}

			private void OnBeltToggleClicked(IClickable clickable)
			{
				this.BeltToggleClicked?.Invoke(element);
			}

			private void OnItemContainerAccessClicked(IClickable clickable)
			{
				this.ItemContainerAccessClicked?.Invoke(element);
			}
		}

		private InventorySectionController controller;

		private int currentHover;

		private ObservableCollectionExt<InventorySlotDisplayData> model;

		private InventoryGridView grid;

		private UIDragElement draggedElement;

		public List<SlotObserver> slotObservers = new List<SlotObserver>();

		public event InventorySlotDelegate SlotClicked;

		public event InventorySlotHoverChangedDelegate HoverChanged;

		public event InventorySlotHoverChangedDelegate ItemContainerAccessHoverChanged;

		public event InventorySlotDelegate LockClicked;

		public event InventorySlotDelegate GetClicked;

		public event InventorySlotDelegate BeltResetClicked;

		public event InventorySlotDelegate BeltToggleClicked;

		public event InventorySlotDelegate ItemContainerAccessClicked;

		public event InventorySlotDragDelegate DragStart;

		public event InventorySlotDragDelegate DragOngoing;

		public event InventorySlotDragDelegate DragEnd;

		public event InventorySlotSelectionChangedDelegate SelectionChanged;

		public event InventorySlotPressedChangedDelegate SlotPressChanged;

		public void Initialize(InventorySectionController controller, InventoryGridView grid, ObservableCollectionExt<InventorySlotDisplayData> model, bool reintialize = false)
		{
			if (controller == null)
			{
				Debug.LogError("InventoryUIInteractionObserver: controller is null. Initialization failed.", this);
				return;
			}
			if (reintialize)
			{
				foreach (SlotObserver slotObserver2 in slotObservers)
				{
					slotObserver2.LockClicked -= OnObserverLockClicked;
					slotObserver2.GetClicked -= OnObserverGetClicked;
					slotObserver2.BeltResetClicked -= OnObserverBeltResetClicked;
					slotObserver2.BeltToggleClicked -= OnObserverBeltToggleClicked;
					slotObserver2.ItemContainerAccessClicked -= OnObserverItemContainerAccessClicked;
					slotObserver2.ItemContainerHoverChanged -= OnObserverItemContainerHoverChanged;
					slotObserver2.SlotClicked -= OnObserverSlotClicked;
					slotObserver2.SlotPressChanged -= OnObserverSlotPressChanged;
					slotObserver2.DragStart -= OnObserverDragStart;
					slotObserver2.DragOngoing -= OnObserverDragOngoing;
					slotObserver2.DragEnd -= OnObserverDragEnd;
					slotObserver2.Selected -= OnObserverSelected;
					slotObserver2.Deselected -= OnObserverDeselected;
				}
				slotObservers.Clear();
			}
			this.controller = controller;
			this.grid = grid;
			this.model = model;
			currentHover = -1;
			InventoryGridElement[] componentsInChildren = GetComponentsInChildren<InventoryGridElement>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				SlotObserver slotObserver = new SlotObserver(componentsInChildren[i]);
				slotObservers.Add(slotObserver);
				slotObserver.LockClicked += OnObserverLockClicked;
				slotObserver.GetClicked += OnObserverGetClicked;
				slotObserver.BeltResetClicked += OnObserverBeltResetClicked;
				slotObserver.BeltToggleClicked += OnObserverBeltToggleClicked;
				slotObserver.ItemContainerAccessClicked += OnObserverItemContainerAccessClicked;
				slotObserver.ItemContainerHoverChanged += OnObserverItemContainerHoverChanged;
				slotObserver.SlotClicked += OnObserverSlotClicked;
				slotObserver.SlotPressChanged += OnObserverSlotPressChanged;
				slotObserver.DragStart += OnObserverDragStart;
				slotObserver.DragOngoing += OnObserverDragOngoing;
				slotObserver.DragEnd += OnObserverDragEnd;
				slotObserver.Selected += OnObserverSelected;
				slotObserver.Deselected += OnObserverDeselected;
			}
			grid.HoveredIndexChanged += OnGridHoverIndexChanged;
			controller.controller.AboutToClose += OnControllerAboutToClose;
		}

		private void OnObserverItemContainerHoverChanged(InventoryGridElement element, bool hovered)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else if (hovered)
			{
				this.ItemContainerAccessHoverChanged?.Invoke(num, -1, controller);
			}
			else
			{
				this.ItemContainerAccessHoverChanged?.Invoke(-1, num, controller);
			}
		}

		private void OnControllerAboutToClose()
		{
			if (draggedElement != null)
			{
				draggedElement.ForceEndInteraction();
			}
		}

		private void OnDestroy()
		{
			foreach (SlotObserver slotObserver in slotObservers)
			{
				slotObserver.LockClicked -= OnObserverLockClicked;
				slotObserver.GetClicked -= OnObserverGetClicked;
				slotObserver.BeltResetClicked -= OnObserverBeltResetClicked;
				slotObserver.BeltToggleClicked -= OnObserverBeltToggleClicked;
				slotObserver.SlotClicked -= OnObserverSlotClicked;
				slotObserver.SlotPressChanged -= OnObserverSlotPressChanged;
				slotObserver.DragStart -= OnObserverDragStart;
				slotObserver.DragOngoing -= OnObserverDragOngoing;
				slotObserver.DragEnd -= OnObserverDragEnd;
				slotObserver.Selected -= OnObserverSelected;
				slotObserver.Deselected -= OnObserverDeselected;
			}
			if (grid != null)
			{
				grid.HoveredIndexChanged -= OnGridHoverIndexChanged;
			}
			if (controller != null && controller.controller != null)
			{
				controller.controller.AboutToClose -= OnControllerAboutToClose;
			}
		}

		private void OnObserverDeselected(InventoryGridElement element)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.SelectionChanged?.Invoke(num, selected: false, controller);
			}
		}

		private void OnObserverSelected(InventoryGridElement element)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.SelectionChanged?.Invoke(num, selected: true, controller);
			}
		}

		private void OnObserverDragStart(InventoryGridElement element, PointerEventData pointerEventData, bool forced)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
				return;
			}
			draggedElement = element.GetComponent<UIDragElement>();
			this.DragStart?.Invoke(num, controller, pointerEventData, forced);
		}

		private void OnObserverDragOngoing(InventoryGridElement element, PointerEventData pointerEventData, bool forced)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.DragOngoing?.Invoke(num, controller, pointerEventData, forced);
			}
		}

		private void OnObserverDragEnd(InventoryGridElement element, PointerEventData pointerEventData, bool forced)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
				return;
			}
			draggedElement = null;
			this.DragEnd?.Invoke(num, controller, pointerEventData, forced);
		}

		private void OnGridHoverIndexChanged(AGridView<InventorySlotDisplayData> _)
		{
			int num = currentHover;
			int hoveredModelIndex = grid.HoveredModelIndex;
			if (hoveredModelIndex != num)
			{
				currentHover = hoveredModelIndex;
				this.HoverChanged?.Invoke(hoveredModelIndex, num, controller);
			}
		}

		private void OnObserverLockClicked(InventoryGridElement element)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.LockClicked?.Invoke(num, controller);
			}
		}

		private void OnObserverGetClicked(InventoryGridElement element)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.GetClicked?.Invoke(num, controller);
			}
		}

		private void OnObserverBeltToggleClicked(InventoryGridElement element)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.BeltToggleClicked?.Invoke(num, controller);
			}
		}

		private void OnObserverBeltResetClicked(InventoryGridElement element)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.BeltResetClicked?.Invoke(num, controller);
			}
		}

		private void OnObserverItemContainerAccessClicked(InventoryGridElement element)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.ItemContainerAccessClicked?.Invoke(num, controller);
			}
		}

		private void OnObserverSlotClicked(InventoryGridElement element)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.SlotClicked?.Invoke(num, controller);
			}
		}

		private void OnObserverSlotPressChanged(InventoryGridElement element, bool pressed)
		{
			int num = model.IndexOf(element.Data);
			if (num == -1)
			{
				Debug.LogError("Data doesn't belong to any element. This should not happen.", this);
			}
			else
			{
				this.SlotPressChanged?.Invoke(num, pressed, controller);
			}
		}
	}
}
