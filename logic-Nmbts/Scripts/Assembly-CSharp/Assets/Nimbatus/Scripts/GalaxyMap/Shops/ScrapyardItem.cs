using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Shops
{
	public class ScrapyardItem : ShopItem
	{
		public NimbatusItem Item;

		public override void Buy()
		{
			if (IsInStock() && HasResourcesToBuy() && HasCapacityToBuy())
			{
				Item.CurrentStackSize--;
				WeaponPreset weaponPreset = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponPresets.FirstOrDefault((WeaponPreset p) => p.UniqueID == Item.UniqueId);
				if (weaponPreset != null)
				{
					weaponPreset.StackSize--;
				}
				OreReceivable oreReceivable = new OreReceivable();
				oreReceivable.Amount = Price.Amount;
				oreReceivable.Reward = Price.Resource;
				oreReceivable.HandleReward();
			}
		}

		public override bool IsInStock()
		{
			return true;
		}

		public override bool HasCapacityToBuy()
		{
			return true;
		}

		public override bool HasResourcesToBuy()
		{
			return Item.CurrentStackSize > 0;
		}
	}
}
