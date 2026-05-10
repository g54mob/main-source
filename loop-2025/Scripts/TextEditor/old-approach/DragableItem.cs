using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using SPACE_UTIL;

namespace GptDeepResearch
{
	#region old drag
	// works only on left mouse click event
	public class ADragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField] RectTransform entireWindowRect;

		Vector2 delta;
		Transform entireWindowParentBeforeDrag;
		public void OnBeginDrag(PointerEventData eventData)
		{
			Debug.Log("OnBeginDrag");
			if (this.entireWindowRect == null)
				this.entireWindowRect = this.gameObject.GC<RectTransform>();

			this.entireWindowParentBeforeDrag = this.entireWindowRect.parent;
			this.entireWindowRect.SetParent(this.entireWindowRect.root);
			this.entireWindowRect.SetAsLastSibling();

			this.delta = entireWindowRect.anchoredPosition - INPUT.UI.pos;
			Vector2 targetPos = INPUT.UI.pos + this.delta;
			// restriction within bounds >>

			// << restriction within bounds
			entireWindowRect.anchoredPosition = targetPos;

			//throw new System.NotImplementedException();
		}

		public void OnDrag(PointerEventData eventData)
		{
			Debug.Log("OnDrag");
			// this.delta = WindowRect.anchoredPosition - INPUT.UI.pos;
			Vector2 targetPos = INPUT.UI.pos + this.delta;
			// restriction within bounds >>

			// << restriction within bounds
			entireWindowRect.anchoredPosition = targetPos;
			//throw new System.NotImplementedException();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			Debug.Log("OnEndDrag");
			// this.delta = WindowRect.anchoredPosition - INPUT.UI.pos;
			Vector2 targetPos = INPUT.UI.pos + this.delta;
			// restriction within bounds >>

			// << restriction within bounds
			entireWindowRect.anchoredPosition = targetPos;

			this.entireWindowRect.parent = this.entireWindowParentBeforeDrag;
			//throw new System.NotImplementedException();
		}


	} 
	#endregion

	// detects well compared to drag handler
	// Works with custom mouse buttons (Left, Right, Middle)
	public class DragableItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[Header("Mouse Button Settings")]
		public bool useMiddleMouseButton = true;
		public bool useLeftMouseButton = true;
		public bool useRightMouseButton = true;

		[Tooltip("must be a parent window/itself")]
		[Header("targetWindow")]
		[SerializeField] RectTransform targetWindow;
		[SerializeField] bool log_events = false;

		[Header("minimize")]
		[SerializeField] List<Button> minMaxButton_1D;
		[SerializeField] List<GameObject> minMaxInvolveObj_1D;
		[SerializeField] Image imageComponentToDisable;
		[SerializeField] bool modifyText = true;
		[Tooltip("make it true if you want window start with maximized")]
		[SerializeField] bool shouldBeMaximized;

		[Header("bounds")]
		[SerializeField] RectTransform BoundRect;
		[SerializeField] RectTransform CurrentRect;

		private Vector2 delta;
		private Transform entireWindowParentBeforeDrag;
		private bool isDragging = false;
		private bool isMouseOver = false;
		private int dragButton = -1; // Which button started the drag (0=Left, 1=Right, 2=Middle)

		private void Awake()
		{
			if (this.targetWindow == null)
			{
				//Debug.LogError("targetWindow must be either self/parent RectTransform");
				this.targetWindow = this.transform.parent.gameObject.GC<RectTransform>();
				Debug.Log("targetWindow set to 0 Ancestor");
			}

			this.HandleMinimizeMaximize();
		}

		void HandleMinimizeMaximize()
		{
			// do nothing if not assigned >>
			if (this.minMaxButton_1D == null)
				return;
			if (minMaxInvolveObj_1D.Count == 0)
				return;
			// << do nothing if not assigned

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

						if (this.imageComponentToDisable != null)
							this.imageComponentToDisable.enabled = true;

						if (this.modifyText)
							tm.text = "-";
					}
					else
					{
						foreach (GameObject obj in this.minMaxInvolveObj_1D)
							obj.SetActive(false);

						if (this.imageComponentToDisable != null)
							this.imageComponentToDisable.enabled = false;
						if (this.modifyText)
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

					if (this.imageComponentToDisable != null)
						this.imageComponentToDisable.enabled = true;

					if (this.modifyText)
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

					if (this.imageComponentToDisable != null)
						this.imageComponentToDisable.enabled = false;
					if (this.modifyText)
						if (this.modifyText)
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

			if (this.log_events == true)
				Debug.Log($"OnBeginDrag with button {buttonIndex} (0=Left, 1=Right, 2=Middle)");
			isDragging = true;
			dragButton = buttonIndex;

			if (this.targetWindow == null)
			{
				this.targetWindow = this.gameObject.GC<RectTransform>();
			}

			this.entireWindowParentBeforeDrag = this.targetWindow.parent;
			this.targetWindow.SetParent(this.targetWindow.root);
			this.targetWindow.SetAsLastSibling();

			this.delta = targetWindow.anchoredPosition - INPUT.UI.pos;
			Vector2 target_pos = INPUT.UI.pos + this.delta;

			// restriction within bounds >>

			// << restriction within bounds

			targetWindow.anchoredPosition = target_pos;
		}

		// Modified version of your original OnDrag
		public void OnDrag()
		{
			if (!isDragging) return;

			if (this.log_events == true)
				Debug.Log("OnDrag");
			Vector2 target_pos = INPUT.UI.pos + this.delta;

			// restriction within bounds >>
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
			// << restriction within bounds
			targetWindow.anchoredPosition = target_pos;

		}

		// Modified version of your original OnEndDrag
		public void OnEndDrag()
		{
			if (!isDragging) return;

			if (this.log_events == true)
				Debug.Log("OnEndDrag");
			Vector2 target_pos = INPUT.UI.pos + this.delta;

			// restriction within bounds >>
			// << restriction within bounds

			targetWindow.anchoredPosition = target_pos;
			this.targetWindow.parent = this.entireWindowParentBeforeDrag;

			isDragging = false;
			dragButton = -1;
		}

		// Legacy method overloads for compatibility (in case other code calls these)
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