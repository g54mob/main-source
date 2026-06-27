using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Restory.Gameplay.Shops.Devices
{
	public class DeviceShoppingCart
	{
		private readonly List<ILot> lotsInCart = new List<ILot>();

		public IReadOnlyList<ILot> LotsInCart => lotsInCart;

		public bool TryAddToCart(ILot lot)
		{
			if (lotsInCart.Contains(lot))
			{
				Debug.LogError("lotsInCart contains lot " + lot.ID + " already");
				return false;
			}
			lotsInCart.Add(lot);
			return true;
		}

		public bool TryRemoveFromCart(ILot lot)
		{
			return lotsInCart.Remove(lot);
		}

		public int GetTotalCost()
		{
			return lotsInCart.Sum((ILot x) => x.Price);
		}

		public void Clear()
		{
			lotsInCart.Clear();
		}
	}
}
