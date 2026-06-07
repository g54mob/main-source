using System;
using UnityEngine;

public class DraggableBorder : MonoBehaviour
{
	private RectTransform targetPanelTransform;

	private MenuPanel parentMenuPanel;

	private Vector3 dragStart;

	private Vector2 initialSize;

	private Vector2 minSize;

	private Vector2 minDiffBounds;

	private Vector2 maxDiffBounds;

	private Vector3 initialWorldPosition;

	private Vector3 initialScreenPosition;

	private bool currentAdjustOriginX;

	private bool currentAdjustOriginY;

	public DraggableBorderComponent leftEdge;

	public DraggableBorderComponent rightEdge;

	public DraggableBorderComponent bottomEdge;

	public DraggableBorderComponent topEdge;

	public DraggableBorderComponent bottomLeftCorner;

	public DraggableBorderComponent bottomRightCorner;

	public Vector2 specifiedMinSize;

	[NonSerialized]
	public bool isDragging;

	private Vector2 dragPivot;

	public void Awake()
	{
		targetPanelTransform = (RectTransform)base.transform.parent;
		if (null != targetPanelTransform)
		{
			parentMenuPanel = targetPanelTransform.GetComponent<MenuPanel>();
		}
		RectTransform component = GetComponent<RectTransform>();
		if (null != component)
		{
			component.anchorMin = new Vector2(0f, 0f);
			component.anchorMax = new Vector2(1f, 1f);
			component.SetLeft(0f);
			component.SetRight(0f);
			component.SetTop(0f);
			component.SetBottom(0f);
		}
	}

	public void OnHover(DraggableBorderComponent borderComponent)
	{
		if (borderComponent == leftEdge || borderComponent == rightEdge)
		{
			MenuManager.Instance.cursorDisplay.SetCursorResizeHorizontal();
		}
		else if (borderComponent == bottomEdge || borderComponent == topEdge)
		{
			MenuManager.Instance.cursorDisplay.SetCursorResizeVertical();
		}
		else if (borderComponent == bottomLeftCorner)
		{
			MenuManager.Instance.cursorDisplay.SetCursorResizeLeftCorner();
		}
		else if (borderComponent == bottomRightCorner)
		{
			MenuManager.Instance.cursorDisplay.SetCursorResizeRightCorner();
		}
	}

	public void OnBeginDrag(DraggableBorderComponent borderComponent)
	{
		isDragging = true;
		float x = 200f;
		float y = 200f;
		if (specifiedMinSize.x > 0f)
		{
			x = specifiedMinSize.x;
		}
		if (specifiedMinSize.y > 0f)
		{
			y = specifiedMinSize.y;
		}
		minSize = new Vector2(x, y);
		dragStart = UserInput.ScreenMousePos();
		initialSize = targetPanelTransform.sizeDelta;
		initialWorldPosition = targetPanelTransform.position;
		initialScreenPosition = StartupManager.Instance.mainCamera.WorldToScreenPoint(initialWorldPosition);
		currentAdjustOriginX = false;
		currentAdjustOriginY = false;
		minDiffBounds = Vector2.zero;
		maxDiffBounds = Vector2.zero;
		float y2 = initialSize.y - minSize.y;
		if (borderComponent == leftEdge)
		{
			currentAdjustOriginX = true;
			minDiffBounds = new Vector2(float.MinValue, 0f);
			maxDiffBounds = new Vector2(initialSize.x - minSize.x, 0f);
			dragPivot = new Vector2(0f, 0.5f);
		}
		else if (borderComponent == rightEdge)
		{
			minDiffBounds = new Vector2(minSize.x - initialSize.x, 0f);
			maxDiffBounds = new Vector2(float.MaxValue, 0f);
			dragPivot = new Vector2(1f, 0.5f);
		}
		else if (borderComponent == topEdge)
		{
			currentAdjustOriginY = true;
			minDiffBounds = new Vector2(0f, minSize.y - initialSize.y);
			maxDiffBounds = new Vector2(0f, float.MaxValue);
			dragPivot = new Vector2(0.5f, 1f);
		}
		else if (borderComponent == bottomEdge)
		{
			minDiffBounds = new Vector2(0f, float.MinValue);
			maxDiffBounds = new Vector2(0f, y2);
			dragPivot = new Vector2(0.5f, 0f);
		}
		else if (borderComponent == bottomLeftCorner)
		{
			currentAdjustOriginX = true;
			minDiffBounds = new Vector2(float.MinValue, float.MinValue);
			maxDiffBounds = new Vector2(initialSize.x - minSize.x, y2);
			dragPivot = new Vector2(0f, 0f);
		}
		else if (borderComponent == bottomRightCorner)
		{
			minDiffBounds = new Vector2(minSize.x - initialSize.x, float.MinValue);
			maxDiffBounds = new Vector2(float.MaxValue, y2);
			dragPivot = new Vector2(1f, 0f);
		}
	}

	public void OnDrag()
	{
		Vector3 vector = UserInput.ScreenMousePos();
		float num = Mathf.Clamp(vector.x - dragStart.x, minDiffBounds.x, maxDiffBounds.x);
		float num2 = Mathf.Clamp(vector.y - dragStart.y, minDiffBounds.y, maxDiffBounds.y);
		float scaleFactor = MenuManager.Instance.canvas.scaleFactor;
		float x = ((!currentAdjustOriginX) ? (initialSize.x + num) : (initialSize.x - num));
		float y = ((!currentAdjustOriginY) ? (initialSize.y - num2) : (initialSize.y + num2));
		targetPanelTransform.sizeDelta = new Vector2(x, y);
		Vector3 localScale = targetPanelTransform.localScale;
		Vector2 pivot = targetPanelTransform.pivot;
		Vector2 vector2 = new Vector2(1f - Mathf.Abs(dragPivot.x - pivot.x), 1f - Mathf.Abs(dragPivot.y - pivot.y));
		float num3 = num * vector2.x * localScale.x;
		float num4 = num2 * vector2.y * localScale.y;
		float x2 = initialScreenPosition.x + num3 * scaleFactor;
		float y2 = initialScreenPosition.y + num4 * scaleFactor;
		Vector3 position = new Vector3(x2, y2, 0f);
		Vector3 vector3 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(position);
		targetPanelTransform.position = new Vector3(vector3.x, vector3.y, initialWorldPosition.z);
	}

	public void OnEndDrag()
	{
		isDragging = false;
		parentMenuPanel.SaveLayout();
	}

	private void OnDisable()
	{
		MenuManager.Instance.cursorDisplay.SetCursorDefault();
	}
}
