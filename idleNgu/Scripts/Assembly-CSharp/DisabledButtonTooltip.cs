using UnityEngine;
using UnityEngine.UI;

public class DisabledButtonTooltip : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public Button button;

	public string message;

	public void tooltipEnter()
	{
		if (!button.interactable)
		{
			tooltip.showTooltip(message);
		}
	}

	public void tooltipExit()
	{
		tooltip.hideTooltip();
	}

	public void invTooltipEnter()
	{
		if (!button.interactable)
		{
			tooltip.showTooltip(message);
		}
		else
		{
			tooltip.showTooltip("<b>Keyboard Shortcuts:\n\nA+Click item: Use all possible boosts on this item.\nD+Click item: Merge all possible copies onto this item.\nCTRL+Click item: Trash/consumes/transforms item based on context.\nSHIFT+Click item: Protect item from trashing or transforming.\nRight Click Item: Quick-equip.</b>");
		}
	}
}
