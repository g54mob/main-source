using Restory.AssetManagement;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class GameEntitiesInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject gameEntityDataBaseProviderPrefab;

		public override void InstallBindings()
		{
			BindEntityDataBase();
		}

		private void BindEntityDataBase()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(gameEntityDataBaseProviderPrefab);
			base.Container.BindInterfacesAndSelfTo<GameEntityDataBaseProvider>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
