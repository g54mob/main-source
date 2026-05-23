using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PaletteItemEventTrigger : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public UnityEvent onPointerEnterAction;

	public UnityEvent onPointerExitAction;

	public UnityEvent<BaseEventData> onPointerDownAction;

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
	}

	public void OnPointerDown(PointerEventData pointerEventData)
	{
	}
}
