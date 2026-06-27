using Restory.Data.Locations;

namespace Restory.Infrastructure.StateMachine.States.InitializationStates
{
	public struct ScenesTransitionArguments
	{
		public GameScenesPreset ScenesPreset;

		public LoadingScreenTypes LoadingScreen;
	}
}
