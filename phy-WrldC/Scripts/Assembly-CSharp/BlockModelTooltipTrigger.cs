public class BlockModelTooltipTrigger : TooltipTriggerBase
{
	private BlockModelTooltipPanel blockModelTooltipPanel;

	public CreationModel CreationModel { get; set; }

	protected override void Update()
	{
		if (tooltipPanel == null && GameManager.Exist)
		{
			tooltipPanel = GameManager.Instance.GUIManager.BlockModelTooltipPanel;
		}
		if (blockModelTooltipPanel == null && tooltipPanel != null && tooltipPanel is BlockModelTooltipPanel)
		{
			blockModelTooltipPanel = tooltipPanel as BlockModelTooltipPanel;
		}
		base.Update();
	}

	protected override void SetTooltipPanelContent()
	{
		blockModelTooltipPanel.SetCreationModel(CreationModel);
	}
}
