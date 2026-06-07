using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SPACE_UTIL;

namespace SPACE_WindowSystem
{
	/// <summary>
	/// Handles window resizing functionality. Attach this to a small handle (usually bottom-right corner).
	/// This script should be on a child of the window that needs resizing.
	/// </summary>
	public class ResizeHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		[TextArea(minLines: 5, maxLines: 20)]
		string README = @"[logic]
- set the resize handle pos to bottom-right corner 
- of targetWindow once draging is done,
- always use anchoredPostion field which is indiependent of screen resolution,
- note: set later anchor/pivot to bottom left corner and build from there";


		[Header("Mouse Button Settings")]
		[SerializeField] private bool useLeftMouseButton = true;
		[SerializeField] private bool useRightMouseButton = false;
		[SerializeField] private bool useMiddleMouseButton = false;

		[Header("Resize Settings")]
		[SerializeField] private RectTransform targetWindow; // The window to resize (usually parent)
		[SerializeField] private v2 minSize = new v2(200, 150); // Minimum size in canvas coordinates
		[SerializeField] private v2 maxSize = new v2(1000, 800); // Maximum size in canvas coordinates
		[SerializeField] private bool logResizeEvents = false;

		[Header("Handle Positioning")]
		[SerializeField] private bool autoPositionHandleAtEndDrag = true; // Auto-position handle at bottom-right

		// Private fields
		private RectTransform handleRect;
		private bool isResizing = false;
		private bool isMouseOver = false;
		private int resizeButton = -1; // 0=Left, 1=Right, 2=Middle

		Transform _parent;
		private void Awake()
		{
			handleRect = GetComponent<RectTransform>();

			// If no target window specified, use parent
			if (targetWindow == null)
				targetWindow = transform.parent.GetComponent<RectTransform>();

			if (targetWindow == null)
			{
				Debug.LogError($"ResizeHandle on {gameObject.name}: No target window found!", this);
				enabled = false;
				return;
			}
		}

		private void Start()
		{
			this.KeepHandleAtBottomRightCorner();
		}

		private void Update()
		{
			if (isResizing)
			{
				// Continue resizing while button is held
				bool buttonStillDown = CheckButtonDown(resizeButton);

				if (buttonStillDown)
				{
					OnResize();
				}
				else
				{
					OnEndResize();
				}
			}
			else if (isMouseOver)
			{
				// Check for resize start with enabled mouse buttons
				if (useMiddleMouseButton && Input.GetMouseButtonDown(2))
					OnBeginResize(2);
				else if (useRightMouseButton && Input.GetMouseButtonDown(1))
					OnBeginResize(1);
				else if (useLeftMouseButton && Input.GetMouseButtonDown(0))
					OnBeginResize(0);
			}

			// Auto-reposition handle if enabled (useful if window size changes from other sources)
			/*
			if (autoPositionHandle && !isResizing)
				PositionHandleAtBottomRight();
			*/
		}

		#region EventSystem Interface Implementation

		public void OnPointerDown(PointerEventData eventData)
		{
			// Handle pointer down for left mouse button through EventSystem
			if (useLeftMouseButton && eventData.button == PointerEventData.InputButton.Left)
			{
				OnBeginResize(0);
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			// Handle pointer up through EventSystem
			if (isResizing && IsCorrectButton(eventData.button))
			{
				OnEndResize();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isMouseOver = true;
			// Optional: Change cursor to resize cursor
			// Cursor.SetCursor(resizeCursorTexture, Vector2.zero, CursorMode.Auto);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isMouseOver = false;
			// Optional: Reset cursor
			// Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}

		#endregion

		#region Resize Implementation

		Vector2 deltaBegin;

		private void OnBeginResize(int buttonIndex)
		{
			if (isResizing) return;

			if (logResizeEvents)
				Debug.Log($"Resize started with button {buttonIndex} (0=Left, 1=Right, 2=Middle)");

			isResizing = true;
			resizeButton = buttonIndex;

			deltaBegin = handleRect.anchoredPosition - INPUT.UI.pos;

			// WhenLetGoOfHandle();
			// We don't need to store mouse position or window size
			// We'll calculate size based on handle distance from window pivot each frame

		}

		private void OnResize()
		{
			if (!isResizing) return;

			if (logResizeEvents)
				Debug.Log("Resizing...");

			// Get current mouse position in canvas coordinates
			Vector2 currentMousePos = INPUT.UI.pos + this.deltaBegin;

			// Get window's pivot position in canvas coordinates (top-left corner)
			Vector3 windowPivotWorldPos = targetWindow.transform.position;
			Vector2 windowPivotCanvasPos = INPUT.UI.convert(windowPivotWorldPos);

			// Calculate distance from window pivot to mouse position
			Vector2 distanceFromPivot = currentMousePos - windowPivotCanvasPos;

			// Since window pivot is top-left (0,1), the size should be:
			// Width = distance right from pivot (positive X)
			// Height = distance down from pivot (positive Y, but mouse Y decreases going down)
			Vector2 newSize = new Vector2(
				distanceFromPivot.x,  // Width = horizontal distance from top-left
				-distanceFromPivot.y  // Height = vertical distance (negative because Y decreases going down)
			);

			// Clamp size within min/max bounds
			newSize.x = C.clamp(newSize.x, minSize.x, maxSize.x);
			newSize.y = C.clamp(newSize.y, minSize.y, maxSize.y);

			// Apply the new size - this only changes sizeDelta, window position stays the same
			targetWindow.sizeDelta = newSize;
			handleRect.anchoredPosition = currentMousePos;

			// Handle automatically stays at bottom-right due to its anchor setup
		}

		private void OnEndResize()
		{
			if (!isResizing) return;

			if (logResizeEvents)
				Debug.Log("Resize ended");

			isResizing = false;
			resizeButton = -1;

			//
			this.KeepHandleAtBottomRightCorner();
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
				case PointerEventData.InputButton.Left: return resizeButton == 0;
				case PointerEventData.InputButton.Right: return resizeButton == 1;
				case PointerEventData.InputButton.Middle: return resizeButton == 2;
				default: return false;
			}
		}

		// Called Internal/Externally
		public void KeepHandleAtBottomRightCorner()
		{
			// Debug.Log("called handle KeepHandleAtBottomRightCorner()");
			Vector2 posOfWindow = targetWindow.anchoredPosition;

			// convert to anchor + pivot: bottom-left
			// posOfWindow = new Vector2(posOfWindow.x, INPUT.UI.size.y + posOfWindow.y); // its anchored + pivot top-left so coord shall be eg: (10, -100), i,e -100 from top
			posOfWindow = posOfWindow; // its anchored + pivot top-left so coord shall be eg: (10, -100), i,e -100 from top

			Vector2 sizeOfWindow = TargetWindow.sizeDelta;
			Vector2 sizeOfHandle = handleRect.sizeDelta; // for now not required, since it got a visual leaf
														 // using bottom-left anchor + pivot
														 // bottom-left anchor + pivot is the same system used while returning INPUT.UI.pos too.

			// note: transform.postion is depended on screen resolution, while anchored is constant regardless
			handleRect.anchoredPosition = posOfWindow  + new Vector2(sizeOfWindow.x, -sizeOfWindow.y);
		}

		#endregion

		#region Public Interface

		public bool IsResizing => isResizing;
		public int CurrentResizeButton => resizeButton;
		public RectTransform TargetWindow => targetWindow;

		public void SetMouseButtonSettings(bool left, bool right, bool middle)
		{
			useLeftMouseButton = left;
			useRightMouseButton = right;
			useMiddleMouseButton = middle;
		}

		public void SetSizeLimits(v2 min, v2 max)
		{
			minSize = min;
			maxSize = max;
		}

		public void SetTargetWindow(RectTransform window)
		{
			targetWindow = window;
		}

		/// <summary>
		/// Manually trigger handle repositioning (useful if window size changes externally)
		/// </summary>
		public void UpdateHandlePosition()
		{
			
		}

		#endregion
	}
}

