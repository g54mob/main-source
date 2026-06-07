using Factory;
using Motorways.Actions;

public class SwitchGamepadController : GenericGamepadController
{
	public override void RegisterInputActionsForApp(IScope appScope)
	{
		base.RegisterInputActionsForApp(appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(12, InputEventButtonState.JustDown), HandleActivateControllerSelect, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(8, InputEventButtonState.JustDown), menuNavigator.CreateNavigateBack, appScope);
		if (FeatureToggle.IsFeatureEnabled(Feature.CycleLanguages))
		{
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(37, InputEventButtonState.JustDown), SetLanguageAction.CreateCycleForwardSetLanguageAction, appScope);
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(36, InputEventButtonState.JustDown), SetLanguageAction.CreateCycleBackwardSetLanguageAction, appScope);
		}
	}

	public override void RegisterInputActionsForGame(IScope gameScope)
	{
		base.RegisterInputActionsForGame(gameScope);
		if (FeatureToggle.IsFeatureEnabled(Feature.ToggleGameUIWithController))
		{
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(32, InputEventButtonState.JustDown), ToggleGameUIAction.Create, gameScope);
		}
		_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(31, InputEventButtonState.JustDown), ToggleZoomAction.Create, gameScope);
	}

	public virtual PlayerAction HandleActivateControllerSelect(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		ActivateControllerSelectAction activateControllerSelectAction = scope.Get<ActivateControllerSelectAction>();
		activateControllerSelectAction.InitializeAction(playerActionGroup, time);
		activateControllerSelectAction.OnActionBegin(time);
		return activateControllerSelectAction;
	}
}
