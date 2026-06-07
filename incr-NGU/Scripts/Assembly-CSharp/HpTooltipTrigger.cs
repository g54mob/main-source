using UnityEngine;
using UnityEngine.EventSystems;

public class HpTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public NumberFormat format;

	private string message;

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		tooltip.hideTooltip();
	}

	private void showTooltip()
	{
		message = "Max HP: " + format.suffixFormat(character.maxHP) + "\nHP Regen: " + format.suffixFormat(0.05 * character.defense) + "\\s";
		tooltip.showTooltip(message);
	}
}
