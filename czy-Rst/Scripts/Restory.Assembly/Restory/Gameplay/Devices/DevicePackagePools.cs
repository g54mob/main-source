using System;
using Restory.Data.Devices;
using Restory.Data.GameView;
using Restory.ObjectPools;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DevicePackagePools
	{
		private readonly DevicePrefabProvider prefabProvider;

		private readonly SmallDismantledDevicePackPool smallDismantledDevicePackPool;

		private readonly BigDismantledDevicePackPool bigDismantledDevicePackPool;

		private readonly SmallUnlicensedDevicePackagePool smallUnlicensedDevicePackagePool;

		private readonly BigUnlicensedDevicePackagePool bigUnlicensedDevicePackagePool;

		private readonly SmallLicensedDevicePackagePool smallLicensedDevicePackagePool;

		private readonly BigLicensedDevicePackagePool bigLicensedDevicePackagePool;

		private readonly SmallCompetitionDevicePackPool smallCompetitionDevicePackPool;

		private readonly BigCompetitionDevicePackPool bigCompetitionDevicePackPool;

		private readonly ShipmentDevicePackPool shipmentDevicePackPool;

		[Inject]
		private DevicePackagePools(DevicePrefabProvider prefabProvider, SmallDismantledDevicePackPool smallDismantledDevicePackPool, BigDismantledDevicePackPool bigDismantledDevicePackPool, SmallUnlicensedDevicePackagePool smallUnlicensedDevicePackagePool, BigUnlicensedDevicePackagePool bigUnlicensedDevicePackagePool, SmallLicensedDevicePackagePool smallLicensedDevicePackagePool, BigLicensedDevicePackagePool bigLicensedDevicePackagePool, ShipmentDevicePackPool shipmentDevicePackPool, BigCompetitionDevicePackPool bigCompetitionDevicePackPool, SmallCompetitionDevicePackPool smallCompetitionDevicePackPool)
		{
			this.prefabProvider = prefabProvider;
			this.smallDismantledDevicePackPool = smallDismantledDevicePackPool;
			this.bigDismantledDevicePackPool = bigDismantledDevicePackPool;
			this.smallUnlicensedDevicePackagePool = smallUnlicensedDevicePackagePool;
			this.bigUnlicensedDevicePackagePool = bigUnlicensedDevicePackagePool;
			this.smallLicensedDevicePackagePool = smallLicensedDevicePackagePool;
			this.bigLicensedDevicePackagePool = bigLicensedDevicePackagePool;
			this.shipmentDevicePackPool = shipmentDevicePackPool;
			this.bigCompetitionDevicePackPool = bigCompetitionDevicePackPool;
			this.smallCompetitionDevicePackPool = smallCompetitionDevicePackPool;
		}

		public DismantledDevicePack GetDismantledDevicePackage(DeviceContainer deviceContainer)
		{
			return GetDismantledDevicePackagePool(deviceContainer.DevicePreset).Get<DismantledDevicePack>(deviceContainer.transform.parent);
		}

		public UnlicensedDevicePackage GetUnlicensedDevicePackage(DeviceContainer deviceContainer)
		{
			return GetUnlicensedDevicePackagePool(deviceContainer.DevicePreset).Get<UnlicensedDevicePackage>(deviceContainer.transform);
		}

		public LicensedDevicePackage GetLicensedDevicePackage(DeviceContainer deviceContainer)
		{
			return GetLicensedDevicePackagePool(deviceContainer.DevicePreset).Get<LicensedDevicePackage>(deviceContainer.transform);
		}

		public ShipmentDevicePack GetShipmentDevicePackage(DeviceContainer deviceContainer)
		{
			return GetShipmentDevicePackagePool().Get<ShipmentDevicePack>(deviceContainer.transform.parent);
		}

		public CompetitionDevicePack GetCompetitionDevicePackage(DeviceContainer deviceContainer)
		{
			return GetCompetitionDevicePackagePool(deviceContainer.DevicePreset).Get<CompetitionDevicePack>(deviceContainer.transform.parent);
		}

		public void Release(IDevicePackage package, GameViewPreset preset)
		{
			if (!(package is DismantledDevicePack instance))
			{
				if (!(package is UnlicensedDevicePackage instance2))
				{
					if (!(package is LicensedDevicePackage instance3))
					{
						if (!(package is ShipmentDevicePack instance4))
						{
							if (!(package is CompetitionDevicePack instance5))
							{
								throw new NotImplementedException();
							}
							GetCompetitionDevicePackagePool(preset).Release(instance5);
						}
						else
						{
							GetShipmentDevicePackagePool().Release(instance4);
						}
					}
					else
					{
						GetLicensedDevicePackagePool(preset).Release(instance3);
					}
				}
				else
				{
					GetUnlicensedDevicePackagePool(preset).Release(instance2);
				}
			}
			else
			{
				GetDismantledDevicePackagePool(preset).Release(instance);
			}
		}

		private ConcreteGameObjectPool GetDismantledDevicePackagePool(GameViewPreset devicePreset)
		{
			if (!prefabProvider.IsSmallDevice(devicePreset))
			{
				return bigDismantledDevicePackPool;
			}
			return smallDismantledDevicePackPool;
		}

		private ConcreteGameObjectPool GetUnlicensedDevicePackagePool(GameViewPreset devicePreset)
		{
			if (!prefabProvider.IsSmallDevice(devicePreset))
			{
				return bigUnlicensedDevicePackagePool;
			}
			return smallUnlicensedDevicePackagePool;
		}

		private ConcreteGameObjectPool GetLicensedDevicePackagePool(GameViewPreset devicePreset)
		{
			if (!prefabProvider.IsSmallDevice(devicePreset))
			{
				return bigLicensedDevicePackagePool;
			}
			return smallLicensedDevicePackagePool;
		}

		private ConcreteGameObjectPool GetCompetitionDevicePackagePool(GameViewPreset devicePreset)
		{
			if (!prefabProvider.IsSmallDevice(devicePreset))
			{
				return bigCompetitionDevicePackPool;
			}
			return smallCompetitionDevicePackPool;
		}

		private ConcreteGameObjectPool GetShipmentDevicePackagePool()
		{
			return shipmentDevicePackPool;
		}
	}
}
