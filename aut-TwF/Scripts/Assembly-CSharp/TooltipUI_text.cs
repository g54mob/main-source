using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipUI_text : TooltipUI
{
	private const int MAX_CHARACTERS_PER_LINE = 50;

	[SerializeField]
	private TextMeshProUGUI tooltipText;

	public override void Setup(Dictionary<string, object> data)
	{
		tooltipText.text = FunctionLibrary.FormatText(data["text"] as string, 50);
		LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipText.transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
	}
}
