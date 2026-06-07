using TMPro;

public class NormalTooltipPanel : TooltipPanelBase
{
	private TextMeshProUGUI helpText;

	private TextMeshProUGUI hotKeyText;

	protected override void Awake()
	{
		base.Awake();
		helpText = base.transform.FindComponent<TextMeshProUGUI>("HelpText", isRecursively: true);
		hotKeyText = base.transform.FindComponent<TextMeshProUGUI>("HotKeyText", isRecursively: true);
	}

	public void SetHelpAndHotKeyTexts(string help, string hotKey)
	{
		helpText.text = help;
		if (string.IsNullOrEmpty(hotKey))
		{
			hotKeyText.gameObject.SetActive(value: false);
			return;
		}
		hotKeyText.gameObject.SetActive(value: true);
		hotKeyText.text = "[" + hotKey + "]";
	}
}
