using System.Collections.Generic;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.States
{
	public class LoadLevelState : IPayloadedState<string>, IExitableState
	{
		private readonly GameStateMachine _stateMachine;

		private readonly SceneLoader _sceneLoader;

		private readonly LoadingCurtain _loadingCurtain;

		private readonly IGameFactory _gameFactory;

		private readonly IPersistentProgressService _persistentProgressService;

		private readonly List<string> sceneFromCreativeMode = new List<string>
		{
			"Level_0_CreativeMode", "Level_1_CreativeMode", "Level_2_CreativeMode", "Level_3_CreativeMode", "Level_4_CreativeMode", "Level_5_CreativeMode", "Level_6_CreativeMode", "Level_7_CreativeMode", "Level_8_CreativeMode", "Level_9_CreativeMode",
			"Level_10_CreativeMode"
		};

		public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistentProgressService persistentProgressService)
		{
			_stateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
			_loadingCurtain = loadingCurtain;
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
		}

		public void Enter(string sceneName)
		{
			_loadingCurtain.Show(sceneName);
			_gameFactory.Cleanup();
			_persistentProgressService.Progress.CreativeMode = sceneFromCreativeMode.Contains(sceneName);
			_sceneLoader.Load(sceneName, OnLoaded);
		}

		public void Exit()
		{
			_loadingCurtain.Hide();
		}

		public void Enter()
		{
		}

		private void OnLoaded()
		{
			_gameFactory.WarmUp();
			InformProgressReaders();
			_stateMachine.Enter<GameLoopState>();
		}

		private void InformProgressReaders()
		{
			foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
			{
				progressReader.LoadProgress(_persistentProgressService.Progress);
			}
		}
	}
}
