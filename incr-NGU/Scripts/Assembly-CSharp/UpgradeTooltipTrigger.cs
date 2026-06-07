using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public AugmentController ac;

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	public void showTooltip()
	{
		ac.showUpgradeTooltip();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		ac.hideTooltip();
	}
}
