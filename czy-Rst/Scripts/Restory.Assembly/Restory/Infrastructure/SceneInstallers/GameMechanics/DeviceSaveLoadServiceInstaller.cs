using Restory.Gameplay.Devices;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DeviceSaveLoadServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private DeviceSaveLoadService deviceSaveLoadServicePrefab;

		public override void InstallBindings()
		{
			InstallDeviceSaveLoadService();
			InstallDeviceRegistry();
		}

		private void InstallDeviceSaveLoadService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(deviceSaveLoadServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DeviceSaveLoadService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallDeviceRegistry()
		{
			base.Container.BindInterfacesAndSelfTo<DeviceRegistry>().FromNew().AsSingle();
		}
	}
}
