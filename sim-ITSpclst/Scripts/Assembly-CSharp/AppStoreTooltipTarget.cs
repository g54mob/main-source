using UnityEngine;
using UnityEngine.EventSystems;

public class AppStoreTooltipTarget : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public string tooltipMessage;

	public AppStoreTooltipUI tooltipUI;

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
