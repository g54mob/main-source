using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCoverage : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
	public delegate void OnDragCoverage();

	public RectTransform parentRect;

	private Vector2 currentPointerPosition;

	private Vector2 previousPointerPosition;

	public Vector2 pivot;

	public Vector2 sizeRange;

	public float edgeBuffer;

	public event OnDragCoverage OnDragged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void OnPointerDown(PointerEventData data)
	{
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData data)
	{
	}

	private void OnDestroy()
	{
	}

	public void SetSize(float newSize)
	{
	}
}
