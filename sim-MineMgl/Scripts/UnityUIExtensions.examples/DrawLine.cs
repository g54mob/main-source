using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

public class DrawLine : MonoBehaviour, IDragHandler, IEventSystemHandler, IDropHandler, IPointerDownHandler, IPointerUpHandler
{
	public enum DemoMode
	{
		DragDraw = 0,
		ClickDraw = 1
	}

	public UILineRenderer lineRenderer;

	public DemoMode SceneDemoMode;

	private RectTransform RT;

	private Vector2 rectPos;

	private List<Vector2> points = new List<Vector2>();

	private int CurrentLine;

	private Vector2 DragStartPos = Vector2.zero;

	private bool drawing;

	private bool mouseDown;

	private void Start()
	{
		lineRenderer = GetComponent<UILineRenderer>();
		RT = GetComponent<RectTransform>();
		rectPos = RT.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (SceneDemoMode != DemoMode.DragDraw)
		{
			return;
		}
		if (DragStartPos == Vector2.zero)
		{
			DragStartPos = eventData.position;
			if (points.Count < 1)
			{
				points.Add(new Vector2(DragStartPos.x - rectPos.x, DragStartPos.y - rectPos.y));
				CurrentLine++;
			}
			points.Add(new Vector2(DragStartPos.x - rectPos.x, DragStartPos.y - rectPos.y));
		}
		else
		{
			DrawLineToPoint(eventData.position);
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (SceneDemoMode == DemoMode.DragDraw)
		{
			points[CurrentLine] = new Vector2(eventData.position.x - rectPos.x, eventData.position.y - rectPos.y);
			RefreshLine();
			DragStartPos = Vector2.zero;
			CurrentLine++;
		}
	}

	private void Update()
	{
		if (SceneDemoMode == DemoMode.ClickDraw)
		{
			if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.Escape))
			{
				drawing = false;
			}
			if (drawing)
			{
				DrawLineToPoint(Input.mousePosition);
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!drawing)
		{
			drawing = true;
		}
		if (!mouseDown && SceneDemoMode == DemoMode.ClickDraw && drawing)
		{
			if (points.Count < 1)
			{
				points.Add(new Vector2(eventData.position.x - rectPos.x, eventData.position.y - rectPos.y));
			}
			points.Add(new Vector2(eventData.position.x - rectPos.x, eventData.position.y - rectPos.y));
			RefreshLine();
			CurrentLine++;
		}
		mouseDown = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		mouseDown = false;
	}

	private void RefreshLine()
	{
		lineRenderer.Points = points.ToArray();
		lineRenderer.SetAllDirty();
	}

	private void DrawLineToPoint(Vector3 position)
	{
		if (points.Count > CurrentLine)
		{
			points[CurrentLine] = new Vector2(position.x - rectPos.x, position.y - rectPos.y);
			RefreshLine();
		}
	}
}
