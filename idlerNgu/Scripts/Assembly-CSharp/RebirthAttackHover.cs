using UnityEngine;
using UnityEngine.EventSystems;

public class RebirthAttackHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("This is how much your overall Attack stat will be multiplied by on your next rebirth. Highest boss killed on a rebirth, rebirth time, Attack training levels, and many other factors influence this value.");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
