using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler
{
	[SerializeField]
	private RectTransform dragRectTransform;

	[SerializeField]
	private Canvas canvas;

	public void OnDrag(PointerEventData eventData)
	{
		dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		dragRectTransform.SetAsLastSibling();
	}
}
