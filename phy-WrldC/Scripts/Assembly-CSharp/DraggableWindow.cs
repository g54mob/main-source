using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableWindow : MonoBehaviour
{
	private enum PanelSide
	{
		Right = 0,
		Left = 1,
		Top = 2,
		Bottom = 3
	}

	[SerializeField]
	private RectTransform windowRectTransform;

	[SerializeField]
	private RectTransform draggableAreaRectTransform;

	private Canvas parentCanvas;

	private RectTransform parentCanvasRectTransform;

	private Vector2 lastWindowSize;

	private Vector3 initialAnchoredPosition;

	private Vector3 offsetPosition;

	private Vector3[] panelFourCorners = new Vector3[4];

	private Vector3[] canvasFourCorners = new Vector3[4];

	private float uiPixelScale;

	private void Awake()
	{
		parentCanvas = GetComponentInParent<Canvas>();
		parentCanvasRectTransform = parentCanvas.GetComponent<RectTransform>();
		uiPixelScale = parentCanvas.transform.localScale.x;
		lastWindowSize = windowRectTransform.rect.size;
		EventTrigger eventTrigger = draggableAreaRectTransform.GetComponent<EventTrigger>();
		if (eventTrigger == null)
		{
			eventTrigger = draggableAreaRectTransform.gameObject.AddComponent<EventTrigger>();
		}
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.BeginDrag;
		entry.callback.AddListener(delegate(BaseEventData eventData)
		{
			OnBeginDragHandler(eventData as PointerEventData);
		});
		eventTrigger.triggers.Add(entry);
		entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.Drag;
		entry.callback.AddListener(delegate(BaseEventData eventData)
		{
			OnDragHandler(eventData as PointerEventData);
		});
		eventTrigger.triggers.Add(entry);
	}

	private void Update()
	{
		if (windowRectTransform.rect.size != lastWindowSize)
		{
			MakeWindowInsideScreen();
			lastWindowSize = windowRectTransform.rect.size;
		}
	}

	public void SaveWindowPosition()
	{
		initialAnchoredPosition = windowRectTransform.anchoredPosition;
	}

	public void ResetWindowPosition()
	{
		windowRectTransform.anchoredPosition = initialAnchoredPosition;
	}

	private void OnBeginDragHandler(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			offsetPosition = windowRectTransform.position - Util.ConvertMousePositionToRectTransform(parentCanvas);
		}
	}

	private void OnDragHandler(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			Vector3 position = Util.ConvertMousePositionToRectTransform(parentCanvas) + offsetPosition;
			windowRectTransform.position = position;
			MakeWindowInsideScreen();
		}
	}

	private void MakeWindowInsideScreen()
	{
		windowRectTransform.GetWorldCorners(panelFourCorners);
		parentCanvasRectTransform.GetWorldCorners(canvasFourCorners);
		MakeWindowInsideSide(panelFourCorners[2].x, canvasFourCorners[2].x, PanelSide.Right);
		windowRectTransform.GetWorldCorners(panelFourCorners);
		MakeWindowInsideSide(panelFourCorners[1].x, canvasFourCorners[1].x, PanelSide.Left);
		windowRectTransform.GetWorldCorners(panelFourCorners);
		MakeWindowInsideSide(panelFourCorners[1].y, canvasFourCorners[1].y, PanelSide.Top);
		windowRectTransform.GetWorldCorners(panelFourCorners);
		MakeWindowInsideSide(panelFourCorners[0].y, canvasFourCorners[0].y, PanelSide.Bottom);
	}

	private void MakeWindowInsideSide(float panelSidePos, float canvasSidePos, PanelSide panelSideExtrapolation)
	{
		float num = 0f;
		switch (panelSideExtrapolation)
		{
		case PanelSide.Right:
		case PanelSide.Top:
			num = panelSidePos - canvasSidePos;
			break;
		case PanelSide.Left:
		case PanelSide.Bottom:
			num = canvasSidePos - panelSidePos;
			break;
		}
		num += 16f * uiPixelScale;
		if (num > 0f)
		{
			switch (panelSideExtrapolation)
			{
			case PanelSide.Right:
				base.transform.SetPositionX(base.transform.position.x - num);
				break;
			case PanelSide.Left:
				base.transform.SetPositionX(base.transform.position.x + num);
				break;
			case PanelSide.Top:
				base.transform.SetPositionY(base.transform.position.y - num);
				break;
			case PanelSide.Bottom:
				base.transform.SetPositionY(base.transform.position.y + num);
				break;
			}
		}
	}
}
