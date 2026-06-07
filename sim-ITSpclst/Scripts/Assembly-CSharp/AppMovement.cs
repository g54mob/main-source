using UnityEngine;
using UnityEngine.EventSystems;

public class AppMovement : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
	public RectTransform appWindow;

	public RectTransform screenWindow;

	public Canvas canvas;

	public static int margin;

	public int marginCastom;

	private Camera mainCamera;

	private Vector3 dragOffset;

	private void Start()
	{
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void SetOnTop()
	{
	}

	private void SetPositionByMargin()
	{
	}

	private int getMargin()
	{
		return 0;
	}
}
