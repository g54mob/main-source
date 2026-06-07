using Factory;
using Motorways;
using Server;

namespace Screens
{
	public class InGameScalingScreen : BaseScalingScreen
	{
		[Dependency]
		protected PlayerActionController _playerActionController;

		protected IScope _gameScope;

		protected MotorwaysGame _game;

		protected ISimulation _simulation;

		protected bool _blocksGameInput;

		protected virtual MapDefinition GetMapDefinition()
		{
			return _game.MapDefinition;
		}

		public virtual void InitScreen(IScope gameScope, bool blocksGameInput)
		{
			_gameScope = gameScope;
			_game = _gameScope.Get<Game>() as MotorwaysGame;
			_simulation = _gameScope.Get<ISimulation>();
			_blocksGameInput = blocksGameInput;
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			_appScope.Get<InputState>().BlockGameInput = _blocksGameInput;
			if (_blocksGameInput)
			{
				_playerActionController.CancelAllActions();
			}
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			base.TransitionIn(outScreen);
			_game.SetPaused(isPaused: true);
		}

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			if (_canvas != null && base.gameObject.layer == _gameCamera.OverlayLayerIndex)
			{
				_gameCamera.AttachCameraToCanvas(_canvas, CameraLayer.Overlay);
			}
		}

		public override void Reset()
		{
			base.Reset();
			_blocksGameInput = false;
		}
	}
}
