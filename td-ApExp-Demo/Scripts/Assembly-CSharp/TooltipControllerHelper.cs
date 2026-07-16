using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipControllerHelper : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	public event Action OnSelected;

	public event Action OnDeselected;

	public void OnSelect(BaseEventData eventData)
	{
		this.OnSelected?.Invoke();
	}

	public void OnDeselect(BaseEventData eventData)
	{
		this.OnDeselected?.Invoke();
	}
}
