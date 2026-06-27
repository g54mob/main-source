using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public sealed class AvailableDevicesListTrackingServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private AvailableDevicesListTrackingService prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<AvailableDevicesListTrackingService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
