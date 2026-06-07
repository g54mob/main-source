using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipUI_detailedText : TooltipUI
{
	private const int MAX_CHARACTERS_PER_LINE = 70;

	[SerializeField]
	private TextMeshProUGUI headerText;

	[SerializeField]
	private TextMeshProUGUI bodyText;

	public override void Setup(Dictionary<string, object> data)
	{
		headerText.text = data["headerText"] as string;
		bodyText.text = FunctionLibrary.FormatText(data["bodyText"] as string, 70);
		LayoutRebuilder.ForceRebuildLayoutImmediate(bodyText.transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
	}
}
