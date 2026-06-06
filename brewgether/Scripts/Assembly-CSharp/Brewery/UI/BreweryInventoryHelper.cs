using System;
using InventorySystem;

namespace Brewery.UI
{
	public static class BreweryInventoryHelper
	{
		public static InventoryManager GetLocalPlayerInventory()
		{
			return null;
		}

		public static bool TryLocateLocalPlayerInventory(ref InventoryManager currentInventory, Action<InventoryManager> onFound = null)
		{
			return false;
		}

		public static InventoryManager FindLocalPlayerInventoryInScene()
		{
			return null;
		}
	}
}
