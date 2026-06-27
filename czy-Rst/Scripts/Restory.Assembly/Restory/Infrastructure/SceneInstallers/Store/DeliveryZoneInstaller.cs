using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Storages;
using Restory.Gameplay.Tips;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.Store
{
	public class DeliveryZoneInstaller : MonoInstaller
	{
		[SerializeField]
		private ShipmentTrigger shipmentTrigger;

		[SerializeField]
		private DevicesFromNpcsSpawnPoints devicesFromNpcsSpawnPoints;

		[SerializeField]
		private DeliveryZoneBoxesSpawnPoints deliveryZoneBoxesSpawnPoints;

		[SerializeField]
		private MoneyFromNpcReceivingSpace moneyFromNpcReceivingSpace;

		[SerializeField]
		private DevicesStoragesRegistry devicesStoragesRegistry;

		[SerializeField]
		private PackageStacker packageStacker;

		[SerializeField]
		private TipBox tipBox;

		public override void InstallBindings()
		{
			InstallShipmentTrigger();
			InstallDeliveryZoneSpawnPoints();
			InstallMoneyFromNpcReceivingSpace();
			InstallDevicesStoragesRegistry();
			InstallPackageStacker();
			InstallTipBox();
		}

		private void InstallShipmentTrigger()
		{
			base.Container.Bind<ShipmentTrigger>().FromInstance(shipmentTrigger).AsSingle();
		}

		private void InstallDeliveryZoneSpawnPoints()
		{
			base.Container.Bind<DevicesFromNpcsSpawnPoints>().FromInstance(devicesFromNpcsSpawnPoints).AsSingle();
			base.Container.Bind<DeliveryZoneBoxesSpawnPoints>().FromInstance(deliveryZoneBoxesSpawnPoints).AsSingle();
		}

		private void InstallMoneyFromNpcReceivingSpace()
		{
			base.Container.Bind<MoneyFromNpcReceivingSpace>().FromInstance(moneyFromNpcReceivingSpace).AsSingle();
		}

		private void InstallDevicesStoragesRegistry()
		{
			base.Container.Bind<DevicesStoragesRegistry>().FromInstance(devicesStoragesRegistry).AsSingle();
		}

		private void InstallPackageStacker()
		{
			base.Container.BindInterfacesAndSelfTo<PackageStacker>().FromInstance(packageStacker).AsSingle();
		}

		private void InstallTipBox()
		{
			base.Container.Bind<TipBox>().FromInstance(tipBox).AsSingle();
		}
	}
}
