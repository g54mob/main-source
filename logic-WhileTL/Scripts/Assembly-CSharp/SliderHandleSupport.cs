using UnityEngine;
using UnityEngine.EventSystems;

public class SliderHandleSupport : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler
{
	private void Start()
	{
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 zero = Vector3.zero;
		zero.x = eventData.delta.x;
		zero.y = eventData.delta.y;
		base.gameObject.transform.position += zero;
	}
}
