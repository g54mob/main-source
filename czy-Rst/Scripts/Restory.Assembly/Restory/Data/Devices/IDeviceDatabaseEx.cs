using System.Collections.Generic;
using Restory.Data.Elements;
using Restory.StorageSystem;
using Restory.StorageSystem.StorageElements;
using UnityEngine.Pool;

namespace Restory.Data.Devices
{
	public static class IDeviceDatabaseEx
	{
		public static void GetDevicePartInfos(this DeviceInfoDatabase database, List<IElementInfo> partInfos)
		{
			partInfos.Clear();
			HashSet<IElementInfo> hashSet = CollectionPool<HashSet<IElementInfo>, IElementInfo>.Get();
			database.GetDevicePartInfos(hashSet);
			partInfos.AddRange(hashSet);
			CollectionPool<HashSet<IElementInfo>, IElementInfo>.Release(hashSet);
		}

		public static void GetDevicePartInfos(this DeviceInfoDatabase database, HashSet<IElementInfo> partInfos)
		{
			partInfos.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				foreach (IElementInfo element in device.Elements)
				{
					partInfos.Add(element);
				}
			}
		}

		public static void GetDevicePartInfos(this DeviceInfoDatabase database, IDeviceCategory category, List<IElementInfo> partInfos)
		{
			partInfos.Clear();
			HashSet<IElementInfo> hashSet = CollectionPool<HashSet<IElementInfo>, IElementInfo>.Get();
			database.GetDevicePartInfos(category, hashSet);
			partInfos.AddRange(hashSet);
			CollectionPool<HashSet<IElementInfo>, IElementInfo>.Release(hashSet);
		}

		public static void GetDevicePartInfos(this DeviceInfoDatabase database, IDeviceCategory category, HashSet<IElementInfo> partInfos)
		{
			partInfos.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				if (device.Category != category)
				{
					continue;
				}
				foreach (IElementInfo element in device.Elements)
				{
					partInfos.Add(element);
				}
			}
		}

		public static void GetDevicePartInfos(this DeviceInfoDatabase database, string deviceModel, List<IElementInfo> partInfos)
		{
			partInfos.Clear();
			HashSet<IElementInfo> hashSet = CollectionPool<HashSet<IElementInfo>, IElementInfo>.Get();
			database.GetDevicePartInfos(deviceModel, hashSet);
			partInfos.AddRange(hashSet);
			CollectionPool<HashSet<IElementInfo>, IElementInfo>.Release(hashSet);
		}

		public static void GetDevicePartInfos(this DeviceInfoDatabase database, string deviceModel, HashSet<IElementInfo> partInfos)
		{
			partInfos.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				if (device.NameLocalizationKey != deviceModel)
				{
					continue;
				}
				foreach (IElementInfo element in device.Elements)
				{
					partInfos.Add(element);
				}
			}
		}

		public static void GetDevicePartInfos(this DeviceInfoDatabase database, IDeviceCategory category, string deviceModel, List<IElementInfo> partInfos)
		{
			partInfos.Clear();
			HashSet<IElementInfo> hashSet = CollectionPool<HashSet<IElementInfo>, IElementInfo>.Get();
			database.GetDevicePartInfos(category, deviceModel, hashSet);
			partInfos.AddRange(hashSet);
			CollectionPool<HashSet<IElementInfo>, IElementInfo>.Release(hashSet);
		}

		public static void GetDevicePartInfos(this DeviceInfoDatabase database, IDeviceCategory category, string deviceModel, HashSet<IElementInfo> partInfos)
		{
			partInfos.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				if (device.Category != category || device.NameLocalizationKey != deviceModel)
				{
					continue;
				}
				foreach (IElementInfo element in device.Elements)
				{
					partInfos.Add(element);
				}
			}
		}

		public static void GetAllDeviceCategories(this DeviceInfoDatabase database, List<IDeviceCategory> categories)
		{
			categories.Clear();
			HashSet<IDeviceCategory> hashSet = CollectionPool<HashSet<IDeviceCategory>, IDeviceCategory>.Get();
			database.GetAllDeviceCategories(hashSet);
			categories.AddRange(hashSet);
			CollectionPool<HashSet<IDeviceCategory>, IDeviceCategory>.Release(hashSet);
		}

		public static void GetAllDeviceCategories(this DeviceInfoDatabase database, HashSet<IDeviceCategory> categories)
		{
			categories.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				categories.Add(device.Category);
			}
		}

		public static void GetDeviceModels(this DeviceInfoDatabase database, IDeviceCategory category, List<string> deviceModels)
		{
			deviceModels.Clear();
			HashSet<string> hashSet = CollectionPool<HashSet<string>, string>.Get();
			database.GetDeviceModels(category, hashSet);
			deviceModels.AddRange(hashSet);
			CollectionPool<HashSet<string>, string>.Release(hashSet);
		}

		public static void GetDeviceModels(this DeviceInfoDatabase database, IDeviceCategory category, HashSet<string> deviceModels)
		{
			deviceModels.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				if (device.Category == category)
				{
					deviceModels.Add(device.NameLocalizationKey);
				}
			}
		}

		public static void GetDeviceModels(this DeviceInfoDatabase database, List<string> deviceModels)
		{
			deviceModels.Clear();
			HashSet<string> hashSet = CollectionPool<HashSet<string>, string>.Get();
			database.GetDeviceModels(hashSet);
			deviceModels.AddRange(hashSet);
			CollectionPool<HashSet<string>, string>.Release(hashSet);
		}

		public static void GetDeviceModels(this DeviceInfoDatabase database, HashSet<string> deviceModels)
		{
			deviceModels.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				deviceModels.Add(device.NameLocalizationKey);
			}
		}

		public static void GetDeviceCategoriesForPart(this DeviceInfoDatabase database, IElementInfo partInfo, HashSet<IDeviceCategory> categories)
		{
			categories.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				foreach (IElementInfo element in device.Elements)
				{
					if (element == partInfo)
					{
						categories.Add(device.Category);
						break;
					}
				}
			}
		}

		public static void GetDeviceCategoriesForPart(this DeviceInfoDatabase database, IElementInfo partInfo, List<IDeviceCategory> categories)
		{
			HashSet<IDeviceCategory> hashSet = CollectionPool<HashSet<IDeviceCategory>, IDeviceCategory>.Get();
			categories.Clear();
			database.GetDeviceCategoriesForPart(partInfo, hashSet);
			categories.AddRange(hashSet);
			CollectionPool<HashSet<IDeviceCategory>, IDeviceCategory>.Release(hashSet);
		}

		public static void GetDeviceCategoriesForParts(this DeviceInfoDatabase database, IEnumerable<IElementInfo> partInfos, HashSet<IDeviceCategory> categories)
		{
			categories.Clear();
			foreach (IElementInfo partInfo in partInfos)
			{
				foreach (IDeviceInfo device in database.Devices)
				{
					foreach (IElementInfo element in device.Elements)
					{
						if (element == partInfo)
						{
							categories.Add(device.Category);
							break;
						}
					}
				}
			}
		}

		public static void GetDeviceCategoriesForParts(this DeviceInfoDatabase database, IEnumerable<IElementInfo> partInfos, List<IDeviceCategory> categories)
		{
			HashSet<IDeviceCategory> hashSet = CollectionPool<HashSet<IDeviceCategory>, IDeviceCategory>.Get();
			categories.Clear();
			database.GetDeviceCategoriesForParts(partInfos, hashSet);
			categories.AddRange(hashSet);
			CollectionPool<HashSet<IDeviceCategory>, IDeviceCategory>.Release(hashSet);
		}

		public static void GetDeviceModelsForPart(this DeviceInfoDatabase database, IElementInfo partInfo, HashSet<string> models)
		{
			models.Clear();
			foreach (IDeviceInfo device in database.Devices)
			{
				foreach (IElementInfo element in device.Elements)
				{
					if (element == partInfo)
					{
						models.Add(device.NameLocalizationKey);
						break;
					}
				}
			}
		}

		public static void GetDeviceModelsForPart(this DeviceInfoDatabase database, IElementInfo partInfo, List<string> models)
		{
			HashSet<string> hashSet = CollectionPool<HashSet<string>, string>.Get();
			models.Clear();
			database.GetDeviceModelsForPart(partInfo, hashSet);
			models.AddRange(hashSet);
			CollectionPool<HashSet<string>, string>.Release(hashSet);
		}

		public static void GetDeviceModelsForParts(this DeviceInfoDatabase database, IEnumerable<IElementInfo> partInfos, HashSet<string> models)
		{
			models.Clear();
			foreach (IElementInfo partInfo in partInfos)
			{
				foreach (IDeviceInfo device in database.Devices)
				{
					foreach (IElementInfo element in device.Elements)
					{
						if (element == partInfo)
						{
							models.Add(device.NameLocalizationKey);
							break;
						}
					}
				}
			}
		}

		public static void GetDeviceModelsForParts(this DeviceInfoDatabase database, IEnumerable<IElementInfo> partInfos, List<string> models)
		{
			HashSet<string> hashSet = CollectionPool<HashSet<string>, string>.Get();
			models.Clear();
			database.GetDeviceModelsForParts(partInfos, hashSet);
			models.AddRange(hashSet);
			CollectionPool<HashSet<string>, string>.Release(hashSet);
		}

		public static void GetStorageState(this DeviceInfoDatabase database, IEnumerable<IReadOnlyStorageSlot> slots, HashSet<string> models, HashSet<IDeviceCategory> categories)
		{
			models.Clear();
			categories.Clear();
			foreach (IReadOnlyStorageSlot slot in slots)
			{
				if (!(slot.Item is StorageItemElement storageItemElement))
				{
					continue;
				}
				foreach (IDeviceInfo device in database.Devices)
				{
					foreach (IElementInfo element in device.Elements)
					{
						if (element == storageItemElement.Info)
						{
							models.Add(device.NameLocalizationKey);
							categories.Add(device.Category);
							break;
						}
					}
				}
			}
		}
	}
}
