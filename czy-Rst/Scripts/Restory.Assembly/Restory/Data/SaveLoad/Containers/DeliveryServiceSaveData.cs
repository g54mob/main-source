using System;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Data.InteractiveObjects;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Shops.Devices;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class DeliveryServiceSaveData
	{
		public List<InteractiveObjectInfo> PurchasedObjects;

		public HeldElements PurchasedElements;

		public List<PaintingPaletteInfo> PurchasedPalettes;

		public List<GeneratedDeviceForDelivery> GeneratedDevices;

		public List<ContainedInteractiveObject> DeliveryBoxContent;

		public HeldElements ElementsInBox;

		public List<PaintingPaletteInfo> PalettesInBox;

		public InteractiveObjectData DeliveryBoxData;

		public List<ElementsBoxData> PurchasedElementsBoxes;
	}
}
