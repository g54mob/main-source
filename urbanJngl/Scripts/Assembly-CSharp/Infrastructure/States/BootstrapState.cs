using CodeBase.Infrastructure;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.States;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.BoxService;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.LocalizationService;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Tasks_for_levels;

namespace Infrastructure.States
{
	public class BootstrapState : IState, IExitableState
	{
		private const string Initial = "Initial";

		private readonly GameStateMachine _stateMachine;

		private readonly SceneLoader _sceneLoader;

		private readonly AllServices _services;

		public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
			_services = services;
			RegisterServices();
			StartLocalization();
		}

		public void Enter()
		{
			_sceneLoader.Load("Initial", EnterLoadLevel);
		}

		public void Exit()
		{
		}

		private void RegisterServices()
		{
			_services.RegisterSingle((IGameStateMachine)_stateMachine);
			_services.RegisterSingle((IPersistentProgressService)new PersistentProgressService());
			_services.RegisterSingle(new Loader(_stateMachine, _services.Single<IPersistentProgressService>()));
			_services.RegisterSingle((ITaskService)new TaskService(_services.Single<IPersistentProgressService>()));
			_services.RegisterSingle((IBoxService)new BoxService());
			_services.RegisterSingle((ICoinService)new CoinService(_services.Single<IPersistentProgressService>()));
			RegisterAssetProvider();
			_services.RegisterSingle((IGameFactory)new GameFactory(_services.Single<IAssetProvider>(), _services.Single<IGameStateMachine>(), _services.Single<IPersistentProgressService>()));
			_services.RegisterSingle((ISaveLoadService)new SaveLoadService(_services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
		}

		private void RegisterAssetProvider()
		{
			new AssetProvider().Initialize();
		}

		private void EnterLoadLevel()
		{
			_stateMachine.Enter<LoadProgressState, bool>(payload: false);
		}

		private void StartLocalization()
		{
			LocalizationManager.Read();
		}
	}
}
