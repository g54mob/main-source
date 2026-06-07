using UnityEngine;
using UnityEngine.EventSystems;

public class RecyclerTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("Boost Recycling will give you a chance to keep your boost when using it and instead have it degrade to the tier below. For example, a boost 5 will turn into a boost 2. This means more boost for your buck");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
