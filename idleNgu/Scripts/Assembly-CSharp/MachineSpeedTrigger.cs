using UnityEngine;
using UnityEngine.EventSystems;

public class MachineSpeedTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TimeMachineController mc;

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	private void showTooltip()
	{
		mc.displaySpeedTooltip();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		mc.hideTooltip();
	}
}
