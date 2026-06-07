using Factory;
using Motorways.Actions;
using Motorways.Views;

public class ChangeUpgradeBarAction : MotorwaysPlayerAction
{
	private enum VisibilityState
	{
		Down = 0,
		Up = 1,
		UpLocked = 2
	}

	private VisibilityState _visibilityState;

	public override void OnActionBegin(float timestamp)
	{
		base.OnActionBegin(timestamp);
		if (_gameUI.UpgradeBar is UpgradeBarClientHorizontal upgradeBarClientHorizontal)
		{
			switch (_visibilityState)
			{
			case VisibilityState.Down:
				upgradeBarClientHorizontal.HideHud(saveLockedStateToProfile: true);
				SetColourWidgetRadialVisible(visible: false);
				break;
			case VisibilityState.Up:
				upgradeBarClientHorizontal.ShowHud(locked: false);
				SetColourWidgetRadialVisible(visible: true);
				break;
			case VisibilityState.UpLocked:
				upgradeBarClientHorizontal.ShowHud(locked: true);
				SetColourWidgetRadialVisible(visible: true);
				break;
			default:
				Diagnostics.FailAssert("Unexpected ChangeUpgradeBarAction.State: {0}. Has someone forgotten to update this switch statement?", _visibilityState);
				break;
			}
		}
	}

	public override void Tick(float frameTime)
	{
		OnActionComplete();
	}

	public override void Reset()
	{
		base.Reset();
		_visibilityState = VisibilityState.Down;
	}

	private static ChangeUpgradeBarAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		ChangeUpgradeBarAction changeUpgradeBarAction = scope.Get<ChangeUpgradeBarAction>();
		changeUpgradeBarAction.InitializeAction(owningGroup, timestamp);
		return changeUpgradeBarAction;
	}

	private static VisibilityState CurrentUpgradeBarState(UpgradeBarClientHorizontal upgradeBar)
	{
		if (upgradeBar.AreUpgradesShowing())
		{
			if (upgradeBar.IsLocked)
			{
				return VisibilityState.UpLocked;
			}
			return VisibilityState.Up;
		}
		return VisibilityState.Down;
	}

	public static ChangeUpgradeBarAction CreateShowOrLockUpgradeBar(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		ChangeUpgradeBarAction changeUpgradeBarAction = Create(owningGroup, scope, timestamp);
		if (changeUpgradeBarAction._gameUI.UpgradeBar is UpgradeBarClientHorizontal upgradeBar)
		{
			VisibilityState visibilityState = CurrentUpgradeBarState(upgradeBar);
			switch (visibilityState)
			{
			case VisibilityState.Down:
				changeUpgradeBarAction._visibilityState = VisibilityState.Up;
				break;
			case VisibilityState.Up:
				changeUpgradeBarAction._visibilityState = VisibilityState.UpLocked;
				break;
			case VisibilityState.UpLocked:
				changeUpgradeBarAction._visibilityState = VisibilityState.UpLocked;
				break;
			default:
				Diagnostics.FailAssert("Unexpected ChangeUpgradeBarAction.VisibilityState: {0}. Has someone forgotten to update this switch statement?", visibilityState);
				break;
			}
		}
		changeUpgradeBarAction.OnActionBegin(timestamp);
		return changeUpgradeBarAction;
	}

	public static ChangeUpgradeBarAction CreateHideUpgradeBar(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		ChangeUpgradeBarAction changeUpgradeBarAction = Create(owningGroup, scope, timestamp);
		changeUpgradeBarAction._visibilityState = VisibilityState.Down;
		changeUpgradeBarAction.OnActionBegin(timestamp);
		return changeUpgradeBarAction;
	}
}
