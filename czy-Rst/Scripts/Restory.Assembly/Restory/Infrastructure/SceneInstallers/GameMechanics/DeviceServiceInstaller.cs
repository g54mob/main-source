using Restory.Data.Devices;
using Restory.Data.Devices.Quality;
using Restory.Gameplay.Devices;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DeviceServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private DeviceService deviceServicePrefab;

		[SerializeField]
		private DeviceReplacementHandler deviceReplacementHandlerPrefab;

		[SerializeField]
		private DevicePrefabProvider devicePrefabProvider;

		[SerializeField]
		private DeviceQualityDatabase deviceQualityDatabase;

		[SerializeField]
		private RandomDevicesGenerationService randomDevicesGenerationServicePrefab;

		[Space]
		[Header("Device package prefabs")]
		[SerializeField]
		private DismantledDevicePack smallDismantledDevicePackagePrefab;

		[SerializeField]
		private DismantledDevicePack bigDismantledDevicePackagePrefab;

		[SerializeField]
		private UnlicensedDevicePackage smallUnlicensedDevicePackagePrefab;

		[SerializeField]
		private UnlicensedDevicePackage bigUnlicensedDevicePackagePrefab;

		[SerializeField]
		private LicensedDevicePackage smallLicensedDevicePackagePrefab;

		[SerializeField]
		private LicensedDevicePackage bigLicensedDevicePackagePrefab;

		[SerializeField]
		private ShipmentDevicePack shipmentDevicePackagePrefab;

		[SerializeField]
		private CompetitionDevicePack smallCompetitionDevicePackagePrefab;

		[SerializeField]
		private CompetitionDevicePack bigCompetitionDevicePackagePrefab;

		public override void InstallBindings()
		{
			InstallDeviceService();
			InstallDeviceReplacementHandler();
			InstallDeviceFactory();
			InstallDevicePacker();
			InstallPrefabProvider();
			InstallDeviceQualityDatabase();
			InstallRandomDeviceGenerationService();
			InstallDeviceLicensingService();
		}

		private void InstallDeviceService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(deviceServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DeviceService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallDeviceReplacementHandler()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(deviceReplacementHandlerPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DeviceReplacementHandler>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallDeviceFactory()
		{
			base.Container.Bind<SmallDismantledDevicePackPool>().FromNew().AsSingle()
				.WithArguments(smallDismantledDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<BigDismantledDevicePackPool>().FromNew().AsSingle()
				.WithArguments(bigDismantledDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<SmallUnlicensedDevicePackagePool>().FromNew().AsSingle()
				.WithArguments(smallUnlicensedDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<BigUnlicensedDevicePackagePool>().FromNew().AsSingle()
				.WithArguments(bigUnlicensedDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<SmallLicensedDevicePackagePool>().FromNew().AsSingle()
				.WithArguments(smallLicensedDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<BigLicensedDevicePackagePool>().FromNew().AsSingle()
				.WithArguments(bigLicensedDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<ShipmentDevicePackPool>().FromNew().AsSingle()
				.WithArguments(shipmentDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<SmallCompetitionDevicePackPool>().FromNew().AsSingle()
				.WithArguments(smallCompetitionDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<BigCompetitionDevicePackPool>().FromNew().AsSingle()
				.WithArguments(bigCompetitionDevicePackagePrefab.gameObject)
				.WhenInjectedInto<DevicePackagePools>();
			base.Container.Bind<DevicePackagePools>().FromNew().AsSingle()
				.WhenInjectedInto<DeviceFactory>();
			base.Container.Bind<DeviceFactory>().FromNew().AsSingle();
		}

		private void InstallDevicePacker()
		{
			base.Container.BindInterfacesAndSelfTo<DevicePacker>().FromNew().AsSingle();
		}

		private void InstallPrefabProvider()
		{
			base.Container.Bind<DevicePrefabProvider>().FromInstance(Object.Instantiate(devicePrefabProvider)).AsSingle();
		}

		private void InstallDeviceQualityDatabase()
		{
			base.Container.Bind<DeviceQualityDatabase>().FromInstance(Object.Instantiate(deviceQualityDatabase)).AsSingle();
		}

		private void InstallRandomDeviceGenerationService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(randomDevicesGenerationServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<RandomDevicesGenerationService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallDeviceLicensingService()
		{
			base.Container.BindInterfacesAndSelfTo<DeviceLicensingService>().FromNew().AsSingle();
		}
	}
}
