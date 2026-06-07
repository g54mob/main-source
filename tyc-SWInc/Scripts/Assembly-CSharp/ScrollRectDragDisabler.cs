using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollRectDragDisabler : MonoBehaviour, IDragHandler, IEventSystemHandler
{
	private void Start()
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
		eventData.Use();
	}
}
