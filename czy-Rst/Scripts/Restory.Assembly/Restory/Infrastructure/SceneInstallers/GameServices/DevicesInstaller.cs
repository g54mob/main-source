using Restory.Data.Devices;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public sealed class DevicesInstaller : MonoInstaller
	{
		[SerializeField]
		private DeviceInfoDatabase deviceDatabase;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<DeviceInfoDatabase>().FromInstance(deviceDatabase).AsSingle();
		}
	}
}
