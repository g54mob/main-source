using System.Collections.Generic;
using Restory.Gameplay.Shops.Devices;
using UnityEngine;

namespace Restory.Gameplay.Shops
{
	public class ShopsService : MonoBehaviour
	{
		private readonly List<ILot> lots = new List<ILot>();

		public IReadOnlyList<ILot> Lots => lots;

		public void SupplyDeviceLots(IEnumerable<ILot> lots)
		{
			foreach (ILot lot in lots)
			{
				if (!this.lots.Contains(lot))
				{
					this.lots.Add(lot);
				}
			}
		}

		public void SupplyDeviceLot(ILot lot)
		{
			if (!lots.Contains(lot))
			{
				lots.Add(lot);
			}
		}

		public void RemoveDeviceFromShop(ILot lot)
		{
			if (!lots.Remove(lot))
			{
				Debug.LogError("Lot " + lot.ID + " not found in shop");
			}
		}
	}
}
