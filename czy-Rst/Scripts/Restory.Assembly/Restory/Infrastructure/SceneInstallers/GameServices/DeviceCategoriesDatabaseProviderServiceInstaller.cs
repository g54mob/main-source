using Restory.Data.Devices;
using Restory.Gameplay.Devices;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class DeviceCategoriesDatabaseProviderServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private DeviceCategoriesDatabase database;

		public override void InstallBindings()
		{
			DeviceCategoriesDatabaseProviderService instance = new DeviceCategoriesDatabaseProviderService(database);
			base.Container.Bind<DeviceCategoriesDatabaseProviderService>().FromInstance(instance).AsSingle();
		}
	}
}
