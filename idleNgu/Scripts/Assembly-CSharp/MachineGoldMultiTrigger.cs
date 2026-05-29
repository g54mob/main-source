using UnityEngine;
using UnityEngine.EventSystems;

public class MachineGoldMultiTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TimeMachineController mc;

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	private void showTooltip()
	{
		mc.displayGoldMultiTooltip();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		mc.hideTooltip();
	}
}
