using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public string tip;

	public void OnPointerEnter(PointerEventData eventData)
	{
		TooltipSystem.Show(LocalizationSystem.GetLocalizedValue(tip));
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipSystem.Hide();
	}
}
