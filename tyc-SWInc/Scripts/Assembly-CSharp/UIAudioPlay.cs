using UnityEngine;
using UnityEngine.EventSystems;

public class UIAudioPlay : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerEnterHandler, IPointerUpHandler
{
	public string OnMouseOver;

	public string OnMouseUp;

	public string OnMouseDown;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!string.IsNullOrEmpty(OnMouseDown))
		{
			UISoundFX.PlaySFX(OnMouseDown);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!string.IsNullOrEmpty(OnMouseOver))
		{
			UISoundFX.PlaySFX(OnMouseOver);
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!string.IsNullOrEmpty(OnMouseUp))
		{
			UISoundFX.PlaySFX(OnMouseUp);
		}
	}
}
