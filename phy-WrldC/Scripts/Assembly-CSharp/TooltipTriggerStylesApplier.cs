public class TooltipTriggerStylesApplier : StylesApplierBase
{
	private NormalTooltipTrigger tooltipTrigger;

	public override void Initialize()
	{
		tooltipTrigger = GetComponent<NormalTooltipTrigger>();
	}

	public override void UpdateStyles()
	{
	}

	public override void UpdateTexts()
	{
		if (tooltipTrigger != null)
		{
			string id = "tooltip." + baseId;
			tooltipTrigger.HelpText = languages.GetText(id, tooltipTrigger.HelpText);
		}
	}
}
