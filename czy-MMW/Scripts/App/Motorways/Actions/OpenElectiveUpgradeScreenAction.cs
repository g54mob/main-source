using Factory;
using Motorways.Views;

namespace Motorways.Actions
{
	public class OpenElectiveUpgradeScreenAction : MotorwaysPlayerAction
	{
		[Dependency]
		private GameUIScreen _gameUIScreen;

		public static OpenElectiveUpgradeScreenAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			OpenElectiveUpgradeScreenAction openElectiveUpgradeScreenAction = scope.Get<OpenElectiveUpgradeScreenAction>();
			openElectiveUpgradeScreenAction.InitializeAction(owningGroup, timestamp);
			openElectiveUpgradeScreenAction.OnActionBegin(timestamp);
			return openElectiveUpgradeScreenAction;
		}

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			_gameUIScreen.OnElectiveUpgradeButtonPressed();
			OnActionComplete();
		}
	}
}
