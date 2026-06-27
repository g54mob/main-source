using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public sealed class AvailableDevicesWorkTypesTrackingServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private AvailableDevicesWorkTypesTrackingService prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<AvailableDevicesWorkTypesTrackingService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
