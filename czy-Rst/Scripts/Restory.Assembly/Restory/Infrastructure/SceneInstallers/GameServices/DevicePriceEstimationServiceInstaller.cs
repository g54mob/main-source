using Restory.Data.Devices;
using Restory.Gameplay.Devices;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class DevicePriceEstimationServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private DevicePriceEstimationSettings devicePriceEstimationSettings;

		public override void InstallBindings()
		{
			InstallDevicePriceEstimationService();
		}

		private void InstallDevicePriceEstimationService()
		{
			base.Container.BindInterfacesAndSelfTo<DevicePriceEstimationService>().AsSingle().WithArguments(devicePriceEstimationSettings);
		}
	}
}
