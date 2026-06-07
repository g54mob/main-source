using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class TooltipComponent_detailedText : TooltipComponent
{
	private string headerText;

	[SerializeField]
	private LocalizedString defaultHeaderText;

	private string bodyText;

	[SerializeField]
	private LocalizedString defaultBodyText;

	public string HeaderText
	{
		set
		{
			headerText = value;
			InvokeDataChanged();
		}
	}

	public string BodyText
	{
		set
		{
			bodyText = value;
			InvokeDataChanged();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (defaultHeaderText != null && !defaultHeaderText.IsEmpty)
		{
			HeaderText = defaultHeaderText.GetLocalizedString();
		}
		if (defaultBodyText != null && !defaultBodyText.IsEmpty)
		{
			BodyText = defaultBodyText.GetLocalizedString();
		}
	}

	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object>
		{
			{ "bodyText", bodyText },
			{ "headerText", headerText }
		};
	}
}
