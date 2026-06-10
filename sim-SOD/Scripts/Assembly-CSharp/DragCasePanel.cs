using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCasePanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler
{
	private Vector2 pointerOffset;

	public RectTransform pinnedContainer;

	public RectTransform panelRect;

	public PinnedItemController itemController;

	public bool multipleParentInstances;

	private List<DragCasePanel> pinnedFiles;

	public List<Vector2> offsets;

	public void Setup(PinnedItemController newController)
	{
	}

	public void OnPointerDown(PointerEventData data)
	{
	}

	public void OnDrag(PointerEventData data)
	{
	}

	public void ForceDrag(Vector2 cursorPosition)
	{
	}

	public void ForceDragController(Vector2 newLocalPosition)
	{
	}

	private Vector2 ClampCursor(Vector2 rawPointerPosition)
	{
		return default(Vector2);
	}

	public void SetPositionCursor(Vector2 pointerPosition, Vector2 offset)
	{
	}

	public void SetPositionDirect(Vector2 localPosition)
	{
	}

	private Vector2 ClampToCorkboard(Vector2 original)
	{
		return default(Vector2);
	}

	private Vector2 RadiusClamp(Vector2 original, Vector2 point, float radius)
	{
		return default(Vector2);
	}
}
