using UnityEngine;

public class StringIDTooltip : ObjectTooltip
{
	[SerializeField]
	private string _id;

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
