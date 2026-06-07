using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class TooltipComponent_text : TooltipComponent
{
	private string tooltipText;

	[SerializeField]
	private LocalizedString defaultTooltipText;

	public string TooltipText
	{
		get
		{
			return tooltipText;
		}
		set
		{
			tooltipText = value;
			InvokeDataChanged();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (defaultTooltipText != null && !defaultTooltipText.IsEmpty)
		{
			TooltipText = defaultTooltipText.GetLocalizedString();
		}
	}

	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object> { { "text", tooltipText } };
	}
}
