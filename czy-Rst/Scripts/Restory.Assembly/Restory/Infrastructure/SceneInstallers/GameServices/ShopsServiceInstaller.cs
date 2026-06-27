using Restory.Data.Shops.HomeDepot;
using Restory.Gameplay.Shops;
using Restory.Gameplay.Shops.Devices;
using Restory.Gameplay.Shops.Elements;
using Restory.Gameplay.Shops.HomeDepot;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class ShopsServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject shopsServicePrefab;

		[SerializeField]
		private GameObject homeDepotShopServicePrefab;

		[SerializeField]
		private GameObject elementsShopServicePrefab;

		[SerializeField]
		private DeviceShopSupplier deviceShopSupplierPrefab;

		[SerializeField]
		private GameObject deviceShopRandomDevicesGenerationServicePrefab;

		[SerializeField]
		private GameObject deviceShopRandomElementsBoxesGenerationServicePrefab;

		[FormerlySerializedAs("decorsShopInfo")]
		[SerializeField]
		private HomeDepotShopInfo homeDepotShopInfo;

		public override void InstallBindings()
		{
			InstallShopService();
			InstallElementsShopService();
			InstallDeviceShop();
			InstallDecorShop();
		}

		private void InstallDeviceShop()
		{
			base.Container.BindInterfacesAndSelfTo<DeviceShopInteractor>().AsSingle();
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(deviceShopSupplierPrefab.gameObject);
			base.Container.Bind<DeviceShopSupplier>().FromComponentOn(gameObject).AsSingle();
			GameObject gameObject2 = base.Container.InstantiateAndQueueForInject(deviceShopRandomDevicesGenerationServicePrefab);
			base.Container.Bind<DeviceShopRandomDevicesGenerationService>().FromComponentOn(gameObject2).AsSingle()
				.WhenInjectedInto<DeviceShopSupplier>();
			GameObject gameObject3 = base.Container.InstantiateAndQueueForInject(deviceShopRandomElementsBoxesGenerationServicePrefab);
			base.Container.Bind<DeviceShopRandomElementsBoxesGenerationService>().FromComponentOn(gameObject3).AsSingle()
				.WhenInjectedInto<DeviceShopSupplier>();
			base.Container.Bind<DeviceShopTimedLotsRemovingService>().FromNew().AsSingle();
		}

		private void InstallShopService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(shopsServicePrefab);
			base.Container.Bind<ShopsService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallElementsShopService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(elementsShopServicePrefab);
			base.Container.BindInterfacesAndSelfTo<ElementsShopService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallDecorShop()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(homeDepotShopServicePrefab);
			base.Container.Bind<HomeDepotShopInfo>().FromInstance(homeDepotShopInfo).WhenInjectedInto<HomeDepotShopService>();
			base.Container.BindInterfacesAndSelfTo<HomeDepotShopService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<HomeDepotShopInteractor>().AsSingle();
		}
	}
}
