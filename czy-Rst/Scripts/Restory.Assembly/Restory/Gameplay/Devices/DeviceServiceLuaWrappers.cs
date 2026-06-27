using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.Devices.Condition;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Storages;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DeviceServiceLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string CreateDevice = "Devices_CreateDevice";

			public static readonly string CreateUniqueDevice = "Devices_CreateUniqueDevice";

			public static readonly string DoesUniqueDeviceExist = "Devices_DoesUniqueDeviceExist";

			public static readonly string DestroyUniqueDevice = "Devices_DestroyUniqueDevice";

			public static readonly string TurnUniqueDeviceIntoRegularDevice = "Devices_MakeUniqueDeviceNonUnique";
		}

		private readonly DeviceService deviceService;

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		private readonly DevicesFromNpcsService devicesFromNpcsService;

		public DeviceServiceLuaWrappers(DeviceService deviceService, DevicesFromNpcsService devicesFromNpcsService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
			this.deviceService = deviceService;
			this.devicesFromNpcsService = devicesFromNpcsService;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.CreateDevice, this, SymbolExtensions.GetMethodInfo(() => CreateDevice(string.Empty)));
			Lua.RegisterFunction(LuaNames.CreateUniqueDevice, this, SymbolExtensions.GetMethodInfo(() => CreateUniqueDevice(string.Empty)));
			Lua.RegisterFunction(LuaNames.DoesUniqueDeviceExist, this, SymbolExtensions.GetMethodInfo(() => DoesUniqueDeviceExist(string.Empty)));
			Lua.RegisterFunction(LuaNames.DestroyUniqueDevice, this, SymbolExtensions.GetMethodInfo(() => DestroyUniqueDevice(string.Empty)));
			Lua.RegisterFunction(LuaNames.TurnUniqueDeviceIntoRegularDevice, this, SymbolExtensions.GetMethodInfo(() => TurnUniqueDeviceIntoRegularDevice(string.Empty)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.CreateDevice);
			Lua.UnregisterFunction(LuaNames.CreateUniqueDevice);
			Lua.UnregisterFunction(LuaNames.DestroyUniqueDevice);
			Lua.UnregisterFunction(LuaNames.TurnUniqueDeviceIntoRegularDevice);
		}

		private void CreateDevice(string deviceConditionID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo))
			{
				SpawnDevice(entityInfo);
			}
		}

		private void CreateUniqueDevice(string deviceConditionID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo))
			{
				SpawnDevice(entityInfo, isDeviceUnique: true);
			}
		}

		private bool DoesUniqueDeviceExist(string deviceConditionID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo))
			{
				if (!deviceService.IsUniqueDeviceRegistered(entityInfo))
				{
					return devicesFromNpcsService.IsInteractiveObjectInsideDeliveryBox(entityInfo);
				}
				return true;
			}
			return false;
		}

		private void DestroyUniqueDevice(string deviceConditionID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo) && !devicesFromNpcsService.TryToRemoveInteractiveObjectFromDeliveryBox(entityInfo))
			{
				deviceService.DestroyRegisteredNonSellableDeviceContainer(entityInfo);
			}
		}

		private void TurnUniqueDeviceIntoRegularDevice(string deviceConditionID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo) && !devicesFromNpcsService.TryToTurnNonSellableInteractiveObjectInsideDeliveryBoxIntoRegularObject(entityInfo))
			{
				deviceService.TurnNonSellableDeviceIntoRegularDevice(entityInfo);
			}
		}

		private void SpawnDevice(DeviceCondition deviceCondition, bool isDeviceUnique = false)
		{
			if (isDeviceUnique)
			{
				devicesFromNpcsService.AddInteractiveObject(deviceCondition, new NonSellableInteractiveObjectProperty(deviceCondition));
			}
			else
			{
				devicesFromNpcsService.AddInteractiveObject(deviceCondition);
			}
		}
	}
}
