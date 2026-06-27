using System;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.StorageSystem.StorageElements
{
	[Serializable]
	public class StorageItemElement : IStorageItemStackable, IStorageItem
	{
		[SerializeField]
		private ElementData elementData;

		public IElementInfo Info => elementData.Info;

		public Sprite Icon => elementData.Info.Icon;

		public string NameLocalizationKey => elementData.Info.NameLocalizationKey;

		public string DescriptionLocalizationKey
		{
			get
			{
				if (!(elementData.Info.SourceDevice is DeviceInfo deviceInfo))
				{
					return string.Empty;
				}
				return deviceInfo.NameLocalizationKey;
			}
		}

		public int MaxStackCount => elementData.Info.MaxStackCount;

		public string DeviceNameLocalizationKey
		{
			get
			{
				if (elementData.Info.SourceDevice != null)
				{
					return elementData.Info.SourceDevice.NameLocalizationKey;
				}
				return string.Empty;
			}
		}

		public IDeviceCategory DeviceCategory => elementData.Info.SourceDevice?.Category;

		public ElementData ElementData => elementData;

		public StorageItemElement(ElementData elementData)
		{
			this.elementData = elementData;
		}

		public bool CanStackWith(IStorageItemStackable item)
		{
			return false;
		}

		public IStorageItem Clone()
		{
			return new StorageItemElement(elementData);
		}
	}
}
