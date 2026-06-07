using System;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.DragDrop
{
	public class InventoryDragDropController : MonoBehaviour
	{
		private enum DragState
		{
			Idle = 0,
			PendingDrag = 1,
			Dragging = 2
		}

		private static InventoryDragDropController _instance;

		private const float DRAG_THRESHOLD_PX = 5f;

		private const int GHOST_SIZE = 48;

		private DragState _state;

		private Vector2 _pointerDownPosition;

		private int _sourceSlotIndex;

		private string _sourceInventoryId;

		private VisualElement _sourceSlotElement;

		private VisualElement _ghostElement;

		private InventorySlot _draggedSlotSnapshot;

		private VisualElement _currentHoverTarget;

		private VisualElement _rootElement;

		private int _dragPointerId;

		private readonly Dictionary<VisualElement, DragSlotRegistration> _registeredSlots;

		private readonly Dictionary<IPanel, HashSet<VisualElement>> _panelSlots;

		[SerializeField]
		private UIDocument dragOverlayDocument;

		private VisualElement _dragOverlayRoot;

		private IPanel _sourcePanel;

		private const string CLASS_DRAG_GHOST = "drag-ghost";

		private const string CLASS_DRAG_GHOST_COUNT = "drag-ghost-count";

		private const string CLASS_DRAG_SOURCE = "drag-source";

		private const string CLASS_DRAG_OVER_VALID = "drag-over-valid";

		private const string CLASS_DRAG_OVER_SWAP = "drag-over-swap";

		private const string CLASS_DRAG_OVER_CROSS = "drag-over-cross";

		private const string CLASS_DRAG_OVER_BLOCKED = "drag-over-blocked";

		[SerializeField]
		private StyleSheet dragDropStyleSheet;

		private InventoryManager _subscribedInventoryManager;

		private bool _wasItemEquipped;

		private bool _suppressCancelEvents;

		public static InventoryDragDropController Instance => null;

		public bool IsDragging => false;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private VisualElement GetOverlayRoot()
		{
			return null;
		}

		public void RegisterSlot(DragSlotRegistration registration)
		{
		}

		public void UnregisterSlot(VisualElement slotElement)
		{
		}

		public void UnregisterAllSlots(string inventoryId)
		{
		}

		private void RemoveFromPanelTracking(VisualElement element)
		{
		}

		private void RebuildPanelSlots()
		{
		}

		public void OnPointerDownOnSlot(int slotIndex, string inventoryId, Vector2 panelPosition, VisualElement slotElement, InventorySlot slotData, VisualElement rootElement, InventoryManager inventoryManager, int pointerId)
		{
		}

		private void OnPointerMoveDuringDrag(PointerMoveEvent evt)
		{
		}

		private void OnPointerUpDuringDrag(PointerUpEvent evt)
		{
		}

		private void OnKeyDownDuringDrag(KeyDownEvent evt)
		{
		}

		private void BeginDrag(Vector2 currentPos)
		{
		}

		private void ExecuteDrop(DragSlotRegistration targetReg)
		{
		}

		private void CleanupAfterDrop()
		{
		}

		public void CancelDrag()
		{
		}

		private void RestoreItemEquipped()
		{
		}

		private void ResetState()
		{
		}

		private static Vector2 GetScreenPositionTopLeft()
		{
			return default(Vector2);
		}

		private void UpdateGhostPosition(Vector2 sourcePanelPosition)
		{
		}

		private void UpdateHoverTarget(Vector2 sourcePanelPosition)
		{
		}

		private void ClearHoverHighlight()
		{
		}

		private DragSlotRegistration FindRegistrationAtPosition(Vector2 sourcePanelPosition)
		{
			return null;
		}

		private DragSlotRegistration FindRegistrationForSlot(VisualElement slotElement)
		{
			return null;
		}

		public static DragDropAction DetermineDropAction(InventorySlot sourceSlot, InventorySlot targetSlot, string sourceInventoryId, string targetInventoryId, Func<Item, bool> targetCanAcceptItem = null)
		{
			return default(DragDropAction);
		}

		private void UnregisterDragEventHandlers()
		{
		}

		private void SubscribeToCancelTriggers(InventoryManager inventoryManager)
		{
		}

		private void UnsubscribeFromCancelTriggers()
		{
		}

		private void OnExternalUIClosed()
		{
		}

		private void OnInventorySizeChanged(int newSize)
		{
		}
	}
}
