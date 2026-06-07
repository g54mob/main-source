using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonEventTrigger : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField]
	private Selectable targetSelectable;

	public UnityEvent selectEvent;

	public UnityEvent deselectEvent;

	public UnityEvent pointerEnterEvent;

	public UnityEvent pointerExitEvent;

	public void OnSelect(BaseEventData eventData)
	{
		selectEvent.Invoke();
	}

	public void OnDeselect(BaseEventData eventData)
	{
		deselectEvent.Invoke();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		pointerEnterEvent.Invoke();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		pointerExitEvent.Invoke();
	}

	public void TriggerOnDeselect()
	{
		EventSystem.current.SetSelectedGameObject(null);
		BaseEventData eventData = new BaseEventData(EventSystem.current);
		if (targetSelectable != null)
		{
			targetSelectable.OnDeselect(eventData);
		}
	}
}
