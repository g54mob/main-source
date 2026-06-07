using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundClickResponder : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		MenuManager.Instance.OnBackgroundPointerDown();
	}
}
