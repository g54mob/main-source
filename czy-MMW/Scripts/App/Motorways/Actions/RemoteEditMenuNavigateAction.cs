using Factory;

namespace Motorways.Actions
{
	public class RemoteEditMenuNavigateAction : EditMenuNavigateAction
	{
		public static RemoteEditMenuNavigateAction Create(PlayerActionGroup playerActionGroup, IScope scope, float timestamp)
		{
			RemoteEditMenuNavigateAction remoteEditMenuNavigateAction = scope.Get<RemoteEditMenuNavigateAction>();
			remoteEditMenuNavigateAction.InitializeAction(playerActionGroup, timestamp);
			remoteEditMenuNavigateAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Remote, 2, InputEventButtonState.DoubleTapDown), ObserverGreediness.BlocksNewActions);
			remoteEditMenuNavigateAction.OnActionBegin(timestamp);
			return remoteEditMenuNavigateAction;
		}
	}
}
