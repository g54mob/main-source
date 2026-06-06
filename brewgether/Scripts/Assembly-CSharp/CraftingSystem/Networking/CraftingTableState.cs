using System;

namespace CraftingSystem.Networking
{
	[Serializable]
	public struct CraftingTableState
	{
		public CraftingTableSlotData[] inputSlots;

		public CraftingTableSlotData[] outputSlots;

		public string currentRecipe;

		public float craftingProgress;

		public bool isCrafting;

		public ulong currentUser;

		public string Serialize()
		{
			return null;
		}

		public static CraftingTableState Deserialize(string json)
		{
			return default(CraftingTableState);
		}
	}
}
