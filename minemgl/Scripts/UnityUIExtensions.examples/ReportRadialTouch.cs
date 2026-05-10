using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReportRadialTouch : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
{
	public Text OutputField;

	public void OnPointerEnter(PointerEventData eventData)
	{
		OutputField.text = "Enter - eligibleForClick [" + eventData.eligibleForClick + "] - pointerId [ " + eventData.pointerId + "]";
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		OutputField.text = "Pointer Down - eligibleForClick [" + eventData.eligibleForClick + "] - pointerId [ " + eventData.pointerId + "]";
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		OutputField.text = "Pointer Up - eligibleForClick [" + eventData.eligibleForClick + "] - pointerId [ " + eventData.pointerId + "]";
	}
}
