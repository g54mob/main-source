using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIVirtualButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerClickHandler
{
	[Header("Output")]
	public UnityEvent<bool> buttonStateOutputEvent;

	public UnityEvent buttonClickOutputEvent;

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	private void OutputButtonStateValue(bool buttonState)
	{
	}

	private void OutputButtonClickEvent()
	{
	}
}
