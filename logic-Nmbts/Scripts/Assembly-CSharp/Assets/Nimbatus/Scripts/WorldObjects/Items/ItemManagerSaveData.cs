using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items
{
	[Serializable]
	public class ItemManagerSaveData
	{
		public List<string> UnlockedItems;

		public List<ItemStack> StackedItems;

		public List<WeaponPresetData> WeaponPresets;

		public bool StarterSetUnlocked;

		public ItemManagerSaveData()
		{
			UnlockedItems = new List<string>();
			StackedItems = new List<ItemStack>();
			WeaponPresets = new List<WeaponPresetData>();
		}
	}
}
