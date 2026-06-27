using System;
using System.Collections.Generic;
using Restory.Gameplay.Shops.Devices;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class DeviceShopSupplierSaveData
	{
		public List<IDeviceShopLot> ActiveLots { get; set; }

		public List<IElementsBoxLot> ActiveElementsBoxes { get; set; }

		public int SuppliedBatchCount { get; set; }

		public int LastSupplyDayNumber { get; set; }

		public List<IDeviceShopLot> RemainingLotsForToday { get; set; }

		public List<IElementsBoxLot> RemainingElementsBoxesForToday { get; set; }
	}
}
