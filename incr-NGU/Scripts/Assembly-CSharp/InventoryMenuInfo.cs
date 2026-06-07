using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryMenuInfo : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	private string message;

	public void OnPointerEnter(PointerEventData eventData)
	{
		message = "<b>Inventory Menu</b>\n\n";
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
