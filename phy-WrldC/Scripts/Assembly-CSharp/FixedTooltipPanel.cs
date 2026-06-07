using TMPro;

public class FixedTooltipPanel : TooltipPanelBase
{
	private TextMeshProUGUI fixedTooltipText;

	protected override void Awake()
	{
		base.Awake();
		fixedTooltipText = base.transform.FindComponent<TextMeshProUGUI>("FixedTooltipText", isRecursively: true);
	}

	public void SetText(string text)
	{
		fixedTooltipText.SetText(text);
	}
}
