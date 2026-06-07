using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelectHandler : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, ISubmitHandler
{
	public Action OnSelected;

	public Action OnDeselected;

	public Action OnSubmitted;

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}

	public void OnSubmit(BaseEventData eventData)
	{
	}
}
