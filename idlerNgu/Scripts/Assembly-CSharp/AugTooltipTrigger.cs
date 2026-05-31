using UnityEngine;
using UnityEngine.EventSystems;

public class AugTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public AugmentController ac;

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	public void showTooltip()
	{
		ac.showAugTooltip();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		ac.hideTooltip();
	}
}
