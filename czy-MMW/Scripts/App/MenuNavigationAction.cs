using Factory;
using UnityEngine;

public class MenuNavigationAction : PlayerAction
{
	protected enum NavigationAction
	{
		AccumulateMove = 0,
		ResetAccumulated = 1,
		MoveCursor = 2,
		ActivateSelected = 3,
		BackSelected = 4,
		PageSelected = 5
	}

	[Dependency]
	protected MenuNavigation _menuNavigation;

	protected NavigationAction _action;

	protected Vector2 _direction;

	public override bool IsInterruptible => true;

	public override void OnActionBegin(float timestamp)
	{
		base.OnActionBegin(timestamp);
		switch (_action)
		{
		case NavigationAction.MoveCursor:
			_menuNavigation.MoveCursor(_direction);
			break;
		case NavigationAction.AccumulateMove:
			_menuNavigation.AccumulateMove(_direction);
			break;
		case NavigationAction.ActivateSelected:
			if (_menuNavigation.ActivateSelected())
			{
				MakeExclusive();
			}
			break;
		case NavigationAction.BackSelected:
			_menuNavigation.BackActivated();
			break;
		case NavigationAction.PageSelected:
			_menuNavigation.PageSelected(_direction);
			break;
		case NavigationAction.ResetAccumulated:
			break;
		}
	}

	public override void Tick(float frameTime)
	{
		OnActionComplete();
	}

	public override void Reset()
	{
		base.Reset();
		_action = NavigationAction.AccumulateMove;
		_direction = default(Vector2);
	}

	public static MenuNavigationAction CreateMove(PlayerActionGroup owningGroup, IScope scope, float timestamp, Vector2 direction)
	{
		MenuNavigationAction menuNavigationAction = scope.Get<MenuNavigationAction>();
		menuNavigationAction._action = NavigationAction.MoveCursor;
		menuNavigationAction._direction = direction;
		menuNavigationAction.InitializeAction(owningGroup, timestamp);
		menuNavigationAction.OnActionBegin(timestamp);
		return menuNavigationAction;
	}

	public static MenuNavigationAction CreateAccumulateMove(PlayerActionGroup owningGroup, IScope scope, float timestamp, Vector2 direction)
	{
		MenuNavigationAction menuNavigationAction = scope.Get<MenuNavigationAction>();
		menuNavigationAction._action = NavigationAction.AccumulateMove;
		menuNavigationAction._direction = direction;
		menuNavigationAction.InitializeAction(owningGroup, timestamp);
		menuNavigationAction.OnActionBegin(timestamp);
		return menuNavigationAction;
	}

	public static MenuNavigationAction CreateResetAccumulated(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		MenuNavigationAction menuNavigationAction = scope.Get<MenuNavigationAction>();
		menuNavigationAction._action = NavigationAction.ResetAccumulated;
		menuNavigationAction.InitializeAction(owningGroup, timestamp);
		menuNavigationAction.OnActionBegin(timestamp);
		return menuNavigationAction;
	}

	public static MenuNavigationAction CreateActivateSelected(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		MenuNavigationAction menuNavigationAction = scope.Get<MenuNavigationAction>();
		menuNavigationAction._action = NavigationAction.ActivateSelected;
		menuNavigationAction.InitializeAction(owningGroup, timestamp);
		menuNavigationAction.OnActionBegin(timestamp);
		return menuNavigationAction;
	}

	public static MenuNavigationAction CreateBackSelected(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		MenuNavigationAction menuNavigationAction = scope.Get<MenuNavigationAction>();
		menuNavigationAction._action = NavigationAction.BackSelected;
		menuNavigationAction.InitializeAction(owningGroup, timestamp);
		menuNavigationAction.OnActionBegin(timestamp);
		return menuNavigationAction;
	}

	public static MenuNavigationAction CreateChangePageSelected(PlayerActionGroup owningGroup, IScope scope, float timestamp, Vector2 direction)
	{
		MenuNavigationAction menuNavigationAction = scope.Get<MenuNavigationAction>();
		menuNavigationAction._action = NavigationAction.PageSelected;
		menuNavigationAction._direction = direction;
		menuNavigationAction.InitializeAction(owningGroup, timestamp);
		menuNavigationAction.OnActionBegin(timestamp);
		return menuNavigationAction;
	}
}
