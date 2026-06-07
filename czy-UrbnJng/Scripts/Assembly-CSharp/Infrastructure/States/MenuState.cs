using System;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using Infrastructure.Services;

namespace Infrastructure.States
{
	public class MenuState : IState, IExitableState
	{
		private readonly GameStateMachine _stateMachine;

		private readonly SceneLoader _sceneLoader;

		private readonly AllServices _services;

		private readonly LoadingCurtain _loadingCurtain;

		public MenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AllServices services)
		{
			_stateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
			_loadingCurtain = loadingCurtain;
			_services = services;
		}

		public void Exit()
		{
		}

		public void Enter()
		{
			_sceneLoader.Load("Menu", ButtonsActivate);
			_loadingCurtain.Hide();
		}

		private void ButtonsActivate()
		{
			StartMenuUI instance = StartMenuUI.Instance;
			instance.OnResumeButton = (Action)Delegate.Combine(instance.OnResumeButton, new Action(Resume));
			StartMenuUI instance2 = StartMenuUI.Instance;
			instance2.OnNewGAmeButton = (Action)Delegate.Combine(instance2.OnNewGAmeButton, new Action(NewGame));
			StartMenuUI instance3 = StartMenuUI.Instance;
			instance3.OnQuitButton = (Action)Delegate.Combine(instance3.OnQuitButton, new Action(ExitGame));
		}

		public void Resume()
		{
			_stateMachine.Enter<LoadProgressState, bool>(payload: false);
		}

		public void NewGame()
		{
			_stateMachine.Enter<LoadProgressState, bool>(payload: true);
		}

		public void ExitGame()
		{
		}
	}
}
