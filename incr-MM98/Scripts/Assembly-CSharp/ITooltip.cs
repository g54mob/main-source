using UnityEngine.EventSystems;

public interface ITooltip : IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	Tooltip Tooltip { get; }

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		RefreshTooltip();
		MonoSingleton<TooltipVisualizer>.Instance.Show(Tooltip.title, Tooltip.description);
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		MonoSingleton<TooltipVisualizer>.Instance.Hide();
	}

	void RefreshTooltip()
	{
	}
}
