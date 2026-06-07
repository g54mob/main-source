using Factory;
using Motorways.Views;
using UnityEngine;
using UnityEngine.UI;

public class MotorwaysInGameStateToggleController : MotorwaysMenuNavigation
{
	public enum InGameControllerState
	{
		OutOfGame = 0,
		EditingTiles = 1,
		SelectingUpgrades = 2,
		InGameOverlayScreen = 3,
		PauseScreen = 4,
		EditMenu = 5
	}

	public enum StateSwapActionBehaviour
	{
		MaintainActions = 0,
		CancelActions = 1
	}

	[Dependency]
	private PlayerActionController _actionController;

	[Dependency]
	private InputState _inputState;

	public InGameControllerState ControllerState { get; protected set; }

	public static void SwitchToStateIfNeeded(InGameControllerState newState, IScope scope, StateSwapActionBehaviour actionBehaviour = StateSwapActionBehaviour.MaintainActions)
	{
		if (scope.Get<MenuNavigation>() is MotorwaysMenuNavigation motorwaysMenuNavigation && typeof(MotorwaysInGameStateToggleController).IsAssignableFrom(motorwaysMenuNavigation.GetType()))
		{
			((MotorwaysInGameStateToggleController)motorwaysMenuNavigation).SwitchToState(newState, scope, actionBehaviour);
		}
	}

	public virtual void SwitchToState(InGameControllerState newState, IScope scope, StateSwapActionBehaviour actionBehaviour = StateSwapActionBehaviour.MaintainActions)
	{
		switch (newState)
		{
		case InGameControllerState.EditingTiles:
			ReleaseUIFocus();
			break;
		case InGameControllerState.SelectingUpgrades:
		{
			GameUIScreen gameUIScreen = scope.Get<GameUIScreen>();
			if (Diagnostics.Verify(gameUIScreen != null))
			{
				Selectable firstUpgradeIconSelectable = gameUIScreen.GetFirstUpgradeIconSelectable();
				if (firstUpgradeIconSelectable != null)
				{
					SetNewFocus(firstUpgradeIconSelectable);
				}
				else
				{
					newState = ControllerState;
				}
			}
			break;
		}
		}
		if (ControllerState != newState)
		{
			ControllerState = newState;
			if (actionBehaviour == StateSwapActionBehaviour.CancelActions)
			{
				_actionController.CancelAllActions();
			}
		}
		_inputState.MaxRecognizedTouchCount = ((newState != InGameControllerState.EditingTiles) ? 1 : 2);
	}

	public override bool MoveCursor(Vector2 direction)
	{
		bool flag = base.MoveCursor(direction);
		if (!flag && direction.x > menuNavigationSwipeThreshold && ControllerState == InGameControllerState.SelectingUpgrades)
		{
			SwitchToState(InGameControllerState.EditingTiles, _scope);
			return true;
		}
		return flag;
	}
}
