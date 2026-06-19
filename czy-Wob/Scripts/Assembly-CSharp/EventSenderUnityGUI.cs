using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EventSenderUnityGUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public UnityEvent onPointerOverEvents;

	private bool mouseOver;

	private void Update()
	{
		if (mouseOver)
		{
			onPointerOverEvents.Invoke();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		mouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		mouseOver = false;
	}
}
