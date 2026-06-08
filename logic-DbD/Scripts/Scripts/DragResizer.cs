using UnityEngine;
using UnityEngine.EventSystems;

public class DragResizer : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler
{
	[SerializeField]
	private float minWidth;

	[SerializeField]
	private float maxWidth;

	[SerializeField]
	private float minHeight;

	[SerializeField]
	private float maxHeight;

	private RectTransform parentRectTransform;

	private Panel parentPanel;

	private Canvas canvas;

	private void Start()
	{
		parentRectTransform = base.transform.parent.GetComponent<RectTransform>();
		parentPanel = base.transform.parent.GetComponent<Panel>();
	}

	public void OnPointerEnter(PointerEventData data)
	{
		CursorManager.SetCursorExpand();
	}

	public void OnPointerExit(PointerEventData data)
	{
		CursorManager.SetCursorNormal();
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			CursorManager.SetCursorExpand();
			if (canvas == null)
			{
				canvas = UIUtils.FindCanvasFromChild(base.transform);
			}
			Vector2 vector = eventData.delta / canvas.scaleFactor;
			float value = parentRectTransform.rect.width + vector.x;
			(float, bool) boundary = GetBoundary(value, minWidth, maxWidth);
			float item = boundary.Item1;
			bool item2 = boundary.Item2;
			float value2 = parentRectTransform.rect.height - vector.y;
			(float, bool) boundary2 = GetBoundary(value2, minHeight, maxHeight);
			float item3 = boundary2.Item1;
			bool item4 = boundary2.Item2;
			Vector2 vector2 = vector / 2f;
			parentRectTransform.anchoredPosition += new Vector2(item2 ? vector2.x : 0f, item4 ? vector2.y : 0f);
			if (item2)
			{
				parentRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, item);
			}
			if (item4)
			{
				parentRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, item3);
			}
			if (item2 || item4)
			{
				parentPanel.SetCurrentPosition();
			}
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		CursorManager.SetCursorNormal();
	}

	public (float, bool) GetBoundary(float value, float min, float max)
	{
		if (value > max)
		{
			return (max, false);
		}
		if (value < min)
		{
			return (min, false);
		}
		return (value, true);
	}
}
