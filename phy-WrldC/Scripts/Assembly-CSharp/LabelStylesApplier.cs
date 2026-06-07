using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class LabelStylesApplier : StylesApplierBase
{
	private TextMeshProUGUI labelText;

	[SerializeField]
	private bool shouldUnescapeLabelText;

	[SerializeField]
	private string prefixIconText;

	[SerializeField]
	private string suffixIconText;

	public override void Initialize()
	{
		labelText = GetComponent<TextMeshProUGUI>();
	}

	public override void UpdateStyles()
	{
	}

	public override void UpdateTexts()
	{
		if (!string.IsNullOrEmpty(baseId))
		{
			labelText.text = "";
			if (!string.IsNullOrEmpty(prefixIconText))
			{
				labelText.text = Regex.Unescape(prefixIconText);
			}
			string text = languages.GetText("label.text." + baseId, labelText.text);
			labelText.text = (shouldUnescapeLabelText ? Regex.Unescape(text) : text);
			if (!string.IsNullOrEmpty(suffixIconText))
			{
				labelText.text += Regex.Unescape(suffixIconText);
			}
		}
	}
}
