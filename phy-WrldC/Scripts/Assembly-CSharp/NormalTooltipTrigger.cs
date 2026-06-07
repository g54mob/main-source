using UnityEngine;

public class NormalTooltipTrigger : TooltipTriggerBase
{
	[SerializeField]
	[TextArea(4, 6)]
	private string helpText = "Default text...";

	[SerializeField]
	private string hotKeyText = "";

	private NormalTooltipPanel normalTooltipPanel;

	public string HelpText
	{
		get
		{
			return helpText;
		}
		set
		{
			helpText = value;
		}
	}

	public string HotKeyText
	{
		get
		{
			return hotKeyText;
		}
		set
		{
			hotKeyText = value;
		}
	}

	protected override void Update()
	{
		if (tooltipPanel == null && GameManager.Exist)
		{
			tooltipPanel = GameManager.Instance.GUIManager.NormalTooltipPanel;
		}
		if (normalTooltipPanel == null && tooltipPanel != null && tooltipPanel is NormalTooltipPanel)
		{
			normalTooltipPanel = tooltipPanel as NormalTooltipPanel;
		}
		base.Update();
	}

	protected override void SetTooltipPanelContent()
	{
		normalTooltipPanel.SetHelpAndHotKeyTexts(helpText, hotKeyText);
	}
}
