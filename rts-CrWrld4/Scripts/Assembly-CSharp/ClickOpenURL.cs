using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOpenURL : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public string url;

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
