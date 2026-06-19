using TMPro;
using UnityEngine;

public class ContentLockTooltip : ObjectTooltip
{
	private static string id;

	private ContentLockTooltipRequest _request;

	[SerializeField]
	private TextMeshProUGUI _text;

	public override string ID => null;

	public override bool CanHandle(object obj)
	{
		return false;
	}

	public override bool CanWipe(object obj)
	{
		return false;
	}

	protected override bool DoHandle(object obj)
	{
		return false;
	}

	protected override bool DoWipe(object obj)
	{
		return false;
	}
}
