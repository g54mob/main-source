using Infrastructure.Services.SaveLoad;
using Infrastructure.States;

namespace CodeBase.Infrastructure.States
{
	public class GameLoopState : IState, IExitableState
	{
		private readonly ISaveLoadService _saveLoadService;

		public GameLoopState(GameStateMachine stateMachine, ISaveLoadService saveLoadService)
		{
			_saveLoadService = saveLoadService;
		}

		public void Exit()
		{
		}

		public void Enter()
		{
			_saveLoadService.SaveProgress();
		}
	}
}
