using Restory.Infrastructure.Bootstrap;
using Restory.Infrastructure.ProjectServices;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.TimeSystems;
using Restory.UserInterface;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class BootstrapInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject timeScalingServicePrefab;

		[SerializeField]
		private GUI_FadeScreens fadeScreensPrefab;

		[SerializeField]
		private GameBootstrapper gameBootstrapperPrefab;

		[Header("Scenes loading")]
		[SerializeField]
		private AssetReference loadingSceneRef;

		[SerializeField]
		private AssetReference blackLoadingSceneRef;

		[SerializeField]
		private AssetReference bicycleLoadingSceneRef;

		public override void InstallBindings()
		{
			InstallCoroutineRunner();
			InstallFadeScreens();
			InstallLoadingScreens();
			InstallGlobalGameStateMachine();
			InstallGameInstance();
			InstallTimeScalingService();
			InstallGameBootstrapper();
		}

		private void InstallTimeScalingService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(timeScalingServicePrefab);
			base.Container.Bind<TimeScalingService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallGameBootstrapper()
		{
			GameBootstrapper gameBootstrapper = Object.FindAnyObjectByType<GameBootstrapper>();
			if (gameBootstrapper == null)
			{
				GameObject gameObject = base.Container.InstantiateAndQueueForInject(gameBootstrapperPrefab.gameObject);
				base.Container.Bind<GameBootstrapper>().FromComponentOn(gameObject).AsSingle();
			}
			else
			{
				base.Container.Bind<GameBootstrapper>().FromInstance(gameBootstrapper).AsSingle();
			}
		}

		private void InstallFadeScreens()
		{
			GUI_FadeScreens component = base.Container.InstantiateAndQueueForInject(fadeScreensPrefab.gameObject).GetComponent<GUI_FadeScreens>();
			component.PreInit();
			base.Container.Bind<GUI_FadeScreens>().FromInstance(component).AsSingle();
		}

		private void InstallGameInstance()
		{
			base.Container.Bind<Game>().AsSingle().NonLazy();
		}

		private void InstallGlobalGameStateMachine()
		{
			base.Container.Bind<LoadPresetListHistory>().AsSingle();
			base.Container.BindFactory<GameIntroLogosState, GameIntroLogosState.Factory>();
			base.Container.BindFactory<MainMenuState, MainMenuState.Factory>();
			base.Container.BindFactory<GameIntroState, GameIntroState.Factory>();
			base.Container.BindFactory<GameResultsState, GameResultsState.Factory>();
			base.Container.BindFactory<GameLauncherState, GameLauncherState.Factory>();
			base.Container.BindFactory<GameLoopState, GameLoopState.Factory>();
			base.Container.BindFactory<GamePauseState, GamePauseState.Factory>();
			base.Container.BindFactory<BugReportFormState, BugReportFormState.Factory>();
			base.Container.BindFactory<LoadProgressState, LoadProgressState.Factory>();
			base.Container.BindFactory<FinalSelectionState, FinalSelectionState.Factory>();
			base.Container.BindFactory<LoadPresetListState, LoadPresetListState.Factory>();
			base.Container.BindFactory<InstallServicesState, InstallServicesState.Factory>();
			base.Container.BindFactory<StartLoadingPresetListState, StartLoadingPresetListState.Factory>();
			base.Container.BindFactory<DisposePresetListState, DisposePresetListState.Factory>();
			base.Container.Bind<GlobalStateMachine>().AsSingle();
			base.Container.BindInterfacesAndSelfTo<GlobalStateMachineTimeLogger>().AsSingle();
			base.Container.BindInterfacesAndSelfTo<GlobalStateObserver>().AsSingle().CopyIntoAllSubContainers();
			base.Container.Bind<LoadingScreenLoaderService>().AsSingle();
		}

		private void InstallCoroutineRunner()
		{
			base.Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromNewComponentOnNewGameObject()
				.AsSingle()
				.CopyIntoAllSubContainers();
		}

		private void InstallLoadingScreens()
		{
			base.Container.Bind<AssetReference>().WithId("LoadingSceneId").FromInstance(loadingSceneRef)
				.AsCached();
			base.Container.Bind<AssetReference>().WithId("BlackLoadingSceneId").FromInstance(blackLoadingSceneRef)
				.AsCached();
			base.Container.Bind<AssetReference>().WithId("BicycleLoadingSceneId").FromInstance(bicycleLoadingSceneRef)
				.AsCached();
		}
	}
}
