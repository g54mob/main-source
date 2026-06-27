using Restory.Data.GameView;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.TextureMasks;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DeviceFactory
	{
		private readonly DiContainer diContainer;

		private readonly IDService idService;

		private readonly DevicePackagePools packagePools;

		private readonly TextureCacheService textureCacheService;

		[Inject]
		private DeviceFactory(DiContainer diContainer, IDService idService, DevicePackagePools packagePools, TextureCacheService textureCacheService)
		{
			this.diContainer = diContainer;
			this.idService = idService;
			this.packagePools = packagePools;
			this.textureCacheService = textureCacheService;
		}

		public DeviceContainer CreateDeviceContainer(DeviceData deviceData, Transform spawnPoint)
		{
			DeviceContainer deviceContainer = diContainer.InstantiatePrefabForComponent<DeviceContainer>(deviceData.DeviceInfo.Prefab.gameObject, spawnPoint);
			deviceContainer.transform.position = deviceData.DeviceTransform.Position;
			deviceContainer.transform.rotation = deviceData.DeviceTransform.Rotation;
			deviceData.UniqueID = (string.IsNullOrEmpty(deviceData.UniqueID) ? idService.GenerateNew() : deviceData.UniqueID);
			deviceContainer.Init(deviceData);
			deviceContainer.IsInteractable = true;
			return deviceContainer;
		}

		public void DestroyDeviceContainer(DeviceContainer deviceContainer)
		{
			if (deviceContainer.Package is IDevicePackage devicePackage)
			{
				deviceContainer.RemovePackage();
				DestroyDevicePackage(devicePackage, deviceContainer.DevicePreset);
			}
			foreach (ElementSocket elementSocket in deviceContainer.Device.ElementSockets)
			{
				if ((bool)elementSocket.NestedElement)
				{
					ElementData elementData = elementSocket.NestedElement.ConditionHandler.ElementData;
					if (elementData.DirtMaskTextureId > 0)
					{
						textureCacheService.RemoveTextureData(elementData.DirtMaskTextureId);
					}
				}
			}
			if (deviceContainer.Device.TryGetComponent<PaintableDevice>(out var component) && component.PaintTextureId > 0)
			{
				textureCacheService.RemoveTextureData(component.PaintTextureId);
				component.ClearPaintTextureId();
			}
			Object.Destroy(deviceContainer.gameObject);
		}

		public DismantledDevicePack CreateDismantledDevicePack(DeviceContainer deviceContainer)
		{
			return packagePools.GetDismantledDevicePackage(deviceContainer);
		}

		public UnlicensedDevicePackage CreateUnlicensedDevicePack(DeviceContainer deviceContainer)
		{
			return packagePools.GetUnlicensedDevicePackage(deviceContainer);
		}

		public LicensedDevicePackage CreateLicensedDevicePack(DeviceContainer deviceContainer)
		{
			return packagePools.GetLicensedDevicePackage(deviceContainer);
		}

		public ShipmentDevicePack CreateCompletedOrderDevicePack(DeviceContainer deviceContainer)
		{
			return packagePools.GetShipmentDevicePackage(deviceContainer);
		}

		public CompetitionDevicePack CreateCompetitionDevicePack(DeviceContainer deviceContainer)
		{
			return packagePools.GetCompetitionDevicePackage(deviceContainer);
		}

		public void DestroyPackedDeviceContainer(DevicePack devicePack)
		{
			DeviceContainer deviceContainer = DestroyDevicePack(devicePack, devicePack.transform.parent);
			DestroyDeviceContainer(deviceContainer);
		}

		public DeviceContainer DestroyDevicePack(DevicePack devicePack, Transform spawnPoint)
		{
			DeviceContainer deviceContainer = devicePack.DeviceContainer;
			GameViewPreset devicePreset = deviceContainer.DevicePreset;
			deviceContainer.transform.SetParent(spawnPoint);
			devicePack.Clear();
			packagePools.Release(devicePack, devicePreset);
			return deviceContainer;
		}

		public void DestroyDevicePackage(IDevicePackage devicePackage, GameViewPreset devicePreset)
		{
			packagePools.Release(devicePackage, devicePreset);
		}
	}
}
