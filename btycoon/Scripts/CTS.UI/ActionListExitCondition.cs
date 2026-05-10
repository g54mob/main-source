using CTS.Core;
using UnityEngine;

public class ActionListExitCondition : CanvasExitCondition
{
	[SerializeField]
	[Inject(false)]
	private ActionListCanvas _actionList;

	public override bool CanBeExitedWithMouse()
	{
		return !_actionList.IsInProgress();
	}

	public override bool CanBeExitedWithEscape()
	{
		if (_actionList.IsInProgress())
		{
			_actionList.CancelCurrentAction();
			return false;
		}
		return true;
	}
}
