using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CollectionItemEventTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerClickHandler
{
	public UnityEvent onPointerClickAction;

	public UnityEvent onPointerEnterAction;

	public void OnPointerClick(PointerEventData pointerEventData)
	{
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
	}
}
