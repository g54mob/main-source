using UnityEngine;
using UnityEngine.EventSystems;

public class SpanMissionNetwork : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler
{
	private Vector3 startDragDelta;

	private float minDragX;

	private float maxDragX;

	private float minDragY;

	private float maxDragY;

	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
}
