using UnityEngine;

public class FixedTooltipTrigger : TooltipTriggerBase
{
	[SerializeField]
	[TextArea(4, 6)]
	private string tooltipText = "Default text...";

	private FixedTooltipPanel fixedTooltipPanel;

	public string TooltipText
	{
		get
		{
			return tooltipText;
		}
		set
		{
			tooltipText = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (tooltipPanel != null)
		{
			fixedTooltipPanel = tooltipPanel as FixedTooltipPanel;
		}
	}

	protected override void SetTooltipPanelContent()
	{
		fixedTooltipPanel?.SetText(tooltipText);
	}
}
