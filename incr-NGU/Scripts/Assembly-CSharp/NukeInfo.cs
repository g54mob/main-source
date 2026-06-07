using UnityEngine;
using UnityEngine.EventSystems;

public class NukeInfo : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("Click this button to blast through all those scrub bosses that you can annihilate with a flick of your fingers. Your wrists will thank me later.");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
