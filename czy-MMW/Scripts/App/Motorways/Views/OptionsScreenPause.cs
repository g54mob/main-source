using Factory;

namespace Motorways.Views
{
	public class OptionsScreenPause : OptionsScreenBase
	{
		[Dependency]
		protected PlayerActionController _playerActionController;

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			_appScope.Get<InputState>().BlockGameInput = true;
			_playerActionController.CancelAllActions();
		}
	}
}
