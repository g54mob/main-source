using System;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Shops
{
	[Serializable]
	public class ShopInventoryItem : ShopItem
	{
		public BaseReceivable Item;

		public int StackSize;

		public override void Buy()
		{
			if (IsInStock() && HasResourcesToBuy() && HasCapacityToBuy())
			{
				SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.UseResources(Price.Resource, Price.Amount);
				Item.HandleReward();
				StackSize--;
			}
		}

		public override bool IsInStock()
		{
			return StackSize > 0;
		}

		public override bool HasCapacityToBuy()
		{
			switch (Item.Type())
			{
			case EReceivableType.DronePart:
				return true;
			case EReceivableType.Health:
				return SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth < SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
			case EReceivableType.Technology:
				if ((bool)Item.GetReward<WeaponAttributeUpgrade>())
				{
					return !Item.GetReward<WeaponAttributeUpgrade>().Unlocked;
				}
				return true;
			case EReceivableType.Upgrade:
			{
				UpgradeReceivable upgradeReceivable = (UpgradeReceivable)Item;
				return SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(upgradeReceivable.UpgradeType) < upgradeReceivable.Level;
			}
			default:
				return true;
			}
		}

		public override bool HasResourcesToBuy()
		{
			return SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.HasResources(Price.Resource, Price.Amount);
		}
	}
}
