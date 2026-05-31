using UnityEngine;

public class CanvasSimpleExitCondition : CanvasExitCondition
{
	[SerializeField]
	private bool _canBeExitedWithMouse;

	[SerializeField]
	private bool _canBeExitedWithEscape;

	public override bool CanBeExitedWithMouse()
	{
		return _canBeExitedWithMouse;
	}

	public override bool CanBeExitedWithEscape()
	{
		return _canBeExitedWithEscape;
	}
}
