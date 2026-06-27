using Restory.Data.Devices;
using UnityEngine;

namespace Restory.StorageSystem
{
	public interface IStorageItem
	{
		Sprite Icon { get; }

		string NameLocalizationKey { get; }

		string DescriptionLocalizationKey { get; }

		string DeviceNameLocalizationKey { get; }

		IDeviceCategory DeviceCategory { get; }

		IStorageItem Clone();
	}
}
