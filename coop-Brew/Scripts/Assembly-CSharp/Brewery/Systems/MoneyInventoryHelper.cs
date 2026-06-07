using Brewery.Items;
using InventorySystem;
using UnityEngine;

namespace Brewery.Systems
{
	public static class MoneyInventoryHelper
	{
		public static float CalculateTotalMoney(InventoryManager inventory)
		{
			return 0f;
		}

		public static bool SpendMoney(InventoryManager inventory, int amount)
		{
			return false;
		}

		public static int AddMoney(InventoryManager inventory, int amount)
		{
			return 0;
		}

		public static int GetCrateMoneyAmount(CrateMetadata metadata)
		{
			return 0;
		}

		public static bool IsMoneyOnlyCrate(CrateMetadata metadata)
		{
			return false;
		}

		public static int RemoveMoneyFromCrate(InventorySlot crateSlot, int amount)
		{
			return 0;
		}

		public static MoneyItem GetMoneyItem()
		{
			return null;
		}

		public static int AddMoneyWithOverflow(InventoryManager inventory, int amount, Transform playerTransform)
		{
			return 0;
		}

		public static void SpawnMoneyPickup(int amount, Vector3 position)
		{
		}
	}
}
