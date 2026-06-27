using System;
using Restory.Data.Devices;
using Restory.Data.Devices.Quality;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class DeviceData
	{
		public string UniqueID;

		public DeviceInfo DeviceInfo;

		public SerializableTransform DeviceTransform;

		public InteractiveObjectState DeviceState;

		public ElementData[] InstalledElements;

		public PlacedElementsData PlacedElements;

		public int PaintTextureId;

		public DeviceQualityBase PrevKnownQuality;

		public DeviceQualityBase Quality;

		public string StorageID;

		public InteractiveObjectAdditionalProperties InteractiveObjectAdditionalProperties;
	}
}
