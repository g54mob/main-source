using Restory.Gameplay.Shipment;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class ShipmentServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private DecorShippingService decorShippingServicePrefab;

		[SerializeField]
		private DragShipmentPackCustomPool dragShipmentPackCustomPoolPrefab;

		[SerializeField]
		private DecorShipmentPack decorPackPrefab;

		public override void InstallBindings()
		{
			InstallShipmentService();
			InstallDecorShippingService();
			InstallShipmentPackFactory();
			InstallDecorPacker();
		}

		private void InstallShipmentService()
		{
			base.Container.BindInterfacesAndSelfTo<ShipmentService>().FromNew().AsSingle();
		}

		private void InstallDecorShippingService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(decorShippingServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DecorShippingService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallShipmentPackFactory()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(dragShipmentPackCustomPoolPrefab.gameObject);
			base.Container.Bind<DragShipmentPackCustomPool>().FromComponentOn(gameObject).AsSingle()
				.WhenInjectedInto<ShipmentPackFactory>();
			base.Container.Bind<DecorShipmentPackPool>().FromNew().AsSingle()
				.WithArguments(decorPackPrefab.gameObject)
				.WhenInjectedInto<ShipmentPackFactory>();
			base.Container.Bind<ShipmentPackFactory>().FromNew().AsSingle();
		}

		private void InstallDecorPacker()
		{
			base.Container.Bind<DecorPacker>().FromNew().AsSingle();
		}
	}
}
