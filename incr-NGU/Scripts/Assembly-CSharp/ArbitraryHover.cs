using UnityEngine;
using UnityEngine.EventSystems;

public class ArbitraryHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	private string message;

	public void OnPointerEnter(PointerEventData eventData)
	{
		message = "You gain Arbitrary Points (AP) for doing a wide variety of things ingame which I decide are worthy of AP. ";
		message += "Here's a short list of what earns you AP:\n\nEvery rebirth that lasts over 1 hour earns 1 AP every 500 seconds. You'll gain this AP upon rebirthing.\n<b>Titans award a lot of AP!</b>\nThrowing gold in the Money Pit earns AP depending on the amount tossed.\nEvery 10 Bosses in Adventure killed grants you 1 AP.\nThe Daily Spin can give you AP as a prize.";
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
