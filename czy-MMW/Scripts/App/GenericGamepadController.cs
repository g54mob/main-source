using Factory;
using Motorways;
using Motorways.Actions;
using Motorways.Views;

public class GenericGamepadController : BaseController, IGamepadController, IController
{
	[Dependency]
	protected MotorwaysInGameStateToggleController menuNavigator;

	public override string DeviceName => "Gamepad";

	public override void RegisterInputActionsForApp(IScope appScope)
	{
		base.RegisterInputActionsForApp(appScope);
		if (FeatureToggle.IsFeatureEnabled(Feature.MockControllerAsRemote))
		{
			_inputState.IgnorePollingAxis(0);
			_inputState.IgnorePollingAxis(1);
		}
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(6, InputEventButtonState.JustDown), menuNavigator.CreateNavigateLeftAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(4, InputEventButtonState.JustDown), menuNavigator.CreateNavigateRightAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(5, InputEventButtonState.JustDown), menuNavigator.CreateNavigateDownAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(3, InputEventButtonState.JustDown), menuNavigator.CreateNavigateUpAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(2, InputEventButtonState.JustDown), menuNavigator.CreateNavigateAccept, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(7, InputEventButtonState.JustDown), menuNavigator.CreateNavigateBack, appScope);
		_inputState.EnsurePollingAxis(0);
		_inputState.EnsurePollingAxis(1);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(0, InputEventButtonState.JustDown), (PlayerActionGroup playerActionGroup, IScope scope, float time) => menuNavigator.CreateNavigateInDirection(0, 1, playerActionGroup, scope, time), appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(1, InputEventButtonState.JustDown), (PlayerActionGroup playerActionGroup, IScope scope, float time) => menuNavigator.CreateNavigateInDirection(0, 1, playerActionGroup, scope, time), appScope);
		if (FeatureToggle.IsFeatureEnabled(Feature.CycleLanguages))
		{
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(37, InputEventButtonState.JustDown), SetLanguageAction.CreateCycleForwardSetLanguageAction, appScope);
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(36, InputEventButtonState.JustDown), SetLanguageAction.CreateCycleBackwardSetLanguageAction, appScope);
		}
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(42, InputEventButtonState.JustDown), menuNavigator.CreateNavigatePageLeft, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(43, InputEventButtonState.JustDown), menuNavigator.CreateNavigatePageRight, appScope);
	}

	public override void RegisterInputActionsForGame(IScope gameScope)
	{
		base.RegisterInputActionsForGame(gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(16, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateToggleSpeed, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(11, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateSlowDown, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(10, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateSpeedUp, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(9, InputEventButtonState.JustDown), ToggleDrawModeAction.Create, gameScope);
		if (FeatureToggle.IsFeatureEnabled(Feature.ToggleGameUIWithController))
		{
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(32, InputEventButtonState.JustDown), ToggleGameUIAction.Create, gameScope);
		}
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(31, InputEventButtonState.JustDown), ToggleZoomAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(34, InputEventButtonState.Axis), ControllerCameraAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(33, InputEventButtonState.Axis), ControllerCameraAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(2, InputEventButtonState.JustDown), HandleActivateSelected, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(2, InputEventButtonState.JustDown), ToggleCreativeModeEditMenuAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(0, InputEventButtonState.Axis), MoveInGameFocusAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(1, InputEventButtonState.Axis), MoveInGameFocusAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(21, InputEventButtonState.JustDown), ChangeUpgradeBarAction.CreateShowOrLockUpgradeBar, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(22, InputEventButtonState.JustDown), ChangeUpgradeBarAction.CreateHideUpgradeBar, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(18, InputEventButtonState.JustDown), DragClearTileAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.Motorway, InputEventButtonState.JustDown), ControllerDragMotorwayAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.TrafficLight, InputEventButtonState.JustDown), ControllerDragTrafficLightAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.Roundabout, InputEventButtonState.JustDown), ControllerDragRoundaboutAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.MotorwayHandle, InputEventButtonState.JustDown), ControllerDragMotorwayHandleAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.House, InputEventButtonState.JustDown), ControllerDragHouseAction.CreateFromUpgradeMenu, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.Destination, InputEventButtonState.JustDown), (PlayerActionGroup owningGroup, IScope scope, float timestamp) => ControllerDragDestinationAction.CreateSingleFromUpgradeMenu(owningGroup, scope, timestamp), gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.DoubleDestination, InputEventButtonState.JustDown), (PlayerActionGroup owningGroup, IScope scope, float timestamp) => ControllerDragDestinationAction.CreateDoubleFromUpgradeMenu(owningGroup, scope, timestamp), gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.EditMenuOpened, InputEventButtonState.JustDown), ControllerEditMenuNavigateAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateGenericUIEventFilter(2, GameUIButtonType.MoveCreativeModeObject, InputEventButtonState.JustDown), DragCreativeModeEditableObjectAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(44, InputEventButtonState.JustDown), OpenElectiveUpgradeScreenAction.Create, gameScope);
	}

	public virtual PlayerAction HandleActivateSelected(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		if (!_playerActionController.TutorialBlockInputFlag && menuNavigator.ControllerState == MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles)
		{
			GameUIScreen gameUIScreen = scope.Get<GameUIScreen>();
			TilemapView tilemapView = scope.Get<TilemapView>();
			if (gameUIScreen != null)
			{
				if (gameUIScreen.FocussedSelectable != null)
				{
					return PressUIFocusAction.Create(playerActionGroup, scope, time, this);
				}
				if (gameUIScreen.CurrentRoadDrawMode == RoadDrawMode.Add)
				{
					Tile tile = tilemapView.GetTile(tilemapView.GetTileCoordinatesFromScreenPosition(gameUIScreen.FocusPointPosition));
					if (tile != null)
					{
						TileDirectionBitfield motorwayRamps = tile.GetMotorwayRamps(RoadState.Planned | RoadState.Active);
						if (motorwayRamps.Count > 0 || tile.UnbuiltMotorwayId != -1)
						{
							TileDirectionBitfield.Enumerator enumerator = motorwayRamps.GetEnumerator();
							while (enumerator.MoveNext())
							{
								TileDirection current = enumerator.Current;
								if (!tilemapView.GetMotorway(tile.GetMotorwayInDirection(current, RoadState.Planned | RoadState.Active)).IsPermanent)
								{
									return ControllerDragEditMotorwayAction.Create(playerActionGroup, scope, time);
								}
							}
						}
					}
					return ControllerDrawRoadAction(playerActionGroup, scope, time);
				}
				return ControllerDeleteRoadAction(playerActionGroup, scope, time);
			}
		}
		return menuNavigator.CreateNavigateAccept(playerActionGroup, scope, time);
	}

	protected virtual MotorwaysPlayerAction ControllerDrawRoadAction(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		return DrawRoadAction.Create(owningGroup, scope, timestamp);
	}

	protected virtual MotorwaysPlayerAction ControllerDeleteRoadAction(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		return DragClearTileAction.Create(owningGroup, scope, timestamp);
	}
}
