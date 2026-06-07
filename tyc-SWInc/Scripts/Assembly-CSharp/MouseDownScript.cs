using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MouseDownScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler
{
	public UnityEvent OnDown;

	public UnityEvent OnDownRight;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			OnDown.Invoke();
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			OnDownRight.Invoke();
		}
	}
}
