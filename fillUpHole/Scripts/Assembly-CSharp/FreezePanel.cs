using UnityEngine;
using UnityEngine.EventSystems;

public class FreezePanel : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("Image Clicked!");
		eventData.Use();
	}
}
