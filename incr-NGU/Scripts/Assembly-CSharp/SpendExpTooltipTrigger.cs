using UnityEngine;
using UnityEngine.EventSystems;

public class SpendExpTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public Character character;

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("This will open up a magical menu to allow you to spend EXP on a huge variety of bonuses! Most of these bonuses are permanent, too!\n\nYou have <b>" + character.realExp.ToString("###,##0") + "</b> EXP to spend.");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
