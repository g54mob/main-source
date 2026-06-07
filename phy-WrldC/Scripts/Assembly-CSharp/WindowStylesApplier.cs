using TMPro;
using UnityEngine;

public class WindowStylesApplier : StylesApplierBase
{
	[SerializeField]
	private GameObject headerPanel;

	[SerializeField]
	private GameObject contentPanel;

	[SerializeField]
	private GameObject subContentPanel;

	private TextMeshProUGUI titleText;

	public override void Initialize()
	{
		titleText = headerPanel.GetComponentInChildren<TextMeshProUGUI>();
	}

	public override void UpdateStyles()
	{
	}

	public override void UpdateTexts()
	{
		titleText.text = languages.GetText("window.title." + baseId, titleText.text);
	}
}
