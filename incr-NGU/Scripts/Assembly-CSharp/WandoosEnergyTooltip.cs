using UnityEngine;
using UnityEngine.EventSystems;

public class WandoosEnergyTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Wandoos98Controller wc;

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	public void showTooltip()
	{
		wc.showEnergyTooltip();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		wc.hideTooltip();
	}
}
