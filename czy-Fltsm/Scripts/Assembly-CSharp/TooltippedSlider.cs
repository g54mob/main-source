using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltippedSlider : Slider, IEndDragHandler, IEventSystemHandler, ITooltipProvider
{
	[SerializeField]
	protected LocalizedString _tooltip = null;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		TooltipPanel.HideTooltip(this);
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);
		if (!string.IsNullOrWhiteSpace(ReturnParsedTooltip(_tooltip)))
		{
			TooltipPanel.ShowTooltip(this);
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		TooltipPanel.HideTooltip(this);
	}

	public virtual string ReturnParsedTooltip(string tooltip)
	{
		return tooltip;
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return _tooltip;
	}
}
