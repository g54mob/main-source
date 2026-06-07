public class BlockTooltipTrigger : TooltipTriggerBase
{
	private BlockTooltipPanel blockTooltipPanel;

	public CreationModel CreationModel { get; set; }

	protected override void Update()
	{
		if (tooltipPanel == null && GameManager.Exist)
		{
			tooltipPanel = GameManager.Instance.GUIManager.BlockTooltipPanel;
		}
		if (blockTooltipPanel == null && tooltipPanel != null && tooltipPanel is BlockTooltipPanel)
		{
			blockTooltipPanel = tooltipPanel as BlockTooltipPanel;
		}
		base.Update();
	}

	protected override void SetTooltipPanelContent()
	{
		if (CreationModel != null)
		{
			blockTooltipPanel.SetCreationInfo(CreationModel);
		}
	}
}
