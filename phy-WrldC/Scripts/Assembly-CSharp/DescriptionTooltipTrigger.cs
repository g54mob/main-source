public class DescriptionTooltipTrigger : TooltipTriggerBase
{
	private DescriptionTooltipPanel descriptionTooltipPanel;

	public string Description { get; set; }

	protected override void Update()
	{
		if (tooltipPanel == null && GameManager.Exist)
		{
			tooltipPanel = GameManager.Instance.GUIManager.DescriptionTooltipPanel;
		}
		if (descriptionTooltipPanel == null && tooltipPanel != null && tooltipPanel is DescriptionTooltipPanel)
		{
			descriptionTooltipPanel = tooltipPanel as DescriptionTooltipPanel;
		}
		base.Update();
	}

	protected override void SetTooltipPanelContent()
	{
		if (!string.IsNullOrEmpty(Description))
		{
			descriptionTooltipPanel.SetDescriptionText(Description);
		}
	}
}
