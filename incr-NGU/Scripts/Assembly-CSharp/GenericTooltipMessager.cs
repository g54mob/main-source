using UnityEngine;
using UnityEngine.EventSystems;

public class GenericTooltipMessager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public string message;

	public HoverTooltip tooltip;

	public bool tooltipOverride;

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
