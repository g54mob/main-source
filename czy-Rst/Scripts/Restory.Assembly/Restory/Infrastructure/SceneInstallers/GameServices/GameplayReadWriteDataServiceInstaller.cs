using Restory.Data.GameConfigs;
using Restory.Data.ReadWriteServices;
using Restory.Data.ReadWriteServices.Interfaces;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class GameplayReadWriteDataServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject gameplayWriteReadServicePrefab;

		private GameConfig gameConfig;

		[Inject]
		private void Construct(GameConfig gameConfig)
		{
			this.gameConfig = gameConfig;
		}

		public override void InstallBindings()
		{
			InstallSaveSystem();
		}

		private void InstallSaveSystem()
		{
			if (gameConfig.SaveSystemSupportedPlatforms.GetSupportedStatus())
			{
				GameObject gameObject = base.Container.InstantiateAndQueueForInject(gameplayWriteReadServicePrefab);
				base.Container.BindInterfacesAndSelfTo<GameplayReadWriteCombinedDataService>().FromComponentOn(gameObject).AsSingle();
			}
			else
			{
				base.Container.Bind<IGameplayReadWriteDataService>().To<StubReadWriteDataService>().FromNewComponentOnNewGameObject()
					.AsSingle();
			}
		}
	}
}
