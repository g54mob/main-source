using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

using SPACE_UTIL;

namespace Check
{

	// detects well compared to drag handler
	// Works with custom mouse buttons (Left, Right, Middle)
	public class DEBUG_DragableItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[Header("Mouse Button Settings")]
		[SerializeField] bool useMiddleMouseButton = true;
		[SerializeField] bool useLeftMouseButton = true;
		[SerializeField] bool useRightMouseButton = true;

		[SerializeField] RectTransform dragableRectRegion;
		[SerializeField] bool log_drag_events = false;

		[Header("minimize")]
		[SerializeField] List<Button> minMaxButton_1D;
		[SerializeField] List<GameObject> minMaxInvolveObj_1D;

		[SerializeField] bool modifyMinMaximizeText = true;
		[Tooltip("make it true if you want window start with maximized")]
		[SerializeField] bool shouldBeMaximized;

		[Header("bounds")]
		[SerializeField] RectTransform BoundRect;
		[SerializeField] RectTransform CurrentRect;

		[Header("on drag resize script_window")]
		[SerializeField] RectTransform resizeScriptWindowRect;
		[SerializeField] v2 min = (400, 400), max = (800, 800);

		private Vector2 delta;
		private Transform entireWindowParentBeforeDrag;
		private bool isDragging = false;
		private bool isMouseOver = false;
		private int dragButton = -1; // Which button started the drag (0=Left, 1=Right, 2=Middle)

		private void Awake()
		{
			this.HandleMinimizeMaximize();
		}

		void HandleMinimizeMaximize()
		{
			if (this.minMaxButton_1D == null)
				return;
			if (minMaxInvolveObj_1D.Count == 0)
				return;

			//
			foreach (Button btn in minMaxButton_1D)
			{
				btn.onClick.AddListener(() =>
				{
					this.shouldBeMaximized = (minMaxInvolveObj_1D[0].active == false);
					TMPro.TextMeshProUGUI tm = btn.gameObject.NameStartsWith("text").GC<TMPro.TextMeshProUGUI>();

					if (this.shouldBeMaximized == true)
					{
						foreach (GameObject obj in this.minMaxInvolveObj_1D)
							obj.SetActive(true);

						if (this.modifyMinMaximizeText)
							tm.text = "-";
					}
					else
					{
						foreach (GameObject obj in this.minMaxInvolveObj_1D)
							obj.SetActive(false);

						if (this.modifyMinMaximizeText)
							tm.text = "v";
					}
				});
			}

			if (true)
			{
				// this.minimizedBefore = (minMaxInvolveObj_1D[0].active == false);
				if (this.shouldBeMaximized == true)
				{
					foreach (GameObject obj in this.minMaxInvolveObj_1D)
						obj.SetActive(true);

					if (this.modifyMinMaximizeText)
						foreach (Button btn in minMaxButton_1D)
						{
							TMPro.TextMeshProUGUI tm = btn.gameObject.NameStartsWith("text").GC<TMPro.TextMeshProUGUI>();
							tm.text = "-";
						}
				}
				else
				{
					foreach (GameObject obj in this.minMaxInvolveObj_1D)
						obj.SetActive(false);

					if (this.modifyMinMaximizeText)
						if (this.modifyMinMaximizeText)
							foreach (Button btn in minMaxButton_1D)
							{
								TMPro.TextMeshProUGUI tm = btn.gameObject.NameStartsWith("text").GC<TMPro.TextMeshProUGUI>();
								tm.text = "v";
							}
				}
			}
		}

		void Update()
		{
			if (isDragging)
			{
				// Continue dragging while button is held
				bool buttonStillDown = false;

				if (dragButton == 0 && Input.GetMouseButton(0)) buttonStillDown = true;
				else if (dragButton == 1 && Input.GetMouseButton(1)) buttonStillDown = true;
				else if (dragButton == 2 && Input.GetMouseButton(2)) buttonStillDown = true;

				if (buttonStillDown)
				{
					OnDrag();
				}
				else
				{
					OnEndDrag();
				}
			}
			else if (isMouseOver)
			{
				// Check for drag start with custom mouse buttons
				if (useMiddleMouseButton && Input.GetMouseButtonDown(2))
				{
					OnBeginDrag(2);
				}
				else if (useRightMouseButton && Input.GetMouseButtonDown(1))
				{
					OnBeginDrag(1);
				}
				else if (useLeftMouseButton && Input.GetMouseButtonDown(0))
				{
					OnBeginDrag(0);
				}
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			// Handle left mouse button through EventSystem if enabled
			if (useLeftMouseButton && eventData.button == PointerEventData.InputButton.Left)
			{
				OnBeginDrag(0);
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			// Handle mouse up through EventSystem
			if (isDragging &&
				((eventData.button == PointerEventData.InputButton.Left && dragButton == 0) ||
				 (eventData.button == PointerEventData.InputButton.Right && dragButton == 1) ||
				 (eventData.button == PointerEventData.InputButton.Middle && dragButton == 2)))
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

		// Modified version of your original OnBeginDrag
		public void OnBeginDrag(int buttonIndex)
		{
			if (isDragging) return;

			if (this.log_drag_events == true)
				Debug.Log($"OnBeginDrag with button {buttonIndex} (0=Left, 1=Right, 2=Middle)");
			isDragging = true;
			dragButton = buttonIndex;

			if (this.dragableRectRegion == null)
			{
				this.dragableRectRegion = this.gameObject.GC<RectTransform>();
			}

			this.entireWindowParentBeforeDrag = this.dragableRectRegion.parent;
			this.dragableRectRegion.SetParent(this.dragableRectRegion.root);
			this.dragableRectRegion.SetAsLastSibling();

			this.delta = dragableRectRegion.anchoredPosition - INPUT.UI.pos;
			Vector2 target_pos = INPUT.UI.pos + this.delta;

			// restriction within bounds >>

			// << restriction within bounds

			this.setAnchoredPosBasedOnResizable(target_pos);
		}

		// Modified version of your original OnDrag
		public void OnDrag()
		{
			if (!isDragging) return;

			if (this.log_drag_events == true)
				Debug.Log("OnDrag");
			Vector2 target_pos = INPUT.UI.pos + this.delta;

			// restriction within bounds >>
			#region clamp
			if (this.BoundRect != null && this.CurrentRect != null) // diable clamping if no bounds set
			{
				// clamp >>
				Rect PanelBounds = INPUT.UI.getBounds(this.BoundRect);
				Rect CurrentRect = INPUT.UI.getBounds(this.CurrentRect);
				int border = 2;

				// for origin/anchor at center-bottom
				target_pos.x = C.clamp(target_pos.x, PanelBounds.min.x + (border + CurrentRect.width / 2), PanelBounds.max.x - (border + CurrentRect.width / 2));
				target_pos.y = C.clamp(target_pos.y, PanelBounds.min.y + (border + 0), PanelBounds.max.y - (border + CurrentRect.height));
				// << clamp			
			}
			#endregion
			// << restriction within bounds

			this.setAnchoredPosBasedOnResizable(target_pos);


			// INPUT.UI
				// bottom-left: (0, 0)
				// top-right: (1280, 720)

			// handle anchored_pos
				// bottom-left: (-1280 0)
				// top-right: (0, 720)
		}

		// Modified version of your original OnEndDrag
		public void OnEndDrag()
		{
			if (!isDragging) return;

			if (this.log_drag_events == true)
				Debug.Log("OnEndDrag");
			Vector2 target_pos = INPUT.UI.pos + this.delta;

			// restriction within bounds >>
			// << restriction within bounds
			this.setAnchoredPosBasedOnResizable(target_pos);

			this.dragableRectRegion.parent = this.entireWindowParentBeforeDrag;

			isDragging = false;
			dragButton = -1;
		}
		void setAnchoredPosBasedOnResizable(v2 target_pos)
		{
			// resize >>
			if (this.resizeScriptWindowRect != null)
			{
				v2 delta = (Vector3)target_pos - this.resizeScriptWindowRect.transform.position;
				Debug.Log("delta raw: " + delta + " //targer_pos:  " +  target_pos + "// win_rect_transform: " + this.resizeScriptWindowRect.transform.position);
				v2 sign = (C.sign(delta.x), C.sign(delta.y));
				v2 delta_abs = C.abs(delta);

				delta_abs = C.clamp(delta_abs, INPUT.UI.invConvert(this.min), INPUT.UI.invConvert(this.max));
				delta = delta_abs * sign;
				Debug.Log("final delta: " + delta + " // " + INPUT.UI.convert(delta));
				dragableRectRegion.anchoredPosition = this.resizeScriptWindowRect.transform.position + (Vector3)delta;


				Debug.Log("INPUT.UI: " + INPUT.UI.pos);
				Debug.Log("anchiredPos swin: " + this.resizeScriptWindowRect.anchoredPosition);
				Debug.Log("transformPos swin: " + this.resizeScriptWindowRect.transform.position);
				Debug.Log("anchiredPos handle: " + this.dragableRectRegion.anchoredPosition);
				Debug.Log("transformPos handle: " + this.dragableRectRegion.transform.position);

				Vector2 size = INPUT.UI.convert(this.dragableRectRegion.transform.position - this.resizeScriptWindowRect.transform.position);
				Debug.Log("size without abs(): " + size);
				size = C.abs((Vector3)size);

				Debug.Log(size);
				// make sure no ui element of fixed width is compressed beyond
				if (size.in_range(this.min, this.max) == true)
				{
					// dragable only in limits set
					this.resizeScriptWindowRect.sizeDelta = size;
					//dragableRectRegion.anchoredPosition = target_pos;
				}
				else
				{
					
				}

				Debug.Log('='.repeat(20));
			}
			// normal behaviour
			else
				dragableRectRegion.anchoredPosition = target_pos;
			// << resize
		}

		// Legacy method overloads for compatibility (in case other code calls these)
		#region legacy
		public void OnBeginDrag(PointerEventData eventData)
		{
			if (useLeftMouseButton && eventData.button == PointerEventData.InputButton.Left)
			{
				OnBeginDrag(0);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			// This will be handled by the Update method
			// keeping this method for interface compatibility
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (isDragging && eventData.button == PointerEventData.InputButton.Left && dragButton == 0)
			{
				OnEndDrag();
			}
		} 
		#endregion

		// Public utility methods
		public bool IsDragging()
		{
			return isDragging;
		}

		public int GetDragButton()
		{
			return dragButton;
		}

		public void SetDragButtons(bool middle, bool left, bool right)
		{
			useMiddleMouseButton = middle;
			useLeftMouseButton = left;
			useRightMouseButton = right;
		}

	}

}
