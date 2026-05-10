using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

using SPACE_UTIL;

namespace SPACE_WindowSystem
{
	public class SetForegroundLayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] bool moveToTopWhenDrag = true;

		[Header("Mouse Button Settings")]
		[SerializeField] private bool useLeftMouseButton = true;
		[SerializeField] private bool useRightMouseButton = true;
		[SerializeField] private bool useMiddleMouseButton = true;

		/*
		[Header("Resize Handle")]
		[SerializeField] ResizeHandle resizeHandle;
		*/

		[Header("Layer Entire")]
		[SerializeField] Transform layerEntire;

		/*
		[Tooltip("should either be self/anscetor RectTransform")]
		[Header("Target Window(self/ancestor)")]
		[SerializeField] RectTransform targetWindow;
		*/

			/*
		[Header("Drag Settings")]
		[Space]
		[Space]
		[Space]
		[SerializeField] private RectTransform dragRegion; // Optional: specific drag area (e.g., title bar)
		[SerializeField] private RectTransform boundsRect; // Optional: bounds to clamp window position
		*/
		[SerializeField] private bool logDragEvents = false;

		/*
		[Header("Minimize/Maximize")]
		[SerializeField] private List<Button> minMaxButtons;
		[SerializeField] private List<GameObject> minMaxInvolveObjects;
		[SerializeField] private bool modifyMinMaxText = true;
		[SerializeField] private bool startMaximized = true;
		*/

		// Private non-inspector fields
		private Transform originalParent;
		private Vector2 dragOffset;
		private bool isDragging = false;
		private bool isMouseOver = false;
		private int dragButton = -1; // 0=Left, 1=Right, 2=Middle

		private void Awake()
		{
			/*
			if (this.targetWindow == null)
				Debug.LogError("targetWindow must be either self/parent RectTransform");

			if (dragRegion == null)
				dragRegion = targetWindow; // Use entire window if no specific drag region
			*/

			if (this.layerEntire == null)
				Debug.LogError($"layer missing for DragableWindow: {this.gameObject.name}");


			// HandleMinimizeMaximize();
		}

		private void Update()
		{
			if (isDragging)
			{
				// Continue dragging while button is held
				bool buttonStillDown = CheckButtonDown(dragButton);

				if (buttonStillDown)
				{
					// OnDrag();
				}
				else
				{
					// OnEndDrag();
				}
			}
			else if (isMouseOver)
			{
				// Check for drag start with enabled mouse buttons
				if (useMiddleMouseButton && Input.GetMouseButtonDown(2))
					OnBeginDrag(2);
				else if (useRightMouseButton && Input.GetMouseButtonDown(1))
					OnBeginDrag(1);
				else if (useLeftMouseButton && Input.GetMouseButtonDown(0))
					OnBeginDrag(0);
			}
		}

		#region EventSystem Interface Implementation

		public void OnPointerDown(PointerEventData eventData)
		{
			// Handle pointer down for left mouse button through EventSystem
			if (useLeftMouseButton && eventData.button == PointerEventData.InputButton.Left)
			{
				OnBeginDrag(0);
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			// Handle pointer up through EventSystem
			if (isDragging && IsCorrectButton(eventData.button))
			{
				OnEndDrag();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isMouseOver = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isMouseOver = false;
		}

		#endregion

		#region Drag Implementation

		private void OnBeginDrag(int buttonIndex)
		{
			if (isDragging) return;

			if (logDragEvents)
				Debug.Log($"Window drag started with button {buttonIndex} (0=Left, 1=Right, 2=Middle)");

			isDragging = true;
			dragButton = buttonIndex;

			if (moveToTopWhenDrag == true)
			{
				this.layerEntireAsTopLayerAtDragStart(); // Bring to front
			}

			/*
			// Calculate drag offset in canvas-scaled coordinates
			Vector2 canvasMousePos = INPUT.UI.pos;
			dragOffset = targetWindow.anchoredPosition - canvasMousePos;

			#region resize handle
			resizeHandle?.KeepHandleAtBottomRightCorner();
			#endregion
			*/
		}

		private void OnDrag()
		{
			if (!isDragging) return;

			if (logDragEvents)
				Debug.Log("Window dragging...");

			/*
			// Calculate target position in canvas coordinates
			Vector2 targetPos = INPUT.UI.pos + dragOffset;

			// Clamp within bounds if specified
			if (boundsRect != null)
			{
				targetPos = ClampWindowPosition(targetPos);
			}

			// Set the new position
			targetWindow.anchoredPosition = targetPos;

			#region resize handle
			resizeHandle?.KeepHandleAtBottomRightCorner();
			#endregion
			*/
		}

		private void OnEndDrag()
		{
			if (!isDragging) return;

			if (logDragEvents)
				Debug.Log("Window drag ended");

			#region old approach
			// Return to original parent
			/*
			if (moveToTopWhenDrag == true)
			{
				// windowRect.SetParent(originalParent); // Before
				this.layerEntire.SetParent(this.originalParent);
			}
			*/
			#endregion

			isDragging = false;
			dragButton = -1;

			/*
			#region resize handle
			resizeHandle?.KeepHandleAtBottomRightCorner();
			#endregion
			*/
		}

		#endregion

		#region Helper Methods
		private bool CheckButtonDown(int buttonIndex)
		{
			switch (buttonIndex)
			{
				case 0: return Input.GetMouseButton(0);
				case 1: return Input.GetMouseButton(1);
				case 2: return Input.GetMouseButton(2);
				default: return false;
			}
		}

		private bool IsCorrectButton(PointerEventData.InputButton button)
		{
			switch (button)
			{
				case PointerEventData.InputButton.Left: return dragButton == 0;
				case PointerEventData.InputButton.Right: return dragButton == 1;
				case PointerEventData.InputButton.Middle: return dragButton == 2;
				default: return false;
			}
		}

		/*
		private Vector2 ClampWindowPosition(Vector2 targetPos)
		{
			Rect boundsArea = INPUT.UI.getBounds(boundsRect);
			Rect windowArea = INPUT.UI.getBounds(targetWindow);

			const int border = 2;

			// Clamp for top-left anchor/pivot (0,1)
			// Window position represents the top-left corner
			float clampedX = C.clamp(targetPos.x,
				boundsArea.min.x + border,
				boundsArea.max.x - border - windowArea.width);

			float clampedY = C.clamp(targetPos.y,
				boundsArea.min.y + border + windowArea.height,
				boundsArea.max.y - border);

			return new Vector2(clampedX, clampedY);
		}
		*/
		#endregion

		#region Minimize/Maximize Functionality
		/*
		private void HandleMinimizeMaximize()
		{
			if (minMaxButtons == null || minMaxButtons.Count == 0 || minMaxInvolveObjects.Count == 0)
				return;

			// Setup button listeners
			foreach (Button btn in minMaxButtons)
			{
				btn.onClick.AddListener(() =>
				{
					startMaximized = !minMaxInvolveObjects[0].activeInHierarchy;
					ToggleMaximize();
				});
			}

			// Set initial state
			ToggleMaximize();
		}

		private void ToggleMaximize()
		{
			foreach (GameObject obj in minMaxInvolveObjects)
			{
				obj.SetActive(startMaximized);
			}

			if (modifyMinMaxText)
			{
				foreach (Button btn in minMaxButtons)
				{
					var textComponent = btn.gameObject.NameStartsWith("text")?.GC<TMPro.TextMeshProUGUI>();
					if (textComponent != null)
						textComponent.text = startMaximized ? "-" : "v";
				}
			}
		}
		*/
		#endregion

		#region called internal
		void layerEntireAsTopLayerAtDragStart()
		{
			this.layerEntire.SetAsLastSibling();
		}
		#endregion

		#region Public Interface(optional)

		public bool IsDragging => isDragging;
		public int CurrentDragButton => dragButton;

		public void SetMouseButtonSettings(bool left, bool right, bool middle)
		{
			useLeftMouseButton = left;
			useRightMouseButton = right;
			useMiddleMouseButton = middle;
		}

		public void SetBounds(RectTransform bounds)
		{
			// boundsRect = bounds;
		}

		#endregion
	}
}