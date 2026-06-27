using System;
using System.Collections.Generic;
using System.Text;
using Mandragora.Utils;
using Restory.Data.Devices;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Gameplay.Shops.Devices
{
	public class DeviceShopRandomDevicesUniqueTextsService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		[SerializeField]
		private DeviceShopLotsDevicesUniqueTextsCollection deviceTextsCollection;

		[SerializeField]
		private DeviceShopLotsDeviceCategoriesUniqueTextsCollection deviceCategoriesTextsCollection;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool isInDebugMode;

		private readonly Dictionary<string, List<string>> remainingDevicesTexts = new Dictionary<string, List<string>>();

		private readonly Dictionary<string, List<string>> remainingDeviceCategoriesTexts = new Dictionary<string, List<string>>();

		private DeviceShopRandomDevicesUniqueTextsServiceSaveData restoredState;

		public bool TryGetRemainingLocalizationKeyForDevice(DeviceInfo device, out string textLocalizationKey)
		{
			if (!device || !remainingDevicesTexts.TryGetValue(device.ID, out var value) || value.Count == 0)
			{
				if (isInDebugMode)
				{
					Debug.Log("[DeviceShopRandomDevicesUniqueTextsService] tried to find a localization key for device with ID '" + device.ID + "', but there are no unused keys left for that device.");
				}
				textLocalizationKey = string.Empty;
				return false;
			}
			int index = UnityEngine.Random.Range(0, value.Count);
			textLocalizationKey = value[index];
			value.RemoveAt(index);
			if (isInDebugMode)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("[DeviceShopRandomDevicesUniqueTextsService] found localization key '" + textLocalizationKey + "' for device with ID '" + device.ID + "', " + $"keys for that device remaining (total count - {value.Count}):");
				foreach (string item in value)
				{
					stringBuilder.AppendLine(item);
				}
				Debug.Log(stringBuilder.ToString());
			}
			return true;
		}

		public bool TryGetRemainingLocalizationKeyForDeviceCategory(DeviceCategory deviceCategory, out string textLocalizationKey)
		{
			if (!deviceCategory || !remainingDeviceCategoriesTexts.TryGetValue(deviceCategory.ID, out var value) || value.Count == 0)
			{
				if (isInDebugMode)
				{
					Debug.Log("[DeviceShopRandomDevicesUniqueTextsService] tried to find a localization key for device category with ID '" + deviceCategory.ID + "', but there are no unused keys left for that category.");
				}
				textLocalizationKey = string.Empty;
				return false;
			}
			int index = UnityEngine.Random.Range(0, value.Count);
			textLocalizationKey = value[index];
			value.RemoveAt(index);
			if (isInDebugMode)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("[DeviceShopRandomDevicesUniqueTextsService] found localization key '" + textLocalizationKey + "' for device category with ID '" + deviceCategory.ID + "', " + $"keys for that category remaining (total count - {value.Count}):");
				foreach (string item in value)
				{
					stringBuilder.AppendLine(item);
				}
				Debug.Log(stringBuilder.ToString());
			}
			return true;
		}

		public object CaptureState()
		{
			try
			{
				List<string> value;
				using (CollectionPool<List<string>, string>.Get(out value))
				{
					AddDevicesUsedLocalizationKeysToList(value);
					AddDeviceCategoriesUsedLocalizationKeysToList(value);
					return new DeviceShopRandomDevicesUniqueTextsServiceSaveData
					{
						UsedKeys = value.ToArray()
					};
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				restoredState = DataMigrationWizard.Migrate<DeviceShopRandomDevicesUniqueTextsServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if (restoredState != null)
			{
				RestoreDeviceTexts(restoredState);
				RestoreDeviceCategoriesTexts(restoredState);
				return;
			}
			foreach (DeviceShopLotsDeviceUniqueTexts devicesUniqueText in deviceTextsCollection.DevicesUniqueTexts)
			{
				List<string> list = new List<string>();
				list.AddRange(devicesUniqueText.LocalizationKeys);
				remainingDevicesTexts.Add(devicesUniqueText.Device.ID, list);
			}
			foreach (DeviceShopLotsDeviceCategoryUniqueTexts deviceCategoriesUniqueText in deviceCategoriesTextsCollection.DeviceCategoriesUniqueTexts)
			{
				List<string> list2 = new List<string>();
				list2.AddRange(deviceCategoriesUniqueText.LocalizationKeys);
				remainingDeviceCategoriesTexts.Add(deviceCategoriesUniqueText.DeviceCategory.ID, list2);
			}
		}

		private void AddDevicesUsedLocalizationKeysToList(List<string> usedLocalizationKeys)
		{
			foreach (DeviceShopLotsDeviceUniqueTexts devicesUniqueText in deviceTextsCollection.DevicesUniqueTexts)
			{
				if (!devicesUniqueText.Device || !remainingDevicesTexts.TryGetValue(devicesUniqueText.Device.ID, out var value))
				{
					continue;
				}
				foreach (string localizationKey in devicesUniqueText.LocalizationKeys)
				{
					if (!IsKeyInCollection(localizationKey, value))
					{
						usedLocalizationKeys.Add(localizationKey);
					}
				}
			}
		}

		private void AddDeviceCategoriesUsedLocalizationKeysToList(List<string> usedLocalizationKeys)
		{
			foreach (DeviceShopLotsDeviceCategoryUniqueTexts deviceCategoriesUniqueText in deviceCategoriesTextsCollection.DeviceCategoriesUniqueTexts)
			{
				if (!deviceCategoriesUniqueText.DeviceCategory || !remainingDeviceCategoriesTexts.TryGetValue(deviceCategoriesUniqueText.DeviceCategory.ID, out var value))
				{
					continue;
				}
				foreach (string localizationKey in deviceCategoriesUniqueText.LocalizationKeys)
				{
					if (!IsKeyInCollection(localizationKey, value))
					{
						usedLocalizationKeys.Add(localizationKey);
					}
				}
			}
		}

		private void RestoreDeviceTexts(DeviceShopRandomDevicesUniqueTextsServiceSaveData restoredState)
		{
			remainingDevicesTexts.Clear();
			foreach (DeviceShopLotsDeviceUniqueTexts devicesUniqueText in deviceTextsCollection.DevicesUniqueTexts)
			{
				if (!devicesUniqueText.Device)
				{
					continue;
				}
				if (remainingDevicesTexts.TryGetValue(devicesUniqueText.Device.ID, out var value))
				{
					foreach (string localizationKey in devicesUniqueText.LocalizationKeys)
					{
						if (!IsKeyInCollection(localizationKey, restoredState.UsedKeys))
						{
							value.Add(localizationKey);
						}
					}
					continue;
				}
				List<string> list = new List<string>();
				remainingDevicesTexts.Add(devicesUniqueText.Device.ID, list);
				foreach (string localizationKey2 in devicesUniqueText.LocalizationKeys)
				{
					if (!IsKeyInCollection(localizationKey2, restoredState.UsedKeys))
					{
						list.Add(localizationKey2);
					}
				}
			}
		}

		private void RestoreDeviceCategoriesTexts(DeviceShopRandomDevicesUniqueTextsServiceSaveData restoredState)
		{
			remainingDeviceCategoriesTexts.Clear();
			foreach (DeviceShopLotsDeviceCategoryUniqueTexts deviceCategoriesUniqueText in deviceCategoriesTextsCollection.DeviceCategoriesUniqueTexts)
			{
				if (!deviceCategoriesUniqueText.DeviceCategory)
				{
					continue;
				}
				if (remainingDeviceCategoriesTexts.TryGetValue(deviceCategoriesUniqueText.DeviceCategory.ID, out var value))
				{
					foreach (string localizationKey in deviceCategoriesUniqueText.LocalizationKeys)
					{
						if (!IsKeyInCollection(localizationKey, restoredState.UsedKeys))
						{
							value.Add(localizationKey);
						}
					}
					continue;
				}
				List<string> list = new List<string>();
				remainingDeviceCategoriesTexts.Add(deviceCategoriesUniqueText.DeviceCategory.ID, list);
				foreach (string localizationKey2 in deviceCategoriesUniqueText.LocalizationKeys)
				{
					if (!IsKeyInCollection(localizationKey2, restoredState.UsedKeys))
					{
						list.Add(localizationKey2);
					}
				}
			}
		}

		private static bool IsKeyInCollection(string localizationKey, IEnumerable<string> keysCollection)
		{
			foreach (string item in keysCollection)
			{
				if (localizationKey == item)
				{
					return true;
				}
			}
			return false;
		}
	}
}
